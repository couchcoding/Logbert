#region Copyright © 2015 Couchcoding

// File:    FrmAbout.cs
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

using Couchcoding.Logbert.Gui.Dialogs;
using Couchcoding.Logbert.Helper;
using Couchcoding.Logbert.Properties;

namespace Couchcoding.Logbert.Dialogs
{
  /// <summary>
  /// Implements the about dialog.
  /// </summary>
  public partial class FrmAbout : DialogForm
  {
    #region Private Methods

    /// <summary>
    /// Handles the LinkClicked event of the copy to clipboard <see cref="LinkLabelEx"/>.
    /// </summary>
    private void LinkLabelEx1LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      this.CopyToClipboard(txtLicense.Text);
    }

    /// <summary>
    /// Handles the DoubleClick event of the <see cref="ListViewEx"/>.
    /// <remarks>Opens the default webbrowser if the user double clicks on a link.</remarks>
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void LstComponentsDoubleClick(object sender, EventArgs e)
    {
      ListViewHitTestInfo info = lstComponents.HitTest(lstComponents.PointToClient(MousePosition));

      if (info.SubItem != null && info.SubItem.Text.StartsWith("http"))
      {
        Browser.Open(info.SubItem.Text, this);
      }
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Creates a new instance of the <see cref="FrmAbout"/> dialog.
    /// </summary>
    public FrmAbout()
    {
      InitializeComponent();

      lblVersion.Text = string.Format(
          Resources.strAboutDlgVersion
        , Application.ProductVersion);

      lblCopyright.Text = Resources.strAboutDlgCopyright;
    }

    #endregion
  }
}
