#region Copyright © 2018 Couchcoding

// File:    BaseTheme.cs
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

using Couchcoding.Logbert.Theme.Metrics;
using Couchcoding.Logbert.Theme.Palettes;
using Couchcoding.Logbert.Theme.Resources;
using WeifenLuo.WinFormsUI.Docking;

namespace Couchcoding.Logbert.Theme.Themes
{
  /// <summary>
  /// Implements the base class for all themes.
  /// </summary>
  public abstract class BaseTheme
  {
    #region Public Consts

    /// <summary>
    /// Defines the name of the <see cref="VisualStudioLightTheme"/>.
    /// </summary>
    public const string VisualStudioThemeLightName = "Visual Studio Light";

    /// <summary>
    /// Defines the name of the <see cref="VisualStudioBlueTheme"/>.
    /// </summary>
    public const string VisualStudioThemeBlueName = "Visual Studio Blue";

    /// <summary>
    /// Defines the name of the <see cref="VisualStudioDarkTheme"/>.
    /// </summary>
    public const string VisualStudioThemeDarkName = "Visual Studio Dark";

    #endregion

    #region Private Fields

    /// <summary>
    /// Holds the docking theme of the <see cref="BaseTheme"/> instance.
    /// </summary>
    protected ThemeBase mApplicationTheme;

    /// <summary>
    /// Holds the <see cref="ThemeColorPalette"/> of the <see cref="BaseTheme"/> instance.
    /// </summary>
    protected ThemeColorPalette mColorPalette;

    /// <summary>
    /// Holds the <see cref="ThemeMetrics"/> of the <see cref="BaseTheme"/> instance.
    /// </summary>
    protected ThemeMetrics mMetrics;

    /// <summary>
    /// Holds the <see cref="ThemeResources"/> of the <see cref="BaseTheme"/> instance.
    /// </summary>
    protected ThemeResources mResources;

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets the name of the <see cref="BaseTheme"/> instance.
    /// </summary>
    public abstract string Name
    {
      get;
    }

    /// <summary>
    /// Gets the docking theme of the <see cref="BaseTheme"/> instance.
    /// </summary>
    public ThemeBase DockingTheme => mApplicationTheme;

    /// <summary>
    /// Gets the <see cref="ThemeColorPalette"/> of the <see cref="BaseTheme"/> instance.
    /// </summary>
    public ThemeColorPalette ColorPalette => mColorPalette;

    /// <summary>
    /// Gets the <see cref="ThemeMetrics"/> of the <see cref="BaseTheme"/> instance.
    /// </summary>
    public ThemeMetrics Metrics => mMetrics;

    /// <summary>
    /// Gets the <see cref="ThemeResources"/> of the <see cref="BaseTheme"/> instance.
    /// </summary>
    public ThemeResources Resources => mResources;

    #endregion
  }
}
