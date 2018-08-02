using Com.Couchcoding.Logbert.Properties;

using WeifenLuo.WinFormsUI.Docking;

namespace Com.Couchcoding.Logbert.Helper
{
  public static class ThemeManager
  {
    #region Private Fields

    private static ThemeBase mApplicationTheme;

    #endregion

    #region Public Properties

    public static ThemeBase CurrentApplicationTheme
    {
      get
      {
        if (mApplicationTheme == null)
        {
            switch (Settings.Default.ApplicationTheme)
            {
                case "Visual Studio Blue":
                    mApplicationTheme = new VS2015BlueTheme();
                    break;
                default:
                    mApplicationTheme = new VS2015LightTheme();
                    break;
            }
            
        }

        return mApplicationTheme;
      }
    }

    #endregion
  }
}
