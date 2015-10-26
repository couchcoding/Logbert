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

using Com.Couchcoding.Logbert.Helper;
using Com.Couchcoding.Logbert.Logging;
using WeifenLuo.WinFormsUI.Docking;
using Com.Couchcoding.Logbert.Interfaces;
using Com.Couchcoding.Logbert.Logging.Filter;

namespace Com.Couchcoding.Logbert.Dialogs.Docking
{
  /// <summary>
  /// Implements a <see cref="DockContent"/> to create, configure enable and disable filter.
  /// </summary>
  public partial class FrmLogFilter : DockContent, ILogPresenter, ILogFilterProvider
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
    /// Te <see cref="ILogFilterHandler"/> that handles changed filter settings.
    /// </summary>
    private readonly ILogFilterHandler mLogFilterHandler;

    /// <summary>
    /// The one and only <see cref="List{T}"/> of <see cref="LogFilter"/>s of this <see cref="ILogFilterProvider"/>.
    /// </summary>
    private readonly IList<LogFilter> mLogFilter = new List<LogFilter>();

    #endregion

    #region Public Properties

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
      if (disposing && (components != null))
      {
        components.Dispose();
      }

      if (mLogFilterHandler != null)
      {
        mLogFilterHandler.UnregisterFilterProvider(this);
      }

      base.Dispose(disposing);
    }

    #endregion

    #region Private Methods

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
    /// Handles the Click event of the add filter <see cref="ToolStripItem"/>.
    /// </summary>
    private void TsbAddFilterClick(object sender, System.EventArgs e)
    {

    }

    /// <summary>
    /// Handles the Click event of the remove filter <see cref="ToolStripItem"/>.
    /// </summary>
    private void TsbRemoveFilterClick(object sender, System.EventArgs e)
    {

    }

    /// <summary>
    /// Handles the SelectionChanged event of the filter <see cref="DataGridView"/>.
    /// </summary>
    private void DgvFilterSelectionChanged(object sender, System.EventArgs e)
    {

    }

    /// <summary>
    /// Handles the CellDoubleClick event of the filter <see cref="DataGridView"/>.
    /// </summary>
    private void DgvFilterCellCoubleClick(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex >= dgvFilter.RowCount || e.RowIndex < 0)
      {
        return;
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

          dgvFilter.Font = new Font(
              Font.FontFamily
            , dgvFilter.Font.Size + 1);

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

          dgvFilter.Font = new Font(
              Font.FontFamily
            , dgvFilter.Font.Size - 1);

          return dgvFilter.Font.Size > MIN_ZOOM_LEVEL;
        }
        finally
        {
          dgvFilter.ResumeDrawing();
        }
      }

      return false;
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Initializes a new instance of the <see cref="FrmLogFilter"/>.
    /// </summary>
    /// <param name="filterHandler">The <see cref="ILogFilterHandler"/> that handles changed filter settings.</param>
    public FrmLogFilter(ILogFilterHandler filterHandler)
    {
      InitializeComponent();

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
