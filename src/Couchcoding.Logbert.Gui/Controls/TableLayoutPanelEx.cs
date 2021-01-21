#region Copyright © 2015 Couchcoding

// File:    TableLayoutPanelEx.cs
// Package: Logbert
// Project: Logbert
// 
// The MIT License (MIT)
// 
// Copyright (c) 2020 Couchcoding
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

using Couchcoding.Logbert.Gui.Interop;
using System;
using System.Windows.Forms;

namespace Couchcoding.Logbert.Gui.Controls
{
  public class TableLayoutPanelEx : TableLayoutPanel
  {
    #region Public Properties

    /// <summary>
    /// Gets the required creation parameters when the control handle is created.
    /// </summary>
    protected override CreateParams CreateParams
    {
      get
      {
        CreateParams cp = base.CreateParams;
        cp.ExStyle |= Win32.WS_EX_COMPOSITED;
        return cp;
      }
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Raises the CreateControl() method.
    /// </summary>
    protected override void OnCreateControl()
    {
      base.OnCreateControl();

      SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
      SetStyle(ControlStyles.CacheText, true);
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Disables any redrawing of the <see cref="Control"/>.
    /// </summary>
    public void BeginUpdate()
    {
      if (IsHandleCreated)
      {
        Win32.SendMessage(Handle, Win32.WM_SETREDRAW, IntPtr.Zero, IntPtr.Zero);
      }
    }

    /// <summary>
    /// Enables any redrawing of the <see cref="Control"/>.
    /// </summary>
    public void EndUpdate()
    {
      if (IsHandleCreated)
      {
        Win32.SendMessage(Handle, Win32.WM_SETREDRAW, new IntPtr(1), IntPtr.Zero);

        Parent?.Invalidate(true);
      }
    }

    #endregion
  }
}
