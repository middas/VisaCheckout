using VisaCheckout.VisaHelper.Attributes;
using VisaCheckout.VisaHelper.Options;

namespace VisaCheckout.VisaHelper.REST
{
    /// <summary>
    /// The REST helper for updating payment info
    /// </summary>
    public class UpdatePaymentInfo : RestBase, IVisaRestRequest
    {
        public const string ProductionUrl = "https://secure.checkout.visa.com/wallet-services-web/payment/info/";
        public const string ResourceName = "payment/info";
        public const string SandboxUrl = "https://sandbox.secure.checkout.visa.com/wallet-services-web/payment/info/";

        /// <summary>
        /// The constructor
        /// </summary>
        /// <param name="callId"></param>
        /// <param name="apiKey"></param>
        public UpdatePaymentInfo(string callId, string apiKey)
            : base(string.Format("{0}/{1}", ResourceName, callId))
        {
            CallID = callId;
            ApiKey = apiKey;
        }

        /// <summary>
        /// (Required) Public API key, which is different than the shared secret.
        /// </summary>
        [Option("apikey")]
        public string ApiKey { get; set; }

        /// <summary>
        /// The CallId from the Visa response.success
        /// </summary>
        public string CallID { get; set; }

        /// <summary>
        /// The order information to be updated
        /// </summary>
        public OrderInfoOptions OrderInfo { get; set; }

        /// <summary>
        /// The payment information to be updated
        /// </summary>
        public PayInfoOptions PayInfo { get; set; }

        /// <summary>
        /// Sends the web request
        /// </summary>
        /// <returns>A JSON string result</returns>
        public bool SendRequest(string sharedKey, out string responseString)
        {
            string body = string.Format("{{{0},{1}}}", OrderInfo != null ? OrderInfo.GetOptionString() : "", PayInfo != null ? PayInfo.GetOptionString() : "");

            if (body[1] == ',')
            {
                body = string.Format("{{{0}", body.Substring(2));
            }
            if (body[body.Length - 2] == ',')
            {
                body = string.Format("{0}}}", body.Substring(0, body.Length - 2));
            }

            string queryString = WriteOptionalQueryStringValue((UpdatePaymentInfo o) => o.ApiKey);
            queryString = queryString.Substring(0, queryString.Length - 1);

            return SendWebRequest(string.Format("{0}{1}", Environment.IsSandbox ? SandboxUrl : ProductionUrl, CallID), queryString, "PUT", body, sharedKey, out responseString);
        }
    }
}