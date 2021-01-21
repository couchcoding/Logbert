#region Copyright © 2015 Couchcoding

// File:    FrmLogWindow.cs
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
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using Couchcoding.Logbert.Helper;
using Couchcoding.Logbert.Theme.Palettes;
using Couchcoding.Logbert.Interfaces;
using Couchcoding.Logbert.Logging;
using Couchcoding.Logbert.Logging.Filter;
using Couchcoding.Logbert.Properties;

using WeifenLuo.WinFormsUI.Docking;
using Couchcoding.Logbert.Theme.Interfaces;
using Couchcoding.Logbert.Theme;
using Couchcoding.Logbert.Theme.Themes;
using Couchcoding.Logbert.Theme.Helper;

namespace Couchcoding.Logbert.Dialogs.Docking
{
  /// <summary>
  /// Implements the <see cref="DockContent"/> of the log message window.
  /// </summary>
  public partial class FrmLogWindow : DockContent, ILogPresenter, ILogFilterHandler, IBookmarkProvider, ISearchable, IThemable
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

    /// <summary>
    /// Defines the default <see cref="Font"/> name for the <see cref="FrmLogWindow"/>.
    /// </summary>
    private const string DEFAULT_FONT_NAME = "Microsoft Sans Serif";

    /// <summary>
    /// Defines the default <see cref="Font"/> size for the <see cref="FrmLogWindow"/>.
    /// </summary>
    private const int DEFAULT_FONT_SIZE = 9;

    #endregion

    #region Private Fields

    private readonly ILogContainer mLogcontainer;

    private List<LogMessage> mFilteredLogMessages;
    
    /// <summary>
    /// Holds the <see cref="List{LogMessage}"/> of bookmarked <see cref="LogMessage"/>s.
    /// </summary>
    private readonly List<LogMessage> mBookmarks;

    /// <summary>
    /// Holds the <see cref="List{IBookmarkObserver}"/> of <see cref="mBookmarkObserver"/>s.
    /// </summary>
    private readonly List<IBookmarkObserver> mBookmarkObserver = new List<IBookmarkObserver>();

    /// <summary>
    /// Holds the <see cref="ILogFilterProvider"/>s that provides <see cref="LogFilter"/> for the received <see cref="LogMessage"/>s.
    /// </summary>
    private readonly List<ILogFilterProvider> mLogFilterProvider = new List<ILogFilterProvider>();

    /// <summary>
    /// The <see cref="LogFilter"/>s to apply to the recieved <see cref="LogMessage"/>s.
    /// </summary>
    private List<LogFilter> mLogFilterToApply;

    /// <summary>
    /// The current displayed row height of the <see cref="DataGridView"/>.
    /// </summary>
    private int mRowHeight = 22;

    /// <summary>
    /// The <see cref="Image"/>s to display for bookmarked <see cref="LogMessage"/>s.
    /// </summary>
    protected static readonly Image[] mBookmarkImages = 
    {
        Resources.NoBookmark
      , ThemeManager.CurrentApplicationTheme.Resources.Images["FrmLogBookmark"]
    };

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets the count of currently displayed <see cref="LogMessage"/>s.
    /// </summary>
    public int DisplayedLogMessagesCount
    {
      get
      {
        return dtgLogMessages.RowCount;
      }
    }

    /// <summary>
    /// Gets the <see cref="List{LogMessage}"/>´of bookmarked <see cref="LogMessage"/>s.
    /// </summary>
    public List<LogMessage> Bookmarks
    {
      get
      {
        return mBookmarks;
      }
    }

    /// <summary>
    /// Gets the current selected <see cref="LogMessage"/>.
    /// </summary>
    public LogMessage SelectedMessage
    {
      get
      {
        return dtgLogMessages.SelectedRows.Count > 0
          ? mFilteredLogMessages[dtgLogMessages.SelectedRows.OrderByIndex().First().Index]
          : null;
      }
    }

    #endregion

    #region Private Delegates

    /// <summary>
    /// Delegate to update the visible <see cref="LogMessage"/>s.
    /// </summary>
    /// <param name="messages">The list of <see cref="LogMessage"/>s to display.</param>
    /// <param name="delta">The count of new <see cref="LogMessage"/>s.</param>
    private delegate void LogMessagesChangedDelegate(List<LogMessage> messages, int delta);

    private delegate bool SelectLogMessageDelegate(int index);

    #endregion

    #region Public Events

    public event EventHandler<LogMessageSelectedEventArgs> OnLogMessageSelected;

    #endregion

    #region Private Methods

    /// <summary>
    /// Creates a <see cref="MenuItem"/> for the column selection <see cref="ContextMenu"/>.
    /// </summary>
    /// <param name="name">The name of the new <see cref="MenuItem"/>.</param>
    /// <param name="isChecked">Determines whether the new <see cref="MenuItem"/> is initial checked, or not.</param>
    /// <param name="tag">The object reference to the referenced <see cref="DataGridViewColumnHeaderCell"/>.</param>
    /// <returns>A <see cref="MenuItem"/> for the column selection <see cref="ContextMenu"/>.</returns>
    private ToolStripMenuItem CreateColumnSelectItem(string name, bool isChecked, object tag)
    {
      ToolStripMenuItem chkMnuItem = new ToolStripMenuItem(name);
      chkMnuItem.Checked  = isChecked;
      chkMnuItem.Tag      = tag;

      chkMnuItem.Click   += MnuColumnItemClicked;

      return chkMnuItem;
    }

