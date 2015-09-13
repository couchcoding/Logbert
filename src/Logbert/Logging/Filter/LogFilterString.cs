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

namespace Com.Couchcoding.Logbert.Logging.Filter
{
  /// <summary>
  /// Implements a simple string comparing <see cref="LogFilter"/> for <see cref="LogMessage"/>s.
  /// </summary>
  public class LogFilterString : LogFilter
  {
    #region Public Properties

    /// <summary>
    /// Gets the value to filter for.
    /// </summary>
    public string Value
    {
      get;
      private set;
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Determines whether the given <paramref name="value"/> matches the filter, or not.
    /// </summary>
    /// <param name="value">The value that may be match the filter.</param>
    /// <returns><c>True</c> if the given <paramref name="value"/> matches the filter, otherwise <c>false</c>.</returns>
    public override bool Match(object value)
    {
      return Equals(Value, value);
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Creates a new instance of a <see cref="LogFilterString"/>.
    /// </summary>
    /// <param name="columnIndex">The column index to apply the filter to.</param>
    /// <param name="value">The string value to filter for.</param>
    public LogFilterString(int columnIndex, string value) : base(columnIndex)
    {
      Value = value;
    }

    #endregion
  }
}
