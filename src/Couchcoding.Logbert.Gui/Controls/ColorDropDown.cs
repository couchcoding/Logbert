#region Copyright © 2015 Couchcoding

// File:    ColorDropDown.cs
// Package: GuiLibrary
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

namespace Couchcoding.Logbert.Gui.Controls
{
  /// <summary>
  /// Implements a <see cref="ComboBox"/> <see cref="Control"/> to select a <see cref="Color"/>.
  /// </summary>
  public class ColorDropDown : ComboBox
  {
    #region Public Types

    /// <summary>
    /// Simple object to map <see cref="Color"/>s and strings.
    /// </summary>
    public class ColorInfo
    {
      #region Public Properties

      /// <summary>
      /// Gets or sets the text of the <see cref="ColorInfo"/> object.
      /// </summary>
      public string Text
      {
        get;
        set;
      }

      /// <summary>
      /// Gets or sets the <see cref=" Color"/> the <see cref="ColorInfo"/> object represents.
      /// </summary>
      public Color Color
      {
        get;
        set;
      }

      /// <summary>
      /// Determines whether the <see cref="ColorInfo"/> is a custom <see cref="Color"/>, or not.
      /// </summary>
      public bool IsCustomColor
      {
        get;
        private set;
      }

      #endregion

      #region Public Methods

      /// <summary>
      /// Get a new <see cref="ColorInfo"/> instance initialized by the given <paramref name="color"/>.
      /// </summary>
      /// <param name="color">The <see cref="Color"/> to initialize the <see cref="ColorInfo"/> from.</param>
      /// <param name="text">The optional text of the new <see cref="ColorInfo"/>.</param>
      /// <param name="isCustomColor">Determines whether the <see cref="ColorInfo"/> is a custom <see cref="Color"/>, or not.</param>
      /// <returns>A new <see cref="ColorInfo"/> instance initialized by the given <paramref name="color"/>.</returns>
      public static ColorInfo FromColor(Color color, string text = "", bool isCustomColor = false)
      {
        return new ColorInfo(string.IsNullOrEmpty(text) 
          ? color.Name
          : text, color, isCustomColor);
      }

      #endregion

      #region Constructor

      /// <summary>
      /// Creates a new instance of the <see cref="ColorInfo"/> object.
      /// </summary>
      /// <param name="text">The text of the new <see cref="ColorInfo"/> instance.</param>
      /// <param name="color">The <see cref="Color"/> of the new <see cref=" ColorInfo"/> instance.</param>
      /// <param name="isCustomColor">Determines whether the <see cref="ColorInfo"/> is a custom <see cref="Color"/>, or not.</param>
      private ColorInfo(string text, Color color, bool isCustomColor = false)
      {
        Text          = text;
        Color         = color;
        IsCustomColor = isCustomColor;
      }

      #endregion
    }

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets or sets the currently selected item.
    /// </summary>
    public new ColorInfo SelectedItem
    {
      get
      {
        return (ColorInfo)base.SelectedItem;
      }
      set
      {
        base.SelectedItem = value;
      }
    }

    /// <summary>
    /// Gets the text of the selected item, or sets the selection to
    /// the item with the specified text.
    /// </summary>
    public new string SelectedText
    {
      get
      {
        return SelectedIndex >= 0 
          ? SelectedItem.Text 
          : String.Empty;
      }
      set
      {
        for (int i = 0; i < Items.Count; i++)
        {
          if (((ColorInfo)Items[i]).Text == value)
          {
            SelectedIndex = i;
            break;
          }
        }
      }
    }

