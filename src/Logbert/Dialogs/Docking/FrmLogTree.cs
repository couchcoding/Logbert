#region Copyright © 2015 Couchcoding

// File:    FrmLogTree.cs
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

using Couchcoding.Logbert.Interfaces;
using Couchcoding.Logbert.Logging;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using Couchcoding.Logbert.Helper;

using WeifenLuo.WinFormsUI.Docking;
using System.Drawing;

using Couchcoding.Logbert.Logging.Filter;
using Couchcoding.Logbert.Theme.Palettes;
using Couchcoding.Logbert.Theme.Interfaces;
using Couchcoding.Logbert.Theme;
using Couchcoding.Logbert.Theme.Themes;

namespace Couchcoding.Logbert.Dialogs.Docking
{
  /// <summary>
  /// Implements the <see cref="DockContent"/> of the logger tree.
  /// </summary>
  public partial class FrmLogTree : DockContent, ILogPresenter, ILogFilterProvider, IThemable
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

    #region Private Delegates

    /// <summary>
    /// Updates the visible <see cref="LogMessage"/>s.
    /// </summary>
    /// <param name="messages">The list of <see cref="LogMessage"/>s to display.</param>
    /// <param name="delta">The count of new <see cref="LogMessage"/>s.</param>
    private delegate void LogMessagesChangedDelegate(List<LogMessage> messages, int delta);

    #endregion

    #region Private Fields

    private readonly ILogFilterHandler mLogFilterHandler;

    private LogFilterLogger mLogFilter;

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

    /// <summary>
    /// Gets all defines <see cref="LogFilter"/> to apply.
    /// </summary>
    public IList<LogFilter> Filter
    {
      get
      {
        return mLogFilter != null 
          ? new List<LogFilter> { mLogFilter } 
          : null;
      }
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Popuplate a <see cref="TreeView"/> by the given <paramref name="path."/> element.
    /// </summary>
    /// <param name="treeView">The <see cref="TreeView"/> to add new <see cref="TreeNode"/>s to.</param>
    /// <param name="path">The path that contains the path value to add.</param>
    private static void PopulateTreeView(TreeView treeView, string path)
    {
      TreeNode lastNode = null;
      string subPathAgg = string.Empty;

      foreach (string subPath in path.Split(new [] { treeView.PathSeparator }, StringSplitOptions.None))
      {
        subPathAgg += subPath + treeView.PathSeparator;

        TreeNode[] nodes = treeView.Nodes.Find(
            subPathAgg
          , true);

        if (nodes.Length == 0)
        {
          lastNode = lastNode == null
            ? treeView.Nodes.Add(subPathAgg, subPath)
            : lastNode.Nodes.Add(subPathAgg, subPath);

          if (lastNode.Parent != null)
          {
            lastNode.ForeColor = ThemeManager.CurrentApplicationTheme.ColorPalette.ContentForeground;
            lastNode.Parent.Expand();
          }
        }
        else
        {
          lastNode = nodes[0];
        }
      }

      if (treeView.Nodes.Count > 0)
      {
        if (treeView.SelectedNode == null)
        {
          // Initial select the very first node popupulated.
          treeView.SelectedNode = treeView.Nodes[0];
        }

        SetNodeColor(treeView.Nodes[0]
          , ThemeManager.CurrentApplicationTheme.ColorPalette.ContentForeground
          , ThemeManager.CurrentApplicationTheme.ColorPalette.SelectionForeground
          , ThemeManager.CurrentApplicationTheme.ColorPalette.SelectionForegroundFocused
          , false);
      }
    }

    /// <summary>
    /// Handles the NodeMouseClick event of the <see cref="TreeView"/>.
    /// <remarks>Ensures the selected node is immediately selected on left or right mouse click.</remarks>
    /// </summary>
    private void TvLoggerTreeNodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
    {
      if (e.Node == null)
      {
        return;
      }

      if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
      {
        tvLoggerTree.SelectedNode = e.Node;
      }
    }

    private static void SetNodeColor(TreeNode startNode, Color nodeColor, Color nodeColorSelected, Color nodeColorSelectedFocused, bool recursive)
    {
      if (startNode != null)
      {
        startNode.ForeColor = startNode.IsSelected 
          ? startNode.TreeView.Focused
            ? nodeColorSelectedFocused
            : nodeColorSelected
          : nodeColor;

        if (recursive)
        {
          foreach (TreeNode childNode in startNode.Nodes)
          {
            SetNodeColor(childNode, nodeColor, nodeColorSelected, nodeColorSelectedFocused, true);
          }
        }
      }
    }

    private void TvLoggerTreeAfterSelect(object sender, TreeViewEventArgs e)
    {
      if (tvLoggerTree.Nodes.Count == 0)
      {
        return;
      }

      try
      {
        SetNodeColor(tvLoggerTree.Nodes[0]
          , ThemeManager.CurrentApplicationTheme.ColorPalette.ContentForegroundDimmed
            , ThemeManager.CurrentApplicationTheme.ColorPalette.SelectionForeground
            , ThemeManager.CurrentApplicationTheme.ColorPalette.SelectionForegroundFocused
          , true);

        if (e.Node != null)
        {
          SetNodeColor(e.Node
            , ThemeManager.CurrentApplicationTheme.ColorPalette.ContentForeground
            , ThemeManager.CurrentApplicationTheme.ColorPalette.SelectionForeground
            , ThemeManager.CurrentApplicationTheme.ColorPalette.SelectionForegroundFocused
            , tsbFilterRecursive.Checked);
        }
      }
      finally
      {
        if (mLogFilterHandler != null)
        {
          mLogFilter = tvLoggerTree.SelectedNode.Parent == null 
            ? null 
            : new LogFilterLogger(e.Node.GetLoggerPath(), tsbFilterRecursive.Checked);

          mLogFilterHandler.FilterChanged();
        }
      }
    }

    private void TsbFilterRecursiveClick(object sender, EventArgs e)
    {
      TvLoggerTreeAfterSelect(
          sender
        , new TreeViewEventArgs(tvLoggerTree.SelectedNode));
    }

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

        ClearAll();
      }

