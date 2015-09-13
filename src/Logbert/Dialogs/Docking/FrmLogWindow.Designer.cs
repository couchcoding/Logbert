namespace Com.Couchcoding.Logbert.Dialogs.Docking
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
      this.dtgLogMessages = new Com.Couchcoding.GuiLibrary.Controls.DataGridViewEx();
      this.imlBookmark = new System.Windows.Forms.ImageList(this.components);
      this.cmColumns = new System.Windows.Forms.ContextMenu();
      ((System.ComponentModel.ISupportInitialize)(this.dtgLogMessages)).BeginInit();
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
      this.dtgLogMessages.MultiSelect = false;
      this.dtgLogMessages.Name = "dtgLogMessages";
      this.dtgLogMessages.ReadOnly = true;
      this.dtgLogMessages.RowHeadersVisible = false;
      this.dtgLogMessages.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dtgLogMessages.ShowCellErrors = false;
      this.dtgLogMessages.ShowEditingIcon = false;
      this.dtgLogMessages.ShowRowErrors = false;
      this.dtgLogMessages.Size = new System.Drawing.Size(624, 441);
      this.dtgLogMessages.StandardTab = true;
      this.dtgLogMessages.TabIndex = 0;
      this.dtgLogMessages.VirtualMode = true;
      this.dtgLogMessages.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtgLogMessagesCellDoubleClick);
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
      this.cmColumns.Popup += new System.EventHandler(this.CmColumnsPopup);
      // 
      // FrmLogWindow
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(624, 441);
      this.CloseButton = false;
      this.CloseButtonVisible = false;
      this.Controls.Add(this.dtgLogMessages);
      this.DockAreas = WeifenLuo.WinFormsUI.Docking.DockAreas.Document;
      this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "FrmLogWindow";
      this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.Document;
      this.TabText = "Messages";
      this.Text = "Messages";
      ((System.ComponentModel.ISupportInitialize)(this.dtgLogMessages)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private Com.Couchcoding.GuiLibrary.Controls.DataGridViewEx dtgLogMessages;
    private System.Windows.Forms.ImageList imlBookmark;
    private System.Windows.Forms.ContextMenu cmColumns;

  }
}
