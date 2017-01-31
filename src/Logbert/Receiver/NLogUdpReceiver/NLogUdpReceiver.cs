#region Copyright © 2015 Couchcoding

// File:    NLogUdpReceiver.cs
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
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

using Com.Couchcoding.Logbert.Interfaces;

using Com.Couchcoding.Logbert.Controls;
using Com.Couchcoding.Logbert.Helper;
using Com.Couchcoding.Logbert.Logging;

namespace Com.Couchcoding.Logbert.Receiver.NLogUdpReceiver
{
  /// <summary>
  /// Implements a <see cref="ILogProvider"/> for the NLog UDP service.
  /// </summary>
  public class NLogUdpReceiver : ReceiverBase
  {
    #region Private Fields

    /// <summary>
    /// Holds the port to listen on.
    /// </summary>
    private readonly int mPort;

    /// <summary>
    /// The network interface to listen on.
    /// </summary>
    private readonly IPEndPoint mListenInterface;

    /// <summary>
    /// The <see cref="UdpClient"/> to reveive <see cref="LogMessage"/>s from.
    /// </summary>
    private UdpClient mUdpClient;

    /// <summary>
    /// Counts the received messages;
    /// </summary>
    private int mLogNumber;

    #endregion

    #region Private Types

    /// <summary>
    /// Implements a state object for UDP communication.
    /// </summary>
    private class UdpState
    {
      #region Public Properties

      /// <summary>
      /// Gets the <see cref="UdpClient"/> that will receive messages.
      /// </summary>
      internal UdpClient Client
      {
        get;
        private set;
      }

      /// <summary>
      /// Gets the <see cref="IPEndPoint"/> to listen on.
      /// </summary>
      internal IPEndPoint EndPoint
      {
        get;
        private set;
      }

      #endregion

      #region Constructor

      /// <summary>
      /// Creates a new instance of the <see cref="UdpState"/> type.
      /// </summary>
      /// <param name="client">The <see cref="UdpClient"/> that will receive messages.</param>
      /// <param name="endPoint">The <see cref="IPEndPoint"/> to listen on.</param>
      internal UdpState(UdpClient client, IPEndPoint endPoint)
      {
        Client   = client;
        EndPoint = endPoint;
      }

      #endregion
    }

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets the name of the <see cref="ILogProvider"/>.
    /// </summary>
    public override string Name
    {
      get
      {
        return "NLog UDP Receiver";
      }
    }

    /// <summary>
    /// Gets the description of the <see cref="ILogProvider"/>
    /// </summary>
    public override string Description
    {
      get
      {
        return string.Format(
            "{0} (Port: {1})"
          , Name
          , mListenInterface.Port);
      }
    }

    /// <summary>
    /// Gets the filename for export of the received <see cref="LogMessage"/>s.
    /// </summary>
    public override string ExportFileName
    {
      get
      {
        return string.Format(
            "{0} (Port {1})"
          , Name
          , mListenInterface.Port);
      }
    }

    /// <summary>
    /// Gets the settings <see cref="Control"/> of the <see cref="ILogProvider"/>.
    /// </summary>
    public override ILogSettingsCtrl Settings
    {
      get
      {
        return new NLogUdpReceiverSettings();
      }
    }

    /// <summary>
    /// Gets the columns to display of the <see cref="ILogProvider"/>.
    /// </summary>
    public override Dictionary<int, string> Columns
    {
      get
      {
        return new Dictionary<int, string>
        {
          { 0, "Number"    },
          { 1, "Level"     },
          { 2, "Timestamp" },
          { 3, "Logger"    },
          { 4, "Thread"    },
          { 5, "Message"   },
        };
      }
    }

    /// <summary>
    /// Determines whether this <see cref="ILogProvider"/> supports reloading of the content, ot not.
    /// </summary>
    public override bool SupportsReload
    {
      get
      {
        return false;
      }
    }