      base.Dispose(disposing);
    }

    /// <summary>
    /// Handles the DockStateChanged event of the <see cref="FrmLogTree"/> dialog.
    /// </summary>
    protected override void OnDockStateChanged(EventArgs e)
    {
      base.OnDockStateChanged(e);

      // Add additional margin to the treeview 
      // depending on the dock state to fix a drawing issue.
      tvLoggerTree.Margin = new Padding(
          DockState == DockState.DockRight ? 1 : 0
        , 0
        , DockState == DockState.DockLeft  ? 1 : 0
        , 0);
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
      if (InvokeRequired)
      {
        LogMessagesChangedDelegate updateDelegate = LogMessagesChanged;
        Invoke(updateDelegate, messages, delta);

        return;
      }

      try
      {
        tvLoggerTree.AfterSelect -= TvLoggerTreeAfterSelect;

        // We are only interessted in the delta, not all log messages.
        List<LogMessage> newLogMessages = delta < 0
          ? messages
          : messages.GetRange(messages.Count - delta, delta);

        foreach (LogMessage message in newLogMessages)
        {
          PopulateTreeView(
              tvLoggerTree
            , Properties.Resources.strLoggerRoot
              + tvLoggerTree.PathSeparator
              + message.Logger);
        }
      }
      finally
      {
        tvLoggerTree.AfterSelect += TvLoggerTreeAfterSelect;
      }
    }

    /// <summary>
    /// Selects the <see cref="LogMessage"/> on the given <paramref name="index"/>.
    /// </summary>
    /// <param name="index">The index of the <see cref="LogMessage"/> to select.</param>
    public bool SelectLogMessage(int index)
    {
      // There is no select message support for the logger tree.
      return true;
    }

    /// <summary>
    /// Selects the given <paramref name="message"/>.
    /// </summary>
    /// <param name="message">The <see cref="LogMessage"/> o select</param>
    public bool SelectLogMessage(LogMessage message)
    {
      // There is no select message support for the logger tree.
      return true;
    }

    /// <summary>
    /// Clears all shown <see cref="LogMessage"/>s.
    /// </summary>
    public void ClearAll()
    {
      tvLoggerTree.Nodes.Clear();
    }

    /// <summary>
    /// Synchronizes the tree to the specified <see cref="LogMessage"/>.
    /// </summary>
    /// <param name="message">The <see cref="LogMessage"/> to synchronize the tree with.</param>
    public void SynchronizeTree(LogMessage message)
    {
      if (message != null && !string.IsNullOrEmpty(message.Logger))
      {
        TreeNode syncNode = GetNodeByFullPath(tvLoggerTree.Nodes[0], string.Format(
            "{0}{1}{2}"
          , Properties.Resources.strLoggerRoot
          , tvLoggerTree.PathSeparator
          , message.Logger));

        if (syncNode != null)
        {
          tvLoggerTree.SelectedNode = syncNode;
        }
      }
    }

    private TreeNode GetNodeByFullPath(TreeNode startNode, string fullPath)
    {
      if (startNode.FullPath.Equals(fullPath))
      {
        return startNode;
      }

      foreach (TreeNode childNode in startNode.Nodes)
      {
        TreeNode node = GetNodeByFullPath(childNode, fullPath);

        if (node != null)
        {
          return node;
        }
      }

      return null;
    }

    /// <summary>
    /// Handles the DrawNode event oft the logger <see cref="TreeView"/>.
    /// </summary>
    private void TvLoggerTreeDrawNode(object sender, DrawTreeNodeEventArgs e)
    {
      e.DrawDefault = false;

      if (e.Node.Bounds.IsEmpty)
      {
        return;
      }

      Rectangle bounds = new Rectangle(
          0
        , e.Node.Bounds.Y
        , Width - 1
        , e.Node.Bounds.Height - 1);

        e.Graphics.FillRectangle(
            GdiCache.GetBrushFromColor(ThemeManager.CurrentApplicationTheme.ColorPalette.ContentBackground)
          , bounds);

      DrawNodeFocusedHighlight(e, bounds);
      DrawPlusMinus(e);
      DrawNodeText(e);
    }

    private void DrawNodeFocusedHighlight(DrawTreeNodeEventArgs e, Rectangle bounds)
    {
      if ((e.State & TreeNodeStates.Selected) != TreeNodeStates.Selected)
      {
        return;
      }

      int scrollWidth = tvLoggerTree.IsVerticalScrollbarvisible() 
        ? SystemInformation.VerticalScrollBarWidth 
        : 0;

      Brush nodeBackgroundBrush = (e.State & TreeNodeStates.Focused) == TreeNodeStates.Focused
        ? GdiCache.GetBrushFromColor(ThemeManager.CurrentApplicationTheme.ColorPalette.SelectionBackgroundFocused)
        : GdiCache.GetBrushFromColor(ThemeManager.CurrentApplicationTheme.ColorPalette.SelectionBackground);

      e.Graphics.FillRectangle(nodeBackgroundBrush, bounds);
    }

    private void DrawPlusMinus(DrawTreeNodeEventArgs e)
    {
      if (e.Node.Nodes.Count == 0)
      {
        return;
      }

      int indent   = (e.Node.Level * tvLoggerTree.Indent) + tvLoggerTree.Margin.Size.Width;
      int iconLeft = indent + tvLoggerTree.Indent;

      Image img = e.Node.IsExpanded 
        ? ThemeManager.CurrentApplicationTheme.Resources.Images["FrmLogTreeNodeExpanded"]
        : ThemeManager.CurrentApplicationTheme.Resources.Images["FrmLogTreeNodeCollapsed"];

      e.Graphics.DrawImage(img
        , iconLeft - img.Width - 2
        , (e.Bounds.Y + (e.Bounds.Height >> 1)) - (img.Height >> 1) - 1);
    }

    private void DrawNodeText(DrawTreeNodeEventArgs e)
    {
      if (e.Node.Bounds.IsEmpty)
      {
        return;
      }

      Rectangle bounds = e.Node.Bounds;

      Font font = FontCache.GetFontFromIdentifier(
          tvLoggerTree.Font.Name
        , tvLoggerTree.Font.Size
        , tvLoggerTree.Font.Style);

      bounds.Width = TextRenderer.MeasureText(e.Node.Text, font).Width;
      bounds.Y -= 1;
      bounds.X += 1;

      if (e.Node.Level == 0 && e.Node.Parent == null)
      {
        bounds = new Rectangle(
            tvLoggerTree.Margin.Size.Width + ThemeManager.CurrentApplicationTheme.Resources.Images["FrmLogTreeNodeExpanded"].Width + 9
          , 0
          , bounds.Width
          , bounds.Height);
      }

      TextRenderer.DrawText(e.Graphics, e.Node.Text, font, bounds, e.Node.ForeColor);
    }

    /// <summary>
    /// Handles the Dispose event oft the logger <see cref="TreeView"/>.
    /// </summary>
    private void TvLoggerTreeDisposed(object sender, EventArgs e)
    {
      tvLoggerTree.DrawNode -= TvLoggerTreeDrawNode;
      tvLoggerTree.MouseDown-= TvLoggerTreeMouseDown;
      tvLoggerTree.Disposed -= TvLoggerTreeDisposed;
    }

    /// <summary>
    /// Increases the size of the <see cref="ILogPresenter"/> content.
    /// </summary>
    /// <returns><c>True</c> if further increasing is possible, otherwise <c>false</c>.</returns>
    public bool ZoomIn()
    {
      if (tvLoggerTree.Font.Size < MAX_ZOOM_LEVEL)
      {
        try
        {
          tvLoggerTree.SuspendDrawing();

          tvLoggerTree.Font = FontCache.GetFontFromIdentifier(
              Font.Name
            , tvLoggerTree.Font.Size + 1
            , FontStyle.Regular);

          return tvLoggerTree.Font.Size < MAX_ZOOM_LEVEL;
        }
        finally
        {
          tvLoggerTree.ResumeDrawing();
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
      if (tvLoggerTree.Font.Size > MIN_ZOOM_LEVEL)
      {
        try
        {
          tvLoggerTree.SuspendDrawing();

          tvLoggerTree.Font = FontCache.GetFontFromIdentifier(
              Font.Name
            , tvLoggerTree.Font.Size - 1
            , FontStyle.Regular);

          return tvLoggerTree.Font.Size > MIN_ZOOM_LEVEL;
        }
        finally
        {
          tvLoggerTree.ResumeDrawing();
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
      tsbFilterRecursive.Image = theme.Resources.Images["FrmMainTbFilter"];
      tsbZoomIn.Image          = theme.Resources.Images["FrmMainTbZoomIn"];
      tsbZoomOut.Image         = theme.Resources.Images["FrmMainTbZoomOut"];

      if (theme.Metrics.PreferSystemRendering)
      {
        tvLoggerTree.UseNativeSystemRendering(false);
      }
      else
      {
        tvLoggerTree.HotTracking = false;

        tvLoggerTree.DrawMode  = TreeViewDrawMode.OwnerDrawAll;
        tvLoggerTree.BackColor = theme.ColorPalette.ContentBackground;
        tvLoggerTree.ForeColor = theme.ColorPalette.ContentForeground;

        tvLoggerTree.DrawNode  += TvLoggerTreeDrawNode;
        tvLoggerTree.MouseDown += TvLoggerTreeMouseDown;
        tvLoggerTree.Disposed  += TvLoggerTreeDisposed;

        tvLoggerTree.NodeMouseClick -= TvLoggerTreeNodeMouseClick;
      }
    }

    private void TvLoggerTreeMouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
      {
        TreeNode node = tvLoggerTree.GetNodeAt(e.X, e.Y);

        if (node != null)
        {
          tvLoggerTree.SelectedNode = node;
        }
      }
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Creates a new instance of the <see cref="FrmLogTree"/> window.
    /// </summary>
    /// <param name="filterHandler">The <see cref="ILogFilterHandler"/> that handles changed filter settings.</param>
    /// <param name="loggerPathSeperator">The path seperator for <see cref="LogMessage"/>s to build the tree from.</param>
    public FrmLogTree(ILogFilterHandler filterHandler, string loggerPathSeperator)
    {
      InitializeComponent();

      // Apply the current application theme to the control.
      ThemeManager.ApplyTo(this);

      mLogFilterHandler = filterHandler;
      Font              = SystemFonts.MessageBoxFont;

      if (mLogFilterHandler != null)
      {
        // Register the tree as log provider.
        filterHandler.RegisterFilterProvider(this);
      }

      tvLoggerTree.PathSeparator = loggerPathSeperator;
    }

    #endregion
  }
}
