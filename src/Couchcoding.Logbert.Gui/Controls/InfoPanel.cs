#region Copyright © 2015 Couchcoding

// File:    InfoPanel.cs
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
using System.Windows.Forms;

namespace Couchcoding.Logbert.Gui.Controls
{
  /// <summary>
  /// Implements the <see cref="InfoPanel"/> <see cref="Control"/>.
  /// </summary>
  public class InfoPanel : Panel
  {
    #region Private Consts

    /// <summary>
    /// Defines the default horizontal resolution.
    /// </summary>
    protected const float DEFAULT_DPI_Y = 96.0f;

    /// <summary>
    /// Defines the defualt vertical resolution.
    /// </summary>
    protected const float DEFAULT_DPI_X = 96.0f;

    #endregion

    #region Private Fields

    private static SizeF mDpiSize = new SizeF(96.0f, 96.0f);
    
    private Color   mBorderColor  = SystemColors.ControlDark;
    private bool    mShowBorder   = true;
    private bool    mShowTitle    = true;
    private bool    mShowInfoIcon;
    private Image   mInfoImage;
    private Padding mTextPadding;
    private string  mTitle;

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets or sets the border <see cref="Color"/> of the <see cref="Panel"/>.
    /// </summary>
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [Description("Gets or sets the border color of the panel.")]
    public Color BorderColor
    {
      get 
      {
        return mBorderColor;
      }
      set
      {
        if (mBorderColor != value)
        { 
          mBorderColor = value;
          Invalidate();
        }
      }
    }

    /// <summary>
    /// Gets or sets the back <see cref="Color"/> of the <see cref="Panel"/>.
    /// </summary>
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [Description("Gets or sets the back color of the panel.")]
    public override sealed Color BackColor
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

    /// <summary>
    /// Gets or sets the border drawing flag.
    /// </summary>
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [Description("Gets or sets the border drawing flag.")]
    [DefaultValue(true)]
    public bool ShowBorder
    {
      get 
      {
        return mShowBorder;
      }
      set
      {
        if (mShowBorder != value)
        { 
          mShowBorder = value;
          Invalidate();
        }
      }
    }

    /// <summary>
    /// Gets or sets the visibility of the info icon.
    /// </summary>
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [Description("Gets or sets the visibility of the info icon.")]
    [DefaultValue(false)]
    public bool ShowInfoIcon
    {
      get 
      {
        return mShowInfoIcon;
      }
      set
      {
        if (mShowInfoIcon != value)
        { 
          mShowInfoIcon = value;
          Invalidate();
        }
      }
    }

    /// <summary>
    /// Gets or sets the title of the <see cref="Panel"/>.
    /// </summary>
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [Description("Gets or sets the title of the panel.")]
    public override string Text
    {
      get
      {
        return base.Text;
      }
      set
      {
        if (base.Text != value)
        {
          base.Text = value;
          Invalidate();
        }
      }
    }

    /// <summary>
    /// Gets or sets the info Icon.
    /// </summary>
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [Description("Gets or sets the info Icon.")]
    [DefaultValue(null)]
    public Image InfoIcon
    {
      get
      {
        return mInfoImage;
      }
      set
      {
        if (mInfoImage != value)
        {
          mInfoImage = value;
          Invalidate();
        }
      }
    }

    /// <summary>
    /// Gets or sets the <see cref="Padding"/> for the text area.
    /// </summary>
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [Description("Gets or sets the padding for the text area.")]
    public Padding TextPadding
    {
      get
      {
        return mTextPadding;
      }
      set
      {
        if (mTextPadding != value)
        {
          mTextPadding = value;
          Invalidate();
        }
      }
    }

    /// <summary>
    /// Gets or sets the title of the <see cref="Panel"/>.
    /// </summary>
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [Description("Gets or sets the title of the panel.")]
    public string Title
    {
      get
      {
        return mTitle;
      }
      set
      {
        if (mTitle != value)
        {
          mTitle = value;
          Invalidate();
        }
      }
    }

