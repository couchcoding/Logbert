#region Copyright © 2018 Couchcoding

// File:    FrmWelcome.cs
// Package: Logbert
// Project: Logbert
// 
// The MIT License (MIT)
// 
// Copyright (c) 2018 Couchcoding
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
using System.Data;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Com.Couchcoding.GuiLibrary.Controls;
using Com.Couchcoding.Logbert.Helper;
using Com.Couchcoding.Logbert.Properties;
using Com.Couchcoding.Logbert.Receiver;
using Com.Couchcoding.Logbert.Receiver.CustomReceiver.CustomFileReceiver;
using Com.Couchcoding.Logbert.Receiver.CustomReceiver.CustomUdpReceiver;
using Com.Couchcoding.Logbert.Receiver.EventlogReceiver;
using Com.Couchcoding.Logbert.Receiver.Log4NetDirReceiver;
using Com.Couchcoding.Logbert.Receiver.Log4NetFileReceiver;
using Com.Couchcoding.Logbert.Receiver.Log4NetUdpReceiver;
using Com.Couchcoding.Logbert.Receiver.NlogTcpReceiver;
using Com.Couchcoding.Logbert.Receiver.NLogDirReceiver;
using Com.Couchcoding.Logbert.Receiver.NLogFileReceiver;
using Com.Couchcoding.Logbert.Receiver.NLogUdpReceiver;
using Com.Couchcoding.Logbert.Receiver.SyslogFileReceiver;
using Com.Couchcoding.Logbert.Receiver.SyslogUdpReceiver;
using Com.Couchcoding.Logbert.Receiver.WinDebugReceiver;

using Logbert;

using WeifenLuo.WinFormsUI.Docking;

namespace Com.Couchcoding.Logbert.Dialogs.Docking
{
    public partial class FrmWelcome : DockContent
    {
        #region Private Fields

        private MainForm mMainForm;

        #endregion

        #region Constructor

        public FrmWelcome(MainForm mainForm)
        {
            InitializeComponent();

            mMainForm = mainForm;

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

            RebuildMruList();

            MruManager.MruListChanged += (_, __) => RebuildMruList();
        }

        #endregion

        #region Private Methods

        /// <summary>Calculates the scroll offset to the specified child control. </summary>
        /// <returns>The upper-left hand <see cref="T:System.Drawing.Point" /> of the display area relative to the client area required to scroll the control into view.</returns>
        /// <param name="activeControl">The child control to scroll into view. </param>
        protected override Point ScrollToControl(Control activeControl)
        {
            return AutoScrollPosition;
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.SizeChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data. </param>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            int tblLeft = (Width  - tblWelcome.Width)  >> 1;
            int tblTop  = (Height - tblWelcome.Height) >> 1;

            nfoBgPanel.Left = tblLeft >= 0 ? tblLeft : 0;
            nfoBgPanel.Top  = tblTop  >= 0 ? tblTop  : 0;
        }

        #endregion

        private void RecentFileClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string logFileToLoad = ((Control)sender).Tag as string;

            if (!File.Exists(logFileToLoad))
            {
                DialogResult removeRslt = MessageBox.Show(
                      Resources.strMruFileCouldNotBeFound
                    , Application.ProductName
                    , MessageBoxButtons.YesNo
                    , MessageBoxIcon.Warning);

                if (removeRslt == DialogResult.Yes)
                {
                    MruManager.RemoveFile(logFileToLoad);
                }

                return;
            }

            mMainForm.LoadFileIntoLogger(logFileToLoad);
        }

        private void LinkLabelClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Browser.Open((string)((LinkLabelEx)sender).Tag, this);
        }

        private void LoggerSelected(object sender, EventArgs e)
        {
            if (lstLogger.SelectedItem is ReceiverBase selectedReceiver)
            {
              using (FrmNew newDlg = new FrmNew(selectedReceiver.Name))
              {
                if (newDlg.ShowDialog(this) == DialogResult.OK)
                {
                  new FrmLogDocument(newDlg.LogProvider).Show(mMainForm.MainDockPanel);
                }
              }
            }

            lstLogger.ClearSelected();
        }

        private void RebuildMruList()
        {
            flRecentFiles.Controls.Clear();

            for (int mruFileIndex = MruManager.MruFiles.Count - 1; mruFileIndex >= 0; --mruFileIndex)
            {
                LinkLabelEx recentFileLink = new LinkLabelEx
                {
                    Text             = MruManager.MruFiles[mruFileIndex].ToShortPath(SystemFonts.MessageBoxFont, flRecentFiles.Width),
                    Tag              = MruManager.MruFiles[mruFileIndex],
                    ActiveLinkColor  = SystemColors.ActiveCaption,
                    ForeColor        = SystemColors.ControlText,
                    LinkColor        = SystemColors.ControlText,
                    VisitedLinkColor = SystemColors.ControlText,
                    LinkBehavior     = LinkBehavior.HoverUnderline,
                    Padding          = new Padding(0, 0, 0, 10),
                    AutoSize         = true
                };

                recentFileLink.LinkClicked += RecentFileClicked;

                tlTip.SetToolTip(recentFileLink
                    , (string)recentFileLink.Tag);

                flRecentFiles.Controls.Add(recentFileLink);
            }
        }

        private void LstLoggerKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoggerSelected(sender, e);
            }
        }
    }
}
