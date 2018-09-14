namespace Couchcoding.Logbert.Dialogs
{
  partial class FrmAddEditFilter
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
      this.btnCancel = new System.Windows.Forms.Button();
      this.btnOk = new System.Windows.Forms.Button();
      this.chkFilterIsActive = new System.Windows.Forms.CheckBox();
      this.lblColumnToFilter = new System.Windows.Forms.Label();
      this.cmbColumnToFilter = new System.Windows.Forms.ComboBox();
      this.lblExpressionToFilterFor = new System.Windows.Forms.Label();
      this.txtExpressionToFilterFor = new System.Windows.Forms.TextBox();
      this.lblOperator = new System.Windows.Forms.Label();
      this.cmbOperator = new System.Windows.Forms.ComboBox();
      this.SuspendLayout();
      // 
      // btnCancel
      // 
      this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.btnCancel.Location = new System.Drawing.Point(381, 251);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 23);
      this.btnCancel.TabIndex = 8;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      // 
      // btnOk
      // 
      this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.btnOk.Location = new System.Drawing.Point(300, 251);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new System.Drawing.Size(75, 23);
      this.btnOk.TabIndex = 7;
      this.btnOk.Text = "OK";
      this.btnOk.UseVisualStyleBackColor = true;
      // 
      // chkFilterIsActive
      // 
      this.chkFilterIsActive.AutoSize = true;
      this.chkFilterIsActive.Checked = true;
      this.chkFilterIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkFilterIsActive.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.chkFilterIsActive.Location = new System.Drawing.Point(8, 68);
      this.chkFilterIsActive.Name = "chkFilterIsActive";
      this.chkFilterIsActive.Size = new System.Drawing.Size(103, 20);
      this.chkFilterIsActive.TabIndex = 0;
      this.chkFilterIsActive.Text = "Filter is &active";
      this.chkFilterIsActive.UseVisualStyleBackColor = true;
      // 
      // lblColumnToFilter
      // 
      this.lblColumnToFilter.AutoSize = true;
      this.lblColumnToFilter.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.lblColumnToFilter.Location = new System.Drawing.Point(8, 97);
      this.lblColumnToFilter.Name = "lblColumnToFilter";
      this.lblColumnToFilter.Size = new System.Drawing.Size(94, 15);
      this.lblColumnToFilter.TabIndex = 1;
      this.lblColumnToFilter.Text = "&Column to filter:";
      // 
      // cmbColumnToFilter
      // 
      this.cmbColumnToFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.cmbColumnToFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbColumnToFilter.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.cmbColumnToFilter.FormattingEnabled = true;
      this.cmbColumnToFilter.Location = new System.Drawing.Point(8, 115);
      this.cmbColumnToFilter.Name = "cmbColumnToFilter";
      this.cmbColumnToFilter.Size = new System.Drawing.Size(333, 23);
      this.cmbColumnToFilter.TabIndex = 3;
      // 
      // lblExpressionToFilterFor
      // 
      this.lblExpressionToFilterFor.AutoSize = true;
      this.lblExpressionToFilterFor.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.lblExpressionToFilterFor.Location = new System.Drawing.Point(8, 147);
      this.lblExpressionToFilterFor.Name = "lblExpressionToFilterFor";
      this.lblExpressionToFilterFor.Size = new System.Drawing.Size(124, 15);
      this.lblExpressionToFilterFor.TabIndex = 5;
      this.lblExpressionToFilterFor.Text = "&Expression to filter for:";
      // 
      // txtExpressionToFilterFor
      // 
      this.txtExpressionToFilterFor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtExpressionToFilterFor.Location = new System.Drawing.Point(8, 165);
      this.txtExpressionToFilterFor.Name = "txtExpressionToFilterFor";
      this.txtExpressionToFilterFor.Size = new System.Drawing.Size(448, 23);
      this.txtExpressionToFilterFor.TabIndex = 6;
      // 
      // lblOperator
      // 
      this.lblOperator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.lblOperator.AutoSize = true;
      this.lblOperator.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.lblOperator.Location = new System.Drawing.Point(344, 97);
      this.lblOperator.Name = "lblOperator";
      this.lblOperator.Size = new System.Drawing.Size(57, 15);
      this.lblOperator.TabIndex = 2;
      this.lblOperator.Text = "&Operator:";
      // 
      // cmbOperator
      // 
      this.cmbOperator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.cmbOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbOperator.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.cmbOperator.FormattingEnabled = true;
      this.cmbOperator.Items.AddRange(new object[] {
            "Match",
            "Not match"});
      this.cmbOperator.Location = new System.Drawing.Point(347, 115);
      this.cmbOperator.Name = "cmbOperator";
      this.cmbOperator.Size = new System.Drawing.Size(109, 23);
      this.cmbOperator.TabIndex = 4;
      // 
      // FrmAddEditFilter
      // 
      this.AcceptButton = this.btnOk;
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.CancelButton = this.btnCancel;
      this.ClientSize = new System.Drawing.Size(464, 282);
      this.Controls.Add(this.cmbOperator);
      this.Controls.Add(this.lblOperator);
      this.Controls.Add(this.txtExpressionToFilterFor);
      this.Controls.Add(this.lblExpressionToFilterFor);
      this.Controls.Add(this.cmbColumnToFilter);
      this.Controls.Add(this.lblColumnToFilter);
      this.Controls.Add(this.chkFilterIsActive);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnOk);
      this.DialogMainCaption = "Add Filter";
      this.DialogMainDescription = "Configure the settings for the filter.";
      this.Location = new System.Drawing.Point(0, 0);
      this.MinimumSize = new System.Drawing.Size(480, 320);
      this.Name = "FrmAddEditFilter";
      this.Text = "Add Filter";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Button btnOk;
    private System.Windows.Forms.CheckBox chkFilterIsActive;
    private System.Windows.Forms.Label lblColumnToFilter;
    private System.Windows.Forms.ComboBox cmbColumnToFilter;
    private System.Windows.Forms.Label lblExpressionToFilterFor;
    private System.Windows.Forms.TextBox txtExpressionToFilterFor;
    private System.Windows.Forms.Label lblOperator;
    private System.Windows.Forms.ComboBox cmbOperator;
  }
}