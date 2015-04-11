namespace VisaCheckout.VisaHelper.REST
{
    public interface IAdminRestRequest : IVisaRestRequest
    {
        string Create();

        string Delete();

        string Update();
    }
}