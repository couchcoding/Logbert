#region Copyright © 2021 Couchcoding

// File:    LogError.cs
// Package: Logbert
// Project: Logbert
// 
// The MIT License (MIT)
// 
// Copyright (c) 2021 Couchcoding
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

using Couchcoding.Logbert.Properties;
using System.Drawing;

namespace Couchcoding.Logbert.Logging
{
  /// <summary>
  /// Implements an object to encapsulate messages to the user.
  /// </summary>
  public sealed class LogError
  {
    #region Public Properties

    /// <summary>
    /// The title of the <see cref="LogError"/>.
    /// </summary>
    public string Title
    {
      get;
    }

    /// <summary>
    /// The message to display to the user of the <see cref="LogError"/>.
    /// </summary>
    public string Message
    {
      get;
    }

    /// <summary>
    /// The background <see cref="Color"/> of the <see cref="LogError"/>.
    /// </summary>
    public Color BackColor
    {
      get;
    }

    /// <summary>
    /// The foreground <see cref="Color"/> of the <see cref="LogError"/>.
    /// </summary>
    public Color ForeColor
    {
      get;
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Get a new <see cref="LogError"/> instance that indicates an information.
    /// </summary>
    /// <param name="message">The message to display to the user.</param>
    /// <returns>A new <see cref="LogError"/> instance that indicates an information.</returns>
    public static LogError Info(string message)
    {
      return new LogError(Resources.strDocumentInfoTitle, 
        message, 
        SystemColors.Info, 
        SystemColors.InfoText);
    }

    /// <summary>
    /// Get a new <see cref="LogError"/> instance that indicates a warning.
    /// </summary>
    /// <param name="message">The message to display to the user.</param>
    /// <returns>A new <see cref="LogError"/> instance that indicates a warning.</returns>
    public static LogError Warn(string message)
    {
      return new LogError(Resources.strDocumentWarnTitle, 
        message, 
        Color.Orange, 
        Color.Black);
    }

    /// <summary>
    /// Get a new <see cref="LogError"/> instance that indicates an error.
    /// </summary>
    /// <param name="message">The message to display to the user.</param>
    /// <returns>A new <see cref="LogError"/> instance that indicates an error.</returns>
    public static LogError Error(string message)
    {
      return new LogError(Resources.strDocumentErrorTitle, 
        message, 
        Color.LightCoral, 
        Color.Black);
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Initializes a new instance of the <see cref="LogError"/> class with the specified parameters.
    /// </summary>
    /// <param name="title">The title of the <see cref="LogError"/>.</param>
    /// <param name="message">The message to display to the user.</param>
    /// <param name="backColor">The background <see cref="Color"/> for the message.</param>
    /// <param name="foreColor">The foreground <see cref="Color"/> for the message.</param>
    private LogError(string title, string message, Color backColor, Color foreColor)
    {
      Title     = title;
      Message   = message;
      BackColor = backColor;
      ForeColor = ForeColor;
    }

    #endregion
  }
}
