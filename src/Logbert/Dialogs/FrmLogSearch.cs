#region Copyright © 2015 Couchcoding

// File:    FrmLogSearch.cs
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

using Couchcoding.Logbert.Helper;
using Couchcoding.Logbert.Properties;
using System.Text.RegularExpressions;

using Couchcoding.Logbert.Interfaces;
using System.Collections.Specialized;
using System.Drawing;
using System.ComponentModel;

namespace Couchcoding.Logbert.Dialogs
{
  /// <summary>
  /// Implements a find window to search for text.
  /// </summary>
  public partial class FrmLogSearch : Form
  {
    #region Private Consts

    /// <summary>
    /// Defines the count of last searches to remember.
    /// </summary>
    private const int MAX_SEARCH_STRINGS_TO_REMEMBER = 10;

    #endregion

    #region Private Fields

    private readonly ISearchable mSearchable;

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets or sets the font of the text displayed by the control.
    /// </summary>
    /// <returns>The <see cref="T:System.Drawing.Font"/> to apply to the text displayed by the control. The default is the value of the <see cref="P:System.Windows.Forms.Control.DefaultFont"/> property.</returns>
    [AmbientValue(null)]
    [Localizable(true)]
    public sealed override Font Font
    {
      get
      {
        return base.Font;
      }
      set
      {
        base.Font = value;
      }
    }

