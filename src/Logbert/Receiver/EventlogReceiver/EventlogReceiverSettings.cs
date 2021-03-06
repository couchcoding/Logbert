﻿#region Copyright © 2015 Couchcoding

// File:    EventlogReceiverSettings.cs
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
using System.Diagnostics;
using System.Windows.Forms;

using Couchcoding.Logbert.Interfaces;
using Couchcoding.Logbert.Properties;

using Couchcoding.Logbert.Helper;

namespace Couchcoding.Logbert.Receiver.EventlogReceiver
{
  /// <summary>
  /// Implements the <see cref="ILogSettingsCtrl"/> control for the EventLog receiver.
  /// </summary>
  public partial class EventlogReceiverSettings : UserControl, ILogSettingsCtrl
  {
    #region Private Types

    /// <summary>
    /// A type to wrap an <see cref="EventLog"/>.
    /// </summary>
    private class EventLogWrapper
    {
      #region Public Properties

      /// <summary>
      /// Gets or sets the <see cref="EventLog"/> instance.
      /// </summary>
      public EventLog EventLog
      {
        get;
        private set;
      }

      #endregion

      #region Public Methods

      /// <summary>
      /// Returns the fully qualified type name of this instance.
      /// </summary>
      /// <returns> A <see cref="T:System.String"/> containing a fully qualified type name. </returns>
      public override string ToString()
      {
        return EventLog.Log;
      }

      #endregion

      #region Constructor

      /// <summary>
      /// Initializes a new instance of the <see cref="EventLogWrapper"/> type with the specified parameters.
      /// </summary>
      /// <param name="eventLog">The <see cref="EventLog"/> instance to wrap.</param>
      public EventLogWrapper(EventLog eventLog)
      {
        EventLog = eventLog;
      }

      #endregion
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Gets all available <see cref="EventLog"/> names and add them to the <see cref="ComboBox"/>.
    /// </summary>
    private void EnumerateAndAddEventLogNames()
    {
      try
      {
        foreach (EventLog eventLog in EventLog.GetEventLogs())
        {
          cmbLogNames.Items.Add(new EventLogWrapper(eventLog));
        }
      }
      catch (Exception ex)
      {
        Logger.Error(ex.Message);
      }
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.UserControl.Load"/> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data. </param>
    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      if (cmbLogNames.Items.Count > 0)
      {
        // Select the very first log name entry by default.
        cmbLogNames.SelectedIndex = 0;
      }

      if (ModifierKeys != Keys.Shift)
      {
        foreach (EventLogWrapper item in cmbLogNames.Items)
        {
          if (Equals(item.EventLog.Log, Settings.Default.PnlEventLogSettingsLogName))
          {
            cmbLogNames.SelectedItem = item;
            break;
          }
        }

        txtMachineName.Text = Settings.Default.PnlEventLogSettingsMachineName;
        txtSourceName.Text  = Settings.Default.PnlEventLogSettingsSourceName;
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
      if (cmbLogNames.SelectedItem == null)
      {
        return ValidationResult.Error(Resources.strEventLogReceiverNoLogNameAvailable);
      }

      if (string.IsNullOrEmpty(txtMachineName.Text))
      {
        return ValidationResult.Error(Resources.strEventLogReceiverNoMachineName);
      }
      
      return ValidationResult.Success;
    }

    /// <summary>
    /// Creates and returns a fully configured <see cref="ILogProvider"/> instance.
    /// </summary>
    /// <returns>A fully configured <see cref="ILogProvider"/> instance.</returns>
    public ILogProvider GetConfiguredInstance()
    {
      EventLogWrapper wrapper = cmbLogNames.SelectedItem as EventLogWrapper;

      if (wrapper != null)
      {
        string logName     = wrapper.EventLog.Log;
        string machineName = txtMachineName.Text.Trim();
        string sourceName  = txtSourceName.Text.Trim();

        if (ModifierKeys != Keys.Shift)
        {
          Settings.Default.PnlEventLogSettingsLogName     = logName;
          Settings.Default.PnlEventLogSettingsMachineName = machineName;
          Settings.Default.PnlEventLogSettingsSourceName  = sourceName;

          // Save the current settings as new default values.
          Settings.Default.SaveSettings();
        }

        return new EventlogReceiver(
            logName
          , machineName
          , sourceName);
      }

      return null;
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Creates a new instance of the <see cref="EventlogReceiverSettings"/> <see cref="Control"/>.
    /// </summary>
    public EventlogReceiverSettings()
    {
      InitializeComponent();
      
      // Initialize the controls.
      EnumerateAndAddEventLogNames();
    }

    #endregion
  }
}
