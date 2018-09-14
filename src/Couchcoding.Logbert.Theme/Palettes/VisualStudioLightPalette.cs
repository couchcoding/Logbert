#region Copyright © 2018 Couchcoding

// File:    VisualStudioLightPalette.cs
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

using System.Collections.Generic;
using System.Drawing;

namespace Couchcoding.Logbert.Theme.Palettes
{
  /// <summary>
  /// Implements the <see cref="ThemeColorPalette"/> for the Visual Studion Light theme
  /// </summary>
  public class VisualStudioLightPalette : ThemeColorPalette
  {
    #region Private Consts and Static Fields

    private static readonly Color mContentBackground = Color.FromArgb(245, 245, 245);

    private static readonly Color mContentForeground = Color.FromArgb(0, 0, 0);

    private static readonly Color mContentForegroundDimmed = Color.FromArgb(85, 85, 85);

    private static readonly Color mDividerColor = Color.FromArgb(204, 206, 219);

    private static readonly Color mSelectionBackground = Color.FromArgb(204, 206, 219);

    private static readonly Color mSelectionForeground = Color.FromArgb(255, 255, 255);

    private static readonly Color mSelectionBackgroundFocused = Color.FromArgb(0, 122, 204);

    private static readonly Color mSelectionForegroundFocused = Color.FromArgb(255, 255, 255);

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets the log window background <see cref="Color"/>s for supported levels.
    /// </summary>
    public static readonly Dictionary<string, Color> LevelBackColor = new Dictionary<string, Color>
    {
      { "Trace", Color.White      },
      { "Debug", Color.WhiteSmoke },
      { "Info",  Color.LightBlue  },
      { "Warn",  Color.Yellow     },
      { "Error", Color.LightCoral },
      { "Fatal", Color.Red        },
    };

    /// <summary>
    /// Gets the log window foreground <see cref="Color"/>s for supported levels.
    /// </summary>
    public static readonly Dictionary<string, Color> LevelForeColor = new Dictionary<string, Color>
    {
      { "Trace", Color.Black },
      { "Debug", Color.Black },
      { "Info",  Color.Black },
      { "Warn",  Color.Black },
      { "Error", Color.Black },
      { "Fatal", Color.Black },
    };

    /// <summary>
    /// Gets the <see cref="Color"/> of the window content background.
    /// </summary>
    public override Color ContentBackground => mContentBackground;

    /// <summary>
    /// Gets the <see cref="Color"/> of the window content foreground.
    /// </summary>
    public override Color ContentForeground => mContentForeground;

    /// <summary>
    /// Gets the dimmed <see cref="Color"/> of the window content foreground.
    /// </summary>
    public override Color ContentForegroundDimmed => mContentForegroundDimmed;

    /// <summary>
    /// Gets the <see cref="Color"/> of a divider line.
    /// </summary>
    public override Color DividerColor => mDividerColor;

    /// <summary>
    /// Gets the <see cref="Color"/> of a selection background.
    /// </summary>
    public override Color SelectionBackground => mSelectionBackground;

    /// <summary>
    /// Gets the <see cref="Color"/> of a selection foregound.
    /// </summary>
    public override Color SelectionForeground => mSelectionForeground;

    /// <summary>
    /// Gets the <see cref="Color"/> of a focused selection background.
    /// </summary>
    public override Color SelectionBackgroundFocused => mSelectionBackgroundFocused;

    /// <summary>
    /// Gets the <see cref="Color"/> of a focused selection foreground.
    /// </summary>
    public override Color SelectionForegroundFocused => mSelectionForegroundFocused;

    #endregion
  }
}
