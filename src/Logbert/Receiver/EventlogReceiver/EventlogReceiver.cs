#region Copyright © 2015 Couchcoding

// File:    EventlogReceiver.cs
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

using Couchcoding.Logbert.Interfaces;
using Couchcoding.Logbert.Logging;
using System.Diagnostics;

using Couchcoding.Logbert.Controls;
using Couchcoding.Logbert.Helper;

namespace Couchcoding.Logbert.Receiver.EventlogReceiver
{
  /// <summary>
  /// Implements a <see cref="ILogProvider"/> for the event log service.
  /// </summary>
  public class EventlogReceiver : ReceiverBase
  {
    #region Private Consts

    /// <summary>
    /// Defines the default name for the machine to receive messages from.
    /// </summary>
    private const string DEFAULT_MACHINE_NAME = ".";

    #endregion

    #region Private Fields

    /// <summary>
    /// Holds the <see cref="EventLog"/> instance that receives the messages.
    /// </summary>
    private EventLog mEventLog;

    /// <summary>
    /// Counts the received messages;
    /// </summary>
    private int mLogNumber;

    /// <summary>
    /// Holds the name of the log on the specified computer.
    /// </summary>
    private readonly string mLogName;

    /// <summary>
    /// Holds the computer on which the log exists.
    /// </summary>
    private readonly string mMachineName;

