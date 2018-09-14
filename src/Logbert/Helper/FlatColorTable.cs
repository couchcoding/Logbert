#region Copyright © 2015 Couchcoding

// File:    FlatColorTable.cs
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

using System.Drawing;
using System.Windows.Forms;

namespace Couchcoding.Logbert.Helper
{
  /// <summary>
  /// Implements a <see cref="Color"/> table used for flat toolStrip rendering.
  /// </summary>
  public sealed class FlatColorTable : ProfessionalColorTable
  {
    #region Private Fields

    /// <summary>
    /// The background <see cref="Color"/> of the <see cref="FlatColorTable"/>´.
    /// </summary>
    private Color mBackgroundColor;

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets or sets the background <see cref="Color"/> to use.
    /// </summary>
    public Color BackgroundColor
    {
      get
      {
        return mBackgroundColor;
      }
      set
      {
        mBackgroundColor = value;
      }
    }

    /// <summary>
    /// Gets the border color to use on the bottom edge of the <see cref="T:System.Windows.Forms.ToolStrip"/>.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.Drawing.Color"/> that is the border color to use on the bottom edge of the <see cref="T:System.Windows.Forms.ToolStrip"/>.
    /// </returns>
    public override Color ToolStripBorder
    {
      get
      {
        return mBackgroundColor;
      }
    }

    /// <summary>
    /// Gets the starting color of the gradient used in the <see cref="T:System.Windows.Forms.ToolStrip"/> background.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.Drawing.Color"/> that is the starting color of the gradient used in the <see cref="T:System.Windows.Forms.ToolStrip"/> background.
    /// </returns>
    public override Color ToolStripGradientBegin
    {
      get
      {
        return mBackgroundColor;
      }
    }

    /// <summary>
    /// Gets the middle color of the gradient used in the <see cref="T:System.Windows.Forms.ToolStrip"/> background.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.Drawing.Color"/> that is the middle color of the gradient used in the <see cref="T:System.Windows.Forms.ToolStrip"/> background.
    /// </returns>
    public override Color ToolStripGradientMiddle
    {
      get
      {
        return mBackgroundColor;
      }
    }

    /// <summary>
    /// Gets the end color of the gradient used in the <see cref="T:System.Windows.Forms.ToolStrip"/> background.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.Drawing.Color"/> that is the end color of the gradient used in the <see cref="T:System.Windows.Forms.ToolStrip"/> background.
    /// </returns>
    public override Color ToolStripGradientEnd
    {
      get
      {
        return mBackgroundColor;
      }
    }

    /// <summary>
    /// Gets the starting color of the gradient used in the <see cref="T:System.Windows.Forms.ToolStripOverflowButton"/>.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.Drawing.Color"/> that is the starting color of the gradient used in the <see cref="T:System.Windows.Forms.ToolStripOverflowButton"/>.
    /// </returns>
    public override Color OverflowButtonGradientBegin
    {
      get
      {
        return mBackgroundColor;
      }
    }

    /// <summary>
    /// Gets the middle color of the gradient used in the <see cref="T:System.Windows.Forms.ToolStripOverflowButton"/>.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.Drawing.Color"/> that is the middle color of the gradient used in the <see cref="T:System.Windows.Forms.ToolStripOverflowButton"/>.
    /// </returns>
    public override Color OverflowButtonGradientMiddle
    {
      get
      {
        return mBackgroundColor;
      }
    }

    /// <summary>
    /// Gets the end color of the gradient used in the <see cref="T:System.Windows.Forms.ToolStripOverflowButton"/>.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.Drawing.Color"/> that is the end color of the gradient used in the <see cref="T:System.Windows.Forms.ToolStripOverflowButton"/>.
    /// </returns>
    public override Color OverflowButtonGradientEnd
    {
      get
      {
        return mBackgroundColor;
      }
    }

    /// <summary>
    /// Gets the border color of the <see cref="T:System.Windows.Forms.ToolStripMenuItem"/>.
    /// </summary>
    /// <returns>
    ///  A <see cref="T:System.Drawing.Color"/> that is the border color of the <see cref="T:System.Windows.Forms.ToolStripOverflowButton"/>.
    /// </returns>
    public override Color MenuItemBorder
    {
      get
      {
        return Color.Transparent;
      }
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Creates a new instance of the <see cref="FlatColorTable"/> with a backgound color of <see cref="SystemColors.Control"/>.
    /// </summary>
    public FlatColorTable()
    {
      UseSystemColors  = true;
      mBackgroundColor = SystemColors.Control;
    }

    /// <summary>
    /// Creates a new instance of the <see cref="FlatColorTable"/> with the given background color.
    /// </summary>
    /// <param name="backgoundColor">The background <see cref="Color"/> for the new <see cref="FlatColorTable"/> instance.</param>
    public FlatColorTable(Color backgoundColor)
    {
      UseSystemColors  = true;
      mBackgroundColor = backgoundColor;
    }

    #endregion
  }
}
