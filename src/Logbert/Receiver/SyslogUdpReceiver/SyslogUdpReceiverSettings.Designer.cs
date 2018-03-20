namespace Com.Couchcoding.Logbert.Receiver.SyslogUdpReceiver
{
  partial class SyslogUdpReceiverSettings
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
      this.cmbNetworkInterface = new System.Windows.Forms.ComboBox();
      this.nfoPanel = new Com.Couchcoding.GuiLibrary.Controls.InfoPanel();
      this.chkMulticastGroup = new System.Windows.Forms.CheckBox();
      this.txtMulticastIp = new System.Windows.Forms.TextBox();
      this.nudPort = new System.Windows.Forms.NumericUpDown();
      this.lblPort = new System.Windows.Forms.Label();
      this.txtTimestampFormat = new Com.Couchcoding.GuiLibrary.Controls.TextBoxEx();
      this.lblTimestampFormat = new System.Windows.Forms.Label();
      this.mnuTimestamp = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.mnuTimestampPresets = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuTimestampPreset1 = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuTimestampPreset2 = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuTimestampPreset3 = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuTimestampPreset4 = new System.Windows.Forms.ToolStripMenuItem();
      this.yyyyMMddTHHmmssSSSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
      ((System.ComponentModel.ISupportInitialize)(this.nudPort)).BeginInit();
      this.mnuTimestamp.SuspendLayout();
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
      // nfoPanel
      // 
      this.nfoPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.nfoPanel.BackColor = System.Drawing.Color.WhiteSmoke;
      this.nfoPanel.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
      this.nfoPanel.InfoIcon = global::Com.Couchcoding.Logbert.Properties.Resources.StatusAnnotations_Information_16xLG;
      this.nfoPanel.Location = new System.Drawing.Point(0, 43);
      this.nfoPanel.Name = "nfoPanel";
      this.nfoPanel.ShowInfoIcon = true;
      this.nfoPanel.ShowTitle = false;
      this.nfoPanel.Size = new System.Drawing.Size(400, 64);
      this.nfoPanel.TabIndex = 2;
      this.nfoPanel.TextPadding = new System.Windows.Forms.Padding(0, 6, 0, 0);
      this.nfoPanel.Title = "";
      // 
      // chkMulticastGroup
      // 
      this.chkMulticastGroup.AutoSize = true;
      this.chkMulticastGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.chkMulticastGroup.Location = new System.Drawing.Point(0, 164);
      this.chkMulticastGroup.Name = "chkMulticastGroup";
      this.chkMulticastGroup.Size = new System.Drawing.Size(131, 18);
      this.chkMulticastGroup.TabIndex = 5;
      this.chkMulticastGroup.Text = "Join &Multicast Group:";
      this.chkMulticastGroup.UseVisualStyleBackColor = true;
      this.chkMulticastGroup.CheckedChanged += new System.EventHandler(this.ChkMulticastGroupCheckedChanged);
      // 
      // txtMulticastIp
      // 
      this.txtMulticastIp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtMulticastIp.Enabled = false;
      this.txtMulticastIp.Location = new System.Drawing.Point(134, 163);
      this.txtMulticastIp.Name = "txtMulticastIp";
      this.txtMulticastIp.Size = new System.Drawing.Size(266, 20);
      this.txtMulticastIp.TabIndex = 6;
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
            514,
            0,
            0,
            0});
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
      // txtTimestampFormat
      // 
      this.txtTimestampFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtTimestampFormat.ButtonText = "?";
      this.txtTimestampFormat.Location = new System.Drawing.Point(0, 208);
      this.txtTimestampFormat.Name = "txtTimestampFormat";
      this.txtTimestampFormat.Size = new System.Drawing.Size(400, 20);
      this.txtTimestampFormat.TabIndex = 8;
      this.txtTimestampFormat.ButtonClick += new System.EventHandler(this.TxtTimestampFormatButtonClick);
      // 
      // lblTimestampFormat
      // 
      this.lblTimestampFormat.AutoSize = true;
      this.lblTimestampFormat.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.lblTimestampFormat.Location = new System.Drawing.Point(0, 192);
      this.lblTimestampFormat.Name = "lblTimestampFormat";
      this.lblTimestampFormat.Size = new System.Drawing.Size(96, 13);
      this.lblTimestampFormat.TabIndex = 7;
      this.lblTimestampFormat.Text = "Timestamp Format:";
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
      this.mnuTimestamp.Size = new System.Drawing.Size(438, 670);
      // 
      // mnuTimestampPresets
      // 
      this.mnuTimestampPresets.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTimestampPreset1,
            this.mnuTimestampPreset2,
            this.mnuTimestampPreset3,
            this.mnuTimestampPreset4,
            this.yyyyMMddTHHmmssSSSToolStripMenuItem});
      this.mnuTimestampPresets.Name = "mnuTimestampPresets";
      this.mnuTimestampPresets.Size = new System.Drawing.Size(437, 22);
      this.mnuTimestampPresets.Text = "Presets";
      // 
      // mnuTimestampPreset1
      // 
      this.mnuTimestampPreset1.Name = "mnuTimestampPreset1";
      this.mnuTimestampPreset1.Size = new System.Drawing.Size(228, 22);
      this.mnuTimestampPreset1.Tag = "MMM d HH:mm:ss";
      this.mnuTimestampPreset1.Text = "MMM d HH:mm:ss";
      this.mnuTimestampPreset1.Click += new System.EventHandler(this.MnuTimestampPresetClick);
      // 
      // mnuTimestampPreset2
      // 
      this.mnuTimestampPreset2.Name = "mnuTimestampPreset2";
      this.mnuTimestampPreset2.Size = new System.Drawing.Size(228, 22);
      this.mnuTimestampPreset2.Tag = "MMM dd HH:mm:ss";
      this.mnuTimestampPreset2.Text = "MMM dd HH:mm:ss";
      this.mnuTimestampPreset2.Click += new System.EventHandler(this.MnuTimestampPresetClick);
      // 
      // mnuTimestampPreset3
      // 
      this.mnuTimestampPreset3.Name = "mnuTimestampPreset3";
      this.mnuTimestampPreset3.Size = new System.Drawing.Size(228, 22);
      this.mnuTimestampPreset3.Tag = "MMM dd yyyy HH:mm:ss";
      this.mnuTimestampPreset3.Text = "MMM dd yyyy HH:mm:ss";
      this.mnuTimestampPreset3.Click += new System.EventHandler(this.MnuTimestampPresetClick);
      // 
      // mnuTimestampPreset4
      // 
      this.mnuTimestampPreset4.Name = "mnuTimestampPreset4";
      this.mnuTimestampPreset4.Size = new System.Drawing.Size(228, 22);
      this.mnuTimestampPreset4.Tag = "yyyy-MM-dd HH:mm:ss,SSS";
      this.mnuTimestampPreset4.Text = "yyyy-MM-dd HH:mm:ss,SSS";
      this.mnuTimestampPreset4.Click += new System.EventHandler(this.MnuTimestampPresetClick);
      // 
      // yyyyMMddTHHmmssSSSToolStripMenuItem
      // 
      this.yyyyMMddTHHmmssSSSToolStripMenuItem.Name = "yyyyMMddTHHmmssSSSToolStripMenuItem";
      this.yyyyMMddTHHmmssSSSToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
      this.yyyyMMddTHHmmssSSSToolStripMenuItem.Text = "yyyy-MM-ddTHH:mm:ss,SSS";
      this.yyyyMMddTHHmmssSSSToolStripMenuItem.Click += new System.EventHandler(this.MnuTimestampPresetClick);
      // 
      // menuItem2
      // 
      this.menuItem2.Name = "menuItem2";
      this.menuItem2.Size = new System.Drawing.Size(434, 6);
      // 
      // mnuTimestamp_d
      // 
      this.mnuTimestamp_d.Name = "mnuTimestamp_d";
      this.mnuTimestamp_d.ShortcutKeyDisplayString = "The day of the month, from 1 through 31";
      this.mnuTimestamp_d.Size = new System.Drawing.Size(437, 22);
      this.mnuTimestamp_d.Tag = "d";
      this.mnuTimestamp_d.Text = "d";
      this.mnuTimestamp_d.Click += new System.EventHandler(this.MnuTimestampClick);
      // 
      // mnuTimestamp_dd
      // 
      this.mnuTimestamp_dd.Name = "mnuTimestamp_dd";
      this.mnuTimestamp_dd.ShortcutKeyDisplayString = "The day of the month, from 01 through 31";
      this.mnuTimestamp_dd.Size = new System.Drawing.Size(437, 22);
      this.mnuTimestamp_dd.Tag = "dd";
      this.mnuTimestamp_dd.Text = "dd";
      this.mnuTimestamp_dd.Click += new System.EventHandler(this.MnuTimestampClick);
      // 
      // mnuTimestamp_ddd
      // 
      this.mnuTimestamp_ddd.Name = "mnuTimestamp_ddd";
      this.mnuTimestamp_ddd.ShortcutKeyDisplayString = "The abbreviated name of the day of the week";
      this.mnuTimestamp_ddd.Size = new System.Drawing.Size(437, 22);
      this.mnuTimestamp_ddd.Tag = "ddd";
      this.mnuTimestamp_ddd.Text = "ddd";
      this.mnuTimestamp_ddd.Click += new System.EventHandler(this.MnuTimestampClick);
      // 
      // mnuTimestamp_dddd
      // 
      this.mnuTimestamp_dddd.Name = "mnuTimestamp_dddd";
      this.mnuTimestamp_dddd.ShortcutKeyDisplayString = "The full name of the day of the week";
      this.mnuTimestamp_dddd.Size = new System.Drawing.Size(437, 22);
      this.mnuTimestamp_dddd.Tag = "dddd";
      this.mnuTimestamp_dddd.Text = "dddd";
      this.mnuTimestamp_dddd.Click += new System.EventHandler(this.MnuTimestampClick);
      // 
      // mnuTimestamp_f
      // 
      this.mnuTimestamp_f.Name = "mnuTimestamp_f";
      this.mnuTimestamp_f.ShortcutKeyDisplayString = "The tenths of a second in a date and time value";
      this.mnuTimestamp_f.Size = new System.Drawing.Size(437, 22);
      this.mnuTimestamp_f.Tag = "f";
      this.mnuTimestamp_f.Text = "f";
      this.mnuTimestamp_f.Click += new System.EventHandler(this.MnuTimestampClick);
      // 
      // mnuTimestamp_ff
      // 
      this.mnuTimestamp_ff.Name = "mnuTimestamp_ff";
      this.mnuTimestamp_ff.ShortcutKeyDisplayString = "The hundredths of a second in a date and time value";
      this.mnuTimestamp_ff.Size = new System.Drawing.Size(437, 22);
      this.mnuTimestamp_ff.Tag = "ff";
      this.mnuTimestamp_ff.Text = "ff";
      this.mnuTimestamp_ff.Click += new System.EventHandler(this.MnuTimestampClick);
      // 
      // mnuTimestamp_fff
      // 
      this.mnuTimestamp_fff.Name = "mnuTimestamp_fff";
      this.mnuTimestamp_fff.ShortcutKeyDisplayString = "The milliseconds in a date and time value.";
      this.mnuTimestamp_fff.Size = new System.Drawing.Size(437, 22);
      this.mnuTimestamp_fff.Tag = "fff";
      this.mnuTimestamp_fff.Text = "fff";
      this.mnuTimestamp_fff.Click += new System.EventHandler(this.MnuTimestampClick);
      // 
      // mnuTimestamp_h
      // 
      this.mnuTimestamp_h.Name = "mnuTimestamp_h";
      this.mnuTimestamp_h.ShortcutKeyDisplayString = "The hour, using a 12-hour clock from 1 to 12";
      this.mnuTimestamp_h.Size = new System.Drawing.Size(437, 22);
      this.mnuTimestamp_h.Tag = "h";
      this.mnuTimestamp_h.Text = "h";
      this.mnuTimestamp_h.Click += new System.EventHandler(this.MnuTimestampClick);
      // 
      // mnuTimestamp_hh
      // 
      this.mnuTimestamp_hh.Name = "mnuTimestamp_hh";
      this.mnuTimestamp_hh.ShortcutKeyDisplayString = "The hour, using a 12-hour clock from 01 to 12";
      this.mnuTimestamp_hh.Size = new System.Drawing.Size(437, 22);
      this.mnuTimestamp_hh.Tag = "hh";
      this.mnuTimestamp_hh.Text = "hh";
      this.mnuTimestamp_hh.Click += new System.EventHandler(this.MnuTimestampClick);
      // 
      // mnuTimestamp_hhh
      // 
      this.mnuTimestamp_hhh.Name = "mnuTimestamp_hhh";
      this.mnuTimestamp_hhh.ShortcutKeyDisplayString = "The hour, using a 24-hour clock from 0 to 23";
      this.mnuTimestamp_hhh.Size = new System.Drawing.Size(437, 22);
      this.mnuTimestamp_hhh.Tag = "H";
      this.mnuTimestamp_hhh.Text = "H";
      this.mnuTimestamp_hhh.Click += new System.EventHandler(this.MnuTimestampClick);
      // 
      // mnuTimestamp_hhhh
      // 
      this.mnuTimestamp_hhhh.Name = "mnuTimestamp_hhhh";
      this.mnuTimestamp_hhhh.ShortcutKeyDisplayString = "The hour, using a 24-hour clock from 00 to 23";
      this.mnuTimestamp_hhhh.Size = new System.Drawing.Size(437, 22);
      this.mnuTimestamp_hhhh.Tag = "HH";
      this.mnuTimestamp_hhhh.Text = "HH";
      this.mnuTimestamp_hhhh.Click += new System.EventHandler(this.MnuTimestampClick);
      // 
      // mnuTimestamp_m
      // 
      this.mnuTimestamp_m.Name = "mnuTimestamp_m";
      this.mnuTimestamp_m.ShortcutKeyDisplayString = "The minute, from 0 through 59";
      this.mnuTimestamp_m.Size = new System.Drawing.Size(437, 22);
      this.mnuTimestamp_m.Tag = "m";
      this.mnuTimestamp_m.Text = "m";
      this.mnuTimestamp_m.Click += new System.EventHandler(this.MnuTimestampClick);
      // 
      // mnuTimestamp_mm
      // 
      this.mnuTimestamp_mm.Name = "mnuTimestamp_mm";
      this.mnuTimestamp_mm.ShortcutKeyDisplayString = "The minute, from 00 through 59";
      this.mnuTimestamp_mm.Size = new System.Drawing.Size(437, 22);
      this.mnuTimestamp_mm.Tag = "mm";
      this.mnuTimestamp_mm.Text = "mm";
      this.mnuTimestamp_mm.Click += new System.EventHandler(this.MnuTimestampClick);
      // 
      // mnuTimestamp_mmm
      // 
      this.mnuTimestamp_mmm.Name = "mnuTimestamp_mmm";
      this.mnuTimestamp_mmm.ShortcutKeyDisplayString = "The month, from 1 through 12";
      this.mnuTimestamp_mmm.Size = new System.Drawing.Size(437, 22);
      this.mnuTimestamp_mmm.Tag = "M";
      this.mnuTimestamp_mmm.Text = "M";
      this.mnuTimestamp_mmm.Click += new System.EventHandler(this.MnuTimestampClick);
      // 
      // mnuTimestamp_mmmm
      // 
      this.mnuTimestamp_mmmm.Name = "mnuTimestamp_mmmm";
      this.mnuTimestamp_mmmm.ShortcutKeyDisplayString = "The month, from 01 through 12";
      this.mnuTimestamp_mmmm.Size = new System.Drawing.Size(437, 22);
      this.mnuTimestamp_mmmm.Tag = "MM";
      this.mnuTimestamp_mmmm.Text = "MM";
      this.mnuTimestamp_mmmm.Click += new System.EventHandler(this.MnuTimestampClick);
      // 
      // mnuTimestamp_s
      // 
      this.mnuTimestamp_s.Name = "mnuTimestamp_s";
      this.mnuTimestamp_s.ShortcutKeyDisplayString = "The second, from 0 through 59";
      this.mnuTimestamp_s.Size = new System.Drawing.Size(437, 22);
      this.mnuTimestamp_s.Tag = "s";
      this.mnuTimestamp_s.Text = "s";
      this.mnuTimestamp_s.Click += new System.EventHandler(this.MnuTimestampClick);
      // 
      // mnuTimestamp_ss
      // 
      this.mnuTimestamp_ss.Name = "mnuTimestamp_ss";
      this.mnuTimestamp_ss.ShortcutKeyDisplayString = "The second, from 00 through 59";
      this.mnuTimestamp_ss.Size = new System.Drawing.Size(437, 22);
      this.mnuTimestamp_ss.Tag = "ss";
      this.mnuTimestamp_ss.Text = "ss";
      this.mnuTimestamp_ss.Click += new System.EventHandler(this.MnuTimestampClick);
      // 
      // mnuTimestamp_t
      // 
      this.mnuTimestamp_t.Name = "mnuTimestamp_t";
      this.mnuTimestamp_t.ShortcutKeyDisplayString = "The first character of the AM/PM designator";
      this.mnuTimestamp_t.Size = new System.Drawing.Size(437, 22);
      this.mnuTimestamp_t.Tag = "t";
      this.mnuTimestamp_t.Text = "t";
      this.mnuTimestamp_t.Click += new System.EventHandler(this.MnuTimestampClick);
      // 
      // mnuTimestamp_tt
      // 
      this.mnuTimestamp_tt.Name = "mnuTimestamp_tt";
      this.mnuTimestamp_tt.ShortcutKeyDisplayString = "The AM/PM designator";
      this.mnuTimestamp_tt.Size = new System.Drawing.Size(437, 22);
      this.mnuTimestamp_tt.Tag = "tt";
      this.mnuTimestamp_tt.Text = "tt";
      this.mnuTimestamp_tt.Click += new System.EventHandler(this.MnuTimestampClick);
      // 
      // mnuTimestamp_y
      // 
      this.mnuTimestamp_y.Name = "mnuTimestamp_y";
      this.mnuTimestamp_y.ShortcutKeyDisplayString = "The year, from 0 to 99";
      this.mnuTimestamp_y.Size = new System.Drawing.Size(437, 22);
      this.mnuTimestamp_y.Tag = "y";
      this.mnuTimestamp_y.Text = "y";
      this.mnuTimestamp_y.Click += new System.EventHandler(this.MnuTimestampClick);
      // 
      // mnuTimestamp_yy
      // 
      this.mnuTimestamp_yy.Name = "mnuTimestamp_yy";
      this.mnuTimestamp_yy.ShortcutKeyDisplayString = "The year, from 00 to 99";
      this.mnuTimestamp_yy.Size = new System.Drawing.Size(437, 22);
      this.mnuTimestamp_yy.Tag = "yy";
      this.mnuTimestamp_yy.Text = "yy";
      this.mnuTimestamp_yy.Click += new System.EventHandler(this.MnuTimestampClick);
      // 
      // mnuTimestamp_yyy
      // 
      this.mnuTimestamp_yyy.Name = "mnuTimestamp_yyy";
      this.mnuTimestamp_yyy.ShortcutKeyDisplayString = "The year, with a minimum of three digits";
      this.mnuTimestamp_yyy.Size = new System.Drawing.Size(437, 22);
      this.mnuTimestamp_yyy.Tag = "yyy";
      this.mnuTimestamp_yyy.Text = "yyy";
      this.mnuTimestamp_yyy.Click += new System.EventHandler(this.MnuTimestampClick);
      // 
      // mnuTimestamp_yyyy
      // 
      this.mnuTimestamp_yyyy.Name = "mnuTimestamp_yyyy";
      this.mnuTimestamp_yyyy.ShortcutKeyDisplayString = "The year as a four-digit number";
      this.mnuTimestamp_yyyy.Size = new System.Drawing.Size(437, 22);
      this.mnuTimestamp_yyyy.Tag = "yyyy";
      this.mnuTimestamp_yyyy.Text = "yyyy";
      this.mnuTimestamp_yyyy.Click += new System.EventHandler(this.MnuTimestampClick);
      // 
      // mnuTimestamp_z
      // 
      this.mnuTimestamp_z.Name = "mnuTimestamp_z";
      this.mnuTimestamp_z.ShortcutKeyDisplayString = "Hours offset from UTC, with no leading zeros";
      this.mnuTimestamp_z.Size = new System.Drawing.Size(437, 22);
      this.mnuTimestamp_z.Tag = "z";
      this.mnuTimestamp_z.Text = "z";
      this.mnuTimestamp_z.Click += new System.EventHandler(this.MnuTimestampClick);
      // 
      // mnuTimestamp_zz
      // 
      this.mnuTimestamp_zz.Name = "mnuTimestamp_zz";
      this.mnuTimestamp_zz.ShortcutKeyDisplayString = "Hours offset from UTC, with a leading zero for a single-digit value";
      this.mnuTimestamp_zz.Size = new System.Drawing.Size(437, 22);
      this.mnuTimestamp_zz.Tag = "zz";
      this.mnuTimestamp_zz.Text = "zz";
      this.mnuTimestamp_zz.Click += new System.EventHandler(this.MnuTimestampClick);
      // 
      // mnuTimestamp_zzz
      // 
      this.mnuTimestamp_zzz.Name = "mnuTimestamp_zzz";
      this.mnuTimestamp_zzz.ShortcutKeyDisplayString = "Hours and minutes offset from UTC";
      this.mnuTimestamp_zzz.Size = new System.Drawing.Size(437, 22);
      this.mnuTimestamp_zzz.Tag = "zzz";
      this.mnuTimestamp_zzz.Text = "zzz";
      this.mnuTimestamp_zzz.Click += new System.EventHandler(this.MnuTimestampClick);
      // 
      // mnuTimestamp_colon
      // 
      this.mnuTimestamp_colon.Name = "mnuTimestamp_colon";
      this.mnuTimestamp_colon.ShortcutKeyDisplayString = "The time separator";
      this.mnuTimestamp_colon.Size = new System.Drawing.Size(437, 22);
      this.mnuTimestamp_colon.Tag = ":";
      this.mnuTimestamp_colon.Text = ":";
      this.mnuTimestamp_colon.Click += new System.EventHandler(this.MnuTimestampClick);
      // 
      // mnuTimestamp_slash
      // 
      this.mnuTimestamp_slash.Name = "mnuTimestamp_slash";
      this.mnuTimestamp_slash.ShortcutKeyDisplayString = "The date separator";
      this.mnuTimestamp_slash.Size = new System.Drawing.Size(437, 22);
      this.mnuTimestamp_slash.Tag = "/";
      this.mnuTimestamp_slash.Text = "/";
      this.mnuTimestamp_slash.Click += new System.EventHandler(this.MnuTimestampClick);
      // 
      // mnuTimestamp_backslash
      // 
      this.mnuTimestamp_backslash.Name = "mnuTimestamp_backslash";
      this.mnuTimestamp_backslash.ShortcutKeyDisplayString = "The escape character";
      this.mnuTimestamp_backslash.Size = new System.Drawing.Size(437, 22);
      this.mnuTimestamp_backslash.Tag = "\\";
      this.mnuTimestamp_backslash.Text = "\\";
      this.mnuTimestamp_backslash.Click += new System.EventHandler(this.MnuTimestampClick);
      // 
      // SyslogUdpReceiverSettings
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.txtTimestampFormat);
      this.Controls.Add(this.lblTimestampFormat);
      this.Controls.Add(this.nudPort);
      this.Controls.Add(this.lblPort);
      this.Controls.Add(this.txtMulticastIp);
      this.Controls.Add(this.chkMulticastGroup);
      this.Controls.Add(this.nfoPanel);
      this.Controls.Add(this.cmbNetworkInterface);
      this.Controls.Add(this.lblNetworkInterface);
      this.Margin = new System.Windows.Forms.Padding(0);
      this.Name = "SyslogUdpReceiverSettings";
      this.Size = new System.Drawing.Size(400, 300);
      ((System.ComponentModel.ISupportInitialize)(this.nudPort)).EndInit();
      this.mnuTimestamp.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label lblNetworkInterface;
    private System.Windows.Forms.ComboBox cmbNetworkInterface;
    private GuiLibrary.Controls.InfoPanel nfoPanel;
    private System.Windows.Forms.CheckBox chkMulticastGroup;
    private System.Windows.Forms.TextBox txtMulticastIp;
    private System.Windows.Forms.NumericUpDown nudPort;
    private System.Windows.Forms.Label lblPort;
    private GuiLibrary.Controls.TextBoxEx txtTimestampFormat;
    private System.Windows.Forms.Label lblTimestampFormat;
    private System.Windows.Forms.ContextMenuStrip mnuTimestamp;
    private System.Windows.Forms.ToolStripMenuItem mnuTimestampPresets;
    private System.Windows.Forms.ToolStripMenuItem mnuTimestampPreset1;
    private System.Windows.Forms.ToolStripMenuItem mnuTimestampPreset2;
    private System.Windows.Forms.ToolStripMenuItem mnuTimestampPreset3;
    private System.Windows.Forms.ToolStripMenuItem mnuTimestampPreset4;
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
    private System.Windows.Forms.ToolStripMenuItem yyyyMMddTHHmmssSSSToolStripMenuItem;
  }
}