    /// <summary>
    /// Holds the source of event log entries.
    /// </summary>
    private readonly string mSourceName;

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets the name of the <see cref="ILogProvider"/>.
    /// </summary>
    public override string Name
    {
      get
      {
        return "Eventlog Receiver";
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
            "{0} ({1} - {2})"
          , Name
          , mLogName
          , string.IsNullOrEmpty(mSourceName) ? "*" : mSourceName);
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
    /// Gets the settings <see cref="Control"/> of the <see cref="ILogProvider"/>.
    /// </summary>
    public override ILogSettingsCtrl Settings
    {
      get
      {
        return new EventlogReceiverSettings();
      }
    }

    /// <summary>
    /// Gets the columns to display of the <see cref="ILogProvider"/>.
    /// </summary>
    public override Dictionary<int, LogColumnData> Columns
    {
      get
      {
        string[] visibleVal = Properties.Settings.Default.ColumnVisibleEventlogReceiver.Split(',');
        string[] widthVal   = Properties.Settings.Default.ColumnWidthEventlogReceiver.Split(',');

        return new Dictionary<int, LogColumnData>
        {
          { 0, new LogColumnData("Number",      visibleVal[0] == "1", int.Parse(widthVal[0])) },
          { 1, new LogColumnData("Level",       visibleVal[1] == "1", int.Parse(widthVal[1])) },
          { 2, new LogColumnData("Timestamp",   visibleVal[2] == "1", int.Parse(widthVal[2])) },
          { 3, new LogColumnData("Logger",      visibleVal[3] == "1", int.Parse(widthVal[3])) },
          { 4, new LogColumnData("Category",    visibleVal[4] == "1", int.Parse(widthVal[4])) },
          { 5, new LogColumnData("Username",    visibleVal[5] == "1", int.Parse(widthVal[5])) },
          { 6, new LogColumnData("Instance ID", visibleVal[6] == "1", int.Parse(widthVal[6])) },
          { 7, new LogColumnData("Message",     visibleVal[7] == "1", int.Parse(widthVal[7])) }
        };
      }
    }

    /// <summary>
    /// Determines whether this <see cref="ILogProvider"/> supports reloading of the content, ot not.
    /// </summary>
    public override bool SupportsReload
    {
      get
      {
        return false;
      }
    }

    /// <summary>
    /// Get the <see cref="Control"/> to display details about a selected <see cref="LogMessage"/>.
    /// </summary>
    public override ILogPresenter DetailsControl
    {
      get
      {
        return new EventLogDetailsControl();
      }
    }

    /// <summary>
    /// Gets the supported <see cref="LogLevel"/>s of the <see cref="ILogProvider"/>.
    /// </summary>
    public override LogLevel SupportedLevels
    {
      get
      {
        return LogLevel.Info    | 
               LogLevel.Warning | 
               LogLevel.Error;
      }
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Handles the Entry Written event of the <see cref="EventLog"/> instance.
    /// </summary>
    private void EventLogEntryWritten(object sender, EntryWrittenEventArgs e)
    {
      if (mIsActive && (string.IsNullOrEmpty(mSourceName) || Equals(e.Entry.Source, mSourceName)))
      {
        LogMessage newLogMsg = new LogMessageEventlog(
            e.Entry
          , ++mLogNumber);

        if (mLogHandler != null)
        {
          mLogHandler.HandleMessage(newLogMsg);
        }
      }
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

      mEventLog = new EventLog(
          mLogName
        , string.IsNullOrEmpty(mMachineName.Trim()) ? DEFAULT_MACHINE_NAME : mMachineName
        , mSourceName);

      mEventLog.EntryWritten       += EventLogEntryWritten;
      mEventLog.EnableRaisingEvents = true;
    }

    /// <summary>
    /// Shuts down the <see cref="ILogProvider"/> instance.
    /// </summary>
    public override void Shutdown()
    {
      if (mEventLog != null)
      {
        mEventLog.EnableRaisingEvents = false;
        mEventLog.EntryWritten       -= EventLogEntryWritten;

        mEventLog.Dispose();
      }

      base.Shutdown();
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
           + "\"Category\","
           + "\"User Name\","
           + "\"Thread\","
           + "\"Message\""
           + Environment.NewLine;
    }

    /// <summary>
    /// Resets the <see cref="ILogProvider"/> instance.
    /// </summary>
    public override void Clear()
    {
      mLogNumber = 0;
    }

    /// <summary>
    /// Saves the current docking and collumn layout of the <see cref="ILogProvider"/> implementation.
    /// </summary>
    /// <param name="layout">The layout as string to save.</param>
    /// <param name="columnLayout">The current column layout to save.</param>
    public override void SaveLayout(string layout, List<LogColumnData> columnLayout)
    {
      Properties.Settings.Default.DockLayoutEventlogReceiver = layout ?? string.Empty;

      Properties.Settings.Default.ColumnVisibleEventlogReceiver = string.Format(
          "{0},{1},{2},{3},{4},{5},{6},{7}"
        , columnLayout[0].Visible ? 1 : 0
        , columnLayout[1].Visible ? 1 : 0
        , columnLayout[2].Visible ? 1 : 0
        , columnLayout[3].Visible ? 1 : 0
        , columnLayout[4].Visible ? 1 : 0
        , columnLayout[5].Visible ? 1 : 0
        , columnLayout[6].Visible ? 1 : 0
        , columnLayout[7].Visible ? 1 : 0);

      Properties.Settings.Default.ColumnWidthEventlogReceiver = string.Format(
          "{0},{1},{2},{3},{4},{5},{6},{7}"
        , columnLayout[0].Width
        , columnLayout[1].Width
        , columnLayout[2].Width
        , columnLayout[3].Width
        , columnLayout[4].Width
        , columnLayout[5].Width
        , columnLayout[6].Width
        , columnLayout[7].Width);

      Properties.Settings.Default.SaveSettings();
    }

    /// <summary>
    /// Loads the docking layout of the <see cref="ReceiverBase"/> instance.
    /// </summary>
    /// <returns>The restored layout, or <c>null</c> if none exists.</returns>
    public override string LoadLayout()
    {
      return Properties.Settings.Default.DockLayoutEventlogReceiver;
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Creates a new and empty instance of the <see cref="EventlogReceiver"/> class.
    /// </summary>
    public EventlogReceiver()
    {

    }

    /// <summary>
    /// Creates a new and configured instance of the <see cref="Log4NetUdpReceiver"/> class.
    /// </summary>
    /// <param name="logName">The name of the log on the specified computer.</param>
    /// <param name="machineName">The computer on which the log exists.</param>
    /// <param name="sourceName">The source of event log entries.</param>
    public EventlogReceiver(string logName, string machineName, string sourceName)
    {
      mLogName     = logName;
      mMachineName = machineName;
      mSourceName  = sourceName;
    }

    #endregion
  }
}
