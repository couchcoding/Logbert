namespace Couchcoding.Logbert.Dialogs
{
  partial class FrmTimestamps
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
            this.lblTimestampFormat = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.nfoPanel = new Couchcoding.Logbert.Gui.Controls.InfoPanel();
            this.txtTimestamps = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblTimestampFormat
            // 
            this.lblTimestampFormat.AutoSize = true;
            this.lblTimestampFormat.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTimestampFormat.Location = new System.Drawing.Point(9, 68);
            this.lblTimestampFormat.Name = "lblTimestampFormat";
            this.lblTimestampFormat.Size = new System.Drawing.Size(115, 15);
            this.lblTimestampFormat.TabIndex = 0;
            this.lblTimestampFormat.Text = "Timestamp Formats:";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Location = new System.Drawing.Point(380, 229);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOk.Location = new System.Drawing.Point(299, 229);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // nfoPanel
            // 
            this.nfoPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nfoPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.nfoPanel.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.nfoPanel.InfoIcon = global::Couchcoding.Logbert.Properties.Resources.StatusAnnotations_Information_16xLG;
            this.nfoPanel.Location = new System.Drawing.Point(9, 175);
            this.nfoPanel.Name = "nfoPanel";
            this.nfoPanel.ShowInfoIcon = true;
            this.nfoPanel.ShowTitle = false;
            this.nfoPanel.Size = new System.Drawing.Size(446, 48);
            this.nfoPanel.TabIndex = 2;
            this.nfoPanel.Text = "Add as many timestamps to support as you want, but ensure to place each timestamp" +
    " on a new line.";
            this.nfoPanel.TextPadding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.nfoPanel.Title = "";
            // 
            // txtTimestamps
            // 
            this.txtTimestamps.AcceptsReturn = true;
            this.txtTimestamps.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimestamps.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimestamps.Location = new System.Drawing.Point(9, 86);
            this.txtTimestamps.Multiline = true;
            this.txtTimestamps.Name = "txtTimestamps";
            this.txtTimestamps.Size = new System.Drawing.Size(446, 83);
            this.txtTimestamps.TabIndex = 1;
            this.txtTimestamps.WordWrap = false;
            // 
            // FrmTimestamps
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(464, 261);
            this.Controls.Add(this.txtTimestamps);
            this.Controls.Add(this.nfoPanel);
            this.Controls.Add(this.lblTimestampFormat);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.DialogMainCaption = "Edit Timestamps";
            this.DialogMainDescription = "Edit the list of supported timestamps.";
            this.MinimumSize = new System.Drawing.Size(480, 300);
            this.Name = "FrmTimestamps";
            this.Text = "Edit Timestamps";
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Label lblTimestampFormat;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Button btnOk;
    private Gui.Controls.InfoPanel nfoPanel;
    private System.Windows.Forms.TextBox txtTimestamps;
  }
}