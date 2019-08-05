#region Copyright © 2015 Couchcoding

// File:    Extensions.cs
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
using System.Configuration;
using System.Drawing;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Couchcoding.Logbert.Helper
{
  /// <summary>
  /// Implements some <see cref="Control"/> extensions.
  /// </summary>
  public static class Extensions
  {
    #region Private Consts

    /// <summary>
    /// An application sends the WM_SETREDRAW message to a window to allow changes in that window to be redrawn or to prevent changes in that window from being redrawn.
    /// </summary>
    private const int WM_SETREDRAW = 0xB;

    /// <summary>
    /// The line count of a textbox control.
    /// </summary>
    private const int EM_GETLINECOUNT = 0xba;

    #endregion

    #region External Methods

    /// <summary>
    /// Sends the specified message to a window or windows.
    /// </summary>
    /// <param name="hwnd">A handle to the window whose window procedure will receive the message.</param>
    /// <param name="wMsg">The message to be sent.</param>
    /// <param name="wParam">Additional message-specific information.</param>
    /// <param name="lParam">Additional message-specific information.</param>
    /// <returns>The return value specifies the result of the message processing; it depends on the message sent.</returns>
    [DllImport("user32.dll", EntryPoint = "SendMessageA", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
    private static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

    #endregion

    #region Public Methods

    /// <summary>
    /// Gets the specified <paramref name="selection"/> ordered by its index.
    /// </summary>
    /// <param name="selection">The <see cref="DataGridViewSelectedRowCollection"/> to order.</param>
    /// <returns>The specified <paramref name="selection"/> ordered by its index.</returns>
    public static IEnumerable<DataGridViewRow> OrderByIndex(this DataGridViewSelectedRowCollection selection)
    {
      return selection.Cast<DataGridViewRow>().OrderBy(row => row.Index);
    }

    /// <summary>
    /// Suspens the target <see cref="Control"/> from processing redraw events.
    /// </summary>
    /// <param name="target">The target <see cref="Control"/> to prevent from processing redraw events.</param>
    public static void SuspendDrawing(this Control target)
    {
      SendMessage(target.Handle, WM_SETREDRAW, 0, 0);
    }

    /// <summary>
    /// Resumes the processing of redraw event of the target <see cref="Control"/>.
    /// </summary>
    /// <param name="target">The target <see cref="Control"/> to resume processing redraw events.</param>
    /// <param name="redraw"><c>True</c> to force a redraw of the <see cref="Control"/>, otherwise <c>false</c>.</param>
    public static void ResumeDrawing(this Control target, bool redraw = true)
    {
      SendMessage(target.Handle, WM_SETREDRAW, 1, 0);

      if (redraw)
      {
        target.Refresh();
      }
    }

    /// <summary>
    /// Copies the given <paramref name="text"/> to the <see cref="Clipboard"/>.
    /// </summary>
    /// <param name="source">The <see cref="Control"/> that call this method.</param>
    /// <param name="text">The text to copy to the <see cref="Clipboard"/>.</param>
    public static void CopyToClipboard(this Control source, string text)
    {
      Cursor currentCursor = source.Cursor;
      
      try
      {
        source.Cursor = Cursors.WaitCursor;

        if (!string.IsNullOrEmpty(text))
        {
          Clipboard.SetText(text);
        }
      }
      finally
      {
        source.Cursor = currentCursor;
      }
    }

    /// <summary>
    /// Adjusts the <see cref="TextBox"/> height to match the content.
    /// </summary>
    /// <param name="txtBox">The <see cref="TextBox"/> to adjust the height of.</param>
    public static void AdjustHeightToContent(this TextBox txtBox)
    {
      if (txtBox != null && txtBox.IsHandleCreated && txtBox.ClientSize.Width > 1)
      {
        txtBox.Height = (txtBox.Font.Height) * SendMessage(txtBox.Handle
          , EM_GETLINECOUNT
          , 0
          , 0) + txtBox.Margin.Bottom;
      }
    }

    /// <summary>
    /// Converts the given <paramref name="baseValue"/> to a CSV compatible string.
    /// </summary>
    /// <param name="baseValue">The <see cref="IComparable"/> type to convert to be CSV compatible.</param>
    /// <returns>A CSV compatible string.</returns>
    public static string ToCsv(this IComparable baseValue)
    {
      return baseValue.ToString().Replace("\"", "\"\"");
    }

    /// <summary>
    /// Gets the full logging path of the <paramref name="node"/>.
    /// </summary>
    /// <param name="node">The <see cref="TreeNode"/> to get the full path of.</param>
    /// <returns>The full path of the given <paramref name="node"/>.</returns>
    public static string GetLoggerPath(this TreeNode node)
    {
      return node.FullPath.Replace(
          Properties.Resources.strLoggerRoot + node.TreeView.PathSeparator
        , string.Empty);
    }

    /// <summary>
    /// Converts a wildcard to a <see cref="Regex"/>.
    /// </summary>
    /// <param name="pattern">The wildcard pattern to convert.</param>
    /// <returns>A <see cref="Regex"/> equivalent of the given wildcard <paramref name="pattern"/>.</returns>
    public static string ToRegex(this string pattern)
    {
      if (string.IsNullOrEmpty(pattern))
      {
        return string.Empty;
      }

      return Regex.Escape(pattern).
        Replace("\\*", ".*").
        Replace("\\?", ".");
    }

    /// <summary>
    /// Converts a string value to a shorten path string like 'C:\...\file.dat'.
    /// </summary>
    /// <param name="path">The path string to shorten.</param>
    /// <param name="font">The <see cref="Font"/> used to calculate the string length.</param>
    /// <param name="maxWidth">The optional maximum with for the shorten string.</param>
    /// <returns>the shorten string or an empty one on error.</returns>
    public static string ToShortPath(this string path, Font font, int maxWidth = 200)
    {
      if (string.IsNullOrEmpty(path))
      {
        return string.Empty;
      }

      // Copy the original string to prevent accidental modifying it.
      string shortenPath = string.Copy(path);

      // Let the .NET framework do the work!
      TextRenderer.MeasureText(
          shortenPath
        , font
        , new Size(maxWidth, 0)
        ,   TextFormatFlags.PathEllipsis 
          | TextFormatFlags.ModifyString);

        int cutOffIndex = shortenPath.IndexOf('\0');

        return cutOffIndex > 0 
            ? shortenPath.Remove(cutOffIndex) 
            : shortenPath;
    }

    /// <summary>
    /// Saves the given <see cref="ApplicationSettingsBase"/> data without raising an <see cref="Exception"/>.
    /// </summary>
    /// <param name="settingsBase">The <see cref="ApplicationSettingsBase"/> instance to save.</param>
    /// <returns><c>True</c> on success, otherwise <c>false</c>.</returns>
    public static bool SaveSettings(this ApplicationSettingsBase settingsBase)
    {
      if (settingsBase == null)
      {
        return false;
      }

      try
      {
        settingsBase.Save();
      }
      catch
      {
        return false;
      }


      return true;
    }

    /// <summary>
    /// Connects the given <paramref name="pipeClientStream"/> object and write the given <paramref name="message"/> into it.
    /// </summary>
    /// <param name="pipeClientStream">The <see cref="NamedPipeClientStream"/> to connect and write to.</param>
    /// <param name="message">The message to write into the <see cref="NamedPipeClientStream"/> object.</param>
    /// <param name="timeout">The timeout in milliseconds for the client connection.</param>
    public static bool ConnectAndWrite(this NamedPipeClientStream pipeClientStream, byte[] message, int timeout = 1000)
    {
      if (message != null && message.Length > 0)
      {
        try
        {
          pipeClientStream.Connect(timeout);

          pipeClientStream.Write(
              message
            , 0
            , message.Length);

          return true;
        }
        catch (Exception ex)
        {
          Logger.Error(ex.Message);
        }
      }

      return false;
    }

    /// <summary>
    /// Converts the <see cref="DateTime"/> value into a unix timestamp.
    /// </summary>
    /// <param name="date">The <see cref="DateTime"/> object to convert the value from.</param>
    /// <returns>The unix timestamp of the given <see cref="DateTime"/> value.</returns>
    public static long ToUnixTimestamp(this DateTime date)
    {
      long unixTimestamp = date.Ticks - new DateTime(
          1970
        , 1
        , 1).Ticks;

      unixTimestamp /= TimeSpan.TicksPerSecond;
      
      return unixTimestamp;
    }
    
    /// <summary>
    /// Determines whether the vertical <see cref="Scrollbar"/> of the specified <paramref name="ctrl"/> is visible or not.
    /// </summary>
    /// <param name="ctrl">the <see cref="Control"/> to check if it vertical <see cref="Scrollbar"/> is visible.</param>
    /// <returns><c>True</c> if the vertical <see cref="Scrollbar"/> of the <see cref="Control"/> is visible; otherwise <c>false</c>.</returns>
    public static bool IsVerticalScrollbarvisible(this Control ctrl)
    {
      return ((Win32.GetWindowLong(ctrl.Handle, Win32.GWL_STYLE) & Win32.WS_VSCROLL) != 0);
    }

    #endregion
  }
}
