#region Copyright © 2015 Couchcoding

// File:    Win32.cs
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
using System.Runtime.InteropServices;

namespace Couchcoding.Logbert.Helper
{
  /// <summary>
  /// Implements several Win32 API method calls.
  /// </summary>
  public static class Win32
  {
    #region Public Consts

    /// <summary>
    /// Activates and displays the window. If the window is minimized or maximized, the system restores it to its original size and position.
    /// </summary>
    public const short SW_RESTORE = 9;

    /// <summary>
    /// Retrieves the window styles. 
    /// </summary>
    public const int GWL_STYLE = -16;

    /// <summary>
    /// The window has a vertical scroll bar.
    /// </summary>
    public const int WS_VSCROLL = 0x00200000;

    #endregion

    #region Public Methods

    /// <summary>
    /// Retrieves information about the specified window. The function also retrieves the 32-bit (DWORD) value at the specified offset into the extra window memory. 
    /// </summary>
    /// <param name="hWnd">A handle to the window and, indirectly, the class to which the window belongs.</param>
    /// <param name="nIndex">The zero-based offset to the value to be retrieved.</param>
    /// <returns>If the function succeeds, the return value is the requested value.</returns>
    [DllImport("user32.dll", ExactSpelling = false, CharSet = CharSet.Auto)]
    public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

    /// <summary>
    /// Sets the specified window's show state. 
    /// </summary>
    /// <param name="hWnd">A handle to the window.</param>
    /// <param name="nCmdShow">Controls how the window is to be shown.</param>
    /// <returns>If the window was previously visible, the return value is nonzero. If the window was previously hidden, the return value is zero.</returns>
    [DllImport("user32.dll")]
    public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    /// <summary>
    /// Brings the thread that created the specified window into the foreground and activates the window.
    /// </summary>
    /// <param name="hWnd">A handle to the window that should be activated and brought to the foreground.</param>
    /// <returns>If the window was brought to the foreground, the return value is nonzero. If the window was not brought to the foreground, the return value is zero.</returns>
    [DllImport("user32.dll")]
    public static extern IntPtr SetForegroundWindow(IntPtr hWnd);

    /// <summary>
    /// Compares two Unicode strings. Digits in the strings are considered as numerical content rather than text. This test is not case-sensitive.
    /// </summary>
    /// <param name="psz1">A pointer to the first null-terminated string to be compared.</param>
    /// <param name="psz2">A pointer to the second null-terminated string to be compared.</param>
    /// <returns><list type="bullet">
    /// <item><description>Returns zero if the strings are identical.</description></item>
    /// <item><description>Returns 1 if the string pointed to by psz1 has a greater value than that pointed to by psz2.</description></item>
    /// <item><description>Returns -1 if the string pointed to by psz1 has a lesser value than that pointed to by psz2.</description></item></list></returns>
    [DllImport("shlwapi.dll", CharSet = CharSet.Unicode)]
    public static extern int StrCmpLogicalW(string psz1, string psz2);

    #endregion
  }
}
