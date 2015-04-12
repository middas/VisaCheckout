namespace VisaCheckout.VisaHelper.REST
{
    public interface IAdminRestRequest : IVisaRestRequest
    {
        string Method { get; }

        string PrepareCreateRequest();

        string PrepareDeleteRequest();

        string PrepareSelectRequest(byte limit, int page);

        string PrepareUpdateRequest();
    }
}