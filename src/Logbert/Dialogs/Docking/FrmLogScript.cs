  #region Copyright © 2015 Couchcoding

// File:    FrmLogScript.cs
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
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;

using Couchcoding.Logbert.Helper;
using Couchcoding.Logbert.Interfaces;
using Couchcoding.Logbert.Logging;

using ScintillaNET;

using WeifenLuo.WinFormsUI.Docking;
using MoonSharp.Interpreter;
using Couchcoding.Logbert.Properties;
using System.Configuration;
using Couchcoding.Logbert.Theme.Palettes;
using Couchcoding.Logbert.Theme.Interfaces;
using Couchcoding.Logbert.Theme;
using Couchcoding.Logbert.Theme.Themes;

namespace Couchcoding.Logbert.Dialogs.Docking
{
  /// <summary>
  /// Implements the <see cref="DockContent"/> of the script window.
  /// </summary>
  public partial class FrmLogScript : DockContent, ILogPresenter, IBookmarkObserver, IThemable
  {
    #region Private Consts

    /// <summary>
    /// Defines the additional editor <see cref="Padding"/> on the left side of the text edit area.
    /// </summary>
    private const int EDITOR_PADDING = 2;

    /// <summary>
    /// Defines all known build in Lua keywords for auto completion.
    /// </summary>
    private const string LUA_AUTOCOMPLETE_KEYWORKDS = "function end for false true break and not if nil or then while until repeat MsgBox Debug SetBookmark DelBookmark GetMessage OnBookmarksChanged OnMessagesReceived";

    /// <summary>
    /// Defines all known build in Lua keywords for build in functions.
    /// </summary>
    private const string LUA_KEYWORDS_0 = "and break do else elseif end false for function if in local nil not or repeat return then true until while _VERSION assert collectgarbage dofile error gcinfo loadfile loadstring print rawget rawset require tonumber tostring type unpack assert collectgarbage dofile error gcinfo loadfile loadstring print rawget rawset require tonumber tostring type unpack abs acos asin atan atan2 ceil cos deg exp floor format frexp gsub ldexp log log10 max min mod rad random randomseed sin sqrt strbyte strchar strfind strlen strlower strrep strsub strupper tan string.byte string.char string.dump string.find string.len";

    /// <summary>
    /// Defines all known build in Lua keywords for add-on functions.
    /// </summary>
    private const string LUA_KEYWORDS_1 = "string.lower string.rep string.sub string.upper string.format string.gfind string.gsub table.concat table.foreach table.foreachi table.getn table.sort table.insert table.remove table.setn math.abs math.acos math.asin math.atan math.atan2 math.ceil math.cos math.deg math.exp math.floor math.frexp math.ldexp math.log math.log10 math.max math.min math.mod math.pi math.pow math.rad math.random math.randomseed math.sin math.sqrt math.tan string.gmatch string.match string.reverse table.maxn math.cosh math.fmod math.modf math.sinh math.tanh math.huge sort tinsert tremove";

    /// <summary>
    /// Defines all Logbert internal functions.
    /// </summary>
    private const string LUA_KEYWORDS_2 = "Debug MsgBox SetBookmark DelBookmark GetLogMessage OnBookmarksChanged OnMessagesReceived";

    /// <summary>
    /// Defines the minimum font size (em) for the <see cref="Script"/> editor.
    /// </summary>
    private const int MIN_ZOOM_LEVEL = -10;

    /// <summary>
    /// Defines the maximum font size (em) for the <see cref="Script"/> editor.
    /// </summary>
    private const int MAX_ZOOM_LEVEL = 20;

    /// <summary>
    /// Defines the default <see cref="Font"/> name for the <see cref="FrmLogWindow"/>.
    /// </summary>
    private const string DEFAULT_FONT_NAME = "Courier New";

    /// <summary>
    /// Defines the default <see cref="Font"/> size for the <see cref="FrmLogWindow"/>.
    /// </summary>
    private const int DEFAULT_FONT_SIZE = 9;

    #endregion

    #region Private Fields

    /// <summary>
    /// Holds the last calculated line number area width.
    /// </summary>
    private int mMaxLineNumberCharLength;

    /// <summary>
    /// Holds the last caret position wihtin the <see cref="Scintilla"/> edit <see cref="Control"/>.
    /// </summary>
    private int mLastCaretPos;

    /// <summary>
    /// Determines whether the script is running, or not.
    /// </summary>
    private volatile bool mLuaScriptRunning;

    /// <summary>
    /// The Lua <see cref="Script"/> that is executing.
    /// </summary>
    private Script mLuaScript;

    /// <summary>
    /// A simple <see cref="object"/> for thread synchronization.
    /// </summary>
    private static readonly object mSync = new object();

    /// <summary>
    /// The <see cref="IBookmarkProvider"/> instance for bookmark handling.
    /// </summary>
    private readonly IBookmarkProvider mBookmarkProvider;

    /// <summary>
    /// The <see cref="ILogContainer"/> instance that provides received <see cref="LogMessage"/>.
    /// </summary>
    private readonly ILogContainer mLogContainer;

    #endregion

    #region Private Delegates

