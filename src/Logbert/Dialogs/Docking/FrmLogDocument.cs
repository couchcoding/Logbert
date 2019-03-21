#region Copyright © 2015 Couchcoding

// File:    FrmLogDocument.cs
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
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using Couchcoding.Logbert.Helper;
using Couchcoding.Logbert.Interfaces;
using Couchcoding.Logbert.Logging;
using Couchcoding.Logbert.Logging.Filter;
using Couchcoding.Logbert.Properties;

using WeifenLuo.WinFormsUI.Docking;
using Couchcoding.Logbert.Theme.Interfaces;
using Couchcoding.Logbert.Theme;
using Couchcoding.Logbert.Theme.Themes;

namespace Couchcoding.Logbert.Dialogs.Docking
{
  /// <summary>
  /// Implements the main <see cref="DockContent"/> for the logger windows.
  /// </summary>
  public partial class FrmLogDocument : DockContent, ILogHandler, ILogContainer, ILogFilterProvider, ISearchable, IThemable
  {
    #region Private Fields

    /// <summary>
    /// The <see cref="DockContent"/> that shows the <see cref="LogMessage"/>s.
    /// </summary>
    private readonly DockContent mLogWindow;

    /// <summary>
    /// The <see cref="DockContent"/> that shows details of a selected <see cref="LogMessage"/>.
    /// </summary>
    private readonly DockContent mMessageDetails;

    /// <summary>
    /// The <see cref="DockContent"/> that shows the logger tree.
    /// </summary>
    private readonly DockContent mLoggerTree;

    /// <summary>
    /// The <see cref="DockContent"/> that shows bookmarks.
    /// </summary>
    private readonly DockContent mBookmarks;

    /// <summary>
    /// The <see cref="DockContent"/> that shows statistic data.
    /// </summary>
    private readonly DockContent mLogStatistic;

    /// <summary>
    /// The <see cref="DockContent"/> that shows filter settings.
    /// </summary>
    private readonly DockContent mFilter;

    /// <summary>
    /// The <see cref="DockContent"/> for scripting.
    /// </summary>
    private readonly DockContent mLogScript;

    /// <summary>
    /// The <see cref="ILogProvider"/> instance.
    /// </summary>
    private readonly ILogProvider mLogProvider;

    /// <summary>
    /// Holds all received <see cref="LogMessage"/>s.
    /// </summary>
    private readonly List<LogMessage> mLogMessages = new List<LogMessage>(); 

    /// <summary>
    /// A <see cref="ReaderWriterLockSlim"/> to access the list of <see cref="LogMessage"/>s.
    /// </summary>
    private readonly ReaderWriterLockSlim mLogMessageLock = new ReaderWriterLockSlim();

    /// <summary>
    /// Holds the index of the last logged <see cref="LogMessage"/>.
    /// </summary>
    private int mLastLogMessageIndex = 0;

    /// <summary>
    /// The global timeshift value to set for all <see cref="LogMessage"/>s.
    /// </summary>
    private TimeSpan mTimeShiftValue;

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets the received <see cref="LogMessage"/>s.
    /// </summary>
    public List<LogMessage> LogMessages
    {
      get
      {
        mLogMessageLock.EnterReadLock();

        try
        {
          return mLogMessages;
        }
        finally
        {
          mLogMessageLock.ExitReadLock();
        }
      }
    }

    /// <summary>
    /// Gets the current active <see cref="LogLevel"/>s.
    /// Gets or sets the loggin state of the <see cref="ILogHandler"/>.
    /// </summary>
    public bool Active
    {
      get
      {
        return tsbStartPause.Checked;
      }
      set
      {
        tsbStartPause.Checked = value;
      }
    }

    /// <summary>
    /// Gets all defines <see cref="LogFilter"/> to apply.
    /// </summary>
    public IList<LogFilter> Filter
    {
      get
      {
        LogLevel currentLevel = LogLevel.None;

        if (tsbShowTrace.Checked)
        {
          currentLevel |= LogLevel.Trace;
        }

        if (tsbShowDebug.Checked)
        {
          currentLevel |= LogLevel.Debug;
        }

        if (tsbShowInfo.Checked)
        {
          currentLevel |= LogLevel.Info;
        }

        if (tsbShowWarn.Checked)
        {
          currentLevel |= LogLevel.Warning;
        }

        if (tsbShowError.Checked)
        {
          currentLevel |= LogLevel.Error;
        }

        if (tsbShowFatal.Checked)
        {
          currentLevel |= LogLevel.Fatal;
        }

        return new List<LogFilter>
        {
          new LogFilterLevel(currentLevel)
        };
      }
    }

