using System;
using VisaCheckout.VisaHelper.Attributes;

namespace VisaCheckout.VisaHelper.REST
{
    public class UserManagement : VisaRequestBase, IAdminRestRequest
    {
        public const string ProductionUrl = "https://secure.checkout.visa.com/merchant-api/client/users";
        public const string ResourceName = "client/users";
        public const string SandboxUrl = "https://sandbox.secure.checkout.visa.com/merchant-api-ic/client/users";

        [Option("apikey")]
        public string ApiKey { get; set; }

        public UserManagement(string apikey)
            : base(ResourceName)
        {
            if (string.IsNullOrEmpty(apikey))
            {
                throw new ArgumentNullException("ApiKey cannot be null.");
            }

            ApiKey = apikey;
        }

        public string Method { get; private set; }

        public void PrepareCreateRequest()
        {
            Method = "POST";
            throw new NotImplementedException();
        }

        public void PrepareDeleteRequest()
        {
            Method = "DELETE";
            throw new NotImplementedException();
        }

        public void PrepareSelectRequest(byte limit = 100, int page = 1)
        {
            Method = "GET";
            throw new NotImplementedException();
        }

        public void PrepareUpdateRequest()
        {
            Method = "PUT";
            throw new NotImplementedException();
        }

        public bool SendRequest(string sharedKey, out string responseString)
        {
            throw new NotImplementedException();
        }
    }
}