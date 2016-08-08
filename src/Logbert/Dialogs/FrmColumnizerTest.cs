#region Copyright © 2016 Couchcoding

// File:    FrmColumnizerTest.cs
// Package: Logbert
// Project: Logbert
// 
// The MIT License (MIT)
// 
// Copyright (c) 2016 Couchcoding
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
using Com.Couchcoding.Logbert.Receiver.CustomReceiver;
using System.Text.RegularExpressions;

namespace Com.Couchcoding.Logbert.Dialogs
{
  /// <summary>
  /// Imnplements a dialog to test a spezified <see cref="Columnizer"/>.
  /// </summary>
  public partial class FrmColumnizerTest : DialogForm
  {
    #region Private Fields

    /// <summary>
    /// Holds the <see cref="Columnizer"/> instance to test.
    /// </summary>
    private readonly Columnizer mColumnizer;

    #endregion

    #region Private Methods

    /// <summary>
    /// Gets a <see cref="DataGridViewRow"/> that tags the spezified <paramref name="column."/>
    /// </summary>
    /// <param name="column">The <see cref="LogColumn"/> that is tagged in a <see cref="DataGridViewRow"/>.</param>
    /// <returns>The <see cref="DataGridViewRow"/> that tags the spezified <paramref name="column."/>; or <c>null</c> if none is found.</returns>
    private DataGridViewRow GetRowWithTag(LogColumn column)
    {
      foreach (DataGridViewRow dgvRow in dgvResult.Rows)
      {
        if (Equals(dgvRow.Tag, column))
        {
          return dgvRow;
        }
      }

      return null;
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Form.Load"/> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data. </param>
    protected override void OnLoad(System.EventArgs e)
    {
      base.OnLoad(e);

      if (mColumnizer == null || mColumnizer.Columns.Count == 0)
      {
        // Nothing to validate in this case.
        txtLogValue.Enabled = false;
        dgvResult.Enabled   = false;

        return;
      }

      // Initialize the data grid with the specified columns.
      foreach (LogColumn column in mColumnizer.Columns)
      {
        int rowIndex = dgvResult.Rows.Add(
            column.Name
          , string.Empty);

        if (rowIndex != -1)
        {
          dgvResult.Rows[rowIndex].Tag = column;
        }
      }
    }

    /// <summary>
    /// Handles the TextChanged event of the test log value <see cref="TextBox"/>.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TxtLogValueTextChanged(object sender, System.EventArgs e)
    {
      if (mColumnizer == null || mColumnizer.Columns.Count == 0)
      {
        return;
      }

      foreach (LogColumn column in mColumnizer.Columns)
      {
        Regex tmpRgx = new Regex(
            column.Expression
          , RegexOptions.Multiline);

        DataGridViewRow affectedRow = GetRowWithTag(column);

        if (affectedRow == null)
        {
          return;
        }

        Match tmpMtc = tmpRgx.Match(txtLogValue.Text);

        affectedRow.Cells[1].Value = tmpMtc.Groups.Count > 1
          ? tmpMtc.Groups[1].Value
          : string.Empty;
      }
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Initializes a new instance of the <see cref="FrmColumnizerTest"/> dialog.
    /// </summary>
    public FrmColumnizerTest()
    {
      InitializeComponent();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="FrmColumnizerTest"/> dialog.
    /// </summary>
    /// <param name="columnizer">The <see cref="Columnizer"/> instance to test.</param>
    public FrmColumnizerTest(Columnizer columnizer)
    {
      mColumnizer = columnizer;

      InitializeComponent();
    }

    #endregion
  }
}
