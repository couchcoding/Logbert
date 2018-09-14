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

namespace Couchcoding.Logbert.Logging.Filter
{
  /// <summary>
  /// Implements a <see cref="LogLevel"/> to filter <see cref="LogMessage"/>s with a defined value. 
  /// </summary>
  public sealed class LogFilterColumn : LogFilter
  {
    #region Private Fields

    /// <summary>
    /// Hold the active state of the <see cref="LogFilterColumn"/>.
    /// </summary>
    private bool mIsActive;

    /// <summary>
    /// Holds the index of the column to match.
    /// </summary>
    private int mColumnIndex;

    /// <summary>
    /// Holds the index of the select operator.
    /// </summary>
    private int mOperatorIndex;

    /// <summary>
    /// Holds the value the column should have to match.
    /// </summary>
    private Regex mColumnMatchValueRegEx;

    #endregion

    #region Public Properties

    /// <summary>
    /// Determines whether the <see cref=LogFilter"/> is active, or not.
    /// </summary>
    public override bool IsActive
    {
      get
      {
        return mIsActive;
      }
    }

    /// <summary>
    /// Gets the column index to filter in.
    /// </summary>
    public int ColumnIndex
    {
      get
      {
        return mColumnIndex;
      }
    }

    /// <summary>
    /// Gets the index of the choosed operator.
    /// </summary>
    public int OperatorIndex
    {
      get
      {
        return mOperatorIndex;
      }
    }

    /// <summary>
    /// Gets the value the column should have to match.
    /// </summary>
    public string ColumnMatchValueRegEx
    {
      get
      {
        return mColumnMatchValueRegEx.ToString();
      }
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Determines whether the given <paramref name="value"/> matches the filter, or not.
    /// </summary>
    /// <param name="value">The <see cref="LogMessage"/> that may be match the filter.</param>
    /// <returns><c>True</c> if the given <paramref name="value"/> matches the filter, otherwise <c>false</c>.</returns>
    public override bool Match(LogMessage value)
    {
      if (value == null)
      {
        return false;
      }

      object columnValue = value.GetValueForColumn(mColumnIndex);

      if (columnValue != null)
      {
        return OperatorIndex == 0
          ?  mColumnMatchValueRegEx.IsMatch(columnValue.ToString())
          : !mColumnMatchValueRegEx.IsMatch(columnValue.ToString());
      }

      return false;
    }

    /// <summary>
    /// Update the <see cref=LogFilterColumn"/> with the specified parameters.
    /// </summary>
    /// <param name="isActive">The new active state of the <see cref=LogFilterColumn"/>.</param>
    /// <param name="columnIndex">The new column index of the <see cref=LogFilterColumn"/>.</param>
    /// <param name="operatorIndex">The new operator index of thr <see cref="LogFilterColumn"/>.</param>
    /// <param name="expression">The new regular expression of the <see cref=LogFilterColumn"/>.</param>
    public void Update(bool isActive, int columnIndex, int operatorIndex, string expression)
    {
      mIsActive              = isActive;
      mColumnIndex           = columnIndex;
      mOperatorIndex         = operatorIndex;
      mColumnMatchValueRegEx = new Regex(expression);
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Creates a new instance of a <see cref="LogFilterLevel"/>.
    /// </summary>
    /// <param name="isActive">The active state of the <see cref=LogFilterColumn"/>.</param>
    /// <param name="columnIndex">The index of the column to match.</param>
    /// <param name="operatorIndex">The operator index of thr <see cref="LogFilterColumn"/>.</param>
    /// <param name="matchRegex">The string for the column match <see cref="Regex"/>.</param>
    public LogFilterColumn(bool isActive, int columnIndex, int operatorIndex, string matchRegex)
    {
      mIsActive              = isActive;
      mColumnIndex           = columnIndex;
      mOperatorIndex         = operatorIndex;
      mColumnMatchValueRegEx = new Regex(matchRegex ?? ".*");
    }

    #endregion
  }
}