    /// <summary>
    /// Delegate used to start the asynchronous Lua <see cref="Script"/> execution.
    /// </summary>
    /// <param name="luaCode">The Lua <see cref="Script"/> to execute.</param>
    private delegate void StartLuaScriptDelegate(string luaCode);

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets the count of currently displayed <see cref="LogMessage"/>s.
    /// </summary>
    public int DisplayedLogMessagesCount
    {
      get
      {
        return 0;
      }
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Handles the Opening event of the <see cref="ContextMenuStrip"/>.
    /// </summary>
    private void CmsLuaEditOpening(object sender, CancelEventArgs e)
    {
      bool textSelected  = !string.IsNullOrEmpty(scintilla.SelectedText);
      bool textAvailable = !string.IsNullOrEmpty(scintilla.Text) && !mLuaScriptRunning;

      cmsLuaEditUndo.Enabled      = !mLuaScriptRunning && scintilla.CanUndo;
      cmsLuaEditRedo.Enabled      = !mLuaScriptRunning && scintilla.CanRedo;
      cmsLuaEditCut.Enabled       = textSelected && !mLuaScriptRunning;
      cmsLuaEditCopy.Enabled      = textSelected;
      cmsLuaEditPaste.Enabled     = Clipboard.ContainsText() && scintilla.Focused && !scintilla.ReadOnly && !mLuaScriptRunning;
      cmsLuaEditDelete.Enabled    = textSelected;
      cmsLuaEditSelectAll.Enabled = textAvailable;
    }

    /// <summary>
    /// Handles the Click event of the zoom in <see cref="ToolStripButton"/>.
    /// </summary>
    private void TsbZoomInClick(object sender, EventArgs e)
    {
      bool futherZoomInPossible = ZoomIn();

      tsbZoomIn.Enabled  = futherZoomInPossible;
      tsbZoomOut.Enabled = true;
    }

    /// <summary>
    /// Handles the Click event of the zoom out <see cref="ToolStripButton"/>.
    /// </summary>
    private void TsbZoomOutClick(object sender, EventArgs e)
    {
      bool futherZoomOutPossible = ZoomOut();

      tsbZoomIn.Enabled  = true;
      tsbZoomOut.Enabled = futherZoomOutPossible;
    }

    /// <summary>
    /// Handles the Text Changed event of the <see cref="Scintilla"/> edit <see cref=" Control"/>.
    /// </summary>
    private void ScintillaTextChanged(object sender, EventArgs e)
    {
      // Did the number of characters in the line number display change?
      // i.e. nnn VS nn, or nnnn VS nn, etc...
      var lineNumberCharLength = scintilla.Lines.Count.ToString().Length;

      if (lineNumberCharLength != mMaxLineNumberCharLength)
      {
        // Calculate the width required to display the last line number and include some padding for good measure.
        scintilla.Margins[0].Width = scintilla.TextWidth(
            Style.LineNumber
          , new string('9', lineNumberCharLength + 1)) + EDITOR_PADDING;

        mMaxLineNumberCharLength = lineNumberCharLength;
      }
    }

    /// <summary>
    /// Handles the Update UI event of the <see cref="Scintilla"/> edit <see cref="Control"/>.
    /// </summary>
    private void ScintillaUpdateUi(object sender, UpdateUIEventArgs e)
    {
      // Has the caret changed position?
      int caretPos = scintilla.CurrentPosition;

      if (mLastCaretPos != caretPos)
      {
        mLastCaretPos = caretPos;
        int bracePos1 = -1;

        // Is there a brace to the left or right?
        if (caretPos > 0 && IsBrace(scintilla.GetCharAt(caretPos - 1)))
        {
          bracePos1 = (caretPos - 1);
        }
        else if (IsBrace(scintilla.GetCharAt(caretPos)))
        {
          bracePos1 = caretPos;
        }

        if (bracePos1 >= 0)
        {
          // Find the matching brace.
          int bracePos2 = scintilla.BraceMatch(bracePos1);

          if (bracePos2 == Scintilla.InvalidPosition)
          {
            scintilla.BraceBadLight(bracePos1);
          }
          else
          {
            scintilla.BraceHighlight(
                bracePos1
              , bracePos2);
          }
        }
        else
        {
          // Turn off brace matching
          scintilla.BraceHighlight(
              Scintilla.InvalidPosition
            , Scintilla.InvalidPosition);
        }
      }

      bool textSelected  = !string.IsNullOrEmpty(scintilla.SelectedText);
      bool textAvailable = !string.IsNullOrEmpty(scintilla.Text) && !mLuaScriptRunning;

      tsbUndo.Enabled       = !mLuaScriptRunning && scintilla.CanUndo;
      tsbRedo.Enabled       = !mLuaScriptRunning && scintilla.CanRedo;
      tsbLoadScript.Enabled = !mLuaScriptRunning;
      tsbSaveScript.Enabled = textAvailable;
      tsbCut.Enabled        = textSelected && !mLuaScriptRunning;
      tsbCopy.Enabled       = textSelected;
      tsbPaste.Enabled      = Clipboard.ContainsText() && scintilla.Focused && !scintilla.ReadOnly && !mLuaScriptRunning;
      tsbStart.Enabled      = textAvailable;
      tsbStop.Enabled       = mLuaScriptRunning;
    }

    /// <summary>
    /// Handles the Zoom event of the <see cref="Scintilla"/> <see cref="Script"/> editor.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ScintillaZoomChanged(object sender, EventArgs e)
    {
      tsbZoomIn.Enabled  = scintilla.Zoom < MAX_ZOOM_LEVEL;
      tsbZoomOut.Enabled = scintilla.Zoom > MIN_ZOOM_LEVEL;
    }

    /// <summary>
    /// Handles the Char Added event of the <see cref="Scintilla"/> edit <see cref="Control"/>.
    /// </summary>
    private void ScintillaCharAdded(object sender, CharAddedEventArgs e)
    {
      if (scintilla.ReadOnly)
      {
        return;
      }

      // Find the word start.
      int currentPos   = scintilla.CurrentPosition;
      int wordStartPos = scintilla.WordStartPosition(
          currentPos
        , true);

      // Display the autocompletion list.
      int lenEntered = currentPos - wordStartPos;

      if (lenEntered > 0)
      {
        scintilla.AutoCShow(
            lenEntered
          , LUA_AUTOCOMPLETE_KEYWORKDS);
      }
    }

    /// <summary>
    /// Determines whether the given character (code) is a brace, or not.
    /// </summary>
    /// <param name="c">The character (code) to validate.</param>
    /// <returns><c>True</c> if the character provided is a brace, otherwise <c>false</c>.</returns>
    private static bool IsBrace(int c)
    {
      switch (c)
      {
        case '(':
        case ')':
        case '[':
        case ']':
        case '{':
        case '}':
          return true;
      }

      return false;
    }

    /// <summary>
    /// Initializes the <see cref="Scintilla"/> edit <see cref="Control"/>.
    /// </summary>
    private void InitializeScintilaCtrl()
    {
      scintilla.Margins[(int)MarginType.Number].Width = 16;

      scintilla.Lexer            = Lexer.Lua;
      scintilla.CaretLineVisible = Settings.Default.ScriptEditorHighlightCurrentLine;

      // Configuring the default style with properties we have common to every lexer style saves time.
      scintilla.StyleResetDefault();

      if (!string.IsNullOrEmpty(Settings.Default.LogMessagesFontName))
      {
        try
        {
          Settings.Default.SettingChanging -= DefaultSettingChanging;

          scintilla.Styles[Style.Default].Font = Settings.Default.ScriptEditorFontName;
          scintilla.Styles[Style.Default].Size = Settings.Default.ScriptEditorFontSize;
        }
        catch
        {
          // Reset the font on error and save the changed settings as new default.
          Settings.Default.LogMessagesFontName = DEFAULT_FONT_NAME;
          Settings.Default.LogMessagesFontSize = DEFAULT_FONT_SIZE;

          Settings.Default.SaveSettings();
        }
        finally
        {
          Settings.Default.SettingChanging += DefaultSettingChanging;
        }
      }

      scintilla.Styles[Style.Default].Font = Settings.Default.ScriptEditorFontName;
      scintilla.Styles[Style.Default].Size = Settings.Default.ScriptEditorFontSize;

      scintilla.StyleClearAll();
      
      // Configure a margin to display folding symbols.
      scintilla.Margins[(int)MarginType.BackColor].Type      = MarginType.Symbol;
      scintilla.Margins[(int)MarginType.BackColor].Mask      = Marker.MaskFolders;
      scintilla.Margins[(int)MarginType.BackColor].Sensitive = true;
      scintilla.Margins[(int)MarginType.BackColor].Width     = 20;

      scintilla.Styles[Style.LineNumber].ForeColor = ThemeManager.CurrentApplicationTheme.ColorPalette.ContentForegroundDimmed;
      scintilla.Styles[Style.LineNumber].BackColor = ThemeManager.CurrentApplicationTheme.ColorPalette.ContentBackground;
      scintilla.Styles[Style.Default].BackColor    = Settings.Default.CodeElement_DefaultText_BackgroundColor;

      // Set colors for all folding markers.
      for (int i = 0; i <= scintilla.Markers.Count; ++i)
      {
        scintilla.Markers[i].SetForeColor(ThemeManager.CurrentApplicationTheme.ColorPalette.ContentBackground);
        scintilla.Markers[i].SetBackColor(ThemeManager.CurrentApplicationTheme.ColorPalette.ContentForegroundDimmed);
      }

      // Configure folding markers with respective symbols.
      scintilla.Markers[Marker.Folder].Symbol        = MarkerSymbol.BoxPlus;
      scintilla.Markers[Marker.FolderOpen].Symbol    = MarkerSymbol.BoxMinus;
      scintilla.Markers[Marker.FolderEnd].Symbol     = MarkerSymbol.BoxPlusConnected;
      scintilla.Markers[Marker.FolderMidTail].Symbol = MarkerSymbol.TCorner;
      scintilla.Markers[Marker.FolderOpenMid].Symbol = MarkerSymbol.BoxMinusConnected;
      scintilla.Markers[Marker.FolderSub].Symbol     = MarkerSymbol.VLine;
      scintilla.Markers[Marker.FolderTail].Symbol    = MarkerSymbol.LCorner;

      scintilla.SetFoldMarginColor(
          true
        , ThemeManager.CurrentApplicationTheme.ColorPalette.ContentBackground);

      scintilla.SetFoldMarginHighlightColor(
          true
        , ThemeManager.CurrentApplicationTheme.ColorPalette.ContentBackground);

      // Enable automatic folding.
      scintilla.AutoCIgnoreCase = true;
      scintilla.AutomaticFold   = (AutomaticFold.Show  |
                                   AutomaticFold.Click | 
                                   AutomaticFold.Change);
      //Setup the lexer colors.
      SetScintilaCtrlColors();

      // Set the Lua keywords.
      scintilla.SetKeywords(0, LUA_KEYWORDS_0);
      scintilla.SetKeywords(1, LUA_KEYWORDS_1); 
      scintilla.SetKeywords(2, LUA_KEYWORDS_2); 

      // Instruct the lexer to calculate folding.
      scintilla.SetProperty("fold",         "1");
      scintilla.SetProperty("fold.compact", "1");

      // Set the default content to the editor.
      scintilla.Text = Resources.strLuaEditorDefaultContent;
    }

    /// <summary>
    /// Setups the lexer <see cref="Color"/>s and font styles.
    /// </summary>
    private void SetScintilaCtrlColors()
    {
      try
      {
        scintilla.SuspendDrawing();

        scintilla.Styles[Style.Default].BackColor         = Settings.Default.CodeElement_DefaultText_BackgroundColor;

        // Configure braced hightlighting.
        scintilla.Styles[Style.BraceLight].ForeColor      = Settings.Default.CodeElement_Bracket_ForegroundColor;
        scintilla.Styles[Style.BraceLight].BackColor      = Settings.Default.CodeElement_Bracket_BackgroundColor;
        scintilla.Styles[Style.BraceLight].Bold           = Settings.Default.CodeElement_Bracket_FontStyle == FontStyle.Bold;
        scintilla.Styles[Style.BraceBad].ForeColor        = Color.Red;

        // Configure the Lua lexer styles
        scintilla.Styles[Style.Lua.Default].ForeColor       = Settings.Default.CodeElement_DefaultText_ForegroundColor;
        scintilla.Styles[Style.Lua.Comment].ForeColor       = Settings.Default.CodeElement_Comment_ForegroundColor;
        scintilla.Styles[Style.Lua.CommentLine].ForeColor   = Settings.Default.CodeElement_Comment_ForegroundColor;
        scintilla.Styles[Style.Lua.CommentDoc].ForeColor    = Settings.Default.CodeElement_Comment_ForegroundColor;
        scintilla.Styles[Style.Lua.Number].ForeColor        = Settings.Default.CodeElement_Number_ForegroundColor;
        scintilla.Styles[Style.Lua.Word].ForeColor          = Settings.Default.CodeElement_Keyword_ForegroundColor;
        scintilla.Styles[Style.Lua.Word2].ForeColor         = Settings.Default.CodeElement_LuaFunction_ForegroundColor;
        scintilla.Styles[Style.Lua.Word3].ForeColor         = Settings.Default.CodeElement_LogbertFunction_ForegroundColor;
        scintilla.Styles[Style.Lua.Word4].ForeColor         = Settings.Default.CodeElement_DefaultText_ForegroundColor;
        scintilla.Styles[Style.Lua.Word5].ForeColor         = Settings.Default.CodeElement_DefaultText_ForegroundColor;
        scintilla.Styles[Style.Lua.Word6].ForeColor         = Settings.Default.CodeElement_DefaultText_ForegroundColor;
        scintilla.Styles[Style.Lua.Word7].ForeColor         = Settings.Default.CodeElement_DefaultText_ForegroundColor;
        scintilla.Styles[Style.Lua.Word8].ForeColor         = Settings.Default.CodeElement_DefaultText_ForegroundColor;
        scintilla.Styles[Style.Lua.String].ForeColor        = Settings.Default.CodeElement_String_ForegroundColor;
        scintilla.Styles[Style.Lua.Character].ForeColor     = Settings.Default.CodeElement_String_ForegroundColor;
        scintilla.Styles[Style.Lua.StringEol].ForeColor     = Settings.Default.CodeElement_String_ForegroundColor;
        scintilla.Styles[Style.Lua.Operator].ForeColor      = Settings.Default.CodeElement_Operator_ForegroundColor;
        scintilla.Styles[Style.Lua.Identifier].ForeColor    = Settings.Default.CodeElement_Identifier_ForegroundColor;
        scintilla.Styles[Style.Lua.Label].ForeColor         = Settings.Default.CodeElement_DefaultText_ForegroundColor;
        scintilla.Styles[Style.Lua.LiteralString].ForeColor = Settings.Default.CodeElement_DefaultText_ForegroundColor;
        scintilla.Styles[Style.Lua.Preprocessor].ForeColor  = Settings.Default.CodeElement_DefaultText_ForegroundColor;

        scintilla.Styles[Style.Lua.Default].BackColor       = Settings.Default.CodeElement_DefaultText_BackgroundColor;
        scintilla.Styles[Style.Lua.Comment].BackColor       = Settings.Default.CodeElement_Comment_BackgroundColor;
        scintilla.Styles[Style.Lua.CommentLine].BackColor   = Settings.Default.CodeElement_Comment_BackgroundColor;
        scintilla.Styles[Style.Lua.CommentDoc].BackColor    = Settings.Default.CodeElement_Comment_BackgroundColor;
        scintilla.Styles[Style.Lua.Number].BackColor        = Settings.Default.CodeElement_Number_BackgroundColor;
        scintilla.Styles[Style.Lua.Word].BackColor          = Settings.Default.CodeElement_Keyword_BackgroundColor;
        scintilla.Styles[Style.Lua.Word2].BackColor         = Settings.Default.CodeElement_LuaFunction_BackgroundColor;
        scintilla.Styles[Style.Lua.Word3].BackColor         = Settings.Default.CodeElement_LogbertFunction_BackgroundColor;
        scintilla.Styles[Style.Lua.String].BackColor        = Settings.Default.CodeElement_String_BackgroundColor;
        scintilla.Styles[Style.Lua.Character].BackColor     = Settings.Default.CodeElement_String_BackgroundColor;
        scintilla.Styles[Style.Lua.StringEol].BackColor     = Settings.Default.CodeElement_String_BackgroundColor;
        scintilla.Styles[Style.Lua.Operator].BackColor      = Settings.Default.CodeElement_Operator_BackgroundColor;
        scintilla.Styles[Style.Lua.Identifier].BackColor    = Settings.Default.CodeElement_Identifier_BackgroundColor;
        scintilla.Styles[Style.Lua.Label].BackColor         = Settings.Default.CodeElement_DefaultText_BackgroundColor;
        scintilla.Styles[Style.Lua.LiteralString].BackColor = Settings.Default.CodeElement_DefaultText_BackgroundColor;
        scintilla.Styles[Style.Lua.Preprocessor].BackColor  = Settings.Default.CodeElement_DefaultText_BackgroundColor;

        scintilla.Styles[Style.Lua.Default].Bold       = Settings.Default.CodeElement_DefaultText_FontStyle     == FontStyle.Bold;
        scintilla.Styles[Style.Lua.Comment].Bold       = Settings.Default.CodeElement_Comment_FontStyle         == FontStyle.Bold;
        scintilla.Styles[Style.Lua.CommentLine].Bold   = Settings.Default.CodeElement_Comment_FontStyle         == FontStyle.Bold;
        scintilla.Styles[Style.Lua.CommentDoc].Bold    = Settings.Default.CodeElement_Comment_FontStyle         == FontStyle.Bold;
        scintilla.Styles[Style.Lua.Number].Bold        = Settings.Default.CodeElement_Number_FontStyle          == FontStyle.Bold;
        scintilla.Styles[Style.Lua.Word].Bold          = Settings.Default.CodeElement_Keyword_FontStyle         == FontStyle.Bold;
        scintilla.Styles[Style.Lua.Word2].Bold         = Settings.Default.CodeElement_LuaFunction_FontStyle     == FontStyle.Bold;
        scintilla.Styles[Style.Lua.Word3].Bold         = Settings.Default.CodeElement_LogbertFunction_FontStyle == FontStyle.Bold;
        scintilla.Styles[Style.Lua.String].Bold        = Settings.Default.CodeElement_String_FontStyle          == FontStyle.Bold;
        scintilla.Styles[Style.Lua.Character].Bold     = Settings.Default.CodeElement_String_FontStyle          == FontStyle.Bold;
        scintilla.Styles[Style.Lua.StringEol].Bold     = Settings.Default.CodeElement_String_FontStyle          == FontStyle.Bold;
        scintilla.Styles[Style.Lua.Operator].Bold      = Settings.Default.CodeElement_Operator_FontStyle        == FontStyle.Bold;
        scintilla.Styles[Style.Lua.Identifier].Bold    = Settings.Default.CodeElement_Identifier_FontStyle          == FontStyle.Bold;
        scintilla.Styles[Style.Lua.Label].Bold         = Settings.Default.CodeElement_String_FontStyle          == FontStyle.Bold;
        scintilla.Styles[Style.Lua.LiteralString].Bold = Settings.Default.CodeElement_String_FontStyle          == FontStyle.Bold;
        scintilla.Styles[Style.Lua.Preprocessor].Bold  = Settings.Default.CodeElement_String_FontStyle          == FontStyle.Bold;

        if (mLuaScriptRunning)
        {
          scintilla.Styles[Style.Lua.Default].ForeColor       = ThemeManager.CurrentApplicationTheme.ColorPalette.ContentForegroundDimmed;
          scintilla.Styles[Style.Lua.Comment].ForeColor       = ThemeManager.CurrentApplicationTheme.ColorPalette.ContentForegroundDimmed;
          scintilla.Styles[Style.Lua.CommentLine].ForeColor   = ThemeManager.CurrentApplicationTheme.ColorPalette.ContentForegroundDimmed;
          scintilla.Styles[Style.Lua.CommentDoc].ForeColor    = ThemeManager.CurrentApplicationTheme.ColorPalette.ContentForegroundDimmed;
          scintilla.Styles[Style.Lua.Number].ForeColor        = ThemeManager.CurrentApplicationTheme.ColorPalette.ContentForegroundDimmed;
          scintilla.Styles[Style.Lua.Word].ForeColor          = ThemeManager.CurrentApplicationTheme.ColorPalette.ContentForegroundDimmed;
          scintilla.Styles[Style.Lua.Word2].ForeColor         = ThemeManager.CurrentApplicationTheme.ColorPalette.ContentForegroundDimmed;
          scintilla.Styles[Style.Lua.Word3].ForeColor         = ThemeManager.CurrentApplicationTheme.ColorPalette.ContentForegroundDimmed;
          scintilla.Styles[Style.Lua.Word4].ForeColor         = ThemeManager.CurrentApplicationTheme.ColorPalette.ContentForegroundDimmed;
          scintilla.Styles[Style.Lua.Word5].ForeColor         = ThemeManager.CurrentApplicationTheme.ColorPalette.ContentForegroundDimmed;
          scintilla.Styles[Style.Lua.Word6].ForeColor         = ThemeManager.CurrentApplicationTheme.ColorPalette.ContentForegroundDimmed;
          scintilla.Styles[Style.Lua.Word7].ForeColor         = ThemeManager.CurrentApplicationTheme.ColorPalette.ContentForegroundDimmed;
          scintilla.Styles[Style.Lua.Word8].ForeColor         = ThemeManager.CurrentApplicationTheme.ColorPalette.ContentForegroundDimmed;
          scintilla.Styles[Style.Lua.String].ForeColor        = ThemeManager.CurrentApplicationTheme.ColorPalette.ContentForegroundDimmed;
          scintilla.Styles[Style.Lua.Character].ForeColor     = ThemeManager.CurrentApplicationTheme.ColorPalette.ContentForegroundDimmed;
          scintilla.Styles[Style.Lua.StringEol].ForeColor     = ThemeManager.CurrentApplicationTheme.ColorPalette.ContentForegroundDimmed;
          scintilla.Styles[Style.Lua.Operator].ForeColor      = ThemeManager.CurrentApplicationTheme.ColorPalette.ContentForegroundDimmed;
          scintilla.Styles[Style.Lua.Identifier].ForeColor    = ThemeManager.CurrentApplicationTheme.ColorPalette.ContentForegroundDimmed;
          scintilla.Styles[Style.Lua.Label].ForeColor         = ThemeManager.CurrentApplicationTheme.ColorPalette.ContentForegroundDimmed;
          scintilla.Styles[Style.Lua.LiteralString].ForeColor = ThemeManager.CurrentApplicationTheme.ColorPalette.ContentForegroundDimmed;
          scintilla.Styles[Style.Lua.Preprocessor].ForeColor  = ThemeManager.CurrentApplicationTheme.ColorPalette.ContentForegroundDimmed;




          scintilla.SetFoldMarginColor(
              true
            , ThemeManager.CurrentApplicationTheme.ColorPalette.ContentBackground);

          scintilla.SetFoldMarginHighlightColor(
              true
            , ThemeManager.CurrentApplicationTheme.ColorPalette.ContentBackground);
        }
      }
      finally
      {
        scintilla.ResumeDrawing();
      }

      scintilla.WrapMode = Settings.Default.ScriptEditorWordWrap 
        ? WrapMode.Whitespace
        : WrapMode.None;
    }

    /// <summary>
    /// Initializes the Lua <see cref="Script"/> interpreter.
    /// </summary>
    private void InitializeLuaScript()
    {
      mLuaScript = new Script();

      mLuaScript.Globals["Debug"]         = (Action<string>)LuaVmDebugPrint;
      mLuaScript.Globals["Clear"]         = (Action)LuaVmClear;
      mLuaScript.Globals["MsgBox"]        = (Action<string>)LuaVmMsgBox;
      mLuaScript.Globals["SetBookmark"]   = (Func<int, bool>)LuaVmSetBookmark;
      mLuaScript.Globals["DelBookmark"]   = (Func<int, bool>)LuaVmDelBookmark;
      mLuaScript.Globals["GetLogMessage"] = (Func<int, Table>)LuaVmGetLogMessage;

      mLuaScript.Options.DebugPrint = LuaVmDebugPrint;
    }

    /// <summary>
    /// Handles the Click event of the load script <see cref="ToolBarButton"/>.
    /// </summary>
    private void TsbLoadScriptClick(object sender, EventArgs e)
    {
      using (OpenFileDialog ofd = new OpenFileDialog())
      {
        ofd.AutoUpgradeEnabled = true;
        ofd.CheckFileExists    = true;
        ofd.CheckPathExists    = true;
        ofd.Filter             = Resources.strOpenLuaFilter;
        ofd.FilterIndex        = 2;
        ofd.RestoreDirectory   = true;

        if (ofd.ShowDialog(this) == DialogResult.OK)
        {
          try
          {
            scintilla.Text = File.ReadAllText(ofd.FileName);
          }
          catch (Exception ex)
          {
            MessageBox.Show(string.Format(
                Resources.strErrorLoadingScript
              , ex.Message));
          }
        }
      }
    }

    /// <summary>
    /// Handles the Click event of the save script <see cref="ToolBarButton"/>.
    /// </summary>
    private void TsbSaveScriptClick(object sender, EventArgs e)
    {
      using (SaveFileDialog sfd = new SaveFileDialog())
      {
        sfd.CheckPathExists  = true;
        sfd.RestoreDirectory = true;
        sfd.Filter           = Resources.strSaveLuaFilter;
        sfd.FilterIndex      = 2;
        sfd.FileName         = Resources.strDefaultLuaFilename;

        if(sfd.ShowDialog(this) == DialogResult.OK)
        {
          try
          {
            File.WriteAllText(
                sfd.FileName
              , scintilla.Text);
          }
          catch (Exception ex)
          {
            MessageBox.Show(string.Format(
                Resources.strErrorSavingScript
               , ex.Message));
          }
        }
      }
    }

    /// <summary>
    /// Handles the Click event of the copy <see cref="ToolBarButton"/>.
    /// </summary>
    private void TsbCopyClick(object sender, EventArgs e)
    {
      if (!string.IsNullOrEmpty(scintilla.SelectedText))
      {
        scintilla.Copy();
      }
    }

    /// <summary>
    /// Handles the Click event of the cut <see cref="ToolBarButton"/>.
    /// </summary>
    private void TsbCutClick(object sender, EventArgs e)
    {
      if (!string.IsNullOrEmpty(scintilla.SelectedText))
      {
        scintilla.Cut();
      }
    }

    /// <summary>
    /// Handles the Click event of the paste <see cref="ToolBarButton"/>.
    /// </summary>
    private void TsbPasteClick(object sender, EventArgs e)
    {
      if (Clipboard.ContainsText())
      {
        scintilla.Paste();
      }
    }

    /// <summary>
    /// Handles the Click event of the undo <see cref="ToolBarButton"/>.
    /// </summary>
    private void TsbUndoClick(object sender, EventArgs e)
    {
      if (scintilla.CanUndo)
      {
        scintilla.Undo();
      }

      tsbUndo.Enabled = scintilla.CanUndo;
    }

    /// <summary>
    /// Handles the Click event of the redo <see cref="ToolBarButton"/>.
    /// </summary>
    private void TsbRedoClick(object sender, EventArgs e)
    {
      if (scintilla.CanRedo)
      {
        scintilla.Redo();
      }

      tsbRedo.Enabled = scintilla.CanRedo;
    }

    /// <summary>
    /// Handles the Click event of the clear output <see cref="ToolBarButton"/>.
    /// </summary>
    private void TsbOutputClearClick(object sender, EventArgs e)
    {
      txtOutput.Clear();
    }

    /// <summary>
    /// Handles the Click event of the toggle word wrap <see cref="ToolBarButton"/>.
    /// </summary>
    private void TsbOutputWordWrapClick(object sender, EventArgs e)
    {
      tsbOutputWordWrap.Checked = !tsbOutputWordWrap.Checked;
      txtOutput.WordWrap        = tsbOutputWordWrap.Checked;
    }

    /// <summary>
    /// Handles the TextChanged event of the output <see cref="TextBox"/>.
    /// </summary>
    private void TxtOutputTextChanged(object sender, EventArgs e)
    {
      tsbOutputClear.Enabled = !string.IsNullOrEmpty(txtOutput.Text);
    }

    /// <summary>
    /// Handles the Click event of the stop <see cref="ToolStripButton"/>.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TsbStopClick(object sender, EventArgs e)
    {
      StopLuaScript();
    }

    /// <summary>
    /// Handles the Click event of the start <see cref="ToolStripButton"/>.
    /// </summary>
    private void TsbStartClick(object sender, EventArgs e)
    {
      StartLuaScript();
    }

    /// <summary>
    /// Handles the Click event of the delete <see cref="ToolStripMenuItem"/>.
    /// </summary>
    private void TsbDeleteClick(object sender, EventArgs e)
    {
      if (!string.IsNullOrEmpty(scintilla.SelectedText))
      {
        scintilla.DeleteRange(
            scintilla.SelectionStart
          , scintilla.SelectedText.Length);
      }
    }

    /// <summary>
    /// Handles the Click event of the select all <see cref="ToolStripMenuItem"/>.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TsbSelectAllClick(object sender, EventArgs e)
    {
      scintilla.SelectAll();
    }

    private void StartLuaScript()
    {
      StartLuaScriptDelegate worker   = LuaScriptWorker;
      AsyncCallback completedCallback = LuaScriptCallback;

      lock (mSync)
      {
        if (mLuaScriptRunning)
        {
          return;
        }

        tsbLoadScript.Enabled = false;
        tsbSaveScript.Enabled = false;
        tsbCut.Enabled        = false;
        tsbCopy.Enabled       = !string.IsNullOrEmpty(scintilla.SelectedText);
        tsbPaste.Enabled      = false;
        tsbUndo.Enabled       = false;
        tsbRedo.Enabled       = false;
        tsbStart.Enabled      = false;
        tsbStop.Enabled       = true;
        scintilla.ReadOnly    = true;

        scintilla.Styles[Style.Lua.Default].ForeColor       = ThemeManager.CurrentApplicationTheme.ColorPalette.ContentForegroundDimmed;
        scintilla.Styles[Style.Lua.Comment].ForeColor       = ThemeManager.CurrentApplicationTheme.ColorPalette.ContentForegroundDimmed;
        scintilla.Styles[Style.Lua.CommentLine].ForeColor   = ThemeManager.CurrentApplicationTheme.ColorPalette.ContentForegroundDimmed;
        scintilla.Styles[Style.Lua.CommentDoc].ForeColor    = ThemeManager.CurrentApplicationTheme.ColorPalette.ContentForegroundDimmed;
        scintilla.Styles[Style.Lua.Number].ForeColor        = ThemeManager.CurrentApplicationTheme.ColorPalette.ContentForegroundDimmed;
        scintilla.Styles[Style.Lua.Word].ForeColor          = ThemeManager.CurrentApplicationTheme.ColorPalette.ContentForegroundDimmed;
        scintilla.Styles[Style.Lua.Word2].ForeColor         = ThemeManager.CurrentApplicationTheme.ColorPalette.ContentForegroundDimmed;
        scintilla.Styles[Style.Lua.Word3].ForeColor         = ThemeManager.CurrentApplicationTheme.ColorPalette.ContentForegroundDimmed;
        scintilla.Styles[Style.Lua.Word4].ForeColor         = ThemeManager.CurrentApplicationTheme.ColorPalette.ContentForegroundDimmed;
        scintilla.Styles[Style.Lua.Word5].ForeColor         = ThemeManager.CurrentApplicationTheme.ColorPalette.ContentForegroundDimmed;
        scintilla.Styles[Style.Lua.Word6].ForeColor         = ThemeManager.CurrentApplicationTheme.ColorPalette.ContentForegroundDimmed;
        scintilla.Styles[Style.Lua.Word7].ForeColor         = ThemeManager.CurrentApplicationTheme.ColorPalette.ContentForegroundDimmed;
        scintilla.Styles[Style.Lua.Word8].ForeColor         = ThemeManager.CurrentApplicationTheme.ColorPalette.ContentForegroundDimmed;
        scintilla.Styles[Style.Lua.String].ForeColor        = ThemeManager.CurrentApplicationTheme.ColorPalette.ContentForegroundDimmed;
        scintilla.Styles[Style.Lua.Character].ForeColor     = ThemeManager.CurrentApplicationTheme.ColorPalette.ContentForegroundDimmed;
        scintilla.Styles[Style.Lua.StringEol].ForeColor     = ThemeManager.CurrentApplicationTheme.ColorPalette.ContentForegroundDimmed;
        scintilla.Styles[Style.Lua.Operator].ForeColor      = ThemeManager.CurrentApplicationTheme.ColorPalette.ContentForegroundDimmed;
        scintilla.Styles[Style.Lua.Identifier].ForeColor    = ThemeManager.CurrentApplicationTheme.ColorPalette.ContentForegroundDimmed;
        scintilla.Styles[Style.Lua.Label].ForeColor         = ThemeManager.CurrentApplicationTheme.ColorPalette.ContentForegroundDimmed;
        scintilla.Styles[Style.Lua.LiteralString].ForeColor = ThemeManager.CurrentApplicationTheme.ColorPalette.ContentForegroundDimmed;
        scintilla.Styles[Style.Lua.Preprocessor].ForeColor  = ThemeManager.CurrentApplicationTheme.ColorPalette.ContentForegroundDimmed;

        scintilla.SetFoldMarginColor(
            true
          , ThemeManager.CurrentApplicationTheme.ColorPalette.ContentBackground);

        scintilla.SetFoldMarginHighlightColor(
            true
          , ThemeManager.CurrentApplicationTheme.ColorPalette.ContentBackground);

        AsyncOperation async = AsyncOperationManager.CreateOperation(null);

        worker.BeginInvoke(
            scintilla.Text
          , completedCallback
          , async);
        
        mLuaScriptRunning = true;
      }
    }

    private void LuaScriptWorker(string luaCode)
    {
      InitializeLuaScript();

      if (mLuaScript != null)
      {
        try
        {
          mLuaScript.DoString(luaCode);

          if (mLuaScript.Globals["OnMessagesReceived"] != null
          ||  mLuaScript.Globals["OnBookmarksChanged"] != null)
          {
            // Wait for the script to be manually exited.
            while (mLuaScript != null && mLuaScriptRunning)
            {
              System.Threading.Thread.Sleep(100);
            }
          }
        }
        catch (ScriptRuntimeException ex)
        {
          AppendOutput(string.Format(
              Resources.strLuaEditorErrorExecutingScript
            , ex.DecoratedMessage
            , Environment.NewLine));

          mLuaScript = null;
        }
        catch (Exception ex)
        {
          AppendOutput(string.Format(
              Resources.strLuaEditorErrorExecutingScript
            , ex.Message
            , Environment.NewLine));

          mLuaScript = null;
        }
      }
    }

    private void LuaScriptCallback(IAsyncResult ar)
    {
      if (InvokeRequired)
      {
        BeginInvoke(new Action<IAsyncResult>(LuaScriptCallback), ar);
        return;
      }

      StartLuaScriptDelegate worker =
        (StartLuaScriptDelegate)((AsyncResult)ar).AsyncDelegate;

      // Finish the asynchronous operation
      worker.EndInvoke(ar);

      StopLuaScript();
    }

    private void StopLuaScript()
    {
      mLuaScript = null;

      // Clear the running task flag
      lock (mSync)
      {
        mLuaScriptRunning = false;
      }

      bool textSelected  = !string.IsNullOrEmpty(scintilla.SelectedText);
      bool textAvailable = !string.IsNullOrEmpty(scintilla.Text);

      tsbCut.Enabled        = textSelected;
      tsbCopy.Enabled       = textSelected;
      tsbPaste.Enabled      = Clipboard.ContainsText() && scintilla.Focused && !scintilla.ReadOnly;
      tsbStart.Enabled      = textAvailable;
      tsbStop.Enabled       = mLuaScriptRunning;
      tsbLoadScript.Enabled = true;
      tsbSaveScript.Enabled = textAvailable;
      tsbUndo.Enabled       = scintilla.CanUndo;
      tsbRedo.Enabled       = scintilla.CanRedo;
      scintilla.ReadOnly    = false;

      scintilla.Styles[Style.Default].BackColor         = Settings.Default.CodeElement_DefaultText_BackgroundColor;
        scintilla.Styles[Style.Lua.Default].ForeColor       = Settings.Default.CodeElement_DefaultText_ForegroundColor;
        scintilla.Styles[Style.Lua.Comment].ForeColor       = Settings.Default.CodeElement_Comment_ForegroundColor;
        scintilla.Styles[Style.Lua.CommentLine].ForeColor   = Settings.Default.CodeElement_Comment_ForegroundColor;
        scintilla.Styles[Style.Lua.CommentDoc].ForeColor    = Settings.Default.CodeElement_Comment_ForegroundColor;
        scintilla.Styles[Style.Lua.Number].ForeColor        = Settings.Default.CodeElement_Number_ForegroundColor;
        scintilla.Styles[Style.Lua.Word].ForeColor          = Settings.Default.CodeElement_Keyword_ForegroundColor;
        scintilla.Styles[Style.Lua.Word2].ForeColor         = Settings.Default.CodeElement_LuaFunction_ForegroundColor;
        scintilla.Styles[Style.Lua.Word3].ForeColor         = Settings.Default.CodeElement_LogbertFunction_ForegroundColor;
        scintilla.Styles[Style.Lua.Word4].ForeColor         = Settings.Default.CodeElement_DefaultText_ForegroundColor;
        scintilla.Styles[Style.Lua.Word5].ForeColor         = Settings.Default.CodeElement_DefaultText_ForegroundColor;
        scintilla.Styles[Style.Lua.Word6].ForeColor         = Settings.Default.CodeElement_DefaultText_ForegroundColor;
        scintilla.Styles[Style.Lua.Word7].ForeColor         = Settings.Default.CodeElement_DefaultText_ForegroundColor;
        scintilla.Styles[Style.Lua.Word8].ForeColor         = Settings.Default.CodeElement_DefaultText_ForegroundColor;
        scintilla.Styles[Style.Lua.String].ForeColor        = Settings.Default.CodeElement_String_ForegroundColor;
        scintilla.Styles[Style.Lua.Character].ForeColor     = Settings.Default.CodeElement_String_ForegroundColor;
        scintilla.Styles[Style.Lua.StringEol].ForeColor     = Settings.Default.CodeElement_String_ForegroundColor;
        scintilla.Styles[Style.Lua.Operator].ForeColor      = Settings.Default.CodeElement_Operator_ForegroundColor;
        scintilla.Styles[Style.Lua.Identifier].ForeColor    = Settings.Default.CodeElement_Identifier_ForegroundColor;
        scintilla.Styles[Style.Lua.Label].ForeColor         = Settings.Default.CodeElement_DefaultText_ForegroundColor;
        scintilla.Styles[Style.Lua.LiteralString].ForeColor = Settings.Default.CodeElement_DefaultText_ForegroundColor;
        scintilla.Styles[Style.Lua.Preprocessor].ForeColor  = Settings.Default.CodeElement_DefaultText_ForegroundColor;

      scintilla.SetFoldMarginColor(
          true
        , ThemeManager.CurrentApplicationTheme.ColorPalette.ContentBackground);

      scintilla.SetFoldMarginHighlightColor(
          true
        , ThemeManager.CurrentApplicationTheme.ColorPalette.ContentBackground);
    }

    private void AppendOutput(string message)
    {
      if (InvokeRequired)
      {
        BeginInvoke(new Action<string>(AppendOutput), message);
        return;
      }

      txtOutput.AppendText(message.TrimEnd() + Environment.NewLine);
    }

    /// <summary>
    /// Handles the SettingChanging event of the <see cref="Application"/>.
    /// </summary>
    private void DefaultSettingChanging(object sender, SettingChangingEventArgs e)
    {
      if (!IsHandleCreated)
      {
        return;
      }
      
      InitializeScintilaCtrl();
    }

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        components?.Dispose();

        StopLuaScript();

        // Remove the settings change event handler.
        Settings.Default.SettingChanging -= DefaultSettingChanging;
      }

