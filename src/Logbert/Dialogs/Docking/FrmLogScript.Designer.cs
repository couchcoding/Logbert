namespace Couchcoding.Logbert.Dialogs.Docking
{
  partial class FrmLogScript
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
      this.components = new System.ComponentModel.Container();
      System.Windows.Forms.ToolStripSeparator cmsLuaEditSeperator1;
      System.Windows.Forms.ToolStripSeparator cmsLuaEditSeperator2;
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogScript));
      this.scintilla = new ScintillaNET.Scintilla();
      this.cmsLuaEdit = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.cmsLuaEditUndo = new System.Windows.Forms.ToolStripMenuItem();
      this.cmsLuaEditRedo = new System.Windows.Forms.ToolStripMenuItem();
      this.cmsLuaEditCut = new System.Windows.Forms.ToolStripMenuItem();
      this.cmsLuaEditCopy = new System.Windows.Forms.ToolStripMenuItem();
      this.cmsLuaEditPaste = new System.Windows.Forms.ToolStripMenuItem();
      this.cmsLuaEditDelete = new System.Windows.Forms.ToolStripMenuItem();
      this.cmsLuaEditSelectAll = new System.Windows.Forms.ToolStripMenuItem();
      this.tsCuCommands = new Couchcoding.Logbert.Gui.Controls.ToolStripEx();
      this.tsbLoadScript = new System.Windows.Forms.ToolStripButton();
      this.tsbSaveScript = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
      this.tsbCopy = new System.Windows.Forms.ToolStripButton();
      this.tsbCut = new System.Windows.Forms.ToolStripButton();
      this.tsbPaste = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
      this.tsbUndo = new System.Windows.Forms.ToolStripButton();
      this.tsbRedo = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
      this.tsbStart = new System.Windows.Forms.ToolStripButton();
      this.tsbStop = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.tsbZoomIn = new System.Windows.Forms.ToolStripButton();
      this.tsbZoomOut = new System.Windows.Forms.ToolStripButton();
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.tsOutput = new Couchcoding.Logbert.Gui.Controls.ToolStripEx();
      this.tsbOutputClear = new System.Windows.Forms.ToolStripButton();
      this.tsbOutputWordWrap = new System.Windows.Forms.ToolStripButton();
      this.bgPanel = new Couchcoding.Logbert.Gui.Controls.InfoPanel();
      this.txtOutput = new System.Windows.Forms.TextBox();
      cmsLuaEditSeperator1 = new System.Windows.Forms.ToolStripSeparator();
      cmsLuaEditSeperator2 = new System.Windows.Forms.ToolStripSeparator();
      this.cmsLuaEdit.SuspendLayout();
      this.tsCuCommands.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.tableLayoutPanel1.SuspendLayout();
      this.tsOutput.SuspendLayout();
      this.bgPanel.SuspendLayout();
      this.SuspendLayout();
      // 
      // cmsLuaEditSeperator1
      // 
      cmsLuaEditSeperator1.Name = "cmsLuaEditSeperator1";
      cmsLuaEditSeperator1.Size = new System.Drawing.Size(119, 6);
      // 
      // cmsLuaEditSeperator2
      // 
      cmsLuaEditSeperator2.Name = "cmsLuaEditSeperator2";
      cmsLuaEditSeperator2.Size = new System.Drawing.Size(119, 6);
      // 
      // scintilla
      // 
      this.scintilla.AutoCIgnoreCase = true;
      this.scintilla.AutoCMaxHeight = 10;
      this.scintilla.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.scintilla.CaretLineBackColorAlpha = 64;
      this.scintilla.CaretLineVisible = true;
      this.scintilla.ContextMenuStrip = this.cmsLuaEdit;
      this.scintilla.Dock = System.Windows.Forms.DockStyle.Fill;
      this.scintilla.IndentWidth = 2;
      this.scintilla.Lexer = ScintillaNET.Lexer.Lua;
      this.scintilla.Location = new System.Drawing.Point(0, 0);
      this.scintilla.Name = "scintilla";
      this.scintilla.ScrollWidth = 1;
      this.scintilla.Size = new System.Drawing.Size(624, 312);
      this.scintilla.TabIndex = 1;
      this.scintilla.TabWidth = 2;
      this.scintilla.CharAdded += new System.EventHandler<ScintillaNET.CharAddedEventArgs>(this.ScintillaCharAdded);
      this.scintilla.UpdateUI += new System.EventHandler<ScintillaNET.UpdateUIEventArgs>(this.ScintillaUpdateUi);
      this.scintilla.ZoomChanged += new System.EventHandler<System.EventArgs>(this.ScintillaZoomChanged);
      this.scintilla.TextChanged += new System.EventHandler(this.ScintillaTextChanged);
      // 
      // cmsLuaEdit
      // 
      this.cmsLuaEdit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsLuaEditUndo,
            this.cmsLuaEditRedo,
            cmsLuaEditSeperator1,
            this.cmsLuaEditCut,
            this.cmsLuaEditCopy,
            this.cmsLuaEditPaste,
            this.cmsLuaEditDelete,
            cmsLuaEditSeperator2,
            this.cmsLuaEditSelectAll});
      this.cmsLuaEdit.Name = "cmsLuaEdit";
      this.cmsLuaEdit.Size = new System.Drawing.Size(123, 170);
      this.cmsLuaEdit.Opening += new System.ComponentModel.CancelEventHandler(this.CmsLuaEditOpening);
      // 
      // cmsLuaEditUndo
      // 
      this.cmsLuaEditUndo.Name = "cmsLuaEditUndo";
      this.cmsLuaEditUndo.Size = new System.Drawing.Size(122, 22);
      this.cmsLuaEditUndo.Text = "Undo";
      this.cmsLuaEditUndo.Click += new System.EventHandler(this.TsbUndoClick);
      // 
      // cmsLuaEditRedo
      // 
      this.cmsLuaEditRedo.Name = "cmsLuaEditRedo";
      this.cmsLuaEditRedo.Size = new System.Drawing.Size(122, 22);
      this.cmsLuaEditRedo.Text = "Redo";
      this.cmsLuaEditRedo.Click += new System.EventHandler(this.TsbRedoClick);
      // 
      // cmsLuaEditCut
      // 
      this.cmsLuaEditCut.Name = "cmsLuaEditCut";
      this.cmsLuaEditCut.Size = new System.Drawing.Size(122, 22);
      this.cmsLuaEditCut.Text = "Cut";
      this.cmsLuaEditCut.Click += new System.EventHandler(this.TsbCutClick);
      // 
      // cmsLuaEditCopy
      // 
      this.cmsLuaEditCopy.Name = "cmsLuaEditCopy";
      this.cmsLuaEditCopy.Size = new System.Drawing.Size(122, 22);
      this.cmsLuaEditCopy.Text = "Copy";
      this.cmsLuaEditCopy.Click += new System.EventHandler(this.TsbCopyClick);
      // 
      // cmsLuaEditPaste
      // 
      this.cmsLuaEditPaste.Name = "cmsLuaEditPaste";
      this.cmsLuaEditPaste.Size = new System.Drawing.Size(122, 22);
      this.cmsLuaEditPaste.Text = "Paste";
      this.cmsLuaEditPaste.Click += new System.EventHandler(this.TsbPasteClick);
      // 
      // cmsLuaEditDelete
      // 
      this.cmsLuaEditDelete.Name = "cmsLuaEditDelete";
      this.cmsLuaEditDelete.Size = new System.Drawing.Size(122, 22);
      this.cmsLuaEditDelete.Text = "Delete";
      this.cmsLuaEditDelete.Click += new System.EventHandler(this.TsbDeleteClick);
      // 
      // cmsLuaEditSelectAll
      // 
      this.cmsLuaEditSelectAll.Name = "cmsLuaEditSelectAll";
      this.cmsLuaEditSelectAll.Size = new System.Drawing.Size(122, 22);
      this.cmsLuaEditSelectAll.Text = "Select All";
      this.cmsLuaEditSelectAll.Click += new System.EventHandler(this.TsbSelectAllClick);
      // 
      // tsCuCommands
      // 
      this.tsCuCommands.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
      this.tsCuCommands.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbLoadScript,
            this.tsbSaveScript,
            this.toolStripSeparator3,
            this.tsbCopy,
            this.tsbCut,
            this.tsbPaste,
            this.toolStripSeparator4,
            this.tsbUndo,
            this.tsbRedo,
            this.toolStripSeparator5,
            this.tsbStart,
            this.tsbStop,
            this.toolStripSeparator1,
            this.tsbZoomIn,
            this.tsbZoomOut});
      this.tsCuCommands.Location = new System.Drawing.Point(0, 0);
      this.tsCuCommands.Name = "tsCuCommands";
      this.tsCuCommands.Padding = new System.Windows.Forms.Padding(2, 0, 1, 0);
      this.tsCuCommands.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
      this.tsCuCommands.Size = new System.Drawing.Size(624, 25);
      this.tsCuCommands.TabIndex = 3;
      // 
      // tsbLoadScript
      // 
      this.tsbLoadScript.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbLoadScript.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbLoadScript.Name = "tsbLoadScript";
      this.tsbLoadScript.Size = new System.Drawing.Size(23, 22);
      this.tsbLoadScript.Text = "Load script";
      this.tsbLoadScript.Click += new System.EventHandler(this.TsbLoadScriptClick);
      // 
      // tsbSaveScript
      // 
      this.tsbSaveScript.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbSaveScript.Enabled = false;
      this.tsbSaveScript.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbSaveScript.Name = "tsbSaveScript";
      this.tsbSaveScript.Size = new System.Drawing.Size(23, 22);
      this.tsbSaveScript.Text = "Save script";
      this.tsbSaveScript.Click += new System.EventHandler(this.TsbSaveScriptClick);
      // 
      // toolStripSeparator3
      // 
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
      // 
      // tsbCopy
      // 
      this.tsbCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbCopy.Enabled = false;
      this.tsbCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbCopy.Name = "tsbCopy";
      this.tsbCopy.Size = new System.Drawing.Size(23, 22);
      this.tsbCopy.Text = "Copy";
      this.tsbCopy.Click += new System.EventHandler(this.TsbCopyClick);
      // 
      // tsbCut
      // 
      this.tsbCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbCut.Enabled = false;
      this.tsbCut.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbCut.Name = "tsbCut";
      this.tsbCut.Size = new System.Drawing.Size(23, 22);
      this.tsbCut.Text = "Cut";
      this.tsbCut.Click += new System.EventHandler(this.TsbCutClick);
      // 
      // tsbPaste
      // 
      this.tsbPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbPaste.Enabled = false;
      this.tsbPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbPaste.Name = "tsbPaste";
      this.tsbPaste.Size = new System.Drawing.Size(23, 22);
      this.tsbPaste.Text = "Paste";
      this.tsbPaste.Click += new System.EventHandler(this.TsbPasteClick);
      // 
      // toolStripSeparator4
      // 
      this.toolStripSeparator4.Name = "toolStripSeparator4";
      this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
      // 
      // tsbUndo
      // 
      this.tsbUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbUndo.Enabled = false;
      this.tsbUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbUndo.Name = "tsbUndo";
      this.tsbUndo.Size = new System.Drawing.Size(23, 22);
      this.tsbUndo.Text = "Undo";
      this.tsbUndo.Click += new System.EventHandler(this.TsbUndoClick);
      // 
      // tsbRedo
      // 
      this.tsbRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbRedo.Enabled = false;
      this.tsbRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbRedo.Name = "tsbRedo";
      this.tsbRedo.Size = new System.Drawing.Size(23, 22);
      this.tsbRedo.Text = "Redo";
      this.tsbRedo.Click += new System.EventHandler(this.TsbRedoClick);
      // 
      // toolStripSeparator5
      // 
      this.toolStripSeparator5.Name = "toolStripSeparator5";
      this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
      // 
      // tsbStart
      // 
      this.tsbStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbStart.Enabled = false;
      this.tsbStart.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbStart.Name = "tsbStart";
      this.tsbStart.Size = new System.Drawing.Size(23, 22);
      this.tsbStart.Text = "Start script";
      this.tsbStart.Click += new System.EventHandler(this.TsbStartClick);
      // 
      // tsbStop
      // 
      this.tsbStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbStop.Enabled = false;
      this.tsbStop.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbStop.Name = "tsbStop";
      this.tsbStop.Size = new System.Drawing.Size(23, 22);
      this.tsbStop.Text = "Stop script";
      this.tsbStop.Click += new System.EventHandler(this.TsbStopClick);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
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
      // splitContainer1
      // 
      this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
      this.splitContainer1.Location = new System.Drawing.Point(0, 25);
      this.splitContainer1.Name = "splitContainer1";
      this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.scintilla);
      this.splitContainer1.Panel1MinSize = 100;
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
      this.splitContainer1.Panel2MinSize = 100;
      this.splitContainer1.Size = new System.Drawing.Size(624, 416);
      this.splitContainer1.SplitterDistance = 312;
      this.splitContainer1.TabIndex = 4;
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.Controls.Add(this.tsOutput, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.bgPanel, 0, 1);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(624, 100);
      this.tableLayoutPanel1.TabIndex = 1;
      // 
      // tsOutput
      // 
      this.tsOutput.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
      this.tsOutput.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbOutputClear,
            this.tsbOutputWordWrap});
      this.tsOutput.Location = new System.Drawing.Point(0, 0);
      this.tsOutput.Name = "tsOutput";
      this.tsOutput.Padding = new System.Windows.Forms.Padding(2, 0, 1, 0);
      this.tsOutput.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
      this.tsOutput.Size = new System.Drawing.Size(624, 25);
      this.tsOutput.TabIndex = 3;
      // 
      // tsbOutputClear
      // 
      this.tsbOutputClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbOutputClear.Enabled = false;
      this.tsbOutputClear.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbOutputClear.Name = "tsbOutputClear";
      this.tsbOutputClear.Size = new System.Drawing.Size(23, 22);
      this.tsbOutputClear.Text = "Clear all output";
      this.tsbOutputClear.Click += new System.EventHandler(this.TsbOutputClearClick);
      // 
      // tsbOutputWordWrap
      // 
      this.tsbOutputWordWrap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbOutputWordWrap.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbOutputWordWrap.Name = "tsbOutputWordWrap";
      this.tsbOutputWordWrap.Size = new System.Drawing.Size(23, 22);
      this.tsbOutputWordWrap.Text = "Toggle word wrap";
      this.tsbOutputWordWrap.Click += new System.EventHandler(this.TsbOutputWordWrapClick);
      // 
      // bgPanel
      // 
      this.bgPanel.BackColor = System.Drawing.SystemColors.Control;
      this.bgPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(206)))), ((int)(((byte)(219)))));
      this.bgPanel.Controls.Add(this.txtOutput);
      this.bgPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.bgPanel.Location = new System.Drawing.Point(3, 28);
      this.bgPanel.Name = "bgPanel";
      this.bgPanel.Padding = new System.Windows.Forms.Padding(1);
      this.bgPanel.ShowTitle = false;
      this.bgPanel.Size = new System.Drawing.Size(618, 69);
      this.bgPanel.TabIndex = 5;
      this.bgPanel.TextPadding = new System.Windows.Forms.Padding(0, 0, 0, 0);
      this.bgPanel.Title = null;
      // 
      // txtOutput
      // 
      this.txtOutput.BackColor = System.Drawing.SystemColors.Window;
      this.txtOutput.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txtOutput.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtOutput.Location = new System.Drawing.Point(1, 1);
      this.txtOutput.Multiline = true;
      this.txtOutput.Name = "txtOutput";
      this.txtOutput.ReadOnly = true;
      this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.txtOutput.Size = new System.Drawing.Size(616, 67);
      this.txtOutput.TabIndex = 5;
      this.txtOutput.WordWrap = false;
      this.txtOutput.TextChanged += new System.EventHandler(this.TxtOutputTextChanged);
      // 
      // FrmLogScript
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(624, 441);
      this.CloseButton = false;
      this.CloseButtonVisible = false;
      this.Controls.Add(this.splitContainer1);
      this.Controls.Add(this.tsCuCommands);
      this.DockAreas = WeifenLuo.WinFormsUI.Docking.DockAreas.Document;
      this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "FrmLogScript";
      this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.Document;
      this.TabText = "Script";
      this.Text = "Script";
      this.cmsLuaEdit.ResumeLayout(false);
      this.tsCuCommands.ResumeLayout(false);
      this.tsCuCommands.PerformLayout();
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      this.tsOutput.ResumeLayout(false);
      this.tsOutput.PerformLayout();
      this.bgPanel.ResumeLayout(false);
      this.bgPanel.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private ScintillaNET.Scintilla scintilla;
    private Couchcoding.Logbert.Gui.Controls.ToolStripEx tsCuCommands;
    private System.Windows.Forms.ToolStripButton tsbLoadScript;
    private System.Windows.Forms.ToolStripButton tsbSaveScript;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    private System.Windows.Forms.ToolStripButton tsbCut;
    private System.Windows.Forms.ToolStripButton tsbCopy;
    private System.Windows.Forms.ToolStripButton tsbPaste;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    private System.Windows.Forms.ToolStripButton tsbUndo;
    private System.Windows.Forms.ToolStripButton tsbRedo;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
    private System.Windows.Forms.ToolStripButton tsbStart;
    private System.Windows.Forms.ToolStripButton tsbStop;
    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private Couchcoding.Logbert.Gui.Controls.ToolStripEx tsOutput;
    private System.Windows.Forms.ToolStripButton tsbOutputClear;
    private System.Windows.Forms.ToolStripButton tsbOutputWordWrap;
    private Gui.Controls.InfoPanel bgPanel;
    private System.Windows.Forms.TextBox txtOutput;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripButton tsbZoomIn;
    private System.Windows.Forms.ToolStripButton tsbZoomOut;
    private System.Windows.Forms.ContextMenuStrip cmsLuaEdit;
    private System.Windows.Forms.ToolStripMenuItem cmsLuaEditUndo;
    private System.Windows.Forms.ToolStripMenuItem cmsLuaEditRedo;
    private System.Windows.Forms.ToolStripMenuItem cmsLuaEditCut;
    private System.Windows.Forms.ToolStripMenuItem cmsLuaEditCopy;
    private System.Windows.Forms.ToolStripMenuItem cmsLuaEditPaste;
    private System.Windows.Forms.ToolStripMenuItem cmsLuaEditDelete;
    private System.Windows.Forms.ToolStripMenuItem cmsLuaEditSelectAll;
  }
}
