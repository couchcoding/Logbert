namespace Couchcoding.Logbert.Controls.OptionPanels
{
  partial class OptionPanelScriptEditor
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
      this.tblLayout = new System.Windows.Forms.TableLayoutPanel();
      this.cmbFont = new System.Windows.Forms.ComboBox();
      this.lblFont = new System.Windows.Forms.Label();
      this.cmbFontSize = new System.Windows.Forms.ComboBox();
      this.lblFontSize = new System.Windows.Forms.Label();
      this.lstElements = new System.Windows.Forms.ListBox();
      this.lblElement = new System.Windows.Forms.Label();
      this.lblForeColor = new System.Windows.Forms.Label();
      this.clrDrpDwnFore = new Couchcoding.Logbert.Controls.ColorPickerCtrl();
      this.clrDrpDwnBack = new Couchcoding.Logbert.Controls.ColorPickerCtrl();
      this.lblBackColor = new System.Windows.Forms.Label();
      this.lblFontStyle = new System.Windows.Forms.Label();
      this.cmbFontStyle = new System.Windows.Forms.ComboBox();
      this.lblTabSize = new System.Windows.Forms.Label();
      this.nudTabSize = new System.Windows.Forms.NumericUpDown();
      this.chkInsertSpaceForTabs = new System.Windows.Forms.CheckBox();
      this.chkWordWrap = new System.Windows.Forms.CheckBox();
      this.chkHighlightCurrentLine = new System.Windows.Forms.CheckBox();
      this.tblLayout.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudTabSize)).BeginInit();
      this.SuspendLayout();
      // 
      // tblLayout
      // 
      this.tblLayout.ColumnCount = 2;
      this.tblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tblLayout.Controls.Add(this.cmbFont, 0, 1);
      this.tblLayout.Controls.Add(this.lblFont, 0, 0);
      this.tblLayout.Controls.Add(this.cmbFontSize, 1, 1);
      this.tblLayout.Controls.Add(this.lblFontSize, 1, 0);
      this.tblLayout.Dock = System.Windows.Forms.DockStyle.Top;
      this.tblLayout.Location = new System.Drawing.Point(0, 0);
      this.tblLayout.Name = "tblLayout";
      this.tblLayout.RowCount = 2;
      this.tblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tblLayout.Size = new System.Drawing.Size(480, 48);
      this.tblLayout.TabIndex = 0;
      // 
      // cmbFont
      // 
      this.cmbFont.Dock = System.Windows.Forms.DockStyle.Fill;
      this.cmbFont.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbFont.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.cmbFont.FormattingEnabled = true;
      this.cmbFont.Location = new System.Drawing.Point(3, 22);
      this.cmbFont.Name = "cmbFont";
      this.cmbFont.Size = new System.Drawing.Size(393, 21);
      this.cmbFont.TabIndex = 2;
      // 
      // lblFont
      // 
      this.lblFont.AutoSize = true;
      this.lblFont.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.lblFont.Location = new System.Drawing.Point(3, 6);
      this.lblFont.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      this.lblFont.Name = "lblFont";
      this.lblFont.Size = new System.Drawing.Size(31, 13);
      this.lblFont.TabIndex = 0;
      this.lblFont.Text = "Font:";
      // 
      // cmbFontSize
      // 
      this.cmbFontSize.Dock = System.Windows.Forms.DockStyle.Fill;
      this.cmbFontSize.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.cmbFontSize.FormattingEnabled = true;
      this.cmbFontSize.Items.AddRange(new object[] {
            "6",
            "8",
            "10",
            "12",
            "14",
            "16",
            "18",
            "20",
            "22",
            "24"});
      this.cmbFontSize.Location = new System.Drawing.Point(402, 22);
      this.cmbFontSize.MinimumSize = new System.Drawing.Size(40, 0);
      this.cmbFontSize.Name = "cmbFontSize";
      this.cmbFontSize.Size = new System.Drawing.Size(75, 21);
      this.cmbFontSize.TabIndex = 3;
      this.cmbFontSize.Validating += new System.ComponentModel.CancelEventHandler(this.CmbFontSizeValidating);
      // 
      // lblFontSize
      // 
      this.lblFontSize.AutoSize = true;
      this.lblFontSize.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.lblFontSize.Location = new System.Drawing.Point(402, 6);
      this.lblFontSize.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      this.lblFontSize.Name = "lblFontSize";
      this.lblFontSize.Size = new System.Drawing.Size(30, 13);
      this.lblFontSize.TabIndex = 1;
      this.lblFontSize.Text = "Size:";
      // 
      // lstElements
      // 
      this.lstElements.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lstElements.FormattingEnabled = true;
      this.lstElements.IntegralHeight = false;
      this.lstElements.Location = new System.Drawing.Point(3, 67);
      this.lstElements.Name = "lstElements";
      this.lstElements.Size = new System.Drawing.Size(318, 130);
      this.lstElements.TabIndex = 3;
      this.lstElements.SelectedIndexChanged += new System.EventHandler(this.LstElementsSelectedIndexChanged);
      // 
      // lblElement
      // 
      this.lblElement.AutoSize = true;
      this.lblElement.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.lblElement.Location = new System.Drawing.Point(3, 51);
      this.lblElement.Name = "lblElement";
      this.lblElement.Size = new System.Drawing.Size(48, 13);
      this.lblElement.TabIndex = 1;
      this.lblElement.Text = "Element:";
      // 
      // lblForeColor
      // 
      this.lblForeColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.lblForeColor.AutoSize = true;
      this.lblForeColor.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.lblForeColor.Location = new System.Drawing.Point(327, 51);
      this.lblForeColor.Name = "lblForeColor";
      this.lblForeColor.Size = new System.Drawing.Size(54, 13);
      this.lblForeColor.TabIndex = 2;
      this.lblForeColor.Text = "Forecolor:";
      // 
      // clrDrpDwnFore
      // 
      this.clrDrpDwnFore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.clrDrpDwnFore.Location = new System.Drawing.Point(327, 67);
      this.clrDrpDwnFore.Name = "clrDrpDwnFore";
      this.clrDrpDwnFore.SelectedValue = System.Drawing.Color.White;
      this.clrDrpDwnFore.Size = new System.Drawing.Size(150, 23);
      this.clrDrpDwnFore.TabIndex = 4;
      this.clrDrpDwnFore.OnValueChanged += new System.EventHandler<System.EventArgs>(this.clrDrpDwnForeOnValueChanged);
      // 
      // clrDrpDwnBack
      // 
      this.clrDrpDwnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.clrDrpDwnBack.Location = new System.Drawing.Point(327, 115);
      this.clrDrpDwnBack.Name = "clrDrpDwnBack";
      this.clrDrpDwnBack.SelectedValue = System.Drawing.Color.White;
      this.clrDrpDwnBack.Size = new System.Drawing.Size(150, 23);
      this.clrDrpDwnBack.TabIndex = 6;
      this.clrDrpDwnBack.OnValueChanged += new System.EventHandler<System.EventArgs>(this.clrDrpDwnBackOnValueChanged);
      // 
      // lblBackColor
      // 
      this.lblBackColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.lblBackColor.AutoSize = true;
      this.lblBackColor.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.lblBackColor.Location = new System.Drawing.Point(327, 99);
      this.lblBackColor.Name = "lblBackColor";
      this.lblBackColor.Size = new System.Drawing.Size(58, 13);
      this.lblBackColor.TabIndex = 5;
      this.lblBackColor.Text = "Backcolor:";
      // 
      // lblFontStyle
      // 
      this.lblFontStyle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.lblFontStyle.AutoSize = true;
      this.lblFontStyle.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.lblFontStyle.Location = new System.Drawing.Point(327, 147);
      this.lblFontStyle.Name = "lblFontStyle";
      this.lblFontStyle.Size = new System.Drawing.Size(33, 13);
      this.lblFontStyle.TabIndex = 7;
      this.lblFontStyle.Text = "Style:";
      // 
      // cmbFontStyle
      // 
      this.cmbFontStyle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.cmbFontStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbFontStyle.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.cmbFontStyle.FormattingEnabled = true;
      this.cmbFontStyle.Items.AddRange(new object[] {
            "Regular",
            "Bold"});
      this.cmbFontStyle.Location = new System.Drawing.Point(327, 164);
      this.cmbFontStyle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
      this.cmbFontStyle.MinimumSize = new System.Drawing.Size(40, 0);
      this.cmbFontStyle.Name = "cmbFontStyle";
      this.cmbFontStyle.Size = new System.Drawing.Size(150, 21);
      this.cmbFontStyle.TabIndex = 8;
      this.cmbFontStyle.SelectedIndexChanged += new System.EventHandler(this.CmbFontStyleSelectedIndexChanged);
      // 
      // lblTabSize
      // 
      this.lblTabSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.lblTabSize.AutoSize = true;
      this.lblTabSize.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.lblTabSize.Location = new System.Drawing.Point(3, 206);
      this.lblTabSize.Name = "lblTabSize";
      this.lblTabSize.Size = new System.Drawing.Size(52, 13);
      this.lblTabSize.TabIndex = 9;
      this.lblTabSize.Text = "Tab Size:";
      // 
      // nudTabSize
      // 
      this.nudTabSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.nudTabSize.Location = new System.Drawing.Point(3, 222);
      this.nudTabSize.Name = "nudTabSize";
      this.nudTabSize.Size = new System.Drawing.Size(120, 20);
      this.nudTabSize.TabIndex = 10;
      this.nudTabSize.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
      // 
      // chkInsertSpaceForTabs
      // 
      this.chkInsertSpaceForTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.chkInsertSpaceForTabs.AutoSize = true;
      this.chkInsertSpaceForTabs.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.chkInsertSpaceForTabs.Location = new System.Drawing.Point(129, 222);
      this.chkInsertSpaceForTabs.Name = "chkInsertSpaceForTabs";
      this.chkInsertSpaceForTabs.Size = new System.Drawing.Size(133, 18);
      this.chkInsertSpaceForTabs.TabIndex = 11;
      this.chkInsertSpaceForTabs.Text = "Insert spaces for tabs";
      this.chkInsertSpaceForTabs.UseVisualStyleBackColor = true;
      // 
      // chkWordWrap
      // 
      this.chkWordWrap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.chkWordWrap.AutoSize = true;
      this.chkWordWrap.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.chkWordWrap.Location = new System.Drawing.Point(3, 253);
      this.chkWordWrap.Name = "chkWordWrap";
      this.chkWordWrap.Size = new System.Drawing.Size(84, 18);
      this.chkWordWrap.TabIndex = 12;
      this.chkWordWrap.Text = "Word wrap";
      this.chkWordWrap.UseVisualStyleBackColor = true;
      // 
      // chkHighlightCurrentLine
      // 
      this.chkHighlightCurrentLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.chkHighlightCurrentLine.AutoSize = true;
      this.chkHighlightCurrentLine.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.chkHighlightCurrentLine.Location = new System.Drawing.Point(3, 276);
      this.chkHighlightCurrentLine.Name = "chkHighlightCurrentLine";
      this.chkHighlightCurrentLine.Size = new System.Drawing.Size(128, 18);
      this.chkHighlightCurrentLine.TabIndex = 13;
      this.chkHighlightCurrentLine.Text = "Highlight current line";
      this.chkHighlightCurrentLine.UseVisualStyleBackColor = true;
      // 
      // OptionPanelScriptEditor
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.chkHighlightCurrentLine);
      this.Controls.Add(this.chkWordWrap);
      this.Controls.Add(this.chkInsertSpaceForTabs);
      this.Controls.Add(this.nudTabSize);
      this.Controls.Add(this.lblTabSize);
      this.Controls.Add(this.cmbFontStyle);
      this.Controls.Add(this.lblFontStyle);
      this.Controls.Add(this.clrDrpDwnBack);
      this.Controls.Add(this.lblBackColor);
      this.Controls.Add(this.clrDrpDwnFore);
      this.Controls.Add(this.lblForeColor);
      this.Controls.Add(this.lblElement);
      this.Controls.Add(this.lstElements);
      this.Controls.Add(this.tblLayout);
      this.MinimumSize = new System.Drawing.Size(320, 300);
      this.Name = "OptionPanelScriptEditor";
      this.Size = new System.Drawing.Size(480, 300);
      this.tblLayout.ResumeLayout(false);
      this.tblLayout.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudTabSize)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tblLayout;
    private System.Windows.Forms.ComboBox cmbFontSize;
    private System.Windows.Forms.Label lblFontSize;
    private System.Windows.Forms.ComboBox cmbFont;
    private System.Windows.Forms.Label lblFont;
    private System.Windows.Forms.ListBox lstElements;
    private System.Windows.Forms.Label lblElement;
    private System.Windows.Forms.Label lblForeColor;
    private ColorPickerCtrl clrDrpDwnFore;
    private ColorPickerCtrl clrDrpDwnBack;
    private System.Windows.Forms.Label lblBackColor;
    private System.Windows.Forms.Label lblFontStyle;
    private System.Windows.Forms.ComboBox cmbFontStyle;
    private System.Windows.Forms.Label lblTabSize;
    private System.Windows.Forms.NumericUpDown nudTabSize;
    private System.Windows.Forms.CheckBox chkInsertSpaceForTabs;
    private System.Windows.Forms.CheckBox chkWordWrap;
    private System.Windows.Forms.CheckBox chkHighlightCurrentLine;

  }
}
