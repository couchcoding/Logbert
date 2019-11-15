#region Copyright © 2015 Couchcoding

// File:    SyslogFileReceiver.cs
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
using System.Text;

using Couchcoding.Logbert.Interfaces;

using Couchcoding.Logbert.Logging;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using Couchcoding.Logbert.Controls;
using Couchcoding.Logbert.Helper;

namespace Couchcoding.Logbert.Receiver.SyslogFileReceiver
{
  /// <summary>
  /// Implements a <see cref="ILogProvider"/> for the Log4Net file service.
  /// </summary>
  public class SyslogFileReceiver : ReceiverBase
  {
    #region Private Fields

    /// <summary>
    /// Holds the name of the File to observe.
    /// </summary>
    private readonly string mFileToObserve;

    /// <summary>
    /// The format of the timestamp of a received message.
    /// </summary>
    private readonly string mTimestampFormat;

    /// <summary>
    /// Determines whether the file to observed should be read from beginning, or not.
    /// </summary>
    private readonly bool mStartFromBeginning;

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
    public override string Name
    {
      get
      {
        return "Syslog File Receiver";
      }
    }

    /// <summary>
    /// Gets the description of the <see cref="ILogProvider"/>
    /// </summary>
    public override string Description
    {
      get
      {
        return string.Format(
            "{0} ({1})"
          , Name
          , !string.IsNullOrEmpty(mFileToObserve) ? Path.GetFileName(mFileToObserve) : "-");
      }
    }

    /// <summary>
    /// Gets the filename for export of the received <see cref="LogMessage"/>s.
    /// </summary>
    public override string ExportFileName
    {
      get
      {
        return Description;
      }
    }

    /// <summary>
    /// Gets the tooltip to display at the document tab.
    /// </summary>
    public override string Tooltip
    {
      get
      {
        return mFileToObserve;
      }
    }

    /// <summary>
    /// Gets the settings <see cref="Control"/> of the <see cref="ILogProvider"/>.
    /// </summary>
    public override ILogSettingsCtrl Settings
    {
      get
      {
        return new SyslogFileReceiverSettings();
      }
    }

