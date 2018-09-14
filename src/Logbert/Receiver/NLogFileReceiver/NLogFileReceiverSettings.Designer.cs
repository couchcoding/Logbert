namespace Couchcoding.Logbert.Receiver.NLogFileReceiver
{
  partial class NLogFileReceiverSettings
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
            this.lblNetworkInterface = new System.Windows.Forms.Label();
            this.txtLogFile = new Couchcoding.Logbert.Gui.Controls.TextBoxEx();
            this.chkStartFromBeginning = new System.Windows.Forms.CheckBox();
            this.cmbEncoding = new System.Windows.Forms.ComboBox();
            this.lblEncoding = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblNetworkInterface
            // 
            this.lblNetworkInterface.AutoSize = true;
            this.lblNetworkInterface.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblNetworkInterface.Location = new System.Drawing.Point(0, 0);
            this.lblNetworkInterface.Name = "lblNetworkInterface";
            this.lblNetworkInterface.Size = new System.Drawing.Size(79, 13);
            this.lblNetworkInterface.TabIndex = 0;
            this.lblNetworkInterface.Text = "&File to observe:";
            // 
            // txtLogFile
            // 
            this.txtLogFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLogFile.Location = new System.Drawing.Point(0, 16);
            this.txtLogFile.Name = "txtLogFile";
            this.txtLogFile.Size = new System.Drawing.Size(400, 20);
            this.txtLogFile.TabIndex = 1;
            this.txtLogFile.ButtonClick += new System.EventHandler(this.TxtLogFileButtonClick);
            // 
            // chkStartFromBeginning
            // 
            this.chkStartFromBeginning.AutoSize = true;
            this.chkStartFromBeginning.Checked = true;
            this.chkStartFromBeginning.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkStartFromBeginning.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkStartFromBeginning.Location = new System.Drawing.Point(0, 42);
            this.chkStartFromBeginning.Name = "chkStartFromBeginning";
            this.chkStartFromBeginning.Size = new System.Drawing.Size(129, 18);
            this.chkStartFromBeginning.TabIndex = 2;
            this.chkStartFromBeginning.Text = "&Start from beginning.";
            this.chkStartFromBeginning.UseVisualStyleBackColor = true;
            // 
            // cmbEncoding
            // 
            this.cmbEncoding.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbEncoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEncoding.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbEncoding.FormattingEnabled = true;
            this.cmbEncoding.Location = new System.Drawing.Point(0, 85);
            this.cmbEncoding.Name = "cmbEncoding";
            this.cmbEncoding.Size = new System.Drawing.Size(400, 21);
            this.cmbEncoding.Sorted = true;
            this.cmbEncoding.TabIndex = 8;
            // 
            // lblEncoding
            // 
            this.lblEncoding.AutoSize = true;
            this.lblEncoding.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEncoding.Location = new System.Drawing.Point(0, 69);
            this.lblEncoding.Name = "lblEncoding";
            this.lblEncoding.Size = new System.Drawing.Size(55, 13);
            this.lblEncoding.TabIndex = 7;
            this.lblEncoding.Text = "&Encoding:";
            // 
            // NLogFileReceiverSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbEncoding);
            this.Controls.Add(this.lblEncoding);
            this.Controls.Add(this.chkStartFromBeginning);
            this.Controls.Add(this.txtLogFile);
            this.Controls.Add(this.lblNetworkInterface);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MinimumSize = new System.Drawing.Size(0, 108);
            this.Name = "NLogFileReceiverSettings";
            this.Size = new System.Drawing.Size(400, 300);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label lblNetworkInterface;
    private Gui.Controls.TextBoxEx txtLogFile;
    private System.Windows.Forms.CheckBox chkStartFromBeginning;
    private System.Windows.Forms.ComboBox cmbEncoding;
    private System.Windows.Forms.Label lblEncoding;
  }
}
