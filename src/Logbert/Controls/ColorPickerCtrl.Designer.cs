using Couchcoding.Logbert.Gui.Controls;

namespace Couchcoding.Logbert.Controls
{
  partial class ColorPickerCtrl
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
      this.cddColor = new Couchcoding.Logbert.Gui.Controls.ColorDropDown();
      this.btnCustomColor = new System.Windows.Forms.Button();
      this.tblLayout = new System.Windows.Forms.TableLayoutPanel();
      this.tltTip = new System.Windows.Forms.ToolTip(this.components);
      this.tblLayout.SuspendLayout();
      this.SuspendLayout();
      // 
      // cddColor
      // 
      this.cddColor.Dock = System.Windows.Forms.DockStyle.Fill;
      this.cddColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
      this.cddColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cddColor.FormattingEnabled = true;
      this.cddColor.Location = new System.Drawing.Point(0, 1);
      this.cddColor.Margin = new System.Windows.Forms.Padding(0, 1, 3, 0);
      this.cddColor.Name = "cddColor";
      this.cddColor.SelectedItem = null;
      this.cddColor.SelectedValue = System.Drawing.Color.White;
      this.cddColor.Size = new System.Drawing.Size(124, 21);
      this.cddColor.TabIndex = 0;
      // 
      // btnCustomColor
      // 
      this.btnCustomColor.Dock = System.Windows.Forms.DockStyle.Fill;
      this.btnCustomColor.Image = global::Couchcoding.Logbert.Properties.Resources.eyedropper_16xLG;
      this.btnCustomColor.Location = new System.Drawing.Point(127, 0);
      this.btnCustomColor.Margin = new System.Windows.Forms.Padding(0);
      this.btnCustomColor.Name = "btnCustomColor";
      this.btnCustomColor.Size = new System.Drawing.Size(23, 23);
      this.btnCustomColor.TabIndex = 1;
      this.tltTip.SetToolTip(this.btnCustomColor, "Select a custom Color");
      this.btnCustomColor.UseVisualStyleBackColor = true;
      this.btnCustomColor.Click += new System.EventHandler(this.BtnCustomColorClick);
      // 
      // tblLayout
      // 
      this.tblLayout.ColumnCount = 2;
      this.tblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
      this.tblLayout.Controls.Add(this.cddColor, 0, 0);
      this.tblLayout.Controls.Add(this.btnCustomColor, 1, 0);
      this.tblLayout.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tblLayout.Location = new System.Drawing.Point(0, 0);
      this.tblLayout.Margin = new System.Windows.Forms.Padding(0);
      this.tblLayout.Name = "tblLayout";
      this.tblLayout.RowCount = 1;
      this.tblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tblLayout.Size = new System.Drawing.Size(150, 23);
      this.tblLayout.TabIndex = 0;
      // 
      // ColorPickerCtrl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.tblLayout);
      this.Name = "ColorPickerCtrl";
      this.Size = new System.Drawing.Size(150, 23);
      this.tblLayout.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private Couchcoding.Logbert.Gui.Controls.ColorDropDown cddColor;
    private System.Windows.Forms.Button btnCustomColor;
    private System.Windows.Forms.TableLayoutPanel tblLayout;
    private System.Windows.Forms.ToolTip tltTip;
  }
}
