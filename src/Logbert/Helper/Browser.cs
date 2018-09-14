#region Copyright © 2017 Couchcoding

// File:    Browser.cs
// Package: Logbert
// Project: Logbert
// 
// The MIT License (MIT)
// 
// Copyright (c) 2017 Couchcoding
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
using System.Diagnostics;
using System.Windows.Forms;

namespace Couchcoding.Logbert.Helper
{
  /// <summary>
  /// Implements helper methods to access the system browser.
  /// </summary>
  public static class Browser
  {
    #region Public Methods

    /// <summary>
    /// Opens the system web browser with the specified URI.
    /// </summary>
    /// <param name="URI">THE URI to open in the system browser.</param>
    /// <param name="owner">The <see cref="IWin32Window"/> as parent for the <see cref="MessageBox"/> that is shown on error.</param>
    public static void Open(string URI, IWin32Window owner)
    {
      try
      {
        Process.Start(URI);
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
            ProcessStartInfo startInfo = 
              new ProcessStartInfo("IExplore.exe", URI);

            Process.Start(startInfo);
          }
          catch
          {
            MessageBox.Show(
                owner
              , string.Format(Properties.Resources.strMainUnableToOpenUri, URI)
              , Application.ProductName
              , MessageBoxButtons.OK
              , MessageBoxIcon.Error);
          }
        }
      }
    }

    #endregion
  }
}
