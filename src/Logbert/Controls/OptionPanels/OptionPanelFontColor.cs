#region Copyright © 2015 Couchcoding

// File:    OptionPanelFontColor.cs
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
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using System.ComponentModel;

using Couchcoding.Logbert.Helper;
using Couchcoding.Logbert.Interfaces;
using Couchcoding.Logbert.Properties;
using Couchcoding.Logbert.Theme.Palettes;

namespace Couchcoding.Logbert.Controls.OptionPanels
{
  /// <summary>
  /// Implements a <see cref="IOptionPanel"/> to setup font and colors.
  /// </summary>
  public partial class OptionPanelFontColor : OptionPanelBase
  {
    #region Private Consts

    /// <summary>
    /// Defines the default font for the log window.
    /// </summary>
    private const string DEFAULT_FONT_NAME = "Microsoft Sans Serif";

    /// <summary>
    /// Defines the default font size for the log window.
    /// </summary>
    private const int DEFAULT_FONT_SIZE = 9;

    #endregion

    #region Private Fields

    /// <summary>
    /// Holds the last selected theme name.
    /// </summary>
    private string mLastSelectedTheme;

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets the name of the <see cref="IOptionPanel"/> <see cref="System.Windows.Forms.Control"/>.
    /// </summary>
    public override string PanelName
    {
      get
      {
        return Resources.strOptionPanelFontColorName;
      }
    }

