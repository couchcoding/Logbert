namespace Couchcoding.Logbert.Receiver.EventlogReceiver
{
  partial class EventlogReceiverSettings
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
            this.lblPort = new System.Windows.Forms.Label();
            this.txtMachineName = new System.Windows.Forms.TextBox();
            this.txtSourceName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nfoPanel = new Couchcoding.Logbert.Gui.Controls.InfoPanel();
            this.SuspendLayout();
            // 
            // lblLogName
            // 
            this.lblLogName.AutoSize = true;
            this.lblLogName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLogName.Location = new System.Drawing.Point(0, 0);
            this.lblLogName.Name = "lblLogName";
            this.lblLogName.Size = new System.Drawing.Size(59, 13);
            this.lblLogName.TabIndex = 0;
            this.lblLogName.Text = "Log &Name:";
            // 
            // cmbLogNames
            // 
            this.cmbLogNames.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbLogNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLogNames.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbLogNames.FormattingEnabled = true;
            this.cmbLogNames.Location = new System.Drawing.Point(0, 16);
            this.cmbLogNames.Name = "cmbLogNames";
            this.cmbLogNames.Size = new System.Drawing.Size(400, 21);
            this.cmbLogNames.TabIndex = 1;
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPort.Location = new System.Drawing.Point(0, 46);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(82, 13);
            this.lblPort.TabIndex = 2;
            this.lblPort.Text = "&Machine Name:";
            // 
            // txtMachineName
            // 
            this.txtMachineName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMachineName.Location = new System.Drawing.Point(0, 62);
            this.txtMachineName.Name = "txtMachineName";
            this.txtMachineName.Size = new System.Drawing.Size(400, 20);
            this.txtMachineName.TabIndex = 3;
            // 
            // txtSourceName
            // 
            this.txtSourceName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSourceName.Location = new System.Drawing.Point(0, 142);
            this.txtSourceName.Name = "txtSourceName";
            this.txtSourceName.Size = new System.Drawing.Size(400, 20);
            this.txtSourceName.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Location = new System.Drawing.Point(0, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "&Source Name (Optional):";
            // 
            // nfoPanel
            // 
            this.nfoPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nfoPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.nfoPanel.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.nfoPanel.InfoIcon = global::Couchcoding.Logbert.Properties.Resources.StatusAnnotations_Information_16xLG;
            this.nfoPanel.Location = new System.Drawing.Point(0, 89);
            this.nfoPanel.Name = "nfoPanel";
            this.nfoPanel.ShowInfoIcon = true;
            this.nfoPanel.ShowTitle = false;
            this.nfoPanel.Size = new System.Drawing.Size(400, 28);
            this.nfoPanel.TabIndex = 4;
            this.nfoPanel.Text = "A simple \'.\' means the local machine.";
            this.nfoPanel.TextPadding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.nfoPanel.Title = "";
            // 
            // EventlogReceiverSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nfoPanel);
            this.Controls.Add(this.txtSourceName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMachineName);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.cmbLogNames);
            this.Controls.Add(this.lblLogName);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MinimumSize = new System.Drawing.Size(0, 165);
            this.Name = "EventlogReceiverSettings";
            this.Size = new System.Drawing.Size(400, 300);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label lblLogName;
    private System.Windows.Forms.ComboBox cmbLogNames;
    private System.Windows.Forms.Label lblPort;
    private System.Windows.Forms.TextBox txtMachineName;
    private System.Windows.Forms.TextBox txtSourceName;
    private System.Windows.Forms.Label label1;
    private Gui.Controls.InfoPanel nfoPanel;
  }
}
