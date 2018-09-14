#region Copyright © 2015 Couchcoding

// File:    LinkLabelEx.cs
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
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Couchcoding.Logbert.Gui.Controls
{
  /// <summary>
  /// Implements a <see cref="LinkLabel"/> with a correct hand <see cref="Cursor"/>.
  /// </summary>
  public class LinkLabelEx : LinkLabel
  {
    #region Private Consts

    /// <summary>
    /// Sent to a window if the mouse causes the cursor to move within a window and mouse input is not captured. 
    /// </summary>
    private const int WM_SETCURSOR = 0x0020;

    /// <summary>
    /// The Hand cursor.
    /// </summary>
    private const int IDC_HAND = 0x7f89;

    #endregion

    #region Interop Methods

    /// <summary>
    /// Loads the specified cursor resource from the executable (.EXE) file associated with an application instance.
    /// </summary>
    /// <param name="hInstance">A handle to an instance of the module whose executable file contains the cursor to be loaded. </param>
    /// <param name="lpCursorName">The name of the cursor resource to be loaded.</param>
    /// <returns>If the function succeeds, the return value is the handle to the newly loaded cursor.</returns>
    [DllImport("user32.dll")]
    private static extern int LoadCursor(int hInstance, int lpCursorName);

    /// <summary>
    /// Sets the cursor shape. 
    /// </summary>
    /// <param name="hCursor">A handle to the cursor.</param>
    /// <returns>The return value is the handle to the previous cursor, if there was one. </returns>
    [DllImport("user32.dll")]
    private static extern int SetCursor(int hCursor);

    #endregion

    #region Overridden Methdods

    /// <summary>
    /// Processes Windows messages.
    /// </summary>
    /// <param name="m">The Windows <see cref="T:System.Windows.Forms.Message"/> to process. </param>
    protected override void WndProc(ref Message m)
    {
      if (m.Msg == WM_SETCURSOR)
      {
        // Set the systems hand cursor.
        SetCursor(LoadCursor(0, IDC_HAND));

        // The message has been handled.
        m.Result = IntPtr.Zero;
        return;
      }

      base.WndProc(ref m);
    }

    #endregion
  }
}
