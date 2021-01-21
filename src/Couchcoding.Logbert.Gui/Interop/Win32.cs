#region Copyright © 2015 Couchcoding

// File:    Win32.cs
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

namespace Couchcoding.Logbert.Gui.Interop
{
  /// <summary>
  /// Implements several Win32 API method calls.
  /// </summary>
  public static class Win32
  {
    #region Public Consts

    /// <summary>
    /// Sent when the window background must be erased
    /// </summary>
    public const int WM_ERASEBKGND = 0x14;

    /// <summary>
    /// Sets the widths of the left and right margins for an edit control.
    /// </summary>
    public const int EM_SETMARGINS = 0x3d;

    /// <summary>
    /// An application sends the WM_SETREDRAW message to a window to allow changes in that window to be redrawn or to prevent changes in that window from being redrawn.
    /// </summary>
    public static int WM_SETREDRAW = 0x000B;

    /// <summary>
    /// Paints all descendants of a window in bottom-to-top painting order using double-buffering.
    /// </summary>
    public static int WS_EX_COMPOSITED = 0x02000000;

    #endregion

    #region Public Methods

    /// <summary>
    /// Sends the specified message to a window or windows.
    /// </summary>
    /// <param name="hWnd">A handle to the window whose window procedure will receive the message.</param>
    /// <param name="msg">The message to be sent.</param>
    /// <param name="wp">Additional message-specific information.</param>
    /// <param name="lp">Additional message-specific information.</param>
    /// <returns>The return value specifies the result of the message processing; it depends on the message sent.</returns>
    [DllImport("user32.dll")]
    public static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

    /// <summary>
    /// Causes a window to use a different set of visual style information than its class normally uses.
    /// </summary>
    /// <param name="hWnd">Handle to the window whose visual style information is to be changed.</param>
    /// <param name="pszSubAppName">Pointer to a string that contains the application name to use in place of the calling application's name.</param>
    /// <param name="pszSubIdList">Pointer to a string that contains a semicolon-separated list of CLSID names to use in place of the actual list passed by the window's class.</param>
    /// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
    [DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
    public static extern int SetWindowTheme(IntPtr hWnd, string pszSubAppName, string pszSubIdList);

    #endregion
  }
}
