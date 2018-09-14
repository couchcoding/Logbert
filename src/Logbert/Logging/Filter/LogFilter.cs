#region Copyright © 2015 Couchcoding

// File:    LogFilter.cs
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
  /// Implements base vlass to filter for <see cref="LogMessage"/>s.
  /// </summary>
  public abstract class LogFilter
  {
    #region Public Properties

    /// <summary>
    /// Gets or sets whether the <see cref=LogFilter"/> is active, or not.
    /// </summary>
    public abstract bool IsActive
    {
      get;
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Determines whether the given <paramref name="value"/> matches the filter, or not.
    /// </summary>
    /// <param name="value">The <see cref="LogMessage"/> that may be match the filter.</param>
    /// <returns><c>True</c> if the given <paramref name="value"/> matches the filter, otherwise <c>false</c>.</returns>
    public abstract bool Match(LogMessage value);

    #endregion
  }
}
