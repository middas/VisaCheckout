using System;
using VisaCheckout.VisaHelper.Attributes;
using VisaCheckout.VisaHelper.Options;

namespace VisaCheckout.VisaHelper.REST
{
    /// <summary>
    /// The REST helper for managing API Keys
    /// </summary>
    public class ApiKeyManagement : VisaRequestBase, IAdminRestRequest
    {
        public const string ProductionUrl = "https://secure.checkout.visa.com/merchant-api/client/apikeys/";
        public const string ResourceName = "client/apikeys";
        public const string SandboxUrl = "https://sandbox.secure.checkout.visa.com/merchant-api-ic/client/apikeys/";

        private string ContentString = null;
        private string QueryString = null;

        /// <summary>
        /// The constructor
        /// </summary>
        /// <param name="apikey"></param>
        public ApiKeyManagement(string apikey)
            : base(string.Format("{0}/{1}", ResourceName, apikey))
        {
            ApiKey = apikey;
        }

        /// <summary>
        /// (Optional) Your API key.
        /// </summary>
        [Option("apikey")]
        public string ApiKey { get; set; }

        public string Method { get; private set; }

        /// <summary>
        /// (Required) Requested status of the key.
        /// </summary>
        [Option("status")]
        public ApiKeyStatus Status { get; set; }

        /// <summary>
        /// Prepares a request to create an API Key
        /// </summary>
        public void PrepareCreateRequest()
        {
            Method = "POST";

            ContentString = WriteOptionalJavascriptValue((ApiKeyManagement o) => o.Status).ToUpper();
        }

        /// <summary>
        /// Prepares a request to delete an API Key
        /// </summary>
        public void PrepareDeleteRequest()
        {
            Method = "DELETE";
        }

        /// <summary>
        /// Prepares a request to query API Keys
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="page"></param>
        public void PrepareSelectRequest(byte limit = 100, int page = 1)
        {
            Method = "GET";

            if (limit != 100)
            {
                QueryString = string.Format("limit={0}", limit);
            }

            if (page != 1)
            {
                if (!string.IsNullOrEmpty(QueryString))
                {
                    QueryString = string.Format("{0}&page={1}", QueryString, page);
                }
                else
                {
                    QueryString = string.Format("page={0}", page);
                }
            }
        }

        /// <summary>
        /// Prepares a request to update an API Key
        /// </summary>
        public void PrepareUpdateRequest()
        {
            Method = "POST";

            ContentString = WriteOptionalJavascriptValue((ApiKeyManagement o) => o.Status).ToUpper();
        }

        /// <summary>
        /// Sends the request to Visa
        /// </summary>
        /// <param name="sharedKey">The private key given by Visa</param>
        /// <param name="responseString">The response from the request</param>
        /// <returns>Whether the request succeeded or failed</returns>
        public bool SendRequest(string sharedKey, out string responseString)
        {
            if (string.IsNullOrEmpty(Method))
            {
                throw new Exception("Web request was not prepared");
            }

            if (!string.IsNullOrEmpty(ContentString) && ContentString[ContentString.Length] == '&')
            {
                ContentString = ContentString.Substring(0, ContentString.Length - 1);
            }

            if (!string.IsNullOrEmpty(QueryString) && QueryString[QueryString.Length] == '&')
            {
                QueryString = QueryString.Substring(0, QueryString.Length - 1);
            }

            return SendWebRequest(Environment.IsSandbox ? SandboxUrl : ProductionUrl, QueryString, Method, ContentString, sharedKey, out responseString);
        }
    }
}