#region Copyright © 2015 Couchcoding

// File:    LogMessageSelectedEventArgs.cs
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

using Couchcoding.Logbert.Logging;
using System;

namespace Couchcoding.Logbert.Helper
{
  /// <summary>
  /// Implements a custom <see cref="EventHandler"/> for <see cref="LogMessage"/> selection.
  /// </summary>
  public sealed class LogMessageSelectedEventArgs : EventArgs
  {
    #region Public Properties

    /// <summary>
    /// GEts the selected <see cref="LogMessage"/>.
    /// </summary>
    public LogMessage Message
    {
      get;
      private set;
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Creates a new instance of the <see cref="LogMessageSelectedEventArgs"/> class.
    /// </summary>
    /// <param name="message">The selected <see cref="LogMessage"/>.</param>
    public LogMessageSelectedEventArgs(LogMessage message)
    {
      Message = message;
    }

    #endregion
  }
}
