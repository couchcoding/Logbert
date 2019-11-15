#region Copyright © 2015 Couchcoding

// File:    Log4NetFileReceiver.cs
// Package: Logbert
// Project: Logbert
// 
// The MIT License (MIT)
// 
// Copyright (c) 2015 Couchcoding
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

#endregion

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Couchcoding.Logbert.Interfaces;

using Couchcoding.Logbert.Controls;
using Couchcoding.Logbert.Helper;
using Couchcoding.Logbert.Logging;

namespace Couchcoding.Logbert.Receiver.Log4NetDirReceiver
{
  /// <summary>
  /// Implements a <see cref="ILogProvider"/> for the Log4Net file service.
  /// </summary>
  public class Log4NetDirReceiver : ReceiverBase
  {
    #region Private Consts

    /// <summary>
    /// Defines the end tag of a Log4Net message.
    /// </summary>
    private const string LOG4NET_LOGMSG_END = "</log4j:event>";

    #endregion

    #region Private Classes

    /// <summary>
    /// Implements a string comparer that supports natural sorting.
    /// </summary>
    private sealed class NaturalStringComparer : IComparer<string>
    {
      /// <summary>Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.</summary>
      /// <returns>A signed integer that indicates the relative values of <paramref name="a" /> and <paramref name="b" />, as shown in the following table.Value Meaning Less than zero<paramref name="a" /> is less than <paramref name="b" />.Zero<paramref name="a" /> equals <paramref name="b" />.Greater than zero<paramref name="a" /> is greater than <paramref name="b" />.</returns>
      /// <param name="a">The first object to compare.</param>
      /// <param name="b">The second object to compare.</param>
      public int Compare(string a, string b)
      {
        return Win32.StrCmpLogicalW(a, b);
      }
    }

    #endregion

    #region Private Fields

    /// <summary>
    /// Holds the name of the directory to observe.
    /// </summary>
    private readonly string mDirectoryToObserve;

    /// <summary>
    /// Determines whether the file to observed should be read from beginning, or not.
    /// </summary>
    private readonly bool mStartFromBeginning;

    /// <summary>
    /// Holds the filename pattern to observe.
    /// </summary>
    private readonly string mFilenamePattern;

    /// <summary>
    /// Holds the currently observed log file.
    /// </summary>
    private string mCurrentLogFile;

    /// <summary>
    /// The <see cref="FileSystemWatcher"/> used to observe file content changes.
    /// </summary>
    private FileSystemWatcher mFileWatcher;

    /// <summary>
    /// The <see cref="StreamReader"/> used to read the log file content.
    /// </summary>
    private StreamReader mFileReader;

    /// <summary>
    /// Holds the offset of the last read line within the log file.
    /// </summary>
    private long mLastFileOffset;

    /// <summary>
    /// Counts the received messages;
    /// </summary>
    private int mLogNumber;

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets the name of the <see cref="ILogProvider"/>.
    /// </summary>
    public override string Name => "Log4Net Dir Receiver";

    /// <summary>
    /// Gets the description of the <see cref="ILogProvider"/>
    /// </summary>
    public override string Description => $"{Name} ({(!string.IsNullOrEmpty(mDirectoryToObserve) ? Path.GetDirectoryName(mDirectoryToObserve) : "-")})";

    /// <summary>
    /// Gets the filename for export of the received <see cref="LogMessage"/>s.
    /// </summary>
    public override string ExportFileName => Description;

    /// <summary>
    /// Gets the tooltip to display at the document tab.
    /// </summary>
    public override string Tooltip => mDirectoryToObserve;

    /// <summary>
    /// Gets the settings <see cref="Control"/> of the <see cref="ILogProvider"/>.
    /// </summary>
    public override ILogSettingsCtrl Settings => new Log4NetDirReceiverSettings();

