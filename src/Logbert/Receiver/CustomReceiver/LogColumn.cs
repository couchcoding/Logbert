#region Copyright © 2016 Couchcoding

// File:    LogColumn.cs
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

using Couchcoding.Logbert.Properties;
using System.Xml;

namespace Couchcoding.Logbert.Receiver.CustomReceiver
{
  /// <summary>
  /// Implements a column of a custom log.
  /// </summary>
  public sealed class LogColumn
  {
    #region Public Properties

    /// <summary>
    /// Gets or sets the name of the <see cref="LogColumn"/>.
    /// </summary>
    public string Name
    {
      get;
      set;
    }

    /// <summary>
    /// Gets or sets the <see cref="Regex"/> of the <see cref="LogColumn"/>.
    /// </summary>
    public string Expression
    {
      get;
      set;
    }

    /// <summary>
    /// Gets or sets the value of this <see cref="LogColumn"/> is optional on parsing, or not.
    /// </summary>
    public bool Optional
    {
      get;
      set;
    }

    /// <summary>
    /// Gets or sets the <see cref="LogColumnType"/> of the <see cref="LogColumn"/>.
    /// </summary>
    public LogColumnType ColumnType
    {
      get;
      set;
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Serializes the <see cref="LogColumn"/> instance to XML.
    /// </summary>
    /// <param name="writer">The <see cref="XmlWriter"/> instance to serialize into.</param>
    /// <returns><c>True</c> if the serialialzation was successfull; otherwise <c>false</c>.</returns>
    public bool SerializeToXml(XmlWriter writer)
    {
      if (writer != null)
      {
        writer.WriteStartElement("LogColumn");

        writer.WriteAttributeString(
            "Name"
          , Name);

        writer.WriteAttributeString(
            "Expression"
          , Expression);

        writer.WriteAttributeString(
            "Optional"
          , Optional.ToString());

        writer.WriteAttributeString(
            "Type"
          , ((int)(ColumnType)).ToString());

        writer.WriteEndElement();

        return true;
      }

      return false;
    }

    /// <summary>
    /// deserializes the <see cref="LogColumn"/> instance from the spezified <paramref name="node"/>.
    /// </summary>
    /// <param name="node">The <see cref="XmlNode"/> that may contain <see cref="LogColumn"/> data to deserialize.</param>
    /// <returns><c>True</c> if the deserialialzation was successfull; otherwise <c>false</c>.</returns>
    public bool DeserializeFromXml(XmlNode node)
    {
      if (node != null && Equals(node.Name, "LogColumn") && node.Attributes != null)
      {
        if (node.Attributes["Name"]       == null
        ||  node.Attributes["Expression"] == null
        ||  node.Attributes["Optional"]   == null
        ||  node.Attributes["Type"]       == null)
        {
          return false;
        }

        Name       = node.Attributes["Name"].Value       ?? Resources.strColumnizerColumnDefaultName;
        Expression = node.Attributes["Expression"].Value ?? Resources.strColumnizerColumnDefaultExpresssion;
        Optional   = Equals(node.Attributes["Optional"].Value, bool.TrueString);

        int typeResult = 0;
        int.TryParse(node.Attributes["Type"].Value ?? "0", out typeResult);

        ColumnType = (LogColumnType)typeResult;

        return true;
      }

      return false;
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Deserializing Constructor.
    /// </summary>
    public LogColumn()
    {

    }

    /// <summary>
    /// Creates a new instance of a <see cref="LogColumn"/> with the specified parameters.
    /// </summary>
    /// <param name="name">The name of the <see cref="LogColumn"/>.</param>
    /// <param name="expression">The <see cref="Regex"/> string of the <see cref="LogColumn"/>.</param>
    /// <param name="optional">The value of this <see cref="LogColumn"/> is optional on parsing, or not.</param>
    /// <param name="type">The <see cref="LogColumnType"/> of the <see cref="LogColumn"/>.</param>
    public LogColumn(string name, string expression, bool optional, LogColumnType type)
    {
      Name       = name;
      Expression = expression;
      Optional   = optional;
      ColumnType = type;
    }

    #endregion
  }
}
