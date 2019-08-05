#region Copyright © 2015 Couchcoding

// File:    EventLogDetailsControl.cs
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
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using Couchcoding.Logbert.Helper;
using Couchcoding.Logbert.Theme.Palettes;
using Couchcoding.Logbert.Interfaces;
using Couchcoding.Logbert.Logging;
using Couchcoding.Logbert.Properties;
using Couchcoding.Logbert.Theme.Interfaces;
using Couchcoding.Logbert.Theme;
using Couchcoding.Logbert.Theme.Themes;

namespace Couchcoding.Logbert.Controls
{
  /// <summary>
  /// Implements a <see cref="UserControl"/> to display details of a selected <see cref="LogMessage"/>.
  /// </summary>
  public partial class EventLogDetailsControl : UserControl, ILogPresenter, IThemable
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
    Font mBoldCaptionFont;

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets the count of currently displayed <see cref=LogMessage"/>s.
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
      StringBuilder sBuilder = new StringBuilder();

      sBuilder.AppendLine("Number:             " + txtDataNumber.Text);
      sBuilder.AppendLine("Level:              " + txtDataLevel.Text);
      sBuilder.AppendLine("Local Machine Time: " + txtDataDateAndTime.Text);
      sBuilder.AppendLine("Logger:             " + txtDataLogger.Text);
      sBuilder.AppendLine("Category:           " + txtDataCategory.Text);
      sBuilder.AppendLine("Username:           " + txtDataUsername.Text);
      sBuilder.AppendLine("InstanceId:         " + txtDataInstaceId.Text);
      sBuilder.AppendLine("Message:            " + txtDataMessage.Text);

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
    /// Handles the Click event of the copy level details <see cref="PictureBox"/>.
    /// <para>
    /// Copies the level details to the <see cref="Clipboard"/>.
    /// </para>
    /// </summary>
    private void PbxCopyLevelClick(object sender, EventArgs e)
    {
      pbxCopyLevel.CopyToClipboard(txtDataLevel.Text);
    }

    /// <summary>
    /// Handles the Click event of the copy date and time details <see cref="PictureBox"/>.
    /// <para>
    /// Copies the date and time details to the <see cref="Clipboard"/>.
    /// </para>
    /// </summary>
    private void PbxCopyDateTimeClick(object sender, EventArgs e)
    {
      pbxCopyDateAndTime.CopyToClipboard(txtDataDateAndTime.Text);
    }

    /// <summary>
    /// Handles the Click event of the copy logger details <see cref="PictureBox"/>.
    /// <para>
    /// Copies the logger details to the <see cref="Clipboard"/>.
    /// </para>
    /// </summary>
    private void PbxCopyLoggerClick(object sender, EventArgs e)
    {
      pbxCopyLogger.CopyToClipboard(txtDataLogger.Text);
    }

    /// <summary>
    /// Handles the Click event of the copy category details <see cref="PictureBox"/>.
    /// <para>
    /// Copies the category details to the <see cref="Clipboard"/>.
    /// </para>
    /// </summary>
    private void PbxCopyCategoryClick(object sender, EventArgs e)
    {
      pbxCopyCategory.CopyToClipboard(txtDataCategory.Text);
    }

    /// <summary>
    /// Handles the Click event of the copy username details <see cref="PictureBox"/>.
    /// <para>
    /// Copies the username details to the <see cref="Clipboard"/>.
    /// </para>
    /// </summary>
    private void PbxCopyUsernameClick(object sender, EventArgs e)
    {
      pbxCopyUsername.CopyToClipboard(txtDataUsername.Text);
    }

    /// <summary>
    /// Handles the Click event of the copy message details <see cref="PictureBox"/>.
    /// <para>
    /// Copies the message details to the <see cref="Clipboard"/>.
    /// </para>
    /// </summary>
    private void PbxCopyMessageClick(object sender, EventArgs e)
    {
      pbxCopyMessage.CopyToClipboard(txtDataMessage.Text);
    }

