using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace VisaCheckout.VisaHelper
{
    /// <summary>
    /// Helps handles response data
    /// </summary>
    public class ResponseHandler
    {
        private const int HmacLength = 32;
        private const int IvLength = 16;

        /// <summary>
        /// Decrypt data
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="data">The encrypted data</param>
        /// <returns>A decrypted byte array</returns>
        public byte[] Decrypt(byte[] key, byte[] data)
        {
            if (data == null || data.Length <= IvLength + HmacLength)
            {
                throw new ArgumentException("Bad input data", "data");
            }

            byte[] hmac = new byte[HmacLength];
            Array.Copy(data, 0, hmac, 0, HmacLength);

            byte[] iv = new byte[IvLength];
            Array.Copy(data, HmacLength, iv, 0, IvLength);

            byte[] payload = new byte[data.Length - HmacLength - IvLength];
            Array.Copy(data, HmacLength + IvLength, payload, 0, payload.Length);

            byte[] returnData = null;

            using (Aes aes = new AesManaged()
            {
                BlockSize = 128,
                KeySize = 256,
                Key = Hash(key),
                IV = iv,
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7
            })
            using (MemoryStream ms = new MemoryStream())
            using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
            {
                cs.Write(payload, 0, payload.Length);
                cs.FlushFinalBlock();
                returnData = ms.ToArray();
            }

            return returnData;
        }

        /// <summary>
        /// Decrypt the payment data
        /// </summary>
        /// <param name="secretKey">The secret key given by Visa</param>
        /// <param name="encKey">The encrypted key from the response</param>
        /// <param name="paymentData">The encrypted response data</param>
        /// <returns>The decrypted payment data as a string</returns>
        public string DecryptPaymentData(string secretKey, string encKey, string paymentData)
        {
            byte[] dynamicKey = Decrypt(Encoding.UTF8.GetBytes(secretKey), Convert.FromBase64String(encKey));

            return Encoding.UTF8.GetString(Decrypt(dynamicKey, Convert.FromBase64String(paymentData)));
        }

        private byte[] Hash(byte[] key)
        {
            return (new SHA256Managed()).ComputeHash(key);
        }

        private byte[] HmacHash(byte[] key, byte[] data)
        {
            return (new HMACSHA256(key)).ComputeHash(data);
        }
    }
}