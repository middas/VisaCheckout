namespace VisaCheckout.VisaHelper.REST
{
    public interface IVisaRestRequest
    {
        bool SendRequest(string sharedKey, out string responseString);
    }
}