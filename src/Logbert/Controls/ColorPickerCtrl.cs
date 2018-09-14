#region Copyright © 2015 Couchcoding

// File:    ColorPickerCtrl.cs
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

using System;
using System.Drawing;
using System.Windows.Forms;

using Couchcoding.Logbert.Gui.Controls;
using Couchcoding.Logbert.Properties;

namespace Couchcoding.Logbert.Controls
{
  /// <summary>
  /// Implements a <see cref="UserControl"/> to select predefined and custom <see cref="Color"/>s.
  /// </summary>
  public partial class ColorPickerCtrl : UserControl
  {
    #region Public Events

    /// <summary>
    /// The <see cref="EventHandler"/> to register for value changes.
    /// </summary>
    public event EventHandler<EventArgs> OnValueChanged;

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets the value of the selected item, or sets the selection to
    /// the item with the specified value.
    /// </summary>
    public Color SelectedValue
    {
      get
      {
        return cddColor.SelectedValue;
      }
      set
      {
        cddColor.SelectedValue = value;
      }
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Adds all standard <see cref="Color"/>s to the <see cref="ColorDropDown"/> and selects the given <paramref name="selectedColor"/>.
    /// </summary>
    /// <param name="selectedColor">The <see cref="Color"/> to initial select.</param>
    public void AddColors(Color selectedColor)
    {
      cddColor.AddStandardColors();

      cddColor.Items.Add(ColorDropDown.ColorInfo.FromColor(
          selectedColor
        , Resources.strOptionPanelFontColorCustomColor
        , true));

      cddColor.SelectedValue = selectedColor;

      // Attach the event handler for the color selection.
      cddColor.SelectedIndexChanged += CddColorSelectedIndexChanged;
    }

    /// <summary>
    /// Handles the Click event of the custom color <see cref="Button"/>.
    /// </summary>
    private void BtnCustomColorClick(object sender, EventArgs e)
    {
      using (ColorDialog clrDlg = new ColorDialog())
      {
        clrDlg.Color = cddColor.SelectedValue;

        if (clrDlg.ShowDialog(this) == DialogResult.OK)
        {
          cddColor.SelectedValue = clrDlg.Color;
        }
      }
    }

    /// <summary>
    /// Handles the SelectedIndexChanged of the <see cref="ColorDropDown"/>.
    /// </summary>
    private void CddColorSelectedIndexChanged(object sender, EventArgs e)
    {
      if (!cddColor.SelectedItem.IsCustomColor)
      {
        // Reset the custom color value.
        cddColor.SetCustomColor(Color.Transparent);
      }

      if (OnValueChanged != null)
      {
        OnValueChanged(
            this
          , EventArgs.Empty);
      }
    }

    /// <summary>
    /// Performs the work of setting the specified bounds of this control.
    /// </summary>
    /// <param name="x">The new <see cref="P:System.Windows.Forms.Control.Left"/> property value of the control. </param><param name="y">The new <see cref="P:System.Windows.Forms.Control.Top"/> property value of the control. </param><param name="width">The new <see cref="P:System.Windows.Forms.Control.Width"/> property value of the control. </param><param name="height">The new <see cref="P:System.Windows.Forms.Control.Height"/> property value of the control. </param><param name="specified">A bitwise combination of the <see cref="T:System.Windows.Forms.BoundsSpecified"/> values. </param>
    protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
    {
      base.SetBoundsCore(x, y, width, cddColor.Height + 2, specified);
    }

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }

      // Remove the event handler for the color selection.
      cddColor.SelectedIndexChanged -= CddColorSelectedIndexChanged;

      base.Dispose(disposing);
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Populate control with standard <see cref="Color"/>s.
    /// </summary>
    public void AddStandardColors()
    {
      cddColor.AddStandardColors();
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Creates a new instance of the <see cref="ColorPickerCtrl"/> <see cref="Control"/>.
    /// </summary>
    public ColorPickerCtrl()
    {
      InitializeComponent();
    }

    #endregion
  }
}
