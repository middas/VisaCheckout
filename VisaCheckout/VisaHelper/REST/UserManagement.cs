using System;
using System.Text;
using VisaCheckout.VisaHelper.Attributes;

namespace VisaCheckout.VisaHelper.REST
{
    public class UserManagement : RestBase, IAdminRestRequest
    {
        public const string ProductionUrl = "https://secure.checkout.visa.com/merchant-api/client/users";
        public const string ResourceName = "client/users";
        public const string SandboxUrl = "https://sandbox.secure.checkout.visa.com/merchant-api-ic/client/users";

        private string ContentString = null;
        private string QueryParameters = null;

        public UserManagement(string apikey)
            : base(ResourceName)
        {
            if (string.IsNullOrEmpty(apikey))
            {
                throw new ArgumentNullException("ApiKey cannot be null.");
            }

            ApiKey = apikey;
        }

        [Option("apikey")]
        public string ApiKey { get; set; }

        [Option("email")]
        public string Email { get; set; }

        [Option("firstName")]
        public string FirstName { get; set; }

        [Option("lastName")]
        public string LastName { get; set; }

        public string Method { get; private set; }

        [Option("username")]
        public string Username { get; set; }

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

        public void PrepareDeleteRequest()
        {
            Method = "DELETE";

            if (string.IsNullOrEmpty(Username))
            {
                throw new ArgumentNullException("Username cannot be null.");
            }

            StringBuilder sb = new StringBuilder(WriteOptionalQueryStringValue((UserManagement o) => o.ApiKey));
            sb.Append(WriteOptionalQueryStringValue((UserManagement o) => o.Username));

            QueryParameters = sb.ToString();
        }

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

        public void PrepareUpdateRequest()
        {
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

        public bool SendRequest(string sharedKey, out string responseString)
        {
            if (string.IsNullOrEmpty(Method))
            {
                throw new Exception("Web request was not prepared");
            }

            string url = Environment.IsSandbox ? SandboxUrl : ProductionUrl;
            ResourcePath = ResourceName;

            if (!string.IsNullOrEmpty(ContentString) && ContentString[ContentString.Length - 1] == ',')
            {
                ContentString = ContentString.Substring(0, ContentString.Length - 1);
            }

            if (!string.IsNullOrEmpty(QueryParameters) && QueryParameters[QueryParameters.Length - 1] == '&')
            {
                QueryParameters = QueryParameters.Substring(0, QueryParameters.Length - 1);
            }

            return SendWebRequest(url, QueryParameters, Method, ContentString, sharedKey, out responseString);
        }
    }
}