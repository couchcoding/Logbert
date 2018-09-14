#region Copyright © 2017 Couchcoding

// File:    CustomDetailsControl.cs
// Package: Logbert
// Project: Logbert
// 
// The MIT License (MIT)
// 
// Copyright (c) 2017 Couchcoding
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
using System.Text;
using System.Windows.Forms;

using Couchcoding.Logbert.Helper;
using Couchcoding.Logbert.Interfaces;
using Couchcoding.Logbert.Logging;
using Couchcoding.Logbert.Receiver.CustomReceiver;
using Couchcoding.Logbert.Gui.Controls;
using Couchcoding.Logbert.Properties;
using Couchcoding.Logbert.Theme.Palettes;
using Couchcoding.Logbert.Theme.Interfaces;
using Couchcoding.Logbert.Theme;
using Couchcoding.Logbert.Theme.Themes;

namespace Couchcoding.Logbert.Controls
{
  /// <summary>
  /// Implements a <see cref="UserControl"/> to display details of a selected <see cref="LogMessage"/>.
  /// </summary>
  public partial class CustomDetailsControl : UserControl, ILogPresenter, IThemable
  {
    #region Private Consts

    /// <summary>
    /// Defines the minimum font size (em) for the <see cref="LogMessage"/> list.
    /// </summary>
    private const int MIN_ZOOM_LEVEL = 6;

    /// <summary>
    /// Defines the maximum font size (em) for the <see cref="LogMessage"/> list.
    /// </summary>
    private const int MAX_ZOOM_LEVEL = 60;

    #endregion

    #region Private Fields

    /// <summary>
    /// The bold <see cref="Font"/> for the caption area.
    /// </summary>
    private Font mBoldCaptionFont;

    /// <summary>
    /// The linked <see cref="Columnizer"/> instance.
    /// </summary>
    private readonly Columnizer mColumnizer;

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets the count of currently displayed <see cref="LogMessage"/>s.
    /// </summary>
    public int DisplayedLogMessagesCount
    {
      get
      {
        return 0;
      }
    }

    /// <summary>
    /// Gets or sets the font of the text displayed by the control.
    /// </summary>
    /// <returns>The <see cref="T:System.Drawing.Font"/> to apply to the text displayed by the control. The default is the value of the <see cref="P:System.Windows.Forms.Control.DefaultFont"/> property.</returns>
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

    #endregion

    #region Private Methods

    /// <summary>
    /// Handles the Click event of the zoom in <see cref="ToolStripButton"/>.
    /// </summary>
    private void TsbZoomInClick(object sender, EventArgs e)
    {
      bool futherZoomInPossible = ZoomIn();

      tsbZoomIn.Enabled  = futherZoomInPossible;
      tsbZoomOut.Enabled = true;
    }

    /// <summary>
    /// Handles the Click event of the zoom out <see cref="ToolStripButton"/>.
    /// </summary>
    private void TsbZoomOutClick(object sender, EventArgs e)
    {
      bool futherZoomOutPossible = ZoomOut();

      tsbZoomIn.Enabled  = true;
      tsbZoomOut.Enabled = futherZoomOutPossible;
    }

    /// <summary>
    /// Handles the Click event of the copy content <see cref="ToolStripButton"/>.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TsbCopyClick(object sender, EventArgs e)
    {
      Dictionary<string, string> outputValues = new Dictionary<string, string>
      {
        { "Number", txtDataNumber.Text }
      };

      // Initialize with the "Number" string.
      int longestCaptionLength = 6;

      foreach (Control ctrl in tblLogMessage.Controls)
      {
        Label lblCaption = ctrl as Label;

        if (lblCaption == null || !(lblCaption.Tag is LogColumn))
        {
          // Ignore not matching textboxes.
          continue;
        }

        if (lblCaption.Text.Length > longestCaptionLength)
        {
          longestCaptionLength = lblCaption.Text.Length;
        }

        foreach (Control txtCtrl in tblLogMessage.Controls)
        {
          TextBox txtValue = txtCtrl as TextBox;

          if (txtValue == null || !Equals(txtValue.Tag, lblCaption.Tag))
          {
            continue;
          }

          outputValues.Add(lblCaption.Text, txtCtrl.Text);
          break;
        }
      }

      StringBuilder sBuilder = new StringBuilder();

      foreach (KeyValuePair<string, string> output in outputValues)
      {
        sBuilder.AppendLine(string.Format(
            "{0," + ((longestCaptionLength + 1) * -1) + "} {1}"
          , output.Key + ":"
          , output.Value));
      }

      this.CopyToClipboard(sBuilder.ToString());
    }

    /// <summary>
    /// Handles the CellPaint event of the <see cref="TableLayoutPanel"/>.
    /// </summary>
    private void TblLogMessageCellPaint(object sender, TableLayoutCellPaintEventArgs e)
    {
      if (e.Row > 0)
      {
        e.Graphics.DrawLine(
            GdiCache.GetPenFromColor(ThemeManager.CurrentApplicationTheme.ColorPalette.DividerColor)
          , new Point(e.CellBounds.Left,  e.CellBounds.Top)
          , new Point(e.CellBounds.Right, e.CellBounds.Top));
      }
    }

