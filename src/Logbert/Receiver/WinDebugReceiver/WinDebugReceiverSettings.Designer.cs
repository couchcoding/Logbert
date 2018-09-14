namespace Couchcoding.Logbert.Receiver.WinDebugReceiver
{
  partial class WinDebugReceiverSettings
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.lblLogName = new System.Windows.Forms.Label();
            this.cmbLogNames = new System.Windows.Forms.ComboBox();
            this.nfoPanel = new Couchcoding.Logbert.Gui.Controls.InfoPanel();
            this.SuspendLayout();
            // 
            // lblLogName
            // 
            this.lblLogName.AutoSize = true;
            this.lblLogName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLogName.Location = new System.Drawing.Point(0, 0);
            this.lblLogName.Name = "lblLogName";
            this.lblLogName.Size = new System.Drawing.Size(98, 13);
            this.lblLogName.TabIndex = 0;
            this.lblLogName.Text = "Process to &Monitor:";
            // 
            // cmbLogNames
            // 
            this.cmbLogNames.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbLogNames.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbLogNames.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLogNames.FormattingEnabled = true;
            this.cmbLogNames.Location = new System.Drawing.Point(0, 16);
            this.cmbLogNames.Name = "cmbLogNames";
            this.cmbLogNames.Size = new System.Drawing.Size(400, 23);
            this.cmbLogNames.TabIndex = 1;
            // 
            // nfoPanel
            // 
            this.nfoPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nfoPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.nfoPanel.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.nfoPanel.InfoIcon = global::Couchcoding.Logbert.Properties.Resources.StatusAnnotations_Information_16xLG;
            this.nfoPanel.Location = new System.Drawing.Point(0, 43);
            this.nfoPanel.Name = "nfoPanel";
            this.nfoPanel.ShowInfoIcon = true;
            this.nfoPanel.ShowTitle = false;
            this.nfoPanel.Size = new System.Drawing.Size(400, 28);
            this.nfoPanel.TabIndex = 5;
            this.nfoPanel.Text = "Leave the process field emtpy to monitor all debug messages.";
            this.nfoPanel.TextPadding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.nfoPanel.Title = "";
            // 
            // WinDebugReceiverSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nfoPanel);
            this.Controls.Add(this.cmbLogNames);
            this.Controls.Add(this.lblLogName);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MinimumSize = new System.Drawing.Size(0, 73);
            this.Name = "WinDebugReceiverSettings";
            this.Size = new System.Drawing.Size(400, 300);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label lblLogName;
    private System.Windows.Forms.ComboBox cmbLogNames;
    private Gui.Controls.InfoPanel nfoPanel;
  }
}