      base.Dispose(disposing);
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Updates the visible <see cref="LogMessage"/>s.
    /// </summary>
    /// <param name="messages">The list of <see cref="LogMessage"/>s to display.</param>
    /// <param name="delta">The count of new <see cref="LogMessage"/>s.</param>
    public void LogMessagesChanged(List<LogMessage> messages, int delta = -1)
    {
      if (mLuaScriptRunning && mLuaScript != null)
      {
        if (mLuaScript.Globals["OnMessagesReceived"] == null)
        {
          return;
        }

        List<LogMessage> newLogMessages = delta < 0
          ? messages
          : messages.GetRange(messages.Count - delta, delta);

        if (newLogMessages.Count > 0)
        {
          try
          {
            Table msgTable = new Table(mLuaScript);

            for (int logMsgIndex = 0; logMsgIndex < newLogMessages.Count; logMsgIndex++)
            {
              Table msgData = newLogMessages[logMsgIndex].ToLuaTable(mLuaScript);
              
              if (msgData != null)
              {
                msgTable[logMsgIndex + 1] = msgData;
              }
            }

            if (msgTable.Length > 0)
            {
              mLuaScript.Call(
                  mLuaScript.Globals["OnMessagesReceived"]
                , msgTable);
            }
          }
          catch (Exception ex)
          {
            AppendOutput(ex.Message);
          }
        }
      }
    }

