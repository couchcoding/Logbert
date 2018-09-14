#region Copyright © 2018 Couchcoding

// File:    FontCache.cs
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

namespace Couchcoding.Logbert.Helper
{
  /// <summary>
  /// Implements a cache for <see cref="Font"/>s.
  /// </summary>
  public static class FontCache
  {
    #region Private Fields

    /// <summary>
    /// The one and only <see cref="Font"/> cache.
    /// </summary>
    private static readonly Dictionary<string, Font> mFontCache = new Dictionary<string, Font>();

    /// <summary>
    /// Simple object for thread synchronization to access the <see cref="Font"/>s.
    /// </summary>
    private static readonly object mFontSync = new object();

    #endregion

    #region Public Methods

    /// <summary>
    /// Gets the cached <see cref="Font"/> that matches the requered parameters.
    /// </summary>
    /// <param name="name">The name of the <see cref="Font"/>.</param>
    /// <param name="size">The size of the <see cref="Font"/>.</param>
    /// <param name="style">The style of the <see cref="Font"/>.</param>
    /// <returns></returns>
    public static Font GetFontFromIdentifier(string name, float size, FontStyle style)
    {
      lock (mFontSync)
      {
        string fontKey = $"{name}_{size}_{style}";

        if (!mFontCache.ContainsKey(fontKey))
        {
          mFontCache[fontKey] = new Font(name, size, style);
        }

        return mFontCache[fontKey];
      }
    }

    #endregion
  }
}
