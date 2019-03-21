#region Copyright © 2015 Couchcoding

// File:    OptionPanelScriptEditor.cs
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
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

using Couchcoding.Logbert.Helper;
using Couchcoding.Logbert.Interfaces;
using Couchcoding.Logbert.Properties;

namespace Couchcoding.Logbert.Controls.OptionPanels
{
  /// <summary>
  /// Implements a <see cref="IOptionPanel"/> for general application settings.
  /// </summary>
  public partial class OptionPanelScriptEditor : OptionPanelBase
  {
    #region Private Consts

    /// <summary>
    /// Defines the default font for the log window.
    /// </summary>
    private const string DEFAULT_FONT_NAME = "Courier New";

    /// <summary>
    /// Defines the default font size for the log window.
    /// </summary>
    private const int DEFAULT_FONT_SIZE = 9;

    #endregion

    #region Private Types

    /// <summary>
    /// A type to manage <see cref="CodeElement"/> formating.
    /// </summary>
    private class CodeElement
    {
      #region Private Fields

      /// <summary>
      /// The name of the <see cref="CodeElement"/>.
      /// </summary>
      private readonly string mName;

      /// <summary>
      /// The key to load and store the last used values.
      /// </summary>
      private readonly string mKey;

      #endregion

      #region Public Properties

      /// <summary>
      /// Gets or sets the forecolor of the <see cref="CodeElement"/>.
      /// </summary>
      public Color Forecolor
      {
        get;
        set;
      }

      /// <summary>
      /// Gets or sets the backcolor of the <see cref="CodeElement"/>.
      /// </summary>
      public Color Backcolor
      {
        get;
        set;
      }

      /// <summary>
      /// Determines whether the <see cref="CodeElement"/> is drawn bold, or not.
      /// </summary>
      public FontStyle Style
      {
        get;
        set;
      }

      #endregion

      #region Public Methods

      /// <summary>
      /// Returns the fully qualified type name of this instance.
      /// </summary>
      /// <returns> A <see cref="T:System.String"/> containing a fully qualified type name. </returns>
      public override string ToString()
      {
        return mName;
      }

      /// <summary>
      /// Initializes a new <see cref="CodeElement"/> from the given <paramref name="key"/>.
      /// </summary>
      /// <param name="name">The name of the <see cref="CodeElement"/>.</param>
      /// <param name="key">The settings key used to load existing values.</param>
      public static CodeElement Load(string name, string key)
      {
        CodeElement newElement = new CodeElement(name, key)
        {
          Forecolor = (Color)Settings.Default["CodeElement_"     + key + "_ForegroundColor"],
          Backcolor = (Color)Settings.Default["CodeElement_"     + key + "_BackgroundColor"],
          Style     = (FontStyle)Settings.Default["CodeElement_" + key + "_FontStyle"]
        };


        return newElement;
      }

      /// <summary>
      /// Saves the values to the settings key.
      /// </summary>
      public void Save()
      {
        Settings.Default["CodeElement_" + mKey + "_ForegroundColor"] = Forecolor;
        Settings.Default["CodeElement_" + mKey + "_BackgroundColor"] = Backcolor;
        Settings.Default["CodeElement_" + mKey + "_FontStyle"]       = Style;
      }

      #endregion

      #region Constructor

      /// <summary>
      /// Initializes a new <see cref="CodeElement "/> instance with the given parameters.
      /// </summary>
      /// <param name="name">The name of the new <see cref="CodeElement"/>.</param>
      /// <param name="key">The settings key of the <see cref="CodeElement"/>.</param>
      private CodeElement(string name, string key)
      {
        mName = name;
        mKey  = key;
      }

      #endregion
    }

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets the name of the <see cref="IOptionPanel"/> <see cref="System.Windows.Forms.Control"/>.
    /// </summary>
    public override string PanelName
    {
      get
      {
        return Resources.strOptionPanelScriptEditor;
      }
    }

