#region Copyright © 2015 Couchcoding

// File:    MainForm.cs
// Package: Logbert
// Project: Logbert
// 
// The MIT License (MIT)
// 
// Copyright (c) 2015 Couchcoding
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

#endregion

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Com.Couchcoding.Logbert.Controls.OptionPanels;
using Com.Couchcoding.Logbert.Dialogs;
using Com.Couchcoding.Logbert.Dialogs.Docking;
using Com.Couchcoding.Logbert.Helper;
using Com.Couchcoding.Logbert.Properties;
using Com.Couchcoding.Logbert.Receiver.Log4NetFileReceiver;

using WeifenLuo.WinFormsUI.Docking;
using Com.Couchcoding.Logbert.Interfaces;
using Com.Couchcoding.Logbert.Receiver.SyslogFileReceiver;
using System.IO;
using System.IO.Pipes;
using System.Text;

using Com.Couchcoding.Logbert.Receiver;

namespace Logbert
{
  public partial class MainForm : Form, ISearchable
  {
    #region Private Consts

    private const string LOGBERT_HOMEPAGE_URI = @"https://github.com/couchcoding/Logbert/";

    #endregion

    #region Private Fields

    /// <summary>
    /// The find <see cref="Form"/> to search for strings.
    /// </summary>
    private readonly FrmLogSearch mFindWindow;

    /// <summary>
    /// The <see cref="NamedPipeServerStream"/> to receive command line arguments from other Logbert instances.
    /// </summary>
    private static NamedPipeServerStream mPipedStream;

    /// <summary>
    /// A <see cref="Delegate"/> to handle piped messages to this application.
    /// </summary>
    /// <param name="pipedMessage">The received piped message.</param>
    private delegate void HandlePipedMessageDelegate(string pipedMessage);

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets or sets the font of the text displayed by the control.
    /// </summary>
    /// <returns>The <see cref="T:System.Drawing.Font"/> to apply to the text displayed by the control. The default is the value of the <see cref="P:System.Windows.Forms.Control.DefaultFont"/> property.</returns>
    [AmbientValue(null)]
    [Localizable(true)]
    public sealed override Font Font
    {
      get
      {
        return base.Font;
      }
      set
      {
        base.Font = value;
      }
    }

    #endregion

    #region Private Methods

    private void MnuMainHomepageClick(object sender, EventArgs e)
    {
      try
      {
        System.Diagnostics.Process.Start(LOGBERT_HOMEPAGE_URI);
      }
      catch (Exception ex1)
      {
        // System.ComponentModel.Win32Exception is a known exception that occurs when Firefox is default browser.  
        // It actually opens the browser but STILL throws this exception so we can just ignore it.  If not this exception,
        // then attempt to open the URL in IE instead.
        if (ex1.GetType().ToString() != "System.ComponentModel.Win32Exception")
        {
          // Sometimes throws exception so we have to just ignore.
          // This is a common .NET issue that no one online really has a great reason for so now we just need to try to open the URL using IE if we can.
          try
          {
            System.Diagnostics.ProcessStartInfo startInfo = 
              new System.Diagnostics.ProcessStartInfo("IExplore.exe", LOGBERT_HOMEPAGE_URI);

            System.Diagnostics.Process.Start(startInfo);
          }
          catch
          {
            MessageBox.Show(
                this
              , string.Format(Resources.strMainUnableToOpenUri, LOGBERT_HOMEPAGE_URI)
              , Application.ProductName
              , MessageBoxButtons.OK
              , MessageBoxIcon.Error);
          }
        }
      }
    }

    private void MnuMainHelpAboutClick(object sender, EventArgs e)
    {
      using (FrmAbout aboutDlg = new FrmAbout())
      {
        aboutDlg.ShowDialog(this);
      }
    }

    private void MnuMainFileNewLoggerClick(object sender, EventArgs e)
    {
      using (FrmNew newDlg = new FrmNew())
      {
        if (newDlg.ShowDialog(this) == DialogResult.OK)
        {
          new FrmLogDocument(newDlg.LogProvider).Show(mainDockPanel);
        }
      }
    }

    private void MnuMainFileExitClick(object sender, EventArgs e)
    {
      Application.Exit();
    }

