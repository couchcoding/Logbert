namespace Couchcoding.Logbert.Receiver.CustomReceiver.CustomHttpReceiver
{
  partial class CustomHttpReceiverSettings
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
            this.lblUrl = new System.Windows.Forms.Label();
            this.btnRemoveColumnizer = new System.Windows.Forms.Button();
            this.btnAddColumnizer = new System.Windows.Forms.Button();
            this.btnEditColumnizer = new System.Windows.Forms.Button();
            this.cmbColumnizer = new System.Windows.Forms.ComboBox();
            this.lblColumnizer = new System.Windows.Forms.Label();
            this.cmbEncoding = new System.Windows.Forms.ComboBox();
            this.lblEncoding = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.chkAuthentication = new System.Windows.Forms.CheckBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblReload = new System.Windows.Forms.Label();
            this.nudPollingTime = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudPollingTime)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUrl.Location = new System.Drawing.Point(0, 0);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(32, 13);
            this.lblUrl.TabIndex = 0;
            this.lblUrl.Text = "&URL:";
            // 
            // btnRemoveColumnizer
            // 
            this.btnRemoveColumnizer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveColumnizer.Image = global::Couchcoding.Logbert.Properties.Resources.Remove_16xMD;
            this.btnRemoveColumnizer.Location = new System.Drawing.Point(348, 213);
            this.btnRemoveColumnizer.Name = "btnRemoveColumnizer";
            this.btnRemoveColumnizer.Size = new System.Drawing.Size(23, 22);
            this.btnRemoveColumnizer.TabIndex = 12;
            this.btnRemoveColumnizer.UseVisualStyleBackColor = true;
            this.btnRemoveColumnizer.Click += new System.EventHandler(this.BtnRemoveColumnizerClick);
            // 
            // btnAddColumnizer
            // 
            this.btnAddColumnizer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddColumnizer.Image = global::Couchcoding.Logbert.Properties.Resources.action_add_16xMD;
            this.btnAddColumnizer.Location = new System.Drawing.Point(319, 213);
            this.btnAddColumnizer.Name = "btnAddColumnizer";
            this.btnAddColumnizer.Size = new System.Drawing.Size(23, 22);
            this.btnAddColumnizer.TabIndex = 11;
            this.btnAddColumnizer.UseVisualStyleBackColor = true;
            this.btnAddColumnizer.Click += new System.EventHandler(this.BtnAddColumnizerClick);
            // 
            // btnEditColumnizer
            // 
            this.btnEditColumnizer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditColumnizer.Enabled = false;
            this.btnEditColumnizer.Image = global::Couchcoding.Logbert.Properties.Resources.PencilAngled_16xMD_color;
            this.btnEditColumnizer.Location = new System.Drawing.Point(377, 213);
            this.btnEditColumnizer.Name = "btnEditColumnizer";
            this.btnEditColumnizer.Size = new System.Drawing.Size(23, 22);
            this.btnEditColumnizer.TabIndex = 13;
            this.btnEditColumnizer.UseVisualStyleBackColor = true;
            this.btnEditColumnizer.Click += new System.EventHandler(this.BtnEditColumnizerClick);
            // 
            // cmbColumnizer
            // 
            this.cmbColumnizer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbColumnizer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColumnizer.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbColumnizer.FormattingEnabled = true;
            this.cmbColumnizer.Location = new System.Drawing.Point(0, 214);
            this.cmbColumnizer.Name = "cmbColumnizer";
            this.cmbColumnizer.Size = new System.Drawing.Size(313, 21);
            this.cmbColumnizer.Sorted = true;
            this.cmbColumnizer.TabIndex = 10;
            // 
            // lblColumnizer
            // 
            this.lblColumnizer.AutoSize = true;
            this.lblColumnizer.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblColumnizer.Location = new System.Drawing.Point(0, 198);
            this.lblColumnizer.Name = "lblColumnizer";
            this.lblColumnizer.Size = new System.Drawing.Size(61, 13);
            this.lblColumnizer.TabIndex = 9;
            this.lblColumnizer.Text = "&Columnizer:";
            // 
            // cmbEncoding
            // 
            this.cmbEncoding.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbEncoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEncoding.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbEncoding.FormattingEnabled = true;
            this.cmbEncoding.Location = new System.Drawing.Point(0, 260);
            this.cmbEncoding.Name = "cmbEncoding";
            this.cmbEncoding.Size = new System.Drawing.Size(400, 21);
            this.cmbEncoding.Sorted = true;
            this.cmbEncoding.TabIndex = 15;
            // 
            // lblEncoding
            // 
            this.lblEncoding.AutoSize = true;
            this.lblEncoding.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEncoding.Location = new System.Drawing.Point(0, 244);
            this.lblEncoding.Name = "lblEncoding";
            this.lblEncoding.Size = new System.Drawing.Size(55, 13);
            this.lblEncoding.TabIndex = 14;
            this.lblEncoding.Text = "&Encoding:";
            // 
            // txtUrl
            // 
            this.txtUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUrl.Location = new System.Drawing.Point(0, 16);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(400, 20);
            this.txtUrl.TabIndex = 1;
            // 
            // chkAuthentication
            // 
            this.chkAuthentication.AutoSize = true;
            this.chkAuthentication.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkAuthentication.Location = new System.Drawing.Point(0, 42);
            this.chkAuthentication.Name = "chkAuthentication";
            this.chkAuthentication.Size = new System.Drawing.Size(172, 18);
            this.chkAuthentication.TabIndex = 2;
            this.chkAuthentication.Text = "Requires basic &authentication";
            this.chkAuthentication.UseVisualStyleBackColor = true;
            this.chkAuthentication.CheckedChanged += new System.EventHandler(this.ChkAuthenticationCheckedChanged);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Enabled = false;
            this.lblUsername.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUsername.Location = new System.Drawing.Point(16, 69);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(58, 13);
            this.lblUsername.TabIndex = 3;
            this.lblUsername.Text = "Username:";
            // 
            // txtUsername
            // 
            this.txtUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsername.Enabled = false;
            this.txtUsername.Location = new System.Drawing.Point(16, 85);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(384, 20);
            this.txtUsername.TabIndex = 4;
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Enabled = false;
            this.txtPassword.Location = new System.Drawing.Point(16, 124);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(384, 20);
            this.txtPassword.TabIndex = 6;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Enabled = false;
            this.lblPassword.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPassword.Location = new System.Drawing.Point(16, 108);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 5;
            this.lblPassword.Text = "Password:";
            // 
            // lblReload
            // 
            this.lblReload.AutoSize = true;
            this.lblReload.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblReload.Location = new System.Drawing.Point(0, 153);
            this.lblReload.Name = "lblReload";
            this.lblReload.Size = new System.Drawing.Size(117, 13);
            this.lblReload.TabIndex = 7;
            this.lblReload.Text = "&Polling time in seconds:";
            // 
            // nudPollingTime
            // 
            this.nudPollingTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudPollingTime.Location = new System.Drawing.Point(0, 169);
            this.nudPollingTime.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudPollingTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPollingTime.Name = "nudPollingTime";
            this.nudPollingTime.Size = new System.Drawing.Size(400, 20);
            this.nudPollingTime.TabIndex = 8;
            this.nudPollingTime.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // CustomHttpReceiverSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nudPollingTime);
            this.Controls.Add(this.lblReload);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.chkAuthentication);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.cmbEncoding);
            this.Controls.Add(this.lblEncoding);
            this.Controls.Add(this.btnRemoveColumnizer);
            this.Controls.Add(this.btnAddColumnizer);
            this.Controls.Add(this.btnEditColumnizer);
            this.Controls.Add(this.cmbColumnizer);
            this.Controls.Add(this.lblColumnizer);
            this.Controls.Add(this.lblUrl);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MinimumSize = new System.Drawing.Size(0, 300);
            this.Name = "CustomHttpReceiverSettings";
            this.Size = new System.Drawing.Size(400, 300);
            ((System.ComponentModel.ISupportInitialize)(this.nudPollingTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label lblUrl;
    private System.Windows.Forms.Button btnRemoveColumnizer;
    private System.Windows.Forms.Button btnAddColumnizer;
    private System.Windows.Forms.Button btnEditColumnizer;
    private System.Windows.Forms.ComboBox cmbColumnizer;
    private System.Windows.Forms.Label lblColumnizer;
    private System.Windows.Forms.ComboBox cmbEncoding;
    private System.Windows.Forms.Label lblEncoding;
    private System.Windows.Forms.TextBox txtUrl;
    private System.Windows.Forms.CheckBox chkAuthentication;
    private System.Windows.Forms.Label lblUsername;
    private System.Windows.Forms.TextBox txtUsername;
    private System.Windows.Forms.TextBox txtPassword;
    private System.Windows.Forms.Label lblPassword;
    private System.Windows.Forms.Label lblReload;
    private System.Windows.Forms.NumericUpDown nudPollingTime;
  }
}
