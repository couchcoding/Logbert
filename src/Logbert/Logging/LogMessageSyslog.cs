#region Copyright © 2015 Couchcoding

// File:    LogMessageSyslog.cs
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
using System.Text.RegularExpressions;

using System.Globalization;

using Couchcoding.Logbert.Helper;
using Couchcoding.Logbert.Properties;

using MoonSharp.Interpreter;

namespace Couchcoding.Logbert.Logging
{
  /// <summary>
  /// Implements a <see cref="LogMessage"/> class for Syslog messages.
  /// </summary>
  public sealed class LogMessageSyslog : LogMessage
  {
    #region Private Fields

    /// <summary>
    /// Holds the <see cref="DateTime"/> the <see cref="LogMessage"/> is received. 
    /// </summary>
    private DateTime mTimestamp;

    /// <summary>
    /// Holds the local <see cref="DateTime"/> the <see cref="LogMessage"/> is received. 
    /// </summary>
    private DateTime mLocalTimestamp;

    /// <summary>
    /// Holds the message of the <see cref="LogMessage"/>.
    /// </summary>
    private string mMessage;

    /// <summary>
    /// Holds the <see cref="Severity"/> of the <see cref="LogMessageSyslog"/>.
    /// </summary>
    private Severity mSeverity;

    /// <summary>
    /// Holds the <see cref="Facility"/> of the <see cref="LogMessageSyslog"/>.
    /// </summary>
    private Facility mFacility;

    /// <summary>
    /// The <see cref="Regex"/> to parse a syslog <see cref="LogMessage"/>.
    /// </summary>
    private static readonly Regex mSyslogLineRegex = new Regex(@"<([0-9]{1,3})>([\s]?[\d]+\s)?(.*)", RegexOptions.IgnoreCase);

    #endregion

    #region Private Enums

    /// <summary>
    /// All supported severities of the <see cref="SyslogUdpReceiver"/>.
    /// </summary>
    private enum Severity
    {
      Emergency,
      Alert,
      Critical,
      Error,
      Warning,
      Notice,
      Informational,
      Debug,
    }

    /// <summary>
    /// All supported facilities of the <see cref="SyslogUdpReceiver"/>.
    /// </summary>
    public enum Facility
    {
      Kernel,
      UserLevel,
      MailSystem,
      SystemDaemons,
      Security,
      Internal,
      LinePrinter,
      NetworkNews,
      UUCP,
      ClockDaemeon,
      Security2,
      FTPDaemon,
      NTP,
      LogAudit,
      LogAlert,
      Clock,
      Local0,
      Local1,
      Local2,
      Local3,
      Local4,
      Local5,
      Local6,
      Local7,
    }

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
    /// Gets the local <see cref="DateTime"/> the <see cref="LogMessage"/> is received.
    /// </summary>
    public DateTime LocalTimestamp
    {
      get
      {
        return mLocalTimestamp;
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
        return MapLevelType(mSeverity);
      }
    }

