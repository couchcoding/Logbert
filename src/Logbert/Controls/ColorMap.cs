#region Copyright © 2016 Couchcoding

// File:    ColorMap.cs
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
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Couchcoding.Logbert.Helper;
using Couchcoding.Logbert.Theme.Palettes;
using Couchcoding.Logbert.Theme.Interfaces;
using Couchcoding.Logbert.Logging;
using Couchcoding.Logbert.Properties;
using Couchcoding.Logbert.Interfaces;
using Couchcoding.Logbert.Theme;
using Couchcoding.Logbert.Theme.Themes;
using Couchcoding.Logbert.Theme.Helper;

namespace Couchcoding.Logbert.Controls
{
  /// <summary>
  /// Implements a control to show a line mapping.
  /// </summary>
  public partial class ColorMap : UserControl, IThemable
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
    /// The dictionary to map lines to <see cref="LogMessage"/>s.
    /// </summary>
    private readonly Dictionary<int, LogMessage> mColoredLines = new Dictionary<int, LogMessage>();

    /// <summary>
    /// The general <see cref="Padding"/> to define the real drawing area.
    /// </summary>
    private Padding mViewRectPadding;

    /// <summary>
    /// The <see cref="ILogPresenter"/> isntance to inform about message selection.
    /// </summary>
    private readonly ILogPresenter mLogPresenter;

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets or sets the background color for the control.
    /// </summary>
    /// <returns>A <see cref="T:System.Drawing.Color" /> that represents the background color of the control. The default is the value of the <see cref="P:System.Windows.Forms.Control.DefaultBackColor" /> property.</returns>
    public sealed override Color BackColor
    {
      get
      {
        return base.BackColor;
      }

      set
      {
        base.BackColor = value;
      }
    }

    #endregion

