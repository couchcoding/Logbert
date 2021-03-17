using System;
using System.Text;

namespace Couchcoding.Logbert.Receiver.CustomReceiver.CustomHttpReceiver
{
  public class BasicHttpAuthentication
  {
    #region Private Fields

    private readonly string mUsername;

    private readonly string mPassword;

    #endregion

    #region Public Properties

    public string AuthenticationType => "Basic";

    #endregion

    #region Public Methods

    public string GetToken()
    {
      return Convert.ToBase64String(Encoding.ASCII.GetBytes($"{mUsername}:{mPassword}"));
    }

    #endregion

    #region Constructor

    public BasicHttpAuthentication(string username, string password)
    {
      mUsername = username ?? string.Empty;
      mPassword = password ?? string.Empty;
    }

    #endregion
  }
}