    /// <summary>
    /// Raises the BookmarksChanged event of the bookmark <see cref="IBookmarkProvider"/>.
    /// </summary>
    public void BookmarksChanged()
    {
      if (mLuaScriptRunning && mLuaScript != null && mBookmarkProvider != null)
      {
        if (mLuaScript.Globals["OnBookmarksChanged"] == null)
        {
          return;
        }

        Table msgBookmarks = new Table(mLuaScript);

        for (int bkmrkIndx = 0; bkmrkIndx < mBookmarkProvider.Bookmarks.Count; ++bkmrkIndx)
        {
          msgBookmarks[bkmrkIndx + 1] = mBookmarkProvider.Bookmarks[bkmrkIndx].ToLuaTable(mLuaScript);
        }

        mLuaScript.Call(
            mLuaScript.Globals["OnBookmarksChanged"]
          , msgBookmarks);
      }
    }

    /// <summary>
    /// Selects the <see cref="LogMessage"/> on the given <paramref name="index"/>.
    /// </summary>
    /// <param name="index">The index of the <see cref="LogMessage"/> to select.</param>
    /// <returns><c>True</c> if the <see cref="LogMessage"/> of the given <paramref name="index"/> was selected successfully, otherwise <c>false</c>.</returns>
    public bool SelectLogMessage(int index)
    {
      return true;
    }

