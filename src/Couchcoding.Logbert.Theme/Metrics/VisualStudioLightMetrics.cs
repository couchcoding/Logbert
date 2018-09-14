#region Copyright © 2018 Couchcoding

// File:    VisualStudioLightMetrics.cs
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

using System.Windows.Forms;

namespace Couchcoding.Logbert.Theme.Metrics
{
  /// <summary>
  /// Implements the <see cref="ThemeMetrics"/> for the Visual Studio Light theme.
  /// </summary>
  public class VisualStudioLightMetrics : ThemeMetrics
  {
    #region Private Consts and Static Fields

    /// <summary>
    /// Holds the default <see cref="Padding"/> for the <see cref="DataGridView"/> column header text.
    /// </summary>
    private static readonly Padding dataGridViewHeaderColumnPadding = new Padding(0, 2, 0, 2);

    #endregion

    #region Public Methods

    /// <summary>
    /// Gets the <see cref="Padding"/> for the <see cref="DataGridView"/> column header text.
    /// </summary>
    public override Padding DataGridViewHeaderColumnPadding => dataGridViewHeaderColumnPadding;

    /// <summary>
    /// Determines whether the <see cref="BaseTheme"/> instance wants system like renering, or not.
    /// </summary>
    public override bool PreferSystemRendering => false;

    #endregion
    }
}
