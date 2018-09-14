#region Copyright © 2018 Couchcoding

// File:    ThemeColorPalette.cs
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

using System.Drawing;

namespace Couchcoding.Logbert.Theme.Palettes
{
  /// <summary>
  /// Implements the base class for theme color palettes.
  /// </summary>
  public abstract class ThemeColorPalette
  {
    #region Public Properties

    /// <summary>
    /// Gets the <see cref="Color"/> of the window content background.
    /// </summary>
    public abstract Color ContentBackground
    {
      get;
    }

    /// <summary>
    /// Gets the <see cref="Color"/> of the window content foreground.
    /// </summary>
    public abstract Color ContentForeground
    {
      get;
    }

    /// <summary>
    /// Gets the dimmed <see cref="Color"/> of the window content foreground.
    /// </summary>
    public abstract Color ContentForegroundDimmed
    {
      get;
    }

    /// <summary>
    /// Gets the <see cref="Color"/> of a divider line.
    /// </summary>
    public abstract Color DividerColor
    {
      get;
    }

    /// <summary>
    /// Gets the <see cref="Color"/> of a selection background.
    /// </summary>
    public abstract Color SelectionBackground
    {
      get;
    }

    /// <summary>
    /// Gets the <see cref="Color"/> of a selection foregound.
    /// </summary>
    public abstract Color SelectionForeground
    {
      get;
    }

    /// <summary>
    /// Gets the <see cref="Color"/> of a focused selection background.
    /// </summary>
    public abstract Color SelectionBackgroundFocused
    {
      get;
    }

    /// <summary>
    /// Gets the <see cref="Color"/> of a focused selection foreground.
    /// </summary>
    public abstract Color SelectionForegroundFocused
    {
      get;
    }

    #endregion
  }
}