    /// <summary>
    /// Handles the Column Header Mouse Click event of the <see cref="DataGridView"/>.
    /// </summary>
    private void DtgLogMessagesColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
      if (e.Button == MouseButtons.Right)
      {
        cmColumns.Items.Clear();

        foreach (DataGridViewColumn column in dtgLogMessages.Columns)
        {
          DataGridViewColumnHeaderCell headerCell = column.HeaderCell;

          if (headerCell != null && headerCell.OwningColumn != null)
          {
            if (headerCell.OwningColumn.Index == 0)
            {
              continue;
            }

            cmColumns.Items.Add(CreateColumnSelectItem(
                headerCell.OwningColumn.HeaderText
              , headerCell.OwningColumn.Visible
              , headerCell));
          }
        }

        cmColumns.Show(
            this
          , PointToClient(Cursor.Position));
      }
    }

    /// <summary>
    /// Handles the Column Item Clicked event of the <see cref="DataGridView"/>.
    /// </summary>
    private void MnuColumnItemClicked(object sender, EventArgs e)
    {
      ToolStripMenuItem senderItem = sender as ToolStripMenuItem;

      if (senderItem != null)
      {
        DataGridViewColumnHeaderCell headerCell = senderItem.Tag as DataGridViewColumnHeaderCell;

        if (headerCell != null && headerCell.OwningColumn != null)
        {
          headerCell.OwningColumn.Visible = !senderItem.Checked;
        }
      }
    }

    /// <summary>
    /// Determines whether the given <paramref name="message"/> is filtered out, or not.
    /// </summary>
    /// <param name="message">The <see cref="LogMessage"/> to check.</param>
    /// <returns><c>True</c> if the given <see cref="LogMessage"/> is filtered, or not.</returns>
    private bool IsMessageFiltered(LogMessage message)
    {
      if (message == null)
      {
        return true;
      }

      if (mLogFilterToApply != null)
      {
        foreach (LogFilter filter in mLogFilterToApply)
        {
          if (filter.IsActive && !filter.Match(message))
          {
            return true;
          }
        }
      }

      return false;
    }

    /// <summary>
    /// Updates the internal <see cref="IEnumerable{T}"/> of <see cref="LogMessage"/>s to display.
    /// </summary>
    /// <param name="messages">The list of <see cref="LogMessage"/>s to display.</param>
    private void UpdateInternalList(IEnumerable<LogMessage> messages)
    {
      dtgLogMessages.CellValueNeeded -= DtgLogMessagesCellValueNeeded;

      try
      {
        dtgLogMessages.SuspendLayout();

        mFilteredLogMessages?.Clear();
        mFilteredLogMessages = new List<LogMessage>();

        foreach (LogMessage message in messages)
        {
          if (IsMessageFiltered(message))
          {
            continue;
          }

          mFilteredLogMessages.Add(message);
        }

        dtgLogMessages.RowCount = mFilteredLogMessages.Count;

        // Update the color map.
        colorMap1.UpdateColorMap(mFilteredLogMessages);
      }
      finally
      {
        dtgLogMessages.CellValueNeeded += DtgLogMessagesCellValueNeeded;
        dtgLogMessages.ResumeLayout();
      }
    }

    /// <summary>
    /// Initializes the <see cref="DataGridViewColumn"/>s by the given <paramref name="logProvider"/>.
    /// </summary>
    /// <param name="logProvider">The <see cref="ILogProvider"/> that provides necessary column information.</param>
    private void InitializeColumns(ILogProvider logProvider)
    {
      if (logProvider != null)
      {
        dtgLogMessages.SuspendDrawing();

        try
        {
          dtgLogMessages.Columns.Clear();

          // Always add the bookmark column.
          dtgLogMessages.Columns.Add(new DataGridViewImageColumn
          { 
              Tag          = -1 
            , HeaderText   = string.Empty
            , MinimumWidth = 20
            , Width        = 20
            , Resizable    = DataGridViewTriState.False
            , Image        = imlBookmark.Images[0]
            , SortMode     = DataGridViewColumnSortMode.Programmatic
          });

          foreach (KeyValuePair<int, LogColumnData> columnData in logProvider.Columns)
          {
            DataGridViewColumn clmHdr = new DataGridViewTextBoxColumn
            { 
                Tag        = columnData.Key 
              , HeaderText = columnData.Value.Name
              , Width      = columnData.Value.Width
              , Visible    = columnData.Value.Visible
              , SortMode   = DataGridViewColumnSortMode.Programmatic
            };
            
            dtgLogMessages.Columns.Add(clmHdr);
          }
        }
        finally
        {
          dtgLogMessages.ResumeDrawing();
        }
      }
    }

    /// <summary>
    /// Handles the CellValueNeeded event of the <see cref="DataGridView"/>.
    /// </summary>
    private void DtgLogMessagesCellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
    {
      if (e.RowIndex >= mFilteredLogMessages.Count || e.RowIndex < 0)
      {
        return;
      }

      if (e.ColumnIndex == 0 && mBookmarks != null)
      {
        e.Value = mBookmarks.Contains(mFilteredLogMessages[e.RowIndex])
          ? mBookmarkImages[1]
          : mBookmarkImages[0];

        return;
      }

      e.Value = mFilteredLogMessages[e.RowIndex].GetValueForColumn(e.ColumnIndex);
    }

    /// <summary>
    /// Handles the CellPainting event of the <see cref="DataGridView"/>.
    /// </summary>
    private void DtgLogMessagesCellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
      if (e.RowIndex >= mFilteredLogMessages.Count || e.RowIndex < 0)
      {
        return;
      }

      if ((e.State & DataGridViewElementStates.Visible) == DataGridViewElementStates.None)
      {
        return;
      }

      Color foreColor       = SystemColors.WindowText;
      Color backColor       = SystemColors.Window;
      Brush backgroundBrush = null;
      FontStyle fontStyle   = FontStyle.Regular;

      switch (mFilteredLogMessages[e.RowIndex].Level)
      {
        case LogLevel.Trace:
          foreColor = Settings.Default.ForegroundColorTrace;
          backColor = Settings.Default.BackgroundColorTrace;
          fontStyle = Settings.Default.FontStyleTrace;
          backgroundBrush = GdiCache.GetBrushFromColor(backColor);
          break;
        case LogLevel.Debug:
          foreColor = Settings.Default.ForegroundColorDebug;
          backColor = Settings.Default.BackgroundColorDebug;
          fontStyle = Settings.Default.FontStyleDebug;
          backgroundBrush = GdiCache.GetBrushFromColor(backColor);
          break;
        case LogLevel.Info:
          foreColor = Settings.Default.ForegroundColorInfo;
          backColor = Settings.Default.BackgroundColorInfo;
          fontStyle = Settings.Default.FontStyleInfo;
          backgroundBrush = GdiCache.GetBrushFromColor(backColor);
          break;
        case LogLevel.Warning:
          foreColor = Settings.Default.ForegroundColorWarning;
          backColor = Settings.Default.BackgroundColorWarning;
          fontStyle = Settings.Default.FontStyleWarning;
          backgroundBrush = GdiCache.GetBrushFromColor(backColor);
          break;
        case LogLevel.Error:
          foreColor = Settings.Default.ForegroundColorError;
          backColor = Settings.Default.BackgroundColorError;
          fontStyle = Settings.Default.FontStyleError;
          backgroundBrush = GdiCache.GetBrushFromColor(backColor);
          break;
        case LogLevel.Fatal:
          foreColor = Settings.Default.ForegroundColorFatal;
          backColor = Settings.Default.BackgroundColorFatal;
          fontStyle = Settings.Default.FontStyleFatal;
          backgroundBrush = GdiCache.GetBrushFromColor(backColor);
          break;
      }

      if ((e.State & DataGridViewElementStates.Selected) == DataGridViewElementStates.Selected)
      {
        if (Settings.Default.UseInvertedColorForSelection)
        {
          // Invert the colors for selected items.
          Color tmpForecolor = foreColor;

          foreColor       = backColor;
          backColor       = tmpForecolor;
          backgroundBrush = GdiCache.GetBrushFromColor(tmpForecolor);
        }
        else
        {
          // Use the default system colors for selected items.
          foreColor       = SystemColors.HighlightText;
          backColor       = SystemColors.MenuHighlight;
          backgroundBrush = GdiCache.GetBrushFromColor(backColor);
        }
      }

      if (backgroundBrush != null)
      {
        e.Graphics.FillRectangle(
            backgroundBrush
          , e.CellBounds);

        if (e.ColumnIndex == 0)
        {
          // the first column may be an image.
          e.PaintContent(e.CellBounds);
        }
        else
        {
          Font logFont = FontCache.GetFontFromIdentifier(
              e.CellStyle.Font.Name
            , e.CellStyle.Font.Size
            , fontStyle);

          TextRenderer.DrawText(
              e.Graphics
            , e.Value?.ToString() ?? string.Empty
            , logFont
            , e.CellBounds
            , foreColor
            , backColor
            , TextFormatFlags.SingleLine | TextFormatFlags.VerticalCenter);
        }

        e.Graphics.DrawRectangle(
            Settings.Default.LogWindowDrawGrid 
            ? GdiCache.GetPenFromColor(dtgLogMessages.GridColor) 
            : GdiCache.GetPenFromColor(backColor)
          , e.CellBounds);

        e.Handled = true;
      }
    }

    /// <summary>
    /// Raises the LogMessageSelectedEvent event.
    /// </summary>
    /// <param name="e">The <see cref="LogMessageSelectedEventArgs"/> that may contain necessary information.</param>
    private void OnRaiseLogMessageSelectedEvent(LogMessageSelectedEventArgs e)
    {
      OnLogMessageSelected?.Invoke(this, e);
    }

    /// <summary>
    /// Handles the SelectionChanged event of the <see cref=" DataGridView"/>.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void DtgLogMessagesSelectionChanged(object sender, EventArgs e)
    {
      LogMessage selectedMessage = null;

      if (dtgLogMessages.SelectedRows.Count == 1)
      { 
        int messageIndex = dtgLogMessages.SelectedRows.OrderByIndex().First().Index;

        if (messageIndex >= 0 && messageIndex < mFilteredLogMessages.Count)
        {
          selectedMessage = mFilteredLogMessages[messageIndex];

          // If a row above the last one is selected, disable the tail feature.
          mLogcontainer.TailEnabled = messageIndex >= mFilteredLogMessages.Count - 1 
                                   && Settings.Default.LogWndAutoScrollOnLastMessageSelect;
        }
      }

      OnRaiseLogMessageSelectedEvent(
        new LogMessageSelectedEventArgs(selectedMessage));
    }

    /// <summary>
    /// Handles the KeyDown event of the <see cref="DataGridView"/>.
    /// </summary>
    private void DtgLogMessagesKeyDown(object sender, KeyEventArgs e)
    {
      switch (e.KeyCode)
      {
        case Keys.Home:
          SelectLogMessage(0);
          break;

        case Keys.End:
          SelectLogMessage(dtgLogMessages.RowCount);
          break;
      }
    }

    /// <summary>
    /// Handles the CellDoubleClick event of the <see cref="DataGridView"/>.
    /// </summary>
    private void DtgLogMessagesCellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex >= 0 && e.RowIndex < mFilteredLogMessages.Count && e.ColumnIndex == 0)
      {
        LogMessage currentMsg = mFilteredLogMessages[dtgLogMessages.SelectedRows.OrderByIndex().First().Index];

        // Toggle the bookmark state.
        if (mBookmarks.Contains(currentMsg))
        {
          RemoveBookmarks(new List<LogMessage>(new[] { currentMsg }));
        }
        else
        {
          AddBookmarks(new List<LogMessage>(new[] { currentMsg }));
        }
      }
    }

    /// <summary>
    /// Handles the RowHeightInfoNeeded event of the <see cref="DataGridView"/>.
    /// </summary>
    private void DtgLogMessagesRowHeightInfoNeeded(object sender, DataGridViewRowHeightInfoNeededEventArgs e)
    {
      if (mRowHeight > 2)
      {
        e.MinimumHeight = mRowHeight;
        e.Height        = mRowHeight;
      }
    }

    private void dtgLogMessages_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
      if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
      {
        cmLogMessage.Show(
            this
          , PointToClient(Cursor.Position));
      }
    }

    private void dtgLogMessages_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
    {
      if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
      {
        dtgLogMessages.Rows[e.RowIndex].Selected = true;
      }
    }

    private void copyToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
    {
      IDataObject clipboardData = dtgLogMessages.GetClipboardContent();

      if (clipboardData != null)
      {
        Clipboard.SetDataObject(clipboardData);
      }
    }

    private void synchronizeTreeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      LogMessage selectedMessage = mFilteredLogMessages[dtgLogMessages.SelectedRows.OrderByIndex().First().Index] as LogMessage;

      if (selectedMessage != null)
      {
        mLogcontainer.SynchronizeTree(selectedMessage);
      } 
    }

    private void CmsToggleBookmarkClick(object sender, EventArgs e)
    {
      if (mFilteredLogMessages[dtgLogMessages.SelectedRows.OrderByIndex().First().Index] is LogMessage firstMessage)
      {
        bool isBookmarked = mBookmarks.Contains(firstMessage);
        List<LogMessage> selectedMessages = new List<LogMessage>();

        foreach (DataGridViewRow messageRow in dtgLogMessages.SelectedRows)
        {
          selectedMessages.Add(mFilteredLogMessages[messageRow.Index]);
        }

        // Toggle the bookmark state.
        if (isBookmarked)
        {
          RemoveBookmarks(selectedMessages);
        }
        else
        {
          AddBookmarks(selectedMessages);
        }
      }
    }

    /// <summary>
    /// Handles the SettingChanging event of the <see cref="Application"/>.
    /// </summary>
    private void DefaultSettingChanging(object sender, System.Configuration.SettingChangingEventArgs e)
    {
      if (!string.IsNullOrEmpty(Settings.Default.LogMessagesFontName))
      {
        try
        {
          Settings.Default.SettingChanging -= DefaultSettingChanging;

          dtgLogMessages.DefaultCellStyle.Font = FontCache.GetFontFromIdentifier(
              Settings.Default.LogMessagesFontName
            , Settings.Default.LogMessagesFontSize
            , FontStyle.Regular);
        }
        catch
        {
          // Reset the font on error.
          dtgLogMessages.Font = FontCache.GetFontFromIdentifier(
              DEFAULT_FONT_NAME
            , DEFAULT_FONT_SIZE
            , FontStyle.Regular);

          mRowHeight = dtgLogMessages.RowTemplate.Height;

          // Save the changed settings as new default.
          Settings.Default.LogMessagesFontName = DEFAULT_FONT_NAME;
          Settings.Default.LogMessagesFontSize = DEFAULT_FONT_SIZE;

          Settings.Default.SaveSettings();
        }
        finally
        {
          Settings.Default.SettingChanging += DefaultSettingChanging;
        }
      }

      // Hide the color map control.
      SuspendLayout();

      try
      {
        if (Settings.Default.EnableColorMap)
        {
          tableLayoutPanel1.SetColumnSpan(dtgLogMessages, 1);
          colorMap1.Visible = true;

          colorMap1.UpdateColorMap(mFilteredLogMessages);
        }
        else
        {
          colorMap1.Visible = false;
          tableLayoutPanel1.SetColumnSpan(dtgLogMessages, 2);
        }
      }
      finally
      {
        ResumeLayout(true);
      }

      if (e.SettingName.Equals("ColorMapAnnotation"))
      {
        // Force a redraw of the color map control.
        colorMap1.UpdateColorMap(mFilteredLogMessages);
      }

      dtgLogMessages.Refresh();
    }

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        components.Dispose();

        mFilteredLogMessages?.Clear();
        mFilteredLogMessages = null;

        // Remove the settings change event handler.
        Settings.Default.SettingChanging -= DefaultSettingChanging;
      }

      base.Dispose(disposing);
    }

    protected override void OnResize(EventArgs e)
    {
      base.OnResize(e);

      // Force a redraw of the color map.
      colorMap1.UpdateColorMap(mFilteredLogMessages);
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Adds a new Bookmark for the given <paramref name="message"/>.
    /// </summary>
    /// <param name="message">The <see cref="LogMessage"/> to bookmark.</param>
    public void AddBookmarks(List<LogMessage> messages)
    {
      if (messages == null || messages.Count == 0)
      {
        return;
      }

      foreach (LogMessage message in messages)
      {
        if (!mBookmarks.Contains(message))
        {
          mBookmarks.Add(message);
        }
      }

      dtgLogMessages.Invalidate();

      foreach (IBookmarkObserver observer in mBookmarkObserver)
      {
        observer.BookmarksChanged();
      }
    }

    /// <summary>
    /// Removes the given <paramref name="message"/> from the bookmarks.
    /// </summary>
    /// <param name="message">The <see cref="LogMessage"/> to remove from the bookmarks.</param>
    public void RemoveBookmarks(List<LogMessage> messages)
    {
      if (messages == null || messages.Count == 0)
      {
        return;
      }

      foreach (LogMessage message in messages)
      {
        if (mBookmarks.Contains(message))
        {
          mBookmarks.Remove(message);
        }
      }

      dtgLogMessages.Invalidate();

      foreach (IBookmarkObserver observer in mBookmarkObserver)
      {
        observer.BookmarksChanged();
      }
    }

    /// <summary>
    /// Registers a <see cref="IBookmarkObserver"/> to the <see cref="IBookmarkProvider"/> instance.
    /// </summary>
    /// <param name="observer">The <see cref="IBookmarkObserver"/> to register.</param>
    public void RegisterBookmarkObserver(IBookmarkObserver observer)
    {
      if (!mBookmarkObserver.Contains(observer))
      {
        mBookmarkObserver.Add(observer);
      }
    }

    /// <summary>
    /// Unregisters a <see cref="IBookmarkObserver"/> from the <see cref="IBookmarkProvider"/> instance.
    /// </summary>
    /// <param name="observer">The <see cref="IBookmarkObserver"/> to unregister.</param>
    public void UnregisterBookmarkObserver(IBookmarkObserver observer)
    {
      if (mBookmarkObserver.Contains(observer))
      {
        mBookmarkObserver.Remove(observer);
      }
    }

    /// <summary>
    /// Updates the visible <see cref="LogMessage"/>s.
    /// </summary>
    /// <param name="messages">The list of <see cref="LogMessage"/>s to display.</param>
    /// <param name="delta">The count of new <see cref="LogMessage"/>s.</param>
    public void LogMessagesChanged(List<LogMessage> messages, int delta)
    {
      if (InvokeRequired)
      {
        LogMessagesChangedDelegate updateDelegate = LogMessagesChanged;
        Invoke(updateDelegate, messages, delta);

        return;
      }

      try
      {
        dtgLogMessages.SelectionChanged -= DtgLogMessagesSelectionChanged;

        // Convert the list to an array to fix 
        // accessing it while the enumeration is changed.
        UpdateInternalList(messages.ToArray());
      }
      finally
      {
        dtgLogMessages.SelectionChanged += DtgLogMessagesSelectionChanged;
      }

      dtgLogMessages.Refresh();
    }

    /// <summary>
    /// Selects the <see cref="LogMessage"/> on the given <paramref name="index"/>.
    /// </summary>
    /// <param name="index">The index of the <see cref="LogMessage"/> to select.</param>
    public bool SelectLogMessage(int index)
    {
      if (InvokeRequired)
      {
        SelectLogMessageDelegate updateDelegate = SelectLogMessage;
        return (bool)Invoke(updateDelegate, index);
      }

      if (dtgLogMessages.RowCount > 0)
      {
        int horizontalScrollOffset = dtgLogMessages.HorizontalScrollingOffset;

        try
        {
          dtgLogMessages.SuspendDrawing();

          int selIndex = index < 0
            ? 0
            : index >= dtgLogMessages.RowCount
            ? dtgLogMessages.RowCount - 1
            : index;

          if (dtgLogMessages.Rows[selIndex].Cells.Count > 0)
          {
            dtgLogMessages.CurrentCell = dtgLogMessages.Rows[selIndex].Cells[0];
          }

          if (IsHandleCreated)
          {
            try
            {
              dtgLogMessages.FirstDisplayedScrollingRowIndex = selIndex;
            }
            catch (InvalidOperationException)
            {
              SelectLogMessageDelegate updateDelegate = SelectLogMessage;
              BeginInvoke(updateDelegate, index);
            }
          }

          dtgLogMessages.HorizontalScrollingOffset = horizontalScrollOffset;
        }
        finally
        {
          DtgLogMessagesSelectionChanged(
              this
            , EventArgs.Empty);

          dtgLogMessages.ResumeDrawing();
        }

        return true;
      }

      return false;
    }

    /// <summary>
    /// Selects the given <paramref name="message"/>.
    /// </summary>
    /// <param name="message">The <see cref="LogMessage"/> o select</param>
    public bool SelectLogMessage(LogMessage message)
    {
      if (message != null && mFilteredLogMessages.Contains(message))
      {
        return SelectLogMessage(mFilteredLogMessages.IndexOf(message));
      }

      return false;
    }

    /// <summary>
    /// Clears all shown <see cref="LogMessage"/>s.
    /// </summary>
    public void ClearAll()
    {
      dtgLogMessages.SuspendDrawing();

      try
      {
        dtgLogMessages.Rows.Clear();
      }
      finally
      {
        dtgLogMessages.ResumeDrawing();
      }

      colorMap1.ClearAll();
    }

    /// <summary>
    /// Increases the size of the <see cref="ILogPresenter"/> content.
    /// </summary>
    /// <returns><c>True</c> if further increasing is possible, otherwise <c>false</c>.</returns>
    public bool ZoomIn()
    {
      if (dtgLogMessages.Font.Size < MAX_ZOOM_LEVEL)
      {
        using (new WaitCursor(Cursors.Default, Settings.Default.WaitCursorTimeout))
        {
          try
          {
            dtgLogMessages.SuspendDrawing();

            dtgLogMessages.DefaultCellStyle.Font = FontCache.GetFontFromIdentifier(
                dtgLogMessages.DefaultCellStyle.Font.Name
              , dtgLogMessages.DefaultCellStyle.Font.Size + 1
              , FontStyle.Regular);

            dtgLogMessages.Font = dtgLogMessages.DefaultCellStyle.Font;

            ++mRowHeight;

            dtgLogMessages.AutoResizeRows(
              DataGridViewAutoSizeRowsMode.DisplayedCells);

            if (dtgLogMessages.RowCount > 0)
            {
              // Force a refresh of the layout after zoom.
              dtgLogMessages.UpdateRowHeightInfo(0, true);
            }
          }
          finally
          {
            dtgLogMessages.ResumeDrawing();
          }
        }
        return dtgLogMessages.DefaultCellStyle.Font.Size < MAX_ZOOM_LEVEL;
      }

      return false;
    }

    /// <summary>
    /// Decreases the size of the <see cref="ILogPresenter"/> content.
    /// </summary>
    /// <returns><c>True</c> if further decreasing is possible, otherwise <c>false</c>.</returns>
    public bool ZoomOut()
    {
      if (dtgLogMessages.Font.Size > MIN_ZOOM_LEVEL)
      {
        using (new WaitCursor(Cursors.Default, Settings.Default.WaitCursorTimeout))
        {
          try
          {
            dtgLogMessages.SuspendDrawing();

            dtgLogMessages.DefaultCellStyle.Font = FontCache.GetFontFromIdentifier(
                dtgLogMessages.DefaultCellStyle.Font.Name
              , dtgLogMessages.DefaultCellStyle.Font.Size - 1
              , FontStyle.Regular);

            dtgLogMessages.Font = dtgLogMessages.DefaultCellStyle.Font;

            --mRowHeight;

            dtgLogMessages.AutoResizeRows(
              DataGridViewAutoSizeRowsMode.DisplayedCells);

            if (dtgLogMessages.RowCount > 0)
            {
              // Force a refresh of the layout after zoom.
              dtgLogMessages.UpdateRowHeightInfo(0, true);
            }
          }
          finally
          {
            dtgLogMessages.ResumeDrawing();
          }
        }

        return dtgLogMessages.DefaultCellStyle.Font.Size > MIN_ZOOM_LEVEL;
      }

      return false;
    }

    /// <summary>
    /// Handles the change of the <see cref="LogFilter"/> of the registered <see cref="ILogFilterProvider"/>
    /// </summary>
    public void FilterChanged()
    {
      if (InvokeRequired)
      {
        Invoke(new MethodInvoker(FilterChanged));
        return;
      }

      mLogFilterToApply = new List<LogFilter>();

      foreach (ILogFilterProvider filterProvider in mLogFilterProvider)
      {
        if (filterProvider.Filter == null || filterProvider.Filter.Count == 0)
        {
          continue;
        }

        mLogFilterToApply.AddRange(filterProvider.Filter);
      }

      using (new WaitCursor(Cursors.Default, Settings.Default.WaitCursorTimeout))
      {
        try
        {
          dtgLogMessages.SelectionChanged -= DtgLogMessagesSelectionChanged;

          // Remember the current selected message.
          LogMessage selectedMessage = null;

          if (dtgLogMessages.SelectedRows.Count == 1)
          { 
            int messageIndex = dtgLogMessages.SelectedRows.OrderByIndex().First().Index;

            if (messageIndex >= 0 && messageIndex < mFilteredLogMessages.Count)
            {
              selectedMessage = mFilteredLogMessages[messageIndex];
            }
          }

          // Clear all existing datasets.
          dtgLogMessages.Rows.Clear();

          // Convert the list to an array to fix 
          // accessing it while the enumeration is changed.
          UpdateInternalList(mLogcontainer.LogMessages.ToArray());

          // Try to select the previous selected log message again.
          SelectLogMessage(selectedMessage);
        }
        finally
        {
          dtgLogMessages.SelectionChanged += DtgLogMessagesSelectionChanged;
        }
      }

      dtgLogMessages.Refresh();

      if (mLogcontainer != null)
      {
        mLogcontainer.UpdateStatusBarInformation();
      }
    }

    /// <summary>
    /// Registers a <see cref="ILogFilterProvider"/> to the <see cref="ILogFilterHandler"/> instance.
    /// </summary>
    /// <param name="provider">The <see cref="ILogFilterProvider"/> to register.</param>
    public void RegisterFilterProvider(ILogFilterProvider provider)
    {
      if (!mLogFilterProvider.Contains(provider))
      {
        mLogFilterProvider.Add(provider);
      }

      // Apply possible new filter.
      FilterChanged();
    }

    /// <summary>
    /// Unregisters a <see cref="ILogFilterProvider"/> from the <see cref="ILogFilterHandler"/> instance.
    /// </summary>
    /// <param name="provider">The <see cref="ILogFilterProvider"/> to unregister.</param>
    public void UnregisterFilterProvider(ILogFilterProvider provider)
    {
      if (mLogFilterProvider.Contains(provider))
      {
        mLogFilterProvider.Remove(provider);
      }

      // Remove possible obsolete filter.
      FilterChanged();
    }

    /// <summary>
    /// Search for a <see cref="LogMessage"/> that contains the given <paramref name="pattern"/>.
    /// </summary>
    /// <param name="pattern">The patter to search for.</param>
    /// <param name="searchForward">Determines the search direction.</param>
    /// <param name="searchAllDocuments">Determines whether in all open <see cref="ISearchable"/>s should be searched, or not.</param>
    public void SearchLogMessage(string pattern, bool searchForward = true, bool searchAllDocuments = false)
    {
      if (dtgLogMessages.RowCount == 0)
      {
        return;
      }

      int currentMessageIndex = dtgLogMessages.SelectedRows.Count == 0 
        ? 0 
        : dtgLogMessages.SelectedRows.OrderByIndex().First().Index + 1;

      Regex rgxToSeachFor = new Regex(pattern,
        Settings.Default.FrmFindSearchMatchCase 
          ? RegexOptions.None 
          : RegexOptions.IgnoreCase);

      if (searchForward)
      {
        for (int srcIndex = currentMessageIndex; srcIndex < mFilteredLogMessages.Count; ++srcIndex)
        {
          if (rgxToSeachFor.IsMatch(mFilteredLogMessages[srcIndex].Message))
          {
            SelectLogMessage(srcIndex);
            return;
          }
        }

        for (int srcIndex = 0; srcIndex < currentMessageIndex; ++srcIndex)
        {
          if (rgxToSeachFor.IsMatch(mFilteredLogMessages[srcIndex].Message))
          {
            SelectLogMessage(srcIndex);
            return;
          }
        }
      }
      else
      {
        for (int srcIndex = currentMessageIndex - 2; srcIndex >= 0 ; --srcIndex)
        {
          if (rgxToSeachFor.IsMatch(mFilteredLogMessages[srcIndex].Message))
          {
            SelectLogMessage(srcIndex);
            return;
          }
        }

        for (int srcIndex = mFilteredLogMessages.Count - 1; srcIndex >= currentMessageIndex; --srcIndex)
        {
          if (rgxToSeachFor.IsMatch(mFilteredLogMessages[srcIndex].Message))
          {
            SelectLogMessage(srcIndex);
            return;
          }
        }
      }
    }

    public List<LogColumnData> GetColumnLayout()
    {
      List<LogColumnData> columnLayout = new List<LogColumnData>();

      foreach (DataGridViewColumn column in dtgLogMessages.Columns)
      {
        if ((int)column.Tag == -1)
        {
          continue;
        }

        columnLayout.Add(new LogColumnData(column.HeaderText, column.Visible, column.Width));
      }

      return columnLayout;
    }

    /// <summary>
    /// Applies the current theme to the <see cref="Control"/>.
    /// </summary>
    /// <param name="theme">The <see cref="BaseTheme"/> instance to apply.</param>
    public void ApplyTheme(BaseTheme theme)
    {
      ThemeManager.ApplyTo(cmColumns);
      ThemeManager.ApplyTo(cmLogMessage);

      cmdcopytoclipboard.Image = theme.Resources.Images["FrmScriptTbCopy"];
      cmsToggleBookmark.Image  = theme.Resources.Images["FrmMainTbBookmark"];
      cmsSynchronizeTree.Image = theme.Resources.Images["FrmMainTbSync"];
      
      dtgLogMessages.EnableHeadersVisualStyles             = theme.Metrics.PreferSystemRendering;
      dtgLogMessages.ColumnHeadersDefaultCellStyle.Padding = theme.Metrics.DataGridViewHeaderColumnPadding;

      dtgLogMessages.BackgroundColor          = theme.ColorPalette.ContentBackground;
      dtgLogMessages.ForeColor                = theme.ColorPalette.ContentForeground;
      dtgLogMessages.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
      dtgLogMessages.GridColor                = theme.ColorPalette.DividerColor;

      dtgLogMessages.ColumnHeadersDefaultCellStyle.BackColor          = theme.ColorPalette.ContentBackground;
      dtgLogMessages.ColumnHeadersDefaultCellStyle.ForeColor          = theme.ColorPalette.ContentForeground;
      dtgLogMessages.ColumnHeadersDefaultCellStyle.SelectionBackColor = theme.ColorPalette.SelectionBackgroundFocused;
      dtgLogMessages.ColumnHeadersDefaultCellStyle.SelectionForeColor = theme.ColorPalette.SelectionForegroundFocused;

      dtgLogMessages.CellBorderStyle            = DataGridViewCellBorderStyle.Single;
      dtgLogMessages.DefaultCellStyle.BackColor = theme.ColorPalette.ContentBackground;
      dtgLogMessages.DefaultCellStyle.ForeColor = theme.ColorPalette.ContentForeground;
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Creates a new instance of the <see cref="FrmLogWindow"/> window.
    /// </summary>
    /// <param name="logProvider">The <see cref="ILogProvider"/> that sends messages to this window.</param>
    /// <param name="logContainer">The <see cref="ILogContainer"/> that contains the source for <see cref="LogMessage"/>s.</param>
    public FrmLogWindow(ILogProvider logProvider, ILogContainer logContainer)
    {
      InitializeComponent();

      mLogcontainer = logContainer;
      mBookmarks    = new List<LogMessage>();
      InitializeColumns(logProvider);

      if (!logProvider.HasLoggerTree)
      {
        // Remove the synchronize tree menu item if no tree is available.
        cmLogMessage.Items.Remove(cmsSynchronizeTree);
        cmLogMessage.Items.Remove(cmsSeperator);
      }

      ThemeManager.ApplyTo(this);

      if (!string.IsNullOrEmpty(Settings.Default.LogMessagesFontName))
      {
        try
        {
          dtgLogMessages.DefaultCellStyle.Font = FontCache.GetFontFromIdentifier(
              Settings.Default.LogMessagesFontName
            , Settings.Default.LogMessagesFontSize
            , FontStyle.Regular);
        }
        catch
        {
          // Reset the font on error.
          dtgLogMessages.Font = FontCache.GetFontFromIdentifier(
              DEFAULT_FONT_NAME
            , DEFAULT_FONT_SIZE
            , FontStyle.Regular);

          mRowHeight = dtgLogMessages.RowTemplate.Height;

          // Save the changed settings as new default.
          Settings.Default.LogMessagesFontName = DEFAULT_FONT_NAME;
          Settings.Default.LogMessagesFontSize = DEFAULT_FONT_SIZE;

          Settings.Default.SaveSettings();
        }
      }

      if (Settings.Default.EnableColorMap)
      {
        tableLayoutPanel1.SetColumnSpan(dtgLogMessages, 1);
        colorMap1.Visible = true;
      }
      else
      {
        colorMap1.Visible = false;
        tableLayoutPanel1.SetColumnSpan(dtgLogMessages, 2);
      }

      // Listening for settings changes.
      Settings.Default.SettingChanging += DefaultSettingChanging;
    }

    #endregion

  }
}
