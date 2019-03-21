#region Copyright © 2015 Couchcoding

// File:    Log4NetUdpReceiverSettings.cs
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
using System.Net;
using System.Net.NetworkInformation;
using System.Windows.Forms;

using Couchcoding.Logbert.Interfaces;
using Couchcoding.Logbert.Properties;
using System.Net.Sockets;
using System.Text;

using Couchcoding.Logbert.Helper;

namespace Couchcoding.Logbert.Receiver.Log4NetUdpReceiver
{
  /// <summary>
  /// Implements the <see cref="ILogSettingsCtrl"/> control for the Log4Net UDP receiver.
  /// </summary>
  public partial class Log4NetUdpReceiverSettings : UserControl, ILogSettingsCtrl
  {
    #region Private Types

    /// <summary>
    /// Type to warp <see cref="NetworkInterface"/>s.
    /// </summary>
    public class NetworkInterfaceWrapper
    {
      #region Public Properties

      /// <summary>
      /// Gets or sets the wrapped <see cref="NetworkInterface"/>.
      /// </summary>
      public NetworkInterface Adapter
      {
        get;
        private set;
      }

      #endregion

      #region Public Methods

      /// <summary>
      /// Returns the fully qualified type name of this instance.
      /// </summary>
      /// <returns>A <see cref="T:System.String"/> containing a fully qualified type name.</returns>
      public override string ToString()
      {
        return Adapter != null
          ? Adapter.Name
          : string.Empty;
      }

      #endregion

      #region Constructor

      /// <summary>
      /// Creates a new instance of the <see cref="NetworkInterfaceWrapper"/> type.
      /// </summary>
      /// <param name="adapter">The <see cref="NetworkInterface"/> to encapsulate.</param>
      public NetworkInterfaceWrapper(NetworkInterface adapter)
      {
        Adapter = adapter;
      }

