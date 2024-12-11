using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public static class EncryptionHelper
{
    private static readonly string EncryptionKey = "your-encryption-key"; // Replace with a secure key

    /// <summary>
    /// Encrypts plain text using AES encryption.
    /// </summary>
    public static string Encrypt(string plainText)
    {
        if (string.IsNullOrEmpty(plainText)) return string.Empty;

        using (var aes = Aes.Create())
        {
            var key = Encoding.UTF8.GetBytes(EncryptionKey.PadRight(32));
            aes.Key = key;
            aes.IV = new byte[16]; // Initialization vector (defaulted to zeros)

            using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                using (var sw = new StreamWriter(cs))
                {
                    sw.Write(plainText);
                }

                return Convert.ToBase64String(ms.ToArray());
            }
        }
    }

    /// <summary>
    /// Decrypts encrypted text using AES decryption.
    /// </summary>
    public static string Decrypt(string encryptedText)
    {
        if (string.IsNullOrEmpty(encryptedText)) return string.Empty;

        using (var aes = Aes.Create())
        {
            var key = Encoding.UTF8.GetBytes(EncryptionKey.PadRight(32));
            aes.Key = key;
            aes.IV = new byte[16]; // Initialization vector (defaulted to zeros)

            using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
            using (var ms = new MemoryStream(Convert.FromBase64String(encryptedText)))
            using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
            using (var sr = new StreamReader(cs))
            {
                return sr.ReadToEnd();
            }
        }
    }
}
