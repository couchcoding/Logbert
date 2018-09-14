#region Copyright © 2015 Couchcoding

// File:    ValidationResult.cs
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

using Couchcoding.Logbert.Properties;

namespace Couchcoding.Logbert.Receiver
{
  /// <summary>
  /// Implements a type to represent a validation result.
  /// </summary>
  public struct ValidationResult
  {
    #region Public Properties

    /// <summary>
    /// Determines whether the <see cref="ValidationResult"/> represents a success state, or not.
    /// </summary>
    public bool IsSuccess
    {
      get;
      private set;
    }

    /// <summary>
    /// Gets or sets the error message for the <see cref="ValidationResult"/> instance.
    /// </summary>
    public string ErrorMsg
    {
      get;
      private set;
    }

    /// <summary>
    /// Gets a new <see cref="ValidationResult"/> instance that indicates a success state.
    /// </summary>
    public static ValidationResult Success
    {
      get
      {
        return new ValidationResult(
            true
          , string.Empty);
      }
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Gets a new <see cref="ValidationResult"/> instance that indicates a non success state.
    /// </summary>
    /// <param name="errMsg">The occured error the <see cref="ValidationResult"/> represents.</param>
    /// <returns>A new <see cref="ValidationResult"/> instance that indicates a non success state.</returns>
    public static ValidationResult Error(string errMsg)
    {
      return new ValidationResult(
          false
        , errMsg ?? Resources.strValidationResultUnkownError);
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Creates a new instance of the <see cref="ValidationResult"/> type.
    /// </summary>
    /// <param name="isSuccess"><c>True</c> if the <see cref="ValidationResult"/> indicates success, otherwise <c>false</c>.</param>
    /// <param name="errorMsg">The error message that describes a non success state.</param>
    private ValidationResult(bool isSuccess, string errorMsg) : this()
    {
      IsSuccess = isSuccess;
      ErrorMsg  = errorMsg;
    }

    #endregion
  }
}
