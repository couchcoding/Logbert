#region Copyright © 2015 Couchcoding

// File:    BrushCache.cs
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
using System.Drawing;

namespace Com.Couchcoding.Logbert.Helper
{
  /// <summary>
  /// Implements a cache for <see cref="Brushes"/>.
  /// </summary>
  public static class BrushCache
  {
    #region Private Fields

    /// <summary>
    /// The one and only <see cref="Brush"/> cache.
    /// </summary>
    private readonly static Dictionary<Color, Brush> mBrushCache = new Dictionary<Color,Brush>();

    /// <summary>
    /// Simple object for thread synchronization.
    /// </summary>
    private static readonly object mSync = new object();

    #endregion

    #region Public Methods

    /// <summary>
    /// Gets a cached <see cref="Brush"/> that matches the given <paramref name="color"/>.
    /// </summary>
    /// <param name="color">The <see cref="Color"/> to get a <see cref="Brush"/> for</param>
    /// <returns>The cached <see cref="Brush"/> that matches the given <paramref name="color"/>.</returns>
    public static Brush GetBrushFromColor(Color color)
    {
      lock (mSync)
      {
        if (!mBrushCache.ContainsKey(color))
        {
          mBrushCache.Add(color, new SolidBrush(color));
        }

        return mBrushCache[color];
      }
    }

    #endregion
  }
}
