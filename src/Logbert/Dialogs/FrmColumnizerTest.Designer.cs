namespace Couchcoding.Logbert.Dialogs
{
  partial class FrmColumnizerTest
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
      this.btnClose = new System.Windows.Forms.Button();
      this.txtLogValue = new System.Windows.Forms.TextBox();
      this.lblTestLogValue = new System.Windows.Forms.Label();
      this.lblResult = new System.Windows.Forms.Label();
      this.pnlGrid = new Couchcoding.Logbert.Gui.Controls.InfoPanel();
      this.dgvResult = new Couchcoding.Logbert.Gui.Controls.DataGridViewEx();
      this.clmColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.clmValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.pnlGrid.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
      this.SuspendLayout();
      // 
      // btnClose
      // 
      this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.btnClose.Location = new System.Drawing.Point(541, 410);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new System.Drawing.Size(75, 23);
      this.btnClose.TabIndex = 4;
      this.btnClose.Text = "Close";
      this.btnClose.UseVisualStyleBackColor = true;
      // 
      // txtLogValue
      // 
      this.txtLogValue.AcceptsReturn = true;
      this.txtLogValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtLogValue.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtLogValue.Location = new System.Drawing.Point(8, 86);
      this.txtLogValue.Multiline = true;
      this.txtLogValue.Name = "txtLogValue";
      this.txtLogValue.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.txtLogValue.Size = new System.Drawing.Size(608, 128);
      this.txtLogValue.TabIndex = 1;
      this.txtLogValue.TextChanged += new System.EventHandler(this.TxtLogValueTextChanged);
      // 
      // lblTestLogValue
      // 
      this.lblTestLogValue.AutoSize = true;
      this.lblTestLogValue.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.lblTestLogValue.Location = new System.Drawing.Point(8, 68);
      this.lblTestLogValue.Name = "lblTestLogValue";
      this.lblTestLogValue.Size = new System.Drawing.Size(86, 15);
      this.lblTestLogValue.TabIndex = 0;
      this.lblTestLogValue.Text = "Test Log value:";
      // 
      // lblResult
      // 
      this.lblResult.AutoSize = true;
      this.lblResult.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.lblResult.Location = new System.Drawing.Point(8, 223);
      this.lblResult.Name = "lblResult";
      this.lblResult.Size = new System.Drawing.Size(67, 15);
      this.lblResult.TabIndex = 2;
      this.lblResult.Text = "Test Result:";
      // 
      // pnlGrid
      // 
      this.pnlGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.pnlGrid.BackColor = System.Drawing.SystemColors.Control;
      this.pnlGrid.BorderColor = System.Drawing.SystemColors.ControlDark;
      this.pnlGrid.Controls.Add(this.dgvResult);
      this.pnlGrid.Location = new System.Drawing.Point(8, 241);
      this.pnlGrid.Name = "pnlGrid";
      this.pnlGrid.Padding = new System.Windows.Forms.Padding(1);
      this.pnlGrid.Size = new System.Drawing.Size(608, 163);
      this.pnlGrid.TabIndex = 3;
      this.pnlGrid.TextPadding = new System.Windows.Forms.Padding(0, 0, 0, 0);
      this.pnlGrid.Title = null;
      // 
      // dgvResult
      // 
      this.dgvResult.AllowUserToAddRows = false;
      this.dgvResult.AllowUserToDeleteRows = false;
      this.dgvResult.AllowUserToResizeRows = false;
      this.dgvResult.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
      this.dgvResult.BackgroundColor = System.Drawing.SystemColors.Control;
      this.dgvResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmColumn,
            this.clmValue});
      dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
      dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
      dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Window;
      dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.dgvResult.DefaultCellStyle = dataGridViewCellStyle1;
      this.dgvResult.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dgvResult.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
      this.dgvResult.Location = new System.Drawing.Point(1, 1);
      this.dgvResult.MultiSelect = false;
      this.dgvResult.Name = "dgvResult";
      this.dgvResult.ReadOnly = true;
      this.dgvResult.RowHeadersVisible = false;
      this.dgvResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dgvResult.ShowCellErrors = false;
      this.dgvResult.ShowEditingIcon = false;
      this.dgvResult.ShowRowErrors = false;
      this.dgvResult.Size = new System.Drawing.Size(606, 161);
      this.dgvResult.TabIndex = 0;
      // 
      // clmColumn
      // 
      this.clmColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
      this.clmColumn.HeaderText = "Column";
      this.clmColumn.Name = "clmColumn";
      this.clmColumn.ReadOnly = true;
      this.clmColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      this.clmColumn.Width = 56;
      // 
      // clmValue
      // 
      this.clmValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.clmValue.HeaderText = "Value";
      this.clmValue.Name = "clmValue";
      this.clmValue.ReadOnly = true;
      this.clmValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // FrmColumnizerTest
      // 
      this.AcceptButton = this.btnClose;
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.CancelButton = this.btnClose;
      this.ClientSize = new System.Drawing.Size(624, 442);
      this.Controls.Add(this.pnlGrid);
      this.Controls.Add(this.lblResult);
      this.Controls.Add(this.lblTestLogValue);
      this.Controls.Add(this.txtLogValue);
      this.Controls.Add(this.btnClose);
      this.DialogMainCaption = "Test Columnizer";
      this.DialogMainDescription = "Enter a log message to test the spezified columnizer.";
      this.Location = new System.Drawing.Point(0, 0);
      this.MinimumSize = new System.Drawing.Size(640, 480);
      this.Name = "FrmColumnizerTest";
      this.Text = "Test Columnizer";
      this.pnlGrid.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnClose;
    private System.Windows.Forms.TextBox txtLogValue;
    private System.Windows.Forms.Label lblTestLogValue;
    private System.Windows.Forms.Label lblResult;
    private Gui.Controls.InfoPanel pnlGrid;
    private Gui.Controls.DataGridViewEx dgvResult;
    private System.Windows.Forms.DataGridViewTextBoxColumn clmColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn clmValue;
  }
}