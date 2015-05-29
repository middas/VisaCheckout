using System;
using System.Text;
using VisaCheckout.VisaHelper.Attributes;

namespace VisaCheckout.VisaHelper.REST
{
    /// <summary>
    /// The REST helper for managing users
    /// </summary>
    public class UserManagement : RestBase, IAdminRestRequest
    {
        public const string ProductionUrl = "https://secure.checkout.visa.com/merchant-api/client/users";
        public const string ResourceName = "client/users";
        public const string SandboxUrl = "https://sandbox.secure.checkout.visa.com/merchant-api-ic/client/users";

        private string ContentString = null;
        private string QueryParameters = null;

        /// <summary>
        /// The constructor
        /// </summary>
        /// <param name="apikey"></param>
        public UserManagement(string apikey)
            : base(ResourceName)
        {
            if (string.IsNullOrEmpty(apikey))
            {
                throw new ArgumentNullException("ApiKey cannot be null.");
            }

            ApiKey = apikey;
        }

        /// <summary>
        /// (Required) Public API key, which is different than the shared secret
        /// </summary>
        [Option("apikey")]
        public string ApiKey { get; set; }

        /// <summary>
        /// (Required) Email address of client's secondary contact.
        /// </summary>
        [Option("email")]
        public string Email { get; set; }

        /// <summary>
        /// (Required) User's first or given name.
        /// </summary>
        [Option("firstName")]
        public string FirstName { get; set; }

        /// <summary>
        /// (Required) User's last name or surname.
        /// </summary>
        [Option("lastName")]
        public string LastName { get; set; }

        /// <summary>
        /// The HTTP method type
        /// </summary>
        public string Method { get; private set; }

        /// <summary>
        /// User name, which is required with PUT and DELETE methods, not specified as a query parameter for the POST method, and optional for the GET method.
        /// </summary>
        [Option("username")]
        public string Username { get; set; }

        /// <summary>
        /// Prepares a request to create a user
        /// </summary>
        public void PrepareCreateRequest()
        {
            Method = "POST";

            StringBuilder sb = new StringBuilder(WriteOptionalJavascriptValue((UserManagement o) => o.FirstName));
            sb.Append(WriteOptionalJavascriptValue((UserManagement o) => o.LastName));
            sb.Append(WriteOptionalJavascriptValue((UserManagement o) => o.Email));
            sb.Append(WriteOptionalJavascriptValue((UserManagement o) => o.Username));

            ContentString = sb.ToString();
            QueryParameters = WriteOptionalQueryStringValue((UserManagement o) => o.ApiKey);
        }

        /// <summary>
        /// Prepares a request to delete a user
        /// </summary>
        public void PrepareDeleteRequest()
        {
            if (string.IsNullOrEmpty(Username))
            {
                throw new ArgumentNullException("Username cannot be null.");
            }

            Method = "DELETE";

            StringBuilder sb = new StringBuilder(WriteOptionalQueryStringValue((UserManagement o) => o.ApiKey));
            sb.Append(WriteOptionalQueryStringValue((UserManagement o) => o.Username));

            QueryParameters = sb.ToString();
        }

        /// <summary>
        /// Prepares a request to query users
        /// </summary>
        /// <param name="limit">(Optional) The number of results per page; default is 100 clients.</param>
        /// <param name="page">(Optional) The page number; default is the next page, starting from 1.</param>
        public void PrepareSelectRequest(byte limit = 100, int page = 1)
        {
            Method = "GET";

            StringBuilder sb = new StringBuilder(WriteOptionalQueryStringValue((UserManagement o) => o.ApiKey));
            sb.Append(WriteOptionalQueryStringValue((UserManagement o) => o.Username));

            if (limit != 100)
            {
                sb.Append("limit=").Append(limit).Append("&");
            }

            if (page != 1)
            {
                sb.Append("page=").Append(page).Append("&");
            }

            QueryParameters = sb.ToString();
        }

        /// <summary>
        /// Prepares a request to update a user
        /// </summary>
        public void PrepareUpdateRequest()
        {
            if (string.IsNullOrEmpty(Username))
            {
                throw new ArgumentNullException("Username cannot be null.");
            }

            Method = "PUT";

            StringBuilder sb = new StringBuilder(WriteOptionalQueryStringValue((UserManagement o) => o.ApiKey));
            sb.Append(WriteOptionalQueryStringValue((UserManagement o) => o.Username));

            QueryParameters = sb.ToString();

            sb.Clear();
            sb.Append(WriteOptionalJavascriptValue((UserManagement o) => o.FirstName));
            sb.Append(WriteOptionalJavascriptValue((UserManagement o) => o.LastName));
            sb.Append(WriteOptionalJavascriptValue((UserManagement o) => o.Email));
            sb.Append(WriteOptionalJavascriptValue((UserManagement o) => o.Username));

            ContentString = sb.ToString();
        }

        /// <summary>
        /// Sends the request to Visa
        /// </summary>
        /// <param name="sharedKey"></param>
        /// <param name="responseString"></param>
        /// <returns></returns>
        public bool SendRequest(string sharedKey, out string responseString)
        {
            if (string.IsNullOrEmpty(Method))
            {
                throw new Exception("Web request was not prepared");
            }

            string url = Environment.IsSandbox ? SandboxUrl : ProductionUrl;
            ResourcePath = ResourceName;

            if (!string.IsNullOrEmpty(ContentString))
            {
                if (ContentString[ContentString.Length - 1] == ',')
                {
                    ContentString = ContentString.Substring(0, ContentString.Length - 1);
                }

                ContentString = string.Format("{{{0}}}", ContentString);
            }

            if (!string.IsNullOrEmpty(QueryParameters) && QueryParameters[QueryParameters.Length - 1] == '&')
            {
                QueryParameters = QueryParameters.Substring(0, QueryParameters.Length - 1);
            }

            return SendWebRequest(url, QueryParameters, Method, ContentString, sharedKey, out responseString);
        }
    }
}