    private void MnuMainFileOpenLogFileClick(object sender, EventArgs e)
    {
      using (OpenFileDialog ofd = new OpenFileDialog())
      {
        ofd.CheckFileExists  = true;
        ofd.CheckPathExists  = true;
        ofd.Filter           = Resources.strFileLoadPattern;
        ofd.RestoreDirectory = true;

        if (ofd.ShowDialog(this) == DialogResult.OK)
        {
          LoadFileIntoLogger(ofd.FileName);
        }
      }
    }

    private void mnuMainExtrasOptions_Click(object sender, EventArgs e)
    {
      IOptionPanel[] optionPanels = 
      {
        new OptionPanelGeneral(),
        new OptionPanelFontColor(),
        new OptionPanelScriptEditor()
      };

      using (FrmOptions optionsDlg = new FrmOptions(optionPanels))
      {
        if (optionsDlg.ShowDialog(this) == DialogResult.OK)
        {
          using (new WaitCursor(Cursors.Default, Settings.Default.WaitCursorTimeout))
          {
            foreach (IOptionPanel optionPanel in optionPanels)
            {
              optionPanel.SaveSettings();
            }

            foreach (IDockContent dockContent in mainDockPanel.Documents)
            {
              ILogContainer currentDocument = dockContent as ILogContainer;

              if (currentDocument != null)
              {
                // Update the UI refresh value for all logging windows.
                currentDocument.UpdateTimerInterval(
                  Settings.Default.UiRefreshIntervalMs);
              }
            }

            // Force a repaint of all UI elements.
            Refresh();
          }
        }
      }
    }

    private void MnuMainEditFindClick(object sender, EventArgs e)
    {
      if (mFindWindow != null && !mFindWindow.IsDisposed)
      {
        if (!mFindWindow.Visible)
        {
          mFindWindow.Location = new Point(
              Location.X + 100
            , Location.Y + 100);

          mFindWindow.Show(this);
        }

        mFindWindow.Focus();
      }
    }

    /// <summary>
    /// Handles the ContentAdded event of the main <see cref="DockPanel"/>.
    /// </summary>
    private void MainDockPanelContentAdded(object sender, DockContentEventArgs e)
    {
      mnuMainEditFind.Enabled     = true;
      mnuMainEditFindNext.Enabled = true;

      UpdateUiElements();
    }

    /// <summary>
    /// Handles the ContentRemoved event of the main <see cref="DockPanel"/>.
    /// </summary>
    private void MainDockPanelContentRemoved(object sender, DockContentEventArgs e)
    {
      if (Disposing)
      {
        return;
      }

      if (mainDockPanel != null)
      {
        mnuMainEditFind.Enabled     = mainDockPanel.DocumentsCount > 0;
        mnuMainEditFindNext.Enabled = mnuMainEditFind.Enabled;

        if (mainDockPanel.DocumentsCount == 0 &&  mFindWindow.Visible)
        {
          mFindWindow.Hide();
        }
      }
      else
      {
        mnuMainEditFind.Enabled     = false;
        mnuMainEditFindNext.Enabled = false;
      }

      UpdateUiElements();
    }

    /// <summary>
    /// Updates the UI elements within the <see cref="MainForm"/> depending in the current 
    /// <see cref="DockWindow"/>s and <see cref="Settings"/>.
    /// </summary>
    private void UpdateUiElements()
    {
      mnuMainEditFindNext.Enabled = mnuMainEditFind.Enabled 
        && Settings.Default.FrmFindSearchValue != null 
        && !string.IsNullOrEmpty(Settings.Default.FrmFindSearchValue[0]);

      mnuMainEditFindNext.Enabled = mnuMainEditFind.Enabled;
    }

    /// <summary>
    /// Loads the last known dialog settings.
    /// </summary>
    private void LoadDialogSettings()
    {
      if (Settings.Default.FrmMainFormSize.IsEmpty)
      {
        // The application may be opened for the first time.
        Size          = new Size(800, 600);
        StartPosition = FormStartPosition.CenterScreen;
      }
      else
      {
        // Use the last known location.
        StartPosition = FormStartPosition.Manual;

        // Get the available screen area.
        Rectangle availableArea = Screen.GetWorkingArea(this);

        // Ensure the dialog is visible on the right side.
        Left = Settings.Default.FrmMainFormLocation.X + Width <= availableArea.Width
          ? Settings.Default.FrmMainFormLocation.X
          : availableArea.Width - Width;

        // Ensure the dialog is visible on the left side.
        Left = Left < 0 ? 0 : Left;

        // Ensure the dialog is visible on the bottom.
        Top = Settings.Default.FrmMainFormLocation.Y + Height <= availableArea.Height
          ? Settings.Default.FrmMainFormLocation.Y
          : availableArea.Height - Height;

        // Ensure the dialog is visible on the top.
        Top = Top < 0 ? 0 : Top;

        // Set the size of the dialog.
        Size = Settings.Default.FrmMainFormSize;

        // Set the last used window state.
        WindowState = Settings.Default.FrmMainFormState;
      }

      RebuildMruList();
    }