    /// <summary>
    /// Selects the given <paramref name="message"/>.
    /// </summary>
    /// <param name="message">The <see cref="LogMessage"/> to select</param>
    /// <returns><c>True</c> if the given <paramref name="message"/> was selected successfully, otherwise <c>false</c>.</returns>
    public bool SelectLogMessage(LogMessage message)
    {
      return true;
    }

    /// <summary>
    /// Clears all shown <see cref="LogMessage"/>s.
    /// </summary>
    public void ClearAll()
    {

    }

    /// <summary>
    /// Increases the size of the <see cref="ILogPresenter"/> content.
    /// </summary>
    /// <returns><c>True</c> if further increasing is possible, otherwise <c>false</c>.</returns>
    public bool ZoomIn()
    {
      if (scintilla.Zoom < MAX_ZOOM_LEVEL)
      {
        try
        {
          scintilla.SuspendDrawing();

          scintilla.ZoomIn();

          return scintilla.Zoom < MAX_ZOOM_LEVEL;
        }
        finally
        {
          scintilla.ResumeDrawing();
        }
      }

      return false;
    }

    /// <summary>
    /// Decreases the size of the <see cref="ILogPresenter"/> content.
    /// </summary>
    /// <returns><c>True</c> if further decreasing is possible, otherwise <c>false</c>.</returns>
    public bool ZoomOut()
    {
      if (scintilla.Zoom > MIN_ZOOM_LEVEL)
      {
        try
        {
          scintilla.SuspendDrawing();

          scintilla.ZoomOut();

          return scintilla.Zoom > MIN_ZOOM_LEVEL;
        }
        finally
        {
          scintilla.ResumeDrawing();
        }
      }

      return false;
    }

