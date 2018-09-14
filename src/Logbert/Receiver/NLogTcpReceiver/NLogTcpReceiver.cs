#region Copyright © 2015 Couchcoding

// File:    NlogTcpReceiver.cs
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
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using Couchcoding.Logbert.Interfaces;

using Couchcoding.Logbert.Controls;
using Couchcoding.Logbert.Helper;
using Couchcoding.Logbert.Logging;

namespace Couchcoding.Logbert.Receiver.NlogTcpReceiver
{
  /// <summary>
  /// Implements a <see cref="ILogProvider"/> for the Log4Net UDP service.
  /// </summary>
  public class NlogTcpReceiver : ReceiverBase
  {
    #region Private Consts

    /// <summary>
    /// The buffer size in bytes for received data.
    /// </summary>
    private const int RECEIVE_BUFFER_SIZE = 10240;

    #endregion

    #region Private Fields

    /// <summary>
    /// the <see cref="Socket"/> object to use for listening.
    /// </summary>
    private Socket mSocket;

    /// <summary>
    /// Holds the port to listen on.
    /// </summary>
    private readonly int mPort;

    /// <summary>
    /// The network interface to listen on.
    /// </summary>
    private readonly IPEndPoint mListenInterface;

    /// <summary>
    /// Counts the received messages;
    /// </summary>
    private int mLogNumber;

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets the name of the <see cref="ILogProvider"/>.
    /// </summary>
    public override string Name
    {
      get
      {
        return "NLog TCP Receiver";
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
        return new NlogTcpReceiverSettings();
      }
    }

