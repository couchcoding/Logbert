#region Copyright © 2016 Couchcoding

// File:    FrmColumnizerTest.cs
// Package: Logbert
// Project: Logbert
// 
// The MIT License (MIT)
// 
// Copyright (c) 2016 Couchcoding
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
using Com.Couchcoding.Logbert.Receiver.CustomReceiver;

namespace Com.Couchcoding.Logbert.Logging
{
  /// <summary>
  /// Implements a <see cref="LogMessage"/> class for custom logger messages.
  /// </summary>
  public sealed class LogMessageCustom : LogMessage
  {
    #region Private Fields

    private readonly Columnizer mColumnizer;

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets the <see cref="DateTime"/> the <see cref="LogMessage"/> is received.
    /// </summary>
    public override DateTime Timestamp
    {
      get
      {
        throw new NotImplementedException();
      }
    }

    /// <summary>
    /// Gets the message of the <see cref="LogMessage"/>.
    /// </summary>
    public override string Message
    {
      get
      {
        throw new NotImplementedException();
      }
    }

    /// <summary>
    /// Gets the <see cref="LogLevel"/> of the <see cref="LogMessage"/>.
    /// </summary>
    public override LogLevel Level
    {
      get
      {
        throw new NotImplementedException();
      }
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Parses the given <paramref name="data"/> for possible log message parts.
    /// </summary>
    /// <param name="data">The data string to parse.</param>
    /// <returns><c>True</c> on success, otherwise <c>false</c>.</returns>
    private bool ParseData(string data)
    {
      if (string.IsNullOrEmpty(data))
      {
        // No data to parse.
        return false;
      }

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
      throw new NotImplementedException();
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Creates a new instance of the <see cref="LogMessageCustom"/> object.
    /// </summary>
    /// <param name="rawData">The data <see cref="Array"/> the new <see cref="LogMessageCustom"/> represents.</param>
    /// <param name="index">The index of the <see cref="LogMessage"/>.</param>
    /// <param name="columns">The <see cref="Columnizer"/> to use for parsing.</param>
    public LogMessageCustom(string rawData, int index, Columnizer columns) : base(rawData, index)
    {
      if (!ParseData(rawData))
      {
        throw new ApplicationException("Unable to parse the logger data.");
      }
    }

    #endregion
  }
}
