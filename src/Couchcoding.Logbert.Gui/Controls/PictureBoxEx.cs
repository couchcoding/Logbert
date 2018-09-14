#region Copyright © 2015 Couchcoding

// File:    PictureBoxEx.cs
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
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Couchcoding.Logbert.Gui.Controls
{
  /// <summary>
  /// Implements a <see cref="PictureBox"/> with a proper hand cursor for links.
  /// </summary>
  public class PictureBoxEx : PictureBox
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

    #region Private Fields

    /// <summary>
    /// Determines whether the mouse cursor is over the <see cref="PictureBoxEx"/>.
    /// </summary>
    private bool mIsMouseOver;

    #endregion

    #region Overridden Methdods

    /// <summary>
    /// Processes Windows messages.
    /// </summary>
    /// <param name="m">The Windows <see cref="T:System.Windows.Forms.Message"/> to process. </param>
    protected override void WndProc(ref Message m)
    {
      if (m.Msg == WM_SETCURSOR && Cursor == Cursors.Hand)
      {
        // Set the systems hand cursor.
        SetCursor(LoadCursor(0, IDC_HAND));

        // The message has been handled.
        m.Result = IntPtr.Zero;
        return;
      }

      base.WndProc(ref m);
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Control.Paint"/> event.
    /// </summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs"/> that contains the event data.</param>
    protected override void OnPaint(PaintEventArgs pe)
    {
      base.OnPaint(pe);

      if (Width <= 0 || Height <= 0)
      {
        return;
      }

      if (mIsMouseOver)
      {
        using (Pen backPen = new Pen(Color.FromArgb(25, SystemColors.Highlight)))
        {
          pe.Graphics.FillRectangle(
              backPen.Brush
            , 0
            , pe.ClipRectangle.Top
            , pe.ClipRectangle.Width - 0
            , pe.ClipRectangle.Height - 0);

          using (Pen highlightPen = new Pen(Color.FromArgb(100, backPen.Color)))
          {
            pe.Graphics.DrawRectangle(
                highlightPen
              , 0
              , pe.ClipRectangle.Top
              , pe.ClipRectangle.Width - 1
              , pe.ClipRectangle.Height - 1);
          }
        }
      }

      if (Focused && ShowFocusCues && Width > 4 && Height > 4)
      {
        ControlPaint.DrawFocusRectangle(
            pe.Graphics,
          new Rectangle(2, 2, ClientRectangle.Width - 4, ClientRectangle.Height - 4));
      }
    }

    /// <summary>
    /// Handles the OnMouseEnter event of the <see cref="PictureBoxEx"/>.
    /// </summary>
    protected override void OnMouseEnter(EventArgs e)
    {
      base.OnMouseEnter(e);

      if (!mIsMouseOver)
      {
        mIsMouseOver = true;
        Invalidate();
      }
    }

    /// <summary>
    /// Handles the OnMouseLeave event of the <see cref="PictureBoxEx"/>.
    /// </summary>
    protected override void OnMouseLeave(EventArgs e)
    {
      base.OnMouseLeave(e);

      if (mIsMouseOver)
      {
        mIsMouseOver = false;
        Invalidate();
      }
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Control.GotFocus"/> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data. </param>
    protected override void OnGotFocus(EventArgs e)
    {
      base.OnGotFocus(e);

      Invalidate();
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Control.LostFocus"/> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data. </param>
    protected override void OnLostFocus(EventArgs e)
    {
      base.OnLostFocus(e);

      Invalidate();
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Creates a new instance of the <see cref="PictureBoxEx"/> control.
    /// </summary>
    public PictureBoxEx()
    {
      SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
      SetStyle(ControlStyles.ResizeRedraw,          true);
      SetStyle(ControlStyles.Selectable,            true);
      SetStyle(ControlStyles.UserPaint,             true);
    }

    #endregion
  }
}
