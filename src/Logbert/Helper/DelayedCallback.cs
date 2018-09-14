#region Copyright © 2015 Couchcoding

// File:    DelayedCallback.cs
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
using System.Threading;

using Couchcoding.Logbert.Interfaces;

namespace Couchcoding.Logbert.Helper
{

	/// <summary>
	/// This class manages a <see cref="IDelayedCallbackHandler"/>.  After a specified delay the 
	/// <see cref="IDelayedCallbackHandler.Start"/> method is called.
	/// If the <see cref="IDelayedCallbackHandler.Start"/> is called then this guarantees that the 
	/// <see cref="IDelayedCallbackHandler.Finish"/> method is called when this instance is Disposed. 
	/// <seealso cref="WaitCursor"/> for an implementation.
	/// </summary>
	public class DelayedCallback : IDisposable
	{
		#region Private Fields

		/// <summary>
		/// The callback
		/// </summary>
		private IDelayedCallbackHandler mCallbackHandler;			

		/// <summary>
		/// Delay to wait before calling back
		/// </summary>
		private TimeSpan mDelay;

		/// <summary>
		/// Thread to perform the wait and callback
		/// </summary>
		private Thread mCallbackThread;		

		/// <summary>
		/// Have we been Disposed or not ?
		/// </summary>
		private bool mDisposed;	
		
		/// <summary>
		/// Has callback Start been called ?
		/// </summary>
		private bool mStartCalled;

		/// <summary>
		/// WaitHandle for notifications
		/// </summary>
		private readonly ManualResetEvent mResetEvent	= new ManualResetEvent(false);
		
		/// <summary>
		/// Enabled or not ?
		/// </summary>
		private bool mEnabled=  true;

		#endregion
		
		#region Public Properties

		/// <summary>
		/// Enable/Disable the call to Start (note, once Start is called it *always* calls the paired Finish)
		/// </summary>
    public bool Enabled
    {
      get
      {
        return mEnabled;
      }
      set
      {
        mEnabled = value;
      }
    }

		/// <summary>
		/// Get/Set the period of Time to wait before calling the Start method
		/// </summary>
    public TimeSpan Delay
    {
      get
      {
        return mDelay;
      }
      set
      {
        mDelay = value;
      }
    }

		#endregion

    #region Private Methods

		/// <summary>
		/// Prepares the class.  Creates the Thread that will call Start & Finish
		/// </summary>
		/// <param name="callbackHandler">The <see cref="IDelayedCallbackHandler"/> instance that is called after the defined <paramref name="delay"/>.-</param>
		/// <param name="delay">The <see cref="TimeSpan"/> after the <paramref name="callbackHandler"/> is called.</param>
		/// <param name="enabled">Enables, or disables the function.</param>
		protected void Init(IDelayedCallbackHandler callbackHandler, TimeSpan delay, bool enabled)
		{
			mCallbackHandler	           = callbackHandler;
			mDelay				               = delay;
			mEnabled			               = enabled;

			mCallbackThread              = new Thread(CallbackThread);
			mCallbackThread.Name         = this.GetType().Name + " DelayedCallback Thread";
			mCallbackThread.IsBackground = true;

			mCallbackThread.Start();
		}

    /// <summary>
		/// Thread method. Loops calling Start & Finish until Disposed, honours the Enabled flag.
		/// </summary>
		private void CallbackThread()
		{
			do
			{
				// Initial State around loop
				mStartCalled = false;

				WaitToStart();

        if (mStartCalled)
        {
          WaitForReset();
        }

			} while (!mDisposed);
		}

		/// <summary>
		/// Waits for either the ResetEvent or the Wait period to expire.  If Wait period expires then Start is called
		/// </summary>
		private void WaitToStart()
		{
			bool waited = mResetEvent.WaitOne(
          mDelay
        , false);

			mResetEvent.Reset();

			if (!waited)
			{
				if (mEnabled)
				{
					try
					{
						mCallbackHandler.Start();
					}
					finally
					{
						mStartCalled = true;
					}
				}
			}
		}

		/// <summary>
		/// Waits for the ResetEvent (set by Dispose & Reset), since Start has been called we *have* to call Finish
		/// </summary>
		private void WaitForReset()
		{
			mResetEvent.WaitOne();
			mResetEvent.Reset();

			// Always calls Finish even if we are Disabled or we Aborted since Start/Finish *always* go in Pairs
			mCallbackHandler.Finish();
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Resets the Wait period to start Waiting again
		/// </summary>
		public void Reset()
		{
			mResetEvent.Set();
		}

		/// <summary>
		/// On Disposal terminates the Thread, calls Finish (on thread) if Start has been called
		/// </summary>
		public void Dispose()
		{
      if (mDisposed)
      {
        return;
      }

			mDisposed = true; // Kills the Thread loop
			mResetEvent.Set();
		}

		#endregion

		#region Constructor

		/// <summary>
		/// Default Constructor.  Hidden.  
		/// </summary>
		protected DelayedCallback()
		{
			// Derived Class MUST call Init in their constructor	
		}

		/// <summary>
		/// Creates a <see cref="DelayedCallback"/> instance prepared with a <see cref="IDelayedCallbackHandler"/> and the specified <see cref="TimeSpan"/> delay
		/// </summary>
		/// <param name="callbackHandler">The CallbackHandler to use</param>
		/// <param name="delay">Initial Delay value</param>
		/// <param name="enabled">Initial Enabled state</param>
		public DelayedCallback(IDelayedCallbackHandler callbackHandler, TimeSpan delay, bool enabled)
		{
			Init(callbackHandler, delay, enabled);
		}

		#endregion
	}
}