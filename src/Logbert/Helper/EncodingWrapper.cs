#region Copyright © 2018 Couchcoding

// File:    EncodingWrapper.cs
// Package: Logbert
// Project: Logbert
// 
// The MIT License (MIT)
// 
// Copyright (c) 2018 Couchcoding
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

using System.Text;

namespace Couchcoding.Logbert.Helper
{
  /// <summary>
  /// Class to wrap <see cref="Encoding"/> information.
  /// </summary>
  public class EncodingWrapper
  {
    #region Public Properties

    /// <summary>
    /// Gets the associated <see cref="Encoding"/>.
    /// </summary>
    public EncodingInfo Encoding
    {
      get;
    }

    /// <summary>
    /// Gets the codepage of the associated <see cref="Encoding"/>.
    /// </summary>
    public int Codepage => Encoding.CodePage;

    #endregion

    #region Overridden Methods

    /// <summary>Returns a string that represents the current object.</summary>
    /// <returns>A string that represents the current object.</returns>
    /// <filterpriority>2</filterpriority>
    public override string ToString()
    {
      return Encoding.DisplayName;
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Initializes a new instance of the <see cref="EncodingWrapper"/> with the specified parameters.
    /// </summary>
    /// <param name="encoding"></param>
    public EncodingWrapper(EncodingInfo encoding)
    {
      Encoding = encoding;
    }

    #endregion
  }
}