    #endregion

    #region Lua Methods

    private void LuaVmPrint(string value)
    {
      if (!string.IsNullOrEmpty(value))
      {
        AppendOutput(value);
      }
    }

    private void LuaVmDebugPrint(string value)
    {
      if (!string.IsNullOrEmpty(value))
      {
        LuaVmPrint(string.Format(
            "{0}: {1}{2}"
          , DateTime.Now.ToString("HH:mm:ss:fff")
          , value.TrimEnd()
          , Environment.NewLine));
      }
    }

    private void LuaVmClear()
    {
      if (InvokeRequired)
      {
        Invoke(new Action(LuaVmClear));
        return;
      }

      if (mLogContainer != null)
      {
        mLogContainer.ClearAll();
      }
    }

    private void LuaVmMsgBox(string message)
    {
      if (InvokeRequired)
      {
        Invoke(new Action<string>(LuaVmMsgBox), message);
        return;
      }

      MessageBox.Show(
          this
        , message ?? "[NULL]"
        , Application.ProductName);
    }

    private bool LuaVmSetBookmark(int msgIndex)
    {
      if (InvokeRequired)
      {
        return (bool)Invoke(
            new Func<int, bool>(LuaVmSetBookmark)
          , msgIndex);
      }

      if (mBookmarkProvider != null && mLogContainer != null)
      {
        foreach (LogMessage message in mLogContainer.LogMessages)
        {
          if (message.Index == msgIndex)
          {
            mBookmarkProvider.AddBookmarks(new List<LogMessage>(new[] { message }));
            return true;
          }
        }
      }

      return false;
    }

