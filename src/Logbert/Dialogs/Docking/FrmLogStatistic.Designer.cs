namespace Couchcoding.Logbert.Dialogs.Docking
{
  partial class FrmLogStatistic
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
      System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
      System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
      System.Windows.Forms.DataVisualization.Charting.LegendCellColumn legendCellColumn1 = new System.Windows.Forms.DataVisualization.Charting.LegendCellColumn();
      System.Windows.Forms.DataVisualization.Charting.LegendCellColumn legendCellColumn2 = new System.Windows.Forms.DataVisualization.Charting.LegendCellColumn();
      System.Windows.Forms.DataVisualization.Charting.LegendCellColumn legendCellColumn3 = new System.Windows.Forms.DataVisualization.Charting.LegendCellColumn();
      System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogStatistic));
      this.toolStrip1 = new Couchcoding.Logbert.Gui.Controls.ToolStripEx();
      this.tsbShowLegend = new System.Windows.Forms.ToolStripButton();
      this.chrtOverview = new System.Windows.Forms.DataVisualization.Charting.Chart();
      this.toolStrip1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.chrtOverview)).BeginInit();
      this.SuspendLayout();
      // 
      // toolStrip1
      // 
      this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
      this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbShowLegend});
      this.toolStrip1.Location = new System.Drawing.Point(0, 0);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
      this.toolStrip1.Size = new System.Drawing.Size(464, 25);
      this.toolStrip1.TabIndex = 1;
      this.toolStrip1.Text = "Bookmarks";
      // 
      // tsbShowLegend
      // 
      this.tsbShowLegend.CheckOnClick = true;
      this.tsbShowLegend.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbShowLegend.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbShowLegend.Margin = new System.Windows.Forms.Padding(2, 1, 0, 2);
      this.tsbShowLegend.Name = "tsbShowLegend";
      this.tsbShowLegend.Size = new System.Drawing.Size(23, 22);
      this.tsbShowLegend.Text = "Show Legend";
      this.tsbShowLegend.Click += new System.EventHandler(this.TsbShowLegendClick);
      // 
      // chrtOverview
      // 
      chartArea1.AlignmentOrientation = System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal;
      chartArea1.AlignWithChartArea = "ChartAreaPie";
      chartArea1.Area3DStyle.Enable3D = true;
      chartArea1.Area3DStyle.IsRightAngleAxes = false;
      chartArea1.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic;
      chartArea1.Name = "ChartAreaPie";
      this.chrtOverview.ChartAreas.Add(chartArea1);
      this.chrtOverview.Dock = System.Windows.Forms.DockStyle.Fill;
      legendCellColumn1.ColumnType = System.Windows.Forms.DataVisualization.Charting.LegendCellColumnType.SeriesSymbol;
      legendCellColumn1.Name = "clmLevelColor";
      legendCellColumn1.Text = "";
      legendCellColumn2.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
      legendCellColumn2.HeaderAlignment = System.Drawing.StringAlignment.Near;
      legendCellColumn2.Name = "clmLevelName";
      legendCellColumn2.Text = "#LEGENDTEXT:";
      legendCellColumn3.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
      legendCellColumn3.HeaderAlignment = System.Drawing.StringAlignment.Near;
      legendCellColumn3.Name = "clmLevelCount";
      legendCellColumn3.Text = "#VAL";
      legend1.CellColumns.Add(legendCellColumn1);
      legend1.CellColumns.Add(legendCellColumn2);
      legend1.CellColumns.Add(legendCellColumn3);
      legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Left;
      legend1.Name = "Legend";
      legend1.TableStyle = System.Windows.Forms.DataVisualization.Charting.LegendTableStyle.Tall;
      this.chrtOverview.Legends.Add(legend1);
      this.chrtOverview.Location = new System.Drawing.Point(0, 25);
      this.chrtOverview.MinimumSize = new System.Drawing.Size(1, 1);
      this.chrtOverview.Name = "chrtOverview";
      series1.ChartArea = "ChartAreaPie";
      series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
      series1.CustomProperties = "PieLineColor=ControlDarkDark, PieDrawingStyle=Concave, PieLabelStyle=Outside";
      series1.Legend = "Legend";
      series1.Name = "PieSeries";
      this.chrtOverview.Series.Add(series1);
      this.chrtOverview.Size = new System.Drawing.Size(464, 256);
      this.chrtOverview.SuppressExceptions = true;
      this.chrtOverview.TabIndex = 2;
      this.chrtOverview.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ChrtOverviewMouseDown);
      this.chrtOverview.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ChrtOverviewMouseMove);
      this.chrtOverview.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ChrtOverviewMouseUp);
      // 
      // FrmLogStatistic
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(464, 281);
      this.Controls.Add(this.chrtOverview);
      this.Controls.Add(this.toolStrip1);
      this.HideOnClose = true;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "FrmLogStatistic";
      this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockBottom;
      this.ShowInTaskbar = false;
      this.Text = "Statistic";
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.chrtOverview)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }
    #endregion

    private Gui.Controls.ToolStripEx toolStrip1;
    private System.Windows.Forms.ToolStripButton tsbShowLegend;
    private System.Windows.Forms.DataVisualization.Charting.Chart chrtOverview;
  }
}
