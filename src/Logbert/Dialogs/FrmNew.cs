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

using Couchcoding.Logbert.Gui.Dialogs;
using Couchcoding.Logbert.Helper;
using Couchcoding.Logbert.Interfaces;
using Couchcoding.Logbert.Properties;
using Couchcoding.Logbert.Receiver;
using Couchcoding.Logbert.Receiver.CustomReceiver.CustomFileReceiver;
using Couchcoding.Logbert.Receiver.Log4NetUdpReceiver;
using Couchcoding.Logbert.Receiver.Log4NetFileReceiver;
using Couchcoding.Logbert.Receiver.NlogTcpReceiver;
using Couchcoding.Logbert.Receiver.NLogUdpReceiver;
using Couchcoding.Logbert.Receiver.NLogFileReceiver;
using Couchcoding.Logbert.Receiver.SyslogFileReceiver;
using Couchcoding.Logbert.Receiver.SyslogUdpReceiver;
using Couchcoding.Logbert.Receiver.EventlogReceiver;
using Couchcoding.Logbert.Receiver.Log4NetDirReceiver;
using Couchcoding.Logbert.Receiver.NLogDirReceiver;
using Couchcoding.Logbert.Receiver.WinDebugReceiver;
using Couchcoding.Logbert.Receiver.CustomReceiver.CustomUdpReceiver;

namespace Couchcoding.Logbert.Dialogs
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
    public ILogProvider LogProvider => (pnlLoggerPanel.Controls[0] as ILogSettingsCtrl)?.GetConfiguredInstance();

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
        pnlLoggerPanel.SuspendLayout();

        using (new WaitCursor(Cursors.Default, Settings.Default.WaitCursorTimeout))
        {
          try
          {
            ILogSettingsCtrl newSettingsCtrl = logProvider.Settings;

            if (newSettingsCtrl != null)
            {
              if (pnlLoggerPanel.Controls.Count == 1)
              {
                ILogSettingsCtrl oldSettingsCtrl = pnlLoggerPanel.Controls[0] as ILogSettingsCtrl;

                if (oldSettingsCtrl != null)
                {
                  pnlLoggerPanel.Controls.RemoveAt(0);
                  oldSettingsCtrl.Dispose();
                }
              }

              ((Control)newSettingsCtrl).Dock = DockStyle.Fill;

              pnlLoggerPanel.Controls.Add((Control)newSettingsCtrl);
              pnlLoggerPanel.AutoScrollMinSize = pnlLoggerPanel.Controls[0].MinimumSize;

              grpSettings.Text = string.Format(
                Resources.strNewLoggerPanelText
                , logProvider.Name);
            }
          }
          finally
          {
            pnlLoggerPanel.ResumeLayout(true);
          }
        }
      }
    }

    /// <summary>
    /// Initializes the user interface of the dialog.
    /// </summary>
    private void InitializeUserInterface()
    {

      InitializeComponent();

      lstLogger.Items.Add(new Log4NetUdpReceiver());
      lstLogger.Items.Add(new Log4NetFileReceiver());
      lstLogger.Items.Add(new Log4NetDirReceiver());
      lstLogger.AddSeperator();
      lstLogger.Items.Add(new NlogTcpReceiver());
      lstLogger.Items.Add(new NLogUdpReceiver());
      lstLogger.Items.Add(new NLogFileReceiver());
      lstLogger.Items.Add(new NLogDirReceiver());
      lstLogger.AddSeperator();
      lstLogger.Items.Add(new SyslogUdpReceiver());
      lstLogger.Items.Add(new SyslogFileReceiver());
      lstLogger.AddSeperator();
      lstLogger.Items.Add(new EventlogReceiver());
      lstLogger.Items.Add(new WinDebugReceiver());
      lstLogger.AddSeperator();
      lstLogger.Items.Add(new CustomUdpReceiver());
      lstLogger.Items.Add(new CustomTcpReceiver());
      lstLogger.Items.Add(new CustomFileReceiver());
      lstLogger.Items.Add(new CustomDirReceiver());
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
        ILogSettingsCtrl oldSettingsCtrl = pnlLoggerPanel.Controls.Count > 0
          ? pnlLoggerPanel.Controls[0] as ILogSettingsCtrl
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
      InitializeUserInterface();

      lstLogger.SelectedIndex = 0;
    }

    /// <summary>
    /// Creates a new instance of the <see cref="FrmNew"/> <see cref="Form"/>.
    /// </summary>
    public FrmNew(string selectedReceiver)
    {
      InitializeUserInterface();

      for (int receiverIndex = 0; receiverIndex < lstLogger.Items.Count; receiverIndex++)
      {
        if (lstLogger.Items[receiverIndex] is ReceiverBase currentReceiver && Equals(currentReceiver.Name, selectedReceiver))
        {
          lstLogger.SelectedIndex = receiverIndex;
          break;
        }
      }
    }

    #endregion
  }
}
