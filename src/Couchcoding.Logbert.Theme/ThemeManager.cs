#region Copyright © 2018 Couchcoding

// File:    ThemeManager.cs
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

using Couchcoding.Logbert.Theme.Interfaces;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using Couchcoding.Logbert.Theme.Themes;

namespace Couchcoding.Logbert.Theme
{
  /// <summary>
  /// Implements the Logbert theme manager.
  /// </summary>
  public static class ThemeManager
  {
    #region Private Consts

    /// <summary>
    /// Defines the default application theme name to use.
    /// </summary>
    private const string DEFAULT_APPLICATION_THEME_NAME = "Visual Studio Light";

    #endregion

    #region Private Fields

    /// <summary>
    /// Holds the current active <see cref="BaseTheme"/> instance.
    /// </summary>
    private static BaseTheme mApplicationTheme;

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets the current active <see cref="BaseTheme"/> instance.
    /// </summary>
    public static BaseTheme CurrentApplicationTheme
    {
      get
      {
        if (mApplicationTheme == null)
        {
          mApplicationTheme = new VisualStudioLightTheme();
        }

        return mApplicationTheme;
      }
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Applies the current active <see cref="BaseTheme"/> to the specified <paramref name="control"/>.
    /// </summary>
    /// <param name="control">The <see cref="Control"/> to apply the current active <see cref="BaseTheme"/>.</param>
    public static void ApplyTo(Control control)
    {
      if (control is ToolStrip toolStripControl)
      {
        CurrentApplicationTheme.DockingTheme.ApplyTo(toolStripControl);
        return;
      }

      if (control is DockPanel dockPanelControl)
      {
        CurrentApplicationTheme.DockingTheme.ApplyTo(dockPanelControl);
      }

      if (control is IThemable themableControl)
      {
        themableControl.ApplyTheme(CurrentApplicationTheme);
      }

      foreach (Control childControl in control.Controls)
      {
        ApplyTo(childControl);
      }
    }

    /// <summary>
    /// Sets the current active <see cref="BaseTheme"/> by the specified one.
    /// </summary>
    /// <param name="themeName">The name of the Theme to apply.</param>
    public static void SetActiveApplicationTheme(BaseTheme theme)
    {
      mApplicationTheme = theme;
    }

    #endregion
  }
}
