#region Copyright © 2015 Couchcoding

// File:    LogLevel.cs
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

namespace Couchcoding.Logbert.Logging
{
  /// <summary>
  /// All supported <see cref="LogLevel"/>s of a <see cref="LogMessage"/>.
  /// </summary>
  [Flags]
  public enum LogLevel
  {
    /// <summary>
    /// No log level to display.
    /// </summary>
    None = 0,

    /// <summary>
    /// Most detailed information.
    /// </summary>
    Trace = 1,

    /// <summary>
    /// Detailed information on the flow through the system.
    /// </summary>
    Debug = 2,

    /// <summary>
    /// Interesting runtime events (startup/shutdown). Expect these to be immediately visible on a console, so be conservative and keep to a minimum.
    /// </summary>
    Info = 4,

    /// <summary>
    /// Use of deprecated APIs, poor use of API, 'almost' errors, other runtime situations that are undesirable or unexpected, but not necessarily "wrong".
    /// </summary>
    Warning = 8,

    /// <summary>
    /// Other runtime errors or unexpected conditions.
    /// </summary>
    Error = 16,

    /// <summary>
    /// Severe errors that cause premature termination.
    /// </summary>
    Fatal = 32,

    /// <summary>
    /// All log levels may be displayed.
    /// </summary>
    All = Trace | Debug | Info | Warning | Error | Fatal
  }
}
