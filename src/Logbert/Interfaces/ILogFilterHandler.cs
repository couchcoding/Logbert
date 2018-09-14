#region Copyright © 2015 Couchcoding

// File:    ILogFilterHandler.cs
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

using Couchcoding.Logbert.Logging.Filter;

namespace Couchcoding.Logbert.Interfaces
{
  /// <summary>
  /// Interface for all <see cref="LogFilter"/> handler.
  /// </summary>
  public interface ILogFilterHandler
  {
    #region Interface Methods

    /// <summary>
    /// Handles the change of the <see cref="LogFilter"/> of the registered <see cref="ILogFilterProvider"/>
    /// </summary>
    void FilterChanged();

    /// <summary>
    /// Registers a <see cref="ILogFilterProvider"/> to the <see cref="ILogFilterHandler"/> instance.
    /// </summary>
    /// <param name="provider">The <see cref="ILogFilterProvider"/> to register.</param>
    void RegisterFilterProvider(ILogFilterProvider provider);

    /// <summary>
    /// Unregisters a <see cref="ILogFilterProvider"/> from the <see cref="ILogFilterHandler"/> instance.
    /// </summary>
    /// <param name="provider">The <see cref="ILogFilterProvider"/> to unregister.</param>
    void UnregisterFilterProvider(ILogFilterProvider provider);

    #endregion
  }
}