    /// <summary>
    /// Gets the columns to display of the <see cref="ILogProvider"/>.
    /// </summary>
    public override Dictionary<int, LogColumnData> Columns
    {
      get
      {
        string[] visibleVal = Properties.Settings.Default.ColumnVisibleLog4NetDirReceiver.Split(',');
        string[] widthVal   = Properties.Settings.Default.ColumnWidthLog4NetDirReceiver.Split(',');

        return new Dictionary<int, LogColumnData>
        {
          { 0, new LogColumnData("Number",    visibleVal[0] == "1", int.Parse(widthVal[0])) },
          { 1, new LogColumnData("Level",     visibleVal[1] == "1", int.Parse(widthVal[1])) },
          { 2, new LogColumnData("Timestamp", visibleVal[2] == "1", int.Parse(widthVal[2])) },
          { 3, new LogColumnData("Logger",    visibleVal[3] == "1", int.Parse(widthVal[3])) },
          { 4, new LogColumnData("Thread",    visibleVal[4] == "1", int.Parse(widthVal[4])) },
          { 5, new LogColumnData("Message",   visibleVal[5] == "1", int.Parse(widthVal[5])) }
        };
      }
    } 

    /// <summary>
    /// Gets or sets the active state if the <see cref="ILogProvider"/>.
    /// </summary>
    public override bool IsActive
    {
      get
      {
        return base.IsActive;
      }
      set
      {
        base.IsActive = value;

        if (mFileWatcher != null)
        {
          // Update the observer state.
          mFileWatcher.EnableRaisingEvents = base.IsActive;
        }
      }
    }

    /// <summary>
    /// Get the <see cref="Control"/> to display details about a selected <see cref="LogMessage"/>.
    /// </summary>
    public override ILogPresenter DetailsControl => new Log4NetDetailsControl();

    #endregion

    #region Private Methods

    /// <summary>
    /// Handles the FileChanged event of the <see cref="FileSystemWatcher"/> instance.
    /// </summary>
    private void OnLogFileChanged(object sender, FileSystemEventArgs e)
    {
      if (e.ChangeType == WatcherChangeTypes.Changed)
      {
        if (string.IsNullOrEmpty(mCurrentLogFile) && Regex.IsMatch(e.FullPath, mFilenamePattern))
        {
          // Set the one and only file as file to observe.
          mCurrentLogFile = e.FullPath;
        }

        if (e.FullPath.Equals(mCurrentLogFile))
        {
          ReadNewLogMessagesFromFile();
        }
      }
    }

    /// <summary>
    /// Handles the Error event of the <see cref="FileSystemWatcher"/>.
    /// </summary>
    private void OnFileWatcherError(object sender, ErrorEventArgs e)
    {
      // Stop further listening on error.
      if (mFileWatcher != null)
      {
        mFileWatcher.EnableRaisingEvents = false;
        mFileWatcher.Changed -= OnLogFileChanged;
        mFileWatcher.Created -= OnLogFileChanged;
        mFileWatcher.Error   -= OnFileWatcherError;

        mFileWatcher.Dispose();
      }

      Initialize(mLogHandler);
    }

