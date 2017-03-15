#region Copyright © 2017 Couchcoding

// File:    FrmLogStatistic.cs
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
using System.ComponentModel;
using System.Drawing;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms.DataVisualization.Charting;
using Com.Couchcoding.Logbert.Helper;
using Com.Couchcoding.Logbert.Interfaces;
using Com.Couchcoding.Logbert.Logging;
using Com.Couchcoding.Logbert.Properties;
using WeifenLuo.WinFormsUI.Docking;

namespace Com.Couchcoding.Logbert.Dialogs.Docking
{
  /// <summary>
  /// Implements the <see cref="DockContent"/> of the statistic window.
  /// </summary>
  public partial class FrmLogStatistic : DockContent, ILogPresenter
  {
    #region Public Properties

    /// <summary>
    /// Gets the count of currently displayed <see cref="LogMessage"/>s.
    /// </summary>
    public int DisplayedLogMessagesCount => 0;

    #endregion

    #region Public Methods

    /// <summary>
    /// Clears all shown <see cref="LogMessage"/>s.
    /// </summary>
    public void ClearAll()
    {
      chrtOverview.Series[0].Points.SuspendUpdates();

      try
      {
        foreach (DataPoint logLevelPie in chrtOverview.Series[0].Points)
        {
          logLevelPie.YValues           = new double[1];
          logLevelPie.Label             = string.Empty;
          logLevelPie.IsVisibleInLegend = false;
        }
      }
      finally
      {
        chrtOverview.Series[0].Points.ResumeUpdates();
      }
    }

    /// <summary>
    /// Updates the visible <see cref="LogMessage"/>s.
    /// </summary>
    /// <param name="messages">The list of <see cref="LogMessage"/>s to display.</param>
    /// <param name="delta">The count of new <see cref="LogMessage"/>s.</param>
    public void LogMessagesChanged(List<LogMessage> messages, int delta = -1)
    {
      if (!IsHandleCreated)
      {
        return;
      }

      StartUpdateChart(messages);
    }

    /// <summary>
    /// Simple object for thread synchronization.
    /// </summary>
    private static object mSyncRoot = new object();
    private volatile bool mInUpdate;
    private delegate void UpdateChartDelegate(List<LogMessage> messages);

    private void StartUpdateChart(List<LogMessage> messages)
    {
      if (messages != null && messages.Count > 0)
      {
        UpdateChartDelegate worker            = UpdateChartWorker;
        AsyncCallback       completedCallback = UpdateChartCallback;

        lock (mSyncRoot)
        {
          if (mInUpdate)
          {
            return;
          }

          // Create the asynchronous operation.
          AsyncOperation async = AsyncOperationManager.CreateOperation(null);

          // And start it.
          worker.BeginInvoke(
              messages
            , completedCallback
            , async);

          mInUpdate = true;
        }
      }
    }

    private void EndUpdateChart()
    {
      foreach (DataPoint dPoint in chrtOverview.Series[0].Points)
      {
        bool hasAtLeastOneItem = dPoint.YValues[0] > 0;

        dPoint.IsVisibleInLegend = hasAtLeastOneItem;
        dPoint.Label             = hasAtLeastOneItem 
          ? "#PERCENT{P0}" 
          : string.Empty;
      }

      // Clear the running task flag
      lock (mSyncRoot)
      {
        mInUpdate = false;
      }
    }

    private void UpdateChartWorker(List<LogMessage> messages)
    {
      foreach (DataPoint dPoint in chrtOverview.Series[0].Points)
      {
        dPoint.YValues[0] = 0;
      }

      foreach (LogMessage message in messages)
      {
        DataPoint logLevelPie = GetDataPointForLogLevel(message.Level);

        if (logLevelPie != null)
        {
          logLevelPie.YValues[0]++;
        }
      }
    }

