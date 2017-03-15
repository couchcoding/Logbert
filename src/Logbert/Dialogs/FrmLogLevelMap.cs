#region Copyright © 2017 Couchcoding

// File:    FrmLogLevelMap.cs
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

using Com.Couchcoding.GuiLibrary.Dialogs;
using Com.Couchcoding.Logbert.Logging;
using Com.Couchcoding.Logbert.Properties;
using System.Collections.Generic;

namespace Com.Couchcoding.Logbert.Dialogs
{
  /// <summary>
  /// Implements a dialog to edit <see cref="LogLevel"/> mappings for a <see cref="Columnizer"/>.
  /// </summary>
  public partial class FrmLogLevelMap : DialogForm
  {
    #region Public Properties

    /// <summary>
    /// Gets the new <see cref="LogLevel"/> mappings.
    /// </summary>
    public Dictionary<LogLevel, string> LogLevelMapping
    {
      get
      {
        return new Dictionary<LogLevel, string>
        {
            { LogLevel.Trace   , (string)dgvLogLevel.Rows[0].Cells[0].Value }
          , { LogLevel.Debug   , (string)dgvLogLevel.Rows[1].Cells[0].Value }
          , { LogLevel.Info    , (string)dgvLogLevel.Rows[2].Cells[0].Value }
          , { LogLevel.Warning , (string)dgvLogLevel.Rows[3].Cells[0].Value }
          , { LogLevel.Error   , (string)dgvLogLevel.Rows[4].Cells[0].Value }
          , { LogLevel.Fatal   , (string)dgvLogLevel.Rows[5].Cells[0].Value }
        };
      }
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Initializes a new instance of the <see cref="FrmLogLevelMap"/> dialog.
    /// </summary>
    public FrmLogLevelMap()
    {
      InitializeComponent();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="FrmLogLevelMap"/> dialog with the specified parameters.
    /// </summary>
    /// <param name="logLevels">The <see cref="LogLevel"/> mappings to edit.</param>
    public FrmLogLevelMap(Dictionary<LogLevel, string> logLevels)
    {
      InitializeComponent();

      dgvLogLevel.Rows.Add(@"(?i)TRACE(?-i)",        Resources.trace, LogLevel.Trace.ToString()  );
      dgvLogLevel.Rows.Add(@"(?i)DEBUG(?-i)",        Resources.debug, LogLevel.Debug.ToString()  );
      dgvLogLevel.Rows.Add(@"(?i)INFO(?-i)",         Resources.info,  LogLevel.Info.ToString()   );
      dgvLogLevel.Rows.Add(@"(?i)WARN|WARNING(?-i)", Resources.warn,  LogLevel.Warning.ToString());
      dgvLogLevel.Rows.Add(@"(?i)ERROR(?-i)",        Resources.error, LogLevel.Error.ToString()  );
      dgvLogLevel.Rows.Add(@"(?i)FATAL(?-i)",        Resources.fatal, LogLevel.Fatal.ToString()  );

      foreach (KeyValuePair<LogLevel, string> mapping in logLevels)
      {
        switch (mapping.Key)
        {
          case LogLevel.Trace:
            dgvLogLevel.Rows[0].Cells[0].Value = mapping.Value;
            break;
          case LogLevel.Debug:
            dgvLogLevel.Rows[1].Cells[0].Value = mapping.Value;
            break;
          case LogLevel.Info:
            dgvLogLevel.Rows[2].Cells[0].Value = mapping.Value;
            break;
          case LogLevel.Warning:
            dgvLogLevel.Rows[3].Cells[0].Value = mapping.Value;
            break;
          case LogLevel.Error:
            dgvLogLevel.Rows[4].Cells[0].Value = mapping.Value;
            break;
          case LogLevel.Fatal:
            dgvLogLevel.Rows[5].Cells[0].Value = mapping.Value;
            break;
        }
      }
    }

    #endregion
  }
}
