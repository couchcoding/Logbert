#region Copyright © 2015 Couchcoding

// File:    FrmMessageDetails.cs
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

using Couchcoding.Logbert.Interfaces;
using Couchcoding.Logbert.Logging;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Couchcoding.Logbert.Dialogs.Docking
{
  /// <summary>
  /// Implements the <see cref="DockContent"/> to display further details of a <see cref="LogMessage"/>.
  /// </summary>
  public partial class FrmMessageDetails : DockContent, ILogPresenter
  {
    #region Private Fields

    /// <summary>
    /// The <see cref="ILogPresenter"/> to display details of a selected <see cref="LogMessage"/>.
    /// </summary>
    private readonly ILogPresenter mPresenter;

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets the count of currently displayed <see cref=LogMessage"/>s.
    /// </summary>
    public int DisplayedLogMessagesCount
    {
      get
      {
        return 0;
      }
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Updates the visible <see cref="LogMessage"/>s.
    /// </summary>
    /// <param name="messages">The list of <see cref="LogMessage"/>s to display.</param>
    /// <param name="delta">The count of new <see cref="LogMessage"/>s.</param>
    public void LogMessagesChanged(System.Collections.Generic.List<LogMessage> messages, int delta)
    {
      // Nothing to do here.
    }

    /// <summary>
    /// Selects the <see cref="LogMessage"/> on the given <paramref name="index"/>.
    /// </summary>
    /// <param name="index">The index of the <see cref="LogMessage"/> to select.</param>
    public bool SelectLogMessage(int index)
    {
      // Nothing to do here.
      return true;
    }

    /// <summary>
    /// Selects the given <paramref name="message"/>.
    /// </summary>
    /// <param name="message">The <see cref="LogMessage"/> o select</param>
    public bool SelectLogMessage(LogMessage message)
    {
      return mPresenter != null && mPresenter.SelectLogMessage(message);
    }

    /// <summary>
    /// Updates the <see cref="LogLevel"/> to display.
    /// </summary>
    /// <param name="level">The new <see cref="LogLevel"/> to display.</param>
    public void LogLevelChanged(LogLevel level)
    {
      // Nothing to do here.
    }

    /// <summary>
    /// Clears all shown <see cref="LogMessage"/>s.
    /// </summary>
    public void ClearAll()
    {
      if (mPresenter != null)
      {
        mPresenter.ClearAll();
      }
    }

    /// <summary>
    /// Increases the size of the <see cref="ILogPresenter"/> content.
    /// </summary>
    /// <returns><c>True</c> if further increasing is possible, otherwise <c>false</c>.</returns>
    public bool ZoomIn()
    {
      return mPresenter != null && mPresenter.ZoomIn();
    }

    /// <summary>
    /// Decreases the size of the <see cref="ILogPresenter"/> content.
    /// </summary>
    /// <returns><c>True</c> if further decreasing is possible, otherwise <c>false</c>.</returns>
    public bool ZoomOut()
    {
      return mPresenter != null && mPresenter.ZoomOut();
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Creates a new instance of the <see cref="FrmMessageDetails"/> window.
    /// </summary>
    /// <param name="provider">The <see cref="ILogProvider"/> that sends messages to this window.</param>
    public FrmMessageDetails(ILogProvider provider)
    {
      InitializeComponent();

      if (provider != null)
      {
        mPresenter = provider.DetailsControl;

        Control uiPResenter = mPresenter as Control;

        if (uiPResenter != null)
        {
          uiPResenter.Dock = DockStyle.Fill;
          Controls.Add(uiPResenter);
        }
      }
    }

    #endregion
  }
}
