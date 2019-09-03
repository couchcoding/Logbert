using System.Windows.Forms;

namespace Logbert
{
  partial class MainForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.timeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.levelColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.loggerColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.threadColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.msgColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mainDockPanel = new Couchcoding.Logbert.Controls.DockPanelEx();
            this.mnuMain = new Couchcoding.Logbert.Gui.Controls.MenuStripEx();
            this.mnuMainFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMainFileNewLogger = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMainFileOpelLogFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMainFileSeperator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuMainFileRecentFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMainFileSeperator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuMainFileCloseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMainFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMainEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMainEditFind = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMainEditFindNext = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMainExtras = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMainExtrasOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMainHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMainHelpHomepage = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMainAboutSeperator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuMainHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // timeColumnHeader
            // 
            this.timeColumnHeader.Text = "Time";
            this.timeColumnHeader.Width = 120;
            // 
            // levelColumnHeader
            // 
            this.levelColumnHeader.Text = "Level";
            this.levelColumnHeader.Width = 48;
            // 
            // loggerColumnHeader
            // 
            this.loggerColumnHeader.Text = "Logger";
            this.loggerColumnHeader.Width = 92;
            // 
            // threadColumnHeader
            // 
            this.threadColumnHeader.Text = "Thread";
            this.threadColumnHeader.Width = 52;
            // 
            // msgColumnHeader
            // 
            this.msgColumnHeader.Text = "Message";
            this.msgColumnHeader.Width = 751;
            // 
            // mainDockPanel
            // 
            this.mainDockPanel.AllowDrop = true;
            this.mainDockPanel.BackgroundImage = global::Couchcoding.Logbert.Properties.Resources.Logbert_Start_Screen;
            this.mainDockPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mainDockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainDockPanel.Theme = new WeifenLuo.WinFormsUI.Docking.VS2015LightTheme();
            this.mainDockPanel.DocumentStyle = WeifenLuo.WinFormsUI.Docking.DocumentStyle.DockingWindow;
            this.mainDockPanel.Location = new System.Drawing.Point(0, 24);
            this.mainDockPanel.Name = "mainDockPanel";
            this.mainDockPanel.Size = new System.Drawing.Size(1008, 642);
            this.mainDockPanel.TabIndex = 0;
            this.mainDockPanel.ContentAdded += new System.EventHandler<WeifenLuo.WinFormsUI.Docking.DockContentEventArgs>(this.MainDockPanelContentAdded);
            this.mainDockPanel.ContentRemoved += new System.EventHandler<WeifenLuo.WinFormsUI.Docking.DockContentEventArgs>(this.MainDockPanelContentRemoved);
            this.mainDockPanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.mainDockPanel.DragOver += new System.Windows.Forms.DragEventHandler(this.MainForm_DragOver);
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMainFile,
            this.mnuMainEdit,
            this.mnuMainExtras,
            this.mnuMainHelp});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(1008, 24);
            this.mnuMain.TabIndex = 1;
            this.mnuMain.Text = "Main Menu";
            // 
            // mnuMainFile
            // 
            this.mnuMainFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMainFileNewLogger,
            this.mnuMainFileOpelLogFile,
            this.mnuMainFileSeperator1,
            this.mnuMainFileRecentFiles,
            this.mnuMainFileSeperator2,
            this.mnuMainFileCloseAll,
            this.mnuMainFileExit});
            this.mnuMainFile.Name = "mnuMainFile";
            this.mnuMainFile.Size = new System.Drawing.Size(37, 20);
            this.mnuMainFile.Text = "&File";
            this.mnuMainFile.DropDownOpening += new System.EventHandler(this.MnuMainFileOpening);
            // 
            // mnuMainFileNewLogger
            // 
            this.mnuMainFileNewLogger.Name = "mnuMainFileNewLogger";
            this.mnuMainFileNewLogger.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.mnuMainFileNewLogger.Size = new System.Drawing.Size(199, 22);
            this.mnuMainFileNewLogger.Text = "&New Logger...";
            this.mnuMainFileNewLogger.Click += new System.EventHandler(this.MnuMainFileNewLoggerClick);
            // 
            // mnuMainFileOpelLogFile
            // 
            this.mnuMainFileOpelLogFile.Name = "mnuMainFileOpelLogFile";
            this.mnuMainFileOpelLogFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuMainFileOpelLogFile.Size = new System.Drawing.Size(199, 22);
            this.mnuMainFileOpelLogFile.Text = "&Open Log File...";
            this.mnuMainFileOpelLogFile.Click += new System.EventHandler(this.MnuMainFileOpenLogFileClick);
            // 
            // mnuMainFileSeperator1
            // 
            this.mnuMainFileSeperator1.Name = "mnuMainFileSeperator1";
            this.mnuMainFileSeperator1.Size = new System.Drawing.Size(196, 6);
            // 
            // mnuMainFileRecentFiles
            // 
            this.mnuMainFileRecentFiles.Enabled = false;
            this.mnuMainFileRecentFiles.Name = "mnuMainFileRecentFiles";
            this.mnuMainFileRecentFiles.Size = new System.Drawing.Size(199, 22);
            this.mnuMainFileRecentFiles.Text = "Recent &Files";
            // 
            // mnuMainFileSeperator2
            // 
            this.mnuMainFileSeperator2.Name = "mnuMainFileSeperator2";
            this.mnuMainFileSeperator2.Size = new System.Drawing.Size(196, 6);
            // 
            // mnuMainFileCloseAll
            // 
            this.mnuMainFileCloseAll.Enabled = false;
            this.mnuMainFileCloseAll.Name = "mnuMainFileCloseAll";
            this.mnuMainFileCloseAll.Size = new System.Drawing.Size(199, 22);
            this.mnuMainFileCloseAll.Text = "&Close All";
            this.mnuMainFileCloseAll.Click += new System.EventHandler(this.MnuMainFileCloseAllClick);
            // 
            // mnuMainFileExit
            // 
            this.mnuMainFileExit.Name = "mnuMainFileExit";
            this.mnuMainFileExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.mnuMainFileExit.Size = new System.Drawing.Size(199, 22);
            this.mnuMainFileExit.Text = "&Exit";
            this.mnuMainFileExit.Click += new System.EventHandler(this.MnuMainFileExitClick);
            // 
            // mnuMainEdit
            // 
            this.mnuMainEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMainEditFind,
            this.mnuMainEditFindNext});
            this.mnuMainEdit.Name = "mnuMainEdit";
            this.mnuMainEdit.Size = new System.Drawing.Size(39, 20);
            this.mnuMainEdit.Text = "&Edit";
            // 
            // mnuMainEditFind
            // 
            this.mnuMainEditFind.Name = "mnuMainEditFind";
            this.mnuMainEditFind.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.mnuMainEditFind.Size = new System.Drawing.Size(146, 22);
            this.mnuMainEditFind.Text = "&Find...";
            this.mnuMainEditFind.Click += new System.EventHandler(this.MnuMainEditFindClick);
            // 
            // mnuMainEditFindNext
            // 
            this.mnuMainEditFindNext.Name = "mnuMainEditFindNext";
            this.mnuMainEditFindNext.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.mnuMainEditFindNext.Size = new System.Drawing.Size(146, 22);
            this.mnuMainEditFindNext.Text = "Find &next";
            this.mnuMainEditFindNext.Click += new System.EventHandler(this.MnuMainEditFindNextClick);
            // 
            // mnuMainExtras
            // 
            this.mnuMainExtras.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMainExtrasOptions});
            this.mnuMainExtras.Name = "mnuMainExtras";
            this.mnuMainExtras.Size = new System.Drawing.Size(49, 20);
            this.mnuMainExtras.Text = "&Extras";
            // 
            // mnuMainExtrasOptions
            // 
            this.mnuMainExtrasOptions.Name = "mnuMainExtrasOptions";
            this.mnuMainExtrasOptions.Size = new System.Drawing.Size(125, 22);
            this.mnuMainExtrasOptions.Text = "&Options...";
            this.mnuMainExtrasOptions.Click += new System.EventHandler(this.mnuMainExtrasOptions_Click);
            // 
            // mnuMainHelp
            // 
            this.mnuMainHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMainHelpHomepage,
            this.mnuMainAboutSeperator1,
            this.mnuMainHelpAbout});
            this.mnuMainHelp.Name = "mnuMainHelp";
            this.mnuMainHelp.Size = new System.Drawing.Size(44, 20);
            this.mnuMainHelp.Text = "&Help";
            // 
            // mnuMainHelpHomepage
            // 
            this.mnuMainHelpHomepage.Name = "mnuMainHelpHomepage";
            this.mnuMainHelpHomepage.Size = new System.Drawing.Size(177, 22);
            this.mnuMainHelpHomepage.Text = "Logbert &Homepage";
            this.mnuMainHelpHomepage.Click += new System.EventHandler(this.MnuMainHomepageClick);
            // 
            // mnuMainAboutSeperator1
            // 
            this.mnuMainAboutSeperator1.Name = "mnuMainAboutSeperator1";
            this.mnuMainAboutSeperator1.Size = new System.Drawing.Size(174, 6);
            // 
            // mnuMainHelpAbout
            // 
            this.mnuMainHelpAbout.Name = "mnuMainHelpAbout";
            this.mnuMainHelpAbout.Size = new System.Drawing.Size(177, 22);
            this.mnuMainHelpAbout.Text = "&About...";
            this.mnuMainHelpAbout.Click += new System.EventHandler(this.MnuMainHelpAboutClick);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1008, 666);
            this.Controls.Add(this.mainDockPanel);
            this.Controls.Add(this.mnuMain);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuMain;
            this.Name = "MainForm";
            this.Text = "Logbert";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.MainForm_DragOver);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ColumnHeader timeColumnHeader;
    private System.Windows.Forms.ColumnHeader levelColumnHeader;
    private System.Windows.Forms.ColumnHeader loggerColumnHeader;
    private System.Windows.Forms.ColumnHeader threadColumnHeader;
    private System.Windows.Forms.ColumnHeader msgColumnHeader;
    private Couchcoding.Logbert.Controls.DockPanelEx mainDockPanel;
    private Couchcoding.Logbert.Gui.Controls.MenuStripEx mnuMain;
    private ToolStripMenuItem mnuMainFile;
    private ToolStripMenuItem mnuMainFileNewLogger;
    private ToolStripMenuItem mnuMainFileOpelLogFile;
    private ToolStripSeparator mnuMainFileSeperator1;
    private ToolStripMenuItem mnuMainFileRecentFiles;
    private ToolStripSeparator mnuMainFileSeperator2;
    private ToolStripMenuItem mnuMainFileExit;
    private ToolStripMenuItem mnuMainEdit;
    private ToolStripMenuItem mnuMainExtras;
    private ToolStripMenuItem mnuMainHelp;
    private ToolStripMenuItem mnuMainEditFind;
    private ToolStripMenuItem mnuMainEditFindNext;
    private ToolStripMenuItem mnuMainExtrasOptions;
    private ToolStripMenuItem mnuMainHelpAbout;
    private ToolStripMenuItem mnuMainFileCloseAll;
    private ToolStripMenuItem mnuMainHelpHomepage;
    private ToolStripSeparator mnuMainAboutSeperator1;
  }
}

