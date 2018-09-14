namespace Couchcoding.Logbert.Receiver.CustomReceiver.CustomFileReceiver
{
  partial class CustomFileReceiverSettings
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
            this.chkStartFromBeginning = new System.Windows.Forms.CheckBox();
            this.txtLogFile = new Couchcoding.Logbert.Gui.Controls.TextBoxEx();
            this.lblNetworkInterface = new System.Windows.Forms.Label();
            this.lblColumnizer = new System.Windows.Forms.Label();
            this.cmbColumnizer = new System.Windows.Forms.ComboBox();
            this.btnEditColumnizer = new System.Windows.Forms.Button();
            this.btnAddColumnizer = new System.Windows.Forms.Button();
            this.btnRemoveColumnizer = new System.Windows.Forms.Button();
            this.cmbEncoding = new System.Windows.Forms.ComboBox();
            this.lblEncoding = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            // lblColumnizer
            // 
            this.lblColumnizer.AutoSize = true;
            this.lblColumnizer.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblColumnizer.Location = new System.Drawing.Point(0, 69);
            this.lblColumnizer.Name = "lblColumnizer";
            this.lblColumnizer.Size = new System.Drawing.Size(61, 13);
            this.lblColumnizer.TabIndex = 3;
            this.lblColumnizer.Text = "&Columnizer:";
            // 
            // cmbColumnizer
            // 
            this.cmbColumnizer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbColumnizer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColumnizer.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbColumnizer.FormattingEnabled = true;
            this.cmbColumnizer.Location = new System.Drawing.Point(0, 85);
            this.cmbColumnizer.Name = "cmbColumnizer";
            this.cmbColumnizer.Size = new System.Drawing.Size(313, 21);
            this.cmbColumnizer.Sorted = true;
            this.cmbColumnizer.TabIndex = 4;
            // 
            // btnEditColumnizer
            // 
            this.btnEditColumnizer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditColumnizer.Enabled = false;
            this.btnEditColumnizer.Image = global::Couchcoding.Logbert.Properties.Resources.PencilAngled_16xMD_color;
            this.btnEditColumnizer.Location = new System.Drawing.Point(377, 84);
            this.btnEditColumnizer.Name = "btnEditColumnizer";
            this.btnEditColumnizer.Size = new System.Drawing.Size(23, 22);
            this.btnEditColumnizer.TabIndex = 7;
            this.btnEditColumnizer.UseVisualStyleBackColor = true;
            this.btnEditColumnizer.Click += new System.EventHandler(this.BtnEditColumnizerClick);
            // 
            // btnAddColumnizer
            // 
            this.btnAddColumnizer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddColumnizer.Image = global::Couchcoding.Logbert.Properties.Resources.action_add_16xMD;
            this.btnAddColumnizer.Location = new System.Drawing.Point(319, 84);
            this.btnAddColumnizer.Name = "btnAddColumnizer";
            this.btnAddColumnizer.Size = new System.Drawing.Size(23, 22);
            this.btnAddColumnizer.TabIndex = 5;
            this.btnAddColumnizer.UseVisualStyleBackColor = true;
            this.btnAddColumnizer.Click += new System.EventHandler(this.BtnAddColumnizerClick);
            // 
            // btnRemoveColumnizer
            // 
            this.btnRemoveColumnizer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveColumnizer.Image = global::Couchcoding.Logbert.Properties.Resources.Remove_16xMD;
            this.btnRemoveColumnizer.Location = new System.Drawing.Point(348, 84);
            this.btnRemoveColumnizer.Name = "btnRemoveColumnizer";
            this.btnRemoveColumnizer.Size = new System.Drawing.Size(23, 22);
            this.btnRemoveColumnizer.TabIndex = 6;
            this.btnRemoveColumnizer.UseVisualStyleBackColor = true;
            this.btnRemoveColumnizer.Click += new System.EventHandler(this.BtnRemoveColumnizerClick);
            // 
            // cmbEncoding
            // 
            this.cmbEncoding.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbEncoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEncoding.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbEncoding.FormattingEnabled = true;
            this.cmbEncoding.Location = new System.Drawing.Point(0, 131);
            this.cmbEncoding.Name = "cmbEncoding";
            this.cmbEncoding.Size = new System.Drawing.Size(400, 21);
            this.cmbEncoding.Sorted = true;
            this.cmbEncoding.TabIndex = 9;
            // 
            // lblEncoding
            // 
            this.lblEncoding.AutoSize = true;
            this.lblEncoding.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEncoding.Location = new System.Drawing.Point(0, 115);
            this.lblEncoding.Name = "lblEncoding";
            this.lblEncoding.Size = new System.Drawing.Size(55, 13);
            this.lblEncoding.TabIndex = 8;
            this.lblEncoding.Text = "&Encoding:";
            // 
            // CustomFileReceiverSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbEncoding);
            this.Controls.Add(this.lblEncoding);
            this.Controls.Add(this.btnRemoveColumnizer);
            this.Controls.Add(this.btnAddColumnizer);
            this.Controls.Add(this.btnEditColumnizer);
            this.Controls.Add(this.cmbColumnizer);
            this.Controls.Add(this.lblColumnizer);
            this.Controls.Add(this.chkStartFromBeginning);
            this.Controls.Add(this.txtLogFile);
            this.Controls.Add(this.lblNetworkInterface);
            this.MinimumSize = new System.Drawing.Size(0, 154);
            this.Name = "CustomFileReceiverSettings";
            this.Size = new System.Drawing.Size(400, 300);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.CheckBox chkStartFromBeginning;
    private Gui.Controls.TextBoxEx txtLogFile;
    private System.Windows.Forms.Label lblNetworkInterface;
    private System.Windows.Forms.Label lblColumnizer;
    private System.Windows.Forms.ComboBox cmbColumnizer;
    private System.Windows.Forms.Button btnEditColumnizer;
    private System.Windows.Forms.Button btnAddColumnizer;
    private System.Windows.Forms.Button btnRemoveColumnizer;
    private System.Windows.Forms.ComboBox cmbEncoding;
    private System.Windows.Forms.Label lblEncoding;
  }
}