    /// <summary>
    /// Gets the columns to display of the <see cref="ILogProvider"/>.
    /// </summary>
    public override Dictionary<int, LogColumnData> Columns
    {
      get
      {
        string[] visibleVal = Properties.Settings.Default.ColumnVisibleNLogTcpReceiver.Split(',');
        string[] widthVal   = Properties.Settings.Default.ColumnWidthNLogTcpReceiver.Split(',');

        return new Dictionary<int, LogColumnData>
        {
          { 0, new LogColumnData("Number",    visibleVal[0] == "1", int.Parse(widthVal[0])) },
          { 1, new LogColumnData("Level",     visibleVal[1] == "1", int.Parse(widthVal[1])) },
          { 2, new LogColumnData("Timestamp", visibleVal[2] == "1", int.Parse(widthVal[2])) },
          { 3, new LogColumnData("Logger",    visibleVal[3] == "1", int.Parse(widthVal[3])) },
          { 4, new LogColumnData("Thread",    visibleVal[4] == "1", int.Parse(widthVal[4])) },
          { 5, new LogColumnData("Message",   visibleVal[5] == "1", int.Parse(widthVal[5])) }
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
    /// Handles the Completed event of the <see cref="SocketAsyncEventArgs"/>.
    /// </summary>
    private void SocketEventCompleted(object sender, SocketAsyncEventArgs e)
    {
      if (mSocket == null || e.SocketError != SocketError.Success)
      {
        return;
      }

      Thread listeningThread = new Thread(Listening)
      {
        IsBackground = true 
      };

      listeningThread.Start(e.AcceptSocket);

      e.AcceptSocket = null;
      mSocket.AcceptAsync(e);
    }

    /// <summary>
    /// Listen for incomming <see cref="LogMessage"/>s.
    /// </summary>
    /// <param name="newSocket">the <see cref="Socket"/> object that may received new data.</param>
    private void Listening(object newSocket)
    {
      try
      {
        using (Socket socket = (Socket)newSocket)
        {
          using (NetworkStream ns = new NetworkStream(socket, FileAccess.Read, false))
          {
            while (mSocket != null)
            {
              try
              {
                byte[]        receivedBytes     = new byte[1024];
                StringBuilder receivedMessage   = new StringBuilder();

                do
                {
                  int receivedByteCount = ns.Read(
                    receivedBytes
                    , 0
                    , receivedBytes.Length);

                  receivedMessage.Append(mEncoding.GetString(
                      receivedBytes
                    , 0
                    , receivedByteCount));
                }
                while(ns.DataAvailable);

                LogMessage newLogMsg = new LogMessageLog4Net(
                    receivedMessage.ToString()
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
          }
        }
      }
      catch (Exception ex)
      {
        Logger.Warn(ex.Message);
      }
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Intizializes the <see cref="ILogProvider"/>.
    /// </summary>
    /// <param name="logHandler">The <see cref="ILogHandler"/> that may handle incomming <see cref="LogMessage"/>s.</param>
    public override void Initialize(ILogHandler logHandler)
    {
      base.Initialize(logHandler);

      try
      {
        mSocket = new Socket(
            AddressFamily.InterNetwork
          , SocketType.Stream
          , ProtocolType.Tcp);

        mSocket.ExclusiveAddressUse = true;
        mSocket.ReceiveBufferSize   = RECEIVE_BUFFER_SIZE;

        mSocket.Bind(new IPEndPoint(
            IPAddress.Any
          , mPort));

        mSocket.Listen(100);

        SocketAsyncEventArgs socketEvent = new SocketAsyncEventArgs();
        socketEvent.Completed += SocketEventCompleted;

        mSocket.AcceptAsync(socketEvent);
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
      if (mSocket != null)
      {
        mSocket.Close();
        mSocket = null;
      }

      base.Shutdown();
    }

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString()
    {
      return Name;
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
    /// Saves the current docking and collumn layout of the <see cref="ILogProvider"/> implementation.
    /// </summary>
    /// <param name="layout">The layout as string to save.</param>
    /// <param name="columnLayout">The current column layout to save.</param>
    public override void SaveLayout(string layout, List<LogColumnData> columnLayout)
    {
      Properties.Settings.Default.DockLayoutNLogTcpReceiver = layout ?? string.Empty;

      Properties.Settings.Default.ColumnVisibleNLogTcpReceiver = string.Format(
          "{0},{1},{2},{3},{4},{5}"
        , columnLayout[0].Visible ? 1 : 0
        , columnLayout[1].Visible ? 1 : 0
        , columnLayout[2].Visible ? 1 : 0
        , columnLayout[3].Visible ? 1 : 0
        , columnLayout[4].Visible ? 1 : 0
        , columnLayout[5].Visible ? 1 : 0);

      Properties.Settings.Default.ColumnWidthNLogTcpReceiver = string.Format(
          "{0},{1},{2},{3},{4},{5}"
        , columnLayout[0].Width
        , columnLayout[1].Width
        , columnLayout[2].Width
        , columnLayout[3].Width
        , columnLayout[4].Width
        , columnLayout[5].Width);

      Properties.Settings.Default.SaveSettings();
    }

    /// <summary>
    /// Loads the docking layout of the <see cref="ReceiverBase"/> instance.
    /// </summary>
    /// <returns>The restored layout, or <c>null</c> if none exists.</returns>
    public override string LoadLayout()
    {
      return Properties.Settings.Default.DockLayoutNLogTcpReceiver;
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Creates a new and empty instance of the <see cref="NlogTcpReceiver"/> class.
    /// </summary>
    public NlogTcpReceiver()
    {

    }

    /// <summary>
    /// Creates a new and configured instance of the <see cref="NlogTcpReceiver"/> class.
    /// </summary>
    /// <param name="port">The port to listen on for new <see cref="LogMessage"/>s</param>
    /// <param name="listenInterface">The network interface to listen on.</param>
    /// <param name="codePage">The codepage to use for encoding of the data to parse.</param>
    public NlogTcpReceiver(int port, IPEndPoint listenInterface, int codePage) : base (codePage)
    {
      mPort            = port;
      mListenInterface = listenInterface;
    }

    #endregion
  }
}
