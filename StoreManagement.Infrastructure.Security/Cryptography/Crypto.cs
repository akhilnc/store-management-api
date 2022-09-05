using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using StoreManagement.Data.Generics.AppSettings;
using Microsoft.Extensions.Options;

namespace StoreManagement.Infrastructure.Security.Cryptography
{
    public class Crypto : ICrypto
    {
        private readonly int _iterations;
        private readonly string _password;

        public Crypto(IOptions<AppSettings> settings)
        {
            var crypto = settings.Value.Cryptography;
            _iterations = crypto.Iterations;
            _password = crypto.Password;
        }

        public string Encrypt(string input)
        {
            byte[] encrypted;
            byte[] IV;
            var Salt = GetSalt();
            var Key = CreateKey(_password, Salt);

            using (var aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.Padding = PaddingMode.PKCS7;
                aesAlg.Mode = CipherMode.CBC;

                aesAlg.GenerateIV();
                IV = aesAlg.IV;

                var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (var msEncrypt = new MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(input);
                        }

                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            var combinedIvSaltCt = new byte[Salt.Length + IV.Length + encrypted.Length];
            Array.Copy(Salt, 0, combinedIvSaltCt, 0, Salt.Length);
            Array.Copy(IV, 0, combinedIvSaltCt, Salt.Length, IV.Length);
            Array.Copy(encrypted, 0, combinedIvSaltCt, Salt.Length + IV.Length, encrypted.Length);

            return Convert.ToBase64String(combinedIvSaltCt.ToArray());
        }

        public string Decrypt(string input)
        {
            byte[] inputAsByteArray;
            string plaintext = null;
            inputAsByteArray = Convert.FromBase64String(input);

            var Salt = new byte[32];
            var IV = new byte[16];
            var Encoded = new byte[inputAsByteArray.Length - Salt.Length - IV.Length];

            Array.Copy(inputAsByteArray, 0, Salt, 0, Salt.Length);
            Array.Copy(inputAsByteArray, Salt.Length, IV, 0, IV.Length);
            Array.Copy(inputAsByteArray, Salt.Length + IV.Length, Encoded, 0, Encoded.Length);

            var Key = CreateKey(_password, Salt);

            using (var aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;
                aesAlg.Mode = CipherMode.CBC;
                aesAlg.Padding = PaddingMode.PKCS7;

                var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (var msDecrypt = new MemoryStream(Encoded))
                {
                    using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (var srDecrypt = new StreamReader(csDecrypt))
                        {
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return plaintext;
        }


        #region Private

        private byte[] CreateKey(string _password, byte[] salt)
        {
            using (var rfc2898DeriveBytes = new Rfc2898DeriveBytes(_password, salt, _iterations))
            {
                return rfc2898DeriveBytes.GetBytes(32);
            }
        }

        private byte[] GetSalt()
        {
            var salt = new byte[32];
            using (var random = new RNGCryptoServiceProvider())
            {
                random.GetNonZeroBytes(salt);
            }

            return salt;
        }

        #endregion
    }
}