    /// <summary>
    /// Handles the Click event of the copy number details <see cref="PictureBox"/>.
    /// <para>
    /// Copies the number details to the <see cref="Clipboard"/>.
    /// </para>
    /// </summary>
    private void PbxCopyNumberClick(object sender, EventArgs e)
    {
      pbxCopyNumber.CopyToClipboard(txtDataNumber.Text);
    }

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();

        if (mBoldCaptionFont != null)
        {
          mBoldCaptionFont.Dispose();
        }
      }

      base.Dispose(disposing);
    }

    /// <summary>
    /// Adds a new log message row to the message window.
    /// </summary>
    /// <param name="column">The <see cref="LogColumn"/> that should be represented by the new row.</param>
    private void AddLogMsgRowItem(LogColumn column)
    {
      RowStyle baseStyle = tblLogMessage.RowStyles[0];

      tblLogMessage.RowCount++;

      tblLogMessage.RowStyles.Add(new RowStyle(
          baseStyle.SizeType
        , baseStyle.Height));

      tblLogMessage.Controls.Add(new Label()
      {
        Text     = column.Name,
        AutoSize = true,
        Margin   = new Padding(3, 1, 10, 1),
        Padding  = new Padding(4),
        Tag      = column,
        Font     = mBoldCaptionFont

      }, 0, tblLogMessage.RowCount - 1);

      TextBox txtValue = new TextBox()
      {
        BorderStyle = BorderStyle.None,
        ReadOnly    = true,
        Dock        = DockStyle.Fill,
        Margin      = new Padding(3, 4, 3, 1),
        BackColor   = ThemeManager.CurrentApplicationTheme.ColorPalette.ContentBackground,
        ForeColor   = ThemeManager.CurrentApplicationTheme.ColorPalette.ContentForeground,
        Tag         = column
      };

      tblLogMessage.Controls.Add(
          txtValue
        , 1
        , tblLogMessage.RowCount - 1);

      PictureBoxEx pbxCopyButton = new PictureBoxEx()
      {
        BackgroundImageLayout = ImageLayout.Center,
        Cursor                = Cursors.Hand,
        Image                 = ThemeManager.CurrentApplicationTheme.Resources.Images["FrmScriptTbCopy"],
        Margin                = new Padding(2, 2, 1, 1),
        Size                  = new Size(17, 18),
        Visible               = false
      };

      pbxCopyButton.Click += (sender, e) => 
      pbxCopyButton.CopyToClipboard(txtValue.Text);

      tltTip.SetToolTip(pbxCopyButton, string.Format(
          Resources.strMessageDetailsCopyButtonTooltip
        , column.Name));

      tblLogMessage.Controls.Add(
          pbxCopyButton
        , 2
        , tblLogMessage.RowCount - 1);
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Updates the visible <see cref="LogMessage"/>s.
    /// </summary>
    /// <param name="messages">The list of <see cref="LogMessage"/>s to display.</param>
    /// <param name="delta">The count of new <see cref="LogMessage"/>s.</param>
    public void LogMessagesChanged(List<LogMessage> messages, int delta)
    {
      // Nothing to do here.
    }

    /// <summary>
    /// Selects the <see cref="LogMessage"/> on the given <paramref name="index"/>.
    /// </summary>
    /// <param name="index">The index of the <see cref="LogMessage"/> to select.</param>
    public bool SelectLogMessage(int index)
    {
      // Nothing to do here.
      return true;
    }
    
    /// <summary>
    /// Updates the <see cref="LogLevel"/> to display.
    /// </summary>
    /// <param name="level">The new <see cref="LogLevel"/> to display.</param>
    public void LogLevelChanged(LogLevel level)
    {
      // Nothing to do here.
    }

    /// <summary>
    /// Selects the given <paramref name="message"/>.
    /// </summary>
    /// <param name="message">The <see cref="LogMessage"/> o select</param>
    public bool SelectLogMessage(LogMessage message)
    {
      LogMessageCustom logMessage = message as LogMessageCustom;

      try
      {
        this.SuspendDrawing();

        if (logMessage != null)
        {
          txtDataNumber.Text = logMessage.Index.ToString();

          foreach (Control ctrl in tblLogMessage.Controls)
          {
            TextBox txtBox = ctrl as TextBox;

            if (txtBox == null || !(txtBox.Tag is LogColumn))
            {
              // Ignore not matching textboxes.
              continue;
            }

            txtBox.Text = logMessage.GetValueForColumn(mColumnizer.Columns.IndexOf((LogColumn)txtBox.Tag) + 2).ToString();
          }
        }
        else
        {
          txtDataNumber.Text  = message != null 
            ? message.Index.ToString() 
            : string.Empty;

          foreach (Control ctrl in tblLogMessage.Controls)
          {
            TextBox txtBox = ctrl as TextBox;

            if (txtBox == null || !(txtBox.Tag is LogColumn))
            {
              // Ignore not matching textboxes.
              continue;
            }

            txtBox.Text = string.Empty;
          }
        }

        pbxCopyNumber.Visible = !string.IsNullOrEmpty(txtDataNumber.Text);
      }
      finally
      {
        this.ResumeDrawing();
      }

      return true;
    }

    /// <summary>
    /// Clears all shown <see cref="LogMessage"/>s.
    /// </summary>
    public void ClearAll()
    {
      SelectLogMessage(null);
    }

    /// <summary>
    /// Increases the size of the <see cref="ILogPresenter"/> content.
    /// </summary>
    /// <returns><c>True</c> if further increasing is possible, otherwise <c>false</c>.</returns>
    public bool ZoomIn()
    {
      if (tblLogMessage.Font.Size < MAX_ZOOM_LEVEL)
      {
        try
        {
          this.SuspendDrawing();

          tblLogMessage.Font = FontCache.GetFontFromIdentifier(
              Font.Name
            , tblLogMessage.Font.Size + 1
            , FontStyle.Regular);

          mBoldCaptionFont = FontCache.GetFontFromIdentifier(
              Font.Name
            , mBoldCaptionFont.Size + 1
            , FontStyle.Bold);

          lblCaptionNumber.Font = mBoldCaptionFont;

          foreach (Control ctrl in tblLogMessage.Controls)
          {
            Label lblCaption = ctrl as Label;

            if (lblCaption == null || !(lblCaption.Tag is LogColumn))
            {
              // Ignore not matching textboxes.
              continue;
            }

            lblCaption.Font = mBoldCaptionFont;
          }

          return tblLogMessage.Font.Size < MAX_ZOOM_LEVEL;
        }
        finally
        {
          this.ResumeDrawing();
        }
      }

      return false;
    }

    /// <summary>
    /// Decreases the size of the <see cref="ILogPresenter"/> content.
    /// </summary>
    /// <returns><c>True</c> if further decreasing is possible, otherwise <c>false</c>.</returns>
    public bool ZoomOut()
    {
      if (tblLogMessage.Font.Size > MIN_ZOOM_LEVEL)
      {
        try
        {
          this.SuspendDrawing();

          tblLogMessage.Font = FontCache.GetFontFromIdentifier(
              Font.Name
            , tblLogMessage.Font.Size - 1
            , FontStyle.Regular);

          mBoldCaptionFont = FontCache.GetFontFromIdentifier(
              Font.Name
            , mBoldCaptionFont.Size - 1
            , FontStyle.Bold);

          lblCaptionNumber.Font = mBoldCaptionFont;

          foreach (Control ctrl in tblLogMessage.Controls)
          {
            Label lblCaption = ctrl as Label;

            if (lblCaption == null || !(lblCaption.Tag is LogColumn))
            {
              // Ignore not matching textboxes.
              continue;
            }

            lblCaption.Font = mBoldCaptionFont;
          }

          return tblLogMessage.Font.Size > MIN_ZOOM_LEVEL;
        }
        finally
        {
          this.ResumeDrawing();
        }
      }

      return false;
    }

    /// <summary>
    /// Applies the current theme to the <see cref="Control"/>.
    /// </summary>
    /// <param name="theme">The <see cref="BaseTheme"/> instance to apply.</param>
    public void ApplyTheme(BaseTheme theme)
    {
      tsbZoomIn.Image  = theme.Resources.Images["FrmMainTbZoomIn"];
      tsbZoomOut.Image = theme.Resources.Images["FrmMainTbZoomOut"];
      tsbCopy.Image    = theme.Resources.Images["FrmScriptTbCopy"];

      LogMessagePanel.BackColor  = theme.ColorPalette.ContentBackground;
      LogMessagePanel.ForeColor  = theme.ColorPalette.ContentForeground;

      foreach (Control ctrl in tblLogMessage.Controls)
      {
        if (ctrl is TextBox textBoxControl)
        {
          textBoxControl.BackColor = theme.ColorPalette.ContentBackground;
          textBoxControl.ForeColor = theme.ColorPalette.ContentForeground;
        }
      }
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Creates anew instance of the <see cref="CustomDetailsControl"/> <see cref="Control"/>.
    /// </summary>
    public CustomDetailsControl(Columnizer columnizer)
    {
      InitializeComponent();

      mColumnizer      = columnizer;
      mBoldCaptionFont = FontCache.GetFontFromIdentifier(
          Font.Name
        , Font.Size
        , FontStyle.Bold);

      lblCaptionNumber.Font = mBoldCaptionFont;

      foreach (LogColumn column in columnizer.Columns)
      {
        AddLogMsgRowItem(column);
      }

      // Apply the current application theme to the control.
      ThemeManager.ApplyTo(this);
    }

    #endregion
  }
}
