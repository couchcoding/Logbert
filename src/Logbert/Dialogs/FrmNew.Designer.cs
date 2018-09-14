namespace Couchcoding.Logbert.Dialogs
{
  partial class FrmNew
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
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lstLogger = new Couchcoding.Logbert.Gui.Controls.ListBoxEx();
            this.grpSettings = new Couchcoding.Logbert.Gui.Controls.GroupBoxEx();
            this.pnlLoggerPanel = new System.Windows.Forms.Panel();
            this.grpSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOk.Location = new System.Drawing.Point(460, 410);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Location = new System.Drawing.Point(541, 410);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lstLogger
            // 
            this.lstLogger.Dock = System.Windows.Forms.DockStyle.Left;
            this.lstLogger.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.lstLogger.FormattingEnabled = true;
            this.lstLogger.IntegralHeight = false;
            this.lstLogger.ItemHeight = 24;
            this.lstLogger.Location = new System.Drawing.Point(5, 65);
            this.lstLogger.Name = "lstLogger";
            this.lstLogger.Size = new System.Drawing.Size(180, 372);
            this.lstLogger.TabIndex = 2;
            this.lstLogger.SelectedIndexChanged += new System.EventHandler(this.LstLoggerSelectedIndexChanged);
            // 
            // grpSettings
            // 
            this.grpSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSettings.Controls.Add(this.pnlLoggerPanel);
            this.grpSettings.GroupImage = global::Couchcoding.Logbert.Properties.Resources.properties_16xLG;
            this.grpSettings.Location = new System.Drawing.Point(194, 68);
            this.grpSettings.Name = "grpSettings";
            this.grpSettings.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.grpSettings.SeperatorColor = System.Drawing.SystemColors.ControlDark;
            this.grpSettings.Size = new System.Drawing.Size(422, 324);
            this.grpSettings.TabIndex = 3;
            this.grpSettings.TabStop = false;
            this.grpSettings.Text = "Settings";
            // 
            // pnlLoggerPanel
            // 
            this.pnlLoggerPanel.AutoScroll = true;
            this.pnlLoggerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLoggerPanel.Location = new System.Drawing.Point(0, 36);
            this.pnlLoggerPanel.Name = "pnlLoggerPanel";
            this.pnlLoggerPanel.Size = new System.Drawing.Size(422, 288);
            this.pnlLoggerPanel.TabIndex = 1;
            // 
            // FrmNew
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.grpSettings);
            this.Controls.Add(this.lstLogger);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.DialogMainCaption = "New Logger";
            this.DialogMainDescription = "Select and setup the logger type to create.";
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "FrmNew";
            this.Text = "New Logger";
            this.grpSettings.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button btnOk;
    private System.Windows.Forms.Button btnCancel;
    private Couchcoding.Logbert.Gui.Controls.ListBoxEx lstLogger;
    private Couchcoding.Logbert.Gui.Controls.GroupBoxEx grpSettings;
    private System.Windows.Forms.Panel pnlLoggerPanel;
  }
}