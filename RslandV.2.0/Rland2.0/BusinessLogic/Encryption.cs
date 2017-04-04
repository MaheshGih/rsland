using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace Rland2._0.BusinessLogic
{
    public class Encryption
    {

        private static byte[] KEY_64 = { 42, 16, 93, 156, 78, 4, 218, 32 };
        private static byte[] IV_64 = { 55, 103, 246, 79, 36, 99, 167, 3 };

        public Encryption()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #region Password Encryption and Decryption

        public string Encrypt(string value)
        {
            string strReturn = string.Empty;
            try
            {
                if (value != "")
                {
                    DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
                    MemoryStream ms = new MemoryStream();
                    CryptoStream cs = new CryptoStream(ms, cryptoProvider.CreateEncryptor(KEY_64, IV_64), CryptoStreamMode.Write);
                    StreamWriter sw = new StreamWriter(cs);
                    sw.Write(value);
                    sw.Flush();
                    cs.FlushFinalBlock();
                    ms.Flush();
                    //convert back to a string 
                    strReturn = Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return strReturn;
        }

        public string Decrypt(string value)
        {
            string strReturn = string.Empty;
            try
            {
                if (value != "")
                {
                    DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
                    //convert from string to byte array 
                    byte[] buffer = Convert.FromBase64String(value);
                    MemoryStream ms = new MemoryStream(buffer);
                    CryptoStream cs = new CryptoStream(ms, cryptoProvider.CreateDecryptor(KEY_64, IV_64), CryptoStreamMode.Read);
                    StreamReader sr = new StreamReader(cs);
                    strReturn = sr.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return strReturn;
        }

        #endregion
    }

}
