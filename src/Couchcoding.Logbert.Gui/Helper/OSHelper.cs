using System;

namespace Couchcoding.Logbert.Gui.Helper
{
  public static class OSHelper
  {
    /// <summary>
    /// Indicates whether we're running on windows vista or higher, or not.
    /// </summary>
    public static bool IsWinVista
    {
      get
      {
        OperatingSystem os = Environment.OSVersion;
        return (os.Platform == PlatformID.Win32NT) && (os.Version.Major >= 6);
      }
    }
  }
}
