namespace Couchcoding.Logbert.Receiver.NlogTcpReceiver
{
  partial class CustomTcpReceiverSettings
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
            this.cmbNetworkInterface = new System.Windows.Forms.ComboBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.nudPort = new System.Windows.Forms.NumericUpDown();
            this.nfoPanel = new Couchcoding.Logbert.Gui.Controls.InfoPanel();
            this.btnRemoveColumnizer = new System.Windows.Forms.Button();
            this.btnAddColumnizer = new System.Windows.Forms.Button();
            this.btnEditColumnizer = new System.Windows.Forms.Button();
            this.cmbColumnizer = new System.Windows.Forms.ComboBox();
            this.lblColumnizer = new System.Windows.Forms.Label();
            this.cmbEncoding = new System.Windows.Forms.ComboBox();
            this.lblEncoding = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNetworkInterface
            // 
            this.lblNetworkInterface.AutoSize = true;
            this.lblNetworkInterface.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblNetworkInterface.Location = new System.Drawing.Point(0, 0);
            this.lblNetworkInterface.Name = "lblNetworkInterface";
            this.lblNetworkInterface.Size = new System.Drawing.Size(95, 13);
            this.lblNetworkInterface.TabIndex = 0;
            this.lblNetworkInterface.Text = "&Network Interface:";
            // 
            // cmbNetworkInterface
            // 
            this.cmbNetworkInterface.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbNetworkInterface.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNetworkInterface.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbNetworkInterface.FormattingEnabled = true;
            this.cmbNetworkInterface.Location = new System.Drawing.Point(0, 16);
            this.cmbNetworkInterface.Name = "cmbNetworkInterface";
            this.cmbNetworkInterface.Size = new System.Drawing.Size(400, 21);
            this.cmbNetworkInterface.TabIndex = 1;
            this.cmbNetworkInterface.SelectedIndexChanged += new System.EventHandler(this.CmbNetworkInterfaceSelectedIndexChanged);
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPort.Location = new System.Drawing.Point(0, 116);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(29, 13);
            this.lblPort.TabIndex = 3;
            this.lblPort.Text = "&Port:";
            // 
            // nudPort
            // 
            this.nudPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudPort.Location = new System.Drawing.Point(0, 132);
            this.nudPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudPort.Name = "nudPort";
            this.nudPort.Size = new System.Drawing.Size(400, 20);
            this.nudPort.TabIndex = 4;
            this.nudPort.Value = new decimal(new int[] {
            7072,
            0,
            0,
            0});
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
            this.nfoPanel.Size = new System.Drawing.Size(400, 64);
            this.nfoPanel.TabIndex = 2;
            this.nfoPanel.TextPadding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.nfoPanel.Title = "";
            // 
            // btnRemoveColumnizer
            // 
            this.btnRemoveColumnizer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveColumnizer.Image = global::Couchcoding.Logbert.Properties.Resources.Remove_16xMD;
            this.btnRemoveColumnizer.Location = new System.Drawing.Point(348, 176);
            this.btnRemoveColumnizer.Name = "btnRemoveColumnizer";
            this.btnRemoveColumnizer.Size = new System.Drawing.Size(23, 22);
            this.btnRemoveColumnizer.TabIndex = 8;
            this.btnRemoveColumnizer.UseVisualStyleBackColor = true;
            this.btnRemoveColumnizer.Click += new System.EventHandler(this.BtnRemoveColumnizerClick);
            // 
            // btnAddColumnizer
            // 
            this.btnAddColumnizer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddColumnizer.Image = global::Couchcoding.Logbert.Properties.Resources.action_add_16xMD;
            this.btnAddColumnizer.Location = new System.Drawing.Point(319, 176);
            this.btnAddColumnizer.Name = "btnAddColumnizer";
            this.btnAddColumnizer.Size = new System.Drawing.Size(23, 22);
            this.btnAddColumnizer.TabIndex = 7;
            this.btnAddColumnizer.UseVisualStyleBackColor = true;
            this.btnAddColumnizer.Click += new System.EventHandler(this.BtnAddColumnizerClick);
            // 
            // btnEditColumnizer
            // 
            this.btnEditColumnizer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditColumnizer.Enabled = false;
            this.btnEditColumnizer.Image = global::Couchcoding.Logbert.Properties.Resources.PencilAngled_16xMD_color;
            this.btnEditColumnizer.Location = new System.Drawing.Point(377, 176);
            this.btnEditColumnizer.Name = "btnEditColumnizer";
            this.btnEditColumnizer.Size = new System.Drawing.Size(23, 22);
            this.btnEditColumnizer.TabIndex = 9;
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
            this.cmbColumnizer.Location = new System.Drawing.Point(0, 177);
            this.cmbColumnizer.Name = "cmbColumnizer";
            this.cmbColumnizer.Size = new System.Drawing.Size(313, 21);
            this.cmbColumnizer.Sorted = true;
            this.cmbColumnizer.TabIndex = 6;
            // 
            // lblColumnizer
            // 
            this.lblColumnizer.AutoSize = true;
            this.lblColumnizer.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblColumnizer.Location = new System.Drawing.Point(0, 161);
            this.lblColumnizer.Name = "lblColumnizer";
            this.lblColumnizer.Size = new System.Drawing.Size(61, 13);
            this.lblColumnizer.TabIndex = 5;
            this.lblColumnizer.Text = "&Columnizer:";
            // 
            // cmbEncoding
            // 
            this.cmbEncoding.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbEncoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEncoding.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbEncoding.FormattingEnabled = true;
            this.cmbEncoding.Location = new System.Drawing.Point(0, 223);
            this.cmbEncoding.Name = "cmbEncoding";
            this.cmbEncoding.Size = new System.Drawing.Size(400, 21);
            this.cmbEncoding.Sorted = true;
            this.cmbEncoding.TabIndex = 11;
            // 
            // lblEncoding
            // 
            this.lblEncoding.AutoSize = true;
            this.lblEncoding.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEncoding.Location = new System.Drawing.Point(0, 207);
            this.lblEncoding.Name = "lblEncoding";
            this.lblEncoding.Size = new System.Drawing.Size(55, 13);
            this.lblEncoding.TabIndex = 10;
            this.lblEncoding.Text = "&Encoding:";
            // 
            // CustomTcpReceiverSettings
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
            this.Controls.Add(this.nfoPanel);
            this.Controls.Add(this.nudPort);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.cmbNetworkInterface);
            this.Controls.Add(this.lblNetworkInterface);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MinimumSize = new System.Drawing.Size(0, 246);
            this.Name = "CustomTcpReceiverSettings";
            this.Size = new System.Drawing.Size(400, 300);
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label lblNetworkInterface;
    private System.Windows.Forms.ComboBox cmbNetworkInterface;
    private System.Windows.Forms.Label lblPort;
    private System.Windows.Forms.NumericUpDown nudPort;
    private Gui.Controls.InfoPanel nfoPanel;
    private System.Windows.Forms.Button btnRemoveColumnizer;
    private System.Windows.Forms.Button btnAddColumnizer;
    private System.Windows.Forms.Button btnEditColumnizer;
    private System.Windows.Forms.ComboBox cmbColumnizer;
    private System.Windows.Forms.Label lblColumnizer;
    private System.Windows.Forms.ComboBox cmbEncoding;
    private System.Windows.Forms.Label lblEncoding;
  }
}
