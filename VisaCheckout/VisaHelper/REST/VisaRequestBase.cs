using System;
using System.Text;
using VisaCheckout.VisaHelper.Options;

namespace VisaCheckout.VisaHelper.REST
{
    public abstract class VisaRequestBase : OptionsBase
    {
        protected VisaRequestBase(string resourcePath)
        {
            ResourcePath = resourcePath;
        }

        public string ResourcePath { get; set; }

        /// <summary>
        /// A token identifying the transaction and its contents.
        /// Format: Alphanumeric; maximum 100 characters in the form of
        /// x-pay-token: x:UNIX_UTC_Timestamp:SHA256_hash, where
        ///     UNIX_UTC_Timestamp is a UNIX Epoch timestamp
        ///     SHA256_hash is an SHA256 hash of the following unseparated items:
        ///         1. Shared secret associated with the API key
        ///         2. Timestamp from the transaction; exactly the same as UNIX_UTC_Timestamp
        ///         3. Resource path (API name)
        ///         4. This HTTPS request's query string, if it exists
        ///         Note: –The query string includes one or more parameters in name-value pair format,
        ///         in which the name is separated from the value by an equal sign (=). Parameters are separated
        ///         from each other by an ampersand (&) character. The initial question mark (?) is not included
        ///         in the query string. The query string must be URL encoded, excepting the following characters,
        ///         perRFC3986: hyphen, period, underscore. and tilde.
        ///         5. Complete request body, when a request body exists
        /// </summary>
        /// <returns></returns>
        protected string GenerateToken(string sharedKey, string queryString, string body)
        {
            long unixEpoch = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;

            StringBuilder sb = new StringBuilder(sharedKey).Append(unixEpoch).Append(ResourcePath).Append(queryString).Append(body);

            return string.Format("x:{0}:{1}", unixEpoch, Utilities.Sha256Hash(sb.ToString()));
        }
    }
}