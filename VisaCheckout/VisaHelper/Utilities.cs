using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace VisaCheckout.VisaHelper
{
    public class Utilities
    {
        public static string Sha256Hash(string s)
        {
            SHA256Managed sha = new SHA256Managed();
            byte[] hash = sha.ComputeHash(Encoding.UTF8.GetBytes(s));
            string hashString = "";

            foreach (byte b in hash)
            {
                hashString += string.Format("{0:x2}", b);
            }

            return hashString;
        }
    }
}
