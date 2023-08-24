using System.Security.Cryptography;
using System.Text;

namespace testMVC.Helper
{
    public static class Helper
    {
        public static string EncryptString(string plainText, byte[] key, byte[] iv)
        {
            byte[] encrypted;


            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;


                using (MemoryStream memoryStream = new MemoryStream())
                {

                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {

                        using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }

                        encrypted = memoryStream.ToArray();

                    }
                }
            }

            return Convert.ToBase64String(encrypted);
        }

        public static string DecryptString(byte[] cipherText, byte[] key, byte[] iv)
        {
            string decrypted;


            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;


                using (MemoryStream memoryStream = new MemoryStream(cipherText))
                {

                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Read))
                    {

                        using (StreamReader streamReader = new StreamReader(cryptoStream))
                        {
                            decrypted = streamReader.ReadToEnd();
                        }
                    }
                }
            }

            return decrypted;
        }

        public static string GenerateSHA384String(string inputString)
        {
            SHA384 sha384 = SHA384Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(inputString);
            byte[] hash = sha384.ComputeHash(bytes);
            return GetStringFromHash(hash);
        }

        public static string GenerateSHA512String(string inputString)
        {
            SHA512 sha512 = SHA512Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(inputString);
            byte[] hash = sha512.ComputeHash(bytes);
            return GetStringFromHash(hash);
        }
        public static string GenerateSHA1String(string inputString)
        {
            SHA1 sha1 = SHA1Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(inputString);
            byte[] hash = sha1.ComputeHash(bytes);
            return GetStringFromHash(hash);
        }


        public static string GetStringFromHash(byte[] hash)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }
            Console.WriteLine(result.Length);
            return result.ToString();
        }

    }
}