    /// <summary>
    /// Reads possible new log file entries form the file that is observed.
    /// </summary>
    private void ReadNewLogMessagesFromFile()
    {
      if (mFileReader == null || Equals(mFileReader.BaseStream.Length, mLastFileOffset))
      {
        return;
      }

      if (mLastFileOffset > mFileReader.BaseStream.Length)
      {
        // the current log file was re-created. Observe from beginning on.
        mLastFileOffset = 0;
      }

      mFileReader.BaseStream.Seek(
          mLastFileOffset
        , SeekOrigin.Begin);

      string line;
      string dataToParse = string.Empty;

      FixedSizedQueue<LogMessage> messages = new FixedSizedQueue<LogMessage>(
        Properties.Settings.Default.MaxLogMessages);

      while ((line = mFileReader.ReadLine()) != null)
      {
        dataToParse += line;

        int log4NetEndTag = dataToParse.IndexOf(
            LOG4NET_LOGMSG_END
          , StringComparison.Ordinal);

        if (log4NetEndTag > 0)
        {
          LogMessage newLogMsg;

          try
          {
            newLogMsg = new LogMessageLog4Net(
                dataToParse
              , ++mLogNumber);
          }
          catch (Exception ex)
          {
            Logger.Warn(ex.Message);
            continue;
          }

          messages.Enqueue(newLogMsg);

          dataToParse = dataToParse.Substring(
              log4NetEndTag
            , dataToParse.Length - (log4NetEndTag + LOG4NET_LOGMSG_END.Length));
        }
      }

      mLastFileOffset = mFileReader.BaseStream.Position;

      mLogHandler?.HandleMessage(messages.ToArray());
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString()
    {
      return Name;
    }

    /// <summary>
    /// Intizializes the <see cref="ILogProvider"/>.
    /// </summary>
    /// <param name="logHandler">The <see cref="ILogHandler"/> that may handle incomming <see cref="LogMessage"/>s.</param>
    public override void Initialize(ILogHandler logHandler)
    {
      base.Initialize(logHandler);

      Regex filePattern           = new Regex(mFilenamePattern);
      DirectoryInfo dirInfo       = new DirectoryInfo(mDirectoryToObserve);
      List<string> collectedFiles = new List<string>();

      foreach (FileInfo fInfo in dirInfo.GetFiles())
      {
        if (filePattern.IsMatch(fInfo.FullName))
        {
          collectedFiles.Add(fInfo.FullName);
        }
      }

      // Ensure the list of files is natural sorted.
      collectedFiles.Sort(new NaturalStringComparer());

      mLogNumber = 0;

      if (mStartFromBeginning)
      {
        for (int i = collectedFiles.Count - 1; i > 0; i--)
        {
          using (mFileReader = new StreamReader(new FileStream(collectedFiles[i], FileMode.Open, FileAccess.Read, FileShare.ReadWrite), mEncoding))
          {
            // Reset file offset count.
            mLastFileOffset = 0;

            // Read the current file.
            ReadNewLogMessagesFromFile();
          }
        }
      }

      if (collectedFiles.Count > 0)
      {
        // The very first file (without decimal suffix) is the current log file.
        mCurrentLogFile = collectedFiles[0];

        mFileReader = new StreamReader(new FileStream(
            mCurrentLogFile
          , FileMode.Open
          , FileAccess.Read
          , FileShare.ReadWrite)
          , mEncoding);

        if (!mStartFromBeginning)
        {
          // Ommit the already logged data.
          mLastFileOffset = mFileReader.BaseStream.Length;
        }

        ReadNewLogMessagesFromFile();
      }

      mFileWatcher = new FileSystemWatcher(mDirectoryToObserve);

      mFileWatcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.Size | NotifyFilters.FileName;
      mFileWatcher.Changed     += OnLogFileChanged;
      mFileWatcher.Created     += OnLogFileChanged;
      mFileWatcher.Error       += OnFileWatcherError;

      mFileWatcher.EnableRaisingEvents = IsActive;
    }

    /// <summary>
    /// Resets the <see cref="ILogProvider"/> instance.
    /// </summary>
    public override void Clear()
    {
      mLogNumber = 0;
    }

    /// <summary>
    /// Resets the <see cref="ILogProvider"/> instance.
    /// </summary>
    public override void Reset()
    {
      Shutdown();
      Initialize(mLogHandler);
    }

    /// <summary>
    /// Shuts down the <see cref="ILogProvider"/> instance.
    /// </summary>
    public override void Shutdown()
    {
      base.Shutdown();

      if (mFileWatcher != null)
      {
        mFileWatcher.EnableRaisingEvents = false;
        mFileWatcher.Changed            -= OnLogFileChanged;
        mFileWatcher.Created            -= OnLogFileChanged;
        mFileWatcher.Error              -= OnFileWatcherError;
        mFileWatcher.Dispose();
      }

      if (mFileReader != null)
      {
        mFileReader.Close();
        mFileReader = null;
      }
    }

    /// <summary>
    /// Gets the header used for the CSV file export.
    /// </summary>
    /// <returns></returns>
    public override string GetCsvHeader()
    {
      return "\"Number\","
           + "\"Level\","
           + "\"Timestamp\","
           + "\"Logger\","
           + "\"Thread\","
           + "\"Message\","
           + "\"Location\","
           + "\"Custom Data\""
           + Environment.NewLine;
    }

    /// <summary>
    /// Determines whether the <see cref="ReceiverBase"/> instance can handle the given file name as log file.
    /// </summary>
    /// <returns><c>True</c> if the file can be handled, otherwise <c>false</c>.</returns>
    public override bool CanHandleLogFile()
    {
      return !string.IsNullOrEmpty(mDirectoryToObserve) && Directory.Exists(mDirectoryToObserve);
    }

    /// <summary>
    /// Saves the current docking and collumn layout of the <see cref="ILogProvider"/> implementation.
    /// </summary>
    /// <param name="layout">The layout as string to save.</param>
    /// <param name="columnLayout">The current column layout to save.</param>
    public override void SaveLayout(string layout, List<LogColumnData> columnLayout)
    {
      Properties.Settings.Default.DockLayoutLog4NetDirReceiver = layout ?? string.Empty;

      Properties.Settings.Default.ColumnVisibleLog4NetDirReceiver = string.Format(
          "{0},{1},{2},{3},{4},{5}"
        , columnLayout[0].Visible ? 1 : 0
        , columnLayout[1].Visible ? 1 : 0
        , columnLayout[2].Visible ? 1 : 0
        , columnLayout[3].Visible ? 1 : 0
        , columnLayout[4].Visible ? 1 : 0
        , columnLayout[5].Visible ? 1 : 0);

      Properties.Settings.Default.ColumnWidthLog4NetDirReceiver = string.Format(
          "{0},{1},{2},{3},{4},{5}"
        , columnLayout[0].Width
        , columnLayout[1].Width
        , columnLayout[2].Width
        , columnLayout[3].Width
        , columnLayout[4].Width
        , columnLayout[5].Width);

      Properties.Settings.Default.SaveSettings();
    }

    /// <summary>
    /// Loads the docking layout of the <see cref="ReceiverBase"/> instance.
    /// </summary>
    /// <returns>The restored layout, or <c>null</c> if none exists.</returns>
    public override string LoadLayout()
    {
      return Properties.Settings.Default.DockLayoutLog4NetDirReceiver;
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Creates a new and empty instance of the <see cref="Log4NetDirReceiver"/> class.
    /// </summary>
    public Log4NetDirReceiver()
    {

    }

    /// <summary>
    /// Creates a new and configured instance of the <see cref="Log4NetDirReceiver"/> class.
    /// </summary>
    /// <param name="directoryToObserve">The directory the new <see cref="Log4NetDirReceiver"/> instance should observe.</param>
    /// <param name="filenamePattern">The <see cref="Regex"/> to find the files to load and observe.</param>
    /// <param name="startFromBeginning">Determines whether the new <see cref="Log4NetDirReceiver"/> should read all files within the given <paramref name="directoryToObserve"/>, or not.</param>
    /// <param name="codePage">The codepage to use for encoding of the data to parse.</param>
    public Log4NetDirReceiver(string directoryToObserve, string filenamePattern, bool startFromBeginning, int codePage) : base(codePage)
    {
      mDirectoryToObserve = directoryToObserve;
      mFilenamePattern    = filenamePattern;
      mStartFromBeginning = startFromBeginning;
    }

    #endregion
  }
}
