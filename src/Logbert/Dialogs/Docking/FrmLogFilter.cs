#region Copyright © 2015 Couchcoding

// File:    FrmLogFilter.cs
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
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Couchcoding.Logbert.Helper;
using Couchcoding.Logbert.Logging;
using WeifenLuo.WinFormsUI.Docking;
using Couchcoding.Logbert.Interfaces;
using Couchcoding.Logbert.Logging.Filter;
using System;
using Couchcoding.Logbert.Properties;
using Couchcoding.Logbert.Theme.Interfaces;
using Couchcoding.Logbert.Theme;
using Couchcoding.Logbert.Theme.Themes;

namespace Couchcoding.Logbert.Dialogs.Docking
{
  /// <summary>
  /// Implements a <see cref="DockContent"/> to create, configure enable and disable filter.
  /// </summary>
  public partial class FrmLogFilter : DockContent, ILogPresenter, ILogFilterProvider, IThemable
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
    /// The <see cref="ILogFilterHandler"/> that handles changed filter settings.
    /// </summary>
    private readonly ILogFilterHandler mLogFilterHandler;

    /// <summary>
    /// The <see cref="ILogProvider"/> instance to filter for.
    /// </summary>
    private readonly ILogProvider mLogProvider;

    /// <summary>
    /// The one and only <see cref="List{T}"/> of <see cref="LogFilter"/>s of this <see cref="ILogFilterProvider"/>.
    /// </summary>
    private readonly IList<LogFilter> mLogFilter = new List<LogFilter>();

    /// <summary>
    /// The <see cref="Image"/> to use for <see cref=LogFilter"/>s.
    /// </summary>
    private static readonly Image mFilterImage = ThemeManager.CurrentApplicationTheme.Resources.Images["FrmMainTbFilter"];

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
    /// Gets all defines <see cref="LogFilter"/> to apply.
    /// </summary>
    public IList<LogFilter> Filter
    {
      get
      {
        return mLogFilter;
      }
    }

      /// <summary>
    /// Retrieves the current font for this control. This will be the font used by default for painting and text in the control. 
    /// </summary>
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

    #endregion

    #region Private Fields

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        components?.Dispose();

        if (mLogFilterHandler != null)
        {
          mLogFilterHandler.UnregisterFilterProvider(this);
        }

