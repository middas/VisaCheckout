using VisaCheckout.VisaHelper.Options;

namespace VisaCheckout.VisaHelper.REST
{
    /// <summary>
    /// The REST helper for updating payment info
    /// </summary>
    public class UpdatePaymentInfo : VisaRequestBase, IVisaRestRequest
    {
        public const string ProductionUrl = "https://secure.checkout.visa.com/wallet-services-web/payment/info/";
        public const string SandboxUrl = "https://sandbox.secure.checkout.visa.com/wallet-services-web/payment/info/";

        /// <summary>
        /// The constructor
        /// </summary>
        /// <param name="callId"></param>
        /// <param name="apiKey"></param>
        public UpdatePaymentInfo(string callId, string apiKey)
            : base(string.Format("payment/info/{0}", callId))
        {
            CallID = callId;
            ApiKey = apiKey;
        }

        /// <summary>
        /// (Required) Public API key, which is different than the shared secret.
        /// </summary>
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
            throw new System.NotImplementedException();
        }
    }
}