    private void UpdateChartCallback(IAsyncResult ar)
    {
      UpdateChartDelegate worker = (UpdateChartDelegate)((AsyncResult)ar).AsyncDelegate;

      // Finish the asynchronous operation
      worker.EndInvoke(ar);

      BeginInvoke(new Action(EndUpdateChart));
    }

    /// <summary>
    /// Selects the given <paramref name="message"/>.
    /// </summary>
    /// <param name="message">The <see cref="LogMessage"/> o select</param>
    /// <returns><c>True</c> if the given <paramref name="message"/> was selected successfully, otherwise <c>false</c>.</returns>
    public bool SelectLogMessage(LogMessage message)
    {
      // Nothing to do here.
      return true;
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
    /// Increases the size of the <see cref="ILogPresenter"/> content.
    /// </summary>
    /// <returns><c>True</c> if further increasing is possible, otherwise <c>false</c>.</returns>
    public bool ZoomIn()
    {
      return false;
    }

    /// <summary>
    /// Decreases the size of the <see cref="ILogPresenter"/> content.
    /// </summary>
    /// <returns><c>True</c> if further decreasing is possible, otherwise <c>false</c>.</returns>
    public bool ZoomOut()
    {
      return false;
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Gets the <see cref="DataPoint"/> that represents the specified <paramref name="level"/>.
    /// </summary>
    /// <param name="level">The <see cref="LogLevel"/> to get the <see cref="DataPoint"/> for.</param>
    /// <returns></returns>
    private DataPoint GetDataPointForLogLevel(LogLevel level)
    {
      foreach (DataPoint dPoint in chrtOverview.Series[0].Points)
      {
        if (dPoint.Tag.Equals(level))
        {
          return dPoint;
        }
      }

      return null;
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Form.Load" /> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data. </param>
    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      tsbShowLegend.Checked           = Settings.Default.FrmLogStatisticShowLegend;
      chrtOverview.Legends[0].Enabled = tsbShowLegend.Checked;
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
      }

      base.Dispose(disposing);
    }

    /// <summary>
    /// Handles the Click event of the show legend <see cref="ToolStripButton"/>.
    /// </summary>
    private void TsbShowLegendClick(object sender, EventArgs e)
    {
      chrtOverview.Legends[0].Enabled            = tsbShowLegend.Checked;
      Settings.Default.FrmLogStatisticShowLegend = tsbShowLegend.Checked;
      Settings.Default.SaveSettings();
    }

    /// <summary>
    /// Initializes the pie chart control.
    /// </summary>
    /// <param name="logProvider">The <see cref="ILogProvider"/> to initial the color values from.</param>
    private void InitPieChart(ILogProvider logProvider)
    {
      tsbShowLegend.Checked = Settings.Default.FrmLogStatisticShowLegend;

      foreach (LogLevel level in Enum.GetValues(typeof(LogLevel)))
      {
        switch (level)
        {
          case LogLevel.None:
          case LogLevel.All:
            // Not supported to draw
            break;

          default:
            if ((logProvider.SupportedLevels & level) == level)
            {
              DataPoint pieDataPoint = new DataPoint
              {
                Color             = (Color)Settings.Default["BackgroundColor" + level],
                Label             = string.Empty,
                XValue            = 0,
                YValues           = new double[1],
                IsVisibleInLegend = false,
                LegendText        = $"{level}",
                Tag               = level
              };

              chrtOverview.Series[0].Points.Add(pieDataPoint);
            }
            break;
        }
      }
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Creates a new instance of the <see cref="FrmLogStatistic"/> window.
    /// </summary>
    /// <param name="logProvider">The <see cref="ILogProvider"/> that sends messages to this window.</param>
    public FrmLogStatistic(ILogProvider logProvider)
    {
      InitializeComponent();

      // Initial the overview chart.
      InitPieChart(logProvider);

      // Apply the current application theme to the control.
      ThemeManager.CurrentApplicationTheme.ApplyTo(toolStrip1);
    }

    #endregion
  }
}