    /// <summary>
    /// Gets the <see cref="System.Drawing.Image"/> to display left of the <see cref="IOptionPanel"/> name.
    /// </summary>
    public override Image Image
    {
      get
      {
        return Resources.Script_16x;
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
    /// Handles the SelectedIndexChanged event of the code element <see cref="ListBox"/>.
    /// </summary>
    private void LstElementsSelectedIndexChanged(object sender, EventArgs e)
    {
      CodeElement selectedElement = (CodeElement)lstElements.SelectedItem;

      clrDrpDwnFore.AddColors(selectedElement.Forecolor);
      clrDrpDwnBack.AddColors(selectedElement.Backcolor);
      
      cmbFontStyle.SelectedIndex = selectedElement.Style == FontStyle.Bold 
          ? 1 
          : 0;
    }

    /// <summary>
    /// Handles the OnValueChanged of the foreground <see cref="Color"/> <see cref="ColorPickerCtrl"/>.
    /// </summary>
    private void clrDrpDwnForeOnValueChanged(object sender, EventArgs e)
    {
      CodeElement selectedElement = (CodeElement)lstElements.SelectedItem;
      selectedElement.Forecolor   = clrDrpDwnFore.SelectedValue;
    }

    /// <summary>
    /// Handles the OnValueChanged of the background <see cref="Color"/> <see cref="ColorPickerCtrl"/>.
    /// </summary>
    private void clrDrpDwnBackOnValueChanged(object sender, EventArgs e)
    {
      CodeElement selectedElement = (CodeElement)lstElements.SelectedItem;
      selectedElement.Backcolor   = clrDrpDwnBack.SelectedValue;
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the <see cref="FontStyle"/> <see cref="ComboBox"/>.
    /// </summary>
    private void CmbFontStyleSelectedIndexChanged(object sender, EventArgs e)
    {
      CodeElement selectedElement = (CodeElement)lstElements.SelectedItem;
      
      selectedElement.Style = cmbFontStyle.SelectedIndex == 0 
        ? FontStyle.Regular 
        : FontStyle.Bold;
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
        if (fontStr == Settings.Default.ScriptEditorFontName)
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

      cmbFontSize.Text = Settings.Default.ScriptEditorFontSize.
        ToString(CultureInfo.InvariantCulture);

      nudTabSize.Value                = Settings.Default.ScriptEditorTabSize;
      chkInsertSpaceForTabs.Checked   = Settings.Default.ScriptEditorUseSpacesForTabs;
      chkWordWrap.Checked             = Settings.Default.ScriptEditorWordWrap;
      chkHighlightCurrentLine.Checked = Settings.Default.ScriptEditorHighlightCurrentLine;

      lstElements.Items.Add(CodeElement.Load("Bracket",          "Bracket"        ));
      lstElements.Items.Add(CodeElement.Load("Comment",          "Comment"        ));
      lstElements.Items.Add(CodeElement.Load("Default Text",     "DefaultText"    ));
      lstElements.Items.Add(CodeElement.Load("Identifier",       "Identifier"     ));
      lstElements.Items.Add(CodeElement.Load("Keyword",          "Keyword"        ));
      lstElements.Items.Add(CodeElement.Load("Logbert Function", "LogbertFunction"));
      lstElements.Items.Add(CodeElement.Load("Lua Function",     "LuaFunction"    ));
      lstElements.Items.Add(CodeElement.Load("Number",           "Number"         ));
      lstElements.Items.Add(CodeElement.Load("Operator",         "Operator"       ));
      lstElements.Items.Add(CodeElement.Load("String",           "String"         ));

      lstElements.SelectedIndex = 0;
    }

    /// <summary>
    /// Tells the <see cref="IOptionPanel"/> to save the new settings.
    /// </summary>
    public override void SaveSettings()
    {
      using (new WaitCursor(Cursors.Default, Settings.Default.WaitCursorTimeout))
      {
        Settings.Default.ScriptEditorFontName             = cmbFont.Text;
        Settings.Default.ScriptEditorTabSize              = (int)nudTabSize.Value;
        Settings.Default.ScriptEditorUseSpacesForTabs     = chkInsertSpaceForTabs.Checked;
        Settings.Default.ScriptEditorWordWrap             = chkWordWrap.Checked;
        Settings.Default.ScriptEditorHighlightCurrentLine = chkHighlightCurrentLine.Checked;

        int textSize;
        Settings.Default.ScriptEditorFontSize = int.TryParse(cmbFontSize.Text, out textSize)
          ? textSize
          : DEFAULT_FONT_SIZE;

        foreach (CodeElement codeElement in lstElements.Items)
        {
          codeElement.Save();
        }
      }
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Creates a new instance of the <see cref="OptionPanelScriptEditor"/>.
    /// </summary>
    public OptionPanelScriptEditor()
    {
      InitializeComponent();
    }

    #endregion
  }
}
