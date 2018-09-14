#region Copyright © 2015 Couchcoding

// File:    FrmOptions.cs
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

using System.Windows.Forms;

using Couchcoding.Logbert.Gui.Dialogs;
using Couchcoding.Logbert.Helper;
using Couchcoding.Logbert.Interfaces;
using Couchcoding.Logbert.Properties;
using System.Drawing;


namespace Couchcoding.Logbert.Dialogs
{
  /// <summary>
  /// Implements the option dialog.
  /// </summary>
  public partial class FrmOptions : DialogForm
  {
    #region Private Methods

    /// <summary>
    /// Handles the SelectedIndexChanged event of the option <see cref="ListBox"/>.
    /// </summary>
    private void LstSettingsSelectedIndexChanged(object sender, System.EventArgs e)
    {
      if (lstSettings.SelectedItem is IOptionPanel)
      {
        if (pnlOptionPanel.Controls.Count > 0 && pnlOptionPanel.Controls[0] is IOptionPanel)
        {
          if (Equals(pnlOptionPanel.Controls[0], lstSettings.SelectedItem))
          {
            return;
          }

          if (!((IOptionPanel)pnlOptionPanel.Controls[0]).ValidateControl())
          {
            // Remove the event handler (temporary)
            lstSettings.SelectedIndexChanged -= LstSettingsSelectedIndexChanged;

            try
            {
              lstSettings.SelectedItem = (IOptionPanel)pnlOptionPanel.Controls[0];
            }
            finally
            {
              // Re-Add the event handler after the panel has been changed.
              lstSettings.SelectedIndexChanged += LstSettingsSelectedIndexChanged;
            }

            return;
          }

          // Remove the old option panel control.
          pnlOptionPanel.Controls.Remove(pnlOptionPanel.Controls[0]);
        }

        pnlOptionPanel.Visible = false;

        // Set the cursors into wait state if necessary.
        using (new WaitCursor(Cursors.Default, Settings.Default.WaitCursorTimeout))
        {
          // Let the optional panel initialize itself.
          ((IOptionPanel)lstSettings.SelectedItem).BeforePanelShow();
        }

        try
        {
          // Show the new option panel control.
          pnlOptionPanel.Controls.Add((Control)lstSettings.SelectedItem);
          pnlOptionPanel.AutoScrollMinSize = pnlOptionPanel.Controls[0].MinimumSize;
          grpSettings.Text       = ((IOptionPanel)lstSettings.SelectedItem).PanelName;
          grpSettings.GroupImage = ((IOptionPanel)lstSettings.SelectedItem).Image;

          // Initialize the new option panel control.
          ((IOptionPanel)lstSettings.SelectedItem).AdjustSizeAndLocation(grpSettings);
        }
        finally
        {
          pnlOptionPanel.Visible = true;
        }
      }
    }

    /// <summary>
    /// Handles the VisibleChanged event of the settings <see cref="Panel"/> control.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void PnlOptionPanelVisibleChanged(object sender, System.EventArgs e)
    {
      Invalidate(true);
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Control.SizeChanged"/> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data. </param>
    protected override void OnSizeChanged(System.EventArgs e)
    {
      base.OnSizeChanged(e);

      if (pnlOptionPanel.Controls.Count > 0 && pnlOptionPanel.Controls[0] is IOptionPanel)
      {
        // Inform the option panel about this event.
        ((IOptionPanel)pnlOptionPanel.Controls[0]).AdjustSize(pnlOptionPanel.Size);
      }
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Form.Load"/> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data. </param>
    protected override void OnLoad(System.EventArgs e)
    {
      base.OnLoad(e);

      if (lstSettings.Items.Count > 0)
      {
        // Select the very first option panel.
        lstSettings.SelectedIndex = 0;
      }
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Form.Closing"/> event.
    /// </summary>
    /// <param name="e">A <see cref="T:System.ComponentModel.CancelEventArgs"/> that contains the event data. </param>
    protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
    {
      if (DialogResult == DialogResult.OK)
      {
        IOptionPanel optionPanel = lstSettings.SelectedItem as IOptionPanel;

        if (optionPanel != null && !optionPanel.ValidateControl())
        {
          e.Cancel = true;
        }
      }

      base.OnClosing(e);
    }

    /// <summary>
    /// Draws the dialog as a default MSR dialog.
    /// </summary>
    /// <param name="grfx">The <see cref="Graphics"/> context to draw on.</param>
    protected override void DrawDialogBackground(Graphics grfx)
    {
      base.DrawDialogBackground(grfx);

      if (!grpSettings.Visible)
      {
        TextRenderer.DrawText(
            grfx
          , Resources.strOptionPanelPleaseWait
          , Font
          , grpSettings.Bounds
          , SystemColors.Control
          , BackColor
          ,   TextFormatFlags.HorizontalCenter 
            | TextFormatFlags.VerticalCenter 
            | TextFormatFlags.SingleLine);
      }
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Creates a new instance of the <see cref="FrmOptions"/> <see cref="Form"/>.
    /// </summary>
    /// <param name="panels">The list of <see cref="IOptionPanel"/>s to add.</param>
    public FrmOptions(IOptionPanel[] panels)
    {
      InitializeComponent();

      SetStyle(ControlStyles.AllPaintingInWmPaint, true);

      if (panels == null || panels.Length == 0)
      {
        // No panels to add.
        return;
      }

      lstSettings.Items.AddRange(panels);

      using (new WaitCursor(Cursors.WaitCursor))
      {
        // Initialize all option panels.
        foreach (IOptionPanel optionPanel in lstSettings.Items)
        {
          optionPanel.InitializeControl();
        }
      }
    }

    #endregion
  }
}
