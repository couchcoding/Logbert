#region Copyright © 2019 Couchcoding

// File:    ListBoxEx.cs
// Package: GuiLibrary
// Project: Logbert
// 
// The MIT License (MIT)
// 
// Copyright (c) 2019 Couchcoding
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

using Couchcoding.Logbert.Gui.Helper;
using System.Drawing;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Couchcoding.Logbert.Controls
{
  /// <summary>
  /// Implements a <see cref="DockPanel"/> that supports a background image even if it is themed.
  /// </summary>
  internal sealed class DockPanelEx : DockPanel
  {
    #region Overridden Methods

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Control.Paint"/> event.
    /// </summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs"/> that contains the event data.</param>
    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);

      if (BackgroundImage != null && Height > 0 && Width > 0)
      {
        Rectangle imageDimensions = new Rectangle(
            0
          , 0
          , BackgroundImage.Width
          , BackgroundImage.Height);

        e.Graphics.DrawImage(BackgroundImage, new Rectangle(
            0
          , 0
          , DpiHelper.RescaleByDpiX(imageDimensions.Width)
          , DpiHelper.RescaleByDpiY(imageDimensions.Height))
          , imageDimensions
          , GraphicsUnit.Pixel);
      }
    }

    #endregion
  }
}
