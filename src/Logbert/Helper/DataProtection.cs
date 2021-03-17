using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Couchcoding.Logbert.Helper
{
  /// <summary>
  /// Class to protect data like credentials.
  /// </summary>
  public sealed class DataProtection
  {
    #region Private Methods

    /// <summary>
    /// Gets a byte array with additional entropy to improve the strength of the encryption algorithm.
    /// </summary>
    /// <returns></returns>
    private static byte[] GetAditionalEntropy()
    {
      return Encoding.Unicode.GetBytes("{472242CB-00B0-47F0-B2FA-72591E9419E0}");
    }

    /// <summary>
    /// Encrypts the data using DataProtectionScope.CurrentUser.
    /// The result can be decrypted only by the same current user.
    /// </summary>
    /// <param name="data">The data to encrypt.</param>
    /// <returns>The encrypted data.</returns>
    private static byte[] Protect(byte[] data)
    {
      return ProtectedData.Protect(data, GetAditionalEntropy(),
        DataProtectionScope.CurrentUser);
    }

    /// <summary>
    /// Decrypts the data using DataProtectionScope.CurrentUser.
    /// </summary>
    /// <param name="data">The data to encrypt.</param>
    /// <returns>The encrypted data.</returns>
    private static byte[] Unprotect(byte[] data)
    {
      return ProtectedData.Unprotect(data, GetAditionalEntropy(),
        DataProtectionScope.CurrentUser);
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Encrpts a string using an internal .NET algorithm.
    /// </summary>
    /// <param name="stringToEngrypt">The string to encrypt.</param>
    /// <returns>The encrypted string.</returns>
    public static string EncryptString(string stringToEngrypt)
    {
      try
      {
        UnicodeEncoding unicodeEncoding = new UnicodeEncoding();

        byte[] stringAsByteArray = unicodeEncoding.GetBytes(stringToEngrypt);
        byte[] encodedData = Protect(stringAsByteArray);

        return Convert.ToBase64String(encodedData);
      }
      catch (Exception ex)
      {
        Logger.Error(ex.Message);
      }

      return string.Empty;
    }

    /// <summary>
    /// Descrypts a string using an internal .NET algorithm.
    /// </summary>
    /// <param name="stringToDegrypt">The string to decrypt.</param>
    /// <returns>The decrypted string.</returns>
    public static string DecryptString(string stringToDegrypt)
    {
      try
      {
        UnicodeEncoding unicodeEncoding = new UnicodeEncoding();

        byte[] encodedData = Convert.FromBase64String(stringToDegrypt);
        byte[] decodedData = Unprotect(encodedData);

        return unicodeEncoding.GetString(decodedData);
      }
      catch (Exception ex)
      {
        Logger.Error(ex.Message);
      }

      return string.Empty;
    }
    #endregion
  }
}