    /// <summary>
    /// Handles the Click event of the copy instance ID details <see cref="PictureBox"/>.
    /// <para>
    /// Copies the instance ID details to the <see cref="Clipboard"/>.
    /// </para>
    /// </summary>
    private void pbxCopyInstanceId_Click(object sender, EventArgs e)
    {
      pbxCopyInstanceId.CopyToClipboard(txtDataInstaceId.Text);
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
    /// Handles the size changed event of the <see cref="Control"/>.
    /// </summary>
    protected override void OnSizeChanged(EventArgs e)
    {
      base.OnSizeChanged(e);

      txtDataCategory.AdjustHeightToContent();
      txtDataMessage.AdjustHeightToContent();
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
      LogMessageEventlog logMessage = message as LogMessageEventlog;

      try
      {
        this.SuspendDrawing();

        if (logMessage != null)
        {
          txtDataNumber.Text      = logMessage.Index.ToString();
          txtDataLevel.Text       = logMessage.Level.ToString();
          txtDataDateAndTime.Text = logMessage.Timestamp.Add(logMessage.TimeShiftOffset).ToString(Settings.Default.TimestampFormat);
          txtDataLogger.Text      = logMessage.Logger;
          txtDataCategory.Text    = logMessage.Category;
          txtDataUsername.Text    = logMessage.Username;
          txtDataInstaceId.Text   = logMessage.InstanceId.ToString();

          if (logMessage.TimeShiftOffset.Milliseconds != 0)
          {
            txtDataDateAndTime.Text += string.Format(
                Resources.strLoggerDetailsCtrlOffset
              , logMessage.TimeShiftOffset.Milliseconds);
          }

          // Replace all known new line character combinations with the .net one.
          txtDataMessage.Text = Regex.Replace(
              logMessage.Message
            , @"\r(?!\n)|(?<!\r)\n"
            , Environment.NewLine);
        }
        else
        {
          txtDataNumber.Text      = message != null ? message.Index.ToString() : string.Empty;
          txtDataLevel.Text       = message != null ? message.Level.ToString() : string.Empty;
          txtDataDateAndTime.Text = string.Empty;
          txtDataLogger.Text      = message != null ? message.Logger : string.Empty;
          txtDataCategory.Text    = string.Empty;
          txtDataUsername.Text    = string.Empty;
          txtDataInstaceId.Text   = string.Empty;
          txtDataMessage.Text     = message != null ? message.Message.Trim() : string.Empty;
        }

        pbxCopyNumber.Visible      = !string.IsNullOrEmpty(txtDataNumber.Text);
        pbxCopyLevel.Visible       = !string.IsNullOrEmpty(txtDataLevel.Text);
        pbxCopyLogger.Visible      = !string.IsNullOrEmpty(txtDataLogger.Text);
        pbxCopyDateAndTime.Visible = !string.IsNullOrEmpty(txtDataDateAndTime.Text);
        pbxCopyCategory.Visible    = !string.IsNullOrEmpty(txtDataCategory.Text);
        pbxCopyUsername.Visible    = !string.IsNullOrEmpty(txtDataUsername.Text);
        pbxCopyInstanceId.Visible  = !string.IsNullOrEmpty(txtDataInstaceId.Text);
        pbxCopyMessage.Visible     = !string.IsNullOrEmpty(txtDataMessage.Text);
      }
      finally
      {
        txtDataCategory.AdjustHeightToContent();
        txtDataMessage.AdjustHeightToContent();

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

          lblCaptionNumber.Font      = mBoldCaptionFont;
          lblCaptionLevel.Font       = mBoldCaptionFont;
          lblCaptionLogger.Font      = mBoldCaptionFont;
          lblCaptionDateAndTime.Font = mBoldCaptionFont;
          lblCaptionCategory.Font    = mBoldCaptionFont;
          lblCaptionUsername.Font    = mBoldCaptionFont;
          lblCaptionInstanceId.Font  = mBoldCaptionFont;
          lblCaptionMessage.Font     = mBoldCaptionFont;

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

          lblCaptionNumber.Font      = mBoldCaptionFont;
          lblCaptionLevel.Font       = mBoldCaptionFont;
          lblCaptionLogger.Font      = mBoldCaptionFont;
          lblCaptionDateAndTime.Font = mBoldCaptionFont;
          lblCaptionCategory.Font    = mBoldCaptionFont;
          lblCaptionUsername.Font    = mBoldCaptionFont;
          lblCaptionInstanceId.Font  = mBoldCaptionFont;
          lblCaptionMessage.Font     = mBoldCaptionFont;

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

      pbxCopyNumber.Image      = theme.Resources.Images["FrmScriptTbCopy"];
      pbxCopyLevel.Image       = theme.Resources.Images["FrmScriptTbCopy"];
      pbxCopyLogger.Image      = theme.Resources.Images["FrmScriptTbCopy"];
      pbxCopyDateAndTime.Image = theme.Resources.Images["FrmScriptTbCopy"];
      pbxCopyCategory.Image    = theme.Resources.Images["FrmScriptTbCopy"];
      pbxCopyUsername.Image    = theme.Resources.Images["FrmScriptTbCopy"];
      pbxCopyInstanceId.Image  = theme.Resources.Images["FrmScriptTbCopy"];
      pbxCopyMessage.Image     = theme.Resources.Images["FrmScriptTbCopy"];

      LogMessagePanel.BackColor  = theme.ColorPalette.ContentBackground;
      LogMessagePanel.ForeColor  = theme.ColorPalette.ContentForeground;
      
      txtDataNumber.BackColor      = theme.ColorPalette.ContentBackground;
      txtDataNumber.ForeColor      = theme.ColorPalette.ContentForeground;
      txtDataLevel.BackColor       = theme.ColorPalette.ContentBackground;
      txtDataLevel.ForeColor       = theme.ColorPalette.ContentForeground;
      txtDataDateAndTime.BackColor = theme.ColorPalette.ContentBackground;
      txtDataDateAndTime.ForeColor = theme.ColorPalette.ContentForeground;
      txtDataLogger.BackColor      = theme.ColorPalette.ContentBackground;
      txtDataLogger.ForeColor      = theme.ColorPalette.ContentForeground;
      txtDataCategory.BackColor    = theme.ColorPalette.ContentBackground;
      txtDataCategory.ForeColor    = theme.ColorPalette.ContentForeground;
      txtDataUsername.BackColor    = theme.ColorPalette.ContentBackground;
      txtDataUsername.ForeColor    = theme.ColorPalette.ContentForeground;
      txtDataMessage.BackColor     = theme.ColorPalette.ContentBackground;
      txtDataMessage.ForeColor     = theme.ColorPalette.ContentForeground;
      txtDataInstaceId.BackColor   = theme.ColorPalette.ContentBackground;
      txtDataInstaceId.ForeColor   = theme.ColorPalette.ContentForeground;
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Creates anew instance of the <see cref="SyslogDetailsControl"/> <see cref="Control"/>.
    /// </summary>
    public EventLogDetailsControl()
    {
      InitializeComponent();

      // Apply the current application theme to the control.
      ThemeManager.ApplyTo(this);

      mBoldCaptionFont = FontCache.GetFontFromIdentifier(
          Font.Name
        , Font.Size
        , FontStyle.Bold);

      lblCaptionNumber.Font      = mBoldCaptionFont;
      lblCaptionLevel.Font       = mBoldCaptionFont;
      lblCaptionLogger.Font      = mBoldCaptionFont;
      lblCaptionDateAndTime.Font = mBoldCaptionFont;
      lblCaptionCategory.Font    = mBoldCaptionFont;
      lblCaptionUsername.Font    = mBoldCaptionFont;
      lblCaptionInstanceId.Font  = mBoldCaptionFont;
      lblCaptionMessage.Font     = mBoldCaptionFont;
    }

    #endregion
  }
}
