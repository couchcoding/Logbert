namespace Couchcoding.Logbert.Dialogs.Docking
{
  partial class FrmLogFilter
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogFilter));
      this.tsFilter = new Couchcoding.Logbert.Gui.Controls.ToolStripEx();
      this.tsbAddFilter = new System.Windows.Forms.ToolStripButton();
      this.tsbEditFilter = new System.Windows.Forms.ToolStripButton();
      this.tsbRemoveFilter = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.tsbZoomIn = new System.Windows.Forms.ToolStripButton();
      this.tsbZoomOut = new System.Windows.Forms.ToolStripButton();
      this.dgvFilter = new System.Windows.Forms.DataGridView();
      this.clmImage = new System.Windows.Forms.DataGridViewImageColumn();
      this.clmActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.clmColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.clmExpression = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.tsFilter.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgvFilter)).BeginInit();
      this.SuspendLayout();
      // 
      // tsFilter
      // 
      this.tsFilter.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
      this.tsFilter.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddFilter,
            this.tsbEditFilter,
            this.tsbRemoveFilter,
            this.toolStripSeparator2,
            this.tsbZoomIn,
            this.tsbZoomOut});
      this.tsFilter.Location = new System.Drawing.Point(0, 0);
      this.tsFilter.Name = "tsFilter";
      this.tsFilter.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
      this.tsFilter.Size = new System.Drawing.Size(464, 25);
      this.tsFilter.TabIndex = 1;
      this.tsFilter.Text = "Bookmarks";
      // 
      // tsbAddFilter
      // 
      this.tsbAddFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbAddFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbAddFilter.Margin = new System.Windows.Forms.Padding(2, 1, 0, 2);
      this.tsbAddFilter.Name = "tsbAddFilter";
      this.tsbAddFilter.Size = new System.Drawing.Size(23, 22);
      this.tsbAddFilter.Text = "Add Filter";
      this.tsbAddFilter.Click += new System.EventHandler(this.TsbAddFilterClick);
      // 
      // tsbEditFilter
      // 
      this.tsbEditFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbEditFilter.Enabled = false;
      this.tsbEditFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbEditFilter.Name = "tsbEditFilter";
      this.tsbEditFilter.Size = new System.Drawing.Size(23, 22);
      this.tsbEditFilter.Text = "Edit Filter";
      this.tsbEditFilter.Click += new System.EventHandler(this.TsbEditFilterClick);
      // 
      // tsbRemoveFilter
      // 
      this.tsbRemoveFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbRemoveFilter.Enabled = false;
      this.tsbRemoveFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbRemoveFilter.Name = "tsbRemoveFilter";
      this.tsbRemoveFilter.Size = new System.Drawing.Size(23, 22);
      this.tsbRemoveFilter.Text = "Remove Filter";
      this.tsbRemoveFilter.Click += new System.EventHandler(this.TsbRemoveFilterClick);
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
      // dgvFilter
      // 
      this.dgvFilter.AllowUserToAddRows = false;
      this.dgvFilter.AllowUserToDeleteRows = false;
      this.dgvFilter.AllowUserToResizeRows = false;
      this.dgvFilter.BackgroundColor = System.Drawing.SystemColors.Window;
      this.dgvFilter.BorderStyle = System.Windows.Forms.BorderStyle.None;
      dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.dgvFilter.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
      this.dgvFilter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvFilter.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmImage,
            this.clmActive,
            this.clmColumn,
            this.clmExpression});
      dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
      dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.dgvFilter.DefaultCellStyle = dataGridViewCellStyle2;
      this.dgvFilter.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dgvFilter.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
      this.dgvFilter.Location = new System.Drawing.Point(0, 25);
      this.dgvFilter.MultiSelect = false;
      this.dgvFilter.Name = "dgvFilter";
      this.dgvFilter.RowHeadersVisible = false;
      this.dgvFilter.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dgvFilter.ShowCellErrors = false;
      this.dgvFilter.ShowCellToolTips = false;
      this.dgvFilter.ShowEditingIcon = false;
      this.dgvFilter.ShowRowErrors = false;
      this.dgvFilter.Size = new System.Drawing.Size(464, 256);
      this.dgvFilter.TabIndex = 2;
      this.dgvFilter.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvFilterCellCoubleClick);
      this.dgvFilter.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvFilterCellValueChanged);
      this.dgvFilter.CurrentCellDirtyStateChanged += new System.EventHandler(this.DgvFilterCurrentCellDirtyStateChanged);
      this.dgvFilter.SelectionChanged += new System.EventHandler(this.DgvFilterSelectionChanged);
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
      // clmActive
      // 
      this.clmActive.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
      this.clmActive.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.clmActive.HeaderText = "Active";
      this.clmActive.MinimumWidth = 50;
      this.clmActive.Name = "clmActive";
      this.clmActive.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      this.clmActive.Width = 50;
      // 
      // clmColumn
      // 
      this.clmColumn.FillWeight = 30F;
      this.clmColumn.HeaderText = "Column";
      this.clmColumn.MinimumWidth = 40;
      this.clmColumn.Name = "clmColumn";
      this.clmColumn.ReadOnly = true;
      // 
      // clmExpression
      // 
      this.clmExpression.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.clmExpression.FillWeight = 70F;
      this.clmExpression.HeaderText = "Expression";
      this.clmExpression.MinimumWidth = 40;
      this.clmExpression.Name = "clmExpression";
      this.clmExpression.ReadOnly = true;
      // 
      // FrmLogFilter
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(464, 281);
      this.Controls.Add(this.dgvFilter);
      this.Controls.Add(this.tsFilter);
      this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)(((((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom)));
      this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.HideOnClose = true;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "FrmLogFilter";
      this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockBottom;
      this.ShowInTaskbar = false;
      this.Text = "Filter";
      this.tsFilter.ResumeLayout(false);
      this.tsFilter.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgvFilter)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Gui.Controls.ToolStripEx tsFilter;
    private System.Windows.Forms.ToolStripButton tsbAddFilter;
    private System.Windows.Forms.ToolStripButton tsbRemoveFilter;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.ToolStripButton tsbZoomIn;
    private System.Windows.Forms.ToolStripButton tsbZoomOut;
    private System.Windows.Forms.DataGridView dgvFilter;
    private System.Windows.Forms.ToolStripButton tsbEditFilter;
    private System.Windows.Forms.DataGridViewImageColumn clmImage;
    private System.Windows.Forms.DataGridViewCheckBoxColumn clmActive;
    private System.Windows.Forms.DataGridViewTextBoxColumn clmColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn clmExpression;
  }
}
