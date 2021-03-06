using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace AuthGG
{
    internal class Encryption
    {
        public static string APIService(string value)
        {
            string plainText = value;
            string s = Encoding.Default.GetString(Convert.FromBase64String(Constants.APIENCRYPTKEY));
            byte[] hash = SHA256.Create().ComputeHash(Encoding.ASCII.GetBytes(s));
            byte[] bytes = Encoding.ASCII.GetBytes(Encoding.Default.GetString(Convert.FromBase64String(Constants.APIENCRYPTSALT)));
            return Encryption.EncryptString(plainText, hash, bytes);
        }

        public static string EncryptService(string value)
        {
            string plainText = value;
            string s = Encoding.Default.GetString(Convert.FromBase64String(Constants.APIENCRYPTKEY));
            byte[] hash = SHA256.Create().ComputeHash(Encoding.ASCII.GetBytes(s));
            byte[] bytes = Encoding.ASCII.GetBytes(Encoding.Default.GetString(Convert.FromBase64String(Constants.APIENCRYPTSALT)));
            return Encryption.EncryptString(plainText, hash, bytes) + AuthGG.Security.Obfuscate(int.Parse(OnProgramStart.AID.Substring(0, 2)));
        }

        public static string DecryptService(string value)
        {
            string cipherText = value;
            string s = Encoding.Default.GetString(Convert.FromBase64String(Constants.APIENCRYPTKEY));
            byte[] hash = SHA256.Create().ComputeHash(Encoding.ASCII.GetBytes(s));
            byte[] bytes = Encoding.ASCII.GetBytes(Encoding.Default.GetString(Convert.FromBase64String(Constants.APIENCRYPTSALT)));
            return Encryption.DecryptString(cipherText, hash, bytes);
        }

        public static string EncryptString(string plainText, byte[] key, byte[] iv)
        {
            Aes aes = Aes.Create();
            aes.Mode = CipherMode.CBC;
            aes.Key = key;
            aes.IV = iv;
            MemoryStream memoryStream = new MemoryStream();
            ICryptoTransform encryptor = aes.CreateEncryptor();
            CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write);
            byte[] bytes = Encoding.ASCII.GetBytes(plainText);
            cryptoStream.Write(bytes, 0, bytes.Length);
            cryptoStream.FlushFinalBlock();
            byte[] array = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            return Convert.ToBase64String(array, 0, array.Length);
        }

        public static string DecryptString(string cipherText, byte[] key, byte[] iv)
        {
            Aes aes = Aes.Create();
            aes.Mode = CipherMode.CBC;
            aes.Key = key;
            aes.IV = iv;
            MemoryStream memoryStream = new MemoryStream();
            ICryptoTransform decryptor = aes.CreateDecryptor();
            CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Write);
            string empty = string.Empty;
            try
            {
                byte[] buffer = Convert.FromBase64String(cipherText);
                cryptoStream.Write(buffer, 0, buffer.Length);
                cryptoStream.FlushFinalBlock();
                byte[] array = memoryStream.ToArray();
                empty = Encoding.ASCII.GetString(array, 0, array.Length);
            }
            finally
            {
                memoryStream.Close();
                cryptoStream.Close();
            }
            return empty;
        }

        public static string Decode(string text)
        {
            text = text.Replace('_', '/').Replace('-', '+');
            switch (text.Length % 4)
            {
                case 2:
                    text += "==";
                    break;
                case 3:
                    text += "=";
                    break;
            }
            return Encoding.UTF8.GetString(Convert.FromBase64String(text));
        }
    }
}
