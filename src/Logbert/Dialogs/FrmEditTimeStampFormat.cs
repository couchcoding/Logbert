#region Copyright © 2017 Couchcoding

// File:    FrmEditTimeStampFormat.cs
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

using System.Drawing;
using System.Windows.Forms;

using Couchcoding.Logbert.Gui.Dialogs;
using Couchcoding.Logbert.Receiver.CustomReceiver;

namespace Couchcoding.Logbert.Dialogs
{
  /// <summary>
  /// Implements a dialog to edit the timestamp format to parse.
  /// </summary>
  public partial class FrmEditTimeStampFormat : DialogForm
  {
    #region Public Properties

    /// <summary>
    /// Gets the specified timestamp format to parse.
    /// </summary>
    public string DateTimeFormat => txtTimestampFormat.Text ?? Columnizer.DefaultDateTimeFormat;

    #endregion

    #region Private Methods

    /// <summary>
    /// Handles the ButtonClick event of the timestamp help <see cref="Button"/>.
    /// </summary>
    private void TxtTimestampFormatButtonClick(object sender, System.EventArgs e)
    {
      Control btnTimestamp = sender as Control;

      if (btnTimestamp != null)
      {
        mnuTimestamp.Show(
            btnTimestamp
          , new Point(btnTimestamp.Width, btnTimestamp.Top));
      }
    }

    /// <summary>
    /// Handles the Click event of a timestamp preset <see cref="MenuItem"/>.
    /// </summary>
    private void MnuTimestampPresetClick(object sender, System.EventArgs e)
    {
      if (sender is MenuItem mnuCtrl && mnuCtrl.Tag != null)
      {
        txtTimestampFormat.Text = mnuCtrl.Tag.ToString();
      }
    }

    /// <summary>
    /// Handles the Click event of a timestamp help <see cref="MenuItem"/>.
    /// </summary>
    private void MnuTimestampClick(object sender, System.EventArgs e)
    {
      if (sender is MenuItem mnuCtrl && mnuCtrl.Tag != null)
      {
        txtTimestampFormat.SelectedText = mnuCtrl.Tag.ToString();
      }
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Initializes a new instance of the <see cref="FrmEditTimeStampFormat"/> dialog.
    /// </summary>
    public FrmEditTimeStampFormat()
    {
      InitializeComponent();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="FrmEditTimeStampFormat"/> dialog with the specified parameters.
    /// </summary>
    /// <param name="format">The initial timestamp format to display.</param>
    public FrmEditTimeStampFormat(string format)
    {
      InitializeComponent();

      txtTimestampFormat.Text = format ?? Columnizer.DefaultDateTimeFormat;
    }

    #endregion
  }
}
