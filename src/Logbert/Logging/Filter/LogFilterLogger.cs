#region Copyright © 2015 Couchcoding

// File:    LogFilterLogger.cs
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

namespace Couchcoding.Logbert.Logging.Filter
{
  /// <summary>
  /// Implements a simple <see cref="LogLevel"/> comparing <see cref="LogFilter"/>s logger value for <see cref="LogMessage"/>s.
  /// </summary>
  public sealed class LogFilterLogger : LogFilter
  {
    #region Private Fields

    /// <summary>
    /// Holds the path of the logger to filter.
    /// </summary>
    private readonly string mFilterPath;

    /// <summary>
    /// Holds the value if only the start, or the entire value should be compared.
    /// </summary>
    private readonly bool mRecursive;

    #endregion

    #region Public Properties

    /// <summary>
    /// Determines whether the <see cref=LogFilter"/> is active, or not.
    /// </summary>
    public override bool IsActive
    {
      get
      {
        return true;
      }
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Determines whether the given <paramref name="value"/> matches the filter, or not.
    /// </summary>
    /// <param name="value">The value that may be match the filter.</param>
    /// <returns><c>True</c> if the given <paramref name="value"/> matches the filter, otherwise <c>false</c>.</returns>
    public override bool Match(LogMessage value)
    {
      if (value == null)
      {
        return false;
      }

      return mRecursive 
        ? value.Logger.StartsWith(mFilterPath) 
        : Equals(value.Logger, mFilterPath);
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Creates a new instance of the <see cref="LogFilterLogger"/>.
    /// </summary>
    /// <param name="filterPath">The path of the logger to filter.</param>
    /// <param name="recursive">Determines whether the entire string, or only the start should be compared.</param>
    public LogFilterLogger(string filterPath, bool recursive)
    {
      mFilterPath = filterPath;
      mRecursive  = recursive;
    }

    #endregion
  }
}