    private bool LuaVmDelBookmark(int msgIndex)
    {
      if (InvokeRequired)
      {
        return (bool)Invoke(
            new Func<int, bool>(LuaVmDelBookmark)
          , msgIndex);
      }

      if (mBookmarkProvider != null && mLogContainer != null)
      {
        foreach (LogMessage message in mLogContainer.LogMessages)
        {
          if (message.Index == msgIndex)
          {
            mBookmarkProvider.RemoveBookmarks(new List<LogMessage>(new[] { message }));
            return true;
          }
        }
      }

      return false;
    }

    private Table LuaVmGetLogMessage(int msgIndex)
    {
      if (mLuaScript != null && mLogContainer != null)
      {
        foreach (LogMessage message in mLogContainer.LogMessages)
        {
          if (message.Index == msgIndex)
          {
            return message.ToLuaTable(mLuaScript);
          }
        }
      }

      return null;
    }

    /// <summary>
    /// Raises the HandleCreated event.
    /// </summary>
    /// <param name="e">An EventArgs that contains the event data. </param>
    protected override void OnHandleCreated(EventArgs e)
    {
      base.OnHandleCreated(e);

      // Ensure the script is ready as fast as possible.
      BeginInvoke(new Action(Script.WarmUp));
    }

    /// <summary>
    /// Applies the current theme to the <see cref="Control"/>.
    /// </summary>
    /// <param name="theme">The <see cref="BaseTheme"/> instance to apply.</param>
    public void ApplyTheme(BaseTheme theme)
    {
      ThemeManager.ApplyTo(cmsLuaEdit);

      splitContainer1.BackColor = theme.ColorPalette.ContentBackground;

      txtOutput.BackColor = theme.ColorPalette.ContentBackground;
      txtOutput.ForeColor = theme.ColorPalette.ContentForeground;

      tsbLoadScript.Image     = theme.Resources.Images["FrmMainTbOpen"];
      tsbSaveScript.Image     = theme.Resources.Images["FrmMainTbSave"];
      tsbCopy.Image           = theme.Resources.Images["FrmScriptTbCopy"];
      tsbCut.Image            = theme.Resources.Images["FrmScriptTbCut"];
      tsbPaste.Image          = theme.Resources.Images["FrmScriptTbPaste"];
      tsbUndo.Image           = theme.Resources.Images["FrmScriptTbUndo"];
      tsbRedo.Image           = theme.Resources.Images["FrmScriptTbRedo"];
      tsbStart.Image          = theme.Resources.Images["FrmScriptTbStart"];
      tsbStop.Image           = theme.Resources.Images["FrmScriptTbStop"];
      tsbZoomIn.Image         = theme.Resources.Images["FrmMainTbZoomIn"];
      tsbZoomOut.Image        = theme.Resources.Images["FrmMainTbZoomOut"];
      tsbOutputClear.Image    = theme.Resources.Images["FrmScriptTbClear"];
      tsbOutputWordWrap.Image = theme.Resources.Images["FrmScriptTbWordWrap"];
    }

    #endregion

    #region Constructor
    
    /// <summary>
    /// Creates a new instance of the <see cref="FrmLogScript"/> window.
    /// </summary>
    /// <param name="bookmarkProvider">The <see cref="IBookmarkProvider"/> instance that provides bookmarked <see cref="LogMessage"/>s.</param>
    /// <param name="logContainer">The <see cref="ILogContainer"/> that contains the source for <see cref="LogMessage"/>s.</param>
    public FrmLogScript(IBookmarkProvider bookmarkProvider, ILogContainer logContainer)
    {
      InitializeComponent();

      // Apply the current application theme to the control.
      ThemeManager.ApplyTo(this);

      DockHandler.CloseButton        = false;
      DockHandler.CloseButtonVisible = false;
      
      mLogContainer     = logContainer;
      mBookmarkProvider = bookmarkProvider;

      mBookmarkProvider?.RegisterBookmarkObserver(this);

      // Intialize the edit control.
      InitializeScintilaCtrl();

      // Prevent the undo of the initial text.
      scintilla.EmptyUndoBuffer();
      
      // Listening for settings changes.
      Settings.Default.SettingChanging += DefaultSettingChanging;
    }

    #endregion
  }
}
