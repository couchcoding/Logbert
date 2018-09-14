#region Copyright © 2015 Couchcoding

// File:    ListViewEx.cs
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
  /// Implements a <see cref="ListView"/> <see cref="Control"/> that is flicker free.
  /// </summary>
  public class ListViewEx : ListView
  {
    #region Private Consts

    /// <summary>
    /// Defines the minimum width of a column.
    /// </summary>
    private const int MIN_COLUMN_WIDTH = 100;

    #endregion

    #region Interop Methods

    /// <summary>
    /// Causes a window to use a different set of visual style information than its class normally uses.
    /// </summary>
    /// <param name="hWnd">Handle to the window whose visual style information is to be changed.</param>
    /// <param name="pszSubAppName">Pointer to a string that contains the application name to use in place of the calling application's name.</param>
    /// <param name="pszSubIdList">Pointer to a string that contains a semicolon-separated list of CLSID names to use in place of the actual list passed by the window's class.</param>
    /// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
    [DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
    private extern static int SetWindowTheme(IntPtr hWnd, string pszSubAppName, string pszSubIdList);

    #endregion

    #region Private Properties

    /// <summary>
    /// Indicates whether we're running on window vista or higher, or not.
    /// </summary>
    public static bool IsWinVista
    {
      get
      {
        OperatingSystem os = Environment.OSVersion;
        return (os.Platform == PlatformID.Win32NT) && (os.Version.Major >= 6);
      }
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Creates the window handle of the <see cref="TreeViewEx"/> <see cref="Control"/>.
    /// </summary>
    protected override void CreateHandle()
    {
      base.CreateHandle();

      if (IsWinVista)
      {
        SetWindowTheme(Handle, "explorer", null);
      }
    }

    /// <summary>
    /// Notifies the control of Windows messages.
    /// </summary>
    /// <param name="m">A <see cref="T:System.Windows.Forms.Message"/> that represents the Windows message. </param>
    protected override void OnNotifyMessage(Message m)
    {
      // Filter out the WM_ERASEBKGND message.
      if (m.Msg != 0x14)
      {
        base.OnNotifyMessage(m);
      }
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Control.SizeChanged"/> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data. </param>
    protected override void OnSizeChanged(EventArgs e)
    {
      base.OnSizeChanged(e);

      // Ensure the last column uses all available space.
      StretchLastColumn();
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Strches the last column to all available space.
    /// </summary>
    public void StretchLastColumn()
    {
      if (Columns.Count > 0)
      {
        foreach (ColumnHeader clm in Columns)
        {
          // Ensure all columns uses a min space.
          clm.Width = clm.Width < MIN_COLUMN_WIDTH
            ? MIN_COLUMN_WIDTH
            : clm.Width;
        }

        // Stretch the last column to all available space.
        Columns[Columns.Count - 1].Width = -2;
      }
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Creates a new instance of the <see cref="ListViewEx"/> <see cref="Control"/>.
    /// </summary>
    public ListViewEx()
    {
      SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
      SetStyle(ControlStyles.AllPaintingInWmPaint,  true);
      SetStyle(ControlStyles.EnableNotifyMessage,   true);
    }

    #endregion
  }
}
