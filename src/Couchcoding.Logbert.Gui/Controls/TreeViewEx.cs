#region Copyright © 2015 Couchcoding

// File:    TreeViewEx.cs
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
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Couchcoding.Logbert.Gui.Controls
{
  /// <summary>
  /// Implements a double buffered <see cref=" TreeView"/> that is drawn like the native one.
  /// </summary>
  public class TreeViewEx : TreeView
  {
    #region Private Consts

    /// <summary>
    /// Defines the first message index for a <see cref="TreeView"/>.
    /// </summary>
    private const int TV_FIRST = 0x1100;

    /// <summary>
    /// Sets the background color of the control.
    /// </summary>
    private const int TVM_SETBKCOLOR = TV_FIRST + 29;

    /// <summary>
    /// Informs the tree-view control to set extended styles.
    /// </summary>
    private const int TVM_SETEXTENDEDSTYLE = TV_FIRST + 44;

    /// <summary>
    /// Informs the tree-view to use extended double buffering.
    /// </summary>
    private const int TVS_EX_DOUBLEBUFFER = 0x0004;

    /// <summary>
    /// The WM_PRINTCLIENT message is sent to a window to request that it draw its client area in the specified device context, most commonly in a printer device context.
    /// </summary>
    private const int WM_PRINTCLIENT = 0x0318;

    /// <summary>
    /// Draws the client area of the window.
    /// </summary>
    private const int PRF_CLIENT = 0x00000004;

    #endregion

    #region Private Fields

    /// <summary>
    /// Updates the system style of the <see cref="TreeViewEx"/>.
    /// </summary>
    private void UpdateExtendedStyles()
    {
      int style = DoubleBuffered 
        ? TVS_EX_DOUBLEBUFFER 
        : 0;

      if (style != 0 && IsHandleCreated)
      {
        Win32.SendMessage(
            Handle
          , TVM_SETEXTENDEDSTYLE
          , (IntPtr)TVS_EX_DOUBLEBUFFER
          , (IntPtr)style);
      }
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Overrides <see cref="M:System.Windows.Forms.Control.OnHandleCreated(System.EventArgs)"/>.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
    protected override void OnHandleCreated(EventArgs e)
    {
      base.OnHandleCreated(e);
      
      UpdateExtendedStyles();
        
      if (!OSHelper.IsWinVista)
      {
        Win32.SendMessage(
            Handle
          , TVM_SETBKCOLOR
          , IntPtr.Zero
          , (IntPtr)ColorTranslator.ToWin32(BackColor));
      }
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Control.Paint"/> event.
    /// </summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs"/> that contains the event data. </param>
    protected override void OnPaint(PaintEventArgs e)
    {
      if (GetStyle(ControlStyles.UserPaint))
      {
        Message m = new Message();
        m.HWnd = Handle;
        m.Msg = WM_PRINTCLIENT;
        m.WParam = e.Graphics.GetHdc();
        m.LParam = (IntPtr)PRF_CLIENT;
        DefWndProc(ref m);
        e.Graphics.ReleaseHdc(m.WParam);
      }

      base.OnPaint(e);
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Forces the <see cref="TreeViewEx"/> to draw itseld as the explorer <see cref="TreeView"/> if supported by the OS.
    /// </summary>
    /// <param name="value"><c>True</c> to render the <see cref="TreeView"/> native; otherwise <c>false</c>.</param>
    public void UseNativeSystemRendering(bool value)
    {
      if (!value && IsHandleCreated)
      {
        RecreateHandle();
        return;
      }

      if (OSHelper.IsWinVista && value)
      {
        if (!IsHandleCreated)
        {
          CreateHandle();
        }
      }
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Creates a new instance of the <see cref="TreeViewEx"/> <see cref="Control"/>.
    /// </summary>
    public TreeViewEx()
    {
      // Enable default double buffering processing
      SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
      SetStyle(ControlStyles.AllPaintingInWmPaint,  true);

      // Disable default CommCtrl painting on non-Vista systems
      if (!OSHelper.IsWinVista)
      {
        SetStyle(ControlStyles.UserPaint, true);
      }
    }

    #endregion
  }
}
