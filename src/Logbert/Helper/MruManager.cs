#region Copyright © 2015 Couchcoding

// File:    MruManager.cs
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

using Couchcoding.Logbert.Properties;
using System.Collections.Specialized;
using System.IO;

namespace Couchcoding.Logbert.Helper
{
  /// <summary>
  /// Implements a class to manage the recently used files.
  /// </summary>
  public static class MruManager
  {
    #region Private Consts

    /// <summary>
    /// Defines the maximum count of MRU file.
    /// </summary>
    private const int MAX_MRU_FILE_COUNT = 9;

    #endregion

    #region Public Events

    /// <summary>
    /// Occurs if the MRU list has been changed.
    /// </summary>
    public static event EventHandler MruListChanged = delegate { };

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets the <see cref="StringCollection"/> of all known files.
    /// </summary>
    public static StringCollection MruFiles => Settings.Default.MruManagerFiles ?? new StringCollection();

      #endregion

    #region Public Methods

    /// <summary>
    /// Adds the given <paramref name="filename"/> to the recently used <see cref="StringCollection"/>.
    /// </summary>
    /// <param name="filename">The full path of the file to add.</param>
    public static void AddFile(string filename)
    {
      if (!string.IsNullOrEmpty(filename) && File.Exists(filename))
      {
        if (Settings.Default.MruManagerFiles == null)
        {
          Settings.Default.MruManagerFiles = new StringCollection();
        }

        if (!Settings.Default.MruManagerFiles.Contains(filename))
        {
          while (Settings.Default.MruManagerFiles.Count > MAX_MRU_FILE_COUNT)
          {
            // Ensure the maximum count of MRU file is not exceeded.
            Settings.Default.MruManagerFiles.RemoveAt(Settings.Default.MruManagerFiles.Count - 1);
          }

          Settings.Default.MruManagerFiles.Add(filename);
          Settings.Default.SaveSettings();
        }
        else
        {
          // The file already exists. Move it to the last position.
          Settings.Default.MruManagerFiles.Remove(filename);
          Settings.Default.MruManagerFiles.Add(filename);
          Settings.Default.SaveSettings();
        }

        MruListChanged?.Invoke(null, EventArgs.Empty);
      }
    }

      /// <summary>
      /// Removes the given <paramref name="filename"/> from the <see cref="StringCollection"/>.
      /// </summary>
      /// <param name="filename">The full path of the file to remove.</param>
      public static void RemoveFile(string filename)
      {
          if (string.IsNullOrEmpty(filename) || Settings.Default.MruManagerFiles == null)
          {
              return;
          }

          if (Settings.Default.MruManagerFiles.Contains(filename))
          {
              Settings.Default.MruManagerFiles.Remove(filename);
              Settings.Default.SaveSettings();
          }

          MruListChanged?.Invoke(null, EventArgs.Empty);
      }

      /// <summary>
    /// Removes all recently used files from the <see cref="StringCollection"/>.
    /// </summary>
    public static void ClearFiles()
    {
      if (Settings.Default.MruManagerFiles == null)
      {
        return;
      }

      Settings.Default.MruManagerFiles.Clear();
      Settings.Default.SaveSettings();

        MruListChanged?.Invoke(null, EventArgs.Empty);
        }

    #endregion
  }
}
