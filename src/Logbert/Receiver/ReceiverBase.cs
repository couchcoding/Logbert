#region Copyright © 2015 Couchcoding

// File:    ReceiverBase.cs
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
using System.Text;

using Couchcoding.Logbert.Interfaces;
using Couchcoding.Logbert.Logging;
using Couchcoding.Logbert.Helper;

namespace Couchcoding.Logbert.Receiver
{
  /// <summary>
  /// Implements the base class for all <see cref="ILogProvider"/> implementations.
  /// </summary>
  public abstract class ReceiverBase : ILogProvider, IDisposable
  {
    #region Private Consts

    /// <summary>
    ///  Use the ISO-8859-1 (Western European (Windows)) as default encoding.
    /// </summary>
    private const int SYSTEM_DEFAULT_CODEPAGE = 1252;

    #endregion

    #region Private Fields

    /// <summary>
    /// Holds the reference to the <see cref="ILogHandler"/> instance.
    /// </summary>
    protected ILogHandler mLogHandler;

    /// <summary>
    /// Holds the active state if the <see cref="ILogProvider"/>.
    /// </summary>
    protected bool mIsActive = true;

    /// <summary>
    /// The <see cref="Encoding"/> to use while parsing the data.
    /// </summary>
    protected Encoding mEncoding;

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets the name of the <see cref="ILogProvider"/>.
    /// </summary>
    public abstract string Name
    {
      get;
    }

    /// <summary>
    /// Gets the description of the <see cref="ILogProvider"/>
    /// </summary>
    public abstract string Description
    {
      get;
    }

    /// <summary>
    /// Gets the filename for export of the received <see cref="LogMessage"/>s.
    /// </summary>
    public abstract string ExportFileName
    {
      get;
    }
    
    /// <summary>
    /// Gets the tooltip to display at the document tab.
    /// </summary>
    public virtual string Tooltip
    {
      get
      {
        return Description;
      }
    }

    /// <summary>
    /// Gets the settings <see cref="ILogSettingsCtrl"/> of the <see cref="ILogProvider"/>.
    /// </summary>
    public abstract ILogSettingsCtrl Settings
    {
      get;
    }

    /// <summary>
    /// Gets the columns to display of the <see cref="ILogProvider"/>.
    /// </summary>
    public abstract Dictionary<int, LogColumnData> Columns
    {
      get;
    }

    /// <summary>
    /// Determines whether this <see cref="ILogProvider"/> supports the message details window.
    /// </summary>
    public virtual bool HasMessageDetails
    {
      get
      {
        return true;
      }
    }

    /// <summary>
    /// Determines whether this <see cref="ILogProvider"/> supports the logger tree window.
    /// </summary>
    public virtual bool HasLoggerTree
    {
      get
      {
        return true;
      }
    }

    /// <summary>
    /// Determines whether this <see cref="ILogProvider"/> supports the logger tree window.
    /// </summary>
    public virtual bool HasStatisticView
    {
      get
      {
        return true;
      }
    }

    /// <summary>
    /// Gets the supported <see cref="LogLevel"/>s of the <see cref="ILogProvider"/>.
    /// </summary>
    public virtual LogLevel SupportedLevels
    {
      get
      {
        return LogLevel.All;
      }
    }

    /// <summary>
    /// Determines whether this <see cref="ILogProvider"/> supports reloading of the content, ot not.
    /// </summary>
    public virtual bool SupportsReload
    {
      get
      {
        // By default the content may be reloaded.
        return true;
      }
    }

    /// <summary>
    /// Gets or sets the active state if the <see cref="ILogProvider"/>.
    /// </summary>
    public virtual bool IsActive
    {
      get
      {
        return mIsActive;
      }
      set
      {
        mIsActive = value;
      }
    }

    /// <summary>
    /// Get the <see cref="ILogPresenter"/> to display details about a selected <see cref="LogMessage"/>.
    /// </summary>
    public virtual ILogPresenter DetailsControl
    {
      get
      {
        return null;
      }
    }

    /// <summary>
    /// Gets the path seperator for the logger tree.
    /// </summary>
    public virtual string LoggerTreePathSeperator
    {
      get
      {
        return ".";
      }
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Intizializes the <see cref="ILogProvider"/>.
    /// </summary>
    /// <param name="logHandler">The <see cref="ILogHandler"/> that may handle incomming <see cref="LogMessage"/>s.</param>
    public virtual void Initialize(ILogHandler logHandler)
    {
      mLogHandler = logHandler;
    }

    /// <summary>
    /// Clears the <see cref="ILogProvider"/> collected <see cref="LogMessage"/>s.
    /// </summary>
    public virtual void Clear()
    {

    }

    /// <summary>
    /// Resets the <see cref="ILogProvider"/> instance.
    /// </summary>
    public virtual void Reset()
    {
      
    }

    /// <summary>
    /// Shuts down the <see cref="ILogProvider"/> instance.
    /// </summary>
    public virtual void Shutdown()
    {
      
    }

    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    /// <filterpriority>2</filterpriority>
    public virtual void Dispose()
    {
      Shutdown();
    }

    /// <summary>
    /// Gets the header used for the CSV file export.
    /// </summary>
    /// <returns>The header used for the CSV file export.</returns>
    public abstract string GetCsvHeader();

    /// <summary>
    /// Determines whether the <see cref="ReceiverBase"/> instance can handle the given file name as log file.
    /// </summary>
    /// <returns><c>True</c> if the file can be handled, otherwise <c>false</c>.</returns>
    public virtual bool CanHandleLogFile()
    {
      return false;
    }

    /// <summary>
    /// Saves the current docking and collumn layout of the <see cref="ILogProvider"/> implementation.
    /// </summary>
    /// <param name="layout">The layout as string to save.</param>
    /// <param name="columnLayout">The current column layout to save.</param>
    public abstract void SaveLayout(string layout, List<LogColumnData> columnLayout);

    /// <summary>
    /// Loads the docking layout of the <see cref="ReceiverBase"/> instance.
    /// </summary>
    /// <returns>The restored layout, or <c>null</c> if none exists.</returns>
    public abstract string LoadLayout();

    #endregion

    #region Constructor

    /// <summary>
    /// Initializes a new instance of the <see cref="ReceiverBase"/> with the specified parameters.
    /// </summary>
    /// <param name="codePage">The codepage to use for encoding of the datato parse.</param>
    protected ReceiverBase(int codePage = SYSTEM_DEFAULT_CODEPAGE)
    {
      try
      {
        mEncoding = Encoding.GetEncoding(codePage);
      }
      catch (Exception ex)
      {
        Logger.Warn($"Unable to restore encoding (Codepage: {codePage}): {ex.Message}");

        // Using the system default encoding as fallback.
        mEncoding = Encoding.Default;
      }
    }

    #endregion
  }
}
