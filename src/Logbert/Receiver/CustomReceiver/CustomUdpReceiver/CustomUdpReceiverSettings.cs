#region Copyright © 2018 Couchcoding

// File:    CustomUdpReceiverSettings.cs
// Package: Logbert
// Project: Logbert
// 
// The MIT License (MIT)
// 
// Copyright (c) 2018 Couchcoding
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

using Couchcoding.Logbert.Helper;
using Couchcoding.Logbert.Receiver.CustomReceiver.CustomUdpReceiver;
using Couchcoding.Logbert.Dialogs;
using Couchcoding.Logbert.Receiver.CustomReceiver;
using System.Xml;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace Couchcoding.Logbert.Receiver.Log4NetUdpReceiver
{
  /// <summary>
  /// Implements the <see cref="ILogSettingsCtrl"/> control for the custom UDP receiver.
  /// </summary>
  public partial class CustomUdpReceiverSettings : UserControl, ILogSettingsCtrl
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
    /// Handles the Click event of the add columnizer <see cref="Button"/>.
    /// </summary>
    private void BtnAddColumnizerClick(object sender, EventArgs e)
    {
      using (FrmColumnizer columnizerDlg = new FrmColumnizer())
      {
        if (columnizerDlg.ShowDialog(this) == DialogResult.OK && columnizerDlg.Columnizer != null)
        {
          // Add the new item to the selection list.
          cmbColumnizer.Items.Add(columnizerDlg.Columnizer);

          // Select it a new default.
          cmbColumnizer.SelectedItem = columnizerDlg.Columnizer;

          // Save the changed columnizer list.
          SaveColumnizer();
        }
      }

      UpdateEditButtons();
    }

    /// <summary>
    /// Handles the Click event of the remove columnizer <see cref="Button"/>.
    /// </summary>
    private void BtnRemoveColumnizerClick(object sender, EventArgs e)
    {
      if (cmbColumnizer.SelectedItem != null)
      {
        cmbColumnizer.Items.Remove(cmbColumnizer.SelectedItem);

        if (cmbColumnizer.Items.Count > 0)
        {
          // Select the very first one after an element has been deleted.
          cmbColumnizer.SelectedIndex = 0;
        }

        SaveColumnizer();
      }

      UpdateEditButtons();
    }

    /// <summary>
    /// Handles the Click event of the edit columnizer <see cref="Button"/>.
    /// </summary>
    private void BtnEditColumnizerClick(object sender, EventArgs e)
    {
      using (FrmColumnizer columnizerDlg = new FrmColumnizer(cmbColumnizer.SelectedItem as Columnizer))
      {
        if (columnizerDlg.ShowDialog(this) == DialogResult.OK)
        {
          int changedItemIndex = cmbColumnizer.Items.IndexOf(columnizerDlg.Columnizer);

          if (changedItemIndex != -1)
          {
            cmbColumnizer.Items.RemoveAt(changedItemIndex);

            cmbColumnizer.Items.Insert(
                changedItemIndex
              , columnizerDlg.Columnizer);

            cmbColumnizer.SelectedItem = columnizerDlg.Columnizer;
          }

          // Refresh the possible changed columnizer list in case the name of the selected item has been changed.
          cmbColumnizer.Refresh();

          // Save the changed columnizer list.
          SaveColumnizer();
        }
      }

      UpdateEditButtons();
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
    /// Updates the enabled state of the add, edit and remove columnizer <see cref="Button"/>s.
    /// </summary>
    private void UpdateEditButtons()
    {
      cmbColumnizer.Enabled       = cmbColumnizer.Items.Count > 0;
      btnEditColumnizer.Enabled   = cmbColumnizer.SelectedItem != null;
      btnRemoveColumnizer.Enabled = cmbColumnizer.SelectedItem != null;
    }

    /// <summary>
    /// Loads already existing columnizer from a repository.
    /// </summary>
    /// <returns>An <see cref="Array"/> of loaded <see cref="Columnizer"/>.</returns>
    private static Columnizer[] LoadColumnizer()
    {
      string columnizerRepository = Path.Combine(Environment.GetFolderPath(
          Environment.SpecialFolder.ApplicationData)
        , Application.CompanyName
        , Application.ProductName
        , Settings.Default.ColumnizerRepository);

      if (File.Exists(columnizerRepository))
      {
        List<Columnizer> restoredColumnizer = new List<Columnizer>(); 

        try
        {
          XmlDocument userDefXml = new XmlDocument();

          using (XmlTextReader xmlReader = new XmlTextReader(columnizerRepository))
          {
            userDefXml.Load(xmlReader);
          }

          XmlNode rootNode = userDefXml.SelectSingleNode("CustomColumnizer");

          if (rootNode != null && rootNode.HasChildNodes)
          {
            foreach (XmlNode node in rootNode.ChildNodes)
            {
              Columnizer columnizer = new Columnizer();

              if (columnizer.DeserializeFromXml(node))
              {
                restoredColumnizer.Add(columnizer);
              }
            }
          }

          return restoredColumnizer.ToArray();
        }
        catch (Exception ex)
        {
          Logger.Error(
              "An error occurred while loading custom columnizer: {0}"
            , ex.Message);

          return new Columnizer[0];
        }
      }

      return new Columnizer[0];
    }

    /// <summary>
    /// Saves the spezified <paramref name="columnizerToSerialize"/> into the local repository.
    /// </summary>
    /// <param name="columnizerToSerialize">The <see cref="Columnizer"/> to save.</param>
    private static void SaveColumnizer(List<Columnizer> columnizerToSerialize)
    {
      string columnizerRepository = Path.Combine(Environment.GetFolderPath(
          Environment.SpecialFolder.ApplicationData)
        , Application.CompanyName
        , Application.ProductName
        , Settings.Default.ColumnizerRepository);

      if (!Directory.Exists(Path.GetDirectoryName(columnizerRepository)))
      {
        Directory.CreateDirectory(Path.GetDirectoryName(columnizerRepository));
      }

      if (columnizerToSerialize == null || columnizerToSerialize.Count == 0)
      {
        if (File.Exists(columnizerRepository))
        {
          // We don't need an empty columnizer repository.
          try
          {
            File.Delete(columnizerRepository);
          }
          catch (Exception ex)
          {
            Logger.Error(
                "An error occurred while deleting the columnizer repository."
              , ex.Message);
          }
        }

        return;
      }

      try
      {
        // Create a new settings instance for the serialization.
        XmlWriterSettings writerSettings = new XmlWriterSettings();

        // Ensure that all xml entities are escaped.
        writerSettings.CheckCharacters = true;

        // Add indetations to improve readability.
        writerSettings.Indent = true;

        // Ensure no BOM (Byte Order Mask) is written at the beginning of the file.
        writerSettings.Encoding = new UTF8Encoding(false);

        using (FileStream fileStream = new FileStream(columnizerRepository, FileMode.Create, FileAccess.Write))
        {
          // Try to create the new XmlWriter object for serialization.
          XmlWriter writer = XmlWriter.Create(fileStream, writerSettings);

          writer.WriteStartDocument();
          writer.WriteStartElement("CustomColumnizer");

          foreach (Columnizer columnizer in columnizerToSerialize)
          {
            columnizer.SerializeToXml(writer);
          }

          writer.WriteEndElement();
          writer.WriteEndDocument();

          writer.Flush();
          writer.Close();
        }
      }
      catch (Exception ex)
      {
            Logger.Error(
                "An error occurred while writing into the columnizer repository."
              , ex.Message);
      }
    }

    /// <summary>
    /// Saves the configure <see cref="Columnizer"/> into the local repository.
    /// </summary>
    private void SaveColumnizer()
    {
      List<Columnizer> columnizerToSave = new List<Columnizer>();

      // Collect all columnizer.
      foreach (object objItem in cmbColumnizer.Items)
      {
        Columnizer cmbColumnizerItem = objItem as Columnizer;

        if (cmbColumnizerItem != null)
        {
          columnizerToSave.Add(cmbColumnizerItem);
        }
      }

      // Serialize them into the local columnizer repository.
      SaveColumnizer(columnizerToSave);
    }

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
              Resources.strCustomUdpReceiverNetworkDescription
            , '\t'
            , adapter.Adapter.Description
            , Environment.NewLine);

          foreach (UnicastIPAddressInformation ipAddress in ipInfo.UnicastAddresses)
          {
            if (ipAddress.Address != null && ipAddress.Address.AddressFamily == AddressFamily.InterNetwork)
            {
              nfoPanel.Text += string.Format(
                  Resources.strCustomUdpReceiverNetworkIPAddress
                , '\t'
                , ipAddress.Address
                , Environment.NewLine);

              break;
            }
          }

          nfoPanel.Text += string.Format(
              Resources.strCustomUdpReceiverNetworkSpeed
            , '\t'
            , adapter.Adapter.Speed / 1024 / 1024
            , Environment.NewLine);
        }
      }
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.UserControl.Load"/> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data. </param>
    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      cmbColumnizer.Items.AddRange(LoadColumnizer());

      if (cmbColumnizer.Items.Count > 0)
      {
        cmbColumnizer.SelectedIndex = 0;
      }

      if (ModifierKeys != Keys.Shift)
      {
        if (!string.IsNullOrEmpty(Settings.Default.PnlCustomUdpSettingsInterface))
        {
          foreach (NetworkInterfaceWrapper netInterface in cmbNetworkInterface.Items)
          {
            if (Equals(netInterface.ToString(), Settings.Default.PnlCustomUdpSettingsInterface))
            {
              cmbNetworkInterface.SelectedItem = netInterface;
              break;
            }
          }
        }

        nudPort.Value             = Settings.Default.PnlCustomUdpSettingsPort;
        txtMulticastIp.Text       = Settings.Default.PnlCustomUdpSettingsMulticastAddress;
        chkMulticastGroup.Checked = Settings.Default.PnlCustomUdpSettingsJoinMulticast;
      }

      foreach (EncodingInfo encoding in Encoding.GetEncodings())
      {
        EncodingWrapper encWrapper = new EncodingWrapper(encoding);

        cmbEncoding.Items.Add(encWrapper);

        if (encoding.CodePage == (ModifierKeys != Keys.Shift ? Settings.Default.PnlCustomUdpSettingsEncoding : Encoding.Default.CodePage))
        {
          cmbEncoding.SelectedItem = encWrapper;
        }
      }

      if (cmbEncoding.SelectedItem == null)
      {
        cmbEncoding.SelectedIndex = 0;
      }

      UpdateEditButtons();
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
        return ValidationResult.Error(Resources.strCustomUdpReceiverNoNetworkInterfaceAvailable);
      }

      if (chkMulticastGroup.Checked)
      {
        IPAddress parsedMulticastAddress;

        if (!IPAddress.TryParse(txtMulticastIp.Text, out parsedMulticastAddress))
        {
          txtMulticastIp.Select();

          return ValidationResult.Error(Resources.strCustomUdpReceiverInvalidIpAddress);
        }
      }

      return cmbColumnizer.SelectedItem == null 
        ? ValidationResult.Error(Resources.strCustomUdpReceiverNoColumnizerSelected) 
        : ValidationResult.Success;
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
                Settings.Default.PnlCustomUdpSettingsInterface        = cmbNetworkInterface.SelectedItem.ToString();
                Settings.Default.PnlCustomUdpSettingsPort             = (int)nudPort.Value;
                Settings.Default.PnlCustomUdpSettingsJoinMulticast    = chkMulticastGroup.Checked;
                Settings.Default.PnlCustomUdpSettingsMulticastAddress = txtMulticastIp.Text;
                Settings.Default.PnlCustomUdpSettingsEncoding         = ((EncodingWrapper)cmbEncoding.SelectedItem).Codepage;

                Settings.Default.SaveSettings();
              }

              return new CustomUdpReceiver(chkMulticastGroup.Checked 
                  ? IPAddress.Parse(txtMulticastIp.Text.Trim()) 
                  : null
                , new IPEndPoint(ipAddress.Address, (int)nudPort.Value)
                , cmbColumnizer.SelectedItem as Columnizer
                , Settings.Default.PnlCustomUdpSettingsEncoding);
            }
          }
        }
      }

      return null;
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Creates a new instance of the <see cref="CustomUdpReceiverSettings"/> <see cref="Control"/>.
    /// </summary>
    public CustomUdpReceiverSettings()
    {
      InitializeComponent();
      
      // Initialize the controls.
      EnumerateAndAddNetworkInterfaces();
    }

    #endregion
  }
}