    /// <summary>
    /// Gets or sets the draw title flag.
    /// </summary>
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [Description("Gets or sets the draw title flag.")]
    [DefaultValue(true)]
    public bool ShowTitle
    {
      get
      {
        return mShowTitle;
      }
      set
      {
        if (mShowTitle != value)
        {
          mShowTitle = value;
          Invalidate();
        }
      }
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Reloads the current DPI-Settings of the system.
    /// </summary>
    /// <param name="ctrl">The <see cref="Control"/> to use the <see cref="Graphics"/> object from.</param>
    protected static void ReloadDpiSettings(Control ctrl)
    {
      if (ctrl != null)
      {
        using (Graphics grfx = ctrl.CreateGraphics())
        {
          mDpiSize = new SizeF(grfx.DpiX, grfx.DpiY);
        }
      }
    }

    /// <summary>
    /// Rescales the given value by the currently used DPI-Settings.
    /// </summary>
    /// <param name="value">The value to rescale.</param>
    /// <returns>The rescaled value.</returns>
    protected static int RescaleByDpiY(int value)
    {
      return (int)((value / DEFAULT_DPI_Y) * mDpiSize.Height);
    }

    /// <summary>
    /// Rescales the given value by the currently used DPI-Settings.
    /// </summary>
    /// <param name="value">The value to rescale.</param>
    /// <returns>The rescaled value.</returns>
    protected static int RescaleByDpiX(int value)
    {
      return (int)((value / DEFAULT_DPI_X) * mDpiSize.Width);
    }

    #endregion

    #region Overridden Methods

    /// <summary>
    /// Handles the OnPaint event of the <see cref="InfoPanel"/>.
    /// </summary>
    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);

      if (mShowBorder)
      {
        using (Pen borderPen = new Pen(mBorderColor))
        {
          e.Graphics.DrawRectangle(borderPen, new Rectangle(0, 0,
            ClientRectangle.Width - 1, ClientRectangle.Height - 1));
        }
      }

      if (mShowInfoIcon && mInfoImage != null)
      {
        Rectangle imageRect = new Rectangle(0, 0, 
          mInfoImage.Width, mInfoImage.Height);

        if (mShowBorder)
        {
          imageRect.Offset(
            RescaleByDpiX(4), 
            RescaleByDpiY(6));
        }

        e.Graphics.DrawImage(mInfoImage, imageRect, new Rectangle(
          0, 0, imageRect.Width, imageRect.Height), GraphicsUnit.Pixel);
      }

      int textOffsetLeft = (mShowBorder ? RescaleByDpiX(6) : 
        RescaleByDpiX(3)) + (mInfoImage != null ? mShowInfoIcon ? mInfoImage.Width : 0 : 0);
      
      int textOffsetTop = mShowTitle ? 
        RescaleByDpiX(18) : 0;

      if (mShowTitle && !string.IsNullOrEmpty(mTitle))
      {
        Rectangle titleRect = new Rectangle(
          textOffsetLeft + mTextPadding.Left, 
          mTextPadding.Top + RescaleByDpiY(3),
          ClientRectangle.Width - (RescaleByDpiX(6) + mTextPadding.Right + mTextPadding.Left), 
          RescaleByDpiY(20));

        using (Font boldFont = new Font(Font, FontStyle.Bold))
        {
          TextRenderer.DrawText(
              e.Graphics
            , mTitle
            , boldFont
            , titleRect
            , ForeColor
            , BackColor
            ,   TextFormatFlags.TextBoxControl 
              | TextFormatFlags.WordBreak 
              | TextFormatFlags.EndEllipsis 
              | TextFormatFlags.ExpandTabs);
        }
      }

      if (!string.IsNullOrEmpty(Text))
      {
        Rectangle textRect = new Rectangle(textOffsetLeft + mTextPadding.Left, 
          mTextPadding.Top + textOffsetTop,
          ClientRectangle.Width - (textOffsetLeft + mTextPadding.Right + mTextPadding.Left), 
          ClientRectangle.Height - (textOffsetTop + mTextPadding.Top + mTextPadding.Bottom));

        if (textRect.Width > 0 && textRect.Height > 0)
        {
          TextRenderer.DrawText(
              e.Graphics
            , Text, Font
            , textRect
            , ForeColor
            , BackColor
            ,   TextFormatFlags.TextBoxControl 
              | TextFormatFlags.WordBreak 
              | TextFormatFlags.EndEllipsis 
              | TextFormatFlags.ExpandTabs);
        }
      }
    }

    /// <summary>
    /// Calculates the scroll offset to the specified child control. 
    /// </summary>
    /// <returns>The upper-left hand <see cref="T:System.Drawing.Point"/> of the display area relative to the client area required to scroll the control into view.</returns>
    /// <param name="activeControl">The child control to scroll into view. </param>
    protected override Point ScrollToControl(Control activeControl)
    {
      return AutoScrollPosition;
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Creates a new <see cref="InfoPanel"/>.
    /// </summary>
    public InfoPanel()
    {
      SetStyle(ControlStyles.AllPaintingInWmPaint,  true);
      SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
      SetStyle(ControlStyles.ResizeRedraw,          true);
      SetStyle(ControlStyles.UserPaint,             true);

      BackColor = SystemColors.Info;

      ReloadDpiSettings(this);
    }

    #endregion
  }
}
