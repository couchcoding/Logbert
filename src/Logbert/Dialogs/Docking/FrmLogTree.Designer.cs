namespace Couchcoding.Logbert.Dialogs.Docking
{
  partial class FrmLogTree
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogTree));
            this.tsLoggerTree = new Couchcoding.Logbert.Gui.Controls.ToolStripEx();
            this.tsbZoomIn = new System.Windows.Forms.ToolStripButton();
            this.tsbZoomOut = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbFilterRecursive = new System.Windows.Forms.ToolStripButton();
            this.tblLayout = new System.Windows.Forms.TableLayoutPanel();
            this.bgPanel = new Couchcoding.Logbert.Gui.Controls.InfoPanel();
            this.tvLoggerTree = new Couchcoding.Logbert.Gui.Controls.TreeViewEx();
            this.tsLoggerTree.SuspendLayout();
            this.tblLayout.SuspendLayout();
            this.bgPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsLoggerTree
            // 
            this.tsLoggerTree.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsLoggerTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbZoomIn,
            this.tsbZoomOut,
            this.toolStripSeparator1,
            this.tsbFilterRecursive});
            this.tsLoggerTree.Location = new System.Drawing.Point(0, 0);
            this.tsLoggerTree.Name = "tsLoggerTree";
            this.tsLoggerTree.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tsLoggerTree.Size = new System.Drawing.Size(224, 25);
            this.tsLoggerTree.TabIndex = 0;
            this.tsLoggerTree.Text = "toolStrip1";
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
            // tsbFilterRecursive
            // 
            this.tsbFilterRecursive.Checked = true;
            this.tsbFilterRecursive.CheckOnClick = true;
            this.tsbFilterRecursive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsbFilterRecursive.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbFilterRecursive.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFilterRecursive.Margin = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.tsbFilterRecursive.Name = "tsbFilterRecursive";
            this.tsbFilterRecursive.Size = new System.Drawing.Size(23, 22);
            this.tsbFilterRecursive.Text = "Filter Recursive";
            this.tsbFilterRecursive.Click += new System.EventHandler(this.TsbFilterRecursiveClick);
            // 
            // tblLayout
            // 
            this.tblLayout.ColumnCount = 1;
            this.tblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblLayout.Controls.Add(this.bgPanel, 0, 0);
            this.tblLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayout.Location = new System.Drawing.Point(0, 25);
            this.tblLayout.Name = "tblLayout";
            this.tblLayout.RowCount = 1;
            this.tblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblLayout.Size = new System.Drawing.Size(224, 416);
            this.tblLayout.TabIndex = 1;
            // 
            // bgPanel
            // 
            this.bgPanel.BackColor = System.Drawing.SystemColors.Control;
            this.bgPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(206)))), ((int)(((byte)(219)))));
            this.bgPanel.Controls.Add(this.tvLoggerTree);
            this.bgPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bgPanel.Location = new System.Drawing.Point(0, 0);
            this.bgPanel.Margin = new System.Windows.Forms.Padding(0);
            this.bgPanel.Name = "bgPanel";
            this.bgPanel.ShowTitle = false;
            this.bgPanel.Size = new System.Drawing.Size(224, 416);
            this.bgPanel.TabIndex = 0;
            this.bgPanel.TextPadding = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.bgPanel.Title = null;
            // 
            // tvLoggerTree
            // 
            this.tvLoggerTree.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvLoggerTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvLoggerTree.HideSelection = false;
            this.tvLoggerTree.HotTracking = true;
            this.tvLoggerTree.ItemHeight = 21;
            this.tvLoggerTree.Location = new System.Drawing.Point(0, 0);
            this.tvLoggerTree.Margin = new System.Windows.Forms.Padding(0);
            this.tvLoggerTree.Name = "tvLoggerTree";
            this.tvLoggerTree.ShowNodeToolTips = true;
            this.tvLoggerTree.Size = new System.Drawing.Size(224, 416);
            this.tvLoggerTree.TabIndex = 0;
            this.tvLoggerTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TvLoggerTreeNodeMouseClick);
            // 
            // FrmLogTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 441);
            this.Controls.Add(this.tblLayout);
            this.Controls.Add(this.tsLoggerTree);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)(((((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom)));
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmLogTree";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockLeft;
            this.TabText = "Logger Tree";
            this.Text = "Logger Tree";
            this.tsLoggerTree.ResumeLayout(false);
            this.tsLoggerTree.PerformLayout();
            this.tblLayout.ResumeLayout(false);
            this.bgPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private Couchcoding.Logbert.Gui.Controls.ToolStripEx tsLoggerTree;
    private System.Windows.Forms.ToolStripButton tsbFilterRecursive;
    private System.Windows.Forms.ToolStripButton tsbZoomIn;
    private System.Windows.Forms.ToolStripButton tsbZoomOut;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.TableLayoutPanel tblLayout;
    private Gui.Controls.InfoPanel bgPanel;
    private Gui.Controls.TreeViewEx tvLoggerTree;
  }
}
