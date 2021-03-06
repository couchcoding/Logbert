﻿#region Copyright © 2015 Couchcoding

// File:    ILogHandler.cs
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

using Couchcoding.Logbert.Logging;

namespace Couchcoding.Logbert.Interfaces
{
  /// <summary>
  /// Interface for all <see cref="LogMessage"/> handler.
  /// </summary>
  public interface ILogHandler
  {
    #region Interface Methods

    /// <summary>
    /// Handles the given <paramref name="logMsgs"/> <see cref="LogMessage"/>s.
    /// </summary>
    /// <param name="logMsgs">The <see cref="Array"/> of <see cref="LogMessage"/>s to handle.</param>
    void HandleMessage(LogMessage[] logMsgs);

    /// <summary>
    /// Handles the given <paramref name="logMsg"/> <see cref="LogMessage"/>.
    /// </summary>
    /// <param name="logMsg">The <see cref="LogMessage"/> to handle.</param>
    void HandleMessage(LogMessage logMsg);

    /// <summary>
    /// Handle the specified <paramref name="error"/> message.
    /// </summary>
    /// <param name="error">The error message to handle.</param>
    void HandleError(LogError error);

    #endregion
  }
}
