#region Copyright © 2015 Couchcoding

// File:    ILogProvider.cs
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
using System.Windows.Forms;

using Couchcoding.Logbert.Logging;
using Couchcoding.Logbert.Helper;

namespace Couchcoding.Logbert.Interfaces
{
  /// <summary>
  /// Interface for all <see cref="ILogProvider"/> implementations.
  /// </summary>
  public interface ILogProvider
  {
    #region Interface Properties

    /// <summary>
    /// Gets the name of the <see cref="ILogProvider"/>.
    /// </summary>
    string Name
    {
      get;
    }

    /// <summary>
    /// Gets the description of the <see cref="ILogProvider"/>
    /// </summary>
    string Description
    {
      get;
    }

    /// <summary>
    /// Gets the filename for export of the received <see cref="LogMessage"/>s.
    /// </summary>
    string ExportFileName
    {
      get;
    }

    /// <summary>
    /// Gets the tooltip to display at the document tab.
    /// </summary>
    string Tooltip
    {
      get;
    }

    /// <summary>
    /// Gets the settings <see cref="Control"/> of the <see cref="ILogProvider"/>.
    /// </summary>
    ILogSettingsCtrl Settings
    {
      get;
    }

    /// <summary>
    /// Gets the columns to display of the <see cref="ILogProvider"/>.
    /// </summary>
    Dictionary<int, LogColumnData> Columns
    {
      get;
    }

    /// <summary>
    /// Determines whether this <see cref="ILogProvider"/> supports the message details window.
    /// </summary>
    bool HasMessageDetails
    {
      get;
    }

    /// <summary>
    /// Determines whether this <see cref="ILogProvider"/> supports the logger tree window.
    /// </summary>
    bool HasLoggerTree
    {
      get;
    }

    /// <summary>
    /// Determines whether this <see cref="ILogProvider"/> has a statistic window.
    /// </summary>
    bool HasStatisticView
    {
      get;
    }

    /// <summary>
    /// Gets the supported <see cref="LogLevel"/>s of the <see cref="ILogProvider"/>.
    /// </summary>
    LogLevel SupportedLevels
    {
      get;
    }

    /// <summary>
    /// Determines whether this <see cref="ILogProvider"/> supports reloading of the content, ot not.
    /// </summary>
    bool SupportsReload
    {
      get;
    }

    /// <summary>
    /// Gets or sets the active state if the <see cref="ILogProvider"/>.
    /// </summary>
    bool IsActive
    {
      get;
      set;
    }

    /// <summary>
    /// Get the <see cref="Control"/> to display details about a selected <see cref="LogMessage"/>.
    /// </summary>
    ILogPresenter DetailsControl
    {
      get;
    }

    /// <summary>
    /// Gets the path seperator for the logger tree.
    /// </summary>
    string LoggerTreePathSeperator
    {
      get;
    }

    #endregion

    #region Interface Methods

    /// <summary>
    /// Intizializes the <see cref="ILogProvider"/>.
    /// </summary>
    /// <param name="logHandler">The <see cref="ILogHandler"/> that may handle incoming <see cref="LogMessage"/>s.</param>
    void Initialize(ILogHandler logHandler);

    /// <summary>
    /// Clears the <see cref="ILogProvider"/> collected <see cref="LogMessage"/>s.
    /// </summary>
    void Clear();

    /// <summary>
    /// Resets the <see cref="ILogProvider"/> instance.
    /// </summary>
    void Reset();

    /// <summary>
    /// Shuts down the <see cref="ILogProvider"/> instance.
    /// </summary>
    void Shutdown();

    /// <summary>
    /// Gets the header used for the CSV file export.
    /// </summary>
    /// <returns>The header used for the CSV file export.</returns>
    string GetCsvHeader();

    /// <summary>
    /// Saves the current docking and collumn layout of the <see cref="ILogProvider"/> implementation.
    /// </summary>
    /// <param name="layout">The layout as string to save.</param>
    /// <param name="columnLayout">The current column layout to save.</param>
    void SaveLayout(string layout, List<LogColumnData> columnLayout);

    /// <summary>
    /// Loads the docking layout of the <see cref="ILogProvider"/> implementation.
    /// </summary>
    /// <returns>The restored layout, or <c>null</c> if none exists.</returns>
    string LoadLayout();

    #endregion
  }
}