    private void RebuildMruList()
    {
      mnuMainFileRecentFiles.DropDownItems.Clear();
      mnuMainFileRecentFiles.Enabled = false;

      for (int mruFileIndex = MruManager.MruFiles.Count - 1; mruFileIndex >= 0; --mruFileIndex)
      {
        ToolStripMenuItem newMruItem = new ToolStripMenuItem(string.Format(
            "&{0} {1}"
          , MruManager.MruFiles.Count - mruFileIndex
          , MruManager.MruFiles[mruFileIndex].ToShortPath(SystemFonts.MenuFont))
          , null
          , OnMruFileClick);

        newMruItem.Tag = MruManager.MruFiles[mruFileIndex];

        mnuMainFileRecentFiles.DropDownItems.Add(newMruItem);
      }

      if (mnuMainFileRecentFiles.DropDownItems.Count > 0)
      {
        mnuMainFileRecentFiles.Enabled = true;

        // Add a seperator and clear item to the MRU list.
        mnuMainFileRecentFiles.DropDownItems.Add(new ToolStripSeparator());

        mnuMainFileRecentFiles.DropDownItems.Add(new ToolStripMenuItem(
            Resources.strClearMruList
          , null
          , OnMruClearItems));
      }
    }

    private void OnMruClearItems(object sender, EventArgs e)
    {
      MruManager.ClearFiles();
      RebuildMruList();
    }

    private void OnMruFileClick(object sender, EventArgs e)
    {
      string logFileToLoad = ((ToolStripMenuItem)sender).Tag as string;

      if (!File.Exists(logFileToLoad))
      {
        DialogResult removeRslt = MessageBox.Show(
            Resources.strMruFileCouldNotBeFound
          , Application.ProductName
          , MessageBoxButtons.YesNo
          , MessageBoxIcon.Warning);

        if (removeRslt == DialogResult.Yes)
        {
          MruManager.RemoveFile(logFileToLoad);
          RebuildMruList();
        }

        return;
      }

      LoadFileIntoLogger(logFileToLoad);
    }

    /// <summary>
    /// Saves the current dialog settings.
    /// </summary>
    private void SaveDialogSettings()
    {
      Settings.Default.FrmMainFormState = WindowState;

      if (WindowState == FormWindowState.Normal)
      {
        Settings.Default.FrmMainFormSize     = Size;
        Settings.Default.FrmMainFormLocation = Location;
      }

      Settings.Default.SaveSettings();
    }

    /// <summary>
    /// Handles the FromClosing event of the <see cref="MainForm"/>.
    /// <remarks>Saves the current dialog settings.</remarks>
    /// </summary>
    private void MainFormFormClosing(object sender, FormClosingEventArgs e)
    {
      if (ModifierKeys != Keys.Shift)
      {
        SaveDialogSettings();
      }
    }

    /// <summary>
    /// Loads the given <paramref name="logFileToLoad"/> into a new logger window.
    /// </summary>
    /// <param name="logFileToLoad">The log file to load into a new logger window.</param>
    /// <param name="verbose">[Optional] <c>True</c> to inform the user about any load error, otherwise <c>false</c>. Default is <c>True</c>.</param>
    private void LoadFileIntoLogger(string logFileToLoad, bool verbose = true)
    {
      if (!string.IsNullOrEmpty(logFileToLoad) && File.Exists(logFileToLoad))
      {
        ReceiverBase[] knownFileReceiver = 
        {
            new Log4NetFileReceiver(logFileToLoad, true)
          , new SyslogFileReceiver (logFileToLoad, true)
        };

        foreach (ReceiverBase receiver in knownFileReceiver)
        {
          if (receiver.CanHandleLogFile())
          {
            FrmLogDocument newFileDocument = new FrmLogDocument(receiver);

            // Disable continues logging by default.
            newFileDocument.Active = false;
          
            // Show the new document.
            newFileDocument.Show(mainDockPanel);

            // Add the file to the recently used stack.
            MruManager.AddFile(logFileToLoad);

            // Rebuild the MRU list to ensure the opened file is displayed in the menu.
            RebuildMruList();

            return;
          }
        }

        if (verbose)
        {
          // Inform the user about the error.
          MessageBox.Show(this, string.Format(
              Resources.strOpenLogFileError
            , Path.GetFileName(logFileToLoad))
            , Application.ProductName
            , MessageBoxButtons.OK
            , MessageBoxIcon.Error);
        }
      }
    }

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && components != null)
      {
        components.Dispose();
      }