    /// <summary>
    /// Gets the <see cref="System.Drawing.Image"/> to display left of the <see cref="IOptionPanel"/> name.
    /// </summary>
    public override Image Image
    {
      get
      {
        return Resources.font_color;
      }
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Creates a list of all available fonts within the system.
    /// </summary>
    /// <returns>An <see cref="Array"/> of all font names within the system.</returns>
    private static string[] PopulateFontList()
    {
      var enumeratedFonts = new List<string>();

      // Gets the list of installed fonts.
      FontFamily[] ff = FontFamily.Families;

      foreach (FontFamily t in ff)
      {
        if (t.IsStyleAvailable(FontStyle.Regular) && t.IsStyleAvailable(FontStyle.Bold))
        {
          enumeratedFonts.Add(t.Name);
        }
      }

      return enumeratedFonts.ToArray();
    }

    /// <summary>
    /// Handles the Validating event of the font size <see cref="ComboBox"/>.
    /// </summary>
    private void CmbFontSizeValidating(object sender, CancelEventArgs e)
    {
      int enteredValue;
      if (!int.TryParse(cmbFontSize.Text, out enteredValue) || enteredValue < 6 || enteredValue > 24)
      {
        try
        {
          cmbFontSize.Text = Settings.Default.LogMessagesFontSize.
            ToString(CultureInfo.InvariantCulture);
        }
        catch
        {
          cmbFontSize.Text = DEFAULT_FONT_SIZE.
            ToString(CultureInfo.InvariantCulture);
        }
      }
    }

    /// <summary>
    /// Handles the SelectionChangeComitted event of the application theme <see cref="ComboBox"/>.
    /// </summary>
    private void CmbApplicationTheme_SelectionChangeCommitted(object sender, EventArgs e)
    {
      if (cmbApplicationTheme.Text.Equals(mLastSelectedTheme))
      {
        return;
      }

      mLastSelectedTheme = cmbApplicationTheme.Text;

      DialogResult applyColorSchemeResult = MessageBox.Show(this
        , string.Format(Resources.strOptionPanelFontColorApplyColorScheme, cmbApplicationTheme.Text)
        , Application.ProductName
        , MessageBoxButtons.YesNo
        , MessageBoxIcon.Question);

      if (applyColorSchemeResult == DialogResult.Yes)
      {
        this.SuspendDrawing();

        try
        {
          switch (cmbApplicationTheme.Text)
          {
            case "Visual Studio Light":
            case "Visual Studio Blue":
              clrDrpDwnForeTrace.AddColors(VisualStudioLightPalette.LevelForeColor["Trace"]);
              clrDrpDwnForeDebug.AddColors(VisualStudioLightPalette.LevelForeColor["Debug"]);
              clrDrpDwnForeInfo.AddColors(VisualStudioLightPalette.LevelForeColor["Info"]);
              clrDrpDwnForeWarning.AddColors(VisualStudioLightPalette.LevelForeColor["Warn"]);
              clrDrpDwnForeError.AddColors(VisualStudioLightPalette.LevelForeColor["Error"]);
              clrDrpDwnForeFatal.AddColors(VisualStudioLightPalette.LevelForeColor["Fatal"]);

              clrDrpDwnBackTrace.AddColors(VisualStudioLightPalette.LevelBackColor["Trace"]);
              clrDrpDwnBackDebug.AddColors(VisualStudioLightPalette.LevelBackColor["Debug"]);
              clrDrpDwnBackInfo.AddColors(VisualStudioLightPalette.LevelBackColor["Info"]);
              clrDrpDwnBackWarning.AddColors(VisualStudioLightPalette.LevelBackColor["Warn"]);
              clrDrpDwnBackError.AddColors(VisualStudioLightPalette.LevelBackColor["Error"]);
              clrDrpDwnBackFatal.AddColors(VisualStudioLightPalette.LevelBackColor["Fatal"]);
              break;

            case "Visual Studio Dark":
              clrDrpDwnForeTrace.AddColors(VisualStudioDarkPalette.LevelForeColor["Trace"]);
              clrDrpDwnForeDebug.AddColors(VisualStudioDarkPalette.LevelForeColor["Debug"]);
              clrDrpDwnForeInfo.AddColors(VisualStudioDarkPalette.LevelForeColor["Info"]);
              clrDrpDwnForeWarning.AddColors(VisualStudioDarkPalette.LevelForeColor["Warn"]);
              clrDrpDwnForeError.AddColors(VisualStudioDarkPalette.LevelForeColor["Error"]);
              clrDrpDwnForeFatal.AddColors(VisualStudioDarkPalette.LevelForeColor["Fatal"]);

              clrDrpDwnBackTrace.AddColors(VisualStudioDarkPalette.LevelBackColor["Trace"]);
              clrDrpDwnBackDebug.AddColors(VisualStudioDarkPalette.LevelBackColor["Debug"]);
              clrDrpDwnBackInfo.AddColors(VisualStudioDarkPalette.LevelBackColor["Info"]);
              clrDrpDwnBackWarning.AddColors(VisualStudioDarkPalette.LevelBackColor["Warn"]);
              clrDrpDwnBackError.AddColors(VisualStudioDarkPalette.LevelBackColor["Error"]);
              clrDrpDwnBackFatal.AddColors(VisualStudioDarkPalette.LevelBackColor["Fatal"]);
              break;
          }
        }
        finally
        {
          this.ResumeDrawing();
        }
      }
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Method will be called before the <see cref="IOptionPanel"/> is shown first.
    /// </summary>
    public override void InitializeControl()
    {
      string[] fontList = PopulateFontList();

      if (fontList.Length > 0)
      {
        cmbFont.Items.AddRange(fontList);
      }

      foreach (string fontStr in cmbFont.Items)
      {
        if (fontStr == Settings.Default.LogMessagesFontName)
        {
          cmbFont.SelectedItem = fontStr;
          break;
        }
      }

      if (cmbFont.SelectedItem == null)
      {
        // The font 'Microsoft Sans Serif' should always be available!
        cmbFont.Items.Add(DEFAULT_FONT_NAME);
        cmbFont.SelectedItem = DEFAULT_FONT_NAME;
      }

      cmbFontSize.Text = Settings.Default.LogMessagesFontSize.ToString(CultureInfo.InvariantCulture);

      clrDrpDwnForeTrace.AddColors(Settings.Default.ForegroundColorTrace);
      clrDrpDwnForeDebug.AddColors(Settings.Default.ForegroundColorDebug);
      clrDrpDwnForeInfo.AddColors(Settings.Default.ForegroundColorInfo);
      clrDrpDwnForeWarning.AddColors(Settings.Default.ForegroundColorWarning);
      clrDrpDwnForeError.AddColors(Settings.Default.ForegroundColorError);
      clrDrpDwnForeFatal.AddColors(Settings.Default.ForegroundColorFatal);

      clrDrpDwnBackTrace.AddColors(Settings.Default.BackgroundColorTrace);
      clrDrpDwnBackDebug.AddColors(Settings.Default.BackgroundColorDebug);
      clrDrpDwnBackInfo.AddColors(Settings.Default.BackgroundColorInfo);
      clrDrpDwnBackWarning.AddColors(Settings.Default.BackgroundColorWarning);
      clrDrpDwnBackError.AddColors(Settings.Default.BackgroundColorError);
      clrDrpDwnBackFatal.AddColors(Settings.Default.BackgroundColorFatal);

      cmbFontStyleTrace.SelectedIndex   = Settings.Default.FontStyleTrace   == FontStyle.Regular ? 0 : 1;
      cmbFontStyleDebug.SelectedIndex   = Settings.Default.FontStyleDebug   == FontStyle.Regular ? 0 : 1;
      cmbFontStyleInfo.SelectedIndex    = Settings.Default.FontStyleInfo    == FontStyle.Regular ? 0 : 1;
      cmbFontStyleWarning.SelectedIndex = Settings.Default.FontStyleWarning == FontStyle.Regular ? 0 : 1;
      cmbFontStyleError.SelectedIndex   = Settings.Default.FontStyleError   == FontStyle.Regular ? 0 : 1;
      cmbFontStyleFatal.SelectedIndex   = Settings.Default.FontStyleFatal   == FontStyle.Regular ? 0 : 1;
      
      cmbApplicationTheme.SelectedItem = Settings.Default.ApplicationTheme;
      chkDrawGrid.Checked              = Settings.Default.LogWindowDrawGrid;
      chkUseInvertedColors.Checked     = Settings.Default.UseInvertedColorForSelection;

      mLastSelectedTheme = cmbApplicationTheme.Text;
    }

    /// <summary>
    /// Tells the <see cref="IOptionPanel"/> to save the new settings.
    /// </summary>
    public override void SaveSettings()
    {
      using (new WaitCursor(Cursors.Default, Settings.Default.WaitCursorTimeout))
      {
        Settings.Default.LogMessagesFontName = cmbFont.Text;

        int textSize;
        Settings.Default.LogMessagesFontSize = int.TryParse(cmbFontSize.Text, out textSize)
          ? textSize
          : DEFAULT_FONT_SIZE;

        Settings.Default.BackgroundColorTrace   = clrDrpDwnBackTrace.SelectedValue;
        Settings.Default.BackgroundColorDebug   = clrDrpDwnBackDebug.SelectedValue;
        Settings.Default.BackgroundColorInfo    = clrDrpDwnBackInfo.SelectedValue;
        Settings.Default.BackgroundColorWarning = clrDrpDwnBackWarning.SelectedValue;
        Settings.Default.BackgroundColorError   = clrDrpDwnBackError.SelectedValue;
        Settings.Default.BackgroundColorFatal   = clrDrpDwnBackFatal.SelectedValue;

        Settings.Default.ForegroundColorTrace   = clrDrpDwnForeTrace.SelectedValue;
        Settings.Default.ForegroundColorDebug   = clrDrpDwnForeDebug.SelectedValue;
        Settings.Default.ForegroundColorInfo    = clrDrpDwnForeInfo.SelectedValue;
        Settings.Default.ForegroundColorWarning = clrDrpDwnForeWarning.SelectedValue;
        Settings.Default.ForegroundColorError   = clrDrpDwnForeError.SelectedValue;
        Settings.Default.ForegroundColorFatal   = clrDrpDwnForeFatal.SelectedValue;

        Settings.Default.FontStyleTrace   = cmbFontStyleTrace.SelectedIndex == 0 ? FontStyle.Regular : FontStyle.Bold;
        Settings.Default.FontStyleDebug   = cmbFontStyleDebug.SelectedIndex == 0 ? FontStyle.Regular : FontStyle.Bold;
        Settings.Default.FontStyleInfo    = cmbFontStyleInfo.SelectedIndex == 0 ? FontStyle.Regular : FontStyle.Bold;
        Settings.Default.FontStyleWarning = cmbFontStyleWarning.SelectedIndex == 0 ? FontStyle.Regular : FontStyle.Bold;
        Settings.Default.FontStyleError   = cmbFontStyleError.SelectedIndex == 0 ? FontStyle.Regular : FontStyle.Bold;
        Settings.Default.FontStyleFatal   = cmbFontStyleFatal.SelectedIndex == 0 ? FontStyle.Regular : FontStyle.Bold;

        Settings.Default.LogWindowDrawGrid            = chkDrawGrid.Checked;
        Settings.Default.ApplicationTheme             = cmbApplicationTheme.Text;
        Settings.Default.UseInvertedColorForSelection = chkUseInvertedColors.Checked;

        Settings.Default.SaveSettings();
      }
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Creates a new instance of the <see cref="OptionPanelFontColor"/>.
    /// </summary>
    public OptionPanelFontColor()
    {
      InitializeComponent();
    }

    #endregion
  }
}
