#region Copyright © 2015 Couchcoding

// File:    FrmNew.cs
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

using System.Windows.Forms;

using Com.Couchcoding.GuiLibrary.Dialogs;
using Com.Couchcoding.Logbert.Helper;
using Com.Couchcoding.Logbert.Interfaces;
using Com.Couchcoding.Logbert.Properties;
using Com.Couchcoding.Logbert.Receiver;
using Com.Couchcoding.Logbert.Receiver.CustomReceiver.CustomFileReceiver;
using Com.Couchcoding.Logbert.Receiver.Log4NetUdpReceiver;
using Com.Couchcoding.Logbert.Receiver.Log4NetFileReceiver;
using Com.Couchcoding.Logbert.Receiver.NlogTcpReceiver;
using Com.Couchcoding.Logbert.Receiver.NLogUdpReceiver;
using Com.Couchcoding.Logbert.Receiver.NLogFileReceiver;
using Com.Couchcoding.Logbert.Receiver.SyslogFileReceiver;
using Com.Couchcoding.Logbert.Receiver.SyslogUdpReceiver;
using Com.Couchcoding.Logbert.Receiver.EventlogReceiver;

namespace Com.Couchcoding.Logbert.Dialogs
{
  /// <summary>
  /// Implements the new logger dialog.
  /// </summary>
  public partial class FrmNew : DialogForm
  {
    #region Public Properties

    /// <summary>
    /// Gets the fully configured <see cref="ILogProvider"/>, or <c>null</c> on error.
    /// </summary>
    public ILogProvider LogProvider
    {
      get
      {
        ILogSettingsCtrl settingsCtrl = grpSettings.Controls[0] as ILogSettingsCtrl;

        return settingsCtrl != null
          ? settingsCtrl.GetConfiguredInstance()
          : null;
      }
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Handles the SelectedIndexChanged event of the <see cref="ListBox"/> <see cref="Control"/>.
    /// </summary>
    private void LstLoggerSelectedIndexChanged(object sender, System.EventArgs e)
    {
      ILogProvider logProvider = lstLogger.SelectedItem as ILogProvider;

      if (logProvider != null)
      {
        grpSettings.SuspendLayout();

        using (new WaitCursor(Cursors.Default, Settings.Default.WaitCursorTimeout))
        {
          try
          {
            ILogSettingsCtrl newSettingsCtrl = logProvider.Settings;

            if (newSettingsCtrl != null)
            {
              if (grpSettings.Controls.Count == 1)
              {
                ILogSettingsCtrl oldSettingsCtrl = grpSettings.Controls[0] as ILogSettingsCtrl;

                if (oldSettingsCtrl != null)
                {
                  grpSettings.Controls.RemoveAt(0);
                  oldSettingsCtrl.Dispose();
                }
              }

              ((Control)newSettingsCtrl).Dock = DockStyle.Fill;

              grpSettings.Controls.Add((Control)newSettingsCtrl);

              grpSettings.Text = string.Format(
                  Resources.strNewLoggerPanelText
                , logProvider.Name);
            }
          }
          finally
          {
            grpSettings.ResumeLayout();

            if (grpSettings.Controls.Count == 1)
            {
              grpSettings.Controls[0].Select();
            }
          }
        }
      }
    }

    /// <summary>
    /// Validates the dialog inputs before the dialog is closed.
    /// </summary>
    /// <param name="dlgResult">The current active <see cref="DialogResult"/>.</param>
    /// <returns><c>True</c> if all input is valid; otherwise <c>false</c>.</returns>
    protected override bool ValidateDialog(DialogResult dlgResult)
    {
      if (dlgResult == DialogResult.OK)
      {
        ILogSettingsCtrl oldSettingsCtrl = grpSettings.Controls.Count > 0 
          ? grpSettings.Controls[0] as ILogSettingsCtrl
          : null;

        if (oldSettingsCtrl != null)
        {
          ValidationResult result = oldSettingsCtrl.ValidateSettings();

          if (!result.IsSuccess)
          {
            MessageBox.Show(
                this
              , result.ErrorMsg
              , Application.ProductName
              , MessageBoxButtons.OK
              , MessageBoxIcon.Error);

            return false;
          }
        }
      }

      return true;
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Creates a new instance of the <see cref="FrmNew"/> <see cref="Form"/>.
    /// </summary>
    public FrmNew()
    {
      InitializeComponent();

      lstLogger.Items.Add(new Log4NetUdpReceiver());
      lstLogger.Items.Add(new Log4NetFileReceiver());
      lstLogger.AddSeperator();
      lstLogger.Items.Add(new NlogTcpReceiver());
      lstLogger.Items.Add(new NLogUdpReceiver());
      lstLogger.Items.Add(new NLogFileReceiver());
      lstLogger.AddSeperator();
      lstLogger.Items.Add(new SyslogUdpReceiver());
      lstLogger.Items.Add(new SyslogFileReceiver());
      lstLogger.AddSeperator();
      lstLogger.Items.Add(new EventlogReceiver());
      lstLogger.AddSeperator();
      lstLogger.Items.Add(new CustomFileReceiver());

      lstLogger.SelectedIndex = 0;
    }

    #endregion
  }
}
