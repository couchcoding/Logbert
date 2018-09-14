#region Copyright © 2015 Couchcoding

// File:    TextBoxEx.cs
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
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

using Couchcoding.Logbert.Gui.Interop;

namespace Couchcoding.Logbert.Gui.Controls
{
  /// <summary>
  /// Implements a <see cref="TextBox"/> with a <see cref="Button"/>.
  /// </summary>
  public class TextBoxEx : TextBox
  {
    #region Private Consts

    /// <summary>
    /// Defines the default width of the <see cref="Button"/>.
    /// </summary>
    private const int ELLIPSIS_BUTTON_WIDTH = 23;

    #endregion

    #region Private Fields

    /// <summary>
    /// Holds the reference to the <see cref="Button"/>.
    /// </summary>
    private readonly Button mButton;

    #endregion

    #region Public Events

    /// <summary>
    /// Raises the Click event of the <see cref="Button"/>.
    /// </summary>
    public event EventHandler ButtonClick
    {
      add
      {
        mButton.Click += value;
      }
      remove
      {
        mButton.Click -= value;
      }
    }

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets or sets the text displayed on the <see cref="Button"/>.
    /// </summary>
    [Localizable(true)]
    [DefaultValue("...")]
    [Description("The text displayed on the button.")]
    public string ButtonText
    {
      get
      {
        return mButton.Text;
      }
      set
      {
        if (!Equals(mButton.Text, value))
        {
          mButton.Text = value;
        }
      }
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Control.Resize"/> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data. </param>
    protected override void OnResize(EventArgs e)
    {
      base.OnResize(e);

      // The space around the ellipsis button depends on the system rendering.
      int borderAdjust = VisualStyleRenderer.IsSupported 
        ? SystemInformation.Border3DSize.Width - 1
        : SystemInformation.Border3DSize.Width - 2;

      // Calculate and set the new button bounds.
      mButton.Bounds = new Rectangle(
          ClientSize.Width - (ELLIPSIS_BUTTON_WIDTH - borderAdjust)
        , -borderAdjust
        , ELLIPSIS_BUTTON_WIDTH
        , ClientSize.Height + (borderAdjust + borderAdjust));

      // Tell the textbox about the smaller text area size.
      Win32.SendMessage(
          Handle
        , Win32.EM_SETMARGINS
        , (IntPtr)2
        , (IntPtr)(mButton.Width << 16));
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Creates a new instance of the <see cref="TextBoxEx"/> <see cref="Control"/>.
    /// </summary>
    public TextBoxEx()
    {
      mButton           = new Button();
      mButton.Cursor    = Cursors.Default;
      mButton.FlatStyle = FlatStyle.System;
      mButton.BackColor = SystemColors.Control;
      mButton.Text      = "...";

      Controls.Add(mButton);
    }

    #endregion
  }
}