    /// <summary>
    /// Gets the current selected search value.
    /// </summary>
    public string CurrentSearchValue
    {
      get
      {
        return cmbFindWhat.Text;
      }
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Handles the FormClosing event of the <see cref="FrmLogSearch"/> <see cref="Form"/>.
    /// </summary>
    private void FrmLogSearchFormClosing(object sender, FormClosingEventArgs e)
    {
      if (e.CloseReason == CloseReason.UserClosing)
      {
        // Just hide the window.
        Hide();

        // Ensure it won't be realy closed.
        e.Cancel = true;
      }
    }

    /// <summary>
    /// Handles the Load event of the <see cref="FrmLogSearch"/> <see cref="Form"/>.
    /// </summary>
    private void FrmLogSearchLoad(object sender, EventArgs e)
    {
      chkMatchCase.Checked      = Settings.Default.FrmFindSearchMatchCase;
      chkMatchWholeWord.Checked = Settings.Default.FrmFindSearchMatchWholeWord;
      chkUse.Checked            = Settings.Default.FrmFindSearchUseRegex ||
                                  Settings.Default.FrmFindSearchUseWildcard;

      cmbRegexWildcard.SelectedIndex = Settings.Default.FrmFindSearchUseWildcard 
        ? 1  // Wildcard
        : 0; // Regular Expression (.NET)
    }

    /// <summary>
    /// Gets the last used search <see cref="String"/>s as an <see cref="Array"/>.
    /// </summary>
    /// <returns>An <see cref="Array"/> of <see cref="String"/>s that contains the last used search values.</returns>
    private static string[] GetLastUsedSearchValues()
    {
      StringCollection strValues = 
           Settings.Default.FrmFindSearchValue 
        ?? new StringCollection();

      if (strValues.Count == 0 || !strValues.Contains(string.Empty))
      {
        // Ensure the very first entry is an empty string.
        strValues.Insert(0, string.Empty);
      }

      string[] lastSearchValues = new string[strValues.Count];
      strValues.CopyTo(lastSearchValues, 0);

      return lastSearchValues;
    }

    /// <summary>
    /// Handles the CheckedChanged event of the use regex or wildcard <see cref="CheckBox"/>.
    /// </summary>
    private void ChkUseCheckedChanged(object sender, EventArgs e)
    {
      cmbRegexWildcard.Enabled = chkUse.Checked;

      CmbRegexWildcardSelectedIndexChanged(
          sender
        , e);
    }

    /// <summary>
    /// Handles the CheckedChanged event of the match whole word <see cref="CheckBox"/>.
    /// </summary>
    private void ChkMatchWholeWordCheckedChanged(object sender, EventArgs e)
    {
      Settings.Default.FrmFindSearchMatchWholeWord = chkMatchWholeWord.Checked;
      Settings.Default.SaveSettings();
    }

    /// <summary>
    /// Handles the CheckedChanged event of the match case <see cref="CheckBox"/>.
    /// </summary>
    private void ChkMatchCaseCheckedChanged(object sender, EventArgs e)
    {
      Settings.Default.FrmFindSearchMatchCase = chkMatchCase.Checked;
      Settings.Default.SaveSettings();
    }

    /// <summary>
    /// Handles the TextUpdate event of the search <see cref="ComboBox"/>.
    /// </summary>
    private void CmbFindWhatTextUpdate(object sender, EventArgs e)
    {
      bool valueValid = !string.IsNullOrEmpty(cmbFindWhat.Text);

      btnFindNext.Enabled     = valueValid;
      btnFindPrevious.Enabled = valueValid;
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the search <see cref="ComboBox"/>.
    /// </summary>
    private void CmbFindWhatSelectedIndexChanged(object sender, EventArgs e)
    {
      CmbFindWhatTextUpdate(sender, e);
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the regex or wildcard <see cref="ComboBox"/>.
    /// </summary>
    private void CmbRegexWildcardSelectedIndexChanged(object sender, EventArgs e)
    {
      if (cmbRegexWildcard.SelectedIndex == -1)
      {
        return;
      }

      Settings.Default.FrmFindSearchUseRegex    = chkUse.Checked && cmbRegexWildcard.SelectedIndex == 0;
      Settings.Default.FrmFindSearchUseWildcard = chkUse.Checked && cmbRegexWildcard.SelectedIndex == 1;

      Settings.Default.SaveSettings();
    }

    /// <summary>
    /// Rebuilds the list of last used search values.
    /// </summary>
    private void RebuildSearchValuesList()
    {
      if (Settings.Default.FrmFindSearchValue == null)
      {
        // The list may be null on very first search.
        Settings.Default.FrmFindSearchValue = new StringCollection();
      }

      // Ensure only the last 10 search strings are saved.
      if (!Settings.Default.FrmFindSearchValue.Contains(cmbFindWhat.Text))
      {
        Settings.Default.FrmFindSearchValue.Insert(0, cmbFindWhat.Text);

        if (Settings.Default.FrmFindSearchValue.Count > MAX_SEARCH_STRINGS_TO_REMEMBER)
        {
          StringCollection newStrCollection = new StringCollection();

          for (int srcStrCnt = 0; srcStrCnt < MAX_SEARCH_STRINGS_TO_REMEMBER; ++srcStrCnt)
          {
            if (string.IsNullOrEmpty(Settings.Default.FrmFindSearchValue[srcStrCnt]))
            {
              continue;
            }

            newStrCollection.Add(Settings.Default.FrmFindSearchValue[srcStrCnt]);
          }

          Settings.Default.FrmFindSearchValue = newStrCollection;
        }

        Settings.Default.SaveSettings();

        cmbFindWhat.Items.Clear();
        cmbFindWhat.Items.AddRange(GetLastUsedSearchValues());
      }
    }

    /// <summary>
    /// Looks for the next match of the entered search value.
    /// </summary>
    private void BtnFindNextClick(object sender, EventArgs e)
    {
      PerformSearch(cmbFindWhat.Text);
    }

    /// <summary>
    /// Looks for the previous match of the entered search value.
    /// </summary>
    private void BtnFindPreviousClick(object sender, EventArgs e)
    {
      PerformSearch(cmbFindWhat.Text, true);
    }

    /// <summary>
    /// Processes a command key. 
    /// </summary>
    /// <returns><c>True</c> if the keystroke was processed and consumed by the control; otherwise, <c>False</c> to allow further processing.</returns>
    /// <param name="msg">A <see cref="T:System.Windows.Forms.Message"/>, passed by reference, that represents the Win32 message to process. </param><param name="keyData">One of the <see cref="T:System.Windows.Forms.Keys"/> values that represents the key to process. </param>
    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Escape)
      {
        // Close the window.
        Close();

        // The key is handled.
        return true;
      }

      return base.ProcessCmdKey(ref msg, keyData);
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Performs a search for the given string value.
    /// </summary>
    /// <param name="searchString">The value to search for.</param>
    /// <param name="previous">Determines whether the previous value should be searched, ot the next one.</param>
    internal void PerformSearch(string searchString, bool previous = false)
    {
      if (string.IsNullOrEmpty(searchString) || mSearchable == null)
      {
        // Nothing to search for.
        return;
      }

      if (Settings.Default.FrmFindSearchUseWildcard)
      {
        searchString = searchString.ToRegex();
      }

      if (!Settings.Default.FrmFindSearchUseWildcard
      &&  !Settings.Default.FrmFindSearchUseRegex)
      {
        searchString = string.Format(
            "{1}{0}{1}"
          , Regex.Escape(searchString)
          , Settings.Default.FrmFindSearchMatchWholeWord 
            ? "\\b" 
            : string.Empty);
      }

      using (new WaitCursor(Cursors.Default, Settings.Default.WaitCursorTimeout))
      {
        mSearchable.SearchLogMessage(
            searchString
          , !previous
          , cmbLookIn.SelectedIndex == 1);

        RebuildSearchValuesList();
      }
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Creates a new instance of the <see cref="FrmLogSearch"/> window.
    /// </summary>
    public FrmLogSearch(ISearchable searchable)
    {
      InitializeComponent();

      Font                    = SystemFonts.MessageBoxFont;
      mSearchable             = searchable;
      cmbLookIn.SelectedIndex = 0;

      cmbFindWhat.Items.AddRange(GetLastUsedSearchValues());
    }

    #endregion
  }
}
