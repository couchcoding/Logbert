namespace Com.Couchcoding.Logbert.Receiver.NLogDirReceiver
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
      this.components = new System.ComponentModel.Container();
      this.lblNetworkInterface = new System.Windows.Forms.Label();
      this.txtLogDirectory = new Com.Couchcoding.GuiLibrary.Controls.TextBoxEx();
      this.chkInitialReadAll = new System.Windows.Forms.CheckBox();
      this.txtLogFilePattern = new Com.Couchcoding.GuiLibrary.Controls.TextBoxEx();
      this.label1 = new System.Windows.Forms.Label();
      this.mnuFilePattern = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.mnuFilePatternPresets = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuFilePatternLog4Net = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuFilePatterSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.mnuFilePatterMatchAnyCharacterOneTime = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuFilePatterMatchAnyCharacterZeroOrMoreTimes = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuFilePatterMatchAnyCharacterOneOrMoreTimes = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuFilePatterSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.mnuFilePatterMatchAnySingleCharacter = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuFilePatterMatchAnyCharacter = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuFilePatterMatchWordCharacter = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuFilePatterMatchDecimalDigit = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuFilePattern.SuspendLayout();
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
      this.mnuFilePattern.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
      this.mnuFilePattern.Name = "mnuTimestamp";
      this.mnuFilePattern.Size = new System.Drawing.Size(364, 192);
      // 
      // mnuFilePatternPresets
      // 
      this.mnuFilePatternPresets.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFilePatternLog4Net});
      this.mnuFilePatternPresets.Name = "mnuFilePatternPresets";
      this.mnuFilePatternPresets.Size = new System.Drawing.Size(363, 22);
      this.mnuFilePatternPresets.Text = "Presets";
      // 
      // mnuFilePatternLog4Net
      // 
      this.mnuFilePatternLog4Net.Name = "mnuFilePatternLog4Net";
      this.mnuFilePatternLog4Net.ShortcutKeyDisplayString = ".*\\.log[\\.]?[\\d]?";
      this.mnuFilePatternLog4Net.Size = new System.Drawing.Size(246, 22);
      this.mnuFilePatternLog4Net.Tag = ".*\\.log[\\.]?[\\d]?";
      this.mnuFilePatternLog4Net.Text = "Log4Net Pattern";
      this.mnuFilePatternLog4Net.Click += new System.EventHandler(this.MnuFilePatternClick);
      // 
      // mnuFilePatterSeparator1
      // 
      this.mnuFilePatterSeparator1.Name = "mnuFilePatterSeparator1";
      this.mnuFilePatterSeparator1.Size = new System.Drawing.Size(360, 6);
      // 
      // mnuFilePatterMatchAnyCharacterOneTime
      // 
      this.mnuFilePatterMatchAnyCharacterOneTime.Name = "mnuFilePatterMatchAnyCharacterOneTime";
      this.mnuFilePatterMatchAnyCharacterOneTime.ShortcutKeyDisplayString = "Match any character one time";
      this.mnuFilePatterMatchAnyCharacterOneTime.Size = new System.Drawing.Size(363, 22);
      this.mnuFilePatterMatchAnyCharacterOneTime.Tag = ".";
      this.mnuFilePatterMatchAnyCharacterOneTime.Text = ".";
      this.mnuFilePatterMatchAnyCharacterOneTime.Click += new System.EventHandler(this.MnuFilePatternClick);
      // 
      // mnuFilePatterMatchAnyCharacterZeroOrMoreTimes
      // 
      this.mnuFilePatterMatchAnyCharacterZeroOrMoreTimes.Name = "mnuFilePatterMatchAnyCharacterZeroOrMoreTimes";
      this.mnuFilePatterMatchAnyCharacterZeroOrMoreTimes.ShortcutKeyDisplayString = "Match any character zero or more times (wildcard *)";
      this.mnuFilePatterMatchAnyCharacterZeroOrMoreTimes.Size = new System.Drawing.Size(363, 22);
      this.mnuFilePatterMatchAnyCharacterZeroOrMoreTimes.Tag = ".*";
      this.mnuFilePatterMatchAnyCharacterZeroOrMoreTimes.Text = ".*";
      this.mnuFilePatterMatchAnyCharacterZeroOrMoreTimes.Click += new System.EventHandler(this.MnuFilePatternClick);
      // 
      // mnuFilePatterMatchAnyCharacterOneOrMoreTimes
      // 
      this.mnuFilePatterMatchAnyCharacterOneOrMoreTimes.Name = "mnuFilePatterMatchAnyCharacterOneOrMoreTimes";
      this.mnuFilePatterMatchAnyCharacterOneOrMoreTimes.ShortcutKeyDisplayString = "Match any character one or more time (wildcard ?)";
      this.mnuFilePatterMatchAnyCharacterOneOrMoreTimes.Size = new System.Drawing.Size(363, 22);
      this.mnuFilePatterMatchAnyCharacterOneOrMoreTimes.Tag = ".+";
      this.mnuFilePatterMatchAnyCharacterOneOrMoreTimes.Text = ".+";
      this.mnuFilePatterMatchAnyCharacterOneOrMoreTimes.Click += new System.EventHandler(this.MnuFilePatternClick);
      // 
      // mnuFilePatterSeparator2
      // 
      this.mnuFilePatterSeparator2.Name = "mnuFilePatterSeparator2";
      this.mnuFilePatterSeparator2.Size = new System.Drawing.Size(360, 6);
      // 
      // mnuFilePatterMatchAnySingleCharacter
      // 
      this.mnuFilePatterMatchAnySingleCharacter.Name = "mnuFilePatterMatchAnySingleCharacter";
      this.mnuFilePatterMatchAnySingleCharacter.ShortcutKeyDisplayString = "Match any single character in the set \'abc\'";
      this.mnuFilePatterMatchAnySingleCharacter.Size = new System.Drawing.Size(363, 22);
      this.mnuFilePatterMatchAnySingleCharacter.Tag = "[abc]";
      this.mnuFilePatterMatchAnySingleCharacter.Text = "[abc]";
      this.mnuFilePatterMatchAnySingleCharacter.Click += new System.EventHandler(this.MnuFilePatternClick);
      // 
      // mnuFilePatterMatchAnyCharacter
      // 
      this.mnuFilePatterMatchAnyCharacter.Name = "mnuFilePatterMatchAnyCharacter";
      this.mnuFilePatterMatchAnyCharacter.ShortcutKeyDisplayString = "Match any character in range a to f";
      this.mnuFilePatterMatchAnyCharacter.Size = new System.Drawing.Size(363, 22);
      this.mnuFilePatterMatchAnyCharacter.Tag = "[a-f]";
      this.mnuFilePatterMatchAnyCharacter.Text = "[a-f]";
      this.mnuFilePatterMatchAnyCharacter.Click += new System.EventHandler(this.MnuFilePatternClick);
      // 
      // mnuFilePatterMatchWordCharacter
      // 
      this.mnuFilePatterMatchWordCharacter.Name = "mnuFilePatterMatchWordCharacter";
      this.mnuFilePatterMatchWordCharacter.ShortcutKeyDisplayString = "Match any word character";
      this.mnuFilePatterMatchWordCharacter.Size = new System.Drawing.Size(363, 22);
      this.mnuFilePatterMatchWordCharacter.Tag = "\\w";
      this.mnuFilePatterMatchWordCharacter.Text = "\\w";
      this.mnuFilePatterMatchWordCharacter.Click += new System.EventHandler(this.MnuFilePatternClick);
      // 
      // mnuFilePatterMatchDecimalDigit
      // 
      this.mnuFilePatterMatchDecimalDigit.Name = "mnuFilePatterMatchDecimalDigit";
      this.mnuFilePatterMatchDecimalDigit.ShortcutKeyDisplayString = "Match any decimal digit";
      this.mnuFilePatterMatchDecimalDigit.Size = new System.Drawing.Size(363, 22);
      this.mnuFilePatterMatchDecimalDigit.Tag = "\\d";
      this.mnuFilePatterMatchDecimalDigit.Text = "\\d";
      this.mnuFilePatterMatchDecimalDigit.Click += new System.EventHandler(this.MnuFilePatternClick);
      // 
      // Log4NetDirReceiverSettings
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.label1);
      this.Controls.Add(this.txtLogFilePattern);
      this.Controls.Add(this.chkInitialReadAll);
      this.Controls.Add(this.txtLogDirectory);
      this.Controls.Add(this.lblNetworkInterface);
      this.Margin = new System.Windows.Forms.Padding(0);
      this.Name = "Log4NetDirReceiverSettings";
      this.Size = new System.Drawing.Size(400, 300);
      this.mnuFilePattern.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label lblNetworkInterface;
    private GuiLibrary.Controls.TextBoxEx txtLogDirectory;
    private System.Windows.Forms.CheckBox chkInitialReadAll;
    private GuiLibrary.Controls.TextBoxEx txtLogFilePattern;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ContextMenuStrip mnuFilePattern;
    private System.Windows.Forms.ToolStripMenuItem mnuFilePatternPresets;
    private System.Windows.Forms.ToolStripMenuItem mnuFilePatternLog4Net;
    private System.Windows.Forms.ToolStripSeparator mnuFilePatterSeparator1;
    private System.Windows.Forms.ToolStripMenuItem mnuFilePatterMatchAnyCharacterOneTime;
    private System.Windows.Forms.ToolStripMenuItem mnuFilePatterMatchAnyCharacterZeroOrMoreTimes;
    private System.Windows.Forms.ToolStripMenuItem mnuFilePatterMatchAnyCharacterOneOrMoreTimes;
    private System.Windows.Forms.ToolStripSeparator mnuFilePatterSeparator2;
    private System.Windows.Forms.ToolStripMenuItem mnuFilePatterMatchAnySingleCharacter;
    private System.Windows.Forms.ToolStripMenuItem mnuFilePatterMatchAnyCharacter;
    private System.Windows.Forms.ToolStripMenuItem mnuFilePatterMatchWordCharacter;
    private System.Windows.Forms.ToolStripMenuItem mnuFilePatterMatchDecimalDigit;
  }
}
