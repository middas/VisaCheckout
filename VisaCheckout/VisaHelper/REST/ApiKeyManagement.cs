using System;

namespace VisaCheckout.VisaHelper.REST
{
    public class ApiKeyManagement : VisaRequestBase, IAdminRestRequest
    {
        public const string ResourceName = "";

        public ApiKeyManagement()
            : base(ResourceName)
        {
        }

        public string Method
        {
            get { throw new NotImplementedException(); }
        }

        public string PrepareCreateRequest()
        {
            throw new NotImplementedException();
        }

        public string PrepareDeleteRequest()
        {
            throw new NotImplementedException();
        }

        public string PrepareSelectRequest(byte limit = 100, int page = 1)
        {
            throw new NotImplementedException();
        }

        public string PrepareUpdateRequest()
        {
            throw new NotImplementedException();
        }

        public bool SendRequest(string sharedKey, out string responseString)
        {
            throw new NotImplementedException();
        }
    }
}