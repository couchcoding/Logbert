#region Copyright © 2015 Couchcoding

// File:    LogMessageEventlog.cs
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
using System.Diagnostics;
using System.Windows.Forms;

using Couchcoding.Logbert.Helper;
using Couchcoding.Logbert.Properties;
using MoonSharp.Interpreter;
using System.Globalization;

namespace Couchcoding.Logbert.Logging
{
  /// <summary>
  /// Implements a <see cref="LogMessage"/> class for Eventlog messages.
  /// </summary>
  public class LogMessageEventlog: LogMessage
  {
    #region Private Fields

    /// <summary>
    /// Holds the <see cref="DateTime"/> the <see cref="LogMessage"/> is received. 
    /// </summary>
    private DateTime mTimestamp;

    /// <summary>
    /// Holds the message of the <see cref="LogMessage"/>.
    /// </summary>
    private string mMessage;

    /// <summary>
    /// Holds the instance ID name of the <see cref="LogMessage"/>.
    /// </summary>
    private long mInstanceId;

    /// <summary>
    /// Holds the <see cref="EventLogEntryType"/> of the <see cref="LogMessage"/>. 
    /// </summary>
    private EventLogEntryType mLogEntryType;

    /// <summary>
    /// Holds the category of the <see cref="LogMessage"/>.
    /// </summary>
    private string mCategory;

    /// <summary>
    /// Holds the user name of the <see cref="LogMessage"/>.
    /// </summary>
    private string mUsername;

    /// <summary>
    /// Holds the binary data associated with the <see cref="LogMessage"/>.
    /// </summary>
    private byte[] mData;

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets the <see cref="DateTime"/> the <see cref="LogMessage"/> is received.
    /// </summary>
    public override DateTime Timestamp
    {
      get
      {
        return mTimestamp;
      }
    }

    /// <summary>
    /// Gets the message of the <see cref="LogMessage"/>.
    /// </summary>
    public override string Message
    {
      get
      {
        return mMessage;
      }
    }

    /// <summary>
    /// Gets the <see cref="LogLevel"/> of the <see cref="LogMessage"/>.
    /// </summary>
    public override LogLevel Level
    {
      get
      {
        return MapLevelType(mLogEntryType);
      }
    }
    
    /// <summary>
    /// Gets the thread ID of the <see cref="LogMessage"/>.
    /// </summary>
    public long InstanceId
    {
      get
      {
        return mInstanceId;
      }
    }

    /// <summary>
    /// Gets the category of the <see cref="LogMessage"/>.
    /// </summary>
    public string Category
    {
      get
      {
        return mCategory;
      }
    }

    /// <summary>
    /// Gets the user name of the <see cref="LogMessage"/>.
    /// </summary>
    public string Username
    {
      get
      {
        return mUsername;
      }
    }

    /// <summary>
    /// Gets the binary data associated with the <see cref="LogMessage"/>.
    /// </summary>
    public byte[] Data
    {
      get
      {
        return mData;
      }
    }
    
    #endregion

    #region Private Methods

    /// <summary>
    /// Parses the given <paramref name="data"/> for possible log message parts.
    /// </summary>
    /// <param name="data">The data string to parse.</param>
    /// <returns><c>True</c> on success, otherwise <c>false</c>.</returns>
    private bool ParseData(EventLogEntry data)
    {
      if (data != null)
      {
        mLogEntryType = data.EntryType;
        mTimestamp    = data.TimeGenerated;
        mInstanceId   = data.InstanceId & 0x3FFFFFFF;
        mCategory     = data.CategoryNumber == 0 ? Resources.strEventLogReceiverNoCategory : data.Category;
        mUsername     = data.UserName ?? Resources.strEventLogReceiverNoUsername;
        mData         = data.Data;
        mMessage      = data.Message;
        mLogger       = data.Source;

        return true;
      }

      return false;
    }

