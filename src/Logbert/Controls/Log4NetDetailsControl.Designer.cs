namespace Couchcoding.Logbert.Controls
{
  partial class Log4NetDetailsControl
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
      this.logDetailToolStrip = new Couchcoding.Logbert.Gui.Controls.ToolStripEx();
      this.tsbZoomIn = new System.Windows.Forms.ToolStripButton();
      this.tsbZoomOut = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.tsbCopy = new System.Windows.Forms.ToolStripButton();
      this.tltTip = new System.Windows.Forms.ToolTip(this.components);
      this.pbxCopyMessage = new Couchcoding.Logbert.Gui.Controls.PictureBoxEx();
      this.pbxCopyThread = new Couchcoding.Logbert.Gui.Controls.PictureBoxEx();
      this.pbxCopyDateTime = new Couchcoding.Logbert.Gui.Controls.PictureBoxEx();
      this.pbxCopyLevel = new Couchcoding.Logbert.Gui.Controls.PictureBoxEx();
      this.pbxCopyLogger = new Couchcoding.Logbert.Gui.Controls.PictureBoxEx();
      this.pbxCopyLocation = new Couchcoding.Logbert.Gui.Controls.PictureBoxEx();
      this.pbxCopyProperties = new Couchcoding.Logbert.Gui.Controls.PictureBoxEx();
      this.LogMessagePanel = new Couchcoding.Logbert.Gui.Controls.InfoPanel();
      this.tblLogMessage = new System.Windows.Forms.TableLayoutPanel();
      this.lblCaptionProperties = new System.Windows.Forms.Label();
      this.txtDataProperties = new System.Windows.Forms.TextBox();
      this.lblCaptionLocation = new System.Windows.Forms.Label();
      this.lblCaptionLogger = new System.Windows.Forms.Label();
      this.lblCaptionLevel = new System.Windows.Forms.Label();
      this.lblCaptionDateTime = new System.Windows.Forms.Label();
      this.lblCaptionThread = new System.Windows.Forms.Label();
      this.lblCaptionMessage = new System.Windows.Forms.Label();
      this.txtDataLogger = new System.Windows.Forms.TextBox();
      this.txtDataLevel = new System.Windows.Forms.TextBox();
      this.txtDataDateTime = new System.Windows.Forms.TextBox();
      this.txtDataThread = new System.Windows.Forms.TextBox();
      this.txtDataMessage = new System.Windows.Forms.TextBox();
      this.txtDataLocation = new System.Windows.Forms.TextBox();
      this.logDetailToolStrip.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pbxCopyMessage)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbxCopyThread)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbxCopyDateTime)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbxCopyLevel)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbxCopyLogger)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbxCopyLocation)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbxCopyProperties)).BeginInit();
      this.LogMessagePanel.SuspendLayout();
      this.tblLogMessage.SuspendLayout();
      this.SuspendLayout();
      // 
      // logDetailToolStrip
      // 
      this.logDetailToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
      this.logDetailToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbZoomIn,
            this.tsbZoomOut,
            this.toolStripSeparator1,
            this.tsbCopy});
      this.logDetailToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
      this.logDetailToolStrip.Location = new System.Drawing.Point(0, 0);
      this.logDetailToolStrip.Name = "logDetailToolStrip";
      this.logDetailToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
      this.logDetailToolStrip.Size = new System.Drawing.Size(430, 25);
      this.logDetailToolStrip.TabIndex = 0;
      this.logDetailToolStrip.Text = "tsMessageDetails";
      // 
      // tsbZoomIn
      // 
      this.tsbZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbZoomIn.Margin = new System.Windows.Forms.Padding(2, 1, 0, 2);
      this.tsbZoomIn.Name = "tsbZoomIn";
      this.tsbZoomIn.Size = new System.Drawing.Size(23, 22);
      this.tsbZoomIn.Text = "Zoom In";
      this.tsbZoomIn.ToolTipText = "Zoom In";
      this.tsbZoomIn.Click += new System.EventHandler(this.TsbZoomInClick);
      // 
      // tsbZoomOut
      // 
      this.tsbZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbZoomOut.Name = "tsbZoomOut";
      this.tsbZoomOut.Size = new System.Drawing.Size(23, 22);
      this.tsbZoomOut.Text = "Zoom Out";
      this.tsbZoomOut.ToolTipText = "Zoom Out";
      this.tsbZoomOut.Click += new System.EventHandler(this.TsbZoomOutClick);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
      // 
      // tsbCopy
      // 
      this.tsbCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbCopy.Name = "tsbCopy";
      this.tsbCopy.Size = new System.Drawing.Size(93, 22);
      this.tsbCopy.Text = "Copy Details";
      this.tsbCopy.Click += new System.EventHandler(this.TsbCopyClick);
      // 
      // pbxCopyMessage
      // 
      this.pbxCopyMessage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.pbxCopyMessage.Cursor = System.Windows.Forms.Cursors.Hand;
      this.pbxCopyMessage.Location = new System.Drawing.Point(405, 94);
      this.pbxCopyMessage.Margin = new System.Windows.Forms.Padding(2, 2, 1, 1);
      this.pbxCopyMessage.Name = "pbxCopyMessage";
      this.pbxCopyMessage.Size = new System.Drawing.Size(17, 18);
      this.pbxCopyMessage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
      this.pbxCopyMessage.TabIndex = 14;
      this.pbxCopyMessage.TabStop = false;
      this.tltTip.SetToolTip(this.pbxCopyMessage, "Copy Message Details to the Clipboard");
      this.pbxCopyMessage.Visible = false;
      this.pbxCopyMessage.Click += new System.EventHandler(this.PbxCopyMessageClick);
      // 
      // pbxCopyThread
      // 
      this.pbxCopyThread.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.pbxCopyThread.Cursor = System.Windows.Forms.Cursors.Hand;
      this.pbxCopyThread.Location = new System.Drawing.Point(405, 71);
      this.pbxCopyThread.Margin = new System.Windows.Forms.Padding(2, 2, 1, 1);
      this.pbxCopyThread.Name = "pbxCopyThread";
      this.pbxCopyThread.Size = new System.Drawing.Size(17, 18);
      this.pbxCopyThread.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
      this.pbxCopyThread.TabIndex = 13;
      this.pbxCopyThread.TabStop = false;
      this.tltTip.SetToolTip(this.pbxCopyThread, "Copy Thread Details to the Clipboard");
      this.pbxCopyThread.Visible = false;
      this.pbxCopyThread.Click += new System.EventHandler(this.PbxCopyThreadClick);
      // 
      // pbxCopyDateTime
      // 
      this.pbxCopyDateTime.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.pbxCopyDateTime.Cursor = System.Windows.Forms.Cursors.Hand;
      this.pbxCopyDateTime.Location = new System.Drawing.Point(405, 48);
      this.pbxCopyDateTime.Margin = new System.Windows.Forms.Padding(2, 2, 1, 1);
      this.pbxCopyDateTime.Name = "pbxCopyDateTime";
      this.pbxCopyDateTime.Size = new System.Drawing.Size(17, 18);
      this.pbxCopyDateTime.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
      this.pbxCopyDateTime.TabIndex = 12;
      this.pbxCopyDateTime.TabStop = false;
      this.tltTip.SetToolTip(this.pbxCopyDateTime, "Copy Date and Time Details to the Clipboard");
      this.pbxCopyDateTime.Visible = false;
      this.pbxCopyDateTime.Click += new System.EventHandler(this.PbxCopyDateTimeClick);
      // 
      // pbxCopyLevel
      // 
      this.pbxCopyLevel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.pbxCopyLevel.Cursor = System.Windows.Forms.Cursors.Hand;
      this.pbxCopyLevel.Location = new System.Drawing.Point(405, 25);
      this.pbxCopyLevel.Margin = new System.Windows.Forms.Padding(2, 2, 1, 1);
      this.pbxCopyLevel.Name = "pbxCopyLevel";
      this.pbxCopyLevel.Size = new System.Drawing.Size(17, 18);
      this.pbxCopyLevel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
      this.pbxCopyLevel.TabIndex = 11;
      this.pbxCopyLevel.TabStop = false;
      this.tltTip.SetToolTip(this.pbxCopyLevel, "Copy Level Details to the Clipboard");
      this.pbxCopyLevel.Visible = false;
      this.pbxCopyLevel.Click += new System.EventHandler(this.PbxCopyLevelClick);
      // 
      // pbxCopyLogger
      // 
      this.pbxCopyLogger.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.pbxCopyLogger.Cursor = System.Windows.Forms.Cursors.Hand;
      this.pbxCopyLogger.Location = new System.Drawing.Point(405, 2);
      this.pbxCopyLogger.Margin = new System.Windows.Forms.Padding(2, 2, 1, 1);
      this.pbxCopyLogger.Name = "pbxCopyLogger";
      this.pbxCopyLogger.Size = new System.Drawing.Size(17, 18);
      this.pbxCopyLogger.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
      this.pbxCopyLogger.TabIndex = 10;
      this.pbxCopyLogger.TabStop = false;
      this.tltTip.SetToolTip(this.pbxCopyLogger, "Copy Logger Details to the Clipboard");
      this.pbxCopyLogger.Visible = false;
      this.pbxCopyLogger.Click += new System.EventHandler(this.PbxCopyLoggerClick);
      // 
      // pbxCopyLocation
      // 
      this.pbxCopyLocation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.pbxCopyLocation.Cursor = System.Windows.Forms.Cursors.Hand;
      this.pbxCopyLocation.Location = new System.Drawing.Point(405, 117);
      this.pbxCopyLocation.Margin = new System.Windows.Forms.Padding(2, 2, 1, 1);
      this.pbxCopyLocation.Name = "pbxCopyLocation";
      this.pbxCopyLocation.Size = new System.Drawing.Size(17, 18);
      this.pbxCopyLocation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
      this.pbxCopyLocation.TabIndex = 17;
      this.pbxCopyLocation.TabStop = false;
      this.tltTip.SetToolTip(this.pbxCopyLocation, "Copy Location Details to the Clipboard");
      this.pbxCopyLocation.Visible = false;
      this.pbxCopyLocation.Click += new System.EventHandler(this.PbxCopyLocationClick);
      // 
      // pbxCopyProperties
      // 
      this.pbxCopyProperties.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.pbxCopyProperties.Cursor = System.Windows.Forms.Cursors.Hand;
      this.pbxCopyProperties.Location = new System.Drawing.Point(405, 140);
      this.pbxCopyProperties.Margin = new System.Windows.Forms.Padding(2, 2, 1, 1);
      this.pbxCopyProperties.Name = "pbxCopyProperties";
      this.pbxCopyProperties.Size = new System.Drawing.Size(17, 18);
      this.pbxCopyProperties.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
      this.pbxCopyProperties.TabIndex = 20;
      this.pbxCopyProperties.TabStop = false;
      this.tltTip.SetToolTip(this.pbxCopyProperties, "Copy Properties Details to the Clipboard");
      this.pbxCopyProperties.Visible = false;
      this.pbxCopyProperties.Click += new System.EventHandler(this.PbxCopyPropertiesClick);
      // 
      // LogMessagePanel
      // 
      this.LogMessagePanel.AutoScroll = true;
      this.LogMessagePanel.BackColor = System.Drawing.SystemColors.Window;
      this.LogMessagePanel.BorderColor = System.Drawing.SystemColors.ControlDark;
      this.LogMessagePanel.Controls.Add(this.tblLogMessage);
      this.LogMessagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.LogMessagePanel.Location = new System.Drawing.Point(0, 25);
      this.LogMessagePanel.Name = "LogMessagePanel";
      this.LogMessagePanel.ShowBorder = false;
      this.LogMessagePanel.ShowTitle = false;
      this.LogMessagePanel.Size = new System.Drawing.Size(430, 168);
      this.LogMessagePanel.TabIndex = 1;
      this.LogMessagePanel.TextPadding = new System.Windows.Forms.Padding(0, 0, 0, 0);
      this.LogMessagePanel.Title = null;
      // 
      // tblLogMessage
      // 
      this.tblLogMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tblLogMessage.AutoSize = true;
      this.tblLogMessage.ColumnCount = 3;
      this.tblLogMessage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tblLogMessage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tblLogMessage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21F));
      this.tblLogMessage.Controls.Add(this.lblCaptionProperties, 0, 6);
      this.tblLogMessage.Controls.Add(this.txtDataProperties, 0, 6);
      this.tblLogMessage.Controls.Add(this.pbxCopyProperties, 0, 6);
      this.tblLogMessage.Controls.Add(this.lblCaptionLocation, 0, 5);
      this.tblLogMessage.Controls.Add(this.pbxCopyMessage, 2, 4);
      this.tblLogMessage.Controls.Add(this.pbxCopyThread, 2, 3);
      this.tblLogMessage.Controls.Add(this.pbxCopyDateTime, 2, 2);
      this.tblLogMessage.Controls.Add(this.pbxCopyLevel, 2, 1);
      this.tblLogMessage.Controls.Add(this.lblCaptionLogger, 0, 0);
      this.tblLogMessage.Controls.Add(this.lblCaptionLevel, 0, 1);
      this.tblLogMessage.Controls.Add(this.lblCaptionDateTime, 0, 2);
      this.tblLogMessage.Controls.Add(this.lblCaptionThread, 0, 3);
      this.tblLogMessage.Controls.Add(this.lblCaptionMessage, 0, 4);
      this.tblLogMessage.Controls.Add(this.txtDataLogger, 1, 0);
      this.tblLogMessage.Controls.Add(this.txtDataLevel, 1, 1);
      this.tblLogMessage.Controls.Add(this.txtDataDateTime, 1, 2);
      this.tblLogMessage.Controls.Add(this.txtDataThread, 1, 3);
      this.tblLogMessage.Controls.Add(this.txtDataMessage, 1, 4);
      this.tblLogMessage.Controls.Add(this.pbxCopyLogger, 2, 0);
      this.tblLogMessage.Controls.Add(this.txtDataLocation, 1, 5);
      this.tblLogMessage.Controls.Add(this.pbxCopyLocation, 2, 5);
      this.tblLogMessage.Location = new System.Drawing.Point(3, 3);
      this.tblLogMessage.Name = "tblLogMessage";
      this.tblLogMessage.RowCount = 7;
      this.tblLogMessage.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tblLogMessage.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tblLogMessage.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tblLogMessage.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tblLogMessage.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tblLogMessage.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tblLogMessage.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tblLogMessage.Size = new System.Drawing.Size(424, 161);
      this.tblLogMessage.TabIndex = 0;
      this.tblLogMessage.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.TblLogMessageCellPaint);
      // 
      // lblCaptionProperties
      // 
      this.lblCaptionProperties.AutoSize = true;
      this.lblCaptionProperties.Location = new System.Drawing.Point(3, 139);
      this.lblCaptionProperties.Margin = new System.Windows.Forms.Padding(3, 1, 10, 1);
      this.lblCaptionProperties.Name = "lblCaptionProperties";
      this.lblCaptionProperties.Padding = new System.Windows.Forms.Padding(4);
      this.lblCaptionProperties.Size = new System.Drawing.Size(62, 21);
      this.lblCaptionProperties.TabIndex = 12;
      this.lblCaptionProperties.Text = "Properties";
      // 
      // txtDataProperties
      // 
      this.txtDataProperties.BackColor = System.Drawing.SystemColors.Window;
      this.txtDataProperties.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.txtDataProperties.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txtDataProperties.Location = new System.Drawing.Point(101, 142);
      this.txtDataProperties.Margin = new System.Windows.Forms.Padding(3, 4, 3, 1);
      this.txtDataProperties.Multiline = true;
      this.txtDataProperties.Name = "txtDataProperties";
      this.txtDataProperties.ReadOnly = true;
      this.txtDataProperties.Size = new System.Drawing.Size(299, 18);
      this.txtDataProperties.TabIndex = 13;
      // 
      // lblCaptionLocation
      // 
      this.lblCaptionLocation.AutoSize = true;
      this.lblCaptionLocation.Location = new System.Drawing.Point(3, 116);
      this.lblCaptionLocation.Margin = new System.Windows.Forms.Padding(3, 1, 10, 1);
      this.lblCaptionLocation.Name = "lblCaptionLocation";
      this.lblCaptionLocation.Padding = new System.Windows.Forms.Padding(4);
      this.lblCaptionLocation.Size = new System.Drawing.Size(56, 21);
      this.lblCaptionLocation.TabIndex = 10;
      this.lblCaptionLocation.Text = "Location";
      // 
      // lblCaptionLogger
      // 
      this.lblCaptionLogger.AutoSize = true;
      this.lblCaptionLogger.Location = new System.Drawing.Point(3, 1);
      this.lblCaptionLogger.Margin = new System.Windows.Forms.Padding(3, 1, 10, 1);
      this.lblCaptionLogger.Name = "lblCaptionLogger";
      this.lblCaptionLogger.Padding = new System.Windows.Forms.Padding(4);
      this.lblCaptionLogger.Size = new System.Drawing.Size(48, 21);
      this.lblCaptionLogger.TabIndex = 0;
      this.lblCaptionLogger.Text = "Logger";
      // 
      // lblCaptionLevel
      // 
      this.lblCaptionLevel.AutoSize = true;
      this.lblCaptionLevel.Location = new System.Drawing.Point(3, 24);
      this.lblCaptionLevel.Margin = new System.Windows.Forms.Padding(3, 1, 10, 1);
      this.lblCaptionLevel.Name = "lblCaptionLevel";
      this.lblCaptionLevel.Padding = new System.Windows.Forms.Padding(4);
      this.lblCaptionLevel.Size = new System.Drawing.Size(41, 21);
      this.lblCaptionLevel.TabIndex = 2;
      this.lblCaptionLevel.Text = "Level";
      // 
      // lblCaptionDateTime
      // 
      this.lblCaptionDateTime.AutoSize = true;
      this.lblCaptionDateTime.Location = new System.Drawing.Point(3, 47);
      this.lblCaptionDateTime.Margin = new System.Windows.Forms.Padding(3, 1, 10, 1);
      this.lblCaptionDateTime.Name = "lblCaptionDateTime";
      this.lblCaptionDateTime.Padding = new System.Windows.Forms.Padding(4);
      this.lblCaptionDateTime.Size = new System.Drawing.Size(85, 21);
      this.lblCaptionDateTime.TabIndex = 4;
      this.lblCaptionDateTime.Text = "Date and Time";
      // 
      // lblCaptionThread
      // 
      this.lblCaptionThread.AutoSize = true;
      this.lblCaptionThread.Location = new System.Drawing.Point(3, 70);
      this.lblCaptionThread.Margin = new System.Windows.Forms.Padding(3, 1, 10, 1);
      this.lblCaptionThread.Name = "lblCaptionThread";
      this.lblCaptionThread.Padding = new System.Windows.Forms.Padding(4);
      this.lblCaptionThread.Size = new System.Drawing.Size(49, 21);
      this.lblCaptionThread.TabIndex = 6;
      this.lblCaptionThread.Text = "Thread";
      // 
      // lblCaptionMessage
      // 
      this.lblCaptionMessage.AutoSize = true;
      this.lblCaptionMessage.Location = new System.Drawing.Point(3, 93);
      this.lblCaptionMessage.Margin = new System.Windows.Forms.Padding(3, 1, 10, 1);
      this.lblCaptionMessage.Name = "lblCaptionMessage";
      this.lblCaptionMessage.Padding = new System.Windows.Forms.Padding(4);
      this.lblCaptionMessage.Size = new System.Drawing.Size(58, 21);
      this.lblCaptionMessage.TabIndex = 8;
      this.lblCaptionMessage.Text = "Message";
      // 
      // txtDataLogger
      // 
      this.txtDataLogger.BackColor = System.Drawing.SystemColors.Window;
      this.txtDataLogger.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.txtDataLogger.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txtDataLogger.Location = new System.Drawing.Point(101, 4);
      this.txtDataLogger.Margin = new System.Windows.Forms.Padding(3, 4, 3, 1);
      this.txtDataLogger.Name = "txtDataLogger";
      this.txtDataLogger.ReadOnly = true;
      this.txtDataLogger.Size = new System.Drawing.Size(299, 13);
      this.txtDataLogger.TabIndex = 1;
      // 
      // txtDataLevel
      // 
      this.txtDataLevel.BackColor = System.Drawing.SystemColors.Window;
      this.txtDataLevel.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.txtDataLevel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txtDataLevel.Location = new System.Drawing.Point(101, 27);
      this.txtDataLevel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 1);
      this.txtDataLevel.Name = "txtDataLevel";
      this.txtDataLevel.ReadOnly = true;
      this.txtDataLevel.Size = new System.Drawing.Size(299, 13);
      this.txtDataLevel.TabIndex = 3;
      // 
      // txtDataDateTime
      // 
      this.txtDataDateTime.BackColor = System.Drawing.SystemColors.Window;
      this.txtDataDateTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.txtDataDateTime.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txtDataDateTime.Location = new System.Drawing.Point(101, 50);
      this.txtDataDateTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 1);
      this.txtDataDateTime.Name = "txtDataDateTime";
      this.txtDataDateTime.ReadOnly = true;
      this.txtDataDateTime.Size = new System.Drawing.Size(299, 13);
      this.txtDataDateTime.TabIndex = 5;
      // 
      // txtDataThread
      // 
      this.txtDataThread.BackColor = System.Drawing.SystemColors.Window;
      this.txtDataThread.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.txtDataThread.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txtDataThread.Location = new System.Drawing.Point(101, 73);
      this.txtDataThread.Margin = new System.Windows.Forms.Padding(3, 4, 3, 1);
      this.txtDataThread.Name = "txtDataThread";
      this.txtDataThread.ReadOnly = true;
      this.txtDataThread.Size = new System.Drawing.Size(299, 13);
      this.txtDataThread.TabIndex = 7;
      // 
      // txtDataMessage
      // 
      this.txtDataMessage.BackColor = System.Drawing.SystemColors.Window;
      this.txtDataMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.txtDataMessage.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txtDataMessage.Location = new System.Drawing.Point(99, 96);
      this.txtDataMessage.Margin = new System.Windows.Forms.Padding(1, 4, 3, 1);
      this.txtDataMessage.Multiline = true;
      this.txtDataMessage.Name = "txtDataMessage";
      this.txtDataMessage.ReadOnly = true;
      this.txtDataMessage.Size = new System.Drawing.Size(301, 18);
      this.txtDataMessage.TabIndex = 9;
      // 
      // txtDataLocation
      // 
      this.txtDataLocation.BackColor = System.Drawing.SystemColors.Window;
      this.txtDataLocation.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.txtDataLocation.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txtDataLocation.Location = new System.Drawing.Point(101, 119);
      this.txtDataLocation.Margin = new System.Windows.Forms.Padding(3, 4, 3, 1);
      this.txtDataLocation.Name = "txtDataLocation";
      this.txtDataLocation.ReadOnly = true;
      this.txtDataLocation.Size = new System.Drawing.Size(299, 13);
      this.txtDataLocation.TabIndex = 11;
      // 
      // Log4NetDetailsControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.LogMessagePanel);
      this.Controls.Add(this.logDetailToolStrip);
      this.Name = "Log4NetDetailsControl";
      this.Size = new System.Drawing.Size(430, 193);
      this.logDetailToolStrip.ResumeLayout(false);
      this.logDetailToolStrip.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pbxCopyMessage)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbxCopyThread)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbxCopyDateTime)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbxCopyLevel)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbxCopyLogger)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbxCopyLocation)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbxCopyProperties)).EndInit();
      this.LogMessagePanel.ResumeLayout(false);
      this.LogMessagePanel.PerformLayout();
      this.tblLogMessage.ResumeLayout(false);
      this.tblLogMessage.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Couchcoding.Logbert.Gui.Controls.ToolStripEx logDetailToolStrip;
    private System.Windows.Forms.ToolStripButton tsbZoomIn;
    private System.Windows.Forms.ToolStripButton tsbZoomOut;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripButton tsbCopy;
    private System.Windows.Forms.TableLayoutPanel tblLogMessage;
    private Gui.Controls.InfoPanel LogMessagePanel;
    private System.Windows.Forms.Label lblCaptionLogger;
    private System.Windows.Forms.Label lblCaptionLevel;
    private System.Windows.Forms.Label lblCaptionDateTime;
    private System.Windows.Forms.Label lblCaptionThread;
    private System.Windows.Forms.Label lblCaptionMessage;
    private System.Windows.Forms.TextBox txtDataLogger;
    private System.Windows.Forms.TextBox txtDataLevel;
    private System.Windows.Forms.TextBox txtDataDateTime;
    private System.Windows.Forms.TextBox txtDataThread;
    private System.Windows.Forms.TextBox txtDataMessage;
    private Gui.Controls.PictureBoxEx pbxCopyLogger;
    private Gui.Controls.PictureBoxEx pbxCopyMessage;
    private Gui.Controls.PictureBoxEx pbxCopyThread;
    private Gui.Controls.PictureBoxEx pbxCopyDateTime;
    private Gui.Controls.PictureBoxEx pbxCopyLevel;
    private System.Windows.Forms.ToolTip tltTip;
    private System.Windows.Forms.Label lblCaptionLocation;
    private System.Windows.Forms.TextBox txtDataLocation;
    private Gui.Controls.PictureBoxEx pbxCopyLocation;
    private System.Windows.Forms.Label lblCaptionProperties;
    private System.Windows.Forms.TextBox txtDataProperties;
    private Gui.Controls.PictureBoxEx pbxCopyProperties;
  }
}
