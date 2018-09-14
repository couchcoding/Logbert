#region Copyright © 2015 Couchcoding

// File:    Logger.cs
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

using System.Diagnostics;

namespace Couchcoding.Logbert.Helper
{
  /// <summary>
  /// Implements a logger to send message to the <see cref="Debug"/> log.
  /// </summary>
  public static class Logger
  {
    #region Public Enums

    /// <summary>
    /// All available log types.
    /// </summary>
    public enum LogType
    {
      Information, 
      Warning, 
      Error
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Sends the given <paramref name="message"/> to the <see cref="EventLog"/>.
    /// </summary>
    /// <param name="message">The message to send to the <see cref="EventLog"/>.</param>
    /// <param name="type">The specified <see cref="EventLogEntryType"/> of the message.</param>
    private static void Log(string message, LogType type)
    {
      if (string.IsNullOrEmpty(message))
      {
        return;
      }

      try
      {
        Debug.WriteLine(
            message
          , type.ToString());
      }
      catch
      {
        // Ignored!
      }
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Writes the given info <paramref name="message"/> to the <see cref="EventLog"/>.
    /// </summary>
    /// <param name="message">The message to send to the <see cref="EventLog"/>.</param>
    /// <param name="args">The optional arguments to format.</param>
    public static void Info(string message, params object[] args)
    {
      Log(string.Format(message, args), LogType.Information);
    }

    /// <summary>
    /// Writes the given warn <paramref name="message"/> to the <see cref="EventLog"/>.
    /// </summary>
    /// <param name="message">The message to send to the <see cref="EventLog"/>.</param>
    /// <param name="args">The optional arguments to format.</param>
    public static void Warn(string message, params object[] args)
    {
      Log(string.Format(message, args), LogType.Warning);
    }

    /// <summary>
    /// Writes the given error <paramref name="message"/> to the <see cref="EventLog"/>.
    /// </summary>
    /// <param name="message">The message to send to the <see cref="EventLog"/>.</param>
    /// <param name="args">The optional arguments to format.</param>
    public static void Error(string message, params object[] args)
    {
      Log(string.Format(message, args), LogType.Error);
    }

    #endregion
  }
}
