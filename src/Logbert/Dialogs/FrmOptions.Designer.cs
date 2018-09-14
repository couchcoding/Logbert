namespace Couchcoding.Logbert.Dialogs
{
  partial class FrmOptions
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

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
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.grpSettings = new Couchcoding.Logbert.Gui.Controls.GroupBoxEx();
      this.pnlOptionPanel = new System.Windows.Forms.Panel();
      this.lstSettings = new Couchcoding.Logbert.Gui.Controls.ListBoxEx();
      this.btnCancel = new System.Windows.Forms.Button();
      this.btnOk = new System.Windows.Forms.Button();
      this.grpSettings.SuspendLayout();
      this.SuspendLayout();
      // 
      // grpSettings
      // 
      this.grpSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.grpSettings.Controls.Add(this.pnlOptionPanel);
      this.grpSettings.GroupImage = global::Couchcoding.Logbert.Properties.Resources.properties_16xLG;
      this.grpSettings.Location = new System.Drawing.Point(194, 68);
      this.grpSettings.Name = "grpSettings";
      this.grpSettings.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
      this.grpSettings.SeperatorColor = System.Drawing.SystemColors.ControlDark;
      this.grpSettings.Size = new System.Drawing.Size(422, 324);
      this.grpSettings.TabIndex = 1;
      this.grpSettings.TabStop = false;
      this.grpSettings.Text = "Settings";
      this.grpSettings.VisibleChanged += new System.EventHandler(this.PnlOptionPanelVisibleChanged);
      // 
      // pnlOptionPanel
      // 
      this.pnlOptionPanel.AutoScroll = true;
      this.pnlOptionPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pnlOptionPanel.Location = new System.Drawing.Point(0, 36);
      this.pnlOptionPanel.Name = "pnlOptionPanel";
      this.pnlOptionPanel.Size = new System.Drawing.Size(422, 288);
      this.pnlOptionPanel.TabIndex = 0;
      this.pnlOptionPanel.VisibleChanged += new System.EventHandler(this.PnlOptionPanelVisibleChanged);
      // 
      // lstSettings
      // 
      this.lstSettings.Dock = System.Windows.Forms.DockStyle.Left;
      this.lstSettings.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
      this.lstSettings.FormattingEnabled = true;
      this.lstSettings.IntegralHeight = false;
      this.lstSettings.ItemHeight = 24;
      this.lstSettings.Location = new System.Drawing.Point(5, 65);
      this.lstSettings.Name = "lstSettings";
      this.lstSettings.Size = new System.Drawing.Size(180, 372);
      this.lstSettings.TabIndex = 0;
      this.lstSettings.SelectedIndexChanged += new System.EventHandler(this.LstSettingsSelectedIndexChanged);
      // 
      // btnCancel
      // 
      this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.btnCancel.Location = new System.Drawing.Point(541, 410);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 23);
      this.btnCancel.TabIndex = 3;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      // 
      // btnOk
      // 
      this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.btnOk.Location = new System.Drawing.Point(460, 410);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new System.Drawing.Size(75, 23);
      this.btnOk.TabIndex = 2;
      this.btnOk.Text = "OK";
      this.btnOk.UseVisualStyleBackColor = true;
      // 
      // FrmOptions
      // 
      this.AcceptButton = this.btnOk;
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.CancelButton = this.btnCancel;
      this.ClientSize = new System.Drawing.Size(624, 442);
      this.Controls.Add(this.grpSettings);
      this.Controls.Add(this.lstSettings);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnOk);
      this.DialogMainCaption = "Options";
      this.DialogMainDescription = "Setup the program behaviour and the look and feel.";
      this.MinimumSize = new System.Drawing.Size(640, 480);
      this.Name = "FrmOptions";
      this.Text = "Options";
      this.grpSettings.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private Gui.Controls.GroupBoxEx grpSettings;
    private Gui.Controls.ListBoxEx lstSettings;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Button btnOk;
    private System.Windows.Forms.Panel pnlOptionPanel;
  }
}