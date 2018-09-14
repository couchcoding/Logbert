namespace Couchcoding.Logbert.Dialogs
{
  partial class FrmLogSearch
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogSearch));
      this.btnFindPrevious = new System.Windows.Forms.Button();
      this.btnFindNext = new System.Windows.Forms.Button();
      this.grpOptions = new Couchcoding.Logbert.Gui.Controls.GroupBoxEx();
      this.cmbRegexWildcard = new System.Windows.Forms.ComboBox();
      this.chkUse = new System.Windows.Forms.CheckBox();
      this.chkMatchWholeWord = new System.Windows.Forms.CheckBox();
      this.chkMatchCase = new System.Windows.Forms.CheckBox();
      this.cmbLookIn = new System.Windows.Forms.ComboBox();
      this.lblLookIn = new System.Windows.Forms.Label();
      this.cmbFindWhat = new System.Windows.Forms.ComboBox();
      this.lblFindWhat = new System.Windows.Forms.Label();
      this.grpOptions.SuspendLayout();
      this.SuspendLayout();
      // 
      // btnFindPrevious
      // 
      this.btnFindPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnFindPrevious.Enabled = false;
      this.btnFindPrevious.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.btnFindPrevious.Location = new System.Drawing.Point(116, 245);
      this.btnFindPrevious.Name = "btnFindPrevious";
      this.btnFindPrevious.Size = new System.Drawing.Size(85, 23);
      this.btnFindPrevious.TabIndex = 12;
      this.btnFindPrevious.Text = "Find &Previous";
      this.btnFindPrevious.UseVisualStyleBackColor = true;
      this.btnFindPrevious.Click += new System.EventHandler(this.BtnFindPreviousClick);
      // 
      // btnFindNext
      // 
      this.btnFindNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnFindNext.Enabled = false;
      this.btnFindNext.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.btnFindNext.Location = new System.Drawing.Point(207, 245);
      this.btnFindNext.Name = "btnFindNext";
      this.btnFindNext.Size = new System.Drawing.Size(85, 23);
      this.btnFindNext.TabIndex = 13;
      this.btnFindNext.Text = "&Find Next";
      this.btnFindNext.UseVisualStyleBackColor = true;
      this.btnFindNext.Click += new System.EventHandler(this.BtnFindNextClick);
      // 
      // grpOptions
      // 
      this.grpOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.grpOptions.Controls.Add(this.cmbRegexWildcard);
      this.grpOptions.Controls.Add(this.chkUse);
      this.grpOptions.Controls.Add(this.chkMatchWholeWord);
      this.grpOptions.Controls.Add(this.chkMatchCase);
      this.grpOptions.GroupImage = global::Couchcoding.Logbert.Properties.Resources.FindSymbol_6263;
      this.grpOptions.Location = new System.Drawing.Point(12, 104);
      this.grpOptions.Name = "grpOptions";
      this.grpOptions.Padding = new System.Windows.Forms.Padding(3, 20, 3, 3);
      this.grpOptions.SeperatorColor = System.Drawing.SystemColors.ControlDark;
      this.grpOptions.Size = new System.Drawing.Size(280, 135);
      this.grpOptions.TabIndex = 11;
      this.grpOptions.TabStop = false;
      this.grpOptions.Text = "Options";
      // 
      // cmbRegexWildcard
      // 
      this.cmbRegexWildcard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.cmbRegexWildcard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbRegexWildcard.Enabled = false;
      this.cmbRegexWildcard.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.cmbRegexWildcard.FormattingEnabled = true;
      this.cmbRegexWildcard.Items.AddRange(new object[] {
            "Regular Expression (.NET)",
            "Wildcard"});
      this.cmbRegexWildcard.Location = new System.Drawing.Point(22, 108);
      this.cmbRegexWildcard.Name = "cmbRegexWildcard";
      this.cmbRegexWildcard.Size = new System.Drawing.Size(258, 21);
      this.cmbRegexWildcard.TabIndex = 3;
      this.cmbRegexWildcard.SelectedIndexChanged += new System.EventHandler(this.CmbRegexWildcardSelectedIndexChanged);
      // 
      // chkUse
      // 
      this.chkUse.AutoSize = true;
      this.chkUse.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.chkUse.Location = new System.Drawing.Point(6, 84);
      this.chkUse.Name = "chkUse";
      this.chkUse.Size = new System.Drawing.Size(51, 18);
      this.chkUse.TabIndex = 2;
      this.chkUse.Text = "Us&e";
      this.chkUse.UseVisualStyleBackColor = true;
      this.chkUse.CheckedChanged += new System.EventHandler(this.ChkUseCheckedChanged);
      // 
      // chkMatchWholeWord
      // 
      this.chkMatchWholeWord.AutoSize = true;
      this.chkMatchWholeWord.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.chkMatchWholeWord.Location = new System.Drawing.Point(6, 60);
      this.chkMatchWholeWord.Name = "chkMatchWholeWord";
      this.chkMatchWholeWord.Size = new System.Drawing.Size(119, 18);
      this.chkMatchWholeWord.TabIndex = 1;
      this.chkMatchWholeWord.Text = "Match &whole word";
      this.chkMatchWholeWord.UseVisualStyleBackColor = true;
      this.chkMatchWholeWord.CheckedChanged += new System.EventHandler(this.ChkMatchWholeWordCheckedChanged);
      // 
      // chkMatchCase
      // 
      this.chkMatchCase.AutoSize = true;
      this.chkMatchCase.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.chkMatchCase.Location = new System.Drawing.Point(6, 36);
      this.chkMatchCase.Name = "chkMatchCase";
      this.chkMatchCase.Size = new System.Drawing.Size(88, 18);
      this.chkMatchCase.TabIndex = 0;
      this.chkMatchCase.Text = "Match &case";
      this.chkMatchCase.UseVisualStyleBackColor = true;
      this.chkMatchCase.CheckedChanged += new System.EventHandler(this.ChkMatchCaseCheckedChanged);
      // 
      // cmbLookIn
      // 
      this.cmbLookIn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.cmbLookIn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbLookIn.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.cmbLookIn.FormattingEnabled = true;
      this.cmbLookIn.Items.AddRange(new object[] {
            "Current Receiver",
            "All Receivers"});
      this.cmbLookIn.Location = new System.Drawing.Point(12, 71);
      this.cmbLookIn.Name = "cmbLookIn";
      this.cmbLookIn.Size = new System.Drawing.Size(280, 21);
      this.cmbLookIn.TabIndex = 10;
      // 
      // lblLookIn
      // 
      this.lblLookIn.AutoSize = true;
      this.lblLookIn.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.lblLookIn.Location = new System.Drawing.Point(12, 55);
      this.lblLookIn.Name = "lblLookIn";
      this.lblLookIn.Size = new System.Drawing.Size(45, 13);
      this.lblLookIn.TabIndex = 9;
      this.lblLookIn.Text = "&Look in:";
      // 
      // cmbFindWhat
      // 
      this.cmbFindWhat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.cmbFindWhat.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.cmbFindWhat.FormattingEnabled = true;
      this.cmbFindWhat.Location = new System.Drawing.Point(12, 25);
      this.cmbFindWhat.Name = "cmbFindWhat";
      this.cmbFindWhat.Size = new System.Drawing.Size(280, 21);
      this.cmbFindWhat.TabIndex = 8;
      this.cmbFindWhat.SelectedIndexChanged += new System.EventHandler(this.CmbFindWhatSelectedIndexChanged);
      this.cmbFindWhat.TextUpdate += new System.EventHandler(this.CmbFindWhatTextUpdate);
      // 
      // lblFindWhat
      // 
      this.lblFindWhat.AutoSize = true;
      this.lblFindWhat.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.lblFindWhat.Location = new System.Drawing.Point(12, 9);
      this.lblFindWhat.Name = "lblFindWhat";
      this.lblFindWhat.Size = new System.Drawing.Size(56, 13);
      this.lblFindWhat.TabIndex = 7;
      this.lblFindWhat.Text = "Fi&nd what:";
      // 
      // FrmLogSearch
      // 
      this.AcceptButton = this.btnFindNext;
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.ClientSize = new System.Drawing.Size(304, 282);
      this.Controls.Add(this.btnFindPrevious);
      this.Controls.Add(this.btnFindNext);
      this.Controls.Add(this.grpOptions);
      this.Controls.Add(this.cmbLookIn);
      this.Controls.Add(this.lblLookIn);
      this.Controls.Add(this.cmbFindWhat);
      this.Controls.Add(this.lblFindWhat);
      this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MinimumSize = new System.Drawing.Size(216, 320);
      this.Name = "FrmLogSearch";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.Text = "Find Message";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmLogSearchFormClosing);
      this.Load += new System.EventHandler(this.FrmLogSearchLoad);
      this.grpOptions.ResumeLayout(false);
      this.grpOptions.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnFindPrevious;
    private System.Windows.Forms.Button btnFindNext;
    private Gui.Controls.GroupBoxEx grpOptions;
    private System.Windows.Forms.ComboBox cmbRegexWildcard;
    private System.Windows.Forms.CheckBox chkUse;
    private System.Windows.Forms.CheckBox chkMatchWholeWord;
    private System.Windows.Forms.CheckBox chkMatchCase;
    private System.Windows.Forms.ComboBox cmbLookIn;
    private System.Windows.Forms.Label lblLookIn;
    private System.Windows.Forms.ComboBox cmbFindWhat;
    private System.Windows.Forms.Label lblFindWhat;
  }
}