    #region Private Methods

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
    /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
    /// </summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data. </param>
    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);

      Pen drawPen = null;

      foreach (KeyValuePair<int, LogMessage> keyVal in mColoredLines)
      {
        if ((keyVal.Value.Level & (LogLevel)Settings.Default.ColorMapAnnotation) != keyVal.Value.Level)
        {
          continue;
        }

        switch (keyVal.Value.Level)
        {
          case LogLevel.Fatal:
            drawPen = ThemeManager.CurrentApplicationTheme.ColorPalette.ContentBackground.Equals(Settings.Default.BackgroundColorFatal) 
              ? GdiCache.GetPenFromColor(Settings.Default.ForegroundColorFatal) 
              : GdiCache.GetPenFromColor(Settings.Default.BackgroundColorFatal);
            break;

          case LogLevel.Error:
            drawPen = ThemeManager.CurrentApplicationTheme.ColorPalette.ContentBackground.Equals(Settings.Default.BackgroundColorError) 
              ? GdiCache.GetPenFromColor(Settings.Default.ForegroundColorError) 
              : GdiCache.GetPenFromColor(Settings.Default.BackgroundColorError);
            break;

          case LogLevel.Warning:
            drawPen = ThemeManager.CurrentApplicationTheme.ColorPalette.ContentBackground.Equals(Settings.Default.BackgroundColorWarning) 
              ? GdiCache.GetPenFromColor(Settings.Default.ForegroundColorWarning) 
              : GdiCache.GetPenFromColor(Settings.Default.BackgroundColorWarning);
            break;

          case LogLevel.Info:
            drawPen = ThemeManager.CurrentApplicationTheme.ColorPalette.ContentBackground.Equals(Settings.Default.BackgroundColorInfo) 
              ? GdiCache.GetPenFromColor(Settings.Default.ForegroundColorInfo) 
              : GdiCache.GetPenFromColor(Settings.Default.BackgroundColorInfo);
            break;

          case LogLevel.Debug:
            drawPen = ThemeManager.CurrentApplicationTheme.ColorPalette.ContentBackground.Equals(Settings.Default.BackgroundColorDebug) 
              ? GdiCache.GetPenFromColor(Settings.Default.ForegroundColorDebug) 
              : GdiCache.GetPenFromColor(Settings.Default.BackgroundColorDebug);
            break;

          case LogLevel.Trace:
            drawPen = ThemeManager.CurrentApplicationTheme.ColorPalette.ContentBackground.Equals(Settings.Default.BackgroundColorTrace) 
              ? GdiCache.GetPenFromColor(Settings.Default.ForegroundColorTrace) 
              : GdiCache.GetPenFromColor(Settings.Default.BackgroundColorTrace);
            break;

          default:
            drawPen = null;
            break;
        }

        if (drawPen != null)
        {
          e.Graphics.DrawLine(drawPen, 0, keyVal.Key, Width, keyVal.Key);
        }
      }
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Control.MouseMove" /> event.
    /// </summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data. </param>
    protected override void OnMouseMove(MouseEventArgs e)
    {
      base.OnMouseMove(e);

      if (mLogPresenter != null)
      {
        if (mColoredLines.ContainsKey(e.Y) && (mColoredLines[e.Y].Level & (LogLevel)Settings.Default.ColorMapAnnotation) == mColoredLines[e.Y].Level)
        {
          if (Cursor != Cursors.Hand)
          {
            Cursor = Cursors.Hand;
          }
        }
        else
        {
          if (Cursor != Cursors.Default)
          {
            Cursor = Cursors.Default;
          }
        }
      }
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
    /// </summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data. </param>
    protected override void OnMouseDown(MouseEventArgs e)
    {
      base.OnMouseDown(e);

      if (mLogPresenter != null)
      {
        if (mColoredLines.ContainsKey(e.Y) && (mColoredLines[e.Y].Level & (LogLevel)Settings.Default.ColorMapAnnotation) == mColoredLines[e.Y].Level)
        {
          mLogPresenter.SelectLogMessage(mColoredLines[e.Y]);
        }
      }
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Updates the internal color map to display.
    /// </summary>
    /// <param name="displayedMessages"></param>
    public void UpdateColorMap(List<LogMessage> displayedMessages)
    {
      if (Disposing || IsDisposed || !Visible)
      {
        return;
      }

      this.SuspendDrawing();

      try
      {
        // Clear old values.
        mColoredLines.Clear();

        if (displayedMessages == null)
        {
          // No message received yet.
          return;
        }

        // Calculate the available height.
        float ctrlHeight = Height - (mViewRectPadding.Top + mViewRectPadding.Bottom);

        if (ctrlHeight <= 0)
        {
          // No space to draw!
          return;
        }

        for (int i = 0; i < displayedMessages.Count; ++i)
        {
          int newDrawindex = mViewRectPadding.Top + (int)(ctrlHeight / displayedMessages.Count * i);

          if (mColoredLines.ContainsKey(newDrawindex) && mColoredLines[newDrawindex].Level > displayedMessages[i].Level)
          {
            // Don't overwrite higher error indicators.
            continue;
          }

          mColoredLines[newDrawindex] = displayedMessages[i];
        }
      }
      finally
      {
        this.ResumeDrawing();
      }
    }

    /// <summary>
    /// Clears all shown <see cref="LogMessage"/>s.
    /// </summary>
    public void ClearAll()
    {
      if (mColoredLines.Count > 0)
      {
        mColoredLines.Clear();
        Invalidate();
      }
    }

    /// <summary>
    /// Applies the current theme to the <see cref="Control"/>.
    /// </summary>
    /// <param name="theme">The <see cref="BaseTheme"/> instance to apply.</param>
    public void ApplyTheme(BaseTheme theme)
    {
      BackColor = theme.ColorPalette.ContentBackground;
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Initializes a new instance of the <see cref="ColorMap"/> control.
    /// </summary>
    public ColorMap(ILogPresenter logPresenter)
    {
      SetStyle(ControlStyles.AllPaintingInWmPaint,  true);
      SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
      SetStyle(ControlStyles.ResizeRedraw,          true);
      SetStyle(ControlStyles.UserPaint,             true);

      InitializeComponent();

      ThemeManager.ApplyTo(this);

      mLogPresenter    = logPresenter;
      mViewRectPadding = new Padding(
          0
        , SystemInformation.VerticalScrollBarArrowHeight
        , 0
        , SystemInformation.HorizontalScrollBarHeight + SystemInformation.VerticalScrollBarArrowHeight);
    }

    #endregion
  }
}
