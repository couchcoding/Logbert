namespace Couchcoding.Logbert.Controls
{
  partial class SyslogDetailsControl
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
      this.pbxCopyFacility = new Couchcoding.Logbert.Gui.Controls.PictureBoxEx();
      this.pbxCopyTime = new Couchcoding.Logbert.Gui.Controls.PictureBoxEx();
      this.pbxCopyLocalMachineTime = new Couchcoding.Logbert.Gui.Controls.PictureBoxEx();
      this.pbxCopySeverity = new Couchcoding.Logbert.Gui.Controls.PictureBoxEx();
      this.pbxCopyNumber = new Couchcoding.Logbert.Gui.Controls.PictureBoxEx();
      this.pbxCopySender = new Couchcoding.Logbert.Gui.Controls.PictureBoxEx();
      this.pbxCopyMessage = new Couchcoding.Logbert.Gui.Controls.PictureBoxEx();
      this.LogMessagePanel = new Couchcoding.Logbert.Gui.Controls.InfoPanel();
      this.tblLogMessage = new System.Windows.Forms.TableLayoutPanel();
      this.lblCaptionMessage = new System.Windows.Forms.Label();
      this.txtDataMessage = new System.Windows.Forms.TextBox();
      this.lblCaptionSender = new System.Windows.Forms.Label();
      this.lblCaptionNumber = new System.Windows.Forms.Label();
      this.lblCaptionSeverity = new System.Windows.Forms.Label();
      this.lblCaptionLocalMachineTime = new System.Windows.Forms.Label();
      this.lblCaptionTime = new System.Windows.Forms.Label();
      this.lblCaptionFacility = new System.Windows.Forms.Label();
      this.txtDataNumber = new System.Windows.Forms.TextBox();
      this.txtDataSeverity = new System.Windows.Forms.TextBox();
      this.txtDataLocalMachineTime = new System.Windows.Forms.TextBox();
      this.txtDataTime = new System.Windows.Forms.TextBox();
      this.txtDataFacility = new System.Windows.Forms.TextBox();
      this.txtDataSender = new System.Windows.Forms.TextBox();
      this.logDetailToolStrip.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pbxCopyFacility)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbxCopyTime)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbxCopyLocalMachineTime)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbxCopySeverity)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbxCopyNumber)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbxCopySender)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbxCopyMessage)).BeginInit();
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
      // pbxCopyFacility
      // 
      this.pbxCopyFacility.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.pbxCopyFacility.Cursor = System.Windows.Forms.Cursors.Hand;
      this.pbxCopyFacility.Location = new System.Drawing.Point(405, 94);
      this.pbxCopyFacility.Margin = new System.Windows.Forms.Padding(2, 2, 1, 1);
      this.pbxCopyFacility.Name = "pbxCopyFacility";
      this.pbxCopyFacility.Size = new System.Drawing.Size(17, 18);
      this.pbxCopyFacility.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
      this.pbxCopyFacility.TabIndex = 14;
      this.pbxCopyFacility.TabStop = false;
      this.tltTip.SetToolTip(this.pbxCopyFacility, "Copy Facility Details to the Clipboard");
      this.pbxCopyFacility.Visible = false;
      this.pbxCopyFacility.Click += new System.EventHandler(this.PbxCopyFacilityClick);
      // 
      // pbxCopyTime
      // 
      this.pbxCopyTime.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.pbxCopyTime.Cursor = System.Windows.Forms.Cursors.Hand;
      this.pbxCopyTime.Location = new System.Drawing.Point(405, 71);
      this.pbxCopyTime.Margin = new System.Windows.Forms.Padding(2, 2, 1, 1);
      this.pbxCopyTime.Name = "pbxCopyTime";
      this.pbxCopyTime.Size = new System.Drawing.Size(17, 18);
      this.pbxCopyTime.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
      this.pbxCopyTime.TabIndex = 13;
      this.pbxCopyTime.TabStop = false;
      this.tltTip.SetToolTip(this.pbxCopyTime, "Copy Time Details to the Clipboard");
      this.pbxCopyTime.Visible = false;
      this.pbxCopyTime.Click += new System.EventHandler(this.PbxCopyTimeClick);
      // 
      // pbxCopyLocalMachineTime
      // 
      this.pbxCopyLocalMachineTime.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.pbxCopyLocalMachineTime.Cursor = System.Windows.Forms.Cursors.Hand;
      this.pbxCopyLocalMachineTime.Location = new System.Drawing.Point(405, 48);
      this.pbxCopyLocalMachineTime.Margin = new System.Windows.Forms.Padding(2, 2, 1, 1);
      this.pbxCopyLocalMachineTime.Name = "pbxCopyLocalMachineTime";
      this.pbxCopyLocalMachineTime.Size = new System.Drawing.Size(17, 18);
      this.pbxCopyLocalMachineTime.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
      this.pbxCopyLocalMachineTime.TabIndex = 12;
      this.pbxCopyLocalMachineTime.TabStop = false;
      this.tltTip.SetToolTip(this.pbxCopyLocalMachineTime, "Copy Local Machine Date and Time Details to the Clipboard");
      this.pbxCopyLocalMachineTime.Visible = false;
      this.pbxCopyLocalMachineTime.Click += new System.EventHandler(this.PbxCopyLocalMachineTimeClick);
      // 
      // pbxCopySeverity
      // 
      this.pbxCopySeverity.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.pbxCopySeverity.Cursor = System.Windows.Forms.Cursors.Hand;
      this.pbxCopySeverity.Location = new System.Drawing.Point(405, 25);
      this.pbxCopySeverity.Margin = new System.Windows.Forms.Padding(2, 2, 1, 1);
      this.pbxCopySeverity.Name = "pbxCopySeverity";
      this.pbxCopySeverity.Size = new System.Drawing.Size(17, 18);
      this.pbxCopySeverity.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
      this.pbxCopySeverity.TabIndex = 11;
      this.pbxCopySeverity.TabStop = false;
      this.tltTip.SetToolTip(this.pbxCopySeverity, "Copy Severity Details to the Clipboard");
      this.pbxCopySeverity.Visible = false;
      this.pbxCopySeverity.Click += new System.EventHandler(this.PbxCopySeverityClick);
      // 
      // pbxCopyNumber
      // 
      this.pbxCopyNumber.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.pbxCopyNumber.Cursor = System.Windows.Forms.Cursors.Hand;
      this.pbxCopyNumber.Location = new System.Drawing.Point(405, 2);
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
      // pbxCopySender
      // 
      this.pbxCopySender.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.pbxCopySender.Cursor = System.Windows.Forms.Cursors.Hand;
      this.pbxCopySender.Location = new System.Drawing.Point(405, 117);
      this.pbxCopySender.Margin = new System.Windows.Forms.Padding(2, 2, 1, 1);
      this.pbxCopySender.Name = "pbxCopySender";
      this.pbxCopySender.Size = new System.Drawing.Size(17, 18);
      this.pbxCopySender.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
      this.pbxCopySender.TabIndex = 17;
      this.pbxCopySender.TabStop = false;
      this.tltTip.SetToolTip(this.pbxCopySender, "Copy Sender Details to the Clipboard");
      this.pbxCopySender.Visible = false;
      this.pbxCopySender.Click += new System.EventHandler(this.PbxCopySenderClick);
      // 
      // pbxCopyMessage
      // 
      this.pbxCopyMessage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.pbxCopyMessage.Cursor = System.Windows.Forms.Cursors.Hand;
      this.pbxCopyMessage.Location = new System.Drawing.Point(405, 140);
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
      this.tblLogMessage.Controls.Add(this.lblCaptionMessage, 0, 6);
      this.tblLogMessage.Controls.Add(this.txtDataMessage, 0, 6);
      this.tblLogMessage.Controls.Add(this.pbxCopyMessage, 0, 6);
      this.tblLogMessage.Controls.Add(this.lblCaptionSender, 0, 5);
      this.tblLogMessage.Controls.Add(this.pbxCopyFacility, 2, 4);
      this.tblLogMessage.Controls.Add(this.pbxCopyTime, 2, 3);
      this.tblLogMessage.Controls.Add(this.pbxCopyLocalMachineTime, 2, 2);
      this.tblLogMessage.Controls.Add(this.pbxCopySeverity, 2, 1);
      this.tblLogMessage.Controls.Add(this.lblCaptionNumber, 0, 0);
      this.tblLogMessage.Controls.Add(this.lblCaptionSeverity, 0, 1);
      this.tblLogMessage.Controls.Add(this.lblCaptionLocalMachineTime, 0, 2);
      this.tblLogMessage.Controls.Add(this.lblCaptionTime, 0, 3);
      this.tblLogMessage.Controls.Add(this.lblCaptionFacility, 0, 4);
      this.tblLogMessage.Controls.Add(this.txtDataNumber, 1, 0);
      this.tblLogMessage.Controls.Add(this.txtDataSeverity, 1, 1);
      this.tblLogMessage.Controls.Add(this.txtDataLocalMachineTime, 1, 2);
      this.tblLogMessage.Controls.Add(this.txtDataTime, 1, 3);
      this.tblLogMessage.Controls.Add(this.txtDataFacility, 1, 4);
      this.tblLogMessage.Controls.Add(this.pbxCopyNumber, 2, 0);
      this.tblLogMessage.Controls.Add(this.txtDataSender, 1, 5);
      this.tblLogMessage.Controls.Add(this.pbxCopySender, 2, 5);
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
      // lblCaptionMessage
      // 
      this.lblCaptionMessage.AutoSize = true;
      this.lblCaptionMessage.Location = new System.Drawing.Point(3, 139);
      this.lblCaptionMessage.Margin = new System.Windows.Forms.Padding(3, 1, 10, 1);
      this.lblCaptionMessage.Name = "lblCaptionMessage";
      this.lblCaptionMessage.Padding = new System.Windows.Forms.Padding(4);
      this.lblCaptionMessage.Size = new System.Drawing.Size(58, 21);
      this.lblCaptionMessage.TabIndex = 12;
      this.lblCaptionMessage.Text = "Message";
      // 
      // txtDataMessage
      // 
      this.txtDataMessage.BackColor = System.Drawing.SystemColors.Window;
      this.txtDataMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.txtDataMessage.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txtDataMessage.Location = new System.Drawing.Point(127, 142);
      this.txtDataMessage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 1);
      this.txtDataMessage.Multiline = true;
      this.txtDataMessage.Name = "txtDataMessage";
      this.txtDataMessage.ReadOnly = true;
      this.txtDataMessage.Size = new System.Drawing.Size(273, 18);
      this.txtDataMessage.TabIndex = 13;
      // 
      // lblCaptionSender
      // 
      this.lblCaptionSender.AutoSize = true;
      this.lblCaptionSender.Location = new System.Drawing.Point(3, 116);
      this.lblCaptionSender.Margin = new System.Windows.Forms.Padding(3, 1, 10, 1);
      this.lblCaptionSender.Name = "lblCaptionSender";
      this.lblCaptionSender.Padding = new System.Windows.Forms.Padding(4);
      this.lblCaptionSender.Size = new System.Drawing.Size(49, 21);
      this.lblCaptionSender.TabIndex = 10;
      this.lblCaptionSender.Text = "Sender";
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
      // lblCaptionSeverity
      // 
      this.lblCaptionSeverity.AutoSize = true;
      this.lblCaptionSeverity.Location = new System.Drawing.Point(3, 24);
      this.lblCaptionSeverity.Margin = new System.Windows.Forms.Padding(3, 1, 10, 1);
      this.lblCaptionSeverity.Name = "lblCaptionSeverity";
      this.lblCaptionSeverity.Padding = new System.Windows.Forms.Padding(4);
      this.lblCaptionSeverity.Size = new System.Drawing.Size(53, 21);
      this.lblCaptionSeverity.TabIndex = 2;
      this.lblCaptionSeverity.Text = "Severity";
      // 
      // lblCaptionLocalMachineTime
      // 
      this.lblCaptionLocalMachineTime.AutoSize = true;
      this.lblCaptionLocalMachineTime.Location = new System.Drawing.Point(3, 47);
      this.lblCaptionLocalMachineTime.Margin = new System.Windows.Forms.Padding(3, 1, 10, 1);
      this.lblCaptionLocalMachineTime.Name = "lblCaptionLocalMachineTime";
      this.lblCaptionLocalMachineTime.Padding = new System.Windows.Forms.Padding(4);
      this.lblCaptionLocalMachineTime.Size = new System.Drawing.Size(111, 21);
      this.lblCaptionLocalMachineTime.TabIndex = 4;
      this.lblCaptionLocalMachineTime.Text = "Local Machine Time";
      // 
      // lblCaptionTime
      // 
      this.lblCaptionTime.AutoSize = true;
      this.lblCaptionTime.Location = new System.Drawing.Point(3, 70);
      this.lblCaptionTime.Margin = new System.Windows.Forms.Padding(3, 1, 10, 1);
      this.lblCaptionTime.Name = "lblCaptionTime";
      this.lblCaptionTime.Padding = new System.Windows.Forms.Padding(4);
      this.lblCaptionTime.Size = new System.Drawing.Size(38, 21);
      this.lblCaptionTime.TabIndex = 6;
      this.lblCaptionTime.Text = "Time";
      // 
      // lblCaptionFacility
      // 
      this.lblCaptionFacility.AutoSize = true;
      this.lblCaptionFacility.Location = new System.Drawing.Point(3, 93);
      this.lblCaptionFacility.Margin = new System.Windows.Forms.Padding(3, 1, 10, 1);
      this.lblCaptionFacility.Name = "lblCaptionFacility";
      this.lblCaptionFacility.Padding = new System.Windows.Forms.Padding(4);
      this.lblCaptionFacility.Size = new System.Drawing.Size(47, 21);
      this.lblCaptionFacility.TabIndex = 8;
      this.lblCaptionFacility.Text = "Facility";
      // 
      // txtDataNumber
      // 
      this.txtDataNumber.BackColor = System.Drawing.SystemColors.Window;
      this.txtDataNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.txtDataNumber.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txtDataNumber.Location = new System.Drawing.Point(127, 4);
      this.txtDataNumber.Margin = new System.Windows.Forms.Padding(3, 4, 3, 1);
      this.txtDataNumber.Name = "txtDataNumber";
      this.txtDataNumber.ReadOnly = true;
      this.txtDataNumber.Size = new System.Drawing.Size(273, 13);
      this.txtDataNumber.TabIndex = 1;
      // 
      // txtDataSeverity
      // 
      this.txtDataSeverity.BackColor = System.Drawing.SystemColors.Window;
      this.txtDataSeverity.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.txtDataSeverity.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txtDataSeverity.Location = new System.Drawing.Point(127, 27);
      this.txtDataSeverity.Margin = new System.Windows.Forms.Padding(3, 4, 3, 1);
      this.txtDataSeverity.Name = "txtDataSeverity";
      this.txtDataSeverity.ReadOnly = true;
      this.txtDataSeverity.Size = new System.Drawing.Size(273, 13);
      this.txtDataSeverity.TabIndex = 3;
      // 
      // txtDataLocalMachineTime
      // 
      this.txtDataLocalMachineTime.BackColor = System.Drawing.SystemColors.Window;
      this.txtDataLocalMachineTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.txtDataLocalMachineTime.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txtDataLocalMachineTime.Location = new System.Drawing.Point(127, 50);
      this.txtDataLocalMachineTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 1);
      this.txtDataLocalMachineTime.Name = "txtDataLocalMachineTime";
      this.txtDataLocalMachineTime.ReadOnly = true;
      this.txtDataLocalMachineTime.Size = new System.Drawing.Size(273, 13);
      this.txtDataLocalMachineTime.TabIndex = 5;
      // 
      // txtDataTime
      // 
      this.txtDataTime.BackColor = System.Drawing.SystemColors.Window;
      this.txtDataTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.txtDataTime.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txtDataTime.Location = new System.Drawing.Point(127, 73);
      this.txtDataTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 1);
      this.txtDataTime.Name = "txtDataTime";
      this.txtDataTime.ReadOnly = true;
      this.txtDataTime.Size = new System.Drawing.Size(273, 13);
      this.txtDataTime.TabIndex = 7;
      // 
      // txtDataFacility
      // 
      this.txtDataFacility.BackColor = System.Drawing.SystemColors.Window;
      this.txtDataFacility.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.txtDataFacility.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txtDataFacility.Location = new System.Drawing.Point(125, 96);
      this.txtDataFacility.Margin = new System.Windows.Forms.Padding(1, 4, 3, 1);
      this.txtDataFacility.Name = "txtDataFacility";
      this.txtDataFacility.ReadOnly = true;
      this.txtDataFacility.Size = new System.Drawing.Size(275, 13);
      this.txtDataFacility.TabIndex = 9;
      // 
      // txtDataSender
      // 
      this.txtDataSender.BackColor = System.Drawing.SystemColors.Window;
      this.txtDataSender.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.txtDataSender.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txtDataSender.Location = new System.Drawing.Point(127, 119);
      this.txtDataSender.Margin = new System.Windows.Forms.Padding(3, 4, 3, 1);
      this.txtDataSender.Name = "txtDataSender";
      this.txtDataSender.ReadOnly = true;
      this.txtDataSender.Size = new System.Drawing.Size(273, 13);
      this.txtDataSender.TabIndex = 11;
      // 
      // SyslogDetailsControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.LogMessagePanel);
      this.Controls.Add(this.logDetailToolStrip);
      this.Name = "SyslogDetailsControl";
      this.Size = new System.Drawing.Size(430, 193);
      this.logDetailToolStrip.ResumeLayout(false);
      this.logDetailToolStrip.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pbxCopyFacility)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbxCopyTime)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbxCopyLocalMachineTime)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbxCopySeverity)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbxCopyNumber)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbxCopySender)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbxCopyMessage)).EndInit();
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
    private System.Windows.Forms.Label lblCaptionNumber;
    private System.Windows.Forms.Label lblCaptionSeverity;
    private System.Windows.Forms.Label lblCaptionLocalMachineTime;
    private System.Windows.Forms.Label lblCaptionTime;
    private System.Windows.Forms.Label lblCaptionFacility;
    private System.Windows.Forms.TextBox txtDataNumber;
    private System.Windows.Forms.TextBox txtDataSeverity;
    private System.Windows.Forms.TextBox txtDataLocalMachineTime;
    private System.Windows.Forms.TextBox txtDataTime;
    private System.Windows.Forms.TextBox txtDataFacility;
    private Gui.Controls.PictureBoxEx pbxCopyNumber;
    private Gui.Controls.PictureBoxEx pbxCopyFacility;
    private Gui.Controls.PictureBoxEx pbxCopyTime;
    private Gui.Controls.PictureBoxEx pbxCopyLocalMachineTime;
    private Gui.Controls.PictureBoxEx pbxCopySeverity;
    private System.Windows.Forms.ToolTip tltTip;
    private System.Windows.Forms.Label lblCaptionSender;
    private System.Windows.Forms.TextBox txtDataSender;
    private Gui.Controls.PictureBoxEx pbxCopySender;
    private System.Windows.Forms.Label lblCaptionMessage;
    private System.Windows.Forms.TextBox txtDataMessage;
    private Gui.Controls.PictureBoxEx pbxCopyMessage;
  }
}
