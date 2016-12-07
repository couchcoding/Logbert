namespace Com.Couchcoding.Logbert.Controls.OptionPanels
{
  partial class OptionPanelGeneral
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
      this.lblUpdateRate = new System.Windows.Forms.Label();
      this.nudUpdateRate = new System.Windows.Forms.NumericUpDown();
      this.nfoPanel = new Com.Couchcoding.GuiLibrary.Controls.InfoPanel();
      this.lblTimestampFormat = new System.Windows.Forms.Label();
      this.txtTimestampFormat = new Com.Couchcoding.GuiLibrary.Controls.TextBoxEx();
      this.mnuTimestamp = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.mnuTimestampPresets = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuTimestampPreset1 = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuTimestampPreset2 = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuTimestampPreset3 = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuTimestampPreset4 = new System.Windows.Forms.ToolStripMenuItem();
      this.menuItem2 = new System.Windows.Forms.ToolStripSeparator();
      this.mnuTimestamp_d = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuTimestamp_dd = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuTimestamp_ddd = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuTimestamp_dddd = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuTimestamp_f = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuTimestamp_ff = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuTimestamp_fff = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuTimestamp_h = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuTimestamp_hh = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuTimestamp_hhh = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuTimestamp_hhhh = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuTimestamp_m = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuTimestamp_mm = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuTimestamp_mmm = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuTimestamp_mmmm = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuTimestamp_s = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuTimestamp_ss = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuTimestamp_t = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuTimestamp_tt = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuTimestamp_y = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuTimestamp_yy = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuTimestamp_yyy = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuTimestamp_yyyy = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuTimestamp_z = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuTimestamp_zz = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuTimestamp_zzz = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuTimestamp_colon = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuTimestamp_slash = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuTimestamp_backslash = new System.Windows.Forms.ToolStripMenuItem();
      this.chkAutoFollow = new System.Windows.Forms.CheckBox();
      this.chkAllowOnlyOneInstance = new System.Windows.Forms.CheckBox();
      this.lblMaxLogMessages = new System.Windows.Forms.Label();
      this.nudMaxLogMessages = new System.Windows.Forms.NumericUpDown();
      this.chkEnableColorMap = new System.Windows.Forms.CheckBox();
      this.chkAnnotateTrace = new System.Windows.Forms.CheckBox();
      this.chkAnnotateDebug = new System.Windows.Forms.CheckBox();
      this.chkAnnotateInfo = new System.Windows.Forms.CheckBox();
      this.chkAnnotateWarning = new System.Windows.Forms.CheckBox();
      this.chkAnnotateError = new System.Windows.Forms.CheckBox();
      this.chkAnnotateFatal = new System.Windows.Forms.CheckBox();
      ((System.ComponentModel.ISupportInitialize)(this.nudUpdateRate)).BeginInit();
      this.mnuTimestamp.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudMaxLogMessages)).BeginInit();
      this.SuspendLayout();
      // 
      // lblUpdateRate
      // 
      this.lblUpdateRate.AutoSize = true;
      this.lblUpdateRate.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.lblUpdateRate.Location = new System.Drawing.Point(3, 6);
      this.lblUpdateRate.Name = "lblUpdateRate";
      this.lblUpdateRate.Size = new System.Drawing.Size(142, 13);
      this.lblUpdateRate.TabIndex = 0;
      this.lblUpdateRate.Text = "Update Rate in Milliseconds:";
      // 
      // nudUpdateRate
      // 
      this.nudUpdateRate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.nudUpdateRate.Location = new System.Drawing.Point(3, 22);
      this.nudUpdateRate.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
      this.nudUpdateRate.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
      this.nudUpdateRate.Name = "nudUpdateRate";
      this.nudUpdateRate.Size = new System.Drawing.Size(474, 20);
      this.nudUpdateRate.TabIndex = 1;
      this.nudUpdateRate.Value = new decimal(new int[] {
            50,
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
      this.nfoPanel.InfoIcon = global::Com.Couchcoding.Logbert.Properties.Resources.StatusAnnotations_Information_16xLG;
      this.nfoPanel.Location = new System.Drawing.Point(3, 48);
      this.nfoPanel.Name = "nfoPanel";
      this.nfoPanel.ShowInfoIcon = true;
      this.nfoPanel.ShowTitle = false;
      this.nfoPanel.Size = new System.Drawing.Size(474, 48);
      this.nfoPanel.TabIndex = 2;
      this.nfoPanel.Text = "Note: Setting this property to a value less than 100 may result in a not respondi" +
    "ng user interface.";
      this.nfoPanel.TextPadding = new System.Windows.Forms.Padding(0, 6, 0, 0);
      this.nfoPanel.Title = "";
      // 
      // lblTimestampFormat
      // 
      this.lblTimestampFormat.AutoSize = true;
      this.lblTimestampFormat.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.lblTimestampFormat.Location = new System.Drawing.Point(3, 105);
      this.lblTimestampFormat.Name = "lblTimestampFormat";
      this.lblTimestampFormat.Size = new System.Drawing.Size(96, 13);
      this.lblTimestampFormat.TabIndex = 3;
      this.lblTimestampFormat.Text = "Timestamp Format:";
      // 
      // txtTimestampFormat
      // 
      this.txtTimestampFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtTimestampFormat.ButtonText = "?";
      this.txtTimestampFormat.Location = new System.Drawing.Point(3, 121);
      this.txtTimestampFormat.Name = "txtTimestampFormat";
      this.txtTimestampFormat.Size = new System.Drawing.Size(474, 20);
      this.txtTimestampFormat.TabIndex = 4;
      this.txtTimestampFormat.ButtonClick += new System.EventHandler(this.TxtTimestampFormatButtonClick);
      // 
      // mnuTimestamp
      // 
      this.mnuTimestamp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTimestampPresets,
            this.menuItem2,
            this.mnuTimestamp_d,
            this.mnuTimestamp_dd,
            this.mnuTimestamp_ddd,
            this.mnuTimestamp_dddd,
            this.mnuTimestamp_f,
            this.mnuTimestamp_ff,
            this.mnuTimestamp_fff,
            this.mnuTimestamp_h,
            this.mnuTimestamp_hh,
            this.mnuTimestamp_hhh,
            this.mnuTimestamp_hhhh,
            this.mnuTimestamp_m,
            this.mnuTimestamp_mm,
            this.mnuTimestamp_mmm,
            this.mnuTimestamp_mmmm,
            this.mnuTimestamp_s,
            this.mnuTimestamp_ss,
            this.mnuTimestamp_t,
            this.mnuTimestamp_tt,
            this.mnuTimestamp_y,
            this.mnuTimestamp_yy,
            this.mnuTimestamp_yyy,
            this.mnuTimestamp_yyyy,
            this.mnuTimestamp_z,
            this.mnuTimestamp_zz,
            this.mnuTimestamp_zzz,
            this.mnuTimestamp_colon,
            this.mnuTimestamp_slash,
            this.mnuTimestamp_backslash});
      this.mnuTimestamp.Name = "mnuTimestamp";
      this.mnuTimestamp.Size = new System.Drawing.Size(437, 692);
      // 
      // mnuTimestampPresets
      // 
      this.mnuTimestampPresets.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTimestampPreset1,
            this.mnuTimestampPreset2,
            this.mnuTimestampPreset3,
            this.mnuTimestampPreset4});
      this.mnuTimestampPresets.Name = "mnuTimestampPresets";
      this.mnuTimestampPresets.Size = new System.Drawing.Size(436, 22);
      this.mnuTimestampPresets.Text = "Presets";
      // 
      // mnuTimestampPreset1
      // 
      this.mnuTimestampPreset1.Name = "mnuTimestampPreset1";
      this.mnuTimestampPreset1.Size = new System.Drawing.Size(206, 22);
      this.mnuTimestampPreset1.Tag = "HH:mm:ss";
      this.mnuTimestampPreset1.Text = "HH:mm:ss";
      this.mnuTimestampPreset1.Click += new System.EventHandler(this.MnuTimestampPresetClick);
      // 
      // mnuTimestampPreset2
      // 
      this.mnuTimestampPreset2.Name = "mnuTimestampPreset2";
      this.mnuTimestampPreset2.Size = new System.Drawing.Size(206, 22);
      this.mnuTimestampPreset2.Tag = "HH:mm:ss.fff";
      this.mnuTimestampPreset2.Text = "HH:mm:ss.fff";
      this.mnuTimestampPreset2.Click += new System.EventHandler(this.MnuTimestampPresetClick);
      // 
      // mnuTimestampPreset3
      // 
      this.mnuTimestampPreset3.Name = "mnuTimestampPreset3";
      this.mnuTimestampPreset3.Size = new System.Drawing.Size(206, 22);
      this.mnuTimestampPreset3.Tag = "MM/dd/yy HH:mm:ss";
      this.mnuTimestampPreset3.Text = "MM/dd/yy HH:mm:ss";
      this.mnuTimestampPreset3.Click += new System.EventHandler(this.MnuTimestampPresetClick);
      // 
      // mnuTimestampPreset4
      // 
      this.mnuTimestampPreset4.Name = "mnuTimestampPreset4";
      this.mnuTimestampPreset4.Size = new System.Drawing.Size(206, 22);
      this.mnuTimestampPreset4.Tag = "MM/dd/yy HH:mm:ss.fff";
      this.mnuTimestampPreset4.Text = "MM/dd/yy HH:mm:ss.fff";
      this.mnuTimestampPreset4.Click += new System.EventHandler(this.MnuTimestampPresetClick);
      // 
      // menuItem2
      // 
      this.menuItem2.Name = "menuItem2";
      this.menuItem2.Size = new System.Drawing.Size(433, 6);
      // 
      // mnuTimestamp_d
      // 
      this.mnuTimestamp_d.Name = "mnuTimestamp_d";
      this.mnuTimestamp_d.ShortcutKeyDisplayString = "The day of the month, from 1 through 31";
      this.mnuTimestamp_d.Size = new System.Drawing.Size(436, 22);
      this.mnuTimestamp_d.Tag = "d";
      this.mnuTimestamp_d.Text = "d";
      this.mnuTimestamp_d.Click += new System.EventHandler(this.MnuTimestampClick);
      // 
      // mnuTimestamp_dd
      // 
      this.mnuTimestamp_dd.Name = "mnuTimestamp_dd";
      this.mnuTimestamp_dd.ShortcutKeyDisplayString = "The day of the month, from 01 through 31";
      this.mnuTimestamp_dd.Size = new System.Drawing.Size(436, 22);
      this.mnuTimestamp_dd.Tag = "dd";
      this.mnuTimestamp_dd.Text = "dd";
      this.mnuTimestamp_dd.Click += new System.EventHandler(this.MnuTimestampClick);
      // 
      // mnuTimestamp_ddd
      // 
      this.mnuTimestamp_ddd.Name = "mnuTimestamp_ddd";
      this.mnuTimestamp_ddd.ShortcutKeyDisplayString = "The abbreviated name of the day of the week";
      this.mnuTimestamp_ddd.Size = new System.Drawing.Size(436, 22);
      this.mnuTimestamp_ddd.Tag = "ddd";
      this.mnuTimestamp_ddd.Text = "ddd";
      this.mnuTimestamp_ddd.Click += new System.EventHandler(this.MnuTimestampClick);
      // 
      // mnuTimestamp_dddd
      // 
      this.mnuTimestamp_dddd.Name = "mnuTimestamp_dddd";
      this.mnuTimestamp_dddd.ShortcutKeyDisplayString = "The full name of the day of the week";
      this.mnuTimestamp_dddd.Size = new System.Drawing.Size(436, 22);
      this.mnuTimestamp_dddd.Tag = "dddd";
      this.mnuTimestamp_dddd.Text = "dddd";
      this.mnuTimestamp_dddd.Click += new System.EventHandler(this.MnuTimestampClick);
      // 
      // mnuTimestamp_f
      // 
      this.mnuTimestamp_f.Name = "mnuTimestamp_f";
      this.mnuTimestamp_f.ShortcutKeyDisplayString = "The tenths of a second in a date and time value";
      this.mnuTimestamp_f.Size = new System.Drawing.Size(436, 22);
      this.mnuTimestamp_f.Tag = "f";
      this.mnuTimestamp_f.Text = "f";
      this.mnuTimestamp_f.Click += new System.EventHandler(this.MnuTimestampClick);
      // 
      // mnuTimestamp_ff
      // 
      this.mnuTimestamp_ff.Name = "mnuTimestamp_ff";
      this.mnuTimestamp_ff.ShortcutKeyDisplayString = "The hundredths of a second in a date and time value";
      this.mnuTimestamp_ff.Size = new System.Drawing.Size(436, 22);
      this.mnuTimestamp_ff.Tag = "ff";
      this.mnuTimestamp_ff.Text = "ff";
      this.mnuTimestamp_ff.Click += new System.EventHandler(this.MnuTimestampClick);
      // 
      // mnuTimestamp_fff
      // 
      this.mnuTimestamp_fff.Name = "mnuTimestamp_fff";
      this.mnuTimestamp_fff.ShortcutKeyDisplayString = "The milliseconds in a date and time value.";
      this.mnuTimestamp_fff.Size = new System.Drawing.Size(436, 22);
      this.mnuTimestamp_fff.Tag = "fff";
      this.mnuTimestamp_fff.Text = "fff";
      this.mnuTimestamp_fff.Click += new System.EventHandler(this.MnuTimestampClick);
      // 
      // mnuTimestamp_h
      // 
      this.mnuTimestamp_h.Name = "mnuTimestamp_h";
      this.mnuTimestamp_h.ShortcutKeyDisplayString = "The hour, using a 12-hour clock from 1 to 12";
      this.mnuTimestamp_h.Size = new System.Drawing.Size(436, 22);
      this.mnuTimestamp_h.Tag = "h";
      this.mnuTimestamp_h.Text = "h";
      this.mnuTimestamp_h.Click += new System.EventHandler(this.MnuTimestampClick);
      // 
      // mnuTimestamp_hh
      // 
      this.mnuTimestamp_hh.Name = "mnuTimestamp_hh";
      this.mnuTimestamp_hh.ShortcutKeyDisplayString = "The hour, using a 12-hour clock from 01 to 12";
      this.mnuTimestamp_hh.Size = new System.Drawing.Size(436, 22);
      this.mnuTimestamp_hh.Tag = "hh";
      this.mnuTimestamp_hh.Text = "hh";
      this.mnuTimestamp_hh.Click += new System.EventHandler(this.MnuTimestampClick);
      // 
      // mnuTimestamp_hhh
      // 
      this.mnuTimestamp_hhh.Name = "mnuTimestamp_hhh";
      this.mnuTimestamp_hhh.ShortcutKeyDisplayString = "The hour, using a 24-hour clock from 0 to 23";
      this.mnuTimestamp_hhh.Size = new System.Drawing.Size(436, 22);
      this.mnuTimestamp_hhh.Tag = "H";
      this.mnuTimestamp_hhh.Text = "H";
      this.mnuTimestamp_hhh.Click += new System.EventHandler(this.MnuTimestampClick);
      // 
      // mnuTimestamp_hhhh
      // 
      this.mnuTimestamp_hhhh.Name = "mnuTimestamp_hhhh";
      this.mnuTimestamp_hhhh.ShortcutKeyDisplayString = "The hour, using a 24-hour clock from 00 to 23";
      this.mnuTimestamp_hhhh.Size = new System.Drawing.Size(436, 22);
      this.mnuTimestamp_hhhh.Tag = "HH";
      this.mnuTimestamp_hhhh.Text = "HH";
      this.mnuTimestamp_hhhh.Click += new System.EventHandler(this.MnuTimestampClick);
      // 
      // mnuTimestamp_m
      // 
      this.mnuTimestamp_m.Name = "mnuTimestamp_m";
      this.mnuTimestamp_m.ShortcutKeyDisplayString = "The minute, from 0 through 59";
      this.mnuTimestamp_m.Size = new System.Drawing.Size(436, 22);
      this.mnuTimestamp_m.Tag = "m";
      this.mnuTimestamp_m.Text = "m";
      this.mnuTimestamp_m.Click += new System.EventHandler(this.MnuTimestampClick);
      // 
      // mnuTimestamp_mm
      // 
      this.mnuTimestamp_mm.Name = "mnuTimestamp_mm";
      this.mnuTimestamp_mm.ShortcutKeyDisplayString = "The minute, from 00 through 59";
      this.mnuTimestamp_mm.Size = new System.Drawing.Size(436, 22);
      this.mnuTimestamp_mm.Tag = "mm";
      this.mnuTimestamp_mm.Text = "mm";
      this.mnuTimestamp_mm.Click += new System.EventHandler(this.MnuTimestampClick);
      // 
      // mnuTimestamp_mmm
      // 
      this.mnuTimestamp_mmm.Name = "mnuTimestamp_mmm";
      this.mnuTimestamp_mmm.ShortcutKeyDisplayString = "The month, from 1 through 12";
      this.mnuTimestamp_mmm.Size = new System.Drawing.Size(436, 22);
      this.mnuTimestamp_mmm.Tag = "M";
      this.mnuTimestamp_mmm.Text = "M";
      this.mnuTimestamp_mmm.Click += new System.EventHandler(this.MnuTimestampClick);
      // 
      // mnuTimestamp_mmmm
      // 
      this.mnuTimestamp_mmmm.Name = "mnuTimestamp_mmmm";
      this.mnuTimestamp_mmmm.ShortcutKeyDisplayString = "The month, from 01 through 12";
      this.mnuTimestamp_mmmm.Size = new System.Drawing.Size(436, 22);
      this.mnuTimestamp_mmmm.Tag = "MM";
      this.mnuTimestamp_mmmm.Text = "MM";
      this.mnuTimestamp_mmmm.Click += new System.EventHandler(this.MnuTimestampClick);
      // 
      // mnuTimestamp_s
      // 
      this.mnuTimestamp_s.Name = "mnuTimestamp_s";
      this.mnuTimestamp_s.ShortcutKeyDisplayString = "The second, from 0 through 59";
      this.mnuTimestamp_s.Size = new System.Drawing.Size(436, 22);
      this.mnuTimestamp_s.Tag = "s";
      this.mnuTimestamp_s.Text = "s";
      this.mnuTimestamp_s.Click += new System.EventHandler(this.MnuTimestampClick);
      // 
      // mnuTimestamp_ss
      // 
      this.mnuTimestamp_ss.Name = "mnuTimestamp_ss";
      this.mnuTimestamp_ss.ShortcutKeyDisplayString = "The second, from 00 through 59";
      this.mnuTimestamp_ss.Size = new System.Drawing.Size(436, 22);
      this.mnuTimestamp_ss.Tag = "ss";
      this.mnuTimestamp_ss.Text = "ss";
      this.mnuTimestamp_ss.Click += new System.EventHandler(this.MnuTimestampClick);
      // 
      // mnuTimestamp_t
      // 
      this.mnuTimestamp_t.Name = "mnuTimestamp_t";
      this.mnuTimestamp_t.ShortcutKeyDisplayString = "The first character of the AM/PM designator";
      this.mnuTimestamp_t.Size = new System.Drawing.Size(436, 22);
      this.mnuTimestamp_t.Tag = "t";
      this.mnuTimestamp_t.Text = "t";
      this.mnuTimestamp_t.Click += new System.EventHandler(this.MnuTimestampClick);
      // 
      // mnuTimestamp_tt
      // 
      this.mnuTimestamp_tt.Name = "mnuTimestamp_tt";
      this.mnuTimestamp_tt.ShortcutKeyDisplayString = "The AM/PM designator";
      this.mnuTimestamp_tt.Size = new System.Drawing.Size(436, 22);
      this.mnuTimestamp_tt.Tag = "tt";
      this.mnuTimestamp_tt.Text = "tt";
      this.mnuTimestamp_tt.Click += new System.EventHandler(this.MnuTimestampClick);
      // 
      // mnuTimestamp_y
      // 
      this.mnuTimestamp_y.Name = "mnuTimestamp_y";
      this.mnuTimestamp_y.ShortcutKeyDisplayString = "The year, from 0 to 99";
      this.mnuTimestamp_y.Size = new System.Drawing.Size(436, 22);
      this.mnuTimestamp_y.Tag = "y";
      this.mnuTimestamp_y.Text = "y";
      this.mnuTimestamp_y.Click += new System.EventHandler(this.MnuTimestampClick);
      // 
      // mnuTimestamp_yy
      // 
      this.mnuTimestamp_yy.Name = "mnuTimestamp_yy";
      this.mnuTimestamp_yy.ShortcutKeyDisplayString = "The year, from 00 to 99";
      this.mnuTimestamp_yy.Size = new System.Drawing.Size(436, 22);
      this.mnuTimestamp_yy.Tag = "yy";
      this.mnuTimestamp_yy.Text = "yy";
      this.mnuTimestamp_yy.Click += new System.EventHandler(this.MnuTimestampClick);
      // 
      // mnuTimestamp_yyy
      // 
      this.mnuTimestamp_yyy.Name = "mnuTimestamp_yyy";
      this.mnuTimestamp_yyy.ShortcutKeyDisplayString = "The year, with a minimum of three digits";
      this.mnuTimestamp_yyy.Size = new System.Drawing.Size(436, 22);
      this.mnuTimestamp_yyy.Tag = "yyy";
      this.mnuTimestamp_yyy.Text = "yyy";
      this.mnuTimestamp_yyy.Click += new System.EventHandler(this.MnuTimestampClick);
      // 
      // mnuTimestamp_yyyy
      // 
      this.mnuTimestamp_yyyy.Name = "mnuTimestamp_yyyy";
      this.mnuTimestamp_yyyy.ShortcutKeyDisplayString = "The year as a four-digit number";
      this.mnuTimestamp_yyyy.Size = new System.Drawing.Size(436, 22);
      this.mnuTimestamp_yyyy.Tag = "yyyy";
      this.mnuTimestamp_yyyy.Text = "yyyy";
      this.mnuTimestamp_yyyy.Click += new System.EventHandler(this.MnuTimestampClick);
      // 
      // mnuTimestamp_z
      // 
      this.mnuTimestamp_z.Name = "mnuTimestamp_z";
      this.mnuTimestamp_z.ShortcutKeyDisplayString = "Hours offset from UTC, with no leading zeros";
      this.mnuTimestamp_z.Size = new System.Drawing.Size(436, 22);
      this.mnuTimestamp_z.Tag = "z";
      this.mnuTimestamp_z.Text = "z";
      this.mnuTimestamp_z.Click += new System.EventHandler(this.MnuTimestampClick);
      // 
      // mnuTimestamp_zz
      // 
      this.mnuTimestamp_zz.Name = "mnuTimestamp_zz";
      this.mnuTimestamp_zz.ShortcutKeyDisplayString = "Hours offset from UTC, with a leading zero for a single-digit value";
      this.mnuTimestamp_zz.Size = new System.Drawing.Size(436, 22);
      this.mnuTimestamp_zz.Tag = "zz";
      this.mnuTimestamp_zz.Text = "zz";
      this.mnuTimestamp_zz.Click += new System.EventHandler(this.MnuTimestampClick);
      // 
      // mnuTimestamp_zzz
      // 
      this.mnuTimestamp_zzz.Name = "mnuTimestamp_zzz";
      this.mnuTimestamp_zzz.ShortcutKeyDisplayString = "Hours and minutes offset from UTC";
      this.mnuTimestamp_zzz.Size = new System.Drawing.Size(436, 22);
      this.mnuTimestamp_zzz.Tag = "zzz";
      this.mnuTimestamp_zzz.Text = "zzz";
      this.mnuTimestamp_zzz.Click += new System.EventHandler(this.MnuTimestampClick);
      // 
      // mnuTimestamp_colon
      // 
      this.mnuTimestamp_colon.Name = "mnuTimestamp_colon";
      this.mnuTimestamp_colon.ShortcutKeyDisplayString = "The time separator";
      this.mnuTimestamp_colon.Size = new System.Drawing.Size(436, 22);
      this.mnuTimestamp_colon.Tag = ":";
      this.mnuTimestamp_colon.Text = ":";
      this.mnuTimestamp_colon.Click += new System.EventHandler(this.MnuTimestampClick);
      // 
      // mnuTimestamp_slash
      // 
      this.mnuTimestamp_slash.Name = "mnuTimestamp_slash";
      this.mnuTimestamp_slash.ShortcutKeyDisplayString = "The date separator";
      this.mnuTimestamp_slash.Size = new System.Drawing.Size(436, 22);
      this.mnuTimestamp_slash.Tag = "/";
      this.mnuTimestamp_slash.Text = "/";
      this.mnuTimestamp_slash.Click += new System.EventHandler(this.MnuTimestampClick);
      // 
      // mnuTimestamp_backslash
      // 
      this.mnuTimestamp_backslash.Name = "mnuTimestamp_backslash";
      this.mnuTimestamp_backslash.ShortcutKeyDisplayString = "The escape character";
      this.mnuTimestamp_backslash.Size = new System.Drawing.Size(436, 22);
      this.mnuTimestamp_backslash.Tag = "\\";
      this.mnuTimestamp_backslash.Text = "\\";
      this.mnuTimestamp_backslash.Click += new System.EventHandler(this.MnuTimestampClick);
      // 
      // chkAutoFollow
      // 
      this.chkAutoFollow.AutoSize = true;
      this.chkAutoFollow.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.chkAutoFollow.Location = new System.Drawing.Point(3, 153);
      this.chkAutoFollow.Name = "chkAutoFollow";
      this.chkAutoFollow.Size = new System.Drawing.Size(313, 18);
      this.chkAutoFollow.TabIndex = 5;
      this.chkAutoFollow.Text = "Enable scrolling to new messages if the last one is selected.";
      this.chkAutoFollow.UseVisualStyleBackColor = true;
      // 
      // chkAllowOnlyOneInstance
      // 
      this.chkAllowOnlyOneInstance.AutoSize = true;
      this.chkAllowOnlyOneInstance.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.chkAllowOnlyOneInstance.Location = new System.Drawing.Point(3, 177);
      this.chkAllowOnlyOneInstance.Name = "chkAllowOnlyOneInstance";
      this.chkAllowOnlyOneInstance.Size = new System.Drawing.Size(230, 18);
      this.chkAllowOnlyOneInstance.TabIndex = 6;
      this.chkAllowOnlyOneInstance.Text = "Allow only one instance of the application.";
      this.chkAllowOnlyOneInstance.UseVisualStyleBackColor = true;
      // 
      // lblMaxLogMessages
      // 
      this.lblMaxLogMessages.AutoSize = true;
      this.lblMaxLogMessages.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.lblMaxLogMessages.Location = new System.Drawing.Point(3, 204);
      this.lblMaxLogMessages.Name = "lblMaxLogMessages";
      this.lblMaxLogMessages.Size = new System.Drawing.Size(204, 13);
      this.lblMaxLogMessages.TabIndex = 7;
      this.lblMaxLogMessages.Text = "Maximum log messages for each receiver:";
      // 
      // nudMaxLogMessages
      // 
      this.nudMaxLogMessages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.nudMaxLogMessages.Location = new System.Drawing.Point(3, 220);
      this.nudMaxLogMessages.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
      this.nudMaxLogMessages.Name = "nudMaxLogMessages";
      this.nudMaxLogMessages.Size = new System.Drawing.Size(474, 20);
      this.nudMaxLogMessages.TabIndex = 8;
      this.nudMaxLogMessages.Value = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
      // 
      // chkEnableColorMap
      // 
      this.chkEnableColorMap.AutoSize = true;
      this.chkEnableColorMap.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.chkEnableColorMap.Location = new System.Drawing.Point(3, 252);
      this.chkEnableColorMap.Name = "chkEnableColorMap";
      this.chkEnableColorMap.Size = new System.Drawing.Size(255, 18);
      this.chkEnableColorMap.TabIndex = 9;
      this.chkEnableColorMap.Text = "Enable color map annotation in the log window.";
      this.chkEnableColorMap.UseVisualStyleBackColor = true;
      this.chkEnableColorMap.CheckedChanged += new System.EventHandler(this.ChkEnableColorMapCheckedChanged);
      // 
      // chkAnnotateTrace
      // 
      this.chkAnnotateTrace.AutoSize = true;
      this.chkAnnotateTrace.Enabled = false;
      this.chkAnnotateTrace.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.chkAnnotateTrace.Location = new System.Drawing.Point(18, 276);
      this.chkAnnotateTrace.Name = "chkAnnotateTrace";
      this.chkAnnotateTrace.Size = new System.Drawing.Size(152, 18);
      this.chkAnnotateTrace.TabIndex = 10;
      this.chkAnnotateTrace.Text = "Annotate trace messages";
      this.chkAnnotateTrace.UseVisualStyleBackColor = true;
      // 
      // chkAnnotateDebug
      // 
      this.chkAnnotateDebug.AutoSize = true;
      this.chkAnnotateDebug.Enabled = false;
      this.chkAnnotateDebug.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.chkAnnotateDebug.Location = new System.Drawing.Point(18, 299);
      this.chkAnnotateDebug.Name = "chkAnnotateDebug";
      this.chkAnnotateDebug.Size = new System.Drawing.Size(158, 18);
      this.chkAnnotateDebug.TabIndex = 11;
      this.chkAnnotateDebug.Text = "Annotate debug messages";
      this.chkAnnotateDebug.UseVisualStyleBackColor = true;
      // 
      // chkAnnotateInfo
      // 
      this.chkAnnotateInfo.AutoSize = true;
      this.chkAnnotateInfo.Enabled = false;
      this.chkAnnotateInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.chkAnnotateInfo.Location = new System.Drawing.Point(18, 322);
      this.chkAnnotateInfo.Name = "chkAnnotateInfo";
      this.chkAnnotateInfo.Size = new System.Drawing.Size(145, 18);
      this.chkAnnotateInfo.TabIndex = 12;
      this.chkAnnotateInfo.Text = "Annotate info messages";
      this.chkAnnotateInfo.UseVisualStyleBackColor = true;
      // 
      // chkAnnotateWarning
      // 
      this.chkAnnotateWarning.AutoSize = true;
      this.chkAnnotateWarning.Enabled = false;
      this.chkAnnotateWarning.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.chkAnnotateWarning.Location = new System.Drawing.Point(18, 345);
      this.chkAnnotateWarning.Name = "chkAnnotateWarning";
      this.chkAnnotateWarning.Size = new System.Drawing.Size(165, 18);
      this.chkAnnotateWarning.TabIndex = 13;
      this.chkAnnotateWarning.Text = "Annotate warning messages";
      this.chkAnnotateWarning.UseVisualStyleBackColor = true;
      // 
      // chkAnnotateError
      // 
      this.chkAnnotateError.AutoSize = true;
      this.chkAnnotateError.Enabled = false;
      this.chkAnnotateError.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.chkAnnotateError.Location = new System.Drawing.Point(18, 368);
      this.chkAnnotateError.Name = "chkAnnotateError";
      this.chkAnnotateError.Size = new System.Drawing.Size(149, 18);
      this.chkAnnotateError.TabIndex = 14;
      this.chkAnnotateError.Text = "Annotate error messages";
      this.chkAnnotateError.UseVisualStyleBackColor = true;
      // 
      // chkAnnotateFatal
      // 
      this.chkAnnotateFatal.AutoSize = true;
      this.chkAnnotateFatal.Enabled = false;
      this.chkAnnotateFatal.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.chkAnnotateFatal.Location = new System.Drawing.Point(18, 391);
      this.chkAnnotateFatal.Name = "chkAnnotateFatal";
      this.chkAnnotateFatal.Size = new System.Drawing.Size(148, 18);
      this.chkAnnotateFatal.TabIndex = 15;
      this.chkAnnotateFatal.Text = "Annotate fatal messages";
      this.chkAnnotateFatal.UseVisualStyleBackColor = true;
      // 
      // OptionPanelGeneral
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.chkAnnotateFatal);
      this.Controls.Add(this.chkAnnotateError);
      this.Controls.Add(this.chkAnnotateWarning);
      this.Controls.Add(this.chkAnnotateInfo);
      this.Controls.Add(this.chkAnnotateDebug);
      this.Controls.Add(this.chkAnnotateTrace);
      this.Controls.Add(this.chkEnableColorMap);
      this.Controls.Add(this.nudMaxLogMessages);
      this.Controls.Add(this.lblMaxLogMessages);
      this.Controls.Add(this.chkAllowOnlyOneInstance);
      this.Controls.Add(this.chkAutoFollow);
      this.Controls.Add(this.txtTimestampFormat);
      this.Controls.Add(this.lblTimestampFormat);
      this.Controls.Add(this.nfoPanel);
      this.Controls.Add(this.nudUpdateRate);
      this.Controls.Add(this.lblUpdateRate);
      this.MinimumSize = new System.Drawing.Size(320, 410);
      this.Name = "OptionPanelGeneral";
      this.Size = new System.Drawing.Size(480, 410);
      ((System.ComponentModel.ISupportInitialize)(this.nudUpdateRate)).EndInit();
      this.mnuTimestamp.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.nudMaxLogMessages)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label lblUpdateRate;
    private System.Windows.Forms.NumericUpDown nudUpdateRate;
    private GuiLibrary.Controls.InfoPanel nfoPanel;
    private System.Windows.Forms.Label lblTimestampFormat;
    private GuiLibrary.Controls.TextBoxEx txtTimestampFormat;
    private System.Windows.Forms.ContextMenuStrip mnuTimestamp;
    private System.Windows.Forms.ToolStripMenuItem mnuTimestampPresets;
    private System.Windows.Forms.ToolStripSeparator menuItem2;
    private System.Windows.Forms.ToolStripMenuItem mnuTimestamp_d;
    private System.Windows.Forms.ToolStripMenuItem mnuTimestamp_dd;
    private System.Windows.Forms.ToolStripMenuItem mnuTimestamp_ddd;
    private System.Windows.Forms.ToolStripMenuItem mnuTimestamp_dddd;
    private System.Windows.Forms.ToolStripMenuItem mnuTimestamp_f;
    private System.Windows.Forms.ToolStripMenuItem mnuTimestamp_ff;
    private System.Windows.Forms.ToolStripMenuItem mnuTimestamp_fff;
    private System.Windows.Forms.ToolStripMenuItem mnuTimestamp_h;
    private System.Windows.Forms.ToolStripMenuItem mnuTimestamp_hh;
    private System.Windows.Forms.ToolStripMenuItem mnuTimestamp_hhh;
    private System.Windows.Forms.ToolStripMenuItem mnuTimestamp_hhhh;
    private System.Windows.Forms.ToolStripMenuItem mnuTimestamp_m;
    private System.Windows.Forms.ToolStripMenuItem mnuTimestamp_mm;
    private System.Windows.Forms.ToolStripMenuItem mnuTimestamp_mmm;
    private System.Windows.Forms.ToolStripMenuItem mnuTimestamp_mmmm;
    private System.Windows.Forms.ToolStripMenuItem mnuTimestamp_s;
    private System.Windows.Forms.ToolStripMenuItem mnuTimestamp_ss;
    private System.Windows.Forms.ToolStripMenuItem mnuTimestamp_t;
    private System.Windows.Forms.ToolStripMenuItem mnuTimestamp_tt;
    private System.Windows.Forms.ToolStripMenuItem mnuTimestamp_y;
    private System.Windows.Forms.ToolStripMenuItem mnuTimestamp_yy;
    private System.Windows.Forms.ToolStripMenuItem mnuTimestamp_yyy;
    private System.Windows.Forms.ToolStripMenuItem mnuTimestamp_yyyy;
    private System.Windows.Forms.ToolStripMenuItem mnuTimestamp_z;
    private System.Windows.Forms.ToolStripMenuItem mnuTimestamp_zz;
    private System.Windows.Forms.ToolStripMenuItem mnuTimestamp_zzz;
    private System.Windows.Forms.ToolStripMenuItem mnuTimestamp_colon;
    private System.Windows.Forms.ToolStripMenuItem mnuTimestamp_slash;
    private System.Windows.Forms.ToolStripMenuItem mnuTimestamp_backslash;
    private System.Windows.Forms.ToolStripMenuItem mnuTimestampPreset1;
    private System.Windows.Forms.ToolStripMenuItem mnuTimestampPreset2;
    private System.Windows.Forms.ToolStripMenuItem mnuTimestampPreset3;
    private System.Windows.Forms.ToolStripMenuItem mnuTimestampPreset4;
    private System.Windows.Forms.CheckBox chkAutoFollow;
    private System.Windows.Forms.CheckBox chkAllowOnlyOneInstance;
    private System.Windows.Forms.Label lblMaxLogMessages;
    private System.Windows.Forms.NumericUpDown nudMaxLogMessages;
    private System.Windows.Forms.CheckBox chkEnableColorMap;
    private System.Windows.Forms.CheckBox chkAnnotateTrace;
    private System.Windows.Forms.CheckBox chkAnnotateDebug;
    private System.Windows.Forms.CheckBox chkAnnotateInfo;
    private System.Windows.Forms.CheckBox chkAnnotateWarning;
    private System.Windows.Forms.CheckBox chkAnnotateError;
    private System.Windows.Forms.CheckBox chkAnnotateFatal;
  }
}
