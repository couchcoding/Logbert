#region Copyright © 2019 Couchcoding

// File:    FixedSizedQueue.cs
// Package: Logbert
// Project: Logbert
// 
// The MIT License (MIT)
// 
// Copyright (c) 2019 Couchcoding
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

using System.Collections.Concurrent;

namespace Couchcoding.Logbert.Helper
{
  /// <summary>
  /// Implements a <see cref="ConcurrentQueue{T}"/> of a fixed size.
  /// </summary>
  internal class FixedSizedQueue<T> : ConcurrentQueue<T>
  {
    #region Private Fields

    /// <summary>
    /// Simple object for thread synchronization.
    /// </summary>
    private readonly object mSyncObject = new object();

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets the fixed size of the <see cref="FixedSizedQueue{T}"/>.
    /// </summary>
    public int Size
    {
      get;
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Adds an object at the end of the <see cref="FixedSizedQueue{T}"/>.
    /// </summary>
    /// <param name="obj">The object to add at the end of the <see cref="FixedSizedQueue{T}"/></param>
    public new void Enqueue(T obj)
    {
      // Add the object to the queue.
      base.Enqueue(obj);

      lock (mSyncObject)
      {
        while (base.Count > Size)
        {
          // Ensure we don't exceed the maximum size.
          TryDequeue(out T outObj);
        }
      }
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Creates a new instance of the <see cref="FixedSizedQueue{T}"/> with the specified <paramref name="size"/>.
    /// </summary>
    /// <param name="size">The maximum size of the <see cref="FixedSizedQueue{T}"/>.</param>
    public FixedSizedQueue(int size)
    {
      Size = size;
    }

    #endregion
  }
}
