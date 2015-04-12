namespace VisaCheckout.VisaHelper.REST
{
    public interface IAdminRestRequest : IVisaRestRequest
    {
        string Create();

        string Delete();

        string Select(byte limit, int page);

        string Update();
    }
}