    /// <summary>
    /// Mappes the given <paramref name="entryType"/> to the internal <see cref="LogLevel"/>.
    /// </summary>
    /// <param name="entryType">The <see cref="EventLogEntryType"/> to map to the internal <see cref="Enum"/>.</param>
    /// <returns>The mapped <see cref="LogLevel"/>.</returns>
    private LogLevel MapLevelType(EventLogEntryType entryType)
    {
      switch (entryType)
      {
        case EventLogEntryType.Error:
        case EventLogEntryType.FailureAudit:
          return LogLevel.Error;
        case EventLogEntryType.Information:
        case EventLogEntryType.SuccessAudit:
          return LogLevel.Info;
        case EventLogEntryType.Warning:
          return LogLevel.Warning;
      }

      // The lowest one is the default one.
      return LogLevel.Info;
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString()
    {
      EventLogEntry data = mRawData as EventLogEntry;

      if (data != null)
      {
        string logEntry = string.Format("Event Type: {0}, Local Time: {1}, Identifier: {2}, Category Number: {3}, Username: {4}, Binary Data: {5}, Message: {6}, Source: {7}"
          , data.EntryType
          , data.TimeGenerated
          , data.InstanceId & 0x3FFFFFFF
          , data.CategoryNumber == 0 ? Resources.strEventLogReceiverNoCategory : data.Category
          , data.UserName ?? Resources.strEventLogReceiverNoUsername
          , BitConverter.ToString(data.Data)
          , data.Message
          , data.Source);
        
         return logEntry;
      }

      return string.Empty;
    }

    /// <summary>
    /// Exports the <see cref="LogMessage"/> with its data into a comma seperated line.
    /// </summary>
    /// <returns>The <see cref="LogMessage"/> with its data as a comma seperated line.</returns>
    public override string GetCsvLine()
    {
      return string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\"{8}"
        , Index.ToCsv()
        , Level.ToCsv()
        , Timestamp.ToString(Settings.Default.TimestampFormat)
        , Logger.ToCsv()
        , Category.ToCsv()
        , Username.ToCsv()
        , InstanceId.ToCsv()
        , Message.ToCsv()
        , Environment.NewLine);
    }

    /// <summary>
    /// Returns a <see cref="Table"/> that represents the current <see cref="LogMessage"/>.
    /// </summary>
    /// <param name="owner">The owner <see cref="Script"/> instance this <see cref="Table"/> is for.</param>
    /// <returns>A new <see cref="Table"/> object that represents the current <see cref="LogMessage"/>, or <c>null</c> on error.</returns>
    public override Table ToLuaTable(Script owner)
    {
      Table msgData = base.ToLuaTable(owner);

      if (msgData == null)
      {
        return null;
      }

      msgData["InstanceId"] = InstanceId;
      msgData["Category"]   = Category;
      msgData["Username"]   = Username;
      msgData["Data"]       = Data;

      return msgData;
    }

    /// <summary>
    /// Gets the value to display within a <see cref="DataGridView"/> at the fiven <paramref name="columnIndex"/>.
    /// </summary>
    /// <param name="columnIndex">The index of the column at the <see cref="DataGridView"/>.</param>
    /// <returns>The value to display at the given <paramref name="columnIndex"/>, or <c>null</c> if nothing to display.</returns>
    public override object GetValueForColumn(int columnIndex)
    {
      switch (columnIndex)
      {
        case 1:
          return mIndex;
        case 2:
          return Level.ToString();
        case 3:
          return mTimestamp.Add(mTimeShiftOffset).ToString(
              Settings.Default.TimestampFormat
            , CultureInfo.InvariantCulture);
        case 4:
          return mLogger;
        case 5:
          return mCategory;
        case 6:
          return mUsername;
        case 7:
          return mInstanceId;
        case 8:
          return mMessage;
      }

      return null;
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Creates a new instance of the <see cref="LogMessageEventlog"/> object.
    /// </summary>
    /// <param name="rawData">The data <see cref="Array"/> the new <see cref="LogMessageEventlog"/> represents.</param>
    /// <param name="index">The index of the <see cref="LogMessage"/>.</param>
    public LogMessageEventlog(EventLogEntry rawData, int index) : base(rawData, index)
    {
      if (!ParseData(rawData))
      {
        throw new ApplicationException("Unable to parse the logger data.");
      }
    }

    #endregion
  }
}
