#region Copyright © 2016 Couchcoding

// File:    FrmColumnizer.cs
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

using Couchcoding.Logbert.Gui.Controls;
using Couchcoding.Logbert.Gui.Dialogs;
using Couchcoding.Logbert.Receiver.CustomReceiver;
using System.Collections.Generic;
using Couchcoding.Logbert.Properties;
using System.Text.RegularExpressions;

namespace Couchcoding.Logbert.Dialogs
{
  /// <summary>
  /// Implements a dialog to edit <see cref="LogColumn"/>s for a custom receiver.
  /// </summary>
  public partial class FrmColumnizer : DialogForm
  {
    #region Private Fields

    /// <summary>
    /// Holds the currently edited <see cref="Columnizer"/> instance.
    /// </summary>
    private readonly Columnizer mColumnizer;

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets the configured <see cref="Columnizer"/> instance.
    /// </summary>
    public Columnizer Columnizer
    {
      get
      {
        if (mColumnizer.Columns == null)
        {
          // Create a new column collection.
          mColumnizer.Columns = new List<LogColumn>();
        }
        else
        {
          // Clear existing columns.
          mColumnizer.Columns.Clear();
        }

        mColumnizer.Name = txtName.Text;

        foreach (DataGridViewRow dgvRow in dgvColumns.Rows)
        {
          bool optional = (bool)dgvRow.Cells[2].Value;

          LogColumnType columnType = (LogColumnType)System.Enum.Parse(
              typeof(LogColumnType)
            , (string)dgvRow.Cells[3].Value);

          mColumnizer.Columns.Add(new LogColumn(
              (string)dgvRow.Cells[0].Value
            , (string)dgvRow.Cells[1].Value
            , optional
            , columnType));
        }

        return mColumnizer;
      }
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Form.Load"/> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data. </param>
    protected override void OnLoad(System.EventArgs e)
    {
      base.OnLoad(e);

      if (mColumnizer != null)
      {
        txtName.Text = mColumnizer.Name;

        foreach (LogColumn column in mColumnizer.Columns)
        {
          dgvColumns.Rows.Add(
              column.Name
            , column.Expression
            , column.Optional
            , column.ColumnType.ToString());
        }

        UpdateEditButtons();
      }
    }

    /// <summary>
    /// Processes a command key. 
    /// </summary>
    /// <returns><c>True</c> if the keystroke was processed and consumed by the control; otherwise, <c>False</c> to allow further processing.</returns>
    /// <param name="msg">A <see cref="T:System.Windows.Forms.Message"/>, passed by reference, that represents the Win32 message to process. </param><param name="keyData">One of the <see cref="T:System.Windows.Forms.Keys"/> values that represents the key to process. </param>
    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape && dgvColumns.EditingControl != null && dgvColumns.EditingControl.Focused)
      {
        // Cancel the editing.
        dgvColumns.CancelEdit();

        // Dispose the editing control.
        dgvColumns.EndEdit();

        // Don't close the dialog if the user cancels the editing.
        return true;
      }

      return base.ProcessCmdKey(
          ref msg
        , keyData);
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
        if (string.IsNullOrEmpty(txtName.Text))
        {
          MessageBox.Show(
              this
            , Resources.strColumnizerConfigurationPleaseEnterName
            , Application.ProductName
            , MessageBoxButtons.OK
            , MessageBoxIcon.Error);

          txtName.Select();
          return false;
        }

        if (dgvColumns.RowCount == 0)
        {
          MessageBox.Show(
              this
            , Resources.strColumnizerConfigurationAddAtLeastOneRow
            , Application.ProductName
            , MessageBoxButtons.OK
            , MessageBoxIcon.Error);

          dgvColumns.Select();
          return false;
        }

        foreach (DataGridViewRow dgvRow in dgvColumns.Rows)
        {
          if (string.IsNullOrEmpty(dgvRow.Cells[0].Value as string)
          ||  string.IsNullOrEmpty(dgvRow.Cells[1].Value as string))
          {
            MessageBox.Show(
                this
              , Resources.strColumnizerConfigurationEnterColumnNameAndExpression
              , Application.ProductName
              , MessageBoxButtons.OK
              , MessageBoxIcon.Error);

            dgvColumns.Select();
            return false;
          }
        }
      }

