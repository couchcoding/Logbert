#region Copyright © 2015 Couchcoding

// File:    ToolStripEx.cs
// Package: GuiLibrary
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
using System.Windows.Forms;

namespace Couchcoding.Logbert.Gui.Controls
{
  /// <summary>
  /// Implements an enhanced <see cref="ToolStrip"/> control with enabled click through.
  /// </summary>
  public class ToolStripEx : ToolStrip
  {
    #region Private Consts

    /// <summary>
    /// Sent when the cursor is in an inactive window and the user presses a mouse button.
    /// </summary>
    private const uint WM_MOUSEACTIVATE = 0x21;

    /// <summary>
    /// Sent when the cursor is in an inactive window and the user presses a mouse button.
    /// </summary>
    private const uint MA_ACTIVATE = 0x1;

    /// <summary>
    /// Sent when the cursor is in an inactive window and the user presses a mouse button.
    /// </summary>
    private const uint MA_ACTIVATEANDEAT = 0x2;

    #endregion

    #region Overridden Methods

    /// <summary>
    /// Processes Windows messages.
    /// </summary>
    /// <param name="m">The Windows <see cref="T:System.Windows.Forms.Message"/> to process.</param>
    protected override void WndProc(ref Message m)
    {
      base.WndProc(ref m);

      if (m.Msg == WM_MOUSEACTIVATE && m.Result == (IntPtr)MA_ACTIVATEANDEAT)
      {
        m.Result = (IntPtr)MA_ACTIVATE;
      }
    }

    #endregion
  }
}
