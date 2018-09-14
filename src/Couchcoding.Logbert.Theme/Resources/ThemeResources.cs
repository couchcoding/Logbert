using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Couchcoding.Logbert.Theme.Resources
{
  public abstract class ThemeResources
  {
    public abstract Dictionary<string, Bitmap> Images
    {
      get;
    }
  }
}
