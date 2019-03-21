#region Copyright © 2015 Couchcoding

// File:    LogMessage.cs
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
using System.Windows.Forms;

using Couchcoding.Logbert.Helper;
using Couchcoding.Logbert.Properties;

using MoonSharp.Interpreter;

namespace Couchcoding.Logbert.Logging
{
  /// <summary>
  /// Implements the base class for <see cref="LogMessage"/>s.
  /// </summary>
  public abstract class LogMessage
  {
    #region Private Fields

    /// <summary>
    /// The UTC start value to calculate the <see cref="LogMessage"/> local timestamp.
    /// </summary>
    protected static readonly DateTime mUtcStartDate = new DateTime(1970, 1, 1);

    /// <summary>
    /// The raw logging data.
    /// </summary>
    protected readonly object mRawData;

    /// <summary>
    /// The index of the <see cref="LogMessage"/>.
    /// </summary>
    protected readonly int mIndex;

    /// <summary>
    /// Holds the logger name of the <see cref="LogMessage"/>.
    /// </summary>
    protected string mLogger;

    /// <summary>
    /// The timeshift offset for the <see cref="LogMessage"/>.
    /// </summary>
    protected TimeSpan mTimeShiftOffset;

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets the index of the <see cref="LogMessage"/>.
    /// </summary>
    public int Index
    {
      get
      {
        return mIndex;
      }
    }

    /// <summary>
    /// Gets the <see cref="DateTime"/> the <see cref="LogMessage"/> is received.
    /// </summary>
    public abstract DateTime Timestamp
    {
      get;
    }

    /// <summary>
    /// Gets the message of the <see cref="LogMessage"/>.
    /// </summary>
    public abstract string Message
    {
      get;
    }

    /// <summary>
    /// Gets the raw data of the <see cref="LogMessage"/>.
    /// </summary>
    public object RawData
    {
      get
      {
        return mRawData;
      }
    }

    /// <summary>
    /// Gets the <see cref="LogLevel"/> of the <see cref="LogMessage"/>.
    /// </summary>
    public abstract LogLevel Level
    {
      get;
    }

    /// <summary>
    /// Get the logger name of the <see cref="LogMessage"/>.
    /// </summary>
    public string Logger
    {
      get
      {
        return mLogger;
      }
    }

    /// <summary>
    /// Get or sets the timeshift offset for the <see cref="LogMessage"/>.
    /// </summary>
    public TimeSpan TimeShiftOffset
    {
      get
      {
        return mTimeShiftOffset;
      }
      set
      {
        mTimeShiftOffset = value;
      }
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Gets the value to display within a <see cref="DataGridView"/> at the fiven <paramref name="columnIndex"/>.
    /// </summary>
    /// <param name="columnIndex">The index of the column at the <see cref="DataGridView"/>.</param>
    /// <returns>The value to display at the given <paramref name="columnIndex"/>, or <c>null</c> if nothing to display.</returns>
    public abstract object GetValueForColumn(int columnIndex);

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString()
    {
      return mRawData.ToString();
    }

    /// <summary>
    /// Returns a <see cref="Table"/> that represents the current <see cref="LogMessage"/>.
    /// </summary>
    /// <param name="owner">The owner <see cref="Script"/> instance this <see cref="Table"/> is for.</param>
    /// <returns>A new <see cref="Table"/> object that represents the current <see cref="LogMessage"/>, or <c>null</c> on error.</returns>
    public virtual Table ToLuaTable(Script owner)
    {
      if (owner == null)
      {
        return null;
      }

      Table msgData = new Table(owner);
              
      msgData["Index"]   = Index;
      msgData["Level"]   = Level;
      msgData["Logger"]  = Logger;
      msgData["Message"] = Message;
      msgData["RawData"] = RawData;

      msgData["TimeShift"] = new Table(owner)
      {
        ["Days"]         = TimeShiftOffset.Days,
        ["Hours"]        = TimeShiftOffset.Hours,
        ["Minutes"]      = TimeShiftOffset.Minutes,
        ["Seconds"]      = TimeShiftOffset.Seconds,
        ["Milliseconds"] = TimeShiftOffset.Milliseconds
      };

      msgData["Timestamp"] = new Table(owner)
      {
        ["Day"]         = Timestamp.Day,
        ["Month"]       = Timestamp.Month,
        ["Year"]        = Timestamp.Year,
        ["Hour"]        = Timestamp.Hour,
        ["Minute"]      = Timestamp.Minute,
        ["Second"]      = Timestamp.Second,
        ["Millisecond"] = Timestamp.Millisecond,
        ["Timestamp"]   = Timestamp.ToUnixTimestamp()
      };
              
     return msgData;
    }

    /// <summary>
    /// Exports the <see cref="LogMessage"/> with its data into a comma seperated line.
    /// </summary>
    /// <returns>The <see cref="LogMessage"/> with its data as a comma seperated line.</returns>
    public virtual string GetCsvLine()
    {
      return string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\"{5}"
        , Index.ToCsv()
        , Level.ToCsv()
        , Timestamp.ToString(Settings.Default.TimestampFormat)
        , Logger.ToCsv()
        , Message.ToCsv()
        , Environment.NewLine);
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Creates a new instance of the <see cref="LogMessage"/> object.
    /// </summary>
    /// <param name="rawData">The data <see cref="Array"/> the new <see cref="LogMessage"/> represents.</param>
    /// <param name="index">The index of the <see cref="LogMessage"/>.</param>
    protected LogMessage(object rawData, int index)
    {
      mIndex   = index;
      mRawData = rawData;
    }

    #endregion
  }
}
