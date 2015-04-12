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

        public void PrepareCreateRequest()
        {
            throw new NotImplementedException();
        }

        public void PrepareDeleteRequest()
        {
            throw new NotImplementedException();
        }

        public void PrepareSelectRequest(byte limit = 100, int page = 1)
        {
            throw new NotImplementedException();
        }

        public void PrepareUpdateRequest()
        {
            throw new NotImplementedException();
        }

        public bool SendRequest(string sharedKey, out string responseString)
        {
            throw new NotImplementedException();
        }
    }
}