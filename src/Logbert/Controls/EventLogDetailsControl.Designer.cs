namespace Com.Couchcoding.Logbert.Controls
{
  partial class EventLogDetailsControl
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
      this.logDetailToolStrip = new Com.Couchcoding.GuiLibrary.Controls.ToolStripEx();
      this.tsbZoomIn = new System.Windows.Forms.ToolStripButton();
      this.tsbZoomOut = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.tsbCopy = new System.Windows.Forms.ToolStripButton();
      this.tltTip = new System.Windows.Forms.ToolTip(this.components);
      this.pbxCopyCategory = new Com.Couchcoding.GuiLibrary.Controls.PictureBoxEx();
      this.pbxCopyLogger = new Com.Couchcoding.GuiLibrary.Controls.PictureBoxEx();
      this.pbxCopyDateAndTime = new Com.Couchcoding.GuiLibrary.Controls.PictureBoxEx();
      this.pbxCopyLevel = new Com.Couchcoding.GuiLibrary.Controls.PictureBoxEx();
      this.pbxCopyNumber = new Com.Couchcoding.GuiLibrary.Controls.PictureBoxEx();
      this.pbxCopyUsername = new Com.Couchcoding.GuiLibrary.Controls.PictureBoxEx();
      this.pbxCopyMessage = new Com.Couchcoding.GuiLibrary.Controls.PictureBoxEx();
      this.pbxCopyInstanceId = new Com.Couchcoding.GuiLibrary.Controls.PictureBoxEx();
      this.LogMessagePanel = new Com.Couchcoding.GuiLibrary.Controls.InfoPanel();
      this.tblLogMessage = new System.Windows.Forms.TableLayoutPanel();
      this.txtDataInstaceId = new System.Windows.Forms.TextBox();
      this.lblCaptionUsername = new System.Windows.Forms.Label();
      this.lblCaptionNumber = new System.Windows.Forms.Label();
      this.lblCaptionLevel = new System.Windows.Forms.Label();
      this.lblCaptionDateAndTime = new System.Windows.Forms.Label();
      this.lblCaptionLogger = new System.Windows.Forms.Label();
      this.lblCaptionCategory = new System.Windows.Forms.Label();
      this.txtDataNumber = new System.Windows.Forms.TextBox();
      this.txtDataLevel = new System.Windows.Forms.TextBox();
      this.txtDataDateAndTime = new System.Windows.Forms.TextBox();
      this.txtDataLogger = new System.Windows.Forms.TextBox();
      this.txtDataCategory = new System.Windows.Forms.TextBox();
      this.txtDataUsername = new System.Windows.Forms.TextBox();
      this.txtDataMessage = new System.Windows.Forms.TextBox();
      this.lblCaptionMessage = new System.Windows.Forms.Label();
      this.lblCaptionInstanceId = new System.Windows.Forms.Label();
      this.logDetailToolStrip.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pbxCopyCategory)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbxCopyLogger)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbxCopyDateAndTime)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbxCopyLevel)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbxCopyNumber)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbxCopyUsername)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbxCopyMessage)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbxCopyInstanceId)).BeginInit();
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
      this.tsbZoomIn.Image = global::Com.Couchcoding.Logbert.Properties.Resources.zoom_16xLG;
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
      this.tsbZoomOut.Image = global::Com.Couchcoding.Logbert.Properties.Resources.ZoomOut_16xLG;
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
      this.tsbCopy.Image = global::Com.Couchcoding.Logbert.Properties.Resources.Copy_6524;
      this.tsbCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbCopy.Name = "tsbCopy";
      this.tsbCopy.Size = new System.Drawing.Size(93, 22);
      this.tsbCopy.Text = "Copy Details";
      this.tsbCopy.Click += new System.EventHandler(this.TsbCopyClick);
      // 
      // pbxCopyCategory
      // 
      this.pbxCopyCategory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.pbxCopyCategory.Cursor = System.Windows.Forms.Cursors.Hand;
      this.pbxCopyCategory.Image = global::Com.Couchcoding.Logbert.Properties.Resources.Copy_6524;
      this.pbxCopyCategory.Location = new System.Drawing.Point(388, 94);
      this.pbxCopyCategory.Margin = new System.Windows.Forms.Padding(2, 2, 1, 1);
      this.pbxCopyCategory.Name = "pbxCopyCategory";
      this.pbxCopyCategory.Size = new System.Drawing.Size(17, 18);
      this.pbxCopyCategory.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
      this.pbxCopyCategory.TabIndex = 14;
      this.pbxCopyCategory.TabStop = false;
      this.tltTip.SetToolTip(this.pbxCopyCategory, "Copy Category Details to the Clipboard");
      this.pbxCopyCategory.Visible = false;
      this.pbxCopyCategory.Click += new System.EventHandler(this.PbxCopyCategoryClick);
      // 
      // pbxCopyLogger
      // 
      this.pbxCopyLogger.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.pbxCopyLogger.Cursor = System.Windows.Forms.Cursors.Hand;
      this.pbxCopyLogger.Image = global::Com.Couchcoding.Logbert.Properties.Resources.Copy_6524;
      this.pbxCopyLogger.Location = new System.Drawing.Point(388, 71);
      this.pbxCopyLogger.Margin = new System.Windows.Forms.Padding(2, 2, 1, 1);
      this.pbxCopyLogger.Name = "pbxCopyLogger";
      this.pbxCopyLogger.Size = new System.Drawing.Size(17, 18);
      this.pbxCopyLogger.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
      this.pbxCopyLogger.TabIndex = 13;
      this.pbxCopyLogger.TabStop = false;
      this.tltTip.SetToolTip(this.pbxCopyLogger, "Copy Logger Details to the Clipboard");
      this.pbxCopyLogger.Visible = false;
      this.pbxCopyLogger.Click += new System.EventHandler(this.PbxCopyLoggerClick);
      // 
      // pbxCopyDateAndTime
      // 
      this.pbxCopyDateAndTime.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.pbxCopyDateAndTime.Cursor = System.Windows.Forms.Cursors.Hand;
      this.pbxCopyDateAndTime.Image = global::Com.Couchcoding.Logbert.Properties.Resources.Copy_6524;
      this.pbxCopyDateAndTime.Location = new System.Drawing.Point(388, 48);
      this.pbxCopyDateAndTime.Margin = new System.Windows.Forms.Padding(2, 2, 1, 1);
      this.pbxCopyDateAndTime.Name = "pbxCopyDateAndTime";
      this.pbxCopyDateAndTime.Size = new System.Drawing.Size(17, 18);
      this.pbxCopyDateAndTime.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
      this.pbxCopyDateAndTime.TabIndex = 12;
      this.pbxCopyDateAndTime.TabStop = false;
      this.tltTip.SetToolTip(this.pbxCopyDateAndTime, "Copy Date and Time Details to the Clipboard");
      this.pbxCopyDateAndTime.Visible = false;
      this.pbxCopyDateAndTime.Click += new System.EventHandler(this.PbxCopyDateTimeClick);
      // 
      // pbxCopyLevel
      // 
      this.pbxCopyLevel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.pbxCopyLevel.Cursor = System.Windows.Forms.Cursors.Hand;
      this.pbxCopyLevel.Image = global::Com.Couchcoding.Logbert.Properties.Resources.Copy_6524;
      this.pbxCopyLevel.Location = new System.Drawing.Point(388, 25);
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
      // pbxCopyNumber
      // 
      this.pbxCopyNumber.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.pbxCopyNumber.Cursor = System.Windows.Forms.Cursors.Hand;
      this.pbxCopyNumber.Image = global::Com.Couchcoding.Logbert.Properties.Resources.Copy_6524;
      this.pbxCopyNumber.Location = new System.Drawing.Point(388, 2);
      this.pbxCopyNumber.Margin = new System.Windows.Forms.Padding(2, 2, 1, 1);
      this.pbxCopyNumber.Name = "pbxCopyNumber";
      this.pbxCopyNumber.Size = new System.Drawing.Size(17, 18);
      this.pbxCopyNumber.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
      this.pbxCopyNumber.TabIndex = 10;
      this.pbxCopyNumber.TabStop = false;
      this.tltTip.SetToolTip(this.pbxCopyNumber, "Copy Log Number Details to the Clipboard");
      this.pbxCopyNumber.Visible = false;
      this.pbxCopyNumber.Click += new System.EventHandler(this.PbxCopyNumberClick);
      // 
      // pbxCopyUsername
      // 
      this.pbxCopyUsername.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.pbxCopyUsername.Cursor = System.Windows.Forms.Cursors.Hand;
      this.pbxCopyUsername.Image = global::Com.Couchcoding.Logbert.Properties.Resources.Copy_6524;
      this.pbxCopyUsername.Location = new System.Drawing.Point(388, 117);
      this.pbxCopyUsername.Margin = new System.Windows.Forms.Padding(2, 2, 1, 1);
      this.pbxCopyUsername.Name = "pbxCopyUsername";
      this.pbxCopyUsername.Size = new System.Drawing.Size(17, 18);
      this.pbxCopyUsername.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
      this.pbxCopyUsername.TabIndex = 17;
      this.pbxCopyUsername.TabStop = false;
      this.tltTip.SetToolTip(this.pbxCopyUsername, "Copy Username Details to the Clipboard");
      this.pbxCopyUsername.Visible = false;
      this.pbxCopyUsername.Click += new System.EventHandler(this.PbxCopyUsernameClick);
      // 
      // pbxCopyMessage
      // 
      this.pbxCopyMessage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.pbxCopyMessage.Cursor = System.Windows.Forms.Cursors.Hand;
      this.pbxCopyMessage.Image = global::Com.Couchcoding.Logbert.Properties.Resources.Copy_6524;
      this.pbxCopyMessage.Location = new System.Drawing.Point(388, 163);
      this.pbxCopyMessage.Margin = new System.Windows.Forms.Padding(2, 2, 1, 1);
      this.pbxCopyMessage.Name = "pbxCopyMessage";
      this.pbxCopyMessage.Size = new System.Drawing.Size(17, 18);
      this.pbxCopyMessage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
      this.pbxCopyMessage.TabIndex = 20;
      this.pbxCopyMessage.TabStop = false;
      this.tltTip.SetToolTip(this.pbxCopyMessage, "Copy Message Details to the Clipboard");
      this.pbxCopyMessage.Visible = false;
      this.pbxCopyMessage.Click += new System.EventHandler(this.PbxCopyMessageClick);
      // 
      // pbxCopyInstanceId
      // 
      this.pbxCopyInstanceId.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.pbxCopyInstanceId.Cursor = System.Windows.Forms.Cursors.Hand;
      this.pbxCopyInstanceId.Image = global::Com.Couchcoding.Logbert.Properties.Resources.Copy_6524;
      this.pbxCopyInstanceId.Location = new System.Drawing.Point(388, 140);
      this.pbxCopyInstanceId.Margin = new System.Windows.Forms.Padding(2, 2, 1, 1);
      this.pbxCopyInstanceId.Name = "pbxCopyInstanceId";
      this.pbxCopyInstanceId.Size = new System.Drawing.Size(17, 17);
      this.pbxCopyInstanceId.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
      this.pbxCopyInstanceId.TabIndex = 22;
      this.pbxCopyInstanceId.TabStop = false;
      this.tltTip.SetToolTip(this.pbxCopyInstanceId, "Copy Instance ID Details to the Clipboard");
      this.pbxCopyInstanceId.Visible = false;
      this.pbxCopyInstanceId.Click += new System.EventHandler(this.pbxCopyInstanceId_Click);
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
      this.tblLogMessage.Controls.Add(this.txtDataInstaceId, 0, 6);
      this.tblLogMessage.Controls.Add(this.pbxCopyInstanceId, 2, 6);
      this.tblLogMessage.Controls.Add(this.lblCaptionUsername, 0, 5);
      this.tblLogMessage.Controls.Add(this.pbxCopyCategory, 2, 4);
      this.tblLogMessage.Controls.Add(this.pbxCopyLogger, 2, 3);
      this.tblLogMessage.Controls.Add(this.pbxCopyDateAndTime, 2, 2);
      this.tblLogMessage.Controls.Add(this.pbxCopyLevel, 2, 1);
      this.tblLogMessage.Controls.Add(this.lblCaptionNumber, 0, 0);
      this.tblLogMessage.Controls.Add(this.lblCaptionLevel, 0, 1);
      this.tblLogMessage.Controls.Add(this.lblCaptionDateAndTime, 0, 2);
      this.tblLogMessage.Controls.Add(this.lblCaptionLogger, 0, 3);
      this.tblLogMessage.Controls.Add(this.lblCaptionCategory, 0, 4);
      this.tblLogMessage.Controls.Add(this.txtDataNumber, 1, 0);
      this.tblLogMessage.Controls.Add(this.txtDataLevel, 1, 1);
      this.tblLogMessage.Controls.Add(this.txtDataDateAndTime, 1, 2);
      this.tblLogMessage.Controls.Add(this.txtDataLogger, 1, 3);
      this.tblLogMessage.Controls.Add(this.txtDataCategory, 1, 4);
      this.tblLogMessage.Controls.Add(this.pbxCopyNumber, 2, 0);
      this.tblLogMessage.Controls.Add(this.txtDataUsername, 1, 5);
      this.tblLogMessage.Controls.Add(this.pbxCopyUsername, 2, 5);
      this.tblLogMessage.Controls.Add(this.txtDataMessage, 1, 7);
      this.tblLogMessage.Controls.Add(this.lblCaptionMessage, 0, 7);
      this.tblLogMessage.Controls.Add(this.lblCaptionInstanceId, 0, 6);
      this.tblLogMessage.Controls.Add(this.pbxCopyMessage, 2, 7);
      this.tblLogMessage.Location = new System.Drawing.Point(3, 3);
      this.tblLogMessage.Name = "tblLogMessage";
      this.tblLogMessage.RowCount = 8;
      this.tblLogMessage.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tblLogMessage.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tblLogMessage.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tblLogMessage.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tblLogMessage.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tblLogMessage.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tblLogMessage.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tblLogMessage.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tblLogMessage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tblLogMessage.Size = new System.Drawing.Size(407, 184);
      this.tblLogMessage.TabIndex = 0;
      this.tblLogMessage.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.TblLogMessageCellPaint);
      // 
      // txtDataInstaceId
      // 
      this.txtDataInstaceId.BackColor = System.Drawing.SystemColors.Window;
      this.txtDataInstaceId.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.txtDataInstaceId.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txtDataInstaceId.Location = new System.Drawing.Point(101, 142);
      this.txtDataInstaceId.Margin = new System.Windows.Forms.Padding(3, 4, 3, 1);
      this.txtDataInstaceId.Name = "txtDataInstaceId";
      this.txtDataInstaceId.ReadOnly = true;
      this.txtDataInstaceId.Size = new System.Drawing.Size(282, 13);
      this.txtDataInstaceId.TabIndex = 13;
      // 
      // lblCaptionUsername
      // 
      this.lblCaptionUsername.AutoSize = true;
      this.lblCaptionUsername.Location = new System.Drawing.Point(3, 116);
      this.lblCaptionUsername.Margin = new System.Windows.Forms.Padding(3, 1, 10, 1);
      this.lblCaptionUsername.Name = "lblCaptionUsername";
      this.lblCaptionUsername.Padding = new System.Windows.Forms.Padding(4);
      this.lblCaptionUsername.Size = new System.Drawing.Size(63, 21);
      this.lblCaptionUsername.TabIndex = 10;
      this.lblCaptionUsername.Text = "Username";
      // 
      // lblCaptionNumber
      // 
      this.lblCaptionNumber.AutoSize = true;
      this.lblCaptionNumber.Location = new System.Drawing.Point(3, 1);
      this.lblCaptionNumber.Margin = new System.Windows.Forms.Padding(3, 1, 10, 1);
      this.lblCaptionNumber.Name = "lblCaptionNumber";
      this.lblCaptionNumber.Padding = new System.Windows.Forms.Padding(4);
      this.lblCaptionNumber.Size = new System.Drawing.Size(52, 21);
      this.lblCaptionNumber.TabIndex = 0;
      this.lblCaptionNumber.Text = "Number";
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
      // lblCaptionDateAndTime
      // 
      this.lblCaptionDateAndTime.AutoSize = true;
      this.lblCaptionDateAndTime.Location = new System.Drawing.Point(3, 47);
      this.lblCaptionDateAndTime.Margin = new System.Windows.Forms.Padding(3, 1, 10, 1);
      this.lblCaptionDateAndTime.Name = "lblCaptionDateAndTime";
      this.lblCaptionDateAndTime.Padding = new System.Windows.Forms.Padding(4);
      this.lblCaptionDateAndTime.Size = new System.Drawing.Size(85, 21);
      this.lblCaptionDateAndTime.TabIndex = 4;
      this.lblCaptionDateAndTime.Text = "Date and Time";
      // 
      // lblCaptionLogger
      // 
      this.lblCaptionLogger.AutoSize = true;
      this.lblCaptionLogger.Location = new System.Drawing.Point(3, 70);
      this.lblCaptionLogger.Margin = new System.Windows.Forms.Padding(3, 1, 10, 1);
      this.lblCaptionLogger.Name = "lblCaptionLogger";
      this.lblCaptionLogger.Padding = new System.Windows.Forms.Padding(4);
      this.lblCaptionLogger.Size = new System.Drawing.Size(48, 21);
      this.lblCaptionLogger.TabIndex = 6;
      this.lblCaptionLogger.Text = "Logger";
      // 
      // lblCaptionCategory
      // 
      this.lblCaptionCategory.AutoSize = true;
      this.lblCaptionCategory.Location = new System.Drawing.Point(3, 93);
      this.lblCaptionCategory.Margin = new System.Windows.Forms.Padding(3, 1, 10, 1);
      this.lblCaptionCategory.Name = "lblCaptionCategory";
      this.lblCaptionCategory.Padding = new System.Windows.Forms.Padding(4);
      this.lblCaptionCategory.Size = new System.Drawing.Size(57, 21);
      this.lblCaptionCategory.TabIndex = 8;
      this.lblCaptionCategory.Text = "Category";
      // 
      // txtDataNumber
      // 
      this.txtDataNumber.BackColor = System.Drawing.SystemColors.Window;
      this.txtDataNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.txtDataNumber.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txtDataNumber.Location = new System.Drawing.Point(101, 4);
      this.txtDataNumber.Margin = new System.Windows.Forms.Padding(3, 4, 3, 1);
      this.txtDataNumber.Name = "txtDataNumber";
      this.txtDataNumber.ReadOnly = true;
      this.txtDataNumber.Size = new System.Drawing.Size(282, 13);
      this.txtDataNumber.TabIndex = 1;
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
      this.txtDataLevel.Size = new System.Drawing.Size(282, 13);
      this.txtDataLevel.TabIndex = 3;
      // 
      // txtDataDateAndTime
      // 
      this.txtDataDateAndTime.BackColor = System.Drawing.SystemColors.Window;
      this.txtDataDateAndTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.txtDataDateAndTime.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txtDataDateAndTime.Location = new System.Drawing.Point(101, 50);
      this.txtDataDateAndTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 1);
      this.txtDataDateAndTime.Name = "txtDataDateAndTime";
      this.txtDataDateAndTime.ReadOnly = true;
      this.txtDataDateAndTime.Size = new System.Drawing.Size(282, 13);
      this.txtDataDateAndTime.TabIndex = 5;
      // 
      // txtDataLogger
      // 
      this.txtDataLogger.BackColor = System.Drawing.SystemColors.Window;
      this.txtDataLogger.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.txtDataLogger.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txtDataLogger.Location = new System.Drawing.Point(101, 73);
      this.txtDataLogger.Margin = new System.Windows.Forms.Padding(3, 4, 3, 1);
      this.txtDataLogger.Name = "txtDataLogger";
      this.txtDataLogger.ReadOnly = true;
      this.txtDataLogger.Size = new System.Drawing.Size(282, 13);
      this.txtDataLogger.TabIndex = 7;
      // 
      // txtDataCategory
      // 
      this.txtDataCategory.BackColor = System.Drawing.SystemColors.Window;
      this.txtDataCategory.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.txtDataCategory.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txtDataCategory.Location = new System.Drawing.Point(99, 96);
      this.txtDataCategory.Margin = new System.Windows.Forms.Padding(1, 4, 3, 1);
      this.txtDataCategory.Name = "txtDataCategory";
      this.txtDataCategory.ReadOnly = true;
      this.txtDataCategory.Size = new System.Drawing.Size(284, 13);
      this.txtDataCategory.TabIndex = 9;
      // 
      // txtDataUsername
      // 
      this.txtDataUsername.BackColor = System.Drawing.SystemColors.Window;
      this.txtDataUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.txtDataUsername.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txtDataUsername.Location = new System.Drawing.Point(101, 119);
      this.txtDataUsername.Margin = new System.Windows.Forms.Padding(3, 4, 3, 1);
      this.txtDataUsername.Name = "txtDataUsername";
      this.txtDataUsername.ReadOnly = true;
      this.txtDataUsername.Size = new System.Drawing.Size(282, 13);
      this.txtDataUsername.TabIndex = 11;
      // 
      // txtDataMessage
      // 
      this.txtDataMessage.BackColor = System.Drawing.SystemColors.Window;
      this.txtDataMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.txtDataMessage.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txtDataMessage.Location = new System.Drawing.Point(101, 165);
      this.txtDataMessage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 1);
      this.txtDataMessage.Multiline = true;
      this.txtDataMessage.Name = "txtDataMessage";
      this.txtDataMessage.ReadOnly = true;
      this.txtDataMessage.Size = new System.Drawing.Size(282, 18);
      this.txtDataMessage.TabIndex = 15;
      // 
      // lblCaptionMessage
      // 
      this.lblCaptionMessage.AutoSize = true;
      this.lblCaptionMessage.Location = new System.Drawing.Point(3, 162);
      this.lblCaptionMessage.Margin = new System.Windows.Forms.Padding(3, 1, 10, 1);
      this.lblCaptionMessage.Name = "lblCaptionMessage";
      this.lblCaptionMessage.Padding = new System.Windows.Forms.Padding(4);
      this.lblCaptionMessage.Size = new System.Drawing.Size(58, 21);
      this.lblCaptionMessage.TabIndex = 14;
      this.lblCaptionMessage.Text = "Message";
      // 
      // lblCaptionInstanceId
      // 
      this.lblCaptionInstanceId.AutoSize = true;
      this.lblCaptionInstanceId.Location = new System.Drawing.Point(3, 139);
      this.lblCaptionInstanceId.Margin = new System.Windows.Forms.Padding(3, 1, 10, 1);
      this.lblCaptionInstanceId.Name = "lblCaptionInstanceId";
      this.lblCaptionInstanceId.Padding = new System.Windows.Forms.Padding(4);
      this.lblCaptionInstanceId.Size = new System.Drawing.Size(70, 21);
      this.lblCaptionInstanceId.TabIndex = 12;
      this.lblCaptionInstanceId.Text = "Instance ID";
      // 
      // EventLogDetailsControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.LogMessagePanel);
      this.Controls.Add(this.logDetailToolStrip);
      this.Name = "EventLogDetailsControl";
      this.Size = new System.Drawing.Size(430, 193);
      this.logDetailToolStrip.ResumeLayout(false);
      this.logDetailToolStrip.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pbxCopyCategory)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbxCopyLogger)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbxCopyDateAndTime)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbxCopyLevel)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbxCopyNumber)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbxCopyUsername)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbxCopyMessage)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbxCopyInstanceId)).EndInit();
      this.LogMessagePanel.ResumeLayout(false);
      this.LogMessagePanel.PerformLayout();
      this.tblLogMessage.ResumeLayout(false);
      this.tblLogMessage.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private GuiLibrary.Controls.ToolStripEx logDetailToolStrip;
    private System.Windows.Forms.ToolStripButton tsbZoomIn;
    private System.Windows.Forms.ToolStripButton tsbZoomOut;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripButton tsbCopy;
    private System.Windows.Forms.TableLayoutPanel tblLogMessage;
    private GuiLibrary.Controls.InfoPanel LogMessagePanel;
    private System.Windows.Forms.Label lblCaptionNumber;
    private System.Windows.Forms.Label lblCaptionLevel;
    private System.Windows.Forms.Label lblCaptionDateAndTime;
    private System.Windows.Forms.Label lblCaptionLogger;
    private System.Windows.Forms.Label lblCaptionCategory;
    private System.Windows.Forms.TextBox txtDataNumber;
    private System.Windows.Forms.TextBox txtDataLevel;
    private System.Windows.Forms.TextBox txtDataDateAndTime;
    private System.Windows.Forms.TextBox txtDataLogger;
    private System.Windows.Forms.TextBox txtDataCategory;
    private GuiLibrary.Controls.PictureBoxEx pbxCopyNumber;
    private GuiLibrary.Controls.PictureBoxEx pbxCopyCategory;
    private GuiLibrary.Controls.PictureBoxEx pbxCopyLogger;
    private GuiLibrary.Controls.PictureBoxEx pbxCopyDateAndTime;
    private GuiLibrary.Controls.PictureBoxEx pbxCopyLevel;
    private System.Windows.Forms.ToolTip tltTip;
    private System.Windows.Forms.Label lblCaptionUsername;
    private System.Windows.Forms.TextBox txtDataUsername;
    private GuiLibrary.Controls.PictureBoxEx pbxCopyUsername;
    private System.Windows.Forms.Label lblCaptionMessage;
    private System.Windows.Forms.TextBox txtDataMessage;
    private GuiLibrary.Controls.PictureBoxEx pbxCopyMessage;
    private GuiLibrary.Controls.PictureBoxEx pbxCopyInstanceId;
    private System.Windows.Forms.Label lblCaptionInstanceId;
    private System.Windows.Forms.TextBox txtDataInstaceId; 
  }
}
