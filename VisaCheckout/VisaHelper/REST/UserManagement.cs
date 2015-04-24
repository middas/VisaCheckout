using System;

namespace VisaCheckout.VisaHelper.REST
{
    public class UserManagement : VisaRequestBase, IAdminRestRequest
    {
        public const string ProductionUrl = "https://secure.checkout.visa.com/merchant-api/client/users";
        public const string ResourceName = "client/users";
        public const string SandboxUrl = "https://sandbox.secure.checkout.visa.com/merchant-api-ic/client/users";

        public UserManagement()
            : base(ResourceName)
        {
        }

        public string Method { get; private set; }

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