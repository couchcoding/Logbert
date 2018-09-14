#region Copyright © 2016 Couchcoding

// File:    Columnizer.cs
// Package: Logbert
// Project: Logbert
// 
// The MIT License (MIT)
// 
// Copyright (c) 2016 Couchcoding
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

using Couchcoding.Logbert.Logging;
using Couchcoding.Logbert.Properties;
using System.Collections.Generic;
using System.Xml;

namespace Couchcoding.Logbert.Receiver.CustomReceiver
{
  /// <summary>
  /// Implements a <see cref="Columnizer"/> for custom <see cref="LogMessage"/>s.
  /// </summary>
  public sealed class Columnizer
  {
    #region Private Fields
    
    /// <summary>
    /// The default format string to parse a timestamp value.
    /// </summary>
    public static readonly string DefaultDateTimeFormat = "yyyy-dd-MM hh:mm:ss.fff";
    
    #endregion

    #region Private Properties

    /// <summary>
    /// Gets or sets the <see cref="LogColumn"/>s of the <see cref="Columnizer"/>.
    /// </summary>
    public List<LogColumn> Columns
    {
      get;
      set;
    }

    /// <summary>
    /// Gets or sets the name of the <see cref="Columnizer"/>.
    /// </summary>
    public string Name
    {
      get;
      set;
    }

    /// <summary>
    /// Gets or sets the <see cref="LogLevel"/> mappings.
    /// </summary>
    public Dictionary<LogLevel, string> LogLevelMapping
    {
      get;
      set;
    }
    
    /// <summary>
    /// Gets or sets the format string of the timestamp.
    /// </summary>
    public string DateTimeFormat
    {
      get;
      set;
    }

      #endregion

    #region Public Methods

    /// <summary>
    /// Serializes the <see cref="Columnizer"/> instance to XML.
    /// </summary>
    /// <param name="writer">The <see cref="XmlWriter"/> instance to serialize into.</param>
    /// <returns><c>True</c> if the serialialzation was successfull; otherwise <c>false</c>.</returns>
    public bool SerializeToXml(XmlWriter writer)
    {
      if (writer != null)
      {
        writer.WriteStartElement("Columnizer");

        writer.WriteAttributeString(
            "Name"
          , Name);

        writer.WriteAttributeString(
            "DateTimeFormat"
          , DateTimeFormat);

        if (Columns.Count > 0)
        {
          writer.WriteStartElement("LogColumns");

          foreach (LogColumn column in Columns)
          {
            column.SerializeToXml(writer);
          }

          writer.WriteEndElement();
        }

        writer.WriteStartElement("LogLevels");

        foreach (KeyValuePair<LogLevel, string> logLevelMap in LogLevelMapping)
        {
          writer.WriteStartElement("LogLevel");

          writer.WriteAttributeString(
              "Value"
            , logLevelMap.Value);

          writer.WriteAttributeString(
              "Level"
            , ((int)logLevelMap.Key).ToString());

          writer.WriteEndElement();
        }

        writer.WriteEndElement();
        writer.WriteEndElement();

        return true;
      }

      return false;
    }

    /// <summary>
    /// deserializes the <see cref="Columnizer"/> instance from the spezified <paramref name="node"/>.
    /// </summary>
    /// <param name="node">The <see cref="XmlNode"/> that may contain <see cref="LogColumn"/> data to deserialize.</param>
    /// <returns><c>True</c> if the deserialialzation was successfull; otherwise <c>false</c>.</returns>
    public bool DeserializeFromXml(XmlNode node)
    {
      if (node != null && Equals(node.Name, "Columnizer") && node.Attributes != null)
      {
        Name = node.Attributes["Name"] != null
             ? node.Attributes["Name"].Value ?? Resources.strColumnizerDefaultName
             : Resources.strColumnizerDefaultName;

        DateTimeFormat = node.Attributes["DateTimeFormat"] != null
            ? node.Attributes["DateTimeFormat"].Value ?? DefaultDateTimeFormat
            : DefaultDateTimeFormat;

        // Initialize an empty column list.
        Columns = new List<LogColumn>();

        XmlNode columnNode = node.SelectSingleNode("LogColumns");

        if (columnNode.HasChildNodes)
        {
          foreach (XmlNode childNode in columnNode.ChildNodes)
          {
            LogColumn deserializedColumn = new LogColumn();

            if (deserializedColumn.DeserializeFromXml(childNode))
            {
              Columns.Add(deserializedColumn);
            }
          }
        }

        XmlNode logLevelNode = node.SelectSingleNode("LogLevels");

        if (logLevelNode.HasChildNodes)
        {
          foreach (XmlNode childNode in logLevelNode.ChildNodes)
          {
            LogLevel parsedLevel = (LogLevel)int.Parse(
              childNode.Attributes["Level"].Value);

            LogLevelMapping[parsedLevel] = childNode.Attributes["Value"].Value;
          }
        }

        return true;
      }

      return false;
    }

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString()
    {
      return Name ?? Resources.strColumnizerDefaultName;
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Initializes a new instance of a <see cref="Columnizer"/>.
    /// </summary>
    /// <param name="name">The name of the new <see cref="Columnizer"/> instance.</param>
    public Columnizer(string name = "New Columnizer")
    {
      Name           = name;
      Columns        = new List<LogColumn>();
      DateTimeFormat = DefaultDateTimeFormat;

      // Initialize a default log level mapping.
      LogLevelMapping = new Dictionary<LogLevel, string>
      {
          { LogLevel.Trace   , @"(?i)TRACE(?-i)"        }
        , { LogLevel.Debug   , @"(?i)DEBUG(?-i)"        }
        , { LogLevel.Info    , @"(?i)INFO(?-i)"         }
        , { LogLevel.Warning , @"(?i)WARN|WARNING(?-i)" }
        , { LogLevel.Error   , @"(?i)ERROR(?-i)"        }
        , { LogLevel.Fatal   , @"(?i)FATAL(?-i)"        }
      };
    }

    #endregion
  }
}
