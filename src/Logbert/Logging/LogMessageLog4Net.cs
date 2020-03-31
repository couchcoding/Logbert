#region Copyright © 2015 Couchcoding

// File:    LogMessageLog4Net.cs
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

using Couchcoding.Logbert.Properties;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;

using Couchcoding.Logbert.Helper;

using MoonSharp.Interpreter;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Couchcoding.Logbert.Logging
{
  /// <summary>
  /// Implements a <see cref="LogMessage"/> class for Log4Net logger messages.
  /// </summary>
  public sealed class LogMessageLog4Net : LogMessage
  {
    #region Public Types

    /// <summary>
    /// Implements a simple type to represent a Log4NEt location info.
    /// </summary>
    public struct LocationInfo
    {
      #region Public Properties

      /// <summary>
      /// Gets or sets the file name of the <see cref="LocationInfo"/> type.
      /// </summary>
      public string FileName
      {
        get;
        private set;
      }

      /// <summary>
      /// Gets or sets the class name of the <see cref="LocationInfo"/> type.
      /// </summary>
      public string ClassName
      {
        get;
        private set;
      }

      /// <summary>
      /// Gets or sets the method name of the <see cref="LocationInfo"/> type.
      /// </summary>
      public string MethodName
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
        string locationString  = !string.IsNullOrEmpty(FileName)   ? "File: "   + FileName : string.Empty;
               locationString += !string.IsNullOrEmpty(ClassName)  ? "Class: "  + ClassName : string.Empty;
               locationString += !string.IsNullOrEmpty(MethodName) ? "Method: " + MethodName : string.Empty;

 	      return locationString;
      }

      #endregion

      #region Constructor

      /// <summary>
      /// Creates a new instance of a <see cref="LocationInfo"/> type.
      /// </summary>
      /// <param name="fileName">The file name of the <see cref="LocationInfo"/> type.</param>
      /// <param name="className">The class name of the <see cref="LocationInfo"/> type.</param>
      /// <param name="methodName">The method name of the <see cref="LocationInfo"/> type.</param>
      public LocationInfo(string fileName, string className, string methodName) : this()
      {
        FileName   = fileName;
        ClassName  = className;
        MethodName = methodName;
      }

      #endregion
    }

    #endregion

    #region Private Fields

    /// <summary>
    /// The necessary <see cref="XmlParserContext"/> to handle the log4j XML namespace within the log fragments.
    /// </summary>
    private static readonly XmlParserContext mParserContext;

    /// <summary>
    /// Holds the <see cref="DateTime"/> the <see cref="LogMessage"/> is received. 
    /// </summary>
    private DateTime mTimestamp;

    /// <summary>
    /// Holds the message of the <see cref="LogMessage"/>.
    /// </summary>
    private string mMessage;

    /// <summary>
    /// Holds the <see cref="LogLevel"/> of the <see cref="LogMessage"/>.
    /// </summary>
    private LogLevel mLevel;

    /// <summary>
    /// Holds the thread name of the <see cref="LogMessage"/>.
    /// </summary>
    private string mThread;

    /// <summary>
    /// Holds the <see cref="LocationInfo"/> of the <see cref="LogMessage"/>.
    /// </summary>
    private LocationInfo mLocation;

    /// <summary>
    /// Holds a <see cref="Dictionary{V, T}"/> of custom properties.
    /// </summary>
    private readonly Dictionary<string, string> mCustomProperties = new Dictionary<string,string>();

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets the <see cref="DateTime"/> the <see cref="LogMessage"/> is received.
    /// </summary>
    public override DateTime Timestamp
    {
      get
      {
        return mTimestamp;
      }
    }

    /// <summary>
    /// Gets the message of the <see cref="LogMessage"/>.
    /// </summary>
    public override string Message
    {
      get
      {
        return mMessage;
      }
    }

    /// <summary>
    /// Gets the <see cref="LogLevel"/> of the <see cref="LogMessage"/>.
    /// </summary>
    public override LogLevel Level
    {
      get
      {
        return mLevel;
      }
    }

    /// <summary>
    /// Gets the thread name of the <see cref="LogMessage"/>.
    /// </summary>
    public string Thread
    {
      get
      {
        return mThread;
      }
    }

    /// <summary>
    /// Gets the <see cref="LocationInfo"/> of the <see cref="LogMessage"/>.
    /// </summary>
    public LocationInfo Location
    {
      get
      {
        return mLocation;
      }
    }

    /// <summary>
    /// Gets a <see cref="Dictionary{V, T}"/> of custom properties.
    /// </summary>
    public Dictionary<string, string> CustomProperties
    {
      get
      {
        return mCustomProperties;
      }
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Parses the given <paramref name="data"/> for possible log message parts.
    /// </summary>
    /// <param name="data">The data string to parse.</param>
    /// <returns><c>True</c> on success, otherwise <c>false</c>.</returns>
    private bool ParseData(string data)
    {
      if (!string.IsNullOrEmpty(data))
      {
        using (XmlReader reader = new XmlTextReader(data, XmlNodeType.Element, mParserContext))
        {
          if ((reader.MoveToContent() != XmlNodeType.Element) || (reader.Name != "log4j:event"))
          {
            return false;
          }

          long timestamp;
          mTimestamp = long.TryParse(reader.GetAttribute("timestamp"), out timestamp)
            ? mUtcStartDate.AddMilliseconds(timestamp)
            : DateTime.Now;

          mLevel  = MapLevelType(reader.GetAttribute("level"));
          mLogger = reader.GetAttribute("logger");
          mThread = reader.GetAttribute("thread");

          int eventDepth = reader.Depth;
          reader.Read();

          while (reader.Depth > eventDepth)
          {
            if (reader.MoveToContent() == XmlNodeType.Element)
            {
              switch (reader.Name)
              {
                case "log4j:message":
                  mMessage = reader.ReadString();
                  break;

                case "log4j:throwable":
                  mMessage += Environment.NewLine + reader.ReadString();
                  break;

                case "log4j:locationInfo":
                  mLocation = new LocationInfo(
                      reader.GetAttribute("file")   ?? string.Empty
                    , reader.GetAttribute("class")  ?? string.Empty
                    , reader.GetAttribute("method") ?? string.Empty);
                  break;

                case "log4j:properties":
                  reader.Read();
                  while (reader.MoveToContent() == XmlNodeType.Element && reader.Name == "log4j:data")
                  {
                    string name  = reader.GetAttribute("name");
                    string value = reader.GetAttribute("value");

                    if (name != null)
                    {
                      switch (name.ToLower())
                      {
                        case "exceptions":
                          mCustomProperties["ExceptionString"] = value;
                          break;
                        default:
                          mCustomProperties[name] = value;
                          break;
                      }
                    }

                    reader.Read();
                  }

                  break;
              }
            }

            reader.Read();
          }

          return true;
        }
      }

      return false;
    }

    /// <summary>
    /// Mappes the given <paramref name="levelType"/> to the internal <see cref="LogLevel"/>.
    /// </summary>
    /// <param name="levelType">The string to map to the internal <see cref="Enum"/>.</param>
    /// <returns>The mapped <see cref="LogLevel"/>.</returns>
    private LogLevel MapLevelType(string levelType)
    {
      if (!string.IsNullOrEmpty(levelType))
      {
        if (Regex.IsMatch(levelType, Settings.Default.Log4NetLevelDebug))
        {
          return LogLevel.Debug;
        }

        if (Regex.IsMatch(levelType, Settings.Default.Log4NetLevelInfo))
        {
          return LogLevel.Info;
        }

        if (Regex.IsMatch(levelType, Settings.Default.Log4NetLeveLWarning))
        {
          return LogLevel.Warning;
        }

        if (Regex.IsMatch(levelType, Settings.Default.Log4NetLevelError))
        {
          return LogLevel.Error;
        }

        if (Regex.IsMatch(levelType, Settings.Default.Log4NetLevelFatal))
        {
          return LogLevel.Fatal;
        }
      }

      // The lowest one is the default one.
      return LogLevel.Trace;
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Gets the value to display within a <see cref="DataGridView"/> at the fiven <paramref name="columnIndex"/>.
    /// </summary>
    /// <param name="columnIndex">The index of the column at the <see cref="DataGridView"/>.</param>
    /// <returns>The value to display at the given <paramref name="columnIndex"/>, or <c>null</c> if nothing to display.</returns>
    public override object GetValueForColumn(int columnIndex)
    {
      switch (columnIndex)
      {
        case 1:
          return mIndex;
        case 2:
          return mLevel.ToString();
        case 3:
          return mTimestamp.Add(mTimeShiftOffset).ToString(
              Settings.Default.TimestampFormat
            , CultureInfo.InvariantCulture);
        case 4:
          return mLogger;
        case 5:
          return mThread;
        case 6:
          return mMessage;
      }

      return null;
    }

    /// <summary>
    /// Exports the <see cref="LogMessage"/> with its data into a comma seperated line.
    /// </summary>
    /// <returns>The <see cref="LogMessage"/> with its data as a comma seperated line.</returns>
    public override string GetCsvLine()
    {
      string messageValue = string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\""
        , mIndex.ToCsv()
        , mLevel.ToCsv()
        , mTimestamp.ToString(Settings.Default.TimestampFormat)
        , mLogger.ToCsv()
        , mThread.ToCsv()
        , mMessage.ToCsv()
        , mLocation.ToString().ToCsv());

      foreach (KeyValuePair<string, string> customProperty in mCustomProperties)
      {
        messageValue += string.Format("{0}: {1},"
          , customProperty.Key.ToCsv()
          , customProperty.Value.ToCsv());
      }

      if (messageValue.Length > 0)
      {
        // Remove the last comma from the custom properties string.
        messageValue = messageValue.Remove(
            messageValue.Length - 1
          , 1);
      }

      return messageValue + "\"";
    }

    /// <summary>
    /// Returns a <see cref="Table"/> that represents the current <see cref="LogMessage"/>.
    /// </summary>
    /// <param name="owner">The owner <see cref="Script"/> instance this <see cref="Table"/> is for.</param>
    /// <returns>A new <see cref="Table"/> object that represents the current <see cref="LogMessage"/>, or <c>null</c> on error.</returns>
    public override Table ToLuaTable(Script owner)
    {
      Table msgData = base.ToLuaTable(owner);

      if (msgData == null)
      {
        return null;
      }

      msgData["Thread"]   = Thread;
      msgData["Location"] = Location.ToString();
      
      Table customProperties = new Table(owner);

      foreach (KeyValuePair<string, string> customProperty in mCustomProperties)
      {
        customProperties[customProperty.Key] = customProperty.Value;
      }

      msgData["CustomProperties"] = customProperties;

      return msgData;
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Creates a new instance of the <see cref="LogMessageLog4Net"/> object.
    /// </summary>
    /// <param name="rawData">The data <see cref="Array"/> the new <see cref="LogMessageLog4Net"/> represents.</param>
    /// <param name="index">The index of the <see cref="LogMessage"/>.</param>
    public LogMessageLog4Net(string rawData, int index) : base(rawData, index)
    {
      if (!ParseData(rawData))
      {
        throw new ApplicationException("Unable to parse the logger data.");
      }
    }

    /// <summary>
    /// Static constructior to initialize the Log4J XML parser context.
    /// </summary>
    static LogMessageLog4Net()
    {
      XmlNamespaceManager namespaceManager = 
        new XmlNamespaceManager(new NameTable());

      namespaceManager.AddNamespace("nlog", "urn:ignore");

      namespaceManager.AddNamespace(
          "log4j"
        , "http://jakarta.apache.org/log4j/");

      mParserContext = new XmlParserContext(
          null
        , namespaceManager
        , null
        , XmlSpace.Default);
    }

    #endregion
  }
}
