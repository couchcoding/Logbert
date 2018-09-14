namespace Couchcoding.Logbert.Controls
{
  partial class CustomDetailsControl
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
      this.pbxCopyNumber = new Couchcoding.Logbert.Gui.Controls.PictureBoxEx();
      this.LogMessagePanel = new Couchcoding.Logbert.Gui.Controls.InfoPanel();
      this.tblLogMessage = new System.Windows.Forms.TableLayoutPanel();
      this.lblCaptionNumber = new System.Windows.Forms.Label();
      this.txtDataNumber = new System.Windows.Forms.TextBox();
      this.logDetailToolStrip.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pbxCopyNumber)).BeginInit();
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
      this.tblLogMessage.Controls.Add(this.lblCaptionNumber, 0, 0);
      this.tblLogMessage.Controls.Add(this.txtDataNumber, 1, 0);
      this.tblLogMessage.Controls.Add(this.pbxCopyNumber, 2, 0);
      this.tblLogMessage.Location = new System.Drawing.Point(3, 3);
      this.tblLogMessage.Name = "tblLogMessage";
      this.tblLogMessage.RowCount = 1;
      this.tblLogMessage.RowStyles.Add(new System.Windows.Forms.RowStyle());
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
      // txtDataNumber
      // 
      this.txtDataNumber.BackColor = System.Drawing.SystemColors.Window;
      this.txtDataNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.txtDataNumber.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txtDataNumber.Location = new System.Drawing.Point(68, 4);
      this.txtDataNumber.Margin = new System.Windows.Forms.Padding(3, 4, 3, 1);
      this.txtDataNumber.Name = "txtDataNumber";
      this.txtDataNumber.ReadOnly = true;
      this.txtDataNumber.Size = new System.Drawing.Size(332, 13);
      this.txtDataNumber.TabIndex = 1;
      // 
      // CustomDetailsControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.LogMessagePanel);
      this.Controls.Add(this.logDetailToolStrip);
      this.Name = "CustomDetailsControl";
      this.Size = new System.Drawing.Size(430, 193);
      this.logDetailToolStrip.ResumeLayout(false);
      this.logDetailToolStrip.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pbxCopyNumber)).EndInit();
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
    private System.Windows.Forms.TextBox txtDataNumber;
    private Gui.Controls.PictureBoxEx pbxCopyNumber;
    private System.Windows.Forms.ToolTip tltTip;
  }
}
