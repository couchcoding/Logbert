#region Copyright © 2021 Couchcoding

// File:    CustomFileReceiver.cs
// Package: Logbert
// Project: Logbert
// 
// The MIT License (MIT)
// 
// Copyright (c) 2021 Couchcoding
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

using Couchcoding.Logbert.Controls;
using Couchcoding.Logbert.Helper;
using Couchcoding.Logbert.Interfaces;
using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.ComponentModel;
using System.Net;
using System.Linq;
using Couchcoding.Logbert.Logging;
using System.Threading;

namespace Couchcoding.Logbert.Receiver.CustomReceiver.CustomHttpReceiver
{
  /// <summary>
  /// Implements a <see cref="ILogProvider"/> for the custom log http service.
  /// </summary>
  class CustomHttpReceiver : ReceiverBase
  {
    #region Private Fields

    /// <summary>
    /// The linked <see cref="Columnizer"/> instance.
    /// </summary>
    private readonly Columnizer mColumnizer;

    /// <summary>
    /// The <see cref="HttpClient"/> to recieve data.
    /// </summary>
    private HttpClient mHttpClient;

    /// <summary>
    /// Counts the received messages.
    /// </summary>
    private int mLogNumber;

    /// <summary>
    /// Holds the <see cref="BasicHttpAuthentication"/> instance if necessary to authenticate.
    /// </summary>
    private readonly BasicHttpAuthentication mAuthentication;

    /// <summary>
    /// The URL to receive data from.
    /// </summary>
    private readonly string mUrl;

    /// <summary>
    /// The polling time in seconds.
    /// </summary>
    private readonly int mPollTime = 5;

    /// <summary>
    /// Holds the last received by position that is loaded.
    /// </summary>
    private long mLastOffset = 0;

    /// <summary>
    /// Simple <see cref="Object"/> for thread synchronization.
    /// </summary>
    private static readonly object lastOffsetLock = new object();

    /// <summary>
    /// Delegate used to start the asynchronous Lua <see cref="Script"/> execution.
    /// </summary>
    /// <param name="luaCode">The Lua <see cref="Script"/> to execute.</param>
    private delegate void StartHttpFileListeningDelegate(HttpClient client, string url);

    private volatile bool mConnected;

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets the name of the <see cref="ILogProvider"/>.
    /// </summary>
    public override string Name => "Custom HTTP Receiver";

    /// <summary>
    /// Gets the description of the <see cref="ILogProvider"/>
    /// </summary>
    public override string Description => $"{Name} ({mUrl})";

    /// <summary>
    /// Gets the filename for export of the received <see cref="LogMessage"/>s.
    /// </summary>
    public override string ExportFileName => $"{Name} ({mUrl})";

    /// <summary>
    /// Gets the settings <see cref="Control"/> of the <see cref="ILogProvider"/>.
    /// </summary>
    public override ILogSettingsCtrl Settings => new CustomHttpReceiverSettings();

    /// <summary>
    /// Determines whether this <see cref="ILogProvider"/> supports the logger tree window.
    /// </summary>
    public override bool HasLoggerTree => false;

    /// <summary>
    /// Gets the columns to display of the <see cref="ILogProvider"/>.
    /// </summary>
    public override Dictionary<int, LogColumnData> Columns
    {
      get
      {
        Dictionary<int, LogColumnData> clmDict = new Dictionary<int, LogColumnData>
        {
          { 0, new LogColumnData("Number") }
        };

        foreach (LogColumn lgclm in mColumnizer.Columns)
        {
          clmDict.Add(clmDict.Count, new LogColumnData(
            lgclm.Name
          , true
          , lgclm.ColumnType == LogColumnType.Message ? 1024 : 100));
        }

        return clmDict;
      }
    }

    /// <summary>
    /// Get the <see cref="Control"/> to display details about a selected <see cref="LogMessage"/>.
    /// </summary>
    public override ILogPresenter DetailsControl
    {
      get
      {
        return new CustomDetailsControl(mColumnizer);
      }
    }

    /// <summary>
    /// Gets or sets the active state if the <see cref="ILogProvider"/>.
    /// </summary>
    public override bool IsActive
    {
      get
      {
        return base.IsActive;
      }
      set
      {
        base.IsActive = value;

        if (!mIsActive)
        {
          Shutdown();
        }
        else
        {
          Initialize(mLogHandler);
        }
      }
    }

