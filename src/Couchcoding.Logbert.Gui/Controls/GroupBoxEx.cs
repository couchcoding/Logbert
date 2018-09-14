#region Copyright © 2015 Couchcoding

// File:    GroupBoxEx.cs
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

using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Couchcoding.Logbert.Gui.Controls
{
  /// <summary>
  /// Implements a custom drawn <see cref="GroupBox"/> <see cref="Control"/>.
  /// </summary>
  public class GroupBoxEx : GroupBox
  {
    #region Private Fields

    /// <summary>
    /// Holds the height of the height of the caption area.
    /// </summary>
    private int mGroupCaptionHeight = 20;

    /// <summary>
    /// The <see cref="Color"/> of the seperator line.
    /// </summary>
    private Color mSeperatorColor = SystemColors.ControlDark;

    /// <summary>
    /// The group <see cref="Image"/> to draw.
    /// </summary>
    private Image mGroupImage;

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets or sets the height of the caption area.
    /// </summary>
    [Browsable(true)]
    [DefaultValue(20)]
    [Description("The height of the caption area.")]
    public int GroupCaptionHeight
    {
      get
      {
        return mGroupCaptionHeight;
      }
      set
      {
        if (value > 0 && value < Height && !Equals(mGroupCaptionHeight, value))
        {
          mGroupCaptionHeight = value;

          Padding = new Padding(
              Margin.Left
            , mGroupCaptionHeight
            , Margin.Right
            , Margin.Bottom);

          Invalidate();
        }
      }
    }

    /// <summary>
    /// Gets or sets the seperator <see cref="Color"/>.
    /// </summary>
    [Browsable(true)]
    [Description("The seperator color.")]
    public Color SeperatorColor
    {
      get
      {
        return mSeperatorColor;
      }
      set
      {
        if (!Equals(mSeperatorColor, value))
        {
          mSeperatorColor = value;
          Invalidate();
        }
      }
    }

    /// <summary>
    /// Gets or sets the <see cref="Image"/> for the group.
    /// </summary>
    [Browsable(true)]
    [DefaultValue(null)]
    [Description("The image fo the group.")]
    public Image GroupImage
    {
      get
      {
        return mGroupImage;
      }
      set
      {
        if (!Equals(mGroupImage, value))
        {
          mGroupImage = value;
          Invalidate();
        }
      }
    }

    #endregion

    #region Overridden Methods

    /// <summary>
    /// Handles the OnPaint event of the <see cref="GroupBoxEx"/> <see cref="Control"/>.
    /// </summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs"/> that contains the event data. </param>
    protected override void OnPaint(PaintEventArgs e)
    {
      if (Width > 0 && Height > 0)
      {
        if (mGroupImage != null)
        {
          e.Graphics.DrawImage(
              mGroupImage
            , new Rectangle(0, ((mGroupCaptionHeight - 16) >> 1), 16, 16)
            , new Rectangle(0, 0, mGroupImage.Width, mGroupImage.Height)
            , GraphicsUnit.Pixel);
        }

        TextRenderer.DrawText(
            e.Graphics
          , Text
          , Font
          , new Rectangle(mGroupImage != null ? 20 : 0, 0, Width, mGroupCaptionHeight)
          , ForeColor
          , BackColor
          , TextFormatFlags.SingleLine     | 
            TextFormatFlags.TextBoxControl | 
            TextFormatFlags.VerticalCenter );

        if (!Equals(mSeperatorColor, Color.Transparent))
        {
          Rectangle hRect = new Rectangle(
              0
            , mGroupCaptionHeight
            , Width
            , 1);

          using (Brush hBrush = new LinearGradientBrush(hRect, mSeperatorColor, BackColor, LinearGradientMode.Horizontal))
          {
            e.Graphics.FillRectangle(hBrush, hRect);
          }
        }
      }
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Creates a new instance of the <see cref="GroupBoxEx"/> <see cref="Control"/>.
    /// </summary>
    public GroupBoxEx()
    {
      SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
      SetStyle(ControlStyles.AllPaintingInWmPaint, true);

      Padding = new Padding(
          Margin.Left
        , mGroupCaptionHeight
        , Margin.Right
        , Margin.Bottom);
    }

    #endregion
  }
}
