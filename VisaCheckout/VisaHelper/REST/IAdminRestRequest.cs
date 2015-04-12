namespace VisaCheckout.VisaHelper.REST
{
    public interface IAdminRestRequest : IVisaRestRequest
    {
        string Method { get; }

        void PrepareCreateRequest();

        void PrepareDeleteRequest();

        void PrepareSelectRequest(byte limit, int page);

        void PrepareUpdateRequest();
    }
}