    /// <summary>
    /// Gets the columns to display of the <see cref="ILogProvider"/>.
    /// </summary>
    public override Dictionary<int, LogColumnData> Columns
    {
      get
      {
        string[] visibleVal = Properties.Settings.Default.ColumnVisibleSyslogFileReceiver.Split(',');
        string[] widthVal   = Properties.Settings.Default.ColumnWidthSyslogFileReceiver.Split(',');

        return new Dictionary<int, LogColumnData>
        {
          { 0, new LogColumnData("Number",             visibleVal[0] == "1", int.Parse(widthVal[0])) },
          { 1, new LogColumnData("Severity",           visibleVal[1] == "1", int.Parse(widthVal[1])) },
          { 2, new LogColumnData("Local Machine Time", visibleVal[2] == "1", int.Parse(widthVal[2])) },
          { 3, new LogColumnData("Time",               visibleVal[3] == "1", int.Parse(widthVal[3])) },
          { 4, new LogColumnData("Facility",           visibleVal[4] == "1", int.Parse(widthVal[4])) },
          { 5, new LogColumnData("Sender",             visibleVal[5] == "1", int.Parse(widthVal[5])) },
          { 6, new LogColumnData("Message",            visibleVal[6] == "1", int.Parse(widthVal[6])) }
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
    public override ILogPresenter DetailsControl
    {
      get
      {
        return new SyslogDetailsControl();
      }
    }

    /// <summary>
    /// Gets the supported <see cref="LogLevel"/>s of the <see cref="ILogProvider"/>.
    /// </summary>
    public override LogLevel SupportedLevels => LogLevel.All;

    /// <summary>
    /// Gets the path seperator for the logger tree.
    /// </summary>
    public override string LoggerTreePathSeperator
    {
      get
      {
        return "\t";
      }
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Handles the FileChanged event of the <see cref="FileSystemWatcher"/> instance.
    /// </summary>
    private void OnLogFileChanged(object sender, FileSystemEventArgs e)
    {
      if (e.ChangeType == WatcherChangeTypes.Changed)
      {
        ReadNewLogMessagesFromFile();
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
        mFileWatcher.Changed            -= OnLogFileChanged;
        mFileWatcher.Error              -= OnFileWatcherError;
        mFileWatcher.Dispose();
      }

      string pathOfFile = Path.GetDirectoryName(mFileToObserve);
      string nameOfFile = Path.GetFileName(mFileToObserve);

      if (!string.IsNullOrEmpty(pathOfFile) && !string.IsNullOrEmpty(nameOfFile))
      {
        mFileWatcher = new FileSystemWatcher(pathOfFile, nameOfFile)
        {
          NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.Size
        };

        mFileWatcher.Changed            += OnLogFileChanged;
        mFileWatcher.Error              += OnFileWatcherError;
        mFileWatcher.EnableRaisingEvents = IsActive;

        ReadNewLogMessagesFromFile();
      }
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

      mFileReader.BaseStream.Seek(
        mLastFileOffset
        , SeekOrigin.Begin);

      string line;

      FixedSizedQueue<LogMessage> messages = new FixedSizedQueue<LogMessage>(
        Properties.Settings.Default.MaxLogMessages);

      while ((line = mFileReader.ReadLine()) != null)
      {
        if (string.IsNullOrEmpty(line))
        {
          continue;
        }

        try
        {
          messages.Enqueue(new LogMessageSyslog(
            line
            , ++mLogNumber
            , mTimestampFormat));
        }
        catch (Exception ex)
        {
          Logger.Warn(ex.Message);
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

      mFileReader = new StreamReader(new FileStream(
          mFileToObserve
        , FileMode.Open
        , FileAccess.Read
        , FileShare.ReadWrite)
        , mEncoding);

      mLogNumber      = 0;
      mLastFileOffset = mStartFromBeginning
        ? 0
        : mFileReader.BaseStream.Length;

      string pathOfFile = Path.GetDirectoryName(mFileToObserve);
      string nameOfFile = Path.GetFileName(mFileToObserve);

      if (!string.IsNullOrEmpty(pathOfFile) && !string.IsNullOrEmpty(nameOfFile))
      {
        mFileWatcher = new FileSystemWatcher(pathOfFile, nameOfFile)
        {
          NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.Size
        };

        mFileWatcher.Changed            += OnLogFileChanged;
        mFileWatcher.Error              += OnFileWatcherError;
        mFileWatcher.EnableRaisingEvents = IsActive;

        ReadNewLogMessagesFromFile();
      }
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
           + "\"Severity\","
           + "\"Local Machine Time\","
           + "\"Time\","
           + "\"Facility\","
           + "\"Sender\","
           + "\"Message\""
           + Environment.NewLine;
    }

    /// <summary>
    /// Determines whether the <see cref="ReceiverBase"/> instance can handle the given file name as log file.
    /// </summary>
    /// <returns><c>True</c> if the file can be handled, otherwise <c>false</c>.</returns>
    public override bool CanHandleLogFile()
    {
      if (string.IsNullOrEmpty(mFileToObserve) || !File.Exists(mFileToObserve))
      {
        return false;
      }

      using (StreamReader tmpReader = new StreamReader(mFileToObserve))
      {
        string firstLine = tmpReader.ReadLine();

        return Regex.IsMatch(
            firstLine ?? string.Empty
          , @"<([0-9]{1,3})>"
          , RegexOptions.IgnoreCase);
      }
    }

    /// <summary>
    /// Saves the current docking and collumn layout of the <see cref="ILogProvider"/> implementation.
    /// </summary>
    /// <param name="layout">The layout as string to save.</param>
    /// <param name="columnLayout">The current column layout to save.</param>
    public override void SaveLayout(string layout, List<LogColumnData> columnLayout)
    {
      Properties.Settings.Default.DockLayoutSyslogFileReceiver = layout ?? string.Empty;

      Properties.Settings.Default.ColumnVisibleSyslogFileReceiver = string.Format(
          "{0},{1},{2},{3},{4},{5},{6}"
        , columnLayout[0].Visible ? 1 : 0
        , columnLayout[1].Visible ? 1 : 0
        , columnLayout[2].Visible ? 1 : 0
        , columnLayout[3].Visible ? 1 : 0
        , columnLayout[4].Visible ? 1 : 0
        , columnLayout[5].Visible ? 1 : 0
        , columnLayout[6].Visible ? 1 : 0);

      Properties.Settings.Default.ColumnWidthSyslogFileReceiver = string.Format(
          "{0},{1},{2},{3},{4},{5},{6}"
        , columnLayout[0].Width
        , columnLayout[1].Width
        , columnLayout[2].Width
        , columnLayout[3].Width
        , columnLayout[4].Width
        , columnLayout[5].Width
        , columnLayout[6].Width);

      Properties.Settings.Default.SaveSettings();
    }

    /// <summary>
    /// Loads the docking layout of the <see cref="ReceiverBase"/> instance.
    /// </summary>
    /// <returns>The restored layout, or <c>null</c> if none exists.</returns>
    public override string LoadLayout()
    {
      return Properties.Settings.Default.DockLayoutSyslogFileReceiver;
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Creates a new and empty instance of the <see cref="SyslogFileReceiver"/> class.
    /// </summary>
    public SyslogFileReceiver()
    {

    }

    /// <summary>
    /// Creates a new and configured instance of the <see cref="SyslogFileReceiver"/> class.
    /// </summary>
    /// <param name="fileToObserve">The file the new <see cref="SyslogFileReceiver"/> instance should observe.</param>
    /// <param name="startFromBeginning">Determines whether the new <see cref="SyslogFileReceiver"/> should read the given <paramref name="fileToObserve"/> from beginnin, or not.</param>
    /// <param name="timestampFormat">The format of the timestamp of a received message.</param>
    /// <param name="codePage">The codepage to use for encoding of the data to parse.</param>
    public SyslogFileReceiver(string fileToObserve, bool startFromBeginning, string timestampFormat, int codePage) : base (codePage)
    {
      mFileToObserve      = fileToObserve;
      mStartFromBeginning = startFromBeginning;
      mTimestampFormat    = timestampFormat;
    }

    #endregion
  }
}
