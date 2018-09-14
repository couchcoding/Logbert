#region Copyright © 2017 Couchcoding

// File:    NLogDirReceiverSettings.cs
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
using System.Drawing;
using System.Windows.Forms;

using Couchcoding.Logbert.Interfaces;
using Couchcoding.Logbert.Properties;
using System.IO;
using System.Text;

using Couchcoding.Logbert.Helper;

namespace Couchcoding.Logbert.Receiver.NLogDirReceiver
{
  /// <summary>
  /// Implements the <see cref="ILogSettingsCtrl"/> control for the NLog file receiver.
  /// </summary>
  public partial class NLogDirReceiverSettings : UserControl, ILogSettingsCtrl
  {
    #region Private Methods

    /// <summary>
    /// Handles the Click event of the browse for file <see cref="Button"/>.
    /// </summary>
    private void TxtLogDirectoryButtonClick(object sender, EventArgs e)
    {
      using (FolderBrowserDialog bfd = new FolderBrowserDialog())
      {
        bfd.Description  = Resources.strNLogDirectoryReceiverSelectDirectoryToObserve;
        bfd.RootFolder   = Environment.SpecialFolder.Desktop;
        bfd.SelectedPath = txtLogDirectory.Text;

        if (bfd.ShowDialog(this) == DialogResult.OK)
        {
          txtLogDirectory.Text = bfd.SelectedPath;
        }
      }
    }

    /// <summary>
    /// Handles the Click event of the file pattern help <see cref="Button"/>.
    /// </summary>
    private void TxtLogFilePatternButtonClick(object sender, EventArgs e)
    {
      Control btnFilePattern = sender as Control;

      if (btnFilePattern != null)
      {
        mnuFilePattern.Show(
            btnFilePattern
          , new Point(btnFilePattern.Width, btnFilePattern.Top));
      }
    }

    /// <summary>
    /// Handles the Click event of a file pattern preset <see cref="MenuItem"/>.
    /// </summary>
    private void MnuFilePatternPresetClick(object sender, EventArgs e)
    {
      if (sender is MenuItem mnuCtrl && mnuCtrl.Tag != null)
      {
        txtLogFilePattern.Text = mnuCtrl.Tag.ToString();
      }
    }

    /// <summary>
    /// Handles the Click event of a file pattern preset <see cref="MenuItem"/>.
    /// </summary>
    private void MnuFilePatternClick(object sender, EventArgs e)
    {
      if (sender is MenuItem mnuCtrl && mnuCtrl.Tag != null)
      {
        txtLogFilePattern.SelectedText = mnuCtrl.Tag.ToString();
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
        if (Directory.Exists(Settings.Default.PnlNLogDirectorySettingsDirectory))
        {
          txtLogDirectory.Text = Settings.Default.PnlNLogDirectorySettingsDirectory;
        }

        txtLogFilePattern.Text    = Settings.Default.PnlNLogDirectorySettingsPattern ;
        chkInitialReadAll.Checked = Settings.Default.PnlNLogDirectorySettingsReadAllExisting;
      }

      foreach (EncodingInfo encoding in Encoding.GetEncodings())
      {
        EncodingWrapper encWrapper = new EncodingWrapper(encoding);

        cmbEncoding.Items.Add(encWrapper);

        if (encoding.CodePage == (ModifierKeys != Keys.Shift ? Settings.Default.PnlSyslogUdpSettingsEncoding : Encoding.Default.CodePage))
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
      if (!Directory.Exists(txtLogDirectory.Text))
      {
        txtLogDirectory.SelectAll();
        txtLogDirectory.Select();

        return ValidationResult.Error(Resources.strNLogDirectodyReceiverDirectoryDoesNotExist);
      }

      if (string.IsNullOrEmpty(txtLogFilePattern.Text))
      {
        txtLogFilePattern.SelectAll();
        txtLogFilePattern.Select();

        return ValidationResult.Error(Resources.strNLogDirectodyReceiverInvalidFilePattern);
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
        Settings.Default.PnlNLogDirectorySettingsDirectory       = txtLogDirectory.Text;
        Settings.Default.PnlNLogDirectorySettingsPattern         = txtLogFilePattern.Text;
        Settings.Default.PnlNLogDirectorySettingsReadAllExisting = chkInitialReadAll.Checked;
        Settings.Default.PnlNLogDirectorySettingsEncoding        = ((EncodingWrapper)cmbEncoding.SelectedItem).Codepage;

        Settings.Default.SaveSettings();
      }

      return new NLogDirReceiver(
          txtLogDirectory.Text
        , txtLogFilePattern.Text
        , chkInitialReadAll.Checked
        , Settings.Default.PnlNLogDirectorySettingsEncoding);
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Creates a new instance of the <see cref="NLogDirReceiverSettings"/> <see cref="Control"/>.
    /// </summary>
    public NLogDirReceiverSettings()
    {
      InitializeComponent();
    }

    #endregion
  }
}
