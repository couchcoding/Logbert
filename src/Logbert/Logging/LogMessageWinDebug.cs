#region Copyright © 2017 Couchcoding

// File:    LogMessageWinDebug.cs
// Package: Logbert
// Project: Logbert
// 
// The MIT License (MIT)
// 
// Copyright (c) 2017 Couchcoding
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

using Couchcoding.Logbert.Helper;
using Couchcoding.Logbert.Properties;
using MoonSharp.Interpreter;
using System;
using System.Globalization;

namespace Couchcoding.Logbert.Logging
{
  /// <summary>
  /// Implements a <see cref="LogMessage"/> class for windows debug messages.
  /// </summary>
  public sealed class LogMessageWinDebug : LogMessage
  {
    #region Private Fields

    /// <summary>
    /// Holds the <see cref="DateTime"/> the <see cref="LogMessage"/> is received. 
    /// </summary>
    private DateTime mTimestamp;

    /// <summary>
    /// Holds the process ID of the <see cref="LogMessage"/>.
    /// </summary>
    private int mProcessId;

    /// <summary>
    /// Holds the message of the <see cref="LogMessage"/>.
    /// </summary>
    private string mMessage;

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
    /// Gets the process ID of the <see cref="LogMessage"/>.
    /// </summary>
    public int ProcessId
    {
      get
      {
        return mProcessId;
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
        return LogLevel.Debug;
      }
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Parses the given <paramref name="data"/> for possible log message parts.
    /// </summary>
    /// <param name="data">The data string to parse.</param>
    /// <returns><c>True</c> on success, otherwise <c>false</c>.</returns>
    private bool ParseData(int id, string data)
    {
      if (string.IsNullOrEmpty(data))
      {
        // No valid debug message.
        return false;
      }

      mProcessId = id;
      mMessage   = data;
      mTimestamp = DateTime.Now;

      return true;
    }

    #endregion

    #region Public Methods

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
          return mProcessId.ToString();
        case 5:
          return mMessage;
      }

      return null;
    }

    /// <summary>
    /// Exports the <see cref="LogMessage"/> with its data into a comma seperated line.
    /// </summary>
    /// <returns>The <see cref="LogMessage"/> with its data as a comma seperated line.</returns>
    public override string GetCsvLine()
    {
      string messageValue = string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\""
        , mIndex.ToCsv()
        , Level.ToString()
        , mTimestamp.ToString(Settings.Default.TimestampFormat)
        , mProcessId.ToString().ToCsv()
        , mMessage.ToCsv());

      if (messageValue.Length > 0)
      {
        // Remove the last comma from the custom properties string.
        messageValue = messageValue.Remove(
            messageValue.Length - 1
          , 1);
      }

      return messageValue + "\"";
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

      msgData["ProcessID"] = mProcessId.ToString();
      
      return msgData;
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Creates a new instance of the <see cref="LogMessageSyslog"/> object.
    /// </summary>
    /// <param name="rawData">The data <see cref="Array"/> the new <see cref="LogMessageSyslog"/> represents.</param>
    /// <param name="index">The index of the <see cref="LogMessage"/>.</param>
    public LogMessageWinDebug(int processId, string rawData, int index) : base(rawData, index)
    {
      if (!ParseData(processId, rawData))
      {
        throw new ApplicationException("Unable to parse the logger data.");
      }
    }

    #endregion
  }
}
