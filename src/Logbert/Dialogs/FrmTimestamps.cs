using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Couchcoding.Logbert.Gui.Dialogs;

namespace Couchcoding.Logbert.Dialogs
{
  public partial class FrmTimestamps : DialogForm
  {
    #region Private Fields
    
    /// <summary>
    /// The default format string to parse a timestamp value.
    /// </summary>
    public static readonly string DefaultDateTimeFormat = "MMM d HH:mm:ss";
    
    #endregion

    #region Public Properties

    /// <summary>
    /// Gets the specified timestamp format to parse.
    /// </summary>
    public string Timestamps => txtTimestamps.Text ?? DefaultDateTimeFormat;

    #endregion

    #region Constructor

    /// <summary>
    /// Initializes a new instance of the <see cref="FrmTimestamps"/> dialog.
    /// </summary>
    public FrmTimestamps()
    {
      InitializeComponent();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="FrmTimestamps"/> dialog with the specified parameters.
    /// </summary>
    /// <param name="format">The initial timestamp format to display.</param>
    public FrmTimestamps(string format)
    {
      InitializeComponent();

      txtTimestamps.Text = format ?? DefaultDateTimeFormat;
    }

    #endregion
  }
}
