namespace Couchcoding.Logbert.Dialogs.Docking
{
  partial class FrmLogBookmarks
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogBookmarks));
            this.toolStrip1 = new Couchcoding.Logbert.Gui.Controls.ToolStripEx();
            this.tsbRemoveBookmark = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbPreviousBookmark = new System.Windows.Forms.ToolStripButton();
            this.tsbNextBookmark = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbZoomIn = new System.Windows.Forms.ToolStripButton();
            this.tsbZoomOut = new System.Windows.Forms.ToolStripButton();
            this.dgvBookmarks = new System.Windows.Forms.DataGridView();
            this.clmImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.clmRow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookmarks)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbRemoveBookmark,
            this.toolStripSeparator1,
            this.tsbPreviousBookmark,
            this.tsbNextBookmark,
            this.toolStripSeparator2,
            this.tsbZoomIn,
            this.tsbZoomOut});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(464, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "Bookmarks";
            // 
            // tsbRemoveBookmark
            // 
            this.tsbRemoveBookmark.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRemoveBookmark.Enabled = false;
            this.tsbRemoveBookmark.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRemoveBookmark.Margin = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.tsbRemoveBookmark.Name = "tsbRemoveBookmark";
            this.tsbRemoveBookmark.Size = new System.Drawing.Size(23, 22);
            this.tsbRemoveBookmark.Text = "Remove Bookmark";
            this.tsbRemoveBookmark.Click += new System.EventHandler(this.TsbRemoveBookmarkClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbPreviousBookmark
            // 
            this.tsbPreviousBookmark.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPreviousBookmark.Enabled = false;
            this.tsbPreviousBookmark.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPreviousBookmark.Name = "tsbPreviousBookmark";
            this.tsbPreviousBookmark.Size = new System.Drawing.Size(23, 22);
            this.tsbPreviousBookmark.Text = "Previous Bookmark";
            this.tsbPreviousBookmark.Click += new System.EventHandler(this.TsbPreviousBookmarkClick);
            // 
            // tsbNextBookmark
            // 
            this.tsbNextBookmark.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNextBookmark.Enabled = false;
            this.tsbNextBookmark.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNextBookmark.Name = "tsbNextBookmark";
            this.tsbNextBookmark.Size = new System.Drawing.Size(23, 22);
            this.tsbNextBookmark.Text = "Next Bookmark";
            this.tsbNextBookmark.Click += new System.EventHandler(this.TsbNextBookmarkClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbZoomIn
            // 
            this.tsbZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbZoomIn.Name = "tsbZoomIn";
            this.tsbZoomIn.Size = new System.Drawing.Size(23, 22);
            this.tsbZoomIn.Text = "Zoom In";
            this.tsbZoomIn.Click += new System.EventHandler(this.TsbZoomInClick);
            // 
            // tsbZoomOut
            // 
            this.tsbZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbZoomOut.Name = "tsbZoomOut";
            this.tsbZoomOut.Size = new System.Drawing.Size(23, 22);
            this.tsbZoomOut.Text = "Zoom Out";
            this.tsbZoomOut.Click += new System.EventHandler(this.TsbZoomOutClick);
            // 
            // dgvBookmarks
            // 
            this.dgvBookmarks.AllowUserToAddRows = false;
            this.dgvBookmarks.AllowUserToDeleteRows = false;
            this.dgvBookmarks.AllowUserToResizeRows = false;
            this.dgvBookmarks.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvBookmarks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBookmarks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBookmarks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBookmarks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmImage,
            this.clmRow,
            this.clmMessage});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBookmarks.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBookmarks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBookmarks.Location = new System.Drawing.Point(0, 25);
            this.dgvBookmarks.MultiSelect = false;
            this.dgvBookmarks.Name = "dgvBookmarks";
            this.dgvBookmarks.ReadOnly = true;
            this.dgvBookmarks.RowHeadersVisible = false;
            this.dgvBookmarks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBookmarks.ShowCellErrors = false;
            this.dgvBookmarks.ShowCellToolTips = false;
            this.dgvBookmarks.ShowEditingIcon = false;
            this.dgvBookmarks.ShowRowErrors = false;
            this.dgvBookmarks.Size = new System.Drawing.Size(464, 256);
            this.dgvBookmarks.TabIndex = 1;
            this.dgvBookmarks.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvBookmarksCellDoubleClick);
            this.dgvBookmarks.SelectionChanged += new System.EventHandler(this.DgvBookmarksSelectionChanged);
            // 
            // clmImage
            // 
            this.clmImage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.clmImage.HeaderText = "";
            this.clmImage.MinimumWidth = 20;
            this.clmImage.Name = "clmImage";
            this.clmImage.ReadOnly = true;
            this.clmImage.Width = 20;
            // 
            // clmRow
            // 
            this.clmRow.FillWeight = 30F;
            this.clmRow.HeaderText = "Number";
            this.clmRow.MinimumWidth = 40;
            this.clmRow.Name = "clmRow";
            this.clmRow.ReadOnly = true;
            // 
            // clmMessage
            // 
            this.clmMessage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmMessage.FillWeight = 70F;
            this.clmMessage.HeaderText = "Message";
            this.clmMessage.MinimumWidth = 40;
            this.clmMessage.Name = "clmMessage";
            this.clmMessage.ReadOnly = true;
            // 
            // FrmLogBookmarks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 281);
            this.Controls.Add(this.dgvBookmarks);
            this.Controls.Add(this.toolStrip1);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)(((((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom)));
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmLogBookmarks";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockBottom;
            this.ShowInTaskbar = false;
            this.Text = "Bookmarks";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookmarks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private Couchcoding.Logbert.Gui.Controls.ToolStripEx toolStrip1;
    private System.Windows.Forms.ToolStripButton tsbRemoveBookmark;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripButton tsbPreviousBookmark;
    private System.Windows.Forms.ToolStripButton tsbNextBookmark;
    private System.Windows.Forms.DataGridView dgvBookmarks;
    private System.Windows.Forms.DataGridViewImageColumn clmImage;
    private System.Windows.Forms.DataGridViewTextBoxColumn clmRow;
    private System.Windows.Forms.DataGridViewTextBoxColumn clmMessage;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.ToolStripButton tsbZoomIn;
    private System.Windows.Forms.ToolStripButton tsbZoomOut;
  }
}
