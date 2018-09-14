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

using Couchcoding.Logbert.Gui.Dialogs;
using Couchcoding.Logbert.Helper;
using Couchcoding.Logbert.Interfaces;
using Couchcoding.Logbert.Logging.Filter;
using Couchcoding.Logbert.Properties;
using System.ComponentModel;

namespace Couchcoding.Logbert.Dialogs
{
  /// <summary>
  /// Implements the add and edit filter dialog.
  /// </summary>
  public partial class FrmAddEditFilter : DialogForm
  {
    #region Public Properties

    /// <summary>
    /// Gets or sets the title of the <see cref="Form"/>.
    /// </summary>
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [Description("Gets or sets the title of the Form.")]
    public override string Text
    {
      get
      {
        return base.Text;
      }

      set
      {
        base.Text = value;
      }
    }

    /// <summary>
    /// Gets the selected active state of the <see cref="LogFilter"/>.
    /// </summary>
    public bool IsFilterActive
    {
      get
      {
        return chkFilterIsActive.Checked;
      }
    }

    /// <summary>
    /// Gets the selected column index of the <see cref=LogFilter"/>.
    /// </summary>
    public int ColumnIndex
    {
      get
      {
        return cmbColumnToFilter.SelectedIndex + 1;
      }
    }

    /// <summary>
    /// Gets the selected operator index of the <see cref=LogFilter"/>.
    /// </summary>
    public int OperatorIndex
    {
      get
      {
        return cmbOperator.SelectedIndex;
      }
    }

    /// <summary>
    /// Gets the entered regular expression of the <see cref=LogFilter"/>.
    /// </summary>
    public string ExpressionRegex
    {
      get
      {
        return txtExpressionToFilterFor.Text;
      }
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Initializes a new instance of the <see cref="FrmAddEditFilter"/> with the specified parameters.
    /// </summary>
    /// <param name="filterToEdit">The <see cref=LogFilterColumn"/> to edit.</param>
    public FrmAddEditFilter(ILogProvider logProvider, LogFilterColumn filterToEdit)
    {
      InitializeComponent();

      // Adjust the title and caption of the dialog to match editing.
      Text              = Resources.strFilterDlgEditFilter;
      DialogMainCaption = Resources.strFilterDlgEditFilter;

      if (logProvider != null)
      {
        foreach (LogColumnData columnName in logProvider.Columns.Values)
        {
          cmbColumnToFilter.Items.Add(columnName.Name);
        }

        if (cmbColumnToFilter.Items.Count > 0)
        {
          cmbColumnToFilter.SelectedIndex = 0;
        }
      }

      cmbOperator.SelectedIndex = 0;

      if (filterToEdit != null)
      {
        chkFilterIsActive.Checked       = filterToEdit.IsActive;
        cmbColumnToFilter.SelectedIndex = filterToEdit.ColumnIndex - 1;
        cmbOperator.SelectedIndex       = filterToEdit.OperatorIndex;
        txtExpressionToFilterFor.Text   = filterToEdit.ColumnMatchValueRegEx;
      }
    }

    #endregion
  }
}