    /// <summary>
    /// Gets the value of the selected item, or sets the selection to
    /// the item with the specified value.
    /// </summary>
    public new Color SelectedValue
    {
      get
      {
        return SelectedIndex >= 0 
          ? SelectedItem.Color 
          : Color.White;
      }
      set
      {
        for (int i = 0; i < Items.Count; ++i)
        {
          if (((ColorInfo)Items[i]).Color == value)
          {
            if (!((ColorInfo)Items[i]).IsCustomColor)
            {
              // Reset the custom color value
              SetCustomColor(Color.Transparent);
            }

            SelectedIndex = i;
            return;
          }
        }

        // Update the custom color value.
        SetCustomColor(value);

        // Set the custom color selected.
        SelectedIndex = Items.Count - 1;
      }
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Populate control with standard <see cref="Color"/>s.
    /// </summary>
    public void AddStandardColors(ColorInfo customColor = null)
    {
      Items.Clear();

      Items.Add(ColorInfo.FromColor(Color.Black));
      Items.Add(ColorInfo.FromColor(Color.Blue));
      Items.Add(ColorInfo.FromColor(Color.Lime));
      Items.Add(ColorInfo.FromColor(Color.Cyan));
      Items.Add(ColorInfo.FromColor(Color.Red));
      Items.Add(ColorInfo.FromColor(Color.Fuchsia));
      Items.Add(ColorInfo.FromColor(Color.Yellow));
      Items.Add(ColorInfo.FromColor(Color.White));
      Items.Add(ColorInfo.FromColor(Color.Navy));
      Items.Add(ColorInfo.FromColor(Color.Green));
      Items.Add(ColorInfo.FromColor(Color.Teal));
      Items.Add(ColorInfo.FromColor(Color.Maroon));
      Items.Add(ColorInfo.FromColor(Color.Purple));
      Items.Add(ColorInfo.FromColor(Color.Olive));
      Items.Add(ColorInfo.FromColor(Color.Gray));

      if (customColor != null)
      {
        Items.Add(customColor);
      }
    }

    /// <summary>
    /// Sets the <see cref="Color"/> of the custom <see cref="Color"/> item.
    /// </summary>
    /// <param name="color">The custom <see cref="Color"/> to set.</param>
    public void SetCustomColor(Color color)
    {
      if (Items.Count > 0 && ((ColorInfo)Items[Items.Count - 1]).IsCustomColor)
      {
        ((ColorInfo)Items[Items.Count - 1]).Color = color;
      }

      Invalidate();
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.ComboBox.DrawItem"/> event.
    /// </summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.DrawItemEventArgs"/> that contains the event data. </param>
    protected override void OnDrawItem(DrawItemEventArgs e)
    {
      if (e.Index >= 0)
      {
        ColorInfo color = (ColorInfo)Items[e.Index];

        e.DrawBackground();

        // Draw the color box
        Rectangle rect = new Rectangle();
        rect.X         = e.Bounds.X + 2;
        rect.Y         = e.Bounds.Y + 2;
        rect.Width     = 18;
        rect.Height    = e.Bounds.Height - 5;

        using (SolidBrush cbBrush =  new SolidBrush(color.Color))
        {
          e.Graphics.FillRectangle(cbBrush, rect);
        }
        
        e.Graphics.DrawRectangle(
            SystemPens.WindowText
          , rect);

        // Enable smooth drawing.
        e.Graphics.TextRenderingHint = System.Drawing.
          Text.TextRenderingHint.ClearTypeGridFit;

        // Write the color name
        Brush brush = (e.State & DrawItemState.Selected) != DrawItemState.None 
          ? SystemBrushes.HighlightText 
          : SystemBrushes.WindowText;

        e.Graphics.DrawString(color.Text, Font, brush,
            e.Bounds.X + rect.X + rect.Width + 2,
            e.Bounds.Y + ((e.Bounds.Height - Font.Height) >> 1));

        // Draw the focus rectangle if appropriate
        if ((e.State & DrawItemState.NoFocusRect) == DrawItemState.None)
        {
          e.DrawFocusRectangle();
        }
      }
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Creates a new instance of the <see cref="ColorDropDown"/> <see cref="Control"/>.
    /// </summary>
    public ColorDropDown()
    {
      DropDownStyle = ComboBoxStyle.DropDownList;
      DrawMode      = DrawMode.OwnerDrawFixed;
    }

    #endregion
  }
}
