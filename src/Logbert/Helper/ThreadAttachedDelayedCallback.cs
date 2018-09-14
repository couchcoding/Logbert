#region Copyright © 2015 Couchcoding

// File:    ThreadAttachedDelayedCallback.cs
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
using System.Runtime.InteropServices;

using Couchcoding.Logbert.Interfaces;

namespace Couchcoding.Logbert.Helper
{
	/// <summary>
	/// Base class for StDelayedCallback classes that require ThreadInput from the Main thread
	/// 
	/// This class is a client of itself in that it implements the IDelayedCallbackHandler interface.
	/// </summary>
	public class ThreadAttachedDelayedCallback : DelayedCallback, IDelayedCallbackHandler
	{
		#region Private Fields

		/// <summary>
		/// GUI Thread Id 
		/// </summary>
		private readonly uint mMainThreadId;

		/// <summary>
		/// Callback Thread Id
		/// </summary>
		private uint mCllbackThreadId;
		
    #endregion

		#region External Methods

    /// <summary>
    /// Attaches or detaches the input processing mechanism of one thread to that of another thread.
    /// </summary>
    /// <param name="attachTo">The identifier of the thread to be attached to another thread.</param>
    /// <param name="attachFrom">The identifier of the thread to which idAttach will be attached.</param>
    /// <param name="attach">If this parameter is <c>true</c>, the two threads are attached. If the parameter is <c>false</c>, the threads are detached.</param>
    /// <returns>If the function succeeds, the return value is nonzero.</returns>
		[DllImport("USER32.DLL")]
		private static extern uint AttachThreadInput(uint attachTo, uint attachFrom, bool attach);

    /// <summary>
    /// Retrieves the thread identifier of the calling thread.
    /// </summary>
    /// <returns>The return value is the thread identifier of the calling thread.</returns>
		[DllImport("KERNEL32.DLL")]
		private static extern uint GetCurrentThreadId();

		#endregion

		#region Public Methods

		/// <summary>
		/// Start.Called when the Delay has expired and operation is to begin.
		/// This implementation attaches this Thread to the Main Thread's Input.
		/// </summary>
		public virtual void Start()
		{
			// Start is called in a new Thread, grab the new Thread Id so we can attach to Main thread's input
			mCllbackThreadId = GetCurrentThreadId();

			AttachThreadInput(
          mCllbackThreadId
        , mMainThreadId
        , true);
		}

		/// <summary>
		/// Finish.Called when the operation is to finish (usually IDispose)
		/// This implementation detaches this Thread from the Main Thread's Input.
		/// </summary>
		public virtual void Finish()
		{
			// Detach from Main thread input
			AttachThreadInput(
          mCllbackThreadId
        , mMainThreadId
        , false);
		}

		#endregion

    #region Constructor

		/// <summary>
		/// Member Initialising Constructor.
		/// </summary>
		/// <param name="delay">Delay to wait for</param>
		/// <param name="enabled">Enabled or not</param>
		public ThreadAttachedDelayedCallback(TimeSpan delay, bool enabled)
		{
			// Constructor is called from (what is treated as) the Main thread, grab its Thread Id
			mMainThreadId = GetCurrentThreadId();

			Init(this
        , delay
        , enabled);
		}

		/// <summary>
		/// Member Initialising Constructor.
		/// </summary>
		/// <param name="delay">Delay to wait for</param>
		public ThreadAttachedDelayedCallback(TimeSpan delay) : this(delay, true)
		{

		}

		#endregion
	}
}
