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
          mApplicationTheme = new VS2015LightTheme();
        }

        return mApplicationTheme;
      }
    }

    #endregion
  }
}
