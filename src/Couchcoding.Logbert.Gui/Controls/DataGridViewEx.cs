#region Copyright © 2015 Couchcoding

// File:    DataGridViewEx.cs
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

using Couchcoding.Logbert.Gui.Helper;
using Couchcoding.Logbert.Gui.Interop;
using Couchcoding.Logbert.Theme.Helper;
using Couchcoding.Logbert.Theme.Interfaces;
using Couchcoding.Logbert.Theme.Themes;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Couchcoding.Logbert.Gui.Controls
{
  /// <summary>
  /// Implements a double buffered <see cref="DataGridView"/> <see cref="Control"/>.
  /// </summary>
  public class DataGridViewEx : DataGridView, IThemable
  {
    #region Constructor

    /// <summary>
    /// Creates a new instance of the <see cref="DataGridViewEx"/> <see cref="Control"/>.
    /// </summary>
    public DataGridViewEx()
    {
      SetStyle(ControlStyles.Opaque,                true);
      SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
    }

    #endregion

    /// <summary>
    /// Creates the window handle of the <see cref="TreeViewEx"/> <see cref="Control"/>.
    /// </summary>
    protected override void CreateHandle()
    {
      base.CreateHandle();

      foreach (Control ctrl in Controls)
      {
        if (ctrl is ScrollBar)

          Win32.SetWindowTheme(Handle, "Explorer", null);
      }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);

      if (ClientRectangle.Width > 0 && ClientRectangle.Height > 0)
      {
        var spaceLeft   = VerticalScrollBar.Visible 
          ? SystemInformation.VerticalScrollBarWidth 
          : 0;

        var spaceBottom = HorizontalScrollBar.Visible 
          ? SystemInformation.HorizontalScrollBarHeight 
          : 0;

        e.Graphics.FillRectangle(GdiCache.GetBrushFromColor(Theme.ThemeManager.CurrentApplicationTheme.ColorPalette.ContentBackground), new Rectangle(
          ClientRectangle.Width  - spaceLeft,
          ClientRectangle.Height - spaceBottom,
          SystemInformation.VerticalScrollBarWidth,
          SystemInformation.HorizontalScrollBarHeight));
      }
    }

    /// <summary>
    /// Applies the current theme to the <see cref="Control"/>.
    /// </summary>
    /// <param name="theme">The <see cref="BaseTheme"/> instance to apply.</param>
    public void ApplyTheme(BaseTheme theme)
    {
      BackColor = theme.ColorPalette.ContentBackground;

      foreach (Control ctrl in Controls)
      {
        if (ctrl is ScrollBar && OSHelper.IsWinVista && !string.IsNullOrEmpty(theme.WindowThemeName))
        {
          Win32.SetWindowTheme(ctrl.Handle, theme.WindowThemeName, null);
        }
      }
    }
  }
}
