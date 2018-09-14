#region Copyright © 2015 Couchcoding

// File:    DialogForm.cs
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
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Couchcoding.Logbert.Gui.Dialogs
{
  /// <summary>
  /// Implements a custom <see cref="Form"/> with smarter user interface.
  /// </summary>
  public class DialogForm : Form
  {
    #region Private Consts

    /// <summary>
    /// Defines the height of the button area within the dialog.
    /// </summary>
    protected const int BUTTON_AREA_HEIGHT = 40;

    /// <summary>
    /// Defines the height of the header area within the dialog.
    /// </summary>
    protected const int HEADER_AREA_HEIGHT = 60;

    #endregion

    #region Private Fields

    private bool   mShowHeaderArea         = true;
    private bool   mShowFooterArea         = true;
    private Color  mContentColor           = SystemColors.Control;
    private Color  mHeaderCaptionColor     = Color.Black;
    private Color  mHeaderDescriptionColor = Color.DimGray;
    private Color  mHeaderColor            = Color.White;
    private string mDialogMainCaption      = string.Empty;
    private string mDialogMainDescription  = string.Empty;
    private Image  mDialogImage;

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets or sets the font of the text displayed by the control.
    /// </summary>
    /// <returns>The <see cref="T:System.Drawing.Font"/> to apply to the text displayed by the control. The default is the value of the <see cref="P:System.Windows.Forms.Control.DefaultFont"/> property.</returns>
    [AmbientValue(null)]
    [Localizable(true)]
    public sealed override Font Font
    {
      get
      {
        return base.Font;
      }
      set
      {
        base.Font = value;
      }
    }

    /// <summary>
    /// Gets or sets the foreground color of the dialog header caption.
    /// </summary>
    [Browsable(true)]
    [DefaultValue(typeof(Color), "Black")]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [Category("Gui Appearance")]
    [Description("Gets or sets the foreground color of the dialog header caption.")]
    public Color HeaderCaptionColor
    {
      get
      {
        return mHeaderCaptionColor;
      }
      set
      {
        if (mHeaderCaptionColor != value)
        {
          mHeaderCaptionColor = value;
          Invalidate();
        }
      }
    }

    /// <summary>
    /// Gets or sets the foreground color of the dialog header text.
    /// </summary>
    [Browsable(true)]
    [DefaultValue(typeof(Color), "DimGray")]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [Category("Gui Appearance")]
    [Description("Gets or sets the foreground color of the dialog header description.")]
    public Color HeaderDescriptionColor
    {
      get
      {
        return mHeaderDescriptionColor;
      }
      set
      {
        if (mHeaderDescriptionColor != value)
        {
          mHeaderDescriptionColor = value;
          Invalidate();
        }
      }
    }

    /// <summary>
    /// Gets or sets the backgound <see cref="Color"/> of the dialog content area.
    /// </summary>
    [Browsable(true)]
    [DefaultValue(typeof(SystemColors), "Control")]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [Category("Gui Appearance")]
    [Description("Gets or sets the backgound color of the dialog content area.")]
    public Color ContentColor
    {
      get
      {
        return mContentColor;
      }
      set
      {
        if (mContentColor != value)
        {
          mContentColor = value;
          Invalidate();
        }
      }
    }

    /// <summary>
    /// Gets or sets the backcolor of the header area.
    /// </summary>
    [Browsable(true)]
    [DefaultValue(typeof(Color), "White")]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [Category("Gui Appearance")]
    [Description("Gets or sets the backcolor of the header area.")]
    public Color HeaderColor
    {
      get
      {
        return mHeaderColor;
      }
      set
      {
        if (mHeaderColor != value)
        {
          mHeaderColor = value;
          Invalidate();
        }
      }
    }

    /// <summary>
    /// Gets or sets the wizard or dialog header <see cref="Image"/>.
    /// </summary>
    [Browsable(true)]
    [DefaultValue(null)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [Category("Gui Appearance")]
    [Description("Gets or sets the wizard or dialog header image.")]
    public Image DialogImage
    {
      get
      {
        return mDialogImage;
      }
      set
      {
        if (mDialogImage != value)
        {
          mDialogImage = value;
          Invalidate();
        }
      }
    }

    /// <summary>
    /// Gets or sets the caption of the dialog.
    /// </summary>
    [Browsable(true)]
    [Localizable(true)]
    [DefaultValue("")]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [Category("Gui Appearance")]
    [Description("Gets or sets the caption of the dialog.")]
    public string DialogMainCaption
    {
      get
      {
        return mDialogMainCaption;
      }
      set
      {
        if (mDialogMainCaption != value)
        {
          mDialogMainCaption = value;
          Invalidate();
        }
      }
    }

    /// <summary>
    /// Gets or sets the description displayed in the header if dialog mode is used.
    /// </summary>
    [Browsable(true)]
    [Localizable(true)]
    [DefaultValue("")]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [Category("Gui Appearance")]
    [Description("Gets or sets the description displayed in the header if dialog mode is used.")]
    public string DialogMainDescription
    {
      get
      {
        return mDialogMainDescription;
      }
      set
      {
        if (mDialogMainDescription != value)
        {
          mDialogMainDescription = value;
          Invalidate();
        }
      }
    }

    /// <summary>
    /// Gets or sets the value if the header area of the dialog is shown.
    /// </summary>
    [Browsable(true)]
    [DefaultValue(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [Category("Gui Appearance")]
    [Description("Gets or sets the value if the header area of the dialog is shown.")]
    public bool ShowHeaderArea
    {
      get
      {
        return mShowHeaderArea;
      }
      set
      {
        if (mShowHeaderArea != value)
        {
          mShowHeaderArea = value;
          Invalidate();
          RecalculatePadding();
        }
      }
    }

    /// <summary>
    /// Gets or sets the value if the footer area of the dialog is shown.
    /// </summary>
    [Browsable(true)]
    [DefaultValue(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [Category("Gui Appearance")]
    [Description("Gets or sets the value if the footer area of the dialog is shown.")]
    public virtual bool ShowFooterArea
    {
      get
      {
        return mShowFooterArea;
      }
      set
      {
        if (mShowFooterArea != value)
        {
          mShowFooterArea = value;
          RecalculatePadding();
          Invalidate();
        }
      }
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Validates the dialog inputs before the dialog is closed.
    /// </summary>
    /// <param name="dlgResult">The current active <see cref="DialogResult"/>.</param>
    /// <returns><c>True</c> if all input is valid; otherwise <c>false</c>.</returns>
    protected virtual bool ValidateDialog(DialogResult dlgResult)
    {
      // By default everything is valid.
      return true;
    }

    /// <summary>
    /// Recalculates the Padding depending on the DPI setings.
    /// </summary>
    protected void RecalculatePadding()
    {
      Padding = new Padding(
          5
        , mShowHeaderArea ? HEADER_AREA_HEIGHT + 5 : 5
        , 5
        , 5);
    }

    /// <summary>
    /// Draws the dialog as a default MSR dialog.
    /// </summary>
    /// <param name="grfx">The <see cref="Graphics"/> context to draw on.</param>
    protected virtual void DrawDialogBackground(Graphics grfx)
    {
      if (mShowHeaderArea && Width > 0 && Height > 0)
      {
        int headerHeight = DpiHelper.RescaleByDpiY(HEADER_AREA_HEIGHT);

        if (mHeaderColor != Color.Transparent && mHeaderColor != mContentColor)
        {
          using (Brush headerBrush = new SolidBrush(mHeaderColor))
          {
            grfx.FillRectangle(headerBrush, new Rectangle(
              0
              , 0
              , ClientRectangle.Width
              , headerHeight));
          }

          Rectangle shadowRect = new Rectangle(0, headerHeight - 2, Width, 2);

          if (shadowRect.Width > 0 && shadowRect.Height > 0)
          {
            using (LinearGradientBrush shadowBrush = new LinearGradientBrush(shadowRect, SystemColors.ControlDark, ContentColor, LinearGradientMode.Vertical))
            {
              // Set the wrap mode to tile flip x to fix flickering on resize.
              shadowBrush.WrapMode = WrapMode.TileFlipX;

              grfx.FillRectangle(shadowBrush, shadowRect);
            }
          }
        }

        if (mDialogImage != null)
        {
          grfx.DrawImage(mDialogImage
            , new Rectangle(
                ClientRectangle.Width - mDialogImage.Width
              , (headerHeight - mDialogImage.Height) >> 1
              , mDialogImage.Width
              , mDialogImage.Height)
            , new Rectangle(
                0
              , 0
              , mDialogImage.Width
              , mDialogImage.Height)
            , GraphicsUnit.Pixel);
        }

        if (!string.IsNullOrEmpty(mDialogMainCaption))
        {
          using (Font captionFont = new Font(Font.Name, 10.25F, FontStyle.Regular, GraphicsUnit.Point))
          {
            using (Brush captionBrush = new SolidBrush(mHeaderCaptionColor))
            {
              grfx.DrawString(
                  mDialogMainCaption
                , captionFont
                , captionBrush
                , new Point(
                    DpiHelper.RescaleByDpiY(12)
                  , DpiHelper.RescaleByDpiY(8)));
            }
          }
        }

        if (!string.IsNullOrEmpty(mDialogMainDescription))
        {
          using (Brush textBrush = new SolidBrush(mHeaderDescriptionColor))
          {
            using (StringFormat sFormat = new StringFormat())
            {
              int imgSpaceLeft = mDialogImage != null ? mDialogImage.Width : 0;

              grfx.DrawString(
                  mDialogMainDescription
                , Font
                , textBrush
                , new RectangleF(
                    DpiHelper.RescaleByDpiY(24)
                  , DpiHelper.RescaleByDpiY(30)
                  , ClientRectangle.Width - imgSpaceLeft - DpiHelper.RescaleByDpiX(30)
                  , headerHeight - DpiHelper.RescaleByDpiY(22))
                , sFormat);
            }
          }
        }
      }
    }

    /// <summary>
    /// Handles the OnPait event of the <see cref="DialogForm"/> dialog.
    /// </summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs"/> that contains the event data.</param>
    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);

      int buttonHeight = mShowFooterArea ? DpiHelper.RescaleByDpiY(BUTTON_AREA_HEIGHT) : 0;

      using (Brush contentBrush = new SolidBrush(ContentColor))
      {
        e.Graphics.FillRectangle(
            contentBrush
          , new Rectangle(0, 0, ClientRectangle.Width, ClientRectangle.Height - buttonHeight));
      }

      // Set the TextRenderingHint to clear type.
      e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

      // Draw the dialog as a default dialog.
      DrawDialogBackground(e.Graphics);
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Form.Closing"/> event.
    /// </summary>
    /// <param name="e">A <see cref="T:System.ComponentModel.CancelEventArgs"/> that contains the event data. </param>
    protected override void OnClosing(CancelEventArgs e)
    {
      // Prevent the dialog from closing if at least one dialog input is invalid.
      e.Cancel = !ValidateDialog(DialogResult);

      base.OnClosing(e);

      if (Owner != null)
      {
        // Focus the owning window.
        Owner.Activate();
      }
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Creates a new instance of the <see cref="DialogForm"/> dialog.
    /// </summary>
    protected DialogForm()
    {
      SetStyle(ControlStyles.AllPaintingInWmPaint,  true);
      SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
      SetStyle(ControlStyles.ResizeRedraw,          true);

      Font                   = SystemFonts.MessageBoxFont;
      ContentColor           = SystemColors.Control;
      HeaderColor            = Color.White;
      HeaderDescriptionColor = Color.DimGray;

      MinimizeBox   = false;
      MaximizeBox   = false;
      ShowIcon      = false;
      ShowInTaskbar = false;
      StartPosition = FormStartPosition.CenterParent;

      RecalculatePadding();
    }

    #endregion
  }
}
