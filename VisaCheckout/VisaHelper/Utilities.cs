using System.Security.Cryptography;
using System.Text;
using System.Web;

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

        public static string UrlEncode(string s)
        {
            if (!string.IsNullOrEmpty(s))
            {
                string value = HttpUtility.UrlEncode(s).Replace("%26", "&").Replace("%3d", "=");
                value = value.Replace("%2d", "-").Replace("2e", ".").Replace("5f", "_").Replace("7e", "~");

                return value;
            }

            return s;
        }
    }
}