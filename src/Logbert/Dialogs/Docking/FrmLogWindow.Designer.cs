namespace Couchcoding.Logbert.Dialogs.Docking
{
  partial class FrmLogWindow
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogWindow));
      this.dtgLogMessages = new Couchcoding.Logbert.Gui.Controls.DataGridViewEx();
      this.imlBookmark = new System.Windows.Forms.ImageList(this.components);
      this.cmColumns = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.cmLogMessage = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.cmsSynchronizeTree = new System.Windows.Forms.ToolStripMenuItem();
      this.cmdcopytoclipboard = new System.Windows.Forms.ToolStripMenuItem();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.colorMap1 = new Couchcoding.Logbert.Controls.ColorMap((Interfaces.ILogPresenter)this);
      this.cmsSeperator = new System.Windows.Forms.ToolStripSeparator();
      this.cmsToggleBookmark = new System.Windows.Forms.ToolStripMenuItem();
      ((System.ComponentModel.ISupportInitialize)(this.dtgLogMessages)).BeginInit();
      this.cmLogMessage.SuspendLayout();
      this.tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // dtgLogMessages
      // 
      this.dtgLogMessages.AllowUserToAddRows = false;
      this.dtgLogMessages.AllowUserToDeleteRows = false;
      this.dtgLogMessages.AllowUserToResizeRows = false;
      this.dtgLogMessages.BackgroundColor = System.Drawing.SystemColors.Window;
      this.dtgLogMessages.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.dtgLogMessages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      this.dtgLogMessages.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dtgLogMessages.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
      this.dtgLogMessages.Location = new System.Drawing.Point(0, 0);
      this.dtgLogMessages.Margin = new System.Windows.Forms.Padding(0);
      this.dtgLogMessages.MultiSelect = true;
      this.dtgLogMessages.Name = "dtgLogMessages";
      this.dtgLogMessages.ReadOnly = true;
      this.dtgLogMessages.RowHeadersVisible = false;
      this.dtgLogMessages.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dtgLogMessages.ShowCellErrors = false;
      this.dtgLogMessages.ShowEditingIcon = false;
      this.dtgLogMessages.ShowRowErrors = false;
      this.dtgLogMessages.Size = new System.Drawing.Size(604, 441);
      this.dtgLogMessages.StandardTab = true;
      this.dtgLogMessages.TabIndex = 0;
      this.dtgLogMessages.VirtualMode = true;
      this.dtgLogMessages.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtgLogMessagesCellDoubleClick);
      this.dtgLogMessages.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgLogMessages_CellMouseClick);
      this.dtgLogMessages.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgLogMessages_CellMouseDown);
      this.dtgLogMessages.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DtgLogMessagesCellPainting);
      this.dtgLogMessages.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.DtgLogMessagesCellValueNeeded);
      this.dtgLogMessages.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DtgLogMessagesColumnHeaderMouseClick);
      this.dtgLogMessages.RowHeightInfoNeeded += new System.Windows.Forms.DataGridViewRowHeightInfoNeededEventHandler(this.DtgLogMessagesRowHeightInfoNeeded);
      this.dtgLogMessages.SelectionChanged += new System.EventHandler(this.DtgLogMessagesSelectionChanged);
      this.dtgLogMessages.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DtgLogMessagesKeyDown);
      // 
      // imlBookmark
      // 
      this.imlBookmark.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlBookmark.ImageStream")));
      this.imlBookmark.TransparentColor = System.Drawing.Color.Transparent;
      this.imlBookmark.Images.SetKeyName(0, "NoBookmark.png");
      this.imlBookmark.Images.SetKeyName(1, "bookmark_002_16xMD.png");
      // 
      // cmColumns
      // 
      this.cmColumns.Name = "cmColumns";
      this.cmColumns.Size = new System.Drawing.Size(61, 4);
      // 
      // cmLogMessage
      // 
      this.cmLogMessage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsSynchronizeTree,
            this.cmsSeperator,
            this.cmdcopytoclipboard,
            this.cmsToggleBookmark});
      this.cmLogMessage.Name = "cmColumns";
      this.cmLogMessage.Size = new System.Drawing.Size(214, 98);
      // 
      // cmsSynchronizeTree
      // 
      this.cmsSynchronizeTree.Name = "cmsSynchronizeTree";
      this.cmsSynchronizeTree.Size = new System.Drawing.Size(213, 22);
      this.cmsSynchronizeTree.Text = "Synchronize Tree";
      this.cmsSynchronizeTree.Click += new System.EventHandler(this.synchronizeTreeToolStripMenuItem_Click);
      // 
      // cmdcopytoclipboard
      // 
      this.cmdcopytoclipboard.Name = "cmdcopytoclipboard";
      this.cmdcopytoclipboard.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
      this.cmdcopytoclipboard.Size = new System.Drawing.Size(213, 22);
      this.cmdcopytoclipboard.Text = "Copy to Clipboard";
      this.cmdcopytoclipboard.Click += new System.EventHandler(this.copyToClipboardToolStripMenuItem_Click);
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 2;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tableLayoutPanel1.Controls.Add(this.dtgLogMessages, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.colorMap1, 1, 0);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 1;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(624, 441);
      this.tableLayoutPanel1.TabIndex = 2;
      // 
      // colorMap1
      // 
      this.colorMap1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.colorMap1.Location = new System.Drawing.Point(604, 0);
      this.colorMap1.Margin = new System.Windows.Forms.Padding(0);
      this.colorMap1.Name = "colorMap1";
      this.colorMap1.Size = new System.Drawing.Size(20, 441);
      this.colorMap1.TabIndex = 1;
      // 
      // cmsSeperator
      // 
      this.cmsSeperator.Name = "cmsSeperator";
      this.cmsSeperator.Size = new System.Drawing.Size(210, 6);
      // 
      // cmsToggleBookmark
      // 
      this.cmsToggleBookmark.Name = "cmsToggleBookmark";
      this.cmsToggleBookmark.Size = new System.Drawing.Size(213, 22);
      this.cmsToggleBookmark.Text = "Toggle Bookmark";
      this.cmsToggleBookmark.Click += new System.EventHandler(this.CmsToggleBookmarkClick);
      // 
      // FrmLogWindow
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(624, 441);
      this.CloseButton = false;
      this.CloseButtonVisible = false;
      this.Controls.Add(this.tableLayoutPanel1);
      this.DockAreas = WeifenLuo.WinFormsUI.Docking.DockAreas.Document;
      this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "FrmLogWindow";
      this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.Document;
      this.TabText = "Messages";
      this.Text = "Messages";
      ((System.ComponentModel.ISupportInitialize)(this.dtgLogMessages)).EndInit();
      this.cmLogMessage.ResumeLayout(false);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private Gui.Controls.DataGridViewEx dtgLogMessages;
    private System.Windows.Forms.ImageList imlBookmark;
    private System.Windows.Forms.ContextMenuStrip cmColumns;
    private System.Windows.Forms.ContextMenuStrip cmLogMessage;
    private System.Windows.Forms.ToolStripMenuItem cmsSynchronizeTree;
    private System.Windows.Forms.ToolStripMenuItem cmdcopytoclipboard;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private Controls.ColorMap colorMap1;
    private System.Windows.Forms.ToolStripSeparator cmsSeperator;
    private System.Windows.Forms.ToolStripMenuItem cmsToggleBookmark;
  }
}
