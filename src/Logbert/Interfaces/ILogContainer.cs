#region Copyright © 2015 Couchcoding

// File:    ILogContainer.cs
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
using System.Collections.Generic;

using Couchcoding.Logbert.Logging;

namespace Couchcoding.Logbert.Interfaces
{
  /// <summary>
  /// Interface for all <see cref="LogMessage"/> container.
  /// </summary>
  public interface ILogContainer
  {
    #region Interface Properties

    /// <summary>
    /// Gets the received <see cref="LogMessage"/>s.
    /// </summary>
    List<LogMessage> LogMessages
    {
      get;
    }

    /// <summary>
    /// Gets or sets the tail state.
    /// </summary>
    bool TailEnabled
    {
      get;
      set;
    }

    #endregion

    #region Interface Methods

    /// <summary>
    /// Synchronizes the tree to the specified <see cref="LogMessage"/>.
    /// </summary>
    /// <param name="message">The <see cref="LogMessage"/> to synchronize the tree with.</param>
    void SynchronizeTree(LogMessage message);

    /// <summary>
    /// Update the value of the UI update timer interval.
    /// </summary>
    /// <param name="newTimerInterval">The new value for the UI update time.</param>
    void UpdateTimerInterval(int newTimerInterval);

    /// <summary>
    /// Updates the information display in the <see cref="StatusBar"/>.
    /// </summary>
    void UpdateStatusBarInformation();

    /// <summary>
    /// Clear all received logging data.
    /// </summary>
    void ClearAll();

    #endregion
  }
}
