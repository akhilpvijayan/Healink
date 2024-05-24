using System.Security.Cryptography;

namespace Healink.Helper
{
    public class Encryptor
    {
        public static byte[] GenerateAesKey()
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.KeySize = 256;
                aesAlg.GenerateKey();
                return aesAlg.Key;
            }
        }

        public static byte[] EncryptMessage(string plainText, byte[] key)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;

                aesAlg.GenerateIV();
                byte[] iv = aesAlg.IV;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, iv);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                        byte[] encryptedData = msEncrypt.ToArray();
                        byte[] result = new byte[iv.Length + encryptedData.Length];
                        Buffer.BlockCopy(iv, 0, result, 0, iv.Length);
                        Buffer.BlockCopy(encryptedData, 0, result, iv.Length, encryptedData.Length);
                        return result;
                    }
                }
            }
        }
        public static string DecryptMessage(byte[] encryptedMessage, byte[] key)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;

                byte[] iv = new byte[aesAlg.BlockSize / 8];
                byte[] encryptedData = new byte[encryptedMessage.Length - iv.Length];
                Buffer.BlockCopy(encryptedMessage, 0, iv, 0, iv.Length);
                Buffer.BlockCopy(encryptedMessage, iv.Length, encryptedData, 0, encryptedData.Length);
                aesAlg.IV = iv;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(encryptedData))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            string decryptedText = srDecrypt.ReadToEnd();
                            return decryptedText;
                        }
                    }
                }
            }
        }

    }
}
