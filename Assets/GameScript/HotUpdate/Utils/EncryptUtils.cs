using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
#region << 脚 本 注 释 >>
//作  用:    EncryptUtils
//作  者:    曾思信
//创建时间:  #CREATETIME#
#endregion

public class EncryptUtils
{
    #region DES加密解密

    /// <summary>
    /// DES加密
    /// </summary>
    /// <param name="data">加密数据</param>
    /// <param name="key">8位字符的密钥字符串</param>
    /// <param name="iv">8位字符的初始化向量字符串</param>
    /// <returns></returns>
    public static string DESEncrypt(string data, string key, string iv)
    {
        byte[] byteKey = Encoding.UTF8.GetBytes(key);
        byte[] byteIV = Encoding.UTF8.GetBytes(iv);

        string encryptedString = null;
        using (Aes aes = Aes.Create())
        {
            aes.Key = byteKey;
            aes.IV = byteIV;

            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter sw = new StreamWriter(cs))
                    {
                        sw.Write(data);
                    }

                    encryptedString = Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        return encryptedString;
    }

    /// <summary>
    /// DES解密
    /// </summary>
    /// <param name="data">解密数据</param>
    /// <param name="key">8位字符的密钥字符串(需要和加密时相同)</param>
    /// <param name="iv">8位字符的初始化向量字符串(需要和加密时相同)</param>
    /// <returns></returns>
    public static string DESDecrypt(string data, string key, string iv)
    {
        byte[] byteKey = Encoding.UTF8.GetBytes(key);
        byte[] byteIV = Encoding.UTF8.GetBytes(iv);

        string decryptedString = null;
        using (Aes aes = Aes.Create())
        {
            aes.Key = byteKey;
            aes.IV = byteIV;

            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(data)))
            {
                using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader sr = new StreamReader(cs))
                    {
                        decryptedString = sr.ReadToEnd();
                    }
                }
            }
        }

        return decryptedString;
    }

    #endregion
}