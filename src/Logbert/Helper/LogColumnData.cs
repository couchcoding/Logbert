#region Copyright © 2018 Couchcoding

// File:    LogColumnData.cs
// Package: Logbert
// Project: Logbert
// 
// The MIT License (MIT)
// 
// Copyright (c) 2018 Couchcoding
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

namespace Couchcoding.Logbert.Helper
{
  /// <summary>
  /// Implements a class to store log column specific data.
  /// </summary>
  public sealed class LogColumnData
  {
    #region Public Properties

    /// <summary>
    /// Gets the name of the log column.
    /// </summary>
    public string Name
    {
      get;
    }

    /// <summary>
    /// Gets the visibility state of the log column.
    /// </summary>
    public bool Visible
    {
      get;
    }

    /// <summary>
    /// Gets the width of the log column.
    /// </summary>
    public int Width
    {
      get;
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Initializes a new instance of the <see cref="LogColumnData"/> with the specified parameters.
    /// </summary>
    /// <param name="name">The name of the log column.</param>
    /// <param name="visible">The visibility state of the log column.</param>
    /// <param name="width">The width of the log column.</param>
    public LogColumnData(string name, bool visible = true, int width = 100)
    {
      Name = name ?? string.Empty;
      Visible = visible;
      Width = width;
    }

    #endregion
  }
}
