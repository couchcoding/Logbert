#region Copyright © 2015 Couchcoding

// File:    WaitCursor.cs
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
using System.Windows.Forms;

using Couchcoding.Logbert.Properties;

namespace Couchcoding.Logbert.Helper
{
	/// <summary>
	/// Utility class to make showing (usually) a Wait Cursor much simpler and to remove the
	/// possibility of the Cursor not being restored due to an uncaught exception or forgetfulness to restore
	/// the cursor manually.
	/// 
	/// 2 Possible uses for this class :-
	/// 
	/// 1.  Single instance usage of the StCursor ..
	/// Instead of
	/// 
	/// public void DoSomeLengthyWork()
	/// {
	///		try
	///		{
	///			Screen.Cursor = Cursors.Wait;
	///			
	///			SlowlyCountToTenBillion();
	///		}
	///		finally
	///		{
	///			Screen.Cursor = Cursors.Default;
	///		}
	/// }
	/// 
	/// do this ..
	/// 
	/// public void DoSomeLengthyWork()
	/// {
	///		using (new WaitCursor(Cursors.Wait, new TimeSpan(0, 0, 0, 0, 100)))
	///		{
	///			SlowlyCountToTenBillion();
	///		}
	/// }
	/// 
	/// Above code will show the Wait cursor after 100ms of 'work'.  
	/// It makes use of the 'using' statement and IDispose to *make sure* the Cursor is always restored 
	/// </summary>
	public class WaitCursor : ThreadAttachedDelayedCallback
	{
		#region Private Fields

    /// <summary>
    /// Remember old cursor.
    /// </summary>
		private readonly Cursor mOldCursor;

		#endregion

		#region Public Methods

	  /// <summary>
    /// Start showing the wait cursor delayed.
    /// </summary>
	  public override void Start()
    {
      base.Start();

      Cursor.Current = Cursors.WaitCursor;
    }

		/// <summary>
		/// Finish showing the Cursor (switch back to previous Cursor)
		/// </summary>
		public override void Finish()
		{
			Cursor.Current = mOldCursor;

			base.Finish();
		}

		#endregion

		#region Constructor

    /// <summary>
    /// Creates a new instance if the <see cref="WaitCursor"/>.
    /// </summary>
    public WaitCursor() : base(new TimeSpan(0, 0, 0, 0, Settings.Default.WaitCursorTimeout))
    {
      mOldCursor = Cursor.Current;
    }

    /// <summary>
    /// Creates a new instance if the <see cref="WaitCursor"/>.
    /// </summary>
    /// <param name="oldCursor">The original <see cref="Cursor"/> to restore aber the operation.</param>
    /// <param name="waitTime">The time in ms to wait before the wait <see cref="Cursor"/> is shown.</param>
    public WaitCursor(Cursor oldCursor, int waitTime) : base(new TimeSpan(0, 0, 0, 0, waitTime))
    {
      mOldCursor = oldCursor;
    }

    /// <summary>
    /// Creates a new instance if the <see cref="WaitCursor"/>.
    /// </summary>
    /// <param name="oldCursor">The original <see cref="Cursor"/> to restore aber the operation.</param>
    public WaitCursor(Cursor oldCursor) : base(new TimeSpan(0, 0, 0, 0, Settings.Default.WaitCursorTimeout))
    {
      mOldCursor = oldCursor;
    }

    /// <summary>
    /// Creates a new instance if the <see cref="WaitCursor"/>.
    /// </summary>
    /// <param name="waitTime">The time in ms to wait before the wait <see cref="Cursor"/> is shown.</param>
    public WaitCursor(int waitTime) : base(new TimeSpan(0, 0, 0, 0, waitTime))
    {
      mOldCursor = Cursor.Current;
    }

		#endregion
	}
}
