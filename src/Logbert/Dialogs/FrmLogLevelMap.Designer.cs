namespace Com.Couchcoding.Logbert.Dialogs
{
  partial class FrmLogLevelMap
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
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogLevelMap));
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
      this.btnCancel = new System.Windows.Forms.Button();
      this.btnOk = new System.Windows.Forms.Button();
      this.pnlGrid = new Com.Couchcoding.GuiLibrary.Controls.InfoPanel();
      this.dgvLogLevel = new Com.Couchcoding.GuiLibrary.Controls.DataGridViewEx();
      this.clmValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.clmImage = new System.Windows.Forms.DataGridViewImageColumn();
      this.clmLogLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.nfoPanel = new Com.Couchcoding.GuiLibrary.Controls.InfoPanel();
      this.pnlGrid.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgvLogLevel)).BeginInit();
      this.SuspendLayout();
      // 
      // btnCancel
      // 
      this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.btnCancel.Location = new System.Drawing.Point(381, 271);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 23);
      this.btnCancel.TabIndex = 10;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      // 
      // btnOk
      // 
      this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.btnOk.Location = new System.Drawing.Point(300, 271);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new System.Drawing.Size(75, 23);
      this.btnOk.TabIndex = 9;
      this.btnOk.Text = "OK";
      this.btnOk.UseVisualStyleBackColor = true;
      // 
      // pnlGrid
      // 
      this.pnlGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.pnlGrid.BackColor = System.Drawing.SystemColors.Control;
      this.pnlGrid.BorderColor = System.Drawing.SystemColors.ControlDark;
      this.pnlGrid.Controls.Add(this.dgvLogLevel);
      this.pnlGrid.Location = new System.Drawing.Point(8, 122);
      this.pnlGrid.Name = "pnlGrid";
      this.pnlGrid.Padding = new System.Windows.Forms.Padding(1);
      this.pnlGrid.Size = new System.Drawing.Size(448, 143);
      this.pnlGrid.TabIndex = 11;
      this.pnlGrid.TextPadding = new System.Windows.Forms.Padding(0, 0, 0, 0);
      this.pnlGrid.Title = null;
      // 
      // dgvLogLevel
      // 
      this.dgvLogLevel.AllowUserToAddRows = false;
      this.dgvLogLevel.AllowUserToDeleteRows = false;
      this.dgvLogLevel.AllowUserToResizeColumns = false;
      this.dgvLogLevel.AllowUserToResizeRows = false;
      this.dgvLogLevel.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
      this.dgvLogLevel.BackgroundColor = System.Drawing.SystemColors.Control;
      this.dgvLogLevel.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.dgvLogLevel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvLogLevel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmValue,
            this.clmImage,
            this.clmLogLevel});
      this.dgvLogLevel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dgvLogLevel.Location = new System.Drawing.Point(1, 1);
      this.dgvLogLevel.MultiSelect = false;
      this.dgvLogLevel.Name = "dgvLogLevel";
      this.dgvLogLevel.RowHeadersVisible = false;
      this.dgvLogLevel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dgvLogLevel.ShowCellErrors = false;
      this.dgvLogLevel.ShowEditingIcon = false;
      this.dgvLogLevel.ShowRowErrors = false;
      this.dgvLogLevel.Size = new System.Drawing.Size(446, 141);
      this.dgvLogLevel.TabIndex = 0;
      // 
      // clmValue
      // 
      this.clmValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      dataGridViewCellStyle4.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.clmValue.DefaultCellStyle = dataGridViewCellStyle4;
      this.clmValue.FillWeight = 50F;
      this.clmValue.HeaderText = "Value";
      this.clmValue.MinimumWidth = 100;
      this.clmValue.Name = "clmValue";
      // 
      // clmImage
      // 
      this.clmImage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
      dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle5.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle5.NullValue")));
      dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText;
      this.clmImage.DefaultCellStyle = dataGridViewCellStyle5;
      this.clmImage.HeaderText = "";
      this.clmImage.MinimumWidth = 20;
      this.clmImage.Name = "clmImage";
      this.clmImage.ReadOnly = true;
      this.clmImage.Width = 20;
      // 
      // clmLogLevel
      // 
      this.clmLogLevel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
      this.clmLogLevel.DefaultCellStyle = dataGridViewCellStyle6;
      this.clmLogLevel.FillWeight = 50F;
      this.clmLogLevel.HeaderText = "Log Level";
      this.clmLogLevel.MinimumWidth = 100;
      this.clmLogLevel.Name = "clmLogLevel";
      this.clmLogLevel.ReadOnly = true;
      // 
      // nfoPanel
      // 
      this.nfoPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.nfoPanel.BackColor = System.Drawing.Color.WhiteSmoke;
      this.nfoPanel.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
      this.nfoPanel.InfoIcon = global::Com.Couchcoding.Logbert.Properties.Resources.StatusAnnotations_Information_16xLG;
      this.nfoPanel.Location = new System.Drawing.Point(8, 68);
      this.nfoPanel.Name = "nfoPanel";
      this.nfoPanel.ShowInfoIcon = true;
      this.nfoPanel.ShowTitle = false;
      this.nfoPanel.Size = new System.Drawing.Size(448, 48);
      this.nfoPanel.TabIndex = 12;
      this.nfoPanel.Text = "Note: You may use regular expressions for a match. Leave a value empty to ignore " +
    "a log level.";
      this.nfoPanel.TextPadding = new System.Windows.Forms.Padding(0, 6, 0, 0);
      this.nfoPanel.Title = "";
      // 
      // FrmLogLevelMap
      // 
      this.AcceptButton = this.btnOk;
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.CancelButton = this.btnCancel;
      this.ClientSize = new System.Drawing.Size(464, 302);
      this.Controls.Add(this.nfoPanel);
      this.Controls.Add(this.pnlGrid);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnOk);
      this.DialogMainCaption = "Edit Log Levels";
      this.DialogMainDescription = "Configure the mapping of the as \'Level\' declared column to known log levels.";
      this.Location = new System.Drawing.Point(0, 0);
      this.MinimumSize = new System.Drawing.Size(480, 340);
      this.Name = "FrmLogLevelMap";
      this.Text = "Edit Log Levels";
      this.pnlGrid.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dgvLogLevel)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Button btnOk;
    private GuiLibrary.Controls.InfoPanel pnlGrid;
    private GuiLibrary.Controls.DataGridViewEx dgvLogLevel;
    private System.Windows.Forms.DataGridViewTextBoxColumn clmValue;
    private System.Windows.Forms.DataGridViewImageColumn clmImage;
    private System.Windows.Forms.DataGridViewTextBoxColumn clmLogLevel;
    private GuiLibrary.Controls.InfoPanel nfoPanel;
  }
}