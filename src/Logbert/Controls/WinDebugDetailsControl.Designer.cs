namespace Couchcoding.Logbert.Controls
{
  partial class WinDebugDetailsControl
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
            this.pbxCopyProcessId = new Couchcoding.Logbert.Gui.Controls.PictureBoxEx();
            this.pbxCopyTime = new Couchcoding.Logbert.Gui.Controls.PictureBoxEx();
            this.pbxCopyLevel = new Couchcoding.Logbert.Gui.Controls.PictureBoxEx();
            this.pbxCopyNumber = new Couchcoding.Logbert.Gui.Controls.PictureBoxEx();
            this.pbxCopyMessage = new Couchcoding.Logbert.Gui.Controls.PictureBoxEx();
            this.LogMessagePanel = new Couchcoding.Logbert.Gui.Controls.InfoPanel();
            this.tblLogMessage = new System.Windows.Forms.TableLayoutPanel();
            this.lblCaptionNumber = new System.Windows.Forms.Label();
            this.lblCaptionLevel = new System.Windows.Forms.Label();
            this.lblCaptionTime = new System.Windows.Forms.Label();
            this.lblCaptionProcessId = new System.Windows.Forms.Label();
            this.txtDataNumber = new System.Windows.Forms.TextBox();
            this.txtDataLevel = new System.Windows.Forms.TextBox();
            this.txtDataTime = new System.Windows.Forms.TextBox();
            this.txtDataProcessId = new System.Windows.Forms.TextBox();
            this.txtDataMessage = new System.Windows.Forms.TextBox();
            this.lblCaptionMessage = new System.Windows.Forms.Label();
            this.logDetailToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCopyProcessId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCopyTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCopyLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCopyNumber)).BeginInit();
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
            this.tsbCopy.Size = new System.Drawing.Size(77, 22);
            this.tsbCopy.Text = "Copy Details";
            this.tsbCopy.Click += new System.EventHandler(this.TsbCopyClick);
            // 
            // pbxCopyProcessId
            // 
            this.pbxCopyProcessId.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbxCopyProcessId.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxCopyProcessId.Location = new System.Drawing.Point(405, 71);
            this.pbxCopyProcessId.Margin = new System.Windows.Forms.Padding(2, 2, 1, 1);
            this.pbxCopyProcessId.Name = "pbxCopyProcessId";
            this.pbxCopyProcessId.Size = new System.Drawing.Size(17, 18);
            this.pbxCopyProcessId.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbxCopyProcessId.TabIndex = 14;
            this.pbxCopyProcessId.TabStop = false;
            this.tltTip.SetToolTip(this.pbxCopyProcessId, "Copy Facility Details to the Clipboard");
            this.pbxCopyProcessId.Visible = false;
            this.pbxCopyProcessId.Click += new System.EventHandler(this.PbxCopyProcessIdClick);
            // 
            // pbxCopyTime
            // 
            this.pbxCopyTime.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbxCopyTime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxCopyTime.Location = new System.Drawing.Point(405, 48);
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
            // pbxCopyMessage
            // 
            this.pbxCopyMessage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbxCopyMessage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxCopyMessage.Location = new System.Drawing.Point(405, 94);
            this.pbxCopyMessage.Margin = new System.Windows.Forms.Padding(2, 2, 1, 1);
            this.pbxCopyMessage.Name = "pbxCopyMessage";
            this.pbxCopyMessage.Size = new System.Drawing.Size(17, 18);
            this.pbxCopyMessage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbxCopyMessage.TabIndex = 21;
            this.pbxCopyMessage.TabStop = false;
            this.tltTip.SetToolTip(this.pbxCopyMessage, "Copy Message Details to the Clipboard");
            this.pbxCopyMessage.Visible = false;
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
            this.tblLogMessage.Controls.Add(this.pbxCopyProcessId, 2, 3);
            this.tblLogMessage.Controls.Add(this.pbxCopyTime, 2, 2);
            this.tblLogMessage.Controls.Add(this.pbxCopyLevel, 2, 1);
            this.tblLogMessage.Controls.Add(this.lblCaptionNumber, 0, 0);
            this.tblLogMessage.Controls.Add(this.lblCaptionLevel, 0, 1);
            this.tblLogMessage.Controls.Add(this.lblCaptionTime, 0, 2);
            this.tblLogMessage.Controls.Add(this.lblCaptionProcessId, 0, 3);
            this.tblLogMessage.Controls.Add(this.txtDataNumber, 1, 0);
            this.tblLogMessage.Controls.Add(this.txtDataLevel, 1, 1);
            this.tblLogMessage.Controls.Add(this.txtDataTime, 1, 2);
            this.tblLogMessage.Controls.Add(this.txtDataProcessId, 1, 3);
            this.tblLogMessage.Controls.Add(this.pbxCopyNumber, 2, 0);
            this.tblLogMessage.Controls.Add(this.pbxCopyMessage, 2, 4);
            this.tblLogMessage.Controls.Add(this.txtDataMessage, 1, 4);
            this.tblLogMessage.Controls.Add(this.lblCaptionMessage, 0, 4);
            this.tblLogMessage.Location = new System.Drawing.Point(3, 3);
            this.tblLogMessage.Name = "tblLogMessage";
            this.tblLogMessage.RowCount = 5;
            this.tblLogMessage.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblLogMessage.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblLogMessage.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblLogMessage.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblLogMessage.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblLogMessage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblLogMessage.Size = new System.Drawing.Size(424, 161);
            this.tblLogMessage.TabIndex = 0;
            this.tblLogMessage.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.TblLogMessageCellPaint);
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
            // lblCaptionTime
            // 
            this.lblCaptionTime.AutoSize = true;
            this.lblCaptionTime.Location = new System.Drawing.Point(3, 47);
            this.lblCaptionTime.Margin = new System.Windows.Forms.Padding(3, 1, 10, 1);
            this.lblCaptionTime.Name = "lblCaptionTime";
            this.lblCaptionTime.Padding = new System.Windows.Forms.Padding(4);
            this.lblCaptionTime.Size = new System.Drawing.Size(38, 21);
            this.lblCaptionTime.TabIndex = 6;
            this.lblCaptionTime.Text = "Time";
            // 
            // lblCaptionProcessId
            // 
            this.lblCaptionProcessId.AutoSize = true;
            this.lblCaptionProcessId.Location = new System.Drawing.Point(3, 70);
            this.lblCaptionProcessId.Margin = new System.Windows.Forms.Padding(3, 1, 10, 1);
            this.lblCaptionProcessId.Name = "lblCaptionProcessId";
            this.lblCaptionProcessId.Padding = new System.Windows.Forms.Padding(4);
            this.lblCaptionProcessId.Size = new System.Drawing.Size(67, 21);
            this.lblCaptionProcessId.TabIndex = 8;
            this.lblCaptionProcessId.Text = "Process ID";
            // 
            // txtDataNumber
            // 
            this.txtDataNumber.BackColor = System.Drawing.SystemColors.Window;
            this.txtDataNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDataNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDataNumber.Location = new System.Drawing.Point(83, 4);
            this.txtDataNumber.Margin = new System.Windows.Forms.Padding(3, 4, 3, 1);
            this.txtDataNumber.Name = "txtDataNumber";
            this.txtDataNumber.ReadOnly = true;
            this.txtDataNumber.Size = new System.Drawing.Size(317, 13);
            this.txtDataNumber.TabIndex = 1;
            // 
            // txtDataLevel
            // 
            this.txtDataLevel.BackColor = System.Drawing.SystemColors.Window;
            this.txtDataLevel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDataLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDataLevel.Location = new System.Drawing.Point(83, 27);
            this.txtDataLevel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 1);
            this.txtDataLevel.Name = "txtDataLevel";
            this.txtDataLevel.ReadOnly = true;
            this.txtDataLevel.Size = new System.Drawing.Size(317, 13);
            this.txtDataLevel.TabIndex = 3;
            // 
            // txtDataTime
            // 
            this.txtDataTime.BackColor = System.Drawing.SystemColors.Window;
            this.txtDataTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDataTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDataTime.Location = new System.Drawing.Point(83, 50);
            this.txtDataTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 1);
            this.txtDataTime.Name = "txtDataTime";
            this.txtDataTime.ReadOnly = true;
            this.txtDataTime.Size = new System.Drawing.Size(317, 13);
            this.txtDataTime.TabIndex = 7;
            // 
            // txtDataProcessId
            // 
            this.txtDataProcessId.BackColor = System.Drawing.SystemColors.Window;
            this.txtDataProcessId.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDataProcessId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDataProcessId.Location = new System.Drawing.Point(81, 73);
            this.txtDataProcessId.Margin = new System.Windows.Forms.Padding(1, 4, 3, 1);
            this.txtDataProcessId.Name = "txtDataProcessId";
            this.txtDataProcessId.ReadOnly = true;
            this.txtDataProcessId.Size = new System.Drawing.Size(319, 13);
            this.txtDataProcessId.TabIndex = 9;
            // 
            // txtDataMessage
            // 
            this.txtDataMessage.BackColor = System.Drawing.SystemColors.Window;
            this.txtDataMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDataMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDataMessage.Location = new System.Drawing.Point(83, 96);
            this.txtDataMessage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 1);
            this.txtDataMessage.Multiline = true;
            this.txtDataMessage.Name = "txtDataMessage";
            this.txtDataMessage.ReadOnly = true;
            this.txtDataMessage.Size = new System.Drawing.Size(317, 64);
            this.txtDataMessage.TabIndex = 13;
            // 
            // lblCaptionMessage
            // 
            this.lblCaptionMessage.AutoSize = true;
            this.lblCaptionMessage.Location = new System.Drawing.Point(3, 93);
            this.lblCaptionMessage.Margin = new System.Windows.Forms.Padding(3, 1, 10, 1);
            this.lblCaptionMessage.Name = "lblCaptionMessage";
            this.lblCaptionMessage.Padding = new System.Windows.Forms.Padding(4);
            this.lblCaptionMessage.Size = new System.Drawing.Size(58, 21);
            this.lblCaptionMessage.TabIndex = 12;
            this.lblCaptionMessage.Text = "Message";
            // 
            // WinDebugDetailsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LogMessagePanel);
            this.Controls.Add(this.logDetailToolStrip);
            this.Name = "WinDebugDetailsControl";
            this.Size = new System.Drawing.Size(430, 193);
            this.logDetailToolStrip.ResumeLayout(false);
            this.logDetailToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCopyProcessId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCopyTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCopyLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCopyNumber)).EndInit();
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
    private System.Windows.Forms.Label lblCaptionLevel;
    private System.Windows.Forms.Label lblCaptionTime;
    private System.Windows.Forms.Label lblCaptionProcessId;
    private System.Windows.Forms.TextBox txtDataNumber;
    private System.Windows.Forms.TextBox txtDataLevel;
    private System.Windows.Forms.TextBox txtDataTime;
    private System.Windows.Forms.TextBox txtDataProcessId;
    private Gui.Controls.PictureBoxEx pbxCopyNumber;
    private Gui.Controls.PictureBoxEx pbxCopyProcessId;
    private Gui.Controls.PictureBoxEx pbxCopyTime;
    private Gui.Controls.PictureBoxEx pbxCopyLevel;
    private System.Windows.Forms.ToolTip tltTip;
    private System.Windows.Forms.Label lblCaptionMessage;
    private System.Windows.Forms.TextBox txtDataMessage;
    private Gui.Controls.PictureBoxEx pbxCopyMessage;
  }
}
