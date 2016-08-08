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

using Com.Couchcoding.Logbert.Properties;
using System.Collections.Generic;
using System.Xml;

namespace Com.Couchcoding.Logbert.Receiver.CustomReceiver
{
  public sealed class Columnizer
  {
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

        if (Columns.Count > 0)
        {
          foreach (LogColumn column in Columns)
          {
            column.SerializeToXml(writer);
          }
        }

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

        // Initialize an empty column list.
        Columns = new List<LogColumn>();

        if (node.HasChildNodes)
        {
          foreach (XmlNode childNode in node.ChildNodes)
          {
            LogColumn deserializedColumn = new LogColumn();

            if (deserializedColumn.DeserializeFromXml(childNode))
            {
              Columns.Add(deserializedColumn);
            }
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
      Name    = name;
      Columns = new List<LogColumn>();
    }

    #endregion
  }
}
