using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace Utility
{
    public static class Encryption
    {
        public static void Encrypt(string plainTextFileName, string encryptedFileName, string key)
        {
            FileStream plainTextFileStream = new FileStream(plainTextFileName, FileMode.Open, FileAccess.Read);

            FileStream encryptedFileNameStream = new FileStream(encryptedFileName, FileMode.Create, FileAccess.Write);

            DESCryptoServiceProvider dESCrypto = new DESCryptoServiceProvider();
            dESCrypto.Key = ASCIIEncoding.ASCII.GetBytes(key);
            dESCrypto.IV = ASCIIEncoding.ASCII.GetBytes(key);

            ICryptoTransform encryptor = dESCrypto.CreateEncryptor();

            CryptoStream cryptoStream = new CryptoStream(encryptedFileNameStream, encryptor, CryptoStreamMode.Write);

            byte[] byteArray = new byte[plainTextFileStream.Length];
            plainTextFileStream.Read(byteArray, 0, byteArray.Length);
            cryptoStream.Write(byteArray, 0, byteArray.Length);

            cryptoStream.Close();
            plainTextFileStream.Close();
            encryptedFileNameStream.Close();
        }

        public static void Decrypt(string plainTextFileName, string encryptedFileName, string key)
        {
            StreamWriter streamWriter = new StreamWriter(plainTextFileName);

            try
            {
                FileStream encryptedFileNameStream = new FileStream(encryptedFileName, FileMode.Open, FileAccess.Read);

                DESCryptoServiceProvider dESCrypto = new DESCryptoServiceProvider();
                dESCrypto.Key = ASCIIEncoding.ASCII.GetBytes(key);
                dESCrypto.IV = ASCIIEncoding.ASCII.GetBytes(key);

                ICryptoTransform decryptor = dESCrypto.CreateDecryptor();

                CryptoStream cryptoStream = new CryptoStream(encryptedFileNameStream, decryptor, CryptoStreamMode.Read);

                streamWriter.Write(new StreamReader(cryptoStream).ReadToEnd());

                streamWriter.Flush();
                streamWriter.Close();
            }
            catch (Exception)
            {
                streamWriter.Close();
                throw new Exception("Error: Cannot continue with the decryption process.");
            }
        }
    }
}
