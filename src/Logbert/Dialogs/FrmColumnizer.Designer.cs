namespace Com.Couchcoding.Logbert.Dialogs
{
  partial class FrmColumnizer
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      this.btnCancel = new System.Windows.Forms.Button();
      this.btnOk = new System.Windows.Forms.Button();
      this.lblName = new System.Windows.Forms.Label();
      this.txtName = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.dgvColumns = new Com.Couchcoding.GuiLibrary.Controls.DataGridViewEx();
      this.clmName = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.clmRegex = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.clmOptional = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.clmType = new System.Windows.Forms.DataGridViewComboBoxColumn();
      this.pnlGrid = new Com.Couchcoding.GuiLibrary.Controls.InfoPanel();
      this.tsColumns = new Com.Couchcoding.GuiLibrary.Controls.ToolStripEx();
      this.tsbAddColumn = new System.Windows.Forms.ToolStripButton();
      this.tsbRemoveColumn = new System.Windows.Forms.ToolStripButton();
      this.tsbEditColumn = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.tsbMoveUp = new System.Windows.Forms.ToolStripButton();
      this.tsbMoveDown = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.tsbTestColumnizer = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
      this.tsbEditLogLevels = new System.Windows.Forms.ToolStripButton();
      this.nfoPanel = new Com.Couchcoding.GuiLibrary.Controls.InfoPanel();
      ((System.ComponentModel.ISupportInitialize)(this.dgvColumns)).BeginInit();
      this.pnlGrid.SuspendLayout();
      this.tsColumns.SuspendLayout();
      this.SuspendLayout();
      // 
      // btnCancel
      // 
      this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.btnCancel.Location = new System.Drawing.Point(541, 410);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 23);
      this.btnCancel.TabIndex = 7;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      // 
      // btnOk
      // 
      this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.btnOk.Location = new System.Drawing.Point(460, 410);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new System.Drawing.Size(75, 23);
      this.btnOk.TabIndex = 6;
      this.btnOk.Text = "OK";
      this.btnOk.UseVisualStyleBackColor = true;
      // 
      // lblName
      // 
      this.lblName.AutoSize = true;
      this.lblName.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.lblName.Location = new System.Drawing.Point(8, 68);
      this.lblName.Name = "lblName";
      this.lblName.Size = new System.Drawing.Size(42, 15);
      this.lblName.TabIndex = 0;
      this.lblName.Text = "&Name:";
      // 
      // txtName
      // 
      this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtName.Location = new System.Drawing.Point(8, 86);
      this.txtName.Name = "txtName";
      this.txtName.Size = new System.Drawing.Size(608, 23);
      this.txtName.TabIndex = 1;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.label1.Location = new System.Drawing.Point(8, 143);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(58, 15);
      this.label1.TabIndex = 2;
      this.label1.Text = "&Columns:";
      // 
      // dgvColumns
      // 
      this.dgvColumns.AllowUserToAddRows = false;
      this.dgvColumns.AllowUserToDeleteRows = false;
      this.dgvColumns.AllowUserToResizeRows = false;
      this.dgvColumns.BackgroundColor = System.Drawing.SystemColors.Control;
      this.dgvColumns.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.dgvColumns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvColumns.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmName,
            this.clmRegex,
            this.clmOptional,
            this.clmType});
      this.dgvColumns.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dgvColumns.Location = new System.Drawing.Point(1, 1);
      this.dgvColumns.MultiSelect = false;
      this.dgvColumns.Name = "dgvColumns";
      this.dgvColumns.RowHeadersVisible = false;
      this.dgvColumns.ShowCellErrors = false;
      this.dgvColumns.ShowRowErrors = false;
      this.dgvColumns.Size = new System.Drawing.Size(606, 184);
      this.dgvColumns.TabIndex = 0;
      this.dgvColumns.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvColumnsCellEndEdit);
      this.dgvColumns.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DgvColumnsEditingControlShowing);
      this.dgvColumns.SelectionChanged += new System.EventHandler(this.DgvColumnsSelectionChanged);
      // 
      // clmName
      // 
      this.clmName.FillWeight = 30F;
      this.clmName.HeaderText = "Name";
      this.clmName.MinimumWidth = 100;
      this.clmName.Name = "clmName";
      this.clmName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // clmRegex
      // 
      this.clmRegex.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      dataGridViewCellStyle1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.clmRegex.DefaultCellStyle = dataGridViewCellStyle1;
      this.clmRegex.FillWeight = 70F;
      this.clmRegex.HeaderText = "Regular expression";
      this.clmRegex.MinimumWidth = 100;
      this.clmRegex.Name = "clmRegex";
      this.clmRegex.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // clmOptional
      // 
      this.clmOptional.HeaderText = "Optional";
      this.clmOptional.MinimumWidth = 70;
      this.clmOptional.Name = "clmOptional";
      this.clmOptional.Resizable = System.Windows.Forms.DataGridViewTriState.False;
      this.clmOptional.Width = 70;
      // 
      // clmType
      // 
      this.clmType.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.clmType.HeaderText = "Type";
      this.clmType.Items.AddRange(new object[] {
            "Unknown",
            "Timestamp",
            "Level",
            "Message"});
      this.clmType.MaxDropDownItems = 4;
      this.clmType.MinimumWidth = 100;
      this.clmType.Name = "clmType";
      this.clmType.Resizable = System.Windows.Forms.DataGridViewTriState.False;
      // 
      // pnlGrid
      // 
      this.pnlGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.pnlGrid.BackColor = System.Drawing.SystemColors.Control;
      this.pnlGrid.BorderColor = System.Drawing.SystemColors.ControlDark;
      this.pnlGrid.Controls.Add(this.dgvColumns);
      this.pnlGrid.Location = new System.Drawing.Point(8, 161);
      this.pnlGrid.Name = "pnlGrid";
      this.pnlGrid.Padding = new System.Windows.Forms.Padding(1);
      this.pnlGrid.Size = new System.Drawing.Size(608, 186);
      this.pnlGrid.TabIndex = 4;
      this.pnlGrid.TextPadding = new System.Windows.Forms.Padding(0, 0, 0, 0);
      this.pnlGrid.Title = null;
      // 
      // tsColumns
      // 
      this.tsColumns.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.tsColumns.AutoSize = false;
      this.tsColumns.CanOverflow = false;
      this.tsColumns.Dock = System.Windows.Forms.DockStyle.None;
      this.tsColumns.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
      this.tsColumns.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddColumn,
            this.tsbRemoveColumn,
            this.tsbEditColumn,
            this.toolStripSeparator1,
            this.tsbMoveUp,
            this.tsbMoveDown,
            this.toolStripSeparator2,
            this.tsbTestColumnizer,
            this.toolStripSeparator3,
            this.tsbEditLogLevels});
      this.tsColumns.Location = new System.Drawing.Point(435, 133);
      this.tsColumns.Name = "tsColumns";
      this.tsColumns.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
      this.tsColumns.Size = new System.Drawing.Size(181, 25);
      this.tsColumns.TabIndex = 3;
      this.tsColumns.Text = "Columns";
      // 
      // tsbAddColumn
      // 
      this.tsbAddColumn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbAddColumn.Image = global::Com.Couchcoding.Logbert.Properties.Resources.action_add_16xMD;
      this.tsbAddColumn.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbAddColumn.Name = "tsbAddColumn";
      this.tsbAddColumn.Size = new System.Drawing.Size(23, 22);
      this.tsbAddColumn.Text = "Add Column";
      this.tsbAddColumn.Click += new System.EventHandler(this.TsbAddColumnClick);
      // 
      // tsbRemoveColumn
      // 
      this.tsbRemoveColumn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbRemoveColumn.Enabled = false;
      this.tsbRemoveColumn.Image = global::Com.Couchcoding.Logbert.Properties.Resources.Remove_16xMD;
      this.tsbRemoveColumn.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbRemoveColumn.Margin = new System.Windows.Forms.Padding(0, 1, 1, 2);
      this.tsbRemoveColumn.Name = "tsbRemoveColumn";
      this.tsbRemoveColumn.Size = new System.Drawing.Size(23, 22);
      this.tsbRemoveColumn.Text = "Remove Column";
      this.tsbRemoveColumn.Click += new System.EventHandler(this.TsbRemoveColumnClick);
      // 
      // tsbEditColumn
      // 
      this.tsbEditColumn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbEditColumn.Enabled = false;
      this.tsbEditColumn.Image = global::Com.Couchcoding.Logbert.Properties.Resources.PencilAngled_16xMD_color;
      this.tsbEditColumn.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbEditColumn.Name = "tsbEditColumn";
      this.tsbEditColumn.Size = new System.Drawing.Size(23, 22);
      this.tsbEditColumn.Text = "Edit Column";
      this.tsbEditColumn.Click += new System.EventHandler(this.TsbEditColumnClick);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
      // 
      // tsbMoveUp
      // 
      this.tsbMoveUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbMoveUp.Enabled = false;
      this.tsbMoveUp.Image = global::Com.Couchcoding.Logbert.Properties.Resources.arrow_Up_16xLG;
      this.tsbMoveUp.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbMoveUp.Name = "tsbMoveUp";
      this.tsbMoveUp.Size = new System.Drawing.Size(23, 22);
      this.tsbMoveUp.Text = "Move Up";
      this.tsbMoveUp.Click += new System.EventHandler(this.TsbMoveUpClick);
      // 
      // tsbMoveDown
      // 
      this.tsbMoveDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbMoveDown.Enabled = false;
      this.tsbMoveDown.Image = global::Com.Couchcoding.Logbert.Properties.Resources.arrow_Down_16xLG;
      this.tsbMoveDown.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbMoveDown.Name = "tsbMoveDown";
      this.tsbMoveDown.Size = new System.Drawing.Size(23, 22);
      this.tsbMoveDown.Text = "Move Down";
      this.tsbMoveDown.Click += new System.EventHandler(this.TsbMoveDownClick);
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
      // 
      // tsbTestColumnizer
      // 
      this.tsbTestColumnizer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbTestColumnizer.Enabled = false;
      this.tsbTestColumnizer.Image = global::Com.Couchcoding.Logbert.Properties.Resources.RunTests_8790;
      this.tsbTestColumnizer.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbTestColumnizer.Name = "tsbTestColumnizer";
      this.tsbTestColumnizer.Size = new System.Drawing.Size(23, 22);
      this.tsbTestColumnizer.Text = "Test Columnizer";
      this.tsbTestColumnizer.Click += new System.EventHandler(this.TsbTestColumnizerClick);
      // 
      // toolStripSeparator3
      // 
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
      // 
      // tsbEditLogLevels
      // 
      this.tsbEditLogLevels.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbEditLogLevels.Image = global::Com.Couchcoding.Logbert.Properties.Resources.LogLevel_16x;
      this.tsbEditLogLevels.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbEditLogLevels.Name = "tsbEditLogLevels";
      this.tsbEditLogLevels.Size = new System.Drawing.Size(23, 22);
      this.tsbEditLogLevels.Text = "Edit Log Levels";
      this.tsbEditLogLevels.Click += new System.EventHandler(this.TsbEditLogLevelsClick);
      // 
      // nfoPanel
      // 
      this.nfoPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.nfoPanel.BackColor = System.Drawing.Color.WhiteSmoke;
      this.nfoPanel.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
      this.nfoPanel.InfoIcon = global::Com.Couchcoding.Logbert.Properties.Resources.StatusAnnotations_Information_16xLG;
      this.nfoPanel.Location = new System.Drawing.Point(8, 353);
      this.nfoPanel.Name = "nfoPanel";
      this.nfoPanel.ShowInfoIcon = true;
      this.nfoPanel.ShowTitle = false;
      this.nfoPanel.Size = new System.Drawing.Size(608, 48);
      this.nfoPanel.TabIndex = 5;
      this.nfoPanel.Text = "Note: The columns for bookmarks and log numbers will always be added and each reg" +
    "ular expression needs a grouped item.";
      this.nfoPanel.TextPadding = new System.Windows.Forms.Padding(0, 6, 0, 0);
      this.nfoPanel.Title = "";
      // 
      // FrmColumnizer
      // 
      this.AcceptButton = this.btnOk;
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnCancel;
      this.ClientSize = new System.Drawing.Size(624, 442);
      this.Controls.Add(this.nfoPanel);
      this.Controls.Add(this.pnlGrid);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.txtName);
      this.Controls.Add(this.lblName);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnOk);
      this.Controls.Add(this.tsColumns);
      this.DialogMainCaption = "Columnizer";
      this.DialogMainDescription = "Define the name and the columns to parse using regular expressions.";
      this.Location = new System.Drawing.Point(0, 0);
      this.MinimumSize = new System.Drawing.Size(640, 480);
      this.Name = "FrmColumnizer";
      this.Text = "Columnizer";
      ((System.ComponentModel.ISupportInitialize)(this.dgvColumns)).EndInit();
      this.pnlGrid.ResumeLayout(false);
      this.tsColumns.ResumeLayout(false);
      this.tsColumns.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Button btnOk;
    private System.Windows.Forms.Label lblName;
    private System.Windows.Forms.TextBox txtName;
    private System.Windows.Forms.Label label1;
    private GuiLibrary.Controls.DataGridViewEx dgvColumns;
    private GuiLibrary.Controls.InfoPanel pnlGrid;
    private GuiLibrary.Controls.ToolStripEx tsColumns;
    private System.Windows.Forms.ToolStripButton tsbAddColumn;
    private System.Windows.Forms.ToolStripButton tsbEditColumn;
    private System.Windows.Forms.ToolStripButton tsbRemoveColumn;
    private System.Windows.Forms.ToolStripButton tsbTestColumnizer;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripButton tsbMoveUp;
    private System.Windows.Forms.ToolStripButton tsbMoveDown;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private GuiLibrary.Controls.InfoPanel nfoPanel;
    private System.Windows.Forms.DataGridViewTextBoxColumn clmName;
    private System.Windows.Forms.DataGridViewTextBoxColumn clmRegex;
    private System.Windows.Forms.DataGridViewCheckBoxColumn clmOptional;
    private System.Windows.Forms.DataGridViewComboBoxColumn clmType;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    private System.Windows.Forms.ToolStripButton tsbEditLogLevels;
  }
}