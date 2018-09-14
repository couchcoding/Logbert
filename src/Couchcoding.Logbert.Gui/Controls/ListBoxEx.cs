#region Copyright © 2015 Couchcoding

// File:    ListBoxEx.cs
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
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Couchcoding.Logbert.Gui.Controls
{
  /// <summary>
  /// Implements a flicker free custom drawn <see cref="ListBox"/> <see cref="Control"/>.
  /// </summary>
  public class ListBoxEx : ListBox
  {
    #region Private Consts

    private const int PRF_CLIENT     = 0x4;
    private const int WM_PRINTCLIENT = 0x318;

    #endregion

    #region Private Types

    /// <summary>
    /// Implements a <see cref="ListBox"/> item <see cref="Seperator"/>
    /// </summary>
    protected class Seperator
    {
      #region Publie Methods

      /// <summary>
      /// Returns the fully qualified type name of this instance.
      /// </summary>
      /// <returns>A <see cref="T:System.String"/> containing a fully qualified type name.</returns>
      public override string ToString()
      {
        return string.Empty;
      }

      #endregion
    }

    /// <summary>
    /// Defines all known <see cref="ListView"/> states.
    /// </summary>
    protected enum ListViewState
    {
      Normal = 1,
      Hot = 2,
      Selected = 3,
      Disabled = 4,
      SelectedAnNotFocused = 5,
      HotSelected = 6
    }

    #endregion

    #region Private Fields

    /// <summary>
    /// Holds the last hovered item index.
    /// </summary>
    protected int mMouseIndex = -1;

    /// <summary>
    /// The height of a <see cref="Seperator"/> item.
    /// </summary>
    protected int mSeperatorHeight = 6;

    /// <summary>
    /// The string format to use for the text drawing.
    /// </summary>
    protected static StringFormat mStringFormat = new StringFormat
    {
      Alignment     = StringAlignment.Near,
      LineAlignment = StringAlignment.Center,
      Trimming      = StringTrimming.EllipsisCharacter
    };

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets or sets the drawing mode for the control.
    /// </summary>
    /// <returns>One of the <see cref="T:System.Windows.Forms.DrawMode"/> values representing the mode for drawing the items of the control. The default is DrawMode.Normal.</returns>
    [Description("Gets or sets the drawing mode for the control.")]
    [DefaultValue(DrawMode.Normal)]
    [Category("Behavior")]
    [RefreshProperties(RefreshProperties.Repaint)]
    public new DrawMode DrawMode
    {
      get
      {
        return base.DrawMode;
      }
      set
      {
        base.DrawMode = value;
      }
    }

    /// <summary>
    /// Gets or sets the height of an item in the <see cref="T:System.Windows.Forms.ListBox"/>.
    /// </summary>
    /// <returns>The height, in pixels, of an item in the control.</returns>
    [RefreshProperties(RefreshProperties.Repaint)]
    [Category("Behavior")]
    [DefaultValue(13)]
    [Localizable(true)]
    [Description("Gets or sets the height of an item in the ListBox")]
    public new int ItemHeight
    {
      get
      {
        return base.ItemHeight;
      }
      set
      {
        base.ItemHeight = DpiHelper.RescaleByDpiY(value);
      }
    }

    /// <summary>
    /// Gets or sets the <see cref="Seperator"/> items.
    /// </summary>
    /// <returns>The height, in pixels, of a <see cref="Seperator"/> item in the control.</returns>
    [RefreshProperties(RefreshProperties.Repaint)]
    [Category("Behavior")]
    [DefaultValue(6)]
    [Description("Gets or sets the height of a seperator item in the ListBox")]
    public int SeperatorHeight
    {
      get
      {
        return mSeperatorHeight;
      }
      set
      {
        int newValue = DpiHelper.RescaleByDpiY(value);

        if (newValue > 0 && mSeperatorHeight != newValue)
        {
          mSeperatorHeight = newValue;
        }
      }
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Invalidates the item at the given <paramref name="index"/>.
    /// </summary>
    /// <param name="index">The index of the item to invalidate.</param>
    private void InvalidateItem(int index)
    {
      if (index > -1 && index < Items.Count)
      {
        Invalidate(GetItemRectangle(index));
      }
    }

    /// <summary>
    /// Handles the item drawing of a non selected item.
    /// </summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.DrawItemEventArgs"/> that contains the event data.</param>
    /// <param name="selected">Determines wheter the item is currently selected.</param>
    protected virtual void DrawItemHighlighted(DrawItemEventArgs e, bool selected)
    {
      if (VisualStyleRenderer.IsSupported)
      {
        VisualStyleElement elementToDraw = selected 
          ? VisualStyleElement.CreateElement("Explorer::ListView", 1, (int)ListViewState.HotSelected)
          : VisualStyleElement.CreateElement("Explorer::ListView", 1, (int)ListViewState.Hot);

        if (VisualStyleRenderer.IsElementDefined(elementToDraw))
        {
          new VisualStyleRenderer(elementToDraw).DrawBackground(e.Graphics, e.Bounds);
          return;
        }
      }

      using (Pen backPen = new Pen(Color.FromArgb(25, SystemColors.Highlight)))
      {
        e.Graphics.FillRectangle(
            backPen.Brush
          , 0
          , e.Bounds.Top
          , e.Bounds.Width - 0
          , e.Bounds.Height - 0);

        using (Pen highlightPen = new Pen(Color.FromArgb(100, backPen.Color)))
        {
          e.Graphics.DrawRectangle(
              highlightPen
            , 0
            , e.Bounds.Top
            , e.Bounds.Width - 1
            , e.Bounds.Height - 1);
        }
      }
    }

    /// <summary>
    /// Handles the item drawing of a selected item.
    /// </summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.DrawItemEventArgs"/> that contains the event data.</param>
    /// <param name="hover">Determines whether the cursor is currently hovering over the item.</param>
    protected virtual void DrawItemSelected(DrawItemEventArgs e, bool hover)
    {
      if (VisualStyleRenderer.IsSupported)
      {
        VisualStyleElement elementToDraw = hover 
          ? VisualStyleElement.CreateElement("Explorer::ListView", 1, (int)ListViewState.HotSelected)
          : VisualStyleElement.CreateElement("Explorer::ListView", 1, (int)ListViewState.Selected);

        if (VisualStyleRenderer.IsElementDefined(elementToDraw))
        {

          new VisualStyleRenderer(elementToDraw).DrawBackground(e.Graphics, e.Bounds);
          return;
        }
      }

      using (Pen backPen = new Pen(Color.FromArgb(50, SystemColors.Highlight)))
      {
        e.Graphics.FillRectangle(
            backPen.Brush
          , 0
          , e.Bounds.Top
          , e.Bounds.Width - 0
          , e.Bounds.Height - 0);

        using (Pen highlightPen = new Pen(Color.FromArgb(200, backPen.Color)))
        {
          e.Graphics.DrawRectangle(
              highlightPen
            , 0
            , e.Bounds.Top
            , e.Bounds.Width - 1
            , e.Bounds.Height - 1);
        }
      }
    }

    /// <summary>
    /// Handles the drawing of the item text.
    /// </summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.DrawItemEventArgs"/> that contains the event data.</param>
    protected virtual void DrawItemText(DrawItemEventArgs e)
    {
      e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

      e.Graphics.DrawString(
          Items[e.Index].ToString()
        , Font
        , SystemBrushes.ControlText
        , new Rectangle(2, e.Bounds.Top + 2, e.Bounds.Width - 4, e.Bounds.Height - 4)
        , mStringFormat);
    }

    /// <summary>
    /// Handles the drawing of a <see cref="Seperator"/> item.
    /// </summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.DrawItemEventArgs"/> that contains the event data.</param>
    protected virtual void DrawSeperator(DrawItemEventArgs e)
    {
      Rectangle hRect = new Rectangle(
          0
        , e.Bounds.Top + (e.Bounds.Height >> 1)
        , Width
        , 1);

      using (Brush hBrush = new LinearGradientBrush(hRect, SystemColors.ControlDark, BackColor, LinearGradientMode.Horizontal))
      {
        e.Graphics.FillRectangle(hBrush, hRect);
      }
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.ListBox.DrawItem"/> event.
    /// </summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.DrawItemEventArgs"/> that contains the event data.</param>
    protected override void OnDrawItem(DrawItemEventArgs e)
    {
      if (Items.Count == 0 || e.Index > Items.Count)
      {
        return;
      }

      e.Graphics.FillRectangle(SystemBrushes.Window, e.Bounds);

      if (Items[e.Index] is Seperator)
      {
        DrawSeperator(e);
        return;
      }

      bool isSelected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
      bool isHover    = mMouseIndex != -1 && e.Index == mMouseIndex;

      if (isSelected)
      {
        DrawItemSelected(e, isHover);

        if (Focused && ShowFocusCues)
        {
          ControlPaint.DrawFocusRectangle(e.Graphics, new Rectangle(
              e.Bounds.X + 1
            , e.Bounds.Y + 1
            , e.Bounds.Width  - 2
            , e.Bounds.Height - 2));
        }
      }

      if (isHover)
      {
        DrawItemHighlighted(e, isSelected);
      }
      
      DrawItemText(e);
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Control.MouseMove"/> event.
    /// </summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs"/> that contains the event data. </param>
    protected override void OnMouseMove(MouseEventArgs e)
    {
      base.OnMouseMove(e);

      int index = IndexFromPoint(e.Location);

      if (index >= 0 && e.Y > GetItemRectangle(index).Bottom)
      {
        index = -1;
      }

      if (!Equals(mMouseIndex, index))
      {
        InvalidateItem(mMouseIndex);
        mMouseIndex = index;
        InvalidateItem(mMouseIndex);
      }
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Control.MouseLeave"/> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data. </param>
    protected override void OnMouseLeave(EventArgs e)
    {
      base.OnMouseLeave(e);

      InvalidateItem(mMouseIndex);
      mMouseIndex = -1;
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Control.Paint"/> event.
    /// </summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs"/> that contains the event data.</param>
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

    /// <summary>
    /// Raises the MeasureItem event.
    /// </summary>
    /// <param name="e">The <see cref="MeasureItemEventArgs"/> that was raised. </param>
    protected override void OnMeasureItem(MeasureItemEventArgs e)
    {
      if (Items.Count > e.Index && Items[e.Index] is Seperator)
      {
        e.ItemHeight = mSeperatorHeight;
      }

      base.OnMeasureItem(e);
    }

    /// <summary>
    /// Raises the SelectedIndexChanged event.
    /// </summary>
    /// <param name="e">A <see cref="EventArgs"/> that contains the event data. </param>
    protected override void OnSelectedIndexChanged(EventArgs e)
    {
      base.OnSelectedIndexChanged(e);

      if (SelectedIndex <= 0)
      {
        return;
      }

      if (Items[SelectedIndex] is Seperator && Items.Count > SelectedIndex)
      {
        ++SelectedIndex;
      }
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Adds a <see cref="Seperator"/> to the item list.
    /// </summary>
    public void AddSeperator()
    {
      Items.Add(new Seperator());
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Creates a new instance of the <see cref="ListBoxEx"/> <see cref="Control"/>.
    /// </summary>
    public ListBoxEx()
    {
      // Enable default double buffering processing (DoubleBuffered returns true)
      SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
      
      //// Disable default CommCtrl painting.
      SetStyle(ControlStyles.UserPaint, true);
      SetStyle(ControlStyles.EnableNotifyMessage, true);

      DrawMode   = DrawMode.OwnerDrawVariable;
      ItemHeight = 24;
    }

    #endregion
  }
}
