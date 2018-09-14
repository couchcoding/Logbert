#region Copyright © 2015 Couchcoding

// File:    OptionPanelBase.cs
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

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Couchcoding.Logbert.Interfaces;

namespace Couchcoding.Logbert.Controls.OptionPanels
{
  /// <summary>
  /// Implements the base class for all <see cref="IOptionPanel"/> instances.
  /// </summary>
  public class OptionPanelBase : UserControl, IOptionPanel
  {
    #region Public Properties

    /// <summary>
    /// Gets the name of the <see cref="IOptionPanel"/> <see cref="System.Windows.Forms.Control"/>.
    /// </summary>
    [Browsable(false)]
    public virtual string PanelName
    {
      get
      {
        return string.Empty;
      }
    }

    /// <summary>
    /// Gets the <see cref="System.Drawing.Image"/> to display left of the <see cref="IOptionPanel"/> name.
    /// </summary>
    [Browsable(false)]
    public virtual Image Image
    {
      get
      {
        return null;
      }
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Method will be called before the <see cref="IOptionPanel"/> is shown first.
    /// </summary>
    public virtual void InitializeControl()
    {

    }

    /// <summary>
    /// Method will be called before the <see cref="IOptionPanel"/> is closed.
    /// </summary>
    /// <returns><c>True</c> if the <see cref="IOptionPanel"/> may be closed, otherwise <c>false</c>.</returns>
    public virtual bool ValidateControl()
    {
      return true;
    }

    /// <summary>
    /// Method will be called before the <see cref="IOptionPanel"/> is shown.
    /// </summary>
    public virtual void BeforePanelShow()
    {

    }

    /// <summary>
    /// Method will be called before the <see cref="IOptionPanel"/> is shown.
    /// </summary>
    /// <param name="parentControl">The parent <see cref="System.Windows.Forms.Control"/> of the <see cref="IOptionPanel"/>.</param>
    public virtual void AdjustSizeAndLocation(Control parentControl)
    {
      if (parentControl != null)
      {
        // Set the dock style of the panel to none.
        Dock = DockStyle.None;

        // Move this panel to the top left corner.
        Location = new Point(0, 0);
        Width    = parentControl.Width;

        // Set the dock style of the panel to fill.
        Dock = DockStyle.Fill;
      }
    }

    /// <summary>
    /// Informs the child <see cref="IOptionPanel"/> control about the <see cref="System.Drawing.Size"/> change of the parent <see cref="System.Windows.Forms.Control"/>.
    /// </summary>
    /// <param name="parentSize">The new <see cref="System.Drawing.Size"/> of the parent <see cref="System.Windows.Forms.Control"/>.</param>
    public virtual void AdjustSize(Size parentSize)
    {
      SuspendLayout();

      try
      {
        Width = parentSize.Width > MinimumSize.Width 
          ? parentSize.Width 
          : MinimumSize.Width;

        Height = parentSize.Height > MinimumSize.Height
          ? parentSize.Height
          : MinimumSize.Height;
      }
      finally
      {
        ResumeLayout(false);
      }
    }

    /// <summary>
    /// Tells the <see cref="IOptionPanel"/> to save the new settings.
    /// </summary>
    public virtual void SaveSettings()
    {

    }

    /// <summary>
    /// Returns a <see cref="T:System.String"/> containing the name of the <see cref="T:System.ComponentModel.Component"/>, if any. This method should not be overridden.
    /// </summary>
    /// <returns>A <see cref="T:System.String"/> containing the name of the <see cref="T:System.ComponentModel.Component"/>, if any, or null if the <see cref="T:System.ComponentModel.Component"/> is unnamed.</returns>
    public override string ToString()
    {
      return PanelName;
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Creates a new instance of the <see cref="OptionPanelBase"/> control.
    /// </summary>
    public OptionPanelBase()
    {
      SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
      SetStyle(ControlStyles.AllPaintingInWmPaint,  true);
      SetStyle(ControlStyles.ResizeRedraw,          true);
    }

    #endregion
  }
}