    #endregion

    #region Private Properties

    /// <summary>
    /// Gets or set the last received line number.
    /// </summary>
    private long LastOffset
    {
      get
      {
        lock (lastOffsetLock)
        {
          return mLastOffset;
        }
      }
      set
      {
        lock (lastOffsetLock)
        {
          mLastOffset = value;
        }
      }
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Intizializes the <see cref="ILogProvider"/>.
    /// </summary>
    /// <param name="logHandler">The <see cref="ILogHandler"/> that may handle incoming <see cref="LogMessage"/>s.</param>
    public override void Initialize(ILogHandler logHandler)
    {
      base.Initialize(logHandler);

      if (mHttpClient == null || !mConnected)
      {
        mHttpClient         = new HttpClient();
        mHttpClient.Timeout = new TimeSpan(0, 0, Properties.Settings.Default.PnlCustomHttpSettingsTimeout);

      }

      StartHttpFileListeningDelegate worker = HttpFileListeningWorker;
      AsyncCallback completedCallback       = HttpFileListeningCallback;

      mConnected = true;
      
      worker.BeginInvoke(
        mHttpClient
      , mUrl
      , completedCallback
      , AsyncOperationManager.CreateOperation(null));
    }

    /// <summary>
    /// Worker thread to recieved new log messges.
    /// </summary>
    /// <param name="client">The <see cref="HttpClient"/> instance to listen for file size changes.</param>
    /// <param name="url">The base URL to receive message from.</param>
    private void HttpFileListeningWorker(HttpClient client, string url)
    {
      if (!mConnected)
      {
        return;
      }
      
      if (mAuthentication != null)
      {
        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(
          mAuthentication.AuthenticationType
        , mAuthentication.GetToken());
      }

      while (mConnected)
      {
        LastOffset = Download(client, url);
        var lastRequestTime = DateTime.Now;

        do
        {
          Thread.Sleep(1);
        } while (mConnected && lastRequestTime.AddSeconds(mPollTime) > DateTime.Now);
      }
    }

    /// <summary>
    /// Downloads new messages from the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="client">The <see cref="HttpClient"/> to use to download messages.</param>
    /// <param name="url">The URL to download messages from.</param>
    /// <returns>The entire count of received lines.</returns>
    private long Download(HttpClient client, string url)
    {
      HttpResponseMessage result = null;

      try
      {
        result = client.GetAsync(url).Result;
      }
      catch (Exception ex)
      {
        mLogHandler?.HandleError(LogError.Error($"Connection closed unexpected: {(ex.InnerException != null ? ex.InnerException.Message : ex.Message)}"));
        Shutdown();
        return LastOffset;
      }

      if (result == null)
      {
        mLogHandler?.HandleError(LogError.Error($"Received unexpected result. Please try to restart the log handler."));
        return LastOffset;
      }

      switch (result.StatusCode)
      {
        case HttpStatusCode.OK:
        case HttpStatusCode.PartialContent:
          {
            var contentLength = int.Parse(result.Content.Headers.GetValues("Content-Length").FirstOrDefault());

            if (contentLength > LastOffset)
            {
              using (var downloadClient = new HttpClient())
              {
                downloadClient.DefaultRequestHeaders.Authorization = client.DefaultRequestHeaders.Authorization;

                if (LastOffset > 0)
                {
                  downloadClient.DefaultRequestHeaders.Range = new System.Net.Http.Headers.RangeHeaderValue(
                      contentLength - Math.Max(contentLength - LastOffset, 0), contentLength);
                }

                List<LogMessage> receivedLogMessages = new List<LogMessage>();

                string downloadedData = mEncoding.GetString(downloadClient.GetByteArrayAsync(url).Result);
                string messageLines = string.Empty;

                foreach (string currentLine in downloadedData.Split('\n'))
                {
                  LogMessageCustom cstmLgMsg;

                  if (string.IsNullOrEmpty(currentLine))
                  {
                    continue;
                  }

                  try
                  {
                    messageLines += currentLine;

                    cstmLgMsg = new LogMessageCustom(
                        messageLines
                      , ++mLogNumber
                      , mColumnizer);
                  }
                  catch (Exception ex)
                  {
                    mLogHandler.HandleError(LogError.Warn(ex.Message));
                    continue;
                  }

                  receivedLogMessages.Add(cstmLgMsg);
                  messageLines = string.Empty;
                }

                mLogHandler?.HandleMessage(receivedLogMessages.ToArray());
              }
            }

            return contentLength;
          }

        case HttpStatusCode.Unauthorized:
          {
            mLogHandler?.HandleError(LogError.Error("Login failed. Status Code: " + result.StatusCode));
            Shutdown();
            break;
          }
        default:
          {
            mLogHandler?.HandleError(LogError.Error("Unexpected Status Code: " + result.StatusCode));
            break;
          }
      }

      return LastOffset;
    }

    /// <summary>
    /// Callback of the asynchronous receive thread.
    /// </summary>
    /// <param name="ar"></param>
    private void HttpFileListeningCallback(IAsyncResult ar)
    {
      StartHttpFileListeningDelegate worker =
        (StartHttpFileListeningDelegate)((AsyncResult)ar).AsyncDelegate;

      try
      {
        // Finish the asynchronous operation
        worker.EndInvoke(ar);
      }
      catch
      { 
        
      }
    }

    /// <summary>
    /// Shuts down the <see cref="ILogProvider"/> instance.
    /// </summary>
    public override void Shutdown()
    {
      base.Shutdown();

      try
      {
        mConnected = false;

        mHttpClient?.Dispose();
        mHttpClient = null;
      }
      catch (Exception ex)
      {
        mLogHandler.HandleError(LogError.Error(ex.Message));
      }
    }

    /// <summary>
    /// Resets the <see cref="ILogProvider"/> instance.
    /// </summary>
    public override void Reset()
    {
      LastOffset = 0;
      Initialize(mLogHandler);
    }

    /// <summary>
    /// Gets the header used for the CSV file export.
    /// </summary>
    public override string GetCsvHeader()
    {
      string csvHdr = "\"Number\",";

      foreach (LogColumn lgclm in mColumnizer.Columns)
      {
        csvHdr += "\"" + lgclm.Name.ToCsv() + "\",";
      }

      if (csvHdr.EndsWith(","))
      {
        // Remove the very last comma.
        csvHdr.Remove(csvHdr.Length - 1, 1);
      }

      return csvHdr + Environment.NewLine;
    }

    /// <summary>
    /// Saves the current docking and collumn layout of the <see cref="ILogProvider"/> implementation.
    /// </summary>
    /// <param name="layout">The layout as string to save.</param>
    /// <param name="columnLayout">The current column layout to save.</param>
    public override void SaveLayout(string layout, List<LogColumnData> columnLayout)
    {
      Properties.Settings.Default.DockLayoutCustomHttpReceiver = layout ?? string.Empty;
      Properties.Settings.Default.SaveSettings();
    }

    /// <summary>
    /// Loads the docking layout of the <see cref="ReceiverBase"/> instance.
    /// </summary>
    /// <returns>The restored layout, or <c>null</c> if none exists.</returns>
    public override string LoadLayout()
    {
      return Properties.Settings.Default.DockLayoutCustomHttpReceiver;
    }

    /// <summary>
    /// Resets the <see cref="ILogProvider"/> instance.
    /// </summary>
    public override void Clear()
    {
      mLogNumber = 0;
    }

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString()
    {
      return Name;
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Creates a new and empty instance of the <see cref="CustomTcpReceiver"/> class.
    /// </summary>
    public CustomHttpReceiver()
    {

    }

    /// <summary>
    /// Creates a new and configured instance of the <see cref="NlogTcpReceiver"/> class.
    /// </summary>
    /// <param name="port">The port to listen on for new <see cref="LogMessage"/>s</param>
    /// <param name="listenInterface">The network interface to listen on.</param>
    /// <param name="codePage">The codepage to use for encoding of the data to parse.</param>
    public CustomHttpReceiver(string url, BasicHttpAuthentication authentication, int pollTime, Columnizer columnizer, int codePage) : base(codePage)
    {
      mAuthentication = authentication;
      mUrl            = url;
      mColumnizer     = columnizer;
    }

    #endregion
  }
}
