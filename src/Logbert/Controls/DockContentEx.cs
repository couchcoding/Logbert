using Couchcoding.Logbert.Helper;
using System;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Couchcoding.Logbert.Controls
{
  public class DockContentEx : DockContent
  {
    private ScrollBars visibleScrollbars;

    public ScrollBars VisibleScrollbars
    {
      get 
      {
        return visibleScrollbars;
      }
      set 
      {
        if (!Equals(value, visibleScrollbars))
        {
          OnVisibleScrollbarsChanged(value);
        }
      }
    }

    protected virtual void OnVisibleScrollbarsChanged(ScrollBars newValue)
    {
      visibleScrollbars = newValue;
    }

    protected override void OnResize(EventArgs e)
    {
      base.OnResize(e);
      VisibleScrollbars = this.GetVisibleScrollbars();
    }
  }
}
