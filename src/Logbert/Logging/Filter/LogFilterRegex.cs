#region Copyright © 2014 Couchcoding

// File:    Log4NetUdpReceiver.cs
// Package: Logbert
// Project: Logbert
// 
// Copyright (c) 2014, Couchcoding. All rights reserved.
// 
// This library is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 3.0 of the License, or (at your option) any later version.
// 
// This library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public
// License along with this library.

#endregion

using System.Text.RegularExpressions;

namespace Com.Couchcoding.Logbert.Logging.Filter
{
  /// <summary>
  /// Implements a simple regular expression bases <see cref="LogFilter"/> for <see cref="LogMessage"/>s.
  /// </summary>
  public class LogFilterRegex : LogFilterString
  {
    #region Private Fields

    /// <summary>
    /// Holds the regular expression of the filter.
    /// </summary>
    private readonly Regex mFilterRegex;

    #endregion

    #region Public Methods

    /// <summary>
    /// Determines whether the given <paramref name="value"/> matches the filter, or not.
    /// </summary>
    /// <param name="value">The value that may be match the filter.</param>
    /// <returns><c>True</c> if the given <paramref name="value"/> matches the filter, otherwise <c>false</c>.</returns>
    public override bool Match(object value)
    {
      return mFilterRegex != null && 
             mFilterRegex.IsMatch(value.ToString());
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Creates a new instance of a <see cref="LogFilterRegex"/>.
    /// </summary>
    /// <param name="columnIndex">The column index to apply the filter to.</param>
    /// <param name="value">The regular expression to filter for.</param>
    public LogFilterRegex(int columnIndex, string value) : base(columnIndex, value)
    {
      mFilterRegex = new Regex(value ?? string.Empty);
    }

    #endregion
  }
}
