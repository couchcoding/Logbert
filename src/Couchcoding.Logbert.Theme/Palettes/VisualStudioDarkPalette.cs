#region Copyright © 2018 Couchcoding

// File:    VisualStudioDarkPalette.cs
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
  /// Implements the <see cref="ThemeColorPalette"/> for the Visual Studion Dark theme
  /// </summary>
  public sealed class VisualStudioDarkPalette : ThemeColorPalette
  {
    #region Private Consts and Static Fields

    private static readonly Color mContentBackground = Color.FromArgb(37, 37, 38);

    private static readonly Color mContentForeground = Color.FromArgb(255, 255, 255);

    private static readonly Color mContentForegroundDimmed = Color.FromArgb(121, 121, 121);

    private static readonly Color mDividerColor = Color.FromArgb(63, 63, 70);

    private static readonly Color mSelectionBackground = Color.FromArgb(63, 63, 70);

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
      { "Trace", mContentBackground },
      { "Debug", mContentBackground },
      { "Info",  mContentBackground },
      { "Warn",  mContentBackground },
      { "Error", mContentBackground },
      { "Fatal", mContentBackground },
    };

    /// <summary>
    /// Gets the log window foreground <see cref="Color"/>s for supported levels.
    /// </summary>
    public static readonly Dictionary<string, Color> LevelForeColor = new Dictionary<string, Color>
    {
      { "Trace", Color.White      },
      { "Debug", Color.WhiteSmoke },
      { "Info",  Color.LightBlue  },
      { "Warn",  Color.Yellow     },
      { "Error", Color.LightCoral },
      { "Fatal", Color.Red        },
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
