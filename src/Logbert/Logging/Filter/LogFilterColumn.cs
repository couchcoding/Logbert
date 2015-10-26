#region Copyright © 2015 Couchcoding

// File:    LogFilterColumn.cs
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

using System.Text.RegularExpressions;

namespace Com.Couchcoding.Logbert.Logging.Filter
{
  /// <summary>
  /// Implements a <see cref="LogLevel"/> to filter <see cref="LogMessage"/>s with a defined value. 
  /// </summary>
  public sealed class LogFilterColumn : LogFilter
  {
    #region Private Fields

    /// <summary>
    /// Holds the index of the column to match.
    /// </summary>
    private readonly int mColumnIndex;

    /// <summary>
    /// Holds the value the column should have to match.
    /// </summary>
    private readonly Regex mColumnMatchValueRegEx;

    #endregion

    #region Public Methods

    /// <summary>
    /// Determines whether the given <paramref name="value"/> matches the filter, or not.
    /// </summary>
    /// <param name="value">The <see cref="LogMessage"/> that may be match the filter.</param>
    /// <returns><c>True</c> if the given <paramref name="value"/> matches the filter, otherwise <c>false</c>.</returns>
    public override bool Match(LogMessage value)
    {
      object columnValue = value.GetValueForColumn(mColumnIndex);

      return columnValue != null && 
        mColumnMatchValueRegEx.IsMatch(columnValue.ToString());
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Creates a new instance of a <see cref="LogFilterLevel"/>.
    /// </summary>
    /// <param name="columnIndex">The index of the column to match.</param>
    /// <param name="matchRegex">The string for the column match <see cref="Regex"/>.</param>
    public LogFilterColumn(int columnIndex, string matchRegex)
    {
      mColumnIndex           = columnIndex;
      mColumnMatchValueRegEx = new Regex(matchRegex ?? ".*");
    }

    #endregion
  }
}