    /// <summary>
    /// Gets the <see cref="Facility"/> of the <see cref="LogMessage"/>.
    /// </summary>
    public Facility LogFacility
    {
      get
      {
        return mFacility;
      }
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Mappes the given <paramref name="levelType"/> to the internal <see cref="LogLevel"/>.
    /// </summary>
    /// <param name="levelType">The <see cref="Severity"/> to map to the internal <see cref="Enum"/>.</param>
    /// <returns>The mapped <see cref="LogLevel"/>.</returns>
    private LogLevel MapLevelType(Severity levelType)
    {
      switch (levelType)
      {
        case Severity.Notice:
          return LogLevel.Trace;
        case Severity.Debug:
          return LogLevel.Debug;
        case Severity.Informational:
          return LogLevel.Info;
        case Severity.Warning:
          return LogLevel.Warning;
        case Severity.Error:
        case Severity.Alert:
          return LogLevel.Error;
        case Severity.Critical:
        case Severity.Emergency:
          return LogLevel.Fatal;
      }

      // The lowest one is the default one.
      return LogLevel.Trace;
    }

    /// <summary>
    /// Parses the given <paramref name="data"/> for possible log message parts.
    /// </summary>
    /// <param name="data">The data string to parse.</param>
    /// <param name="timestampFormat">The format of the timestamp within the message.</param>
    /// <returns><c>True</c> on success, otherwise <c>false</c>.</returns>
    private bool ParseData(string data, string timestampFormat)
    {
      if (string.IsNullOrEmpty(data))
      {
        // No data to parse.
        return false;
      }

      Match msgMtc = mSyslogLineRegex.Match(data);

      if (!msgMtc.Success)
      {
        // No valid syslog message.
        return false;
      }

      uint priMatrix = uint.Parse(msgMtc.Groups[1].Value);

      mSeverity = (Severity)((int)priMatrix & 0x07);
      mFacility = (Facility)((int)priMatrix >> 3);
      mLocalTimestamp = DateTime.Now;

      string syslogMessage = msgMtc.Groups[3].Value.TrimStart();
      int hostIndex = 0;
      bool dtParseResult = false;

      foreach (string possibleTimeStamp in timestampFormat.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
      {
        if (syslogMessage.Length <= possibleTimeStamp.Length || string.IsNullOrEmpty(timestampFormat))
        {
          continue;
        }

        string strTimeStamp = syslogMessage.Substring(hostIndex, possibleTimeStamp.Replace("\'", string.Empty).Length);

        dtParseResult = DateTime.TryParseExact(strTimeStamp
          , possibleTimeStamp
          , CultureInfo.InvariantCulture
          , DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal
          , out mTimestamp);

        if (dtParseResult)
        {
          hostIndex += strTimeStamp.Length;
          break;
        }
      }

      if (!dtParseResult)
      {
        mTimestamp = DateTime.Now;
      }

      syslogMessage = syslogMessage.Substring(hostIndex);
      mLogger = syslogMessage.TrimStart().Split(' ')[0];
      mMessage = syslogMessage.Substring(mLogger.Length + 1);

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
          return mSeverity.ToString();
        case 3:
          return mLocalTimestamp.ToString(Settings.Default.TimestampFormat);
        case 4:
          return mTimestamp.Add(mTimeShiftOffset).ToString(
              Settings.Default.TimestampFormat
            , CultureInfo.InvariantCulture);
        case 5:
          return mFacility.ToString();
        case 6:
          return mLogger;
        case 7:
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
      string messageValue = string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\""
        , mIndex.ToCsv()
        , mSeverity.ToString().ToCsv()
        , mLocalTimestamp.ToString(Settings.Default.TimestampFormat)
        , mTimestamp.ToString(Settings.Default.TimestampFormat)
        , mFacility.ToString().ToCsv()
        , mLogger.ToCsv()
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

      msgData["Facility"] = LogFacility.ToString();

      Table localTimeTable = new Table(owner);

      localTimeTable["Day"] = Timestamp.Day;
      localTimeTable["Month"] = Timestamp.Month;
      localTimeTable["Year"] = Timestamp.Year;
      localTimeTable["Hour"] = Timestamp.Hour;
      localTimeTable["Minute"] = Timestamp.Minute;
      localTimeTable["Second"] = Timestamp.Second;
      localTimeTable["Millisecond"] = Timestamp.Millisecond;
      localTimeTable["Timestamp"] = Timestamp.ToUnixTimestamp();

      msgData["LocalTimestamp"] = localTimeTable;

      return msgData;
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Creates a new instance of the <see cref="LogMessageSyslog"/> object.
    /// </summary>
    /// <param name="rawData">The data <see cref="Array"/> the new <see cref="LogMessageSyslog"/> represents.</param>
    /// <param name="index">The index of the <see cref="LogMessage"/>.</param>
    /// <param name="timestampFormat">The format of the timestamp within the message.</param>
    public LogMessageSyslog(string rawData, int index, string timestampFormat) : base(rawData, index)
    {
      if (!ParseData(rawData, timestampFormat))
      {
        throw new ApplicationException("Unable to parse the logger data.");
      }
    }

    #endregion
  }
}
