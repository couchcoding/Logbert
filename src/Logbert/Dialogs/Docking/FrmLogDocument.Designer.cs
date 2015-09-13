namespace Com.Couchcoding.Logbert.Dialogs.Docking
{
  partial class FrmLogDocument
  {
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogDocument));
      this.LogDockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
      this.VS2012LightTheme = new WeifenLuo.WinFormsUI.Docking.VS2012LightTheme();
      this.stBar = new System.Windows.Forms.StatusBar();
      this.stbStatus = new System.Windows.Forms.StatusBarPanel();
      this.stbMessageCount = new System.Windows.Forms.StatusBarPanel();
      this.tsMessages = new Com.Couchcoding.GuiLibrary.Controls.ToolStripEx();
      this.tslLogLevel = new System.Windows.Forms.ToolStripLabel();
      this.tsbShowTrace = new System.Windows.Forms.ToolStripButton();
      this.tsbShowDebug = new System.Windows.Forms.ToolStripButton();
      this.tsbShowInfo = new System.Windows.Forms.ToolStripButton();
      this.tsbShowWarn = new System.Windows.Forms.ToolStripButton();
      this.tsbShowError = new System.Windows.Forms.ToolStripButton();
      this.tsbShowFatal = new System.Windows.Forms.ToolStripButton();
      this.tssLogLevel = new System.Windows.Forms.ToolStripSeparator();
      this.tsbStartPause = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.tsbGotoFirstMessage = new System.Windows.Forms.ToolStripButton();
      this.tsbGotoLastMessage = new System.Windows.Forms.ToolStripButton();
      this.tsbTraceLastMessage = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
      this.tsbToggleBookmark = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
      this.tsbZoomIn = new System.Windows.Forms.ToolStripButton();
      this.tsbZoomOut = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
      this.tsbReload = new System.Windows.Forms.ToolStripButton();
      this.tsbClearMessages = new System.Windows.Forms.ToolStripButton();
      this.tsbSaveMessages = new System.Windows.Forms.ToolStripButton();
      this.tsSeperatorWindows = new System.Windows.Forms.ToolStripSeparator();
      this.tsbShowMessageDetails = new System.Windows.Forms.ToolStripButton();
      this.tsbShowLoggerTree = new System.Windows.Forms.ToolStripButton();
      this.tsbShowBookmarks = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.tsbTimeShift = new System.Windows.Forms.ToolStripButton();
      this.txtTimeShift = new System.Windows.Forms.ToolStripTextBox();
      this.tslTimeShift = new System.Windows.Forms.ToolStripLabel();
      this.tmrUpdate = new System.Windows.Forms.Timer(this.components);
      this.cmsSaveMessages = new System.Windows.Forms.ContextMenu();
      this.cmsSaveMessagesRaw = new System.Windows.Forms.MenuItem();
      this.cmsSaveMessagesCsv = new System.Windows.Forms.MenuItem();
      ((System.ComponentModel.ISupportInitialize)(this.stbStatus)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.stbMessageCount)).BeginInit();
      this.tsMessages.SuspendLayout();
      this.SuspendLayout();
      // 
      // LogDockPanel
      // 
      this.LogDockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.LogDockPanel.DocumentStyle = WeifenLuo.WinFormsUI.Docking.DocumentStyle.DockingWindow;
      this.LogDockPanel.Location = new System.Drawing.Point(0, 26);
      this.LogDockPanel.Name = "LogDockPanel";
      this.LogDockPanel.Size = new System.Drawing.Size(784, 513);
      this.LogDockPanel.SupportDeeplyNestedContent = true;
      this.LogDockPanel.TabIndex = 1;
      this.LogDockPanel.Theme = this.VS2012LightTheme;
      // 
      // stBar
      // 
      this.stBar.Location = new System.Drawing.Point(0, 539);
      this.stBar.Name = "stBar";
      this.stBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.stbStatus,
            this.stbMessageCount});
      this.stBar.ShowPanels = true;
      this.stBar.Size = new System.Drawing.Size(784, 22);
      this.stBar.TabIndex = 2;
      // 
      // stbStatus
      // 
      this.stbStatus.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
      this.stbStatus.Name = "stbStatus";
      this.stbStatus.Text = "Status: Running";
      this.stbStatus.Width = 95;
      // 
      // stbMessageCount
      // 
      this.stbMessageCount.Name = "stbMessageCount";
      this.stbMessageCount.Text = "0 Messages";
      this.stbMessageCount.ToolTipText = "Count of received Messages";
      // 
      // tsMessages
      // 
      this.tsMessages.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
      this.tsMessages.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslLogLevel,
            this.tsbShowTrace,
            this.tsbShowDebug,
            this.tsbShowInfo,
            this.tsbShowWarn,
            this.tsbShowError,
            this.tsbShowFatal,
            this.tssLogLevel,
            this.tsbStartPause,
            this.toolStripSeparator2,
            this.tsbGotoFirstMessage,
            this.tsbGotoLastMessage,
            this.tsbTraceLastMessage,
            this.toolStripSeparator3,
            this.tsbToggleBookmark,
            this.toolStripSeparator5,
            this.tsbZoomIn,
            this.tsbZoomOut,
            this.toolStripSeparator4,
            this.tsbReload,
            this.tsbClearMessages,
            this.tsbSaveMessages,
            this.tsSeperatorWindows,
            this.tsbShowMessageDetails,
            this.tsbShowLoggerTree,
            this.tsbShowBookmarks,
            this.toolStripSeparator1,
            this.tsbTimeShift,
            this.txtTimeShift,
            this.tslTimeShift});
      this.tsMessages.Location = new System.Drawing.Point(0, 0);
      this.tsMessages.Name = "tsMessages";
      this.tsMessages.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
      this.tsMessages.Size = new System.Drawing.Size(784, 26);
      this.tsMessages.TabIndex = 0;
      this.tsMessages.Text = "Messages";
      // 
      // tslLogLevel
      // 
      this.tslLogLevel.Name = "tslLogLevel";
      this.tslLogLevel.Size = new System.Drawing.Size(60, 23);
      this.tslLogLevel.Text = "Log Level:";
      // 
      // tsbShowTrace
      // 
      this.tsbShowTrace.Checked = true;
      this.tsbShowTrace.CheckOnClick = true;
      this.tsbShowTrace.CheckState = System.Windows.Forms.CheckState.Checked;
      this.tsbShowTrace.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbShowTrace.Image = global::Com.Couchcoding.Logbert.Properties.Resources.trace;
      this.tsbShowTrace.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbShowTrace.Name = "tsbShowTrace";
      this.tsbShowTrace.Size = new System.Drawing.Size(23, 23);
      this.tsbShowTrace.Text = "Trace";
      this.tsbShowTrace.ToolTipText = "Show Trace";
      this.tsbShowTrace.CheckedChanged += new System.EventHandler(this.LogLevelChanged);
      // 
      // tsbShowDebug
      // 
      this.tsbShowDebug.Checked = true;
      this.tsbShowDebug.CheckOnClick = true;
      this.tsbShowDebug.CheckState = System.Windows.Forms.CheckState.Checked;
      this.tsbShowDebug.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbShowDebug.Image = global::Com.Couchcoding.Logbert.Properties.Resources.debug;
      this.tsbShowDebug.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbShowDebug.Name = "tsbShowDebug";
      this.tsbShowDebug.Size = new System.Drawing.Size(23, 23);
      this.tsbShowDebug.Text = "Debug";
      this.tsbShowDebug.ToolTipText = "Show Debug";
      this.tsbShowDebug.CheckedChanged += new System.EventHandler(this.LogLevelChanged);
      // 
      // tsbShowInfo
      // 
      this.tsbShowInfo.Checked = true;
      this.tsbShowInfo.CheckOnClick = true;
      this.tsbShowInfo.CheckState = System.Windows.Forms.CheckState.Checked;
      this.tsbShowInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbShowInfo.Image = global::Com.Couchcoding.Logbert.Properties.Resources.info;
      this.tsbShowInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbShowInfo.Name = "tsbShowInfo";
      this.tsbShowInfo.Size = new System.Drawing.Size(23, 23);
      this.tsbShowInfo.Text = "Info";
      this.tsbShowInfo.ToolTipText = "Show Info";
      this.tsbShowInfo.CheckedChanged += new System.EventHandler(this.LogLevelChanged);
      // 
      // tsbShowWarn
      // 
      this.tsbShowWarn.Checked = true;
      this.tsbShowWarn.CheckOnClick = true;
      this.tsbShowWarn.CheckState = System.Windows.Forms.CheckState.Checked;
      this.tsbShowWarn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbShowWarn.Image = global::Com.Couchcoding.Logbert.Properties.Resources.warn;
      this.tsbShowWarn.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbShowWarn.Name = "tsbShowWarn";
      this.tsbShowWarn.Size = new System.Drawing.Size(23, 23);
      this.tsbShowWarn.Text = "Warning";
      this.tsbShowWarn.ToolTipText = "Show Warning";
      this.tsbShowWarn.CheckedChanged += new System.EventHandler(this.LogLevelChanged);
      // 
      // tsbShowError
      // 
      this.tsbShowError.Checked = true;
      this.tsbShowError.CheckOnClick = true;
      this.tsbShowError.CheckState = System.Windows.Forms.CheckState.Checked;
      this.tsbShowError.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbShowError.Image = global::Com.Couchcoding.Logbert.Properties.Resources.error;
      this.tsbShowError.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbShowError.Name = "tsbShowError";
      this.tsbShowError.Size = new System.Drawing.Size(23, 23);
      this.tsbShowError.Text = "Error";
      this.tsbShowError.ToolTipText = "Show Error";
      this.tsbShowError.CheckedChanged += new System.EventHandler(this.LogLevelChanged);
      // 
      // tsbShowFatal
      // 
      this.tsbShowFatal.Checked = true;
      this.tsbShowFatal.CheckOnClick = true;
      this.tsbShowFatal.CheckState = System.Windows.Forms.CheckState.Checked;
      this.tsbShowFatal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbShowFatal.Image = global::Com.Couchcoding.Logbert.Properties.Resources.fatal;
      this.tsbShowFatal.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbShowFatal.Name = "tsbShowFatal";
      this.tsbShowFatal.Size = new System.Drawing.Size(23, 23);
      this.tsbShowFatal.Text = "Fatal";
      this.tsbShowFatal.ToolTipText = "Show Fatal";
      this.tsbShowFatal.CheckedChanged += new System.EventHandler(this.LogLevelChanged);
      // 
      // tssLogLevel
      // 
      this.tssLogLevel.Name = "tssLogLevel";
      this.tssLogLevel.Size = new System.Drawing.Size(6, 26);
      // 
      // tsbStartPause
      // 
      this.tsbStartPause.Checked = true;
      this.tsbStartPause.CheckOnClick = true;
      this.tsbStartPause.CheckState = System.Windows.Forms.CheckState.Checked;
      this.tsbStartPause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbStartPause.Image = global::Com.Couchcoding.Logbert.Properties.Resources.StatusAnnotations_Play_16xLG;
      this.tsbStartPause.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbStartPause.Name = "tsbStartPause";
      this.tsbStartPause.Size = new System.Drawing.Size(23, 23);
      this.tsbStartPause.Text = "Start / Stop";
      this.tsbStartPause.ToolTipText = "Start / Stop";
      this.tsbStartPause.CheckedChanged += new System.EventHandler(this.TsbStartPauseCheckedChanged);
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new System.Drawing.Size(6, 26);
      // 
      // tsbGotoFirstMessage
      // 
      this.tsbGotoFirstMessage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbGotoFirstMessage.Image = global::Com.Couchcoding.Logbert.Properties.Resources.move_to_top;
      this.tsbGotoFirstMessage.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbGotoFirstMessage.Name = "tsbGotoFirstMessage";
      this.tsbGotoFirstMessage.Size = new System.Drawing.Size(23, 23);
      this.tsbGotoFirstMessage.Text = "Goto First Message";
      this.tsbGotoFirstMessage.Click += new System.EventHandler(this.TsbGotoFirstMessageClick);
      // 
      // tsbGotoLastMessage
      // 
      this.tsbGotoLastMessage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbGotoLastMessage.Image = global::Com.Couchcoding.Logbert.Properties.Resources.move_to_bottom;
      this.tsbGotoLastMessage.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbGotoLastMessage.Name = "tsbGotoLastMessage";
      this.tsbGotoLastMessage.Size = new System.Drawing.Size(23, 23);
      this.tsbGotoLastMessage.Text = "Goto Last Message";
      this.tsbGotoLastMessage.Click += new System.EventHandler(this.TsbGotoLastMessageClick);
      // 
      // tsbTraceLastMessage
      // 
      this.tsbTraceLastMessage.Checked = true;
      this.tsbTraceLastMessage.CheckOnClick = true;
      this.tsbTraceLastMessage.CheckState = System.Windows.Forms.CheckState.Checked;
      this.tsbTraceLastMessage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbTraceLastMessage.Image = global::Com.Couchcoding.Logbert.Properties.Resources.to_bottom;
      this.tsbTraceLastMessage.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbTraceLastMessage.Name = "tsbTraceLastMessage";
      this.tsbTraceLastMessage.Size = new System.Drawing.Size(23, 23);
      this.tsbTraceLastMessage.Text = "Always Select Last Message";
      // 
      // toolStripSeparator3
      // 
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      this.toolStripSeparator3.Size = new System.Drawing.Size(6, 26);
      // 
      // tsbToggleBookmark
      // 
      this.tsbToggleBookmark.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbToggleBookmark.Enabled = false;
      this.tsbToggleBookmark.Image = global::Com.Couchcoding.Logbert.Properties.Resources.Bookmark_6986;
      this.tsbToggleBookmark.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbToggleBookmark.Name = "tsbToggleBookmark";
      this.tsbToggleBookmark.Size = new System.Drawing.Size(23, 23);
      this.tsbToggleBookmark.Text = "Toggle Bookmark";
      this.tsbToggleBookmark.Click += new System.EventHandler(this.TsbToggleBookmarkClick);
      // 
      // toolStripSeparator5
      // 
      this.toolStripSeparator5.Name = "toolStripSeparator5";
      this.toolStripSeparator5.Size = new System.Drawing.Size(6, 26);
      // 
      // tsbZoomIn
      // 
      this.tsbZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbZoomIn.Image = global::Com.Couchcoding.Logbert.Properties.Resources.zoom_16xLG;
      this.tsbZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbZoomIn.Name = "tsbZoomIn";
      this.tsbZoomIn.Size = new System.Drawing.Size(23, 23);
      this.tsbZoomIn.Text = "Zoom In";
      this.tsbZoomIn.Click += new System.EventHandler(this.TsbZoomInClick);
      // 
      // tsbZoomOut
      // 
      this.tsbZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbZoomOut.Image = global::Com.Couchcoding.Logbert.Properties.Resources.ZoomOut_16xLG;
      this.tsbZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbZoomOut.Name = "tsbZoomOut";
      this.tsbZoomOut.Size = new System.Drawing.Size(23, 23);
      this.tsbZoomOut.Text = "Zoom Out";
      this.tsbZoomOut.Click += new System.EventHandler(this.TsbZoomOutClick);
      // 
      // toolStripSeparator4
      // 
      this.toolStripSeparator4.Name = "toolStripSeparator4";
      this.toolStripSeparator4.Size = new System.Drawing.Size(6, 26);
      // 
      // tsbReload
      // 
      this.tsbReload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbReload.Image = global::Com.Couchcoding.Logbert.Properties.Resources.refresh_16xLG;
      this.tsbReload.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbReload.Name = "tsbReload";
      this.tsbReload.Size = new System.Drawing.Size(23, 23);
      this.tsbReload.Text = "Reload";
      this.tsbReload.Click += new System.EventHandler(this.TsbReloadClick);
      // 
      // tsbClearMessages
      // 
      this.tsbClearMessages.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbClearMessages.Image = global::Com.Couchcoding.Logbert.Properties.Resources.action_Cancel_16xLG;
      this.tsbClearMessages.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbClearMessages.Name = "tsbClearMessages";
      this.tsbClearMessages.Size = new System.Drawing.Size(23, 23);
      this.tsbClearMessages.Text = "Clear Messages";
      this.tsbClearMessages.Click += new System.EventHandler(this.TsbClearMessagesClick);
      // 
      // tsbSaveMessages
      // 
      this.tsbSaveMessages.AutoSize = false;
      this.tsbSaveMessages.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbSaveMessages.Image = global::Com.Couchcoding.Logbert.Properties.Resources.save_as;
      this.tsbSaveMessages.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.tsbSaveMessages.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbSaveMessages.Name = "tsbSaveMessages";
      this.tsbSaveMessages.Size = new System.Drawing.Size(32, 22);
      this.tsbSaveMessages.Text = "Save Messages";
      this.tsbSaveMessages.Click += new System.EventHandler(this.TsbSaveMessagesClick);
      // 
      // tsSeperatorWindows
      // 
      this.tsSeperatorWindows.Name = "tsSeperatorWindows";
      this.tsSeperatorWindows.Size = new System.Drawing.Size(6, 26);
      // 
      // tsbShowMessageDetails
      // 
      this.tsbShowMessageDetails.Checked = true;
      this.tsbShowMessageDetails.CheckOnClick = true;
      this.tsbShowMessageDetails.CheckState = System.Windows.Forms.CheckState.Checked;
      this.tsbShowMessageDetails.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbShowMessageDetails.Image = global::Com.Couchcoding.Logbert.Properties.Resources.MesageDetails;
      this.tsbShowMessageDetails.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbShowMessageDetails.Name = "tsbShowMessageDetails";
      this.tsbShowMessageDetails.Size = new System.Drawing.Size(23, 23);
      this.tsbShowMessageDetails.Text = "Message Details";
      this.tsbShowMessageDetails.ToolTipText = "Show Message Details";
      this.tsbShowMessageDetails.Click += new System.EventHandler(this.TsbShowMessageDetailsClick);
      // 
      // tsbShowLoggerTree
      // 
      this.tsbShowLoggerTree.Checked = true;
      this.tsbShowLoggerTree.CheckOnClick = true;
      this.tsbShowLoggerTree.CheckState = System.Windows.Forms.CheckState.Checked;
      this.tsbShowLoggerTree.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbShowLoggerTree.Image = global::Com.Couchcoding.Logbert.Properties.Resources.LoggerTree;
      this.tsbShowLoggerTree.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbShowLoggerTree.Name = "tsbShowLoggerTree";
      this.tsbShowLoggerTree.Size = new System.Drawing.Size(23, 23);
      this.tsbShowLoggerTree.Text = "Logger Tree";
      this.tsbShowLoggerTree.ToolTipText = "Show Logger Tree";
      this.tsbShowLoggerTree.Click += new System.EventHandler(this.TsbShowLoggerTreeClick);
      // 
      // tsbShowBookmarks
      // 
      this.tsbShowBookmarks.CheckOnClick = true;
      this.tsbShowBookmarks.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbShowBookmarks.Image = global::Com.Couchcoding.Logbert.Properties.Resources.Bookmark_5776;
      this.tsbShowBookmarks.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbShowBookmarks.Name = "tsbShowBookmarks";
      this.tsbShowBookmarks.Size = new System.Drawing.Size(23, 23);
      this.tsbShowBookmarks.Text = "Bookmarks";
      this.tsbShowBookmarks.Click += new System.EventHandler(this.TsbShowBookmarksClick);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(6, 26);
      // 
      // tsbTimeShift
      // 
      this.tsbTimeShift.CheckOnClick = true;
      this.tsbTimeShift.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbTimeShift.Image = global::Com.Couchcoding.Logbert.Properties.Resources.clock_16xLG;
      this.tsbTimeShift.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbTimeShift.Name = "tsbTimeShift";
      this.tsbTimeShift.Size = new System.Drawing.Size(23, 23);
      this.tsbTimeShift.Text = "Timeshift";
      this.tsbTimeShift.Click += new System.EventHandler(this.TsbTimeShiftClick);
      // 
      // txtTimeShift
      // 
      this.txtTimeShift.Enabled = false;
      this.txtTimeShift.Margin = new System.Windows.Forms.Padding(1, 1, 1, 2);
      this.txtTimeShift.Name = "txtTimeShift";
      this.txtTimeShift.Size = new System.Drawing.Size(60, 23);
      this.txtTimeShift.Text = "0";
      this.txtTimeShift.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.txtTimeShift.Leave += new System.EventHandler(this.TxtTimeShiftValidated);
      this.txtTimeShift.Validated += new System.EventHandler(this.TxtTimeShiftValidated);
      // 
      // tslTimeShift
      // 
      this.tslTimeShift.Enabled = false;
      this.tslTimeShift.Name = "tslTimeShift";
      this.tslTimeShift.Size = new System.Drawing.Size(73, 23);
      this.tslTimeShift.Text = "Milliseconds";
      // 
      // cmsSaveMessages
      // 
      this.cmsSaveMessages.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.cmsSaveMessagesRaw,
            this.cmsSaveMessagesCsv});
      // 
      // cmsSaveMessagesRaw
      // 
      this.cmsSaveMessagesRaw.Index = 0;
      this.cmsSaveMessagesRaw.Text = "Save &Raw data...";
      this.cmsSaveMessagesRaw.Click += new System.EventHandler(this.CmsSaveMessagesTextClick);
      // 
      // cmsSaveMessagesCsv
      // 
      this.cmsSaveMessagesCsv.Index = 1;
      this.cmsSaveMessagesCsv.Text = "Save as &CSV...";
      this.cmsSaveMessagesCsv.Click += new System.EventHandler(this.CmsSaveMessagesCsvClick);
      // 
      // FrmLogDocument
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(784, 561);
      this.Controls.Add(this.LogDockPanel);
      this.Controls.Add(this.tsMessages);
      this.Controls.Add(this.stBar);
      this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.Document)));
      this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "FrmLogDocument";
      this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.Document;
      this.TabText = "Log Document";
      this.Text = "Log Document";
      ((System.ComponentModel.ISupportInitialize)(this.stbStatus)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.stbMessageCount)).EndInit();
      this.tsMessages.ResumeLayout(false);
      this.tsMessages.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private WeifenLuo.WinFormsUI.Docking.DockPanel LogDockPanel;
    private System.Windows.Forms.StatusBar stBar;
    private Com.Couchcoding.GuiLibrary.Controls.ToolStripEx tsMessages;
    private System.Windows.Forms.ToolStripButton tsbShowDebug;
    private System.Windows.Forms.ToolStripButton tsbShowInfo;
    private System.Windows.Forms.ToolStripButton tsbShowWarn;
    private System.Windows.Forms.ToolStripButton tsbShowError;
    private System.Windows.Forms.ToolStripButton tsbShowFatal;
    private System.Windows.Forms.ToolStripSeparator tssLogLevel;
    private System.Windows.Forms.ToolStripButton tsbStartPause;
    private System.Windows.Forms.ToolStripButton tsbGotoFirstMessage;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.ToolStripButton tsbGotoLastMessage;
    private System.Windows.Forms.ToolStripButton tsbTraceLastMessage;
    private System.Windows.Forms.ToolStripLabel tslLogLevel;
    private System.Windows.Forms.ToolStripButton tsbShowTrace;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    private System.Windows.Forms.ToolStripButton tsbZoomIn;
    private System.Windows.Forms.ToolStripButton tsbZoomOut;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    private System.Windows.Forms.ToolStripButton tsbSaveMessages;
    private System.Windows.Forms.ToolStripButton tsbClearMessages;
    private System.Windows.Forms.StatusBarPanel stbMessageCount;
    private System.Windows.Forms.ToolStripSeparator tsSeperatorWindows;
    private System.Windows.Forms.ToolStripButton tsbShowMessageDetails;
    private System.Windows.Forms.ToolStripButton tsbShowLoggerTree;
    private System.Windows.Forms.StatusBarPanel stbStatus;
    private System.Windows.Forms.ToolStripButton tsbShowBookmarks;
    private System.Windows.Forms.Timer tmrUpdate;
    private System.Windows.Forms.ContextMenu cmsSaveMessages;
    private System.Windows.Forms.MenuItem cmsSaveMessagesRaw;
    private System.Windows.Forms.MenuItem cmsSaveMessagesCsv;
    private System.Windows.Forms.ToolStripButton tsbReload;
    private System.Windows.Forms.ToolStripButton tsbTimeShift;
    private System.Windows.Forms.ToolStripTextBox txtTimeShift;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripLabel tslTimeShift;
    private System.Windows.Forms.ToolStripButton tsbToggleBookmark;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
    private WeifenLuo.WinFormsUI.Docking.VS2012LightTheme VS2012LightTheme;
  }
}
