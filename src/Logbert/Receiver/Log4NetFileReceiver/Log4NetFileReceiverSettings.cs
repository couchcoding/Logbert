#region Copyright © 2015 Couchcoding

// File:    Log4NetFileReceiverSettings.cs
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
using System.Windows.Forms;

using Couchcoding.Logbert.Interfaces;
using Couchcoding.Logbert.Properties;
using System.IO;
using System.Text;

using Couchcoding.Logbert.Helper;

namespace Couchcoding.Logbert.Receiver.Log4NetFileReceiver
{
  /// <summary>
  /// Implements the <see cref="ILogSettingsCtrl"/> control for the Log4Net file receiver.
  /// </summary>
  public partial class Log4NetFileReceiverSettings : UserControl, ILogSettingsCtrl
  {
    #region Private Methods

    /// <summary>
    /// Handles the Click event of the browse for file <see cref="Button"/>.
    /// </summary>
    private void TxtLogFileButtonClick(object sender, EventArgs e)
    {
      using (OpenFileDialog ofd = new OpenFileDialog())
      {
        ofd.CheckFileExists  = true;
        ofd.CheckPathExists  = true;
        ofd.FileName         = txtLogFile.Text;
        ofd.Filter           = Resources.strLog4NetFileReceiverFilePattern;
        ofd.RestoreDirectory = true;

        if (ofd.ShowDialog(this) == DialogResult.OK)
        {
          txtLogFile.Text = ofd.FileName;
        }
      }
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.UserControl.Load"/> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data. </param>
    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      if (ModifierKeys != Keys.Shift)
      {
        if (!string.IsNullOrEmpty(Settings.Default.PnlLog4NetFileSettingsFile)
        &&  File.Exists(Settings.Default.PnlLog4NetFileSettingsFile))
        {
          txtLogFile.Text = Settings.Default.PnlLog4NetFileSettingsFile;
        }

        chkStartFromBeginning.Checked = Settings.Default.PnlLog4NetFileSettingsStartFromBeginning;
      }

      foreach (EncodingInfo encoding in Encoding.GetEncodings())
      {
        EncodingWrapper encWrapper = new EncodingWrapper(encoding);

        cmbEncoding.Items.Add(encWrapper);

        if (encoding.CodePage == (ModifierKeys != Keys.Shift ? Settings.Default.PnlLog4NetFileSettingsEncoding : Encoding.Default.CodePage))
        {
          cmbEncoding.SelectedItem = encWrapper;
        }
      }

      if (cmbEncoding.SelectedItem == null)
      {
        cmbEncoding.SelectedIndex = 0;
      }
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Validates the entered settings.
    /// </summary>
    /// <returns>The <see cref="ValidationResult"/> of the validation.</returns>
    public ValidationResult ValidateSettings()
    {
      if (File.Exists(txtLogFile.Text))
      {
        return ValidationResult.Success;
      }

      txtLogFile.SelectAll();
      txtLogFile.Select();

      return ValidationResult.Error(Resources.strLog4NetFileReceiverFileDoesNotExist);
    }

    /// <summary>
    /// Creates and returns a fully configured <see cref="ILogProvider"/> instance.
    /// </summary>
    /// <returns>A fully configured <see cref="ILogProvider"/> instance.</returns>
    public ILogProvider GetConfiguredInstance()
    {
      if (ModifierKeys != Keys.Shift)
      {
        // Save the current settings as new default values.
        Settings.Default.PnlLog4NetFileSettingsFile               = txtLogFile.Text;
        Settings.Default.PnlLog4NetFileSettingsStartFromBeginning = chkStartFromBeginning.Checked;
        Settings.Default.PnlLog4NetFileSettingsEncoding           = ((EncodingWrapper)cmbEncoding.SelectedItem).Codepage;

        Settings.Default.SaveSettings();
      }

      return new Log4NetFileReceiver(
          txtLogFile.Text
        , chkStartFromBeginning.Checked
        , Settings.Default.PnlLog4NetFileSettingsEncoding);
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Creates a new instance of the <see cref="Log4NetFileReceiverSettings"/> <see cref="Control"/>.
    /// </summary>
    public Log4NetFileReceiverSettings()
    {
      InitializeComponent();
    }

    #endregion
  }
}
