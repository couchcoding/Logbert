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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.timeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.levelColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.loggerColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.threadColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.msgColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.mnuMain = new System.Windows.Forms.MainMenu(this.components);
      this.mnuMainFile = new System.Windows.Forms.MenuItem();
      this.mnuMainFileNewLogger = new System.Windows.Forms.MenuItem();
      this.mnuMainFileOpenLogFile = new System.Windows.Forms.MenuItem();
      this.menuItem2 = new System.Windows.Forms.MenuItem();
      this.mnuMainFileRecentFiles = new System.Windows.Forms.MenuItem();
      this.menuItem16 = new System.Windows.Forms.MenuItem();
      this.mnuMainFileExit = new System.Windows.Forms.MenuItem();
      this.mnuMainEdit = new System.Windows.Forms.MenuItem();
      this.mnuMainEditFind = new System.Windows.Forms.MenuItem();
      this.mnuMainEditFindNext = new System.Windows.Forms.MenuItem();
      this.mnuMainExtras = new System.Windows.Forms.MenuItem();
      this.mnuMainExtrasOptions = new System.Windows.Forms.MenuItem();
      this.mnuMainHelp = new System.Windows.Forms.MenuItem();
      this.mnuMainHelpAbout = new System.Windows.Forms.MenuItem();
      this.mainDockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
      this.VS2012LightTheme = new WeifenLuo.WinFormsUI.Docking.VS2012LightTheme();
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
      // mnuMain
      // 
      this.mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuMainFile,
            this.mnuMainEdit,
            this.mnuMainExtras,
            this.mnuMainHelp});
      // 
      // mnuMainFile
      // 
      this.mnuMainFile.Index = 0;
      this.mnuMainFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuMainFileNewLogger,
            this.mnuMainFileOpenLogFile,
            this.menuItem2,
            this.mnuMainFileRecentFiles,
            this.menuItem16,
            this.mnuMainFileExit});
      this.mnuMainFile.Text = "&File";
      // 
      // mnuMainFileNewLogger
      // 
      this.mnuMainFileNewLogger.Index = 0;
      this.mnuMainFileNewLogger.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
      this.mnuMainFileNewLogger.Text = "&New Logger...";
      this.mnuMainFileNewLogger.Click += new System.EventHandler(this.MnuMainFileNewLoggerClick);
      // 
      // mnuMainFileOpenLogFile
      // 
      this.mnuMainFileOpenLogFile.Index = 1;
      this.mnuMainFileOpenLogFile.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
      this.mnuMainFileOpenLogFile.Text = "&Open Log File...";
      this.mnuMainFileOpenLogFile.Click += new System.EventHandler(this.MnuMainFileOpenLogFileClick);
      // 
      // menuItem2
      // 
      this.menuItem2.Index = 2;
      this.menuItem2.Text = "-";
      // 
      // mnuMainFileRecentFiles
      // 
      this.mnuMainFileRecentFiles.Enabled = false;
      this.mnuMainFileRecentFiles.Index = 3;
      this.mnuMainFileRecentFiles.Text = "Recent &Files";
      // 
      // menuItem16
      // 
      this.menuItem16.Index = 4;
      this.menuItem16.Text = "-";
      // 
      // mnuMainFileExit
      // 
      this.mnuMainFileExit.Index = 5;
      this.mnuMainFileExit.Shortcut = System.Windows.Forms.Shortcut.AltF4;
      this.mnuMainFileExit.Text = "&Exit";
      this.mnuMainFileExit.Click += new System.EventHandler(this.MnuMainFileExitClick);
      // 
      // mnuMainEdit
      // 
      this.mnuMainEdit.Index = 1;
      this.mnuMainEdit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuMainEditFind,
            this.mnuMainEditFindNext});
      this.mnuMainEdit.Text = "&Edit";
      // 
      // mnuMainEditFind
      // 
      this.mnuMainEditFind.Enabled = false;
      this.mnuMainEditFind.Index = 0;
      this.mnuMainEditFind.Shortcut = System.Windows.Forms.Shortcut.CtrlF;
      this.mnuMainEditFind.Text = "&Find...";
      this.mnuMainEditFind.Click += new System.EventHandler(this.MnuMainEditFindClick);
      // 
      // mnuMainEditFindNext
      // 
      this.mnuMainEditFindNext.Enabled = false;
      this.mnuMainEditFindNext.Index = 1;
      this.mnuMainEditFindNext.Shortcut = System.Windows.Forms.Shortcut.F3;
      this.mnuMainEditFindNext.Text = "Find &next";
      // 
      // mnuMainExtras
      // 
      this.mnuMainExtras.Index = 2;
      this.mnuMainExtras.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuMainExtrasOptions});
      this.mnuMainExtras.Text = "&Extras";
      // 
      // mnuMainExtrasOptions
      // 
      this.mnuMainExtrasOptions.Index = 0;
      this.mnuMainExtrasOptions.Shortcut = System.Windows.Forms.Shortcut.F10;
      this.mnuMainExtrasOptions.Text = "&Options...";
      this.mnuMainExtrasOptions.Click += new System.EventHandler(this.mnuMainExtrasOptions_Click);
      // 
      // mnuMainHelp
      // 
      this.mnuMainHelp.Index = 3;
      this.mnuMainHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuMainHelpAbout});
      this.mnuMainHelp.Text = "&Help";
      // 
      // mnuMainHelpAbout
      // 
      this.mnuMainHelpAbout.Index = 0;
      this.mnuMainHelpAbout.Text = "&About...";
      this.mnuMainHelpAbout.Click += new System.EventHandler(this.MnuMainHelpAboutClick);
      // 
      // mainDockPanel
      // 
      this.mainDockPanel.AllowDrop = true;
      this.mainDockPanel.BackgroundImage = global::Com.Couchcoding.Logbert.Properties.Resources.Logbert_Start_Screen;
      this.mainDockPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
      this.mainDockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.mainDockPanel.DocumentStyle = WeifenLuo.WinFormsUI.Docking.DocumentStyle.DockingWindow;
      this.mainDockPanel.Location = new System.Drawing.Point(0, 0);
      this.mainDockPanel.Name = "mainDockPanel";
      this.mainDockPanel.Size = new System.Drawing.Size(1008, 666);
      this.mainDockPanel.TabIndex = 0;
      this.mainDockPanel.Theme = this.VS2012LightTheme;
      this.mainDockPanel.ContentAdded += new System.EventHandler<WeifenLuo.WinFormsUI.Docking.DockContentEventArgs>(this.MainDockPanelContentAdded);
      this.mainDockPanel.ContentRemoved += new System.EventHandler<WeifenLuo.WinFormsUI.Docking.DockContentEventArgs>(this.MainDockPanelContentRemoved);
      this.mainDockPanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
      this.mainDockPanel.DragOver += new System.Windows.Forms.DragEventHandler(this.MainForm_DragOver);
      // 
      // MainForm
      // 
      this.AllowDrop = true;
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.ClientSize = new System.Drawing.Size(1008, 666);
      this.Controls.Add(this.mainDockPanel);
      this.DoubleBuffered = true;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Menu = this.mnuMain;
      this.Name = "MainForm";
      this.Text = "Logbert";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
      this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
      this.DragOver += new System.Windows.Forms.DragEventHandler(this.MainForm_DragOver);
      this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColumnHeader timeColumnHeader;
        private System.Windows.Forms.ColumnHeader levelColumnHeader;
        private System.Windows.Forms.ColumnHeader loggerColumnHeader;
        private System.Windows.Forms.ColumnHeader threadColumnHeader;
        private System.Windows.Forms.ColumnHeader msgColumnHeader;
        private MainMenu mnuMain;
        private MenuItem mnuMainFile;
        private MenuItem mnuMainFileExit;
        private MenuItem mnuMainExtras;
        private MenuItem mnuMainExtrasOptions;
        private MenuItem mnuMainHelp;
        private MenuItem mnuMainHelpAbout;
        private MenuItem mnuMainFileNewLogger;
        private MenuItem mnuMainFileOpenLogFile;
        private MenuItem menuItem16;
        private WeifenLuo.WinFormsUI.Docking.DockPanel mainDockPanel;
        private MenuItem mnuMainEdit;
        private MenuItem mnuMainEditFind;
        private MenuItem mnuMainEditFindNext;
        private MenuItem menuItem2;
        private MenuItem mnuMainFileRecentFiles;
        private WeifenLuo.WinFormsUI.Docking.VS2012LightTheme VS2012LightTheme;
    }
}