      return base.ValidateDialog(dlgResult);
    }

    /// <summary>
    /// Updates the enabled state of the <see cref="DataGridView"/> edit <see cref="ToolBarButton"/>s.
    /// </summary>
    private void UpdateEditButtons()
    {
      DataGridViewCell selectedCell = dgvColumns.CurrentCell;
      bool             isEditing    = selectedCell != null && dgvColumns.EditingControl != null;

      tsbEditColumn.Enabled   = !isEditing && selectedCell != null;
      tsbRemoveColumn.Enabled = !isEditing && selectedCell != null;

      tsbMoveUp.Enabled       = !isEditing && selectedCell != null 
                                           && selectedCell.OwningRow.Index >  0 
                                           && dgvColumns.RowCount > 1;

      tsbMoveDown.Enabled     = !isEditing && selectedCell != null 
                                           && selectedCell.OwningRow.Index >= 0 
                                           && selectedCell.OwningRow.Index < dgvColumns.RowCount - 1 
                                           && dgvColumns.RowCount > 1;

      tsbTestColumnizer.Enabled = !isEditing && dgvColumns.RowCount > 0;
    }

    /// <summary>
    /// Handles the EditingControlShowing event of the <see cref="DataGridView"/>.
    /// </summary>
    private void DgvColumnsEditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
      // Edit and delete is only possible if the cell is not in edit mode.
      UpdateEditButtons();
    }

    /// <summary>
    /// Handles the CellEndEdit of the <see cref="DataGridView"/>.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void DgvColumnsCellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
      // Edit and delete is only possible if the cell is not in edit mode.
      UpdateEditButtons();

      if (e.ColumnIndex == 1 && e.RowIndex > 0)
      {
        string valueToValidate = dgvColumns.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

        if (!string.IsNullOrEmpty(valueToValidate))
        {
          try
          {
            Regex validationRgx = new Regex(valueToValidate);

            if (validationRgx.GetGroupNumbers().Length == 1)
            {
              dgvColumns.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = string.Format(
                  "({0})"
                , valueToValidate);
            }
          }
          catch
          {
            // Catch all invalid input values.
          }
        }
      }
    }

    /// <summary>
    /// Handles the SelectionChanged of the <see cref="DataGridView"/>.
    /// </summary>
    private void DgvColumnsSelectionChanged(object sender, System.EventArgs e)
    {
      // Update the move up and down buttons.
      UpdateEditButtons();
    }

    /// <summary>
    /// Handles the Click event of the add column <see cref="ToolStripButton"/>.
    /// </summary>
    private void TsbAddColumnClick(object sender, System.EventArgs e)
    {
      int newRowIndex = dgvColumns.Rows.Add(
          Resources.strColumnizerColumnDefaultName
        , Resources.strColumnizerColumnDefaultExpresssion
        , false
        , LogColumnType.Unknown.ToString());

      if (newRowIndex != -1)
      {
        dgvColumns.ClearSelection();

        // Scroll to the first cell and select it.
        dgvColumns.CurrentCell          = dgvColumns.Rows[newRowIndex].Cells[0];
        dgvColumns.CurrentCell.Selected = true;

        dgvColumns.BeginEdit(true);
      }

      UpdateEditButtons();
    }

    /// <summary>
    /// Handles the Click event of the remove column <see cref="ToolStripButton"/>.
    /// </summary>
    private void TsbRemoveColumnClick(object sender, System.EventArgs e)
    {
      if (dgvColumns.SelectedCells.Count > 0)
      {
        dgvColumns.Rows.Remove(dgvColumns.SelectedCells[0].OwningRow);
      }

      UpdateEditButtons();
    }

    /// <summary>
    /// Handles the Click event of the edit column <see cref="ToolStripButton"/>.
    /// </summary>
    private void TsbEditColumnClick(object sender, System.EventArgs e)
    {
      if (dgvColumns.SelectedCells.Count == 1)
      {
        dgvColumns.BeginEdit(true);
      }
    }

    /// <summary>
    /// Handles the Click event of the move up <see cref="ToolStripButton"/>.
    /// </summary>
    private void TsbMoveUpClick(object sender, System.EventArgs e)
    {
      DataGridViewRow dgvrToMoveUp = dgvColumns.CurrentCell != null 
        ? dgvColumns.CurrentCell.OwningRow
        : null;

      if (dgvrToMoveUp != null && dgvrToMoveUp.Index > 0)
      {
        // Force the end edit to prevent exceptions.
        if (dgvColumns.EditingControl != null && !dgvColumns.EndEdit())
        {
          return;
        }

        int newIndex = dgvrToMoveUp.Index - 1 < 0
          ? 0
          : dgvrToMoveUp.Index - 1;

        int selCellIndex = dgvrToMoveUp.Cells[0].Selected
          ? 0
          : 1;

        dgvColumns.Rows.Remove(dgvrToMoveUp);

        dgvColumns.Rows.Insert(
            newIndex
          , dgvrToMoveUp);

        // Scroll to the first cell and select it.
        dgvColumns.CurrentCell          = dgvrToMoveUp.Cells[selCellIndex];
        dgvColumns.CurrentCell.Selected = true;
      }
    }

    /// <summary>
    /// Handles the Click event of the move down <see cref="ToolStripButton"/>.
    /// </summary>
    private void TsbMoveDownClick(object sender, System.EventArgs e)
    {
      DataGridViewRow dgvrToMoveDown = dgvColumns.CurrentCell != null 
        ? dgvColumns.CurrentCell.OwningRow
        : null;

      if (dgvrToMoveDown != null && dgvrToMoveDown.Index < dgvColumns.RowCount - 1 )
      {
        // Force the end edit to prevent exceptions.
        if (dgvColumns.EditingControl != null && !dgvColumns.EndEdit())
        {
          return;
        }

        int newIndex = dgvrToMoveDown.Index + 1 < dgvColumns.RowCount - 1  
          ? dgvrToMoveDown.Index + 1
          : dgvColumns.RowCount - 1;

        int selCellIndex = dgvrToMoveDown.Cells[0].Selected
          ? 0
          : 1;

        dgvColumns.Rows.Remove(dgvrToMoveDown);

        dgvColumns.Rows.Insert(
            newIndex
          , dgvrToMoveDown);

        // Scroll to the first cell and select it.
        dgvColumns.CurrentCell          = dgvrToMoveDown.Cells[selCellIndex];
        dgvColumns.CurrentCell.Selected = true;
      }
    }

    /// <summary>
    /// Handles the Click event of the test columnizer <see cref="ToolStripButton"/>.
    /// </summary>
    private void TsbTestColumnizerClick(object sender, System.EventArgs e)
    {
      // Create a new temporary columnizer object for testing.
      Columnizer tmpColumnizer = new Columnizer(txtName.Text);

      foreach (DataGridViewRow dgvRow in dgvColumns.Rows)
      {
        bool optional = dgvRow.Cells[2].Value != null;

        LogColumnType columnType = (LogColumnType)System.Enum.Parse(
            typeof(LogColumnType)
          , (string)dgvRow.Cells[3].Value);

        tmpColumnizer.Columns.Add(new LogColumn(
            (string)dgvRow.Cells[0].Value
          , (string)dgvRow.Cells[1].Value
          , optional
          , columnType));
      }

      using (FrmColumnizerTest testColumnizerDlg = new FrmColumnizerTest(tmpColumnizer))
      {
        testColumnizerDlg.ShowDialog(this);
      }
    }

    /// <summary>
    /// Handles the Click event of the edit log levels <see cref="ToolStripButton"/>.
    /// </summary>
    private void TsbEditLogLevelsClick(object sender, System.EventArgs e)
    {
      using (FrmLogLevelMap logLevelDlg = new FrmLogLevelMap(mColumnizer.LogLevelMapping))
      {
        if (logLevelDlg.ShowDialog(this) == DialogResult.OK)
        {
          mColumnizer.LogLevelMapping = logLevelDlg.LogLevelMapping;
        }
      }
    }

    /// <summary>
    /// Handles the Click event of the edit timestamp format <see cref="ToolStripButton"/>.
    /// </summary>
    private void TsbEditDateTimeFormatClick(object sender, System.EventArgs e)
    {
        using (FrmEditTimeStampFormat logLevelDlg = new FrmEditTimeStampFormat(mColumnizer.DateTimeFormat))
        {
            if (logLevelDlg.ShowDialog(this) == DialogResult.OK)
            {
                mColumnizer.DateTimeFormat = logLevelDlg.DateTimeFormat;
            }
        }
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Initializes a new instance of the <see cref="FrmColumnizer"/> dialog.
    /// </summary>
    public FrmColumnizer() : this(null)
    {

    }

    /// <summary>
    /// Initializes a new instance of the <see cref="FrmColumnizer"/> dialog with the specified parameters.
    /// </summary>
    /// <param name="columnizer">The <see cref="Columnizer"/> instance to edit.</param>
    public FrmColumnizer(Columnizer columnizer)
    {
      InitializeComponent();

      mColumnizer = columnizer ?? new Columnizer();

      // Apply a proper renderer for the embedded toolstrip.
      tsColumns.Renderer = new CustomToolStripSystemRenderer();
    }

    #endregion

  }
}
