namespace Com.Couchcoding.Logbert.Dialogs
{
  partial class FrmAbout
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
      System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new System.Windows.Forms.ListViewItem.ListViewSubItem[] {
            new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "DockPanel Suite"),
            new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "The MIT License", System.Drawing.SystemColors.WindowText, System.Drawing.SystemColors.Window, new System.Drawing.Font("Segoe UI", 9F)),
            new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "http://dockpanelsuite.com/", System.Drawing.SystemColors.HotTrack, System.Drawing.SystemColors.Window, new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline))}, -1);
      System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new System.Windows.Forms.ListViewItem.ListViewSubItem[] {
            new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "ScintillaNET"),
            new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "The MIT License", System.Drawing.SystemColors.WindowText, System.Drawing.SystemColors.Window, new System.Drawing.Font("Segoe UI", 9F)),
            new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "https://github.com/jacobslusser/ScintillaNET", System.Drawing.SystemColors.HotTrack, System.Drawing.SystemColors.Window, new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0))))}, -1);
      System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem(new System.Windows.Forms.ListViewItem.ListViewSubItem[] {
            new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "MoonSharp"),
            new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "Simplified BSD License (BSD)"),
            new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "http://www.moonsharp.org", System.Drawing.SystemColors.HotTrack, System.Drawing.SystemColors.Window, new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0))))}, -1);
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAbout));
      this.tcAbout = new System.Windows.Forms.TabControl();
      this.tpAbout = new System.Windows.Forms.TabPage();
      this.lblVersion = new System.Windows.Forms.Label();
      this.lblCopyright = new System.Windows.Forms.Label();
      this.tpComponents = new System.Windows.Forms.TabPage();
      this.lstComponents = new Com.Couchcoding.GuiLibrary.Controls.ListViewEx();
      this.clmComponent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.clmLicense = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.clmWebsite = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.tpLicense = new System.Windows.Forms.TabPage();
      this.linkLabelEx1 = new Com.Couchcoding.GuiLibrary.Controls.LinkLabelEx();
      this.txtLicense = new System.Windows.Forms.TextBox();
      this.btnClose = new System.Windows.Forms.Button();
      this.tcAbout.SuspendLayout();
      this.tpAbout.SuspendLayout();
      this.tpComponents.SuspendLayout();
      this.tpLicense.SuspendLayout();
      this.SuspendLayout();
      // 
      // tcAbout
      // 
      this.tcAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tcAbout.Controls.Add(this.tpAbout);
      this.tcAbout.Controls.Add(this.tpComponents);
      this.tcAbout.Controls.Add(this.tpLicense);
      this.tcAbout.Location = new System.Drawing.Point(8, 8);
      this.tcAbout.Name = "tcAbout";
      this.tcAbout.SelectedIndex = 0;
      this.tcAbout.Size = new System.Drawing.Size(608, 307);
      this.tcAbout.TabIndex = 0;
      // 
      // tpAbout
      // 
      this.tpAbout.BackColor = System.Drawing.Color.White;
      this.tpAbout.BackgroundImage = global::Com.Couchcoding.Logbert.Properties.Resources.logbert_about;
      this.tpAbout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.tpAbout.Controls.Add(this.lblVersion);
      this.tpAbout.Controls.Add(this.lblCopyright);
      this.tpAbout.Location = new System.Drawing.Point(4, 24);
      this.tpAbout.Name = "tpAbout";
      this.tpAbout.Padding = new System.Windows.Forms.Padding(3);
      this.tpAbout.Size = new System.Drawing.Size(600, 279);
      this.tpAbout.TabIndex = 0;
      this.tpAbout.Text = "About";
      // 
      // lblVersion
      // 
      this.lblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.lblVersion.AutoSize = true;
      this.lblVersion.Location = new System.Drawing.Point(7, 240);
      this.lblVersion.Name = "lblVersion";
      this.lblVersion.Size = new System.Drawing.Size(0, 15);
      this.lblVersion.TabIndex = 0;
      // 
      // lblCopyright
      // 
      this.lblCopyright.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.lblCopyright.AutoSize = true;
      this.lblCopyright.Location = new System.Drawing.Point(7, 258);
      this.lblCopyright.Name = "lblCopyright";
      this.lblCopyright.Size = new System.Drawing.Size(0, 15);
      this.lblCopyright.TabIndex = 1;
      // 
      // tpComponents
      // 
      this.tpComponents.Controls.Add(this.lstComponents);
      this.tpComponents.Location = new System.Drawing.Point(4, 24);
      this.tpComponents.Name = "tpComponents";
      this.tpComponents.Padding = new System.Windows.Forms.Padding(3);
      this.tpComponents.Size = new System.Drawing.Size(600, 279);
      this.tpComponents.TabIndex = 1;
      this.tpComponents.Text = "Components";
      this.tpComponents.UseVisualStyleBackColor = true;
      // 
      // lstComponents
      // 
      this.lstComponents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lstComponents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmComponent,
            this.clmLicense,
            this.clmWebsite});
      this.lstComponents.FullRowSelect = true;
      this.lstComponents.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
      listViewItem1.UseItemStyleForSubItems = false;
      listViewItem2.UseItemStyleForSubItems = false;
      listViewItem3.UseItemStyleForSubItems = false;
      this.lstComponents.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3});
      this.lstComponents.LabelWrap = false;
      this.lstComponents.Location = new System.Drawing.Point(6, 6);
      this.lstComponents.Name = "lstComponents";
      this.lstComponents.Size = new System.Drawing.Size(588, 267);
      this.lstComponents.TabIndex = 0;
      this.lstComponents.UseCompatibleStateImageBehavior = false;
      this.lstComponents.View = System.Windows.Forms.View.Details;
      this.lstComponents.DoubleClick += new System.EventHandler(this.LstComponentsDoubleClick);
      // 
      // clmComponent
      // 
      this.clmComponent.Text = "Component";
      this.clmComponent.Width = 122;
      // 
      // clmLicense
      // 
      this.clmLicense.Text = "License";
      this.clmLicense.Width = 169;
      // 
      // clmWebsite
      // 
      this.clmWebsite.Text = "Website";
      this.clmWebsite.Width = 293;
      // 
      // tpLicense
      // 
      this.tpLicense.Controls.Add(this.linkLabelEx1);
      this.tpLicense.Controls.Add(this.txtLicense);
      this.tpLicense.Location = new System.Drawing.Point(4, 24);
      this.tpLicense.Name = "tpLicense";
      this.tpLicense.Padding = new System.Windows.Forms.Padding(3);
      this.tpLicense.Size = new System.Drawing.Size(600, 279);
      this.tpLicense.TabIndex = 2;
      this.tpLicense.Text = "License";
      this.tpLicense.UseVisualStyleBackColor = true;
      // 
      // linkLabelEx1
      // 
      this.linkLabelEx1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.linkLabelEx1.AutoSize = true;
      this.linkLabelEx1.Location = new System.Drawing.Point(492, 261);
      this.linkLabelEx1.Name = "linkLabelEx1";
      this.linkLabelEx1.Size = new System.Drawing.Size(102, 15);
      this.linkLabelEx1.TabIndex = 1;
      this.linkLabelEx1.TabStop = true;
      this.linkLabelEx1.Text = "Copy to clipboard";
      this.linkLabelEx1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelEx1LinkClicked);
      // 
      // txtLicense
      // 
      this.txtLicense.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtLicense.BackColor = System.Drawing.SystemColors.Window;
      this.txtLicense.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtLicense.Location = new System.Drawing.Point(6, 6);
      this.txtLicense.Multiline = true;
      this.txtLicense.Name = "txtLicense";
      this.txtLicense.ReadOnly = true;
      this.txtLicense.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.txtLicense.Size = new System.Drawing.Size(588, 252);
      this.txtLicense.TabIndex = 0;
      this.txtLicense.Text = resources.GetString("txtLicense.Text");
      this.txtLicense.WordWrap = false;
      // 
      // btnClose
      // 
      this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.btnClose.Location = new System.Drawing.Point(537, 330);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new System.Drawing.Size(75, 23);
      this.btnClose.TabIndex = 1;
      this.btnClose.Text = "Close";
      this.btnClose.UseVisualStyleBackColor = true;
      // 
      // FrmAbout
      // 
      this.AcceptButton = this.btnClose;
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.CancelButton = this.btnClose;
      this.ClientSize = new System.Drawing.Size(624, 361);
      this.Controls.Add(this.btnClose);
      this.Controls.Add(this.tcAbout);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Location = new System.Drawing.Point(0, 0);
      this.Name = "FrmAbout";
      this.Padding = new System.Windows.Forms.Padding(5);
      this.ShowHeaderArea = false;
      this.Text = "About";
      this.tcAbout.ResumeLayout(false);
      this.tpAbout.ResumeLayout(false);
      this.tpAbout.PerformLayout();
      this.tpComponents.ResumeLayout(false);
      this.tpLicense.ResumeLayout(false);
      this.tpLicense.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TabControl tcAbout;
    private System.Windows.Forms.TabPage tpAbout;
    private System.Windows.Forms.TabPage tpComponents;
    private System.Windows.Forms.Label lblVersion;
    private System.Windows.Forms.Label lblCopyright;
    private System.Windows.Forms.TabPage tpLicense;
    private System.Windows.Forms.Button btnClose;
    private System.Windows.Forms.TextBox txtLicense;
    private GuiLibrary.Controls.LinkLabelEx linkLabelEx1;
    private GuiLibrary.Controls.ListViewEx lstComponents;
    private System.Windows.Forms.ColumnHeader clmComponent;
    private System.Windows.Forms.ColumnHeader clmLicense;
    private System.Windows.Forms.ColumnHeader clmWebsite;
  }
}