      #endregion
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Gets all available network interfaces and adds them to the <see cref="ComboBox"/>.
    /// </summary>
    private void EnumerateAndAddNetworkInterfaces()
    {
      NetworkInterface[] adapters = null;

      try
      {
        adapters = NetworkInterface.GetAllNetworkInterfaces();
      }
      catch
      {
        cmbNetworkInterface.SelectedItem = null;
        cmbNetworkInterface.Enabled      = false;
        nudPort.Enabled                  = false;
      }

      if (adapters != null && adapters.Length > 0)
      {
        // Add all found netwoek interfaces to the combo box.
        foreach (NetworkInterface adapter in adapters)
        {
          // Add only 'working' network interfaces.
          if (adapter.OperationalStatus != OperationalStatus.Up
          || !adapter.SupportsMulticast)
          {
            continue;
          }

          cmbNetworkInterface.Items.Add(new NetworkInterfaceWrapper(adapter));
        }

        if (cmbNetworkInterface.Items.Count > 0)
        {
          // Select the very first found network interface.
          cmbNetworkInterface.SelectedIndex = 0;
        }
        else
        {
          cmbNetworkInterface.SelectedItem = null;
          cmbNetworkInterface.Enabled      = false;
          nudPort.Enabled                  = false;
        }
      }
      else
      {
        cmbNetworkInterface.SelectedItem = null;
        cmbNetworkInterface.Enabled      = false;
        nudPort.Enabled                  = false;
      }
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the network interface <see cref="ComboBox"/>.
    /// </summary>
    private void CmbNetworkInterfaceSelectedIndexChanged(object sender, EventArgs e)
    {
      NetworkInterfaceWrapper adapter = cmbNetworkInterface.SelectedItem as NetworkInterfaceWrapper;

      if (adapter != null)
      {
        IPInterfaceProperties ipInfo = adapter.Adapter.GetIPProperties();

        if (ipInfo != null)
        {
          nfoPanel.Text = string.Format(
              Resources.strLog4NetUdpReceiverNetworkDescription
            , '\t'
            , adapter.Adapter.Description
            , Environment.NewLine);

          foreach (UnicastIPAddressInformation ipAddress in ipInfo.UnicastAddresses)
          {
            if (ipAddress.Address != null && ipAddress.Address.AddressFamily == AddressFamily.InterNetwork)
            {
              nfoPanel.Text += string.Format(
                  Resources.strLog4NetUdpReceiverNetworkIPAddress
                , '\t'
                , ipAddress.Address
                , Environment.NewLine);

              break;
            }
          }

          nfoPanel.Text += string.Format(
              Resources.strLog4NetUdpReceiverNetworkSpeed
            , '\t'
            , adapter.Adapter.Speed / 1024 / 1024
            , Environment.NewLine);
        }
      }
    }

    /// <summary>
    /// Handles the CheckedChanged event of the join multicast group <see cref="CheckBox"/>.
    /// </summary>
    private void ChkMulticastGroupCheckedChanged(object sender, EventArgs e)
    {
      txtMulticastIp.Enabled = chkMulticastGroup.Checked;

      if (txtMulticastIp.Enabled)
      {
        txtMulticastIp.Select();
      }
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.UserControl.Load"/> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data. </param>
    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      if (ModifierKeys != Keys.Shift)
      {
        if (!string.IsNullOrEmpty(Settings.Default.PnlLog4NetUdpSettingsInterface))
        {
          foreach (NetworkInterfaceWrapper netInterface in cmbNetworkInterface.Items)
          {
            if (Equals(netInterface.ToString(), Settings.Default.PnlLog4NetUdpSettingsInterface))
            {
              cmbNetworkInterface.SelectedItem = netInterface;
              break;
            }
          }
        }

        nudPort.Value             = Settings.Default.PnlLog4NetUdpSettingsPort;
        txtMulticastIp.Text       = Settings.Default.PnlLog4NetUdpSettingsMulticastAddress;
        chkMulticastGroup.Checked = Settings.Default.PnlLog4NetUdpSettingsJoinMulticast;
      }

      foreach (EncodingInfo encoding in Encoding.GetEncodings())
      {
        EncodingWrapper encWrapper = new EncodingWrapper(encoding);

        cmbEncoding.Items.Add(encWrapper);

        if (encoding.CodePage == (ModifierKeys != Keys.Shift ? Settings.Default.PnlLog4NetUdpSettingsEncoding : Encoding.Default.CodePage))
        {
          cmbEncoding.SelectedItem = encWrapper;
        }
      }

      if (cmbEncoding.SelectedItem == null)
      {
        cmbEncoding.SelectedIndex = 0;
      }
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Validates the entered settings.
    /// </summary>
    /// <returns>The <see cref="ValidationResult"/> of the validation.</returns>
    public ValidationResult ValidateSettings()
    {
      if (cmbNetworkInterface.SelectedItem == null)
      {
        return ValidationResult.Error(Resources.strLog4NetUdpReceiverNoNetworkInterfaceAvailable);
      }

      if (chkMulticastGroup.Checked)
      {
        IPAddress parsedMulticastAddress;

        if (!IPAddress.TryParse(txtMulticastIp.Text, out parsedMulticastAddress))
        {
          txtMulticastIp.Select();

          return ValidationResult.Error(Resources.strLog4NetUdpReceiverInvalidIpAddress);
        }
      }

      return ValidationResult.Success;
    }

    /// <summary>
    /// Creates and returns a fully configured <see cref="ILogProvider"/> instance.
    /// </summary>
    /// <returns>A fully configured <see cref="ILogProvider"/> instance.</returns>
    public ILogProvider GetConfiguredInstance()
    {
      NetworkInterfaceWrapper adapter = cmbNetworkInterface.SelectedItem as NetworkInterfaceWrapper;

      if (adapter != null)
      {
        IPInterfaceProperties ipInfo = adapter.Adapter.GetIPProperties();

        if (ipInfo != null)
        {
          foreach (UnicastIPAddressInformation ipAddress in ipInfo.UnicastAddresses)
          {
            if (ipAddress.Address != null && ipAddress.Address.AddressFamily == AddressFamily.InterNetwork)
            {
              if (ModifierKeys != Keys.Shift)
              {
                // Save the current settings as new default values.
                Settings.Default.PnlLog4NetUdpSettingsInterface        = cmbNetworkInterface.SelectedItem.ToString();
                Settings.Default.PnlLog4NetUdpSettingsPort             = (int)nudPort.Value;
                Settings.Default.PnlLog4NetUdpSettingsJoinMulticast    = chkMulticastGroup.Checked;
                Settings.Default.PnlLog4NetUdpSettingsMulticastAddress = txtMulticastIp.Text;
                Settings.Default.PnlLog4NetUdpSettingsEncoding         = ((EncodingWrapper)cmbEncoding.SelectedItem).Codepage;

                Settings.Default.SaveSettings();
              }

              return new Log4NetUdpReceiver(chkMulticastGroup.Checked 
                  ? IPAddress.Parse(txtMulticastIp.Text.Trim()) 
                  : null
                , new IPEndPoint(ipAddress.Address, (int)nudPort.Value)
                , Settings.Default.PnlLog4NetUdpSettingsEncoding);
            }
          }
        }
      }

      return null;
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Creates a new instance of the <see cref="Log4NetUdpReceiverSettings"/> <see cref="Control"/>.
    /// </summary>
    public Log4NetUdpReceiverSettings()
    {
      InitializeComponent();
      
      // Initialize the controls.
      EnumerateAndAddNetworkInterfaces();
    }

    #endregion
  }
}