    /// <summary>
    /// Gets or sets the tail state.
    /// </summary>
    public bool TailEnabled
    {
      get
      {
        return tsbTraceLastMessage.Checked;
      }
      set
      {
        tsbTraceLastMessage.Checked = value;
      }
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Initializes the default docking layout.
    /// </summary>
    private void InitializeDefaultLayout()
    {
      mLogWindow?.Show(LogDockPanel,      DockState.Document);
      mLogScript?.Show(LogDockPanel,      DockState.Document);
      mMessageDetails?.Show(LogDockPanel, DockState.DockBottom);
      mBookmarks?.Show(LogDockPanel,      DockState.DockBottom);
      mFilter?.Show(LogDockPanel,         DockState.DockBottom);
      mLogStatistic?.Show(LogDockPanel,   DockState.DockBottom);
      mLoggerTree?.Show(LogDockPanel,     DockState.DockRight);

      mMessageDetails?.Activate();
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Form.Load"/> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data. </param>
    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      using (new WaitCursor(Cursors.Default, Settings.Default.WaitCursorTimeout))
      {
        try
        {
          if (mLogProvider != null && ModifierKeys != Keys.Shift)
          {
            string previousLayout = mLogProvider.LoadLayout();

            if (!string.IsNullOrEmpty(previousLayout))
            {
              using (MemoryStream memStream = new MemoryStream(Encoding.UTF8.GetBytes(previousLayout)))
              {
                LogDockPanel.LoadFromXml(
                    memStream
                  , GetContentFromPersistString);
              }
            }
            else
            {
              InitializeDefaultLayout();
            }
          }
          else
          {
            InitializeDefaultLayout();
          }

          tsbShowMessageDetails.Checked = mMessageDetails != null && !mMessageDetails.IsHidden;
          tsbShowLoggerTree.Checked     = mLoggerTree     != null && !mLoggerTree.IsHidden; 
          tsbShowBookmarks.Checked      = mBookmarks      != null && !mBookmarks.IsHidden;
          tsbShowFilter.Checked         = mFilter         != null && !mFilter.IsHidden;
          tsbShowStatistic.Checked      = mLogStatistic   != null && !mLogStatistic.IsHidden;

          if (mLogProvider != null)
          {
            mLogProvider.Initialize(this);

            tsbShowTrace.Available = (mLogProvider.SupportedLevels & LogLevel.Trace)   != 0;
            tsbShowDebug.Available = (mLogProvider.SupportedLevels & LogLevel.Debug)   != 0;
            tsbShowInfo.Available  = (mLogProvider.SupportedLevels & LogLevel.Info)    != 0;
            tsbShowWarn.Available  = (mLogProvider.SupportedLevels & LogLevel.Warning) != 0;
            tsbShowError.Available = (mLogProvider.SupportedLevels & LogLevel.Error)   != 0;
            tsbShowFatal.Available = (mLogProvider.SupportedLevels & LogLevel.Fatal)   != 0;

            if (mLogProvider.SupportedLevels == LogLevel.None)
            {
              tslLogLevel.Available = false;
              tssLogLevel.Available = false;

              tsbStartPause.Margin = new Padding(
                  SystemInformation.Border3DSize.Width
                , tsbStartPause.Margin.Top
                , tsbStartPause.Margin.Right
                , tsbStartPause.Margin.Bottom);
            }

            tsbReload.Available = mLogProvider.SupportsReload;
          }
        }
        finally
        {
          // Register the main document as a filter provider.
          ((ILogFilterHandler)mLogWindow).RegisterFilterProvider(this);

          // Set the initial focus to the log window.
          mLogWindow.Activate();
        }
      }
    }

    /// <summary>
    /// Gets the docking window that matche sthe specified <paramref name="persistString"/> value.
    /// </summary>
    /// <param name="persistString">The full type name of the docking window to restor.</param>
    /// <returns>The <see cref="IDockContent"/> instance to restore, or <c>null</c> if not found.</returns>
    private IDockContent GetContentFromPersistString(string persistString)
    {
      switch (persistString)
      {
        case "Couchcoding.Logbert.Dialogs.Docking.FrmLogWindow":
          return mLogWindow;

        case "Couchcoding.Logbert.Dialogs.Docking.FrmLogScript":
          return mLogScript;

        case "Couchcoding.Logbert.Dialogs.Docking.FrmMessageDetails":
          return mMessageDetails;

        case "Couchcoding.Logbert.Dialogs.Docking.FrmLogBookmarks":
          return mBookmarks;

        case "Couchcoding.Logbert.Dialogs.Docking.FrmLogFilter":
          return mFilter;

        case "Couchcoding.Logbert.Dialogs.Docking.FrmLogTree":
          return mLoggerTree;

        case "Couchcoding.Logbert.Dialogs.Docking.FrmLogStatistic":
          return mLogStatistic;
      }

      Logger.Warn(
          "Unable to restore docking layout for windows type: {0}"
        , persistString);

      return null;
    }

    /// <summary>
    /// Handles the change of <see cref="LogMessage"/>s.
    /// </summary>
    /// <param name="delta">The count of new <see cref="LogMessage"/>s.</param>
    private void LogMessagesChanged(int delta)
    {
      using (new WaitCursor(Cursors.Default, Settings.Default.WaitCursorTimeout))
      {
        List<LogMessage> logMessageCopy;

        try
        {
          mLogMessageLock.EnterReadLock();

          mLastLogMessageIndex = mLogMessages.Count > 0 
            ? mLogMessages[mLogMessages.Count - 1].Index
            : 0;

          // Use a copy of the original list to prevent multiple reader locks.
          logMessageCopy = new List<LogMessage>(mLogMessages.ToArray());
        }
        finally
        {
          mLogMessageLock.ExitReadLock();
        }

        // Update the log presenter windows.
        ((ILogPresenter)mLogWindow).LogMessagesChanged(logMessageCopy,    delta);

        if (mLoggerTree != null)
        {
          ((ILogPresenter)mLoggerTree).LogMessagesChanged(logMessageCopy, delta);
        }

        if (mLogScript != null)
        {
          ((ILogPresenter)mLogScript).LogMessagesChanged(logMessageCopy, delta);
        }

        if (mLogStatistic != null)
        {
          ((ILogPresenter)mLogStatistic).LogMessagesChanged(logMessageCopy, delta);
        }
      }

      if (tsbTraceLastMessage.Checked && mLogMessages.Count > 0)
      {
        // Ensure the last received log message is selected.
        ((ILogPresenter)mLogWindow).SelectLogMessage(mLogMessages.Count - 1);
      }

      UpdateStatusBarInformation();
    }

    /// <summary>
    /// Updates the information display in the <see cref="StatusBar"/>.
    /// </summary>
    public void UpdateStatusBarInformation()
    {
      if (InvokeRequired)
      {
        BeginInvoke(new MethodInvoker(UpdateStatusBarInformation));
        return;
      }

      string dspCount = ((ILogPresenter)mLogWindow).DisplayedLogMessagesCount == mLogMessages.Count
        ? Resources.strDocumentMessageAllDisplayed
        : ((ILogPresenter)mLogWindow).DisplayedLogMessagesCount.ToString();

      stbMessageCount.Text = string.Format(
          Resources.strDocumentMessageCount
        , mLogMessages.Count
        , dspCount);

      stbStatus.Text = mLogProvider != null && mLogProvider.IsActive
        ? Resources.strDocumentStatusRunning
        : Resources.strDocumentStatusStopped;
    }

    /// <summary>
    /// Clear all received logging data.
    /// </summary>
    public void ClearAll()
    {
      mLogMessageLock.EnterWriteLock();

      try
      {
        mLogMessages.Clear();
      }
      finally
      {
        mLogMessageLock.ExitWriteLock();
      }

      if (mLogProvider != null)
      {
        mLogProvider.Clear();
      }

      if (mLoggerTree != null)
      {
        ((ILogPresenter)mLoggerTree).ClearAll();
      }

      if (mMessageDetails != null)
      {
        ((ILogPresenter)mMessageDetails).ClearAll();
      }

      ((ILogPresenter)mLogWindow).ClearAll();
      ((ILogPresenter)mBookmarks).ClearAll();
      ((ILogPresenter)mFilter).ClearAll();
      ((ILogPresenter)mLogScript).ClearAll();
      ((ILogPresenter)mLogStatistic).ClearAll();

      // Force an update of the UI.
      TmrUpdateTick(this, EventArgs.Empty);
    }

    /// <summary>
    /// Synchronizes the tree to the specified <see cref="LogMessage"/>.
    /// </summary>
    /// <param name="message">The <see cref="LogMessage"/> to synchronize the tree with.</param>
    public void SynchronizeTree(LogMessage message)
    {
      if (mLoggerTree != null)
      {
        ((FrmLogTree)mLoggerTree).SynchronizeTree(message);
      }
    }

    /// <summary>
    /// Handles the LogLevelChanged event.
    /// </summary>
    private void LogLevelChanged(object sender, EventArgs e)
    {
      ((ILogFilterHandler)mLogWindow).FilterChanged();
    }

    /// <summary>
    /// Handles the Click event of the reload <see cref="ToolStripButton"/>.
    /// </summary>
    private void TsbReloadClick(object sender, EventArgs e)
    {
      if (mLogProvider != null)
      {
        tsbClearMessages.PerformClick();
        
        mLogProvider.Shutdown();
        mLastLogMessageIndex = 0;
        mLogProvider.Initialize(this);
      }
    }

    /// <summary>
    /// Handles the Click event of the toggle bookmark <see cref="ToolStripButton"/>.
    /// </summary>
    private void TsbToggleBookmarkClick(object sender, EventArgs e)
    {
      LogMessage selLogMessage = ((IBookmarkProvider)mLogWindow).SelectedMessage;

      if (selLogMessage != null)
      {
        if (((IBookmarkProvider)mLogWindow).Bookmarks.Contains(selLogMessage))
        {
          ((IBookmarkProvider)mLogWindow).RemoveBookmarks(new List<LogMessage>(new[] { selLogMessage }));
        }
        else
        {
          ((IBookmarkProvider)mLogWindow).AddBookmarks(new List<LogMessage>(new[] { selLogMessage }));
        }
      }
    }

    /// <summary>
    /// Handles the Click event of the goto first message <see cref="ToolStripButton"/>.
    /// <para>
    /// Selects the very first message in the log window and ensures its visbility.
    /// </para>
    /// </summary>
    private void TsbGotoFirstMessageClick(object sender, EventArgs e)
    {
      ((ILogPresenter)mLogWindow).SelectLogMessage(0);
    }

    /// <summary>
    /// Handles the Click event of the goto last message <see cref="ToolStripButton"/>.
    /// <para>
    /// Selects the last message in the log window and ensures its visbility.
    /// </para>
    /// </summary>
    private void TsbGotoLastMessageClick(object sender, EventArgs e)
    {
      if (mLogMessages.Count > 0)
      {
        ((ILogPresenter)mLogWindow).SelectLogMessage(mLogMessages[mLogMessages.Count - 1]);
      }
    }

    /// <summary>
    /// Handles the Click event of the show message details <see cref="ToolStripButton"/>.
    /// <para>
    /// Shows or hides the message details window.
    /// </para>
    /// </summary>
    private void TsbShowMessageDetailsClick(object sender, EventArgs e)
    {
      if (mMessageDetails != null)
      {
        if (tsbShowMessageDetails.Checked)
        {
          mMessageDetails.Show(LogDockPanel);
        }
        else
        {
          mMessageDetails.Hide();
        }
      }
    }

    /// <summary>
    /// Handles the Click event of the show logger tree <see cref="ToolStripButton"/>.
    /// <para>
    /// Shows or hides the logger tree window.
    /// </para>
    /// </summary>
    private void TsbShowLoggerTreeClick(object sender, EventArgs e)
    {
      if (mLoggerTree != null)
      {
        if (tsbShowLoggerTree.Checked)
        {
          mLoggerTree.Show(LogDockPanel);
        }
        else
        {
          mLoggerTree.Hide();
        }
      }
    }

    /// <summary>
    /// Handles the Click event of the show bookmarks <see cref="ToolStripButton"/>.
    /// <para>
    /// Shows or hides the bookmarks window.
    /// </para>
    /// </summary>
    private void TsbShowBookmarksClick(object sender, EventArgs e)
    {
      if (mBookmarks != null)
      {
        if (tsbShowBookmarks.Checked)
        {
          mBookmarks.Show(LogDockPanel);
        }
        else
        {
          mBookmarks.Hide();
        }
      }
    }

    /// <summary>
    /// Handles the Click event of the show filter <see cref="ToolStripButton"/>.
    /// <para>
    /// Shows or hides the filter window.
    /// </para>
    /// </summary>
    private void TsbShowFilterClick(object sender, EventArgs e)
    {
      if (mFilter != null)
      {
        if (tsbShowFilter.Checked)
        {
          mFilter.Show(LogDockPanel);
        }
        else
        {
          mFilter.Hide();
        }
      }
    }

    /// <summary>
    /// Handles the Click event of the show statistic <see cref="ToolStripButton"/>.
    /// <para>
    /// Shows or hides the statistic window.
    /// </para>
    /// </summary>
    private void TsbShowStatisticClick(object sender, EventArgs e)
    {
      if (mLogStatistic != null)
      {
        if (tsbShowStatistic.Checked)
        {
          mLogStatistic.Show(LogDockPanel);
        }
        else
        {
          mLogStatistic.Hide();
        }
      }
    }

    /// <summary>
    /// Handles the Click event of the start, stop <see cref="ToolStripButton"/>.
    /// <para>
    /// Starts or stops the life logging.
    /// </para>
    /// </summary>
    private void TsbStartPauseCheckedChanged(object sender, EventArgs e)
    {
      if (mLogProvider != null)
      {
        mLogProvider.IsActive = tsbStartPause.Checked;
      }

      UpdateStatusBarInformation();
    }

    /// <summary>
    /// Handles the Click event of the zoom in <see cref="ToolStripButton"/>.
    /// <para>
    /// Increases the <see cref="Font"/> size of the <see cref="LogMessage"/>s list
    /// </para>
    /// </summary>
    private void TsbZoomInClick(object sender, EventArgs e)
    {
      bool futherZoomInPossible = ((ILogPresenter)mLogWindow).ZoomIn();

      tsbZoomIn.Enabled  = futherZoomInPossible;
      tsbZoomOut.Enabled = true;
    }

    /// <summary>
    /// Handles the Click event of the zoom out <see cref="ToolStripButton"/>.
    /// <para>
    /// Decreases the <see cref="Font"/> size of the <see cref="LogMessage"/>s list
    /// </para>
    /// </summary>
    private void TsbZoomOutClick(object sender, EventArgs e)
    {
      bool futherZoomOutPossible = ((ILogPresenter)mLogWindow).ZoomOut();

      tsbZoomIn.Enabled  = true;
      tsbZoomOut.Enabled = futherZoomOutPossible;
    }

    /// <summary>
    /// Handles the Click event of the timeshift <see cref="ToolStripButton"/>.
    /// </summary>
    private void TsbTimeShiftClick(object sender, EventArgs e)
    {
      txtTimeShift.Enabled     = tsbTimeShift.Checked;
      tsbTimeShiftUnit.Enabled = tsbTimeShift.Checked;

      SetTimeshiftValue();
    }

    /// <summary>
    /// Handles the Tick event of the UI update time.
    /// </summary>
    private void TmrUpdateTick(object sender, EventArgs e)
    {
      if (mLogMessages.Count > 0)
      {
        // Get the very last received and processed log message.
        LogMessage lastLogMsg = mLogMessages[mLogMessages.Count -1];

        if (lastLogMsg != null && lastLogMsg.Index != mLastLogMessageIndex)
        {
          tmrUpdate.Stop();

          try
          {
            LogMessagesChanged(mLogMessages.Count - mLastLogMessageIndex);
          }
          finally
          {
            tmrUpdate.Start();
          }
        }
      }
    }

    /// <summary>
    /// Handles the Click event of the clear messages <see cref="ToolStripButton"/>.
    /// </summary>
    private void TsbClearMessagesClick(object sender, EventArgs e)
    {
      ClearAll();
    }

    /// <summary>
    /// Handles the OnMessageSelected event of the <see cref="LogMessage"/> window.
    /// </summary>
    private void OnLogMessageSelected(object sender, LogMessageSelectedEventArgs e)
    {
      if (mMessageDetails != null)
      {
        ((ILogPresenter)mMessageDetails).SelectLogMessage(e.Message);
      }

      if (mBookmarks != null)
      {
        ((ILogPresenter)mBookmarks).SelectLogMessage(e.Message);
      }

      if (mFilter != null)
      {
        ((ILogPresenter)mFilter).SelectLogMessage(e.Message);
      }

      tsbToggleBookmark.Enabled = e.Message != null;
    }

    /// <summary>
    /// Writes the given <paramref name="data"/> into the given <paramref name="fileName"/>.
    /// </summary>
    /// <param name="fileName">The file name to save the data into.</param>
    /// <param name="data">The <see cref="StringBuilder"/> that contains the data to write.</param>
    /// <returns><c>True</c> on success, otherwise <c>false</c>.</returns>
    private bool WriteToFile(string fileName, StringBuilder data)
    {
      try
      {
        using (StreamWriter outfile = new StreamWriter(fileName))
        {
          outfile.Write(data);
              
          outfile.Flush();
          outfile.Close();
        }
      }
      catch (Exception ex)
      {
        // Inform the use about the error and provide an option to retry.
        DialogResult retryResult = MessageBox.Show(string.Format(
            Resources.strSaveLogErrorOccured, ex.Message)
          , Application.ProductName
          , MessageBoxButtons.RetryCancel
          , MessageBoxIcon.Error);
        
        return retryResult == DialogResult.Retry && WriteToFile(fileName, data);
      }

      return true;
    }

    /// <summary>
    /// Handles the Click event of the save as text <see cref="ContextMenu"/>.
    /// </summary>
    private void CmsSaveMessagesTextClick(object sender, EventArgs e)
    {
      if (mLogProvider == null)
      {
        // This should never happen!
        return;
      }

      using (SaveFileDialog sfDlg = new SaveFileDialog())
      {
        sfDlg.Filter           = Resources.strSaveLogToTextFilePattern;
        sfDlg.FilterIndex      = 2;
        sfDlg.RestoreDirectory = true;

        sfDlg.FileName = mLogProvider != null 
          ? mLogProvider.ExportFileName 
          : Resources.strSaveLogDefaultName;

        if (sfDlg.ShowDialog(this) == DialogResult.OK)
        {
          using (new WaitCursor(Cursors.Default, Settings.Default.WaitCursorTimeout))
          {
            StringBuilder logData = new StringBuilder();

            // Don't use the member variable to ensure the list ist locked.
            foreach (LogMessage logMsg in LogMessages)
            {
              logData.AppendLine(logMsg.ToString());
            }

            WriteToFile(sfDlg.FileName, logData);
          }
        }
      }
    }

    /// <summary>
    /// Handles the Click event of the save as CSV <see cref="ContextMenu"/>.
    /// </summary>
    private void CmsSaveMessagesCsvClick(object sender, EventArgs e)
    {
      if (mLogProvider == null)
      {
        // This should never happen!
        return;
      }

      using (SaveFileDialog sfDlg = new SaveFileDialog())
      {
        sfDlg.Filter           = Resources.strSaveLogToCSVFilePattern;
        sfDlg.FilterIndex      = 2;
        sfDlg.RestoreDirectory = true;

        sfDlg.FileName = mLogProvider != null 
          ? mLogProvider.ExportFileName 
          : Resources.strSaveLogDefaultName;

        if (sfDlg.ShowDialog(this) == DialogResult.OK)
        {
          using (new WaitCursor(Cursors.Default, Settings.Default.WaitCursorTimeout))
          {
            StringBuilder logData = new StringBuilder(mLogProvider.GetCsvHeader());

            foreach (LogMessage logMsg in LogMessages)
            {
              logData.AppendLine(logMsg.GetCsvLine());
            }

            WriteToFile(sfDlg.FileName, logData);
          }
        }
      }
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

        if (mLogProvider != null)
        {
          // Shutdown the logger functionality.
          mLogProvider.Shutdown();

          try
          {
            // Save the current docking layout.
            using (MemoryStream memStream = new MemoryStream())
            {
              LogDockPanel.SaveAsXml(
                  memStream
                , Encoding.UTF8);

              memStream.Flush();

              memStream.Seek(
                  0
                , SeekOrigin.Begin);

              if (memStream.Length > 0)
              {
                mLogProvider.SaveLayout(
                    Encoding.UTF8.GetString(memStream.ToArray())
                  , ((FrmLogWindow)mLogWindow).GetColumnLayout());
              }
            }
          }
          catch (Exception ex)
          {
            Logger.Error(
                "An error occured while saving the current docking layout: {0}"
              , ex.Message);
          }
        }

        if (tmrUpdate != null && tmrUpdate.Enabled)
        {
          tmrUpdate.Tick -= TmrUpdateTick;

          tmrUpdate.Stop();
          tmrUpdate.Dispose();
        }

        ((ILogFilterHandler)mLogWindow).UnregisterFilterProvider(this);
        ((FrmLogWindow)mLogWindow).OnLogMessageSelected -= OnLogMessageSelected;

        mLogMessages?.Clear();
      }

      base.Dispose(disposing);
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Form.Shown"/> event.
    /// </summary>
    /// <param name="e">A <see cref="T:System.EventArgs"/> that contains the event data. </param>
    protected override void OnShown(EventArgs e)
    {
      base.OnShown(e);

      tmrUpdate.Interval = Settings.Default.UiRefreshIntervalMs;
      tmrUpdate.Tick += TmrUpdateTick;
      
      tmrUpdate.Start();
    }

    /// <summary>
    /// Handles the Validate event of the timeshift <see cref="TextBox"/>.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TxtTimeShiftValidated(object sender, EventArgs e)
    {
      SetTimeshiftValue();
    }

    /// <summary>
    /// Sets a new timeshift value to the <see cref="LogMessage"/>s.
    /// </summary>
    /// <param name="newValue"></param>
    private void SetTimeshiftValue()
    {
      if (!int.TryParse(txtTimeShift.Text.Trim(), out int newValue))
      {
        txtTimeShift.Text = ((int)Settings.Default.TimeShiftValue).ToString();
        return;
      }

      mTimeShiftValue = new TimeSpan(0);

      switch (Settings.Default.TimeShiftUnitIndex)
      {
        case 0:
          tsbTimeShiftUnit.Text = tsbTimeShiftUnitMillisecond.Text;
          break;
        case 1:
          tsbTimeShiftUnit.Text = tsbTimeShiftUnitSecond.Text;
          break;
        case 2:
          tsbTimeShiftUnit.Text = tsbTimeShiftUnitMinute.Text;
          break;
        case 3:
          tsbTimeShiftUnit.Text = tsbTimeShiftUnitHour.Text;
          break;
        case 4:
          tsbTimeShiftUnit.Text = tsbTimeShiftUnitDay.Text;
          break;
      }

      if (tsbTimeShift.Checked)
      {
        switch (Settings.Default.TimeShiftUnitIndex)
        {
          case 0:
            mTimeShiftValue = new TimeSpan(0, 0, 0, 0, newValue);
            tsbTimeShiftUnit.Text = tsbTimeShiftUnitMillisecond.Text;
            break;
          case 1:
            mTimeShiftValue = new TimeSpan(0, 0, 0, newValue, 0);
            tsbTimeShiftUnit.Text = tsbTimeShiftUnitSecond.Text;
            break;
          case 2:
            mTimeShiftValue = new TimeSpan(0, 0, newValue, 0, 0);
            tsbTimeShiftUnit.Text = tsbTimeShiftUnitMinute.Text;
            break;
          case 3:
            mTimeShiftValue = new TimeSpan(0, newValue, 0, 0, 0);
            tsbTimeShiftUnit.Text = tsbTimeShiftUnitHour.Text;
            break;
          case 4:
            mTimeShiftValue = new TimeSpan(newValue, 0, 0, 0, 0);
            tsbTimeShiftUnit.Text = tsbTimeShiftUnitDay.Text;
            break;
        }

        if (Settings.Default.TimeShiftValue != mTimeShiftValue.TotalMilliseconds)
        {
          Settings.Default.TimeShiftValue = mTimeShiftValue.TotalMilliseconds;
          Settings.Default.SaveSettings();
        }
      }

      using (new WaitCursor())
      {
        mLogMessageLock.EnterWriteLock();

        try
        {
          // Update the timeshift offset value.
          foreach (LogMessage logMsg in mLogMessages)
          {
            logMsg.TimeShiftOffset = mTimeShiftValue;
          }
        }
        finally
        {
          mLogMessageLock.ExitWriteLock();
        }

        ((ILogFilterHandler)mLogWindow).FilterChanged();
      }

    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Update the value of the UI update timer interval.
    /// </summary>
    /// <param name="newTimerInterval">The new value for the UI update time.</param>
    public void UpdateTimerInterval(int newTimerInterval)
    {
      if (newTimerInterval > 0 && newTimerInterval != tmrUpdate.Interval)
      {
        tmrUpdate.Stop();

        try
        {
          tmrUpdate.Interval = newTimerInterval;
        }
        finally
        {
          tmrUpdate.Start();
        }
      }
    }

    /// <summary>
    /// Handles the given <paramref name="logMsgs"/> <see cref="LogMessage"/>s.
    /// </summary>
    /// <param name="logMsgs">The <see cref="Array"/> of <see cref="LogMessage"/>s to handle.</param>
    public void HandleMessage(LogMessage[] logMsgs)
    {
      mLogMessageLock.EnterWriteLock();

      try
      {
        foreach (LogMessage logMsg in logMsgs)
        {
          // Always set the current timeshift value.
          logMsg.TimeShiftOffset = mTimeShiftValue;
        }

        mLogMessages.AddRange(logMsgs);

        if (Settings.Default.MaxLogMessages > 0 && mLogMessages.Count > Settings.Default.MaxLogMessages)
        {
          // Remove from the first posotion on.
          mLogMessages.RemoveRange(
              0
            , mLogMessages.Count - Settings.Default.MaxLogMessages);
        }
      }
      finally
      {
        mLogMessageLock.ExitWriteLock();
      }
    }

    /// <summary>
    /// Handles the given <paramref name="logMsg"/> <see cref="LogMessage"/>.
    /// </summary>
    /// <param name="logMsg">The <see cref="LogMessage"/> to handle.</param>
    public void HandleMessage(LogMessage logMsg)
    {
      mLogMessageLock.EnterWriteLock();

      try
      {
        // Always set the current timeshift value.
        logMsg.TimeShiftOffset = mTimeShiftValue;

        mLogMessages.Add(logMsg);

        if (Settings.Default.MaxLogMessages > 0 && mLogMessages.Count > Settings.Default.MaxLogMessages)
        {
          // Remove from the first posotion on.
          mLogMessages.RemoveRange(
              0
            , mLogMessages.Count - Settings.Default.MaxLogMessages);
        }
      }
      finally
      {
        mLogMessageLock.ExitWriteLock();
      }
    }

    /// <summary>
    /// Search for a <see cref="LogMessage"/> that contains the given <paramref name="pattern"/>.
    /// </summary>
    /// <param name="pattern">The patter to search for.</param>
    /// <param name="searchForward">Determines the search direction.</param>
    /// <param name="searchAllDocuments">Determines whether in all open <see cref="ISearchable"/>s should be searched, or not.</param>
    public void SearchLogMessage(string pattern, bool searchForward = true, bool searchAllDocuments = false)
    {
      if (string.IsNullOrEmpty(pattern))
      {
        // Nothing to search for.
        return;
      }

      ISearchable searchable = mLogWindow as ISearchable;

      if (searchable != null)
      {
        searchable.SearchLogMessage(
           pattern
         , searchForward
         , searchAllDocuments);
      }
    }

    /// <summary>
    /// Applies the current theme to the <see cref="Control"/>.
    /// </summary>
    /// <param name="theme">The <see cref="BaseTheme"/> instance to apply.</param>
    public void ApplyTheme(BaseTheme theme)
    {
      txtTimeShift.BackColor = theme.ColorPalette.ContentBackground;
      txtTimeShift.ForeColor = theme.ColorPalette.ContentForeground;

      tsbShowTrace.Image          = theme.Resources.Images["FrmMainTbTrace"];
      tsbShowDebug.Image          = theme.Resources.Images["FrmMainTbDebug"];
      tsbShowInfo.Image           = theme.Resources.Images["FrmMainTbInfo"];
      tsbShowWarn.Image           = theme.Resources.Images["FrmMainTbWarn"];
      tsbShowError.Image          = theme.Resources.Images["FrmMainTbError"];
      tsbShowFatal.Image          = theme.Resources.Images["FrmMainTbFatal"];
      tsbStartPause.Image         = theme.Resources.Images["FrmMainTbStart"];
      tsbGotoFirstMessage.Image   = theme.Resources.Images["FrmMainTbTop"];
      tsbGotoLastMessage.Image    = theme.Resources.Images["FrmMainTbBottom"];
      tsbTraceLastMessage.Image   = theme.Resources.Images["FrmMainTbTraceLog"];
      tsbToggleBookmark.Image     = theme.Resources.Images["FrmMainTbBookmark"];
      tsbZoomIn.Image             = theme.Resources.Images["FrmMainTbZoomIn"];
      tsbZoomOut.Image            = theme.Resources.Images["FrmMainTbZoomOut"];
      tsbReload.Image             = theme.Resources.Images["FrmMainTbReload"];
      tsbClearMessages.Image      = theme.Resources.Images["FrmMainTbClear"];
      tsbSaveMessages.Image       = theme.Resources.Images["FrmMainTbSave"];
      tsbShowMessageDetails.Image = theme.Resources.Images["FrmMainTbDetails"];
      tsbShowLoggerTree.Image     = theme.Resources.Images["FrmMainTbLogTree"];
      tsbShowBookmarks.Image      = theme.Resources.Images["FrmMainTbBookmarks"];
      tsbShowFilter.Image         = theme.Resources.Images["FrmMainTbFilter"];
      tsbShowStatistic.Image      = theme.Resources.Images["FrmMainTbStatistic"];
      tsbTimeShift.Image          = theme.Resources.Images["FrmMainTbTimeshift"];
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Creates a new instance of the <see cref="FrmLogDocument"/> window.
    /// </summary>
    /// <param name="logProvider">The <see cref="ILogProvider"/> that sends messages to this window.</param>
    public FrmLogDocument(ILogProvider logProvider)
    {
      InitializeComponent();

      // Apply the current application theme to the control.
      ThemeManager.ApplyTo(this);
      
      mLogProvider = logProvider;
      
      ToolTipText = logProvider != null 
          ? logProvider.Tooltip 
          : string.Empty;

      mLogWindow = new FrmLogWindow(
          mLogProvider
        , this);

      if (mLogProvider != null)
      {
        TabText = mLogProvider.Description;

        if (mLogProvider.HasMessageDetails)
        {
          mMessageDetails = new FrmMessageDetails(mLogProvider);
          mMessageDetails.VisibleChanged += (sender, e) => 
          { 
            tsbShowMessageDetails.Checked = !mMessageDetails.IsHidden; 
          };
        }

        if (mLogProvider.HasLoggerTree)
        {
          mLoggerTree = new FrmLogTree((ILogFilterHandler)mLogWindow, logProvider.LoggerTreePathSeperator);
          mLoggerTree.VisibleChanged += (sender, e) => 
          { 
            tsbShowLoggerTree.Checked = !mLoggerTree.IsHidden;
          };
        }

        tsbShowMessageDetails.Visible = mLogProvider.HasMessageDetails;
        tsbShowLoggerTree.Visible     = mLogProvider.HasLoggerTree;
        tsbShowStatistic.Visible      = mLogProvider.HasStatisticView;
      }
      else
      {
        tsbShowMessageDetails.Visible = false;
        tsbShowLoggerTree.Visible     = false;
        tsSeperatorWindows.Visible    = false;
        tsbShowStatistic.Visible      = false;
      }

      mLogScript = new FrmLogScript((IBookmarkProvider)mLogWindow, this);
      mBookmarks = new FrmLogBookmarks((IBookmarkProvider)mLogWindow);

      if (mLogProvider.HasStatisticView)
      {
        mLogStatistic = new FrmLogStatistic(mLogProvider);

        mLogStatistic.VisibleChanged += (sender, e) =>
        {
          tsbShowStatistic.Checked = !mLogStatistic.IsHidden;
        };

        mBookmarks.VisibleChanged += (sender, e) =>
        {
          tsbShowBookmarks.Checked = !mBookmarks.IsHidden;
        };
      }

      mFilter = new FrmLogFilter(
          logProvider
        , (ILogFilterHandler)mLogWindow);

      mFilter.VisibleChanged += (sender, e) =>
      {
        tsbShowFilter.Checked = !mFilter.IsHidden;
      };

      ((FrmLogWindow)mLogWindow).OnLogMessageSelected += OnLogMessageSelected;

      LogDockPanel.Theme = ThemeManager.CurrentApplicationTheme.DockingTheme;

      SetTimeshiftValue();
    }

    #endregion

    private void tsbTimeShiftUnit_DropDownOpening(object sender, EventArgs e)
    {
      tsbTimeShiftUnitMillisecond.Checked = false;
      tsbTimeShiftUnitSecond.Checked = false;
      tsbTimeShiftUnitMinute.Checked = false;
      tsbTimeShiftUnitHour.Checked = false;
      tsbTimeShiftUnitDay.Checked = false;

      switch (Settings.Default.TimeShiftUnitIndex)
      { 
        case 0:
          tsbTimeShiftUnitMillisecond.Checked = true;
          break;
        case 1:
          tsbTimeShiftUnitSecond.Checked = true;
          break;
        case 2:
          tsbTimeShiftUnitMinute.Checked = true;
          break;
        case 3:
          tsbTimeShiftUnitHour.Checked = true;
          break;
        case 4:
          tsbTimeShiftUnitDay.Checked = true;
          break;
      }
    }

    private void TsbTimeShiftUnitClicked(object sender, EventArgs e)
    {
      switch (((ToolStripItem)sender).Name)
      {
        case "tsbTimeShiftUnitMillisecond":
          Settings.Default.TimeShiftUnitIndex = 0;
          break;
        case "tsbTimeShiftUnitSecond":
          Settings.Default.TimeShiftUnitIndex = 1;
          break;
        case "tsbTimeShiftUnitMinute":
          Settings.Default.TimeShiftUnitIndex = 2;
          break;
        case "tsbTimeShiftUnitHour":
          Settings.Default.TimeShiftUnitIndex = 3;
          break;
        case "tsbTimeShiftUnitDay":
          Settings.Default.TimeShiftUnitIndex = 4;
          break;
      }

      SetTimeshiftValue();
    }
  }
}
