#region Copyright © 2015 Couchcoding

// File:    SyslogFileReceiverSettings.cs
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

using Couchcoding.Logbert.Helper;
using System.Text;

using Couchcoding.Logbert.Dialogs;

namespace Couchcoding.Logbert.Receiver.SyslogFileReceiver
{
  /// <summary>
  /// Implements the <see cref="ILogSettingsCtrl"/> control for the Syslog file receiver.
  /// </summary>
  public partial class SyslogFileReceiverSettings : UserControl, ILogSettingsCtrl
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
        ofd.Filter           = Resources.strSyslogFileReceiverFilePattern;
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
        if (!string.IsNullOrEmpty(Settings.Default.PnlSyslogFileSettingsFile)
        &&  File.Exists(Settings.Default.PnlSyslogFileSettingsFile))
        {
          txtLogFile.Text = Settings.Default.PnlSyslogFileSettingsFile;
        }

        chkStartFromBeginning.Checked = Settings.Default.PnlSyslogFileSettingsStartFromBeginning;

        int timeStampCount = Settings.Default.PnlSyslogFileSettingsTimestampFormat.Split(
          new [] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries ).Length;

        txtTimestampFormat.Text = timeStampCount > 1
          ? string.Format(Resources.strSyslogReceiverCountOfTimestampsDefined, timeStampCount)
          : Settings.Default.PnlSyslogFileSettingsTimestampFormat;

        txtTimestampFormat.Tag = Settings.Default.PnlSyslogFileSettingsTimestampFormat;
      }
      else
      {
        txtTimestampFormat.Tag = FrmTimestamps.DefaultDateTimeFormat;
      }

      foreach (EncodingInfo encoding in Encoding.GetEncodings())
      {
        EncodingWrapper encWrapper = new EncodingWrapper(encoding);

        cmbEncoding.Items.Add(encWrapper);

        if (encoding.CodePage == (ModifierKeys != Keys.Shift ? Settings.Default.PnlSyslogFileSettingsEncoding : Encoding.Default.CodePage))
        {
          cmbEncoding.SelectedItem = encWrapper;
        }
      }

      if (cmbEncoding.SelectedItem == null)
      {
        cmbEncoding.SelectedIndex = 0;
      }
    }

    /// <summary>
    /// Handles the ButtonClick event of the timestamp help <see cref="Button"/>.
    /// </summary>
    private void TxtTimestampFormatButtonClick(object sender, EventArgs e)
    {
      using (FrmTimestamps timestampEditor = new FrmTimestamps((string)txtTimestampFormat.Tag))
      {
        if (timestampEditor.ShowDialog(this) == DialogResult.OK)
        {
          int timeStampCount = timestampEditor.Timestamps.Split(
            new [] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries ).Length;

          txtTimestampFormat.Text = timeStampCount > 1
            ? string.Format(Resources.strSyslogReceiverCountOfTimestampsDefined, timeStampCount)
            : timestampEditor.Timestamps;

          txtTimestampFormat.Tag = timestampEditor.Timestamps;
        }
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
      if (!File.Exists(txtLogFile.Text))
      {
        txtLogFile.SelectAll();
        txtLogFile.Select();

        return ValidationResult.Error(Resources.strSyslogFileReceiverFileDoesNotExist);
      }

      if (string.IsNullOrEmpty(txtTimestampFormat.Text))
      {
        return ValidationResult.Error(Resources.strSyslogFileReceiverTimestampNotSpecified);
      }

      return ValidationResult.Success;
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
        Settings.Default.PnlSyslogFileSettingsFile               = txtLogFile.Text;
        Settings.Default.PnlSyslogFileSettingsStartFromBeginning = chkStartFromBeginning.Checked;
        Settings.Default.PnlSyslogFileSettingsTimestampFormat    = (string)txtTimestampFormat.Tag;
        Settings.Default.PnlSyslogFileSettingsEncoding           = ((EncodingWrapper)cmbEncoding.SelectedItem).Codepage;
        
        Settings.Default.SaveSettings();
      }

      return new SyslogFileReceiver(
          txtLogFile.Text
        , chkStartFromBeginning.Checked
        , (string)txtTimestampFormat.Tag
        , Settings.Default.PnlSyslogFileSettingsEncoding);
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Creates a new instance of the <see cref="SyslogFileReceiverSettings"/> <see cref="Control"/>.
    /// </summary>
    public SyslogFileReceiverSettings()
    {
      InitializeComponent();
    }

    #endregion
  }
}
