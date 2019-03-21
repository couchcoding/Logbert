#region Copyright © 2015 Couchcoding

// File:    FrmLogBookmarks.cs
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

using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Couchcoding.Logbert.Helper;
using Couchcoding.Logbert.Theme.Palettes;
using Couchcoding.Logbert.Interfaces;
using Couchcoding.Logbert.Logging;

using WeifenLuo.WinFormsUI.Docking;
using Couchcoding.Logbert.Theme.Interfaces;
using Couchcoding.Logbert.Theme;
using Couchcoding.Logbert.Theme.Themes;

namespace Couchcoding.Logbert.Dialogs.Docking
{
  /// <summary>
  /// Implements a <see cref="DockContent"/> to display and manage bookmarked <see cref="LogMessage"/>s.
  /// </summary>
  public partial class FrmLogBookmarks : DockContent, ILogPresenter, IBookmarkObserver, IThemable
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
    /// Holds the <see cref="IBookmarkProvider"/> instance that provides bookmarked <see cref="LogMessage"/>s.
    /// </summary>
    private readonly IBookmarkProvider mBookmarkProvider;

    /// <summary>
    /// The <see cref="Image"/> to use for bookmarks.
    /// </summary>
    private static readonly Image mBookmarkImage = ThemeManager.CurrentApplicationTheme.Resources.Images["FrmLogBookmark"];

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets the count of currently displayed <see cref=LogMessage"/>s.
    /// </summary>
    public int DisplayedLogMessagesCount => 0;

    #endregion

    #region Private Methods

    /// <summary>
    /// Handles the Click event of the remove bookmark <see cref="ToolStripButton"/>.
    /// </summary>
    private void TsbRemoveBookmarkClick(object sender, System.EventArgs e)
    {
      if (mBookmarkProvider != null && dgvBookmarks.SelectedRows.Count > 0)
      {
        List<LogMessage> selectedMessages = new List<LogMessage>();

        foreach (DataGridViewRow selectedRow in dgvBookmarks.SelectedRows)
        {
          if (dgvBookmarks.SelectedRows[0].Tag is LogMessage message)
          {
            selectedMessages.Add(message);
          }
        }

        mBookmarkProvider.RemoveBookmarks(selectedMessages);
      }
    }