      if (mPipedStream != null)
      {
        mPipedStream.Close();
      }

      if (mFindWindow != null)
      {
        mFindWindow.Dispose();
      }

      base.Dispose(disposing);
    }

    /// <summary>
    /// Handles the connected event of the <see cref="NamedPipeServerStream"/> object.
    /// </summary>
    /// <param name="ar">The <see cref="IAsyncResult"/>s that contains connection information.</param>
    private void NamedPipeConnected(IAsyncResult ar)
    {
      if (mPipedStream != null && ar.IsCompleted)
      {
        try
        {
          mPipedStream.EndWaitForConnection(ar);

          byte[] cmdLineBuffer = new byte[8191];

          mPipedStream.BeginRead(
              cmdLineBuffer
            , 0
            , cmdLineBuffer.Length
            , NamedPipeRead
            , cmdLineBuffer);
        }
        catch (ObjectDisposedException)
        {
          // On closing the application the named piped may throw a disposed exception.
          // We ignore this on closing.
        }
        catch (Exception ex)
        {
          Logger.Error(ex.Message);
        }
      }
    }

    /// <summary>
    /// Handles the read event of the <see cref="NamedPipeServerStream"/> object.
    /// </summary>
    /// <param name="ar">The <see cref="IAsyncResult"/>s that contains readable information.</param>
    private void NamedPipeRead(IAsyncResult ar)
    {
      if (mPipedStream != null && ar.IsCompleted && mPipedStream.IsMessageComplete)
      {
        int length = mPipedStream.EndRead(ar);

        string cmdArgs = Encoding.Default.GetString(
            (byte[])ar.AsyncState
          , 0
          , length);

        try
        {
          mPipedStream.Disconnect();

          mPipedStream.BeginWaitForConnection(
              NamedPipeConnected
            , null);

          HandlePipedMessage(cmdArgs);
        }
        catch (Exception ex)
        {
          Logger.Error(ex.Message);
        }
      }
    }

    /// <summary>
    /// Handles messages from the named piped (inter process communication).
    /// </summary>
    /// <param name="pipedMessage">The piped message to handle.</param>
    private void HandlePipedMessage(string pipedMessage)
    {
      if (InvokeRequired)
      {
        // Piped messages comming from a asynchronous task!
        BeginInvoke(
            new HandlePipedMessageDelegate(HandlePipedMessage)
          , pipedMessage);

        return;
      }

      if(Equals(pipedMessage, Program.BRING_TO_FRONT_MSG))
      {
        if (WindowState == FormWindowState.Minimized)
        {
          // Bring the main window into front.
          Win32.ShowWindow(
              Handle
            , Win32.SW_RESTORE);
        }

        Win32.SetForegroundWindow(Handle);

        return;
      }

      // All other messages should contain a file name.
      LoadFileIntoLogger(
          pipedMessage
        , false);
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Form.Load"/> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data. </param>
    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      if (mPipedStream != null)
      {
        mPipedStream.BeginWaitForConnection(
            NamedPipeConnected
          , null);
      }
    }

    /// <summary>
    /// Handles the DragOver event of the main <see cref="Form"/>.
    /// </summary>
    private void MainForm_DragOver(object sender, DragEventArgs e)
    {
      e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop)
        ? DragDropEffects.Copy
        : DragDropEffects.None;
    }

    /// <summary>
    /// Handles the DragDrop event of the main <see cref="Form"/>.
    /// </summary>
    private void MainForm_DragDrop(object sender, DragEventArgs e)
    {
      if (e.Data.GetDataPresent(DataFormats.FileDrop))
      {
        string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

        foreach (string logFileToLoad in files)
        {
          LoadFileIntoLogger(
              logFileToLoad
            , false);
        }
      }
    }

    private void MnuMainEditFindNextClick(object sender, EventArgs e)
    {
      mFindWindow.PerformSearch(mFindWindow.CurrentSearchValue);
    }

    /// <summary>
    /// Handles the DropDownOpening event of the file <see cref="ToolStripMenuItem"/>.
    /// </summary>
    private void MnuMainFileOpening(object sender, EventArgs e)
    {
       mnuMainFileCloseAll.Enabled = mainDockPanel.DocumentsCount > 0;
    }

    /// <summary>
    /// Handles the Click event of the close all <see cref="ToolStripMenuItem"/>.
    /// </summary>
    private void MnuMainFileCloseAllClick(object sender, EventArgs e)
    {
      IDockContent[] openDocuments = mainDockPanel.DocumentsToArray();

      for (int i = openDocuments.Length - 1; i >= 0; --i)
      {
        openDocuments[i].DockHandler.Close();
      }
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Search for a <see cref="LogMessage"/> that contains the given <paramref name="pattern"/>.
    /// </summary>
    /// <param name="pattern">The patter to search for.</param>
    /// <param name="searchForward">Determines the search direction.</param>
    /// <param name="searchAllDocuments">Determines whether in all open <see cref="ISearchable"/>s should be searched, or not.</param>
    public void SearchLogMessage(string pattern, bool searchForward = true, bool searchAllDocuments = false)
    {
      if (string.IsNullOrEmpty(pattern))
      {
        // Nothing to search for.
        return;
      }

      // The current receiver to search into.
      ISearchable currentDocument;

      if (searchAllDocuments)
      {
        foreach (IDockContent dockContent in mainDockPanel.Documents)
        {
          currentDocument = dockContent as ISearchable;

          if (currentDocument != null)
          {
            currentDocument.SearchLogMessage(
                pattern
              , searchForward
              , true);
          }
        }

        return;
      }

      currentDocument = mainDockPanel.ActiveDocument as ISearchable;

      if (currentDocument != null)
      {
        currentDocument.SearchLogMessage(
            pattern
          , searchForward);
      }
    }

    /// <summary>
    /// Creates a new <see cref="NamedPipeServerStream"/> for interprocess communication.
    /// </summary>
    /// <param name="pipeName">The name of the new <see cref="NamedPipeServerStream"/> that is created.</param>
    /// <returns><c>True</c> if the new <see cref="NamedPipeServerStream"/> was created successfully, otherwise <c>false</c>.</returns>
    public static bool CreateNamedPipe(string pipeName)
    {
      if (string.IsNullOrEmpty(pipeName))
      {
        return false;
      }

      try
      {
        mPipedStream = new NamedPipeServerStream(
            pipeName
          , PipeDirection.In
          , 1
          , PipeTransmissionMode.Message
          , PipeOptions.Asynchronous);
      }
      catch
      {
        // Antoher instance seems already running.
        return false;
      }

      return true;
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Creates a new instance of the <see cref="MainForm"/> dialog.
    /// </summary>
    /// <param name="logFileToLoad">The optional path to a log file to load.</param>
    public MainForm(string logFileToLoad)
    {
      InitializeComponent();

      mainDockPanel.Theme = ThemeManager.CurrentApplicationTheme;
      mainDockPanel.Theme.ApplyTo(mnuMain);

      mainDockPanel.BackColor       = mainDockPanel.DockBackColor;
      mainDockPanel.BackgroundImage = Resources.Logbert_Start_Screen;

      // Ensure we're using the systems default dialog font for the main view.
      Font = SystemFonts.MessageBoxFont;

      try
      {
        if (Settings.Default.GetPreviousVersion("FrmMainFormSize") != null)
        {
          // Upgrade previous user settings if necessary.
          Settings.Default.Upgrade();
        }
      }
      catch (Exception ex)
      {
        Logger.Error(ex.Message);
      }

      // Set the size and location of the main window.
      LoadDialogSettings();

      // Create the one and only find window instance.
      mFindWindow = new FrmLogSearch(this);

      LoadFileIntoLogger(logFileToLoad);
    }

    #endregion
  }
}
