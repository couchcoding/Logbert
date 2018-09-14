namespace Couchcoding.Logbert.Dialogs.Docking
{
    partial class FrmWelcome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWelcome));
            this.tblWelcome = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblOnlineRecources = new System.Windows.Forms.Label();
            this.flOnlineResources = new System.Windows.Forms.FlowLayoutPanel();
            this.lnkLogbertHomepage = new Couchcoding.Logbert.Gui.Controls.LinkLabelEx();
            this.lnkLog4NetExamples = new Couchcoding.Logbert.Gui.Controls.LinkLabelEx();
            this.lnkNlogExamples = new Couchcoding.Logbert.Gui.Controls.LinkLabelEx();
            this.tblWelcomeLogger = new System.Windows.Forms.TableLayoutPanel();
            this.lstLogger = new Controls.ThemedListBoxEx();
            this.lblNewLogger = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblRecentFiles = new System.Windows.Forms.Label();
            this.flRecentFiles = new System.Windows.Forms.FlowLayoutPanel();
            this.tlTip = new System.Windows.Forms.ToolTip(this.components);
            this.nfoBgPanel = new Couchcoding.Logbert.Gui.Controls.InfoPanel();
            this.tblWelcome.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.flOnlineResources.SuspendLayout();
            this.tblWelcomeLogger.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.nfoBgPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblWelcome
            // 
            this.tblWelcome.ColumnCount = 2;
            this.tblWelcome.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tblWelcome.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tblWelcome.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.tblWelcome.Controls.Add(this.tblWelcomeLogger, 0, 0);
            this.tblWelcome.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.tblWelcome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblWelcome.Location = new System.Drawing.Point(1, 1);
            this.tblWelcome.Margin = new System.Windows.Forms.Padding(0);
            this.tblWelcome.Name = "tblWelcome";
            this.tblWelcome.RowCount = 2;
            this.tblWelcome.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tblWelcome.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tblWelcome.Size = new System.Drawing.Size(638, 478);
            this.tblWelcome.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.lblOnlineRecources, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.flOnlineResources, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(258, 289);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(377, 186);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // lblOnlineRecources
            // 
            this.lblOnlineRecources.AutoSize = true;
            this.lblOnlineRecources.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOnlineRecources.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOnlineRecources.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblOnlineRecources.Location = new System.Drawing.Point(3, 0);
            this.lblOnlineRecources.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.lblOnlineRecources.Name = "lblOnlineRecources";
            this.lblOnlineRecources.Size = new System.Drawing.Size(230, 31);
            this.lblOnlineRecources.TabIndex = 1;
            this.lblOnlineRecources.Text = "Online Recources";
            // 
            // flOnlineResources
            // 
            this.flOnlineResources.Controls.Add(this.lnkLogbertHomepage);
            this.flOnlineResources.Controls.Add(this.lnkLog4NetExamples);
            this.flOnlineResources.Controls.Add(this.lnkNlogExamples);
            this.flOnlineResources.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flOnlineResources.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flOnlineResources.Location = new System.Drawing.Point(0, 41);
            this.flOnlineResources.Margin = new System.Windows.Forms.Padding(0);
            this.flOnlineResources.Name = "flOnlineResources";
            this.flOnlineResources.Size = new System.Drawing.Size(377, 145);
            this.flOnlineResources.TabIndex = 2;
            // 
            // lnkLogbertHomepage
            // 
            this.lnkLogbertHomepage.ActiveLinkColor = System.Drawing.SystemColors.ActiveCaption;
            this.lnkLogbertHomepage.AutoSize = true;
            this.lnkLogbertHomepage.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkLogbertHomepage.LinkColor = System.Drawing.SystemColors.ControlText;
            this.lnkLogbertHomepage.Location = new System.Drawing.Point(3, 0);
            this.lnkLogbertHomepage.Name = "lnkLogbertHomepage";
            this.lnkLogbertHomepage.Padding = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.lnkLogbertHomepage.Size = new System.Drawing.Size(98, 33);
            this.lnkLogbertHomepage.TabIndex = 0;
            this.lnkLogbertHomepage.TabStop = true;
            this.lnkLogbertHomepage.Tag = "https://github.com/couchcoding/Logbert";
            this.lnkLogbertHomepage.Text = "Logbert Homepage";
            this.tlTip.SetToolTip(this.lnkLogbertHomepage, "https://github.com/couchcoding/Logbert");
            this.lnkLogbertHomepage.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.lnkLogbertHomepage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelClicked);
            // 
            // lnkLog4NetExamples
            // 
            this.lnkLog4NetExamples.ActiveLinkColor = System.Drawing.SystemColors.ActiveCaption;
            this.lnkLog4NetExamples.AutoSize = true;
            this.lnkLog4NetExamples.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkLog4NetExamples.LinkColor = System.Drawing.SystemColors.ControlText;
            this.lnkLog4NetExamples.Location = new System.Drawing.Point(3, 33);
            this.lnkLog4NetExamples.Name = "lnkLog4NetExamples";
            this.lnkLog4NetExamples.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.lnkLog4NetExamples.Size = new System.Drawing.Size(172, 23);
            this.lnkLog4NetExamples.TabIndex = 1;
            this.lnkLog4NetExamples.TabStop = true;
            this.lnkLog4NetExamples.Tag = "https://logging.apache.org/log4net/release/config-examples.html";
            this.lnkLog4NetExamples.Text = "Apache log4net™ Config Examples";
            this.tlTip.SetToolTip(this.lnkLog4NetExamples, "https://logging.apache.org/log4net/release/config-examples.html");
            this.lnkLog4NetExamples.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.lnkLog4NetExamples.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelClicked);
            // 
            // lnkNlogExamples
            // 
            this.lnkNlogExamples.ActiveLinkColor = System.Drawing.SystemColors.ActiveCaption;
            this.lnkNlogExamples.AutoSize = true;
            this.lnkNlogExamples.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkNlogExamples.LinkColor = System.Drawing.SystemColors.ControlText;
            this.lnkNlogExamples.Location = new System.Drawing.Point(3, 56);
            this.lnkNlogExamples.Name = "lnkNlogExamples";
            this.lnkNlogExamples.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.lnkNlogExamples.Size = new System.Drawing.Size(114, 23);
            this.lnkNlogExamples.TabIndex = 2;
            this.lnkNlogExamples.TabStop = true;
            this.lnkNlogExamples.Tag = "https://github.com/nlog/nlog/wiki/Examples";
            this.lnkNlogExamples.Text = "NLog Config Examples";
            this.tlTip.SetToolTip(this.lnkNlogExamples, "https://github.com/nlog/nlog/wiki/Examples");
            this.lnkNlogExamples.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.lnkNlogExamples.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelClicked);
            // 
            // tblWelcomeLogger
            // 
            this.tblWelcomeLogger.ColumnCount = 1;
            this.tblWelcomeLogger.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblWelcomeLogger.Controls.Add(this.lstLogger, 0, 1);
            this.tblWelcomeLogger.Controls.Add(this.lblNewLogger, 0, 0);
            this.tblWelcomeLogger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblWelcomeLogger.Location = new System.Drawing.Point(3, 3);
            this.tblWelcomeLogger.Name = "tblWelcomeLogger";
            this.tblWelcomeLogger.RowCount = 2;
            this.tblWelcome.SetRowSpan(this.tblWelcomeLogger, 2);
            this.tblWelcomeLogger.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblWelcomeLogger.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblWelcomeLogger.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblWelcomeLogger.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblWelcomeLogger.Size = new System.Drawing.Size(249, 472);
            this.tblWelcomeLogger.TabIndex = 0;
            // 
            // lstLogger
            // 
            this.lstLogger.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstLogger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstLogger.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.lstLogger.FormattingEnabled = true;
            this.lstLogger.IntegralHeight = false;
            this.lstLogger.ItemHeight = 24;
            this.lstLogger.Location = new System.Drawing.Point(3, 44);
            this.lstLogger.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.lstLogger.Name = "lstLogger";
            this.lstLogger.Size = new System.Drawing.Size(226, 425);
            this.lstLogger.TabIndex = 3;
            this.lstLogger.Click += new System.EventHandler(this.LoggerSelected);
            this.lstLogger.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LstLoggerKeyDown);
            // 
            // lblNewLogger
            // 
            this.lblNewLogger.AutoSize = true;
            this.lblNewLogger.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblNewLogger.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewLogger.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblNewLogger.Location = new System.Drawing.Point(3, 0);
            this.lblNewLogger.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.lblNewLogger.Name = "lblNewLogger";
            this.lblNewLogger.Size = new System.Drawing.Size(160, 31);
            this.lblNewLogger.TabIndex = 0;
            this.lblNewLogger.Text = "New Logger";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lblRecentFiles, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flRecentFiles, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(258, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(377, 280);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // lblRecentFiles
            // 
            this.lblRecentFiles.AutoSize = true;
            this.lblRecentFiles.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblRecentFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecentFiles.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblRecentFiles.Location = new System.Drawing.Point(3, 0);
            this.lblRecentFiles.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.lblRecentFiles.Name = "lblRecentFiles";
            this.lblRecentFiles.Size = new System.Drawing.Size(166, 31);
            this.lblRecentFiles.TabIndex = 1;
            this.lblRecentFiles.Text = "Recent Files";
            // 
            // flRecentFiles
            // 
            this.flRecentFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flRecentFiles.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flRecentFiles.Location = new System.Drawing.Point(0, 41);
            this.flRecentFiles.Margin = new System.Windows.Forms.Padding(0);
            this.flRecentFiles.Name = "flRecentFiles";
            this.flRecentFiles.Size = new System.Drawing.Size(377, 239);
            this.flRecentFiles.TabIndex = 2;
            this.flRecentFiles.WrapContents = false;
            // 
            // nfoBgPanel
            // 
            this.nfoBgPanel.BackColor = System.Drawing.Color.White;
            this.nfoBgPanel.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.nfoBgPanel.Controls.Add(this.tblWelcome);
            this.nfoBgPanel.Location = new System.Drawing.Point(65, 45);
            this.nfoBgPanel.Name = "nfoBgPanel";
            this.nfoBgPanel.Padding = new System.Windows.Forms.Padding(1);
            this.nfoBgPanel.Size = new System.Drawing.Size(640, 480);
            this.nfoBgPanel.TabIndex = 1;
            this.nfoBgPanel.TextPadding = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.nfoBgPanel.Title = null;
            // 
            // FrmWelcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(640, 480);
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::Couchcoding.Logbert.Properties.Resources.Logbert_Logo_Background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.nfoBgPanel);
            this.DockAreas = WeifenLuo.WinFormsUI.Docking.DockAreas.Document;
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmWelcome";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.Document;
            this.TabText = "Welcome";
            this.Text = "Welcome";
            this.tblWelcome.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.flOnlineResources.ResumeLayout(false);
            this.flOnlineResources.PerformLayout();
            this.tblWelcomeLogger.ResumeLayout(false);
            this.tblWelcomeLogger.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.nfoBgPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblWelcome;
        private System.Windows.Forms.TableLayoutPanel tblWelcomeLogger;
        private System.Windows.Forms.Label lblNewLogger;
        private Controls.ThemedListBoxEx lstLogger;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblOnlineRecources;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblRecentFiles;
        private System.Windows.Forms.FlowLayoutPanel flOnlineResources;
        private Gui.Controls.LinkLabelEx lnkLogbertHomepage;
        private Gui.Controls.LinkLabelEx lnkLog4NetExamples;
        private Gui.Controls.LinkLabelEx lnkNlogExamples;
        private System.Windows.Forms.FlowLayoutPanel flRecentFiles;
        private System.Windows.Forms.ToolTip tlTip;
        private Gui.Controls.InfoPanel nfoBgPanel;
    }
}