    /// <summary>
    /// Handles the DoubleClick event of the bookmark <see cref="DataGridView"/>.
    /// </summary>
    private void DgvBookmarksCellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex >= dgvBookmarks.RowCount || e.RowIndex < 0)
      {
        return;
      }

      LogMessage selectedMessage = dgvBookmarks.Rows[e.RowIndex].Tag as LogMessage;

      if (selectedMessage != null && mBookmarkProvider != null)
      {
        mBookmarkProvider.SelectLogMessage(selectedMessage);
      }
    }

    /// <summary>
    /// Handles the SelectionChanged event of the bookmark <see cref="DataGridView"/>.
    /// </summary>
    private void DgvBookmarksSelectionChanged(object sender, System.EventArgs e)
    {
      tsbRemoveBookmark.Enabled   = dgvBookmarks.SelectedRows.Count > 0;
      tsbNextBookmark.Enabled     = dgvBookmarks.SelectedRows.Count > 0 && !dgvBookmarks.Rows[dgvBookmarks.RowCount - 1].Selected;
      tsbPreviousBookmark.Enabled = dgvBookmarks.SelectedRows.Count > 0 && !dgvBookmarks.Rows[0].Selected;
    }

    /// <summary>
    /// Handles the Click event of the goto previous bookmark <see cref="ToolStripItem"/>.
    /// </summary>
    private void TsbPreviousBookmarkClick(object sender, System.EventArgs e)
    {
      if (dgvBookmarks.SelectedRows.Count > 0 && dgvBookmarks.SelectedRows[0].Index != 0)
      {
        int newSelIndex = dgvBookmarks.SelectedRows[0].Index - 1;

        // Select the message within the bookmark window.
        dgvBookmarks.Rows[newSelIndex].Selected = true;

        // Select the message within the log window.
        LogMessage message =  dgvBookmarks.Rows[newSelIndex].Tag as LogMessage;
        
        if (message != null && mBookmarkProvider != null)
        {
          mBookmarkProvider.SelectLogMessage(message);
        }
      }
    }

    /// <summary>
    /// Handles the Click event of the goto next bookmark <see cref="ToolStripItem"/>.
    /// </summary>
    private void TsbNextBookmarkClick(object sender, System.EventArgs e)
    {
      if (dgvBookmarks.SelectedRows.Count > 0 && dgvBookmarks.SelectedRows[0].Index != dgvBookmarks.Rows.Count - 1)
      {
        int newSelIndex = dgvBookmarks.SelectedRows[0].Index + 1;

        // Select the message within the bookmark window.
        dgvBookmarks.Rows[newSelIndex].Selected = true;

        // Select the message within the log window.
        LogMessage message =  dgvBookmarks.Rows[newSelIndex].Tag as LogMessage;

        if (message != null && mBookmarkProvider != null)
        {
          mBookmarkProvider.SelectLogMessage(message);
        }
      }
    }

    /// <summary>
    /// Handles the Click event of the zoom in <see cref="ToolStripItem"/>.
    /// </summary>
    private void TsbZoomInClick(object sender, System.EventArgs e)
    {
      bool futherZoomInPossible = ZoomIn();

      tsbZoomIn.Enabled  = futherZoomInPossible;
      tsbZoomOut.Enabled = true;
    }

    /// <summary>
    /// Handles the Click event of the zoom out <see cref="ToolStripItem"/>.
    /// </summary>
    private void TsbZoomOutClick(object sender, System.EventArgs e)
    {
      bool futherZoomOuPossible = ZoomOut();

      tsbZoomOut.Enabled  = futherZoomOuPossible;
      tsbZoomIn.Enabled = true;
    }

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        components?.Dispose();

        if (mBookmarkProvider != null)
        {
          mBookmarkProvider.UnregisterBookmarkObserver(this);
        }
      }

      base.Dispose(disposing);
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Control.VisibleChanged"/> event.
    /// </summary>
    /// <param name="e">The <see cref="T:System.EventArgs"/> that contains the event data. </param>
    protected override void OnVisibleChanged(System.EventArgs e)
    {
      base.OnVisibleChanged(e);

      if (mBookmarkProvider != null)
      {
        SelectLogMessage(mBookmarkProvider.SelectedMessage);
      }
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Raises the BookmarksChanged event of the bookmark <see cref="IBookmarkProvider"/>.
    /// </summary>
    public void BookmarksChanged()
    {
      if (mBookmarkProvider != null)
      {
        LogMessage selectedMessage = dgvBookmarks.SelectedRows.Count > 0
          ? dgvBookmarks.SelectedRows[0].Tag as LogMessage
          : null;

        dgvBookmarks.SuspendDrawing();

        try
        {
          dgvBookmarks.Rows.Clear();

          foreach (LogMessage message in mBookmarkProvider.Bookmarks)
          {
            int rowIndex = dgvBookmarks.Rows.Add(
                mBookmarkImage
              , message.Index
              , message.Message);

            dgvBookmarks.Rows[rowIndex].Tag = message;

            if (Equals(selectedMessage, message))
            {
              dgvBookmarks.Rows[rowIndex].Selected = true;
            }
          }
        }
        finally
        {
          dgvBookmarks.ResumeDrawing();
        }
        
        SelectLogMessage(mBookmarkProvider.SelectedMessage);
      }
    }

    /// <summary>
    /// Updates the visible <see cref="LogMessage"/>s.
    /// </summary>
    /// <param name="messages">The list of <see cref="LogMessage"/>s to display.</param>
    /// <param name="delta">The count of new <see cref="LogMessage"/>s.</param>
    public void LogMessagesChanged(System.Collections.Generic.List<LogMessage> messages, int delta = -1)
    {
      // Nothing to do here.
    }

    /// <summary>
    /// Selects the <see cref="LogMessage"/> on the given <paramref name="index"/>.
    /// </summary>
    /// <param name="index">The index of the <see cref="LogMessage"/> to select.</param>
    /// <returns><c>True</c> if the <see cref="LogMessage"/> of the given <paramref name="index"/> was selected successfully, otherwise <c>false</c>.</returns>
    public bool SelectLogMessage(int index)
    {
      // Nothing to do here.
      return true;
    }

    /// <summary>
    /// Selects the given <paramref name="message"/>.
    /// </summary>
    /// <param name="message">The <see cref="LogMessage"/> o select</param>
    /// <returns><c>True</c> if the given <paramref name="message"/> was selected successfully, otherwise <c>false</c>.</returns>
    public bool SelectLogMessage(LogMessage message)
    {
      if (message == null || mBookmarkProvider == null)
      {
        return false;
      }

      tsbNextBookmark.Enabled = dgvBookmarks.SelectedRows.Count > 0 && 
                                   !dgvBookmarks.Rows[dgvBookmarks.RowCount - 1].Selected;

      tsbPreviousBookmark.Enabled = dgvBookmarks.SelectedRows.Count > 0 && 
                                   !dgvBookmarks.Rows[0].Selected;

      return true;
    }

    /// <summary>
    /// Clears all shown <see cref="LogMessage"/>s.
    /// </summary>
    public void ClearAll()
    {
      mBookmarkProvider.Bookmarks.Clear();
      BookmarksChanged();
    }

    /// <summary>
    /// Increases the size of the <see cref="ILogPresenter"/> content.
    /// </summary>
    /// <returns><c>True</c> if further increasing is possible, otherwise <c>false</c>.</returns>
    public bool ZoomIn()
    {
      if (dgvBookmarks.Font.Size < MAX_ZOOM_LEVEL)
      {
        try
        {
          dgvBookmarks.SuspendDrawing();

          dgvBookmarks.Font = FontCache.GetFontFromIdentifier(
              Font.Name
            , dgvBookmarks.Font.Size + 1
            , FontStyle.Regular);

          return dgvBookmarks.Font.Size < MAX_ZOOM_LEVEL;
        }
        finally
        {
          dgvBookmarks.ResumeDrawing();
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
      if (dgvBookmarks.Font.Size > MIN_ZOOM_LEVEL)
      {
        try
        {
          dgvBookmarks.SuspendDrawing();

          dgvBookmarks.Font = FontCache.GetFontFromIdentifier(
              Font.Name
            , dgvBookmarks.Font.Size - 1
            , FontStyle.Regular);

          return dgvBookmarks.Font.Size > MIN_ZOOM_LEVEL;
        }
        finally
        {
          dgvBookmarks.ResumeDrawing();
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
      tsbRemoveBookmark.Image   = theme.Resources.Images["FrmBookmarksTbRemove"];
      tsbPreviousBookmark.Image = theme.Resources.Images["FrmBookmarksTbPrevious"];
      tsbNextBookmark.Image     = theme.Resources.Images["FrmBookmarksTbNext"];
      tsbZoomIn.Image           = theme.Resources.Images["FrmMainTbZoomIn"];
      tsbZoomOut.Image          = theme.Resources.Images["FrmMainTbZoomOut"];

      dgvBookmarks.EnableHeadersVisualStyles             = theme.Metrics.PreferSystemRendering;
      dgvBookmarks.ColumnHeadersDefaultCellStyle.Padding = theme.Metrics.DataGridViewHeaderColumnPadding;

      dgvBookmarks.BackgroundColor          = theme.ColorPalette.ContentBackground;
      dgvBookmarks.ForeColor                = theme.ColorPalette.ContentForeground;
      dgvBookmarks.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
      dgvBookmarks.GridColor                = theme.ColorPalette.DividerColor;

      dgvBookmarks.ColumnHeadersDefaultCellStyle.BackColor = theme.ColorPalette.ContentBackground;
      dgvBookmarks.ColumnHeadersDefaultCellStyle.ForeColor = theme.ColorPalette.ContentForeground;

      dgvBookmarks.CellBorderStyle            = DataGridViewCellBorderStyle.Single;
      dgvBookmarks.DefaultCellStyle.BackColor = theme.ColorPalette.ContentBackground;
      dgvBookmarks.DefaultCellStyle.ForeColor = theme.ColorPalette.ContentForeground;
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Creates a new instance of the <see cref="FrmLogBookmarks"/> window.
    /// </summary>
    /// <param name="bookmarkProvider">The <see cref="IBookmarkProvider"/> instance that provides bookmarked <see cref="LogMessage"/>s.</param>
    public FrmLogBookmarks(IBookmarkProvider bookmarkProvider)
    {
      mBookmarkProvider = bookmarkProvider;

      // Register this instance as observer.
      mBookmarkProvider?.RegisterBookmarkObserver(this);

      InitializeComponent();

      // Apply the current application theme to the control.
      ThemeManager.ApplyTo(this);
    }

    #endregion
  }
}