    /// <summary>
    /// Get the <see cref="Control"/> to display details about a selected <see cref="LogMessage"/>.
    /// </summary>
    public override ILogPresenter DetailsControl
    {
      get
      {
        return new Log4NetDetailsControl();
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

    #region Private Methods

    /// <summary>
    /// Handles the received UDP message event.
    /// </summary>
    /// <param name="ar">The <see cref="IAsyncResult"/> object that contains necessary meta data.</param>
    private void ReceiveUdpMessage(IAsyncResult ar)
    {
      UdpClient client = ((UdpState)ar.AsyncState).Client;

      IPEndPoint wantedIpEndPoint   = ((UdpState)(ar.AsyncState)).EndPoint;
      IPEndPoint receivedIpEndPoint = new IPEndPoint(IPAddress.Any, 0);

      Byte[] receiveBytes;

      try
      {
        receiveBytes = client.EndReceive(
            ar
          , ref receivedIpEndPoint);
      }
      catch (ObjectDisposedException)
      {
        // The socket seems to be already closed.
        return;
      }

      bool isRightHost = (wantedIpEndPoint.Address.Equals(receivedIpEndPoint.Address)) 
                       || wantedIpEndPoint.Address.Equals(IPAddress.Any);

      if (isRightHost && receiveBytes != null)
      {
        try
        {
          LogMessage newLogMsg = new LogMessageLog4Net(
              Encoding.ASCII.GetString(receiveBytes)
            , ++mLogNumber);

          if (mLogHandler != null)
          {
            mLogHandler.HandleMessage(newLogMsg);
          }
        }
        catch (Exception ex)
        {
          Logger.Warn(ex.Message);
        }
      }

      client.BeginReceive(ReceiveUdpMessage, ar.AsyncState);
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString()
    {
      return Name;
    }

    /// <summary>
    /// Intizializes the <see cref="ILogProvider"/>.
    /// </summary>
    /// <param name="logHandler">The <see cref="ILogHandler"/> that may handle incomming <see cref="LogMessage"/>s.</param>
    public override void Initialize(ILogHandler logHandler)
    {
      base.Initialize(logHandler);

      try
      {
        mUdpClient     = new UdpClient(mPort);
        UdpState state = new UdpState(mUdpClient, mListenInterface);

        mUdpClient.BeginReceive(
            ReceiveUdpMessage
          , state);
      }
      catch (Exception ex)
      {
        Logger.Warn(ex.Message);
      }
    }

    /// <summary>
    /// Shuts down the <see cref="ILogProvider"/> instance.
    /// </summary>
    public override void Shutdown()
    {
      if (mUdpClient != null)
      {
        mUdpClient.Close();
        mUdpClient = null;
      }

      base.Shutdown();
    }

    /// <summary>
    /// Gets the header used for the CSV file export.
    /// </summary>
    /// <returns></returns>
    public override string GetCsvHeader()
    {
      return "\"Number\","
           + "\"Level\","
           + "\"Timestamp\","
           + "\"Logger\","
           + "\"Thread\","
           + "\"Message\","
           + "\"Location\","
           + "\"Custom Data\""
           + Environment.NewLine;
    }

    /// <summary>
    /// Resets the <see cref="ILogProvider"/> instance.
    /// </summary>
    public override void Clear()
    {
      mLogNumber = 0;
    }

    /// <summary>
    /// Saves the current docking layout of the <see cref="ReceiverBase"/> instance.
    /// </summary>
    /// <param name="layout">The layout as string to save.</param>
    public override void SaveLayout(string layout)
    {
      Properties.Settings.Default.DockLayoutNLogUdpReceiver = layout ?? string.Empty;
      Properties.Settings.Default.SaveSettings();
    }

    /// <summary>
    /// Loads the docking layout of the <see cref="ReceiverBase"/> instance.
    /// </summary>
    /// <returns>The restored layout, or <c>null</c> if none exists.</returns>
    public override string LoadLayout()
    {
      return Properties.Settings.Default.DockLayoutNLogUdpReceiver;
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Creates a new and empty instance of the <see cref="NLogUdpReceiver"/> class.
    /// </summary>
    public NLogUdpReceiver()
    {

    }

    /// <summary>
    /// Creates a new and configured instance of the <see cref="NLogUdpReceiver"/> class.
    /// </summary>
    /// <param name="port">The port to listen on for new <see cref="LogMessage"/>s</param>
    /// <param name="listenInterface">The network interface to listen on.</param>
    public NLogUdpReceiver(int port, IPEndPoint listenInterface)
    {
      mPort            = port;
      mListenInterface = listenInterface;
    }

    #endregion
  }
}
