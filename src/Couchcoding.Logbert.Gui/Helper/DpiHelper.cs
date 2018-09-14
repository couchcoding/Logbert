#region Copyright © 2015 Couchcoding

// File:    DialogForm.cs
// Package: GuiLibrary
// Project: Logbert
// 
// The MIT License (MIT)
// 
// Copyright (c) 2017 Couchcoding
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

namespace Couchcoding.Logbert.Gui.Helper
{
  /// <summary>
  /// Implements a helper class for DPI scaling.
  /// </summary>
  public sealed class DpiHelper
  {
    #region Private Consts

    /// <summary>
    /// Defines the default horizontal resolution.
    /// </summary>
    private const float DEFAULT_DPI_Y = 96.0f;

    /// <summary>
    /// Defines the default vertical resolution.
    /// </summary>
    private const float DEFAULT_DPI_X = 96.0f;

    #endregion

    #region Private Fields

    /// <summary>
    /// Holds the calculated DPI scaling.
    /// </summary>
    private static SizeF mDpiSize = new SizeF(96.0f, 96.0f);

    #endregion

    #region Public Methods

    /// <summary>
    /// Reloads the current DPI-Settings of the system.
    /// </summary>
    /// <param name="ctrl">The <see cref="Control"/> to use the <see cref="Graphics"/> object from.</param>
    public static void ReloadDpiSettings(Control ctrl)
    {
      if (ctrl != null)
      {
        using (Graphics grfx = ctrl.CreateGraphics())
        {
          mDpiSize = new SizeF(grfx.DpiX, grfx.DpiY);
        }
      }
    }

    /// <summary>
    /// Rescales the given value by the currently used DPI-Settings.
    /// </summary>
    /// <param name="value">The value to rescale.</param>
    /// <returns>The rescaled value.</returns>
    public static int RescaleByDpiY(int value)
    {
      return (int)((value / DEFAULT_DPI_Y) * mDpiSize.Height);
    }

    /// <summary>
    /// Rescales the given value by the currently used DPI-Settings.
    /// </summary>
    /// <param name="value">The value to rescale.</param>
    /// <returns>The rescaled value.</returns>
    public static int RescaleByDpiX(int value)
    {
      return (int)((value / DEFAULT_DPI_X) * mDpiSize.Width);
    }

    #endregion
  }
}
