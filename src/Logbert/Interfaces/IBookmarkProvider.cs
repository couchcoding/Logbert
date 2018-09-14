#region Copyright © 2015 Couchcoding

// File:    IBookmarkProvider.cs
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

using System.Collections.Generic;
using Couchcoding.Logbert.Logging;

namespace Couchcoding.Logbert.Interfaces
{
  public interface IBookmarkProvider
  {
    #region Public Properties

    /// <summary>
    /// Gets the <see cref="List{LogMessage}"/>´of bookmarked <see cref="LogMessage"/>s.
    /// </summary>
    List<LogMessage> Bookmarks
    {
      get;
    }

    /// <summary>
    /// Gets the current selected <see cref="LogMessage"/>.
    /// </summary>
    LogMessage SelectedMessage
    {
      get;
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Selects the <see cref="LogMessage"/> on the given <paramref name="index"/>.
    /// </summary>
    /// <param name="index">The index of the <see cref="LogMessage"/> to select.</param>
    /// <returns><c>True</c> if the <see cref="LogMessage"/> of the given <paramref name="index"/> was selected successfully, otherwise <c>false</c>.</returns>
    bool SelectLogMessage(int index);

    /// <summary>
    /// Selects the given <paramref name="message"/>.
    /// </summary>
    /// <param name="message">The <see cref="LogMessage"/> to select</param>
    bool SelectLogMessage(LogMessage message);

    /// <summary>
    /// Adds a new Bookmark for the given list of <paramref name="message"/>s.
    /// </summary>
    /// <param name="messages">The <see cref="LogMessage"/>s to bookmark.</param>
    void AddBookmarks(List<LogMessage> messages);

    /// <summary>
    /// Removes the given <paramref name="message"/>s from the bookmarks.
    /// </summary>
    /// <param name="messages">The <see cref="LogMessage"/>s to remove from the bookmarks.</param>
    void RemoveBookmarks(List<LogMessage> messages);

    /// <summary>
    /// Registers a <see cref="IBookmarkObserver"/> to the <see cref="IBookmarkProvider"/> instance.
    /// </summary>
    /// <param name="observer">The <see cref="IBookmarkObserver"/> to register.</param>
    void RegisterBookmarkObserver(IBookmarkObserver observer);

    /// <summary>
    /// Unregisters a <see cref="IBookmarkObserver"/> from the <see cref="IBookmarkProvider"/> instance.
    /// </summary>
    /// <param name="observer">The <see cref="IBookmarkObserver"/> to unregister.</param>
    void UnregisterBookmarkObserver(IBookmarkObserver observer);

    #endregion
  }
}
