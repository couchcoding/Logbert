namespace Couchcoding.Logbert.Receiver.NLogDirReceiver
{
  partial class NLogDirReceiverSettings
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
            this.txtLogDirectory = new Couchcoding.Logbert.Gui.Controls.TextBoxEx();
            this.chkInitialReadAll = new System.Windows.Forms.CheckBox();
            this.txtLogFilePattern = new Couchcoding.Logbert.Gui.Controls.TextBoxEx();
            this.label1 = new System.Windows.Forms.Label();
            this.mnuFilePattern = new System.Windows.Forms.ContextMenu();
            this.mnuFilePatternPresets = new System.Windows.Forms.MenuItem();
            this.mnuFilePatternLog4Net = new System.Windows.Forms.MenuItem();
            this.mnuFilePatterSeparator1 = new System.Windows.Forms.MenuItem();
            this.mnuFilePatterMatchAnyCharacterOneTime = new System.Windows.Forms.MenuItem();
            this.mnuFilePatterMatchAnyCharacterZeroOrMoreTimes = new System.Windows.Forms.MenuItem();
            this.mnuFilePatterMatchAnyCharacterOneOrMoreTimes = new System.Windows.Forms.MenuItem();
            this.mnuFilePatterSeparator2 = new System.Windows.Forms.MenuItem();
            this.mnuFilePatterMatchAnySingleCharacter = new System.Windows.Forms.MenuItem();
            this.mnuFilePatterMatchAnyCharacter = new System.Windows.Forms.MenuItem();
            this.mnuFilePatterMatchWordCharacter = new System.Windows.Forms.MenuItem();
            this.mnuFilePatterMatchDecimalDigit = new System.Windows.Forms.MenuItem();
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
            this.lblNetworkInterface.Size = new System.Drawing.Size(105, 13);
            this.lblNetworkInterface.TabIndex = 0;
            this.lblNetworkInterface.Text = "&Directory to observe:";
            // 
            // txtLogDirectory
            // 
            this.txtLogDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLogDirectory.Location = new System.Drawing.Point(0, 16);
            this.txtLogDirectory.Name = "txtLogDirectory";
            this.txtLogDirectory.Size = new System.Drawing.Size(400, 20);
            this.txtLogDirectory.TabIndex = 1;
            this.txtLogDirectory.ButtonClick += new System.EventHandler(this.TxtLogDirectoryButtonClick);
            // 
            // chkInitialReadAll
            // 
            this.chkInitialReadAll.AutoSize = true;
            this.chkInitialReadAll.Checked = true;
            this.chkInitialReadAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInitialReadAll.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkInitialReadAll.Location = new System.Drawing.Point(0, 87);
            this.chkInitialReadAll.Name = "chkInitialReadAll";
            this.chkInitialReadAll.Size = new System.Drawing.Size(152, 18);
            this.chkInitialReadAll.TabIndex = 4;
            this.chkInitialReadAll.Text = "&Initial read all existing files";
            this.chkInitialReadAll.UseVisualStyleBackColor = true;
            // 
            // txtLogFilePattern
            // 
            this.txtLogFilePattern.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLogFilePattern.ButtonText = "?";
            this.txtLogFilePattern.Location = new System.Drawing.Point(0, 61);
            this.txtLogFilePattern.Name = "txtLogFilePattern";
            this.txtLogFilePattern.Size = new System.Drawing.Size(400, 20);
            this.txtLogFilePattern.TabIndex = 3;
            this.txtLogFilePattern.ButtonClick += new System.EventHandler(this.TxtLogFilePatternButtonClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Location = new System.Drawing.Point(0, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "&Log file pattern:";
            // 
            // mnuFilePattern
            // 
            this.mnuFilePattern.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuFilePatternPresets,
            this.mnuFilePatterSeparator1,
            this.mnuFilePatterMatchAnyCharacterOneTime,
            this.mnuFilePatterMatchAnyCharacterZeroOrMoreTimes,
            this.mnuFilePatterMatchAnyCharacterOneOrMoreTimes,
            this.mnuFilePatterSeparator2,
            this.mnuFilePatterMatchAnySingleCharacter,
            this.mnuFilePatterMatchAnyCharacter,
            this.mnuFilePatterMatchWordCharacter,
            this.mnuFilePatterMatchDecimalDigit});
            // 
            // mnuFilePatternPresets
            // 
            this.mnuFilePatternPresets.Index = 0;
            this.mnuFilePatternPresets.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuFilePatternLog4Net});
            this.mnuFilePatternPresets.Text = "Presets";
            // 
            // mnuFilePatternLog4Net
            // 
            this.mnuFilePatternLog4Net.Index = 0;
            this.mnuFilePatternLog4Net.Tag = ".*\\.log[\\.]?[\\d]?";
            this.mnuFilePatternLog4Net.Text = "Log4Net Pattern\t.*\\.log[\\.]?[\\d]?";
            this.mnuFilePatternLog4Net.Click += new System.EventHandler(this.MnuFilePatternPresetClick);
            // 
            // mnuFilePatterSeparator1
            // 
            this.mnuFilePatterSeparator1.Index = 1;
            this.mnuFilePatterSeparator1.Text = "-";
            // 
            // mnuFilePatterMatchAnyCharacterOneTime
            // 
            this.mnuFilePatterMatchAnyCharacterOneTime.Index = 2;
            this.mnuFilePatterMatchAnyCharacterOneTime.Tag = ".";
            this.mnuFilePatterMatchAnyCharacterOneTime.Text = ".\tMatch any character one time";
            this.mnuFilePatterMatchAnyCharacterOneTime.Click += new System.EventHandler(this.MnuFilePatternClick);
            // 
            // mnuFilePatterMatchAnyCharacterZeroOrMoreTimes
            // 
            this.mnuFilePatterMatchAnyCharacterZeroOrMoreTimes.Index = 3;
            this.mnuFilePatterMatchAnyCharacterZeroOrMoreTimes.Tag = ".*";
            this.mnuFilePatterMatchAnyCharacterZeroOrMoreTimes.Text = ".*\tMatch any character zero or more times (wildcard *)";
            this.mnuFilePatterMatchAnyCharacterZeroOrMoreTimes.Click += new System.EventHandler(this.MnuFilePatternClick);
            // 
            // mnuFilePatterMatchAnyCharacterOneOrMoreTimes
            // 
            this.mnuFilePatterMatchAnyCharacterOneOrMoreTimes.Index = 4;
            this.mnuFilePatterMatchAnyCharacterOneOrMoreTimes.Tag = ".+";
            this.mnuFilePatterMatchAnyCharacterOneOrMoreTimes.Text = ".+\tMatch any character one or more time (wildcard ?)";
            this.mnuFilePatterMatchAnyCharacterOneOrMoreTimes.Click += new System.EventHandler(this.MnuFilePatternClick);
            // 
            // mnuFilePatterSeparator2
            // 
            this.mnuFilePatterSeparator2.Index = 5;
            this.mnuFilePatterSeparator2.Text = "-";
            // 
            // mnuFilePatterMatchAnySingleCharacter
            // 
            this.mnuFilePatterMatchAnySingleCharacter.Index = 6;
            this.mnuFilePatterMatchAnySingleCharacter.Tag = "[abc]";
            this.mnuFilePatterMatchAnySingleCharacter.Text = "[abc]\tMatch any single character in the set \'abc\'";
            this.mnuFilePatterMatchAnySingleCharacter.Click += new System.EventHandler(this.MnuFilePatternClick);
            // 
            // mnuFilePatterMatchAnyCharacter
            // 
            this.mnuFilePatterMatchAnyCharacter.Index = 7;
            this.mnuFilePatterMatchAnyCharacter.Tag = "[a-f]";
            this.mnuFilePatterMatchAnyCharacter.Text = "[a-f]\tMatch any character in range a to f";
            this.mnuFilePatterMatchAnyCharacter.Click += new System.EventHandler(this.MnuFilePatternClick);
            // 
            // mnuFilePatterMatchWordCharacter
            // 
            this.mnuFilePatterMatchWordCharacter.Index = 8;
            this.mnuFilePatterMatchWordCharacter.Tag = "\\w";
            this.mnuFilePatterMatchWordCharacter.Text = "\\w\tMatch any word character";
            this.mnuFilePatterMatchWordCharacter.Click += new System.EventHandler(this.MnuFilePatternClick);
            // 
            // mnuFilePatterMatchDecimalDigit
            // 
            this.mnuFilePatterMatchDecimalDigit.Index = 9;
            this.mnuFilePatterMatchDecimalDigit.Tag = "\\d";
            this.mnuFilePatterMatchDecimalDigit.Text = "\\d\tMatch any decimal digit";
            this.mnuFilePatterMatchDecimalDigit.Click += new System.EventHandler(this.MnuFilePatternClick);
            // 
            // cmbEncoding
            // 
            this.cmbEncoding.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbEncoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEncoding.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbEncoding.FormattingEnabled = true;
            this.cmbEncoding.Location = new System.Drawing.Point(0, 130);
            this.cmbEncoding.Name = "cmbEncoding";
            this.cmbEncoding.Size = new System.Drawing.Size(400, 21);
            this.cmbEncoding.Sorted = true;
            this.cmbEncoding.TabIndex = 8;
            // 
            // lblEncoding
            // 
            this.lblEncoding.AutoSize = true;
            this.lblEncoding.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEncoding.Location = new System.Drawing.Point(0, 114);
            this.lblEncoding.Name = "lblEncoding";
            this.lblEncoding.Size = new System.Drawing.Size(55, 13);
            this.lblEncoding.TabIndex = 7;
            this.lblEncoding.Text = "&Encoding:";
            // 
            // NLogDirReceiverSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbEncoding);
            this.Controls.Add(this.lblEncoding);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLogFilePattern);
            this.Controls.Add(this.chkInitialReadAll);
            this.Controls.Add(this.txtLogDirectory);
            this.Controls.Add(this.lblNetworkInterface);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MinimumSize = new System.Drawing.Size(0, 153);
            this.Name = "NLogDirReceiverSettings";
            this.Size = new System.Drawing.Size(400, 300);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label lblNetworkInterface;
    private Gui.Controls.TextBoxEx txtLogDirectory;
    private System.Windows.Forms.CheckBox chkInitialReadAll;
    private Gui.Controls.TextBoxEx txtLogFilePattern;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ContextMenu mnuFilePattern;
    private System.Windows.Forms.MenuItem mnuFilePatternPresets;
    private System.Windows.Forms.MenuItem mnuFilePatternLog4Net;
    private System.Windows.Forms.MenuItem mnuFilePatterSeparator1;
    private System.Windows.Forms.MenuItem mnuFilePatterMatchAnyCharacterOneTime;
    private System.Windows.Forms.MenuItem mnuFilePatterMatchAnyCharacterZeroOrMoreTimes;
    private System.Windows.Forms.MenuItem mnuFilePatterMatchAnyCharacterOneOrMoreTimes;
    private System.Windows.Forms.MenuItem mnuFilePatterSeparator2;
    private System.Windows.Forms.MenuItem mnuFilePatterMatchAnySingleCharacter;
    private System.Windows.Forms.MenuItem mnuFilePatterMatchAnyCharacter;
    private System.Windows.Forms.MenuItem mnuFilePatterMatchWordCharacter;
    private System.Windows.Forms.MenuItem mnuFilePatterMatchDecimalDigit;
    private System.Windows.Forms.ComboBox cmbEncoding;
    private System.Windows.Forms.Label lblEncoding;
  }
}
