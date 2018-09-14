namespace Couchcoding.Logbert.Receiver.SyslogFileReceiver
{
  partial class SyslogFileReceiverSettings
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
            this.txtLogFile = new Couchcoding.Logbert.Gui.Controls.TextBoxEx();
            this.chkStartFromBeginning = new System.Windows.Forms.CheckBox();
            this.txtTimestampFormat = new Couchcoding.Logbert.Gui.Controls.TextBoxEx();
            this.lblTimestampFormat = new System.Windows.Forms.Label();
            this.mnuTimestamp = new System.Windows.Forms.ContextMenu();
            this.mnuTimestampPresets = new System.Windows.Forms.MenuItem();
            this.mnuTimestampPreset1 = new System.Windows.Forms.MenuItem();
            this.mnuTimestampPreset2 = new System.Windows.Forms.MenuItem();
            this.mnuTimestampPreset3 = new System.Windows.Forms.MenuItem();
            this.mnuTimestampPreset4 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.mnuTimestamp_d = new System.Windows.Forms.MenuItem();
            this.mnuTimestamp_dd = new System.Windows.Forms.MenuItem();
            this.mnuTimestamp_ddd = new System.Windows.Forms.MenuItem();
            this.mnuTimestamp_dddd = new System.Windows.Forms.MenuItem();
            this.mnuTimestamp_f = new System.Windows.Forms.MenuItem();
            this.mnuTimestamp_ff = new System.Windows.Forms.MenuItem();
            this.mnuTimestamp_fff = new System.Windows.Forms.MenuItem();
            this.mnuTimestamp_h = new System.Windows.Forms.MenuItem();
            this.mnuTimestamp_hh = new System.Windows.Forms.MenuItem();
            this.mnuTimestamp_hhh = new System.Windows.Forms.MenuItem();
            this.mnuTimestamp_hhhh = new System.Windows.Forms.MenuItem();
            this.mnuTimestamp_m = new System.Windows.Forms.MenuItem();
            this.mnuTimestamp_mm = new System.Windows.Forms.MenuItem();
            this.mnuTimestamp_mmm = new System.Windows.Forms.MenuItem();
            this.mnuTimestamp_mmmm = new System.Windows.Forms.MenuItem();
            this.mnuTimestamp_s = new System.Windows.Forms.MenuItem();
            this.mnuTimestamp_ss = new System.Windows.Forms.MenuItem();
            this.mnuTimestamp_t = new System.Windows.Forms.MenuItem();
            this.mnuTimestamp_tt = new System.Windows.Forms.MenuItem();
            this.mnuTimestamp_y = new System.Windows.Forms.MenuItem();
            this.mnuTimestamp_yy = new System.Windows.Forms.MenuItem();
            this.mnuTimestamp_yyy = new System.Windows.Forms.MenuItem();
            this.mnuTimestamp_yyyy = new System.Windows.Forms.MenuItem();
            this.mnuTimestamp_z = new System.Windows.Forms.MenuItem();
            this.mnuTimestamp_zz = new System.Windows.Forms.MenuItem();
            this.mnuTimestamp_zzz = new System.Windows.Forms.MenuItem();
            this.mnuTimestamp_colon = new System.Windows.Forms.MenuItem();
            this.mnuTimestamp_slash = new System.Windows.Forms.MenuItem();
            this.mnuTimestamp_backslash = new System.Windows.Forms.MenuItem();
            this.lblEncoding = new System.Windows.Forms.Label();
            this.cmbEncoding = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
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
            // txtTimestampFormat
            // 
            this.txtTimestampFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimestampFormat.ButtonText = "?";
            this.txtTimestampFormat.Location = new System.Drawing.Point(0, 85);
            this.txtTimestampFormat.Name = "txtTimestampFormat";
            this.txtTimestampFormat.Size = new System.Drawing.Size(400, 20);
            this.txtTimestampFormat.TabIndex = 4;
            this.txtTimestampFormat.ButtonClick += new System.EventHandler(this.TxtTimestampFormatButtonClick);
            // 
            // lblTimestampFormat
            // 
            this.lblTimestampFormat.AutoSize = true;
            this.lblTimestampFormat.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTimestampFormat.Location = new System.Drawing.Point(0, 69);
            this.lblTimestampFormat.Name = "lblTimestampFormat";
            this.lblTimestampFormat.Size = new System.Drawing.Size(96, 13);
            this.lblTimestampFormat.TabIndex = 3;
            this.lblTimestampFormat.Text = "&Timestamp Format:";
            // 
            // mnuTimestamp
            // 
            this.mnuTimestamp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
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
            // 
            // mnuTimestampPresets
            // 
            this.mnuTimestampPresets.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuTimestampPreset1,
            this.mnuTimestampPreset2,
            this.mnuTimestampPreset3,
            this.mnuTimestampPreset4});
            this.mnuTimestampPresets.Name = "mnuTimestampPresets";
            this.mnuTimestampPresets.Text = "Presets";
            // 
            // mnuTimestampPreset1
            // 
            this.mnuTimestampPreset1.Name = "mnuTimestampPreset1";
            this.mnuTimestampPreset1.Tag = "HH:mm:ss";
            this.mnuTimestampPreset1.Text = "HH:mm:ss";
            this.mnuTimestampPreset1.Click += new System.EventHandler(this.MnuTimestampPresetClick);
            // 
            // mnuTimestampPreset2
            // 
            this.mnuTimestampPreset2.Name = "mnuTimestampPreset2";
            this.mnuTimestampPreset2.Tag = "HH:mm:ss.fff";
            this.mnuTimestampPreset2.Text = "HH:mm:ss.fff";
            this.mnuTimestampPreset2.Click += new System.EventHandler(this.MnuTimestampPresetClick);
            // 
            // mnuTimestampPreset3
            // 
            this.mnuTimestampPreset3.Name = "mnuTimestampPreset3";
            this.mnuTimestampPreset3.Tag = "MM/dd/yy HH:mm:ss";
            this.mnuTimestampPreset3.Text = "MM/dd/yy HH:mm:ss";
            this.mnuTimestampPreset3.Click += new System.EventHandler(this.MnuTimestampPresetClick);
            // 
            // mnuTimestampPreset4
            // 
            this.mnuTimestampPreset4.Name = "mnuTimestampPreset4";
            this.mnuTimestampPreset4.Tag = "MM/dd/yy HH:mm:ss.fff";
            this.mnuTimestampPreset4.Text = "MM/dd/yy HH:mm:ss.fff";
            this.mnuTimestampPreset4.Click += new System.EventHandler(this.MnuTimestampPresetClick);
            // 
            // menuItem2
            // 
            this.menuItem2.Name = "menuItem2";
            this.menuItem2.Text = "-";
            // 
            // mnuTimestamp_d
            // 
            this.mnuTimestamp_d.Name = "mnuTimestamp_d";
            this.mnuTimestamp_d.Tag = "d";
            this.mnuTimestamp_d.Text = "d\tThe day of the month, from 1 through 31";
            this.mnuTimestamp_d.Click += new System.EventHandler(this.MnuTimestampClick);
            // 
            // mnuTimestamp_dd
            // 
            this.mnuTimestamp_dd.Name = "mnuTimestamp_dd";
            this.mnuTimestamp_dd.Tag = "dd";
            this.mnuTimestamp_dd.Text = "dd\tThe day of the month, from 01 through 31";
            this.mnuTimestamp_dd.Click += new System.EventHandler(this.MnuTimestampClick);
            // 
            // mnuTimestamp_ddd
            // 
            this.mnuTimestamp_ddd.Name = "mnuTimestamp_ddd";
            this.mnuTimestamp_ddd.Tag = "ddd";
            this.mnuTimestamp_ddd.Text = "ddd\tThe abbreviated name of the day of the week";
            this.mnuTimestamp_ddd.Click += new System.EventHandler(this.MnuTimestampClick);
            // 
            // mnuTimestamp_dddd
            // 
            this.mnuTimestamp_dddd.Name = "mnuTimestamp_dddd";
            this.mnuTimestamp_dddd.Tag = "dddd";
            this.mnuTimestamp_dddd.Text = "dddd\tThe full name of the day of the week";
            this.mnuTimestamp_dddd.Click += new System.EventHandler(this.MnuTimestampClick);
            // 
            // mnuTimestamp_f
            // 
            this.mnuTimestamp_f.Name = "mnuTimestamp_f";
            this.mnuTimestamp_f.Tag = "f";
            this.mnuTimestamp_f.Text = "f\tThe tenths of a second in a date and time value";
            this.mnuTimestamp_f.Click += new System.EventHandler(this.MnuTimestampClick);
            // 
            // mnuTimestamp_ff
            // 
            this.mnuTimestamp_ff.Name = "mnuTimestamp_ff";
            this.mnuTimestamp_ff.Tag = "ff";
            this.mnuTimestamp_ff.Text = "ff\tThe hundredths of a second in a date and time value";
            this.mnuTimestamp_ff.Click += new System.EventHandler(this.MnuTimestampClick);
            // 
            // mnuTimestamp_fff
            // 
            this.mnuTimestamp_fff.Name = "mnuTimestamp_fff";
            this.mnuTimestamp_fff.Tag = "fff";
            this.mnuTimestamp_fff.Text = "fff\tThe milliseconds in a date and time value.";
            this.mnuTimestamp_fff.Click += new System.EventHandler(this.MnuTimestampClick);
            // 
            // mnuTimestamp_h
            // 
            this.mnuTimestamp_h.Name = "mnuTimestamp_h";
            this.mnuTimestamp_h.Tag = "h";
            this.mnuTimestamp_h.Text = "h\tThe hour, using a 12-hour clock from 1 to 12";
            this.mnuTimestamp_h.Click += new System.EventHandler(this.MnuTimestampClick);
            // 
            // mnuTimestamp_hh
            // 
            this.mnuTimestamp_hh.Name = "mnuTimestamp_hh";
            this.mnuTimestamp_hh.Tag = "hh";
            this.mnuTimestamp_hh.Text = "hh\tThe hour, using a 12-hour clock from 01 to 12";
            this.mnuTimestamp_hh.Click += new System.EventHandler(this.MnuTimestampClick);
            // 
            // mnuTimestamp_hhh
            // 
            this.mnuTimestamp_hhh.Name = "mnuTimestamp_hhh";
            this.mnuTimestamp_hhh.Tag = "H";
            this.mnuTimestamp_hhh.Text = "H\tThe hour, using a 24-hour clock from 0 to 23";
            this.mnuTimestamp_hhh.Click += new System.EventHandler(this.MnuTimestampClick);
            // 
            // mnuTimestamp_hhhh
            // 
            this.mnuTimestamp_hhhh.Name = "mnuTimestamp_hhhh";
            this.mnuTimestamp_hhhh.Tag = "HH";
            this.mnuTimestamp_hhhh.Text = "HH\tThe hour, using a 24-hour clock from 00 to 23";
            this.mnuTimestamp_hhhh.Click += new System.EventHandler(this.MnuTimestampClick);
            // 
            // mnuTimestamp_m
            // 
            this.mnuTimestamp_m.Name = "mnuTimestamp_m";
            this.mnuTimestamp_m.Tag = "m";
            this.mnuTimestamp_m.Text = "m\tThe minute, from 0 through 59";
            this.mnuTimestamp_m.Click += new System.EventHandler(this.MnuTimestampClick);
            // 
            // mnuTimestamp_mm
            // 
            this.mnuTimestamp_mm.Name = "mnuTimestamp_mm";
            this.mnuTimestamp_mm.Tag = "mm";
            this.mnuTimestamp_mm.Text = "mm\tThe minute, from 00 through 59";
            this.mnuTimestamp_mm.Click += new System.EventHandler(this.MnuTimestampClick);
            // 
            // mnuTimestamp_mmm
            // 
            this.mnuTimestamp_mmm.Name = "mnuTimestamp_mmm";
            this.mnuTimestamp_mmm.Tag = "M";
            this.mnuTimestamp_mmm.Text = "M\tThe month, from 1 through 12";
            this.mnuTimestamp_mmm.Click += new System.EventHandler(this.MnuTimestampClick);
            // 
            // mnuTimestamp_mmmm
            // 
            this.mnuTimestamp_mmmm.Name = "mnuTimestamp_mmmm";
            this.mnuTimestamp_mmmm.Tag = "MM";
            this.mnuTimestamp_mmmm.Text = "MM\tThe month, from 01 through 12";
            this.mnuTimestamp_mmmm.Click += new System.EventHandler(this.MnuTimestampClick);
            // 
            // mnuTimestamp_s
            // 
            this.mnuTimestamp_s.Name = "mnuTimestamp_s";
            this.mnuTimestamp_s.Tag = "s";
            this.mnuTimestamp_s.Text = "s\tThe second, from 0 through 59";
            this.mnuTimestamp_s.Click += new System.EventHandler(this.MnuTimestampClick);
            // 
            // mnuTimestamp_ss
            // 
            this.mnuTimestamp_ss.Name = "mnuTimestamp_ss";
            this.mnuTimestamp_ss.Tag = "ss";
            this.mnuTimestamp_ss.Text = "ss\tThe second, from 00 through 59";
            this.mnuTimestamp_ss.Click += new System.EventHandler(this.MnuTimestampClick);
            // 
            // mnuTimestamp_t
            // 
            this.mnuTimestamp_t.Name = "mnuTimestamp_t";
            this.mnuTimestamp_t.Tag = "t";
            this.mnuTimestamp_t.Text = "t\tThe first character of the AM/PM designator";
            this.mnuTimestamp_t.Click += new System.EventHandler(this.MnuTimestampClick);
            // 
            // mnuTimestamp_tt
            // 
            this.mnuTimestamp_tt.Name = "mnuTimestamp_tt";
            this.mnuTimestamp_tt.Tag = "tt";
            this.mnuTimestamp_tt.Text = "tt\tThe AM/PM designator";
            this.mnuTimestamp_tt.Click += new System.EventHandler(this.MnuTimestampClick);
            // 
            // mnuTimestamp_y
            // 
            this.mnuTimestamp_y.Name = "mnuTimestamp_y";
            this.mnuTimestamp_y.Tag = "y";
            this.mnuTimestamp_y.Text = "y\tThe year, from 0 to 99";
            this.mnuTimestamp_y.Click += new System.EventHandler(this.MnuTimestampClick);
            // 
            // mnuTimestamp_yy
            // 
            this.mnuTimestamp_yy.Name = "mnuTimestamp_yy";
            this.mnuTimestamp_yy.Tag = "yy";
            this.mnuTimestamp_yy.Text = "yy\tThe year, from 00 to 99";
            this.mnuTimestamp_yy.Click += new System.EventHandler(this.MnuTimestampClick);
            // 
            // mnuTimestamp_yyy
            // 
            this.mnuTimestamp_yyy.Name = "mnuTimestamp_yyy";
            this.mnuTimestamp_yyy.Tag = "yyy";
            this.mnuTimestamp_yyy.Text = "yyy\tThe year, with a minimum of three digits";
            this.mnuTimestamp_yyy.Click += new System.EventHandler(this.MnuTimestampClick);
            // 
            // mnuTimestamp_yyyy
            // 
            this.mnuTimestamp_yyyy.Name = "mnuTimestamp_yyyy";
            this.mnuTimestamp_yyyy.Tag = "yyyy";
            this.mnuTimestamp_yyyy.Text = "yyyy\tThe year as a four-digit number";
            this.mnuTimestamp_yyyy.Click += new System.EventHandler(this.MnuTimestampClick);
            // 
            // mnuTimestamp_z
            // 
            this.mnuTimestamp_z.Name = "mnuTimestamp_z";
            this.mnuTimestamp_z.Tag = "z";
            this.mnuTimestamp_z.Text = "z\tHours offset from UTC, with no leading zeros";
            this.mnuTimestamp_z.Click += new System.EventHandler(this.MnuTimestampClick);
            // 
            // mnuTimestamp_zz
            // 
            this.mnuTimestamp_zz.Name = "mnuTimestamp_zz";
            this.mnuTimestamp_zz.Tag = "zz";
            this.mnuTimestamp_zz.Text = "zz\tHours offset from UTC, with a leading zero for a single-digit value";
            this.mnuTimestamp_zz.Click += new System.EventHandler(this.MnuTimestampClick);
            // 
            // mnuTimestamp_zzz
            // 
            this.mnuTimestamp_zzz.Name = "mnuTimestamp_zzz";
            this.mnuTimestamp_zzz.Tag = "zzz";
            this.mnuTimestamp_zzz.Text = "zzz\tHours and minutes offset from UTC";
            this.mnuTimestamp_zzz.Click += new System.EventHandler(this.MnuTimestampClick);
            // 
            // mnuTimestamp_colon
            // 
            this.mnuTimestamp_colon.Name = "mnuTimestamp_colon";
            this.mnuTimestamp_colon.Tag = ":";
            this.mnuTimestamp_colon.Text = ":\tThe time separator";
            this.mnuTimestamp_colon.Click += new System.EventHandler(this.MnuTimestampClick);
            // 
            // mnuTimestamp_slash
            // 
            this.mnuTimestamp_slash.Name = "mnuTimestamp_slash";
            this.mnuTimestamp_slash.Tag = "/";
            this.mnuTimestamp_slash.Text = "/\tThe date separator";
            this.mnuTimestamp_slash.Click += new System.EventHandler(this.MnuTimestampClick);
            // 
            // mnuTimestamp_backslash
            // 
            this.mnuTimestamp_backslash.Name = "mnuTimestamp_backslash";
            this.mnuTimestamp_backslash.Tag = "\\";
            this.mnuTimestamp_backslash.Text = "\\\tThe escape character";
            this.mnuTimestamp_backslash.Click += new System.EventHandler(this.MnuTimestampClick);
            // 
            // lblEncoding
            // 
            this.lblEncoding.AutoSize = true;
            this.lblEncoding.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEncoding.Location = new System.Drawing.Point(0, 114);
            this.lblEncoding.Name = "lblEncoding";
            this.lblEncoding.Size = new System.Drawing.Size(55, 13);
            this.lblEncoding.TabIndex = 5;
            this.lblEncoding.Text = "&Encoding:";
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
            this.cmbEncoding.TabIndex = 6;
            // 
            // SyslogFileReceiverSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbEncoding);
            this.Controls.Add(this.lblEncoding);
            this.Controls.Add(this.txtTimestampFormat);
            this.Controls.Add(this.lblTimestampFormat);
            this.Controls.Add(this.chkStartFromBeginning);
            this.Controls.Add(this.txtLogFile);
            this.Controls.Add(this.lblNetworkInterface);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MinimumSize = new System.Drawing.Size(0, 153);
            this.Name = "SyslogFileReceiverSettings";
            this.Size = new System.Drawing.Size(400, 300);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label lblNetworkInterface;
    private Gui.Controls.TextBoxEx txtLogFile;
    private System.Windows.Forms.CheckBox chkStartFromBeginning;
    private Gui.Controls.TextBoxEx txtTimestampFormat;
    private System.Windows.Forms.Label lblTimestampFormat;
    private System.Windows.Forms.ContextMenu mnuTimestamp;
    private System.Windows.Forms.MenuItem mnuTimestampPresets;
    private System.Windows.Forms.MenuItem menuItem2;
    private System.Windows.Forms.MenuItem mnuTimestamp_d;
    private System.Windows.Forms.MenuItem mnuTimestamp_dd;
    private System.Windows.Forms.MenuItem mnuTimestamp_ddd;
    private System.Windows.Forms.MenuItem mnuTimestamp_dddd;
    private System.Windows.Forms.MenuItem mnuTimestamp_f;
    private System.Windows.Forms.MenuItem mnuTimestamp_ff;
    private System.Windows.Forms.MenuItem mnuTimestamp_fff;
    private System.Windows.Forms.MenuItem mnuTimestamp_h;
    private System.Windows.Forms.MenuItem mnuTimestamp_hh;
    private System.Windows.Forms.MenuItem mnuTimestamp_hhh;
    private System.Windows.Forms.MenuItem mnuTimestamp_hhhh;
    private System.Windows.Forms.MenuItem mnuTimestamp_m;
    private System.Windows.Forms.MenuItem mnuTimestamp_mm;
    private System.Windows.Forms.MenuItem mnuTimestamp_mmm;
    private System.Windows.Forms.MenuItem mnuTimestamp_mmmm;
    private System.Windows.Forms.MenuItem mnuTimestamp_s;
    private System.Windows.Forms.MenuItem mnuTimestamp_ss;
    private System.Windows.Forms.MenuItem mnuTimestamp_t;
    private System.Windows.Forms.MenuItem mnuTimestamp_tt;
    private System.Windows.Forms.MenuItem mnuTimestamp_y;
    private System.Windows.Forms.MenuItem mnuTimestamp_yy;
    private System.Windows.Forms.MenuItem mnuTimestamp_yyy;
    private System.Windows.Forms.MenuItem mnuTimestamp_yyyy;
    private System.Windows.Forms.MenuItem mnuTimestamp_z;
    private System.Windows.Forms.MenuItem mnuTimestamp_zz;
    private System.Windows.Forms.MenuItem mnuTimestamp_zzz;
    private System.Windows.Forms.MenuItem mnuTimestamp_colon;
    private System.Windows.Forms.MenuItem mnuTimestamp_slash;
    private System.Windows.Forms.MenuItem mnuTimestamp_backslash;
    private System.Windows.Forms.MenuItem mnuTimestampPreset1;
    private System.Windows.Forms.MenuItem mnuTimestampPreset2;
    private System.Windows.Forms.MenuItem mnuTimestampPreset3;
    private System.Windows.Forms.MenuItem mnuTimestampPreset4;
    private System.Windows.Forms.Label lblEncoding;
    private System.Windows.Forms.ComboBox cmbEncoding;
  }
}