        mLogFilter.Clear();
      }

      base.Dispose(disposing);
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Update the <see cref="DataGridView"/> of <see cref=LogFilter"/>s.
    /// </summary>
    private void UpdateLogFilters()
    {
      if (mLogFilter != null)
      {
        LogFilter selectedFilter = dgvFilter.SelectedRows.Count > 0
          ? dgvFilter.SelectedRows[0].Tag as LogFilter
          : null;

        dgvFilter.SuspendDrawing();

        try
        {
          dgvFilter.Rows.Clear();

          foreach (LogFilterColumn filter in mLogFilter)
          {
            int rowIndex = dgvFilter.Rows.Add(
                mFilterImage
              , filter.IsActive
              , mLogProvider.Columns[filter.ColumnIndex - 1].Name
              , string.Format("{0}{1}{2}", filter.OperatorIndex == 1 
                ? Resources.strFilterNotMatchStartTag 
                : string.Empty, filter.ColumnMatchValueRegEx, filter.OperatorIndex == 1 
                ? Resources.strFilterNotMatchEndTag 
                : string.Empty));

            dgvFilter.Rows[rowIndex].Tag = filter;

            if (Equals(selectedFilter, filter))
            {
              dgvFilter.Rows[rowIndex].Selected = true;
            }
          }
        }
        finally
        {
          dgvFilter.ResumeDrawing();
        }
      }
    }

    /// <summary>
    /// Handles the Click event of the zoom in <see cref="ToolStripItem"/>.
    /// </summary>
    private void TsbZoomInClick(object sender, EventArgs e)
    {
      bool futherZoomInPossible = ZoomIn();

      tsbZoomIn.Enabled  = futherZoomInPossible;
      tsbZoomOut.Enabled = true;
    }

    /// <summary>
    /// Handles the Click event of the zoom out <see cref="ToolStripItem"/>.
    /// </summary>
    private void TsbZoomOutClick(object sender, EventArgs e)
    {
      bool futherZoomOuPossible = ZoomOut();

      tsbZoomOut.Enabled = futherZoomOuPossible;
      tsbZoomIn.Enabled  = true;
    }

    /// <summary>
    /// Handles the Click event of the add filter <see cref="ToolStripItem"/>.
    /// </summary>
    private void TsbAddFilterClick(object sender, EventArgs e)
    {
      using (FrmAddEditFilter addEditFilterDlg = new FrmAddEditFilter(mLogProvider, null))
      {
        if (addEditFilterDlg.ShowDialog(this) == DialogResult.OK)
        {
          LogFilterColumn newLogFilter = new LogFilterColumn(
              addEditFilterDlg.IsFilterActive
            , addEditFilterDlg.ColumnIndex
            , addEditFilterDlg.OperatorIndex
            , addEditFilterDlg.ExpressionRegex);

          mLogFilter.Add(newLogFilter);

          // Update the data grid.
          UpdateLogFilters();

          // Inform the filter handler about the changed filters.
          mLogFilterHandler.FilterChanged();
        }
      }
    }

    /// <summary>
    /// Handles the Click event of the edit filter <see cref="ToolStripItem"/>.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TsbEditFilterClick(object sender, EventArgs e)
    {
      if (dgvFilter.SelectedRows.Count > 0)
      {
        LogFilterColumn filterToEdit = dgvFilter.SelectedRows[0].Tag as LogFilterColumn;

        if (filterToEdit != null)
        {
          using (FrmAddEditFilter addEditFilterDlg = new FrmAddEditFilter(mLogProvider, filterToEdit))
          {
            if (addEditFilterDlg.ShowDialog(this) == DialogResult.OK)
            {
              filterToEdit.Update(
                  addEditFilterDlg.IsFilterActive
                , addEditFilterDlg.ColumnIndex
                , addEditFilterDlg.OperatorIndex
                , addEditFilterDlg.ExpressionRegex);

              // Update the data grid.
              UpdateLogFilters();

              // Inform the filter handler about the changed filters.
              mLogFilterHandler.FilterChanged();
            }
          }
        }
      }
    }

    /// <summary>
    /// Handles the Click event of the remove filter <see cref="ToolStripItem"/>.
    /// </summary>
    private void TsbRemoveFilterClick(object sender, EventArgs e)
    {
      if (dgvFilter.SelectedRows.Count > 0)
      {
        // Remove the filter from the collction.
        mLogFilter.Remove(dgvFilter.SelectedRows[0].Tag as LogFilter);

        // Update the data grid.
        UpdateLogFilters();

        // Inform the filter handler about the changed filters.
        mLogFilterHandler.FilterChanged();
      }
    }

    /// <summary>
    /// Handles the SelectionChanged event of the filter <see cref="DataGridView"/>.
    /// </summary>
    private void DgvFilterSelectionChanged(object sender, EventArgs e)
    {
      bool atLeastOneItemSelected = dgvFilter.SelectedRows.Count > 0;

      tsbRemoveFilter.Enabled = atLeastOneItemSelected;
      tsbEditFilter.Enabled   = atLeastOneItemSelected;
    }

    /// <summary>
    /// Handles the CellDoubleClick event of the filter <see cref="DataGridView"/>.
    /// </summary>
    private void DgvFilterCellCoubleClick(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex >= dgvFilter.RowCount || e.RowIndex < 0 || e.ColumnIndex == 1)
      {
        return;
      }

      // Double click means editing!
      tsbEditFilter.PerformClick();
    }

    /// <summary>
    /// Handles the CellValueChanged event of the filter <see cref=DataGridView"/>.
    /// </summary>
    private void DgvFilterCellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex >= 0 && e.ColumnIndex == 1)
      {
        LogFilterColumn filterToEdit = dgvFilter.Rows[e.RowIndex].Tag as LogFilterColumn;

        if (filterToEdit != null)
        {
          filterToEdit.Update(
              (bool)dgvFilter.Rows[e.RowIndex].Cells[e.ColumnIndex].Value
            , filterToEdit.ColumnIndex
            , filterToEdit.OperatorIndex
            , filterToEdit.ColumnMatchValueRegEx);

          // Update the data grid.
          UpdateLogFilters();

          // Inform the filter handler about the changed filters.
          mLogFilterHandler.FilterChanged();
        }
      }
    }

    /// <summary>
    /// Handles the CurrentCellDirtyStateChanged event of the filter <see cref=DataGridView"/>.
    /// </summary>
    private void DgvFilterCurrentCellDirtyStateChanged(object sender, EventArgs e)
    {
      if (dgvFilter.IsCurrentCellDirty)
      {
        dgvFilter.CommitEdit(DataGridViewDataErrorContexts.Commit);
      }
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Clears all shown <see cref="LogMessage"/>s.
    /// </summary>
    public void ClearAll()
    {
      // Nothing to clear here!
    }

    /// <summary>
    /// Updates the visible <see cref="LogMessage"/>s.
    /// </summary>
    /// <param name="messages">The list of <see cref="LogMessage"/>s to display.</param>
    /// <param name="delta">The count of new <see cref="LogMessage"/>s.</param>
    public void LogMessagesChanged(List<LogMessage> messages, int delta = -1)
    {
      // Nothing to do here.
    }

    /// <summary>
    /// Selects the given <paramref name="message"/>.
    /// </summary>
    /// <param name="message">The <see cref="LogMessage"/> o select</param>
    /// <returns><c>True</c> if the given <paramref name="message"/> was selected successfully, otherwise <c>false</c>.</returns>
    public bool SelectLogMessage(LogMessage message)
    {
      // Nothing to do here.
      return false;
    }

    /// <summary>
    /// Selects the <see cref="LogMessage"/> on the given <paramref name="index"/>.
    /// </summary>
    /// <param name="index">The index of the <see cref="LogMessage"/> to select.</param>
    /// <returns><c>True</c> if the <see cref="LogMessage"/> of the given <paramref name="index"/> was selected successfully, otherwise <c>false</c>.</returns>
    public bool SelectLogMessage(int index)
    {
      // Nothing to do here.
      return false;
    }

    /// <summary>
    /// Increases the size of the <see cref="ILogPresenter"/> content.
    /// </summary>
    /// <returns><c>True</c> if further increasing is possible, otherwise <c>false</c>.</returns>
    public bool ZoomIn()
    {
      if (dgvFilter.Font.Size < MAX_ZOOM_LEVEL)
      {
        try
        {
          dgvFilter.SuspendDrawing();

          dgvFilter.Font = FontCache.GetFontFromIdentifier(
              Font.Name
            , dgvFilter.Font.Size + 1
            , FontStyle.Regular);

          return dgvFilter.Font.Size < MAX_ZOOM_LEVEL;
        }
        finally
        {
          dgvFilter.ResumeDrawing();
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
      if (dgvFilter.Font.Size > MIN_ZOOM_LEVEL)
      {
        try
        {
          dgvFilter.SuspendDrawing();

          dgvFilter.Font = FontCache.GetFontFromIdentifier(
              Font.Name
            , dgvFilter.Font.Size - 1
            , FontStyle.Regular);

          return dgvFilter.Font.Size > MIN_ZOOM_LEVEL;
        }
        finally
        {
          dgvFilter.ResumeDrawing();
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
      tsbAddFilter.Image    = theme.Resources.Images["FrmFilterTbAdd"];
      tsbEditFilter.Image   = theme.Resources.Images["FrmFilterTbEdit"];
      tsbRemoveFilter.Image = theme.Resources.Images["FrmFilterTbRemove"];
      tsbZoomIn.Image       = theme.Resources.Images["FrmMainTbZoomIn"];
      tsbZoomOut.Image      = theme.Resources.Images["FrmMainTbZoomOut"];

      dgvFilter.EnableHeadersVisualStyles             = theme.Metrics.PreferSystemRendering;
      dgvFilter.ColumnHeadersDefaultCellStyle.Padding = theme.Metrics.DataGridViewHeaderColumnPadding;

      dgvFilter.BackgroundColor          = theme.ColorPalette.ContentBackground;
      dgvFilter.ForeColor                = theme.ColorPalette.ContentForeground;
      dgvFilter.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
      dgvFilter.GridColor                = theme.ColorPalette.DividerColor;

      dgvFilter.ColumnHeadersDefaultCellStyle.BackColor = theme.ColorPalette.ContentBackground;
      dgvFilter.ColumnHeadersDefaultCellStyle.ForeColor = theme.ColorPalette.ContentForeground;

      dgvFilter.CellBorderStyle            = DataGridViewCellBorderStyle.Single;
      dgvFilter.DefaultCellStyle.BackColor = theme.ColorPalette.ContentBackground;
      dgvFilter.DefaultCellStyle.ForeColor = theme.ColorPalette.ContentForeground;
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Initializes a new instance of the <see cref="FrmLogFilter"/>.
    /// </summary>
    /// <param name="logProvider">The <see cref=ILogProvider"/> instance to filter for.</param>
    /// <param name="filterHandler">The <see cref="ILogFilterHandler"/> that handles changed filter settings.</param>
    public FrmLogFilter(ILogProvider logProvider, ILogFilterHandler filterHandler)
    {
      InitializeComponent();

      // Apply the current application theme to the control.
      ThemeManager.ApplyTo(this);

      mLogProvider      = logProvider;
      mLogFilterHandler = filterHandler;
      Font              = SystemFonts.MessageBoxFont;

      if (mLogFilterHandler != null)
      {
        mLogFilterHandler.RegisterFilterProvider(this);
      }
    }

    #endregion
  }
}
