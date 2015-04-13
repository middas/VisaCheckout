using System.Net;
using System.Text;
using VisaCheckout.VisaHelper.Attributes;
using VisaCheckout.VisaHelper.Options;

namespace VisaCheckout.VisaHelper.REST
{
    /// <summary>
    /// The REST helper for getting payment data
    /// </summary>
    public class GetPaymentData : VisaRequestBase, IVisaRestRequest
    {
        public const string ProductionUrl = "https://secure.checkout.visa.com/wallet-services-web/payment/data/";
        public const string SandboxUrl = "https://sandbox.secure.checkout.visa.com/wallet-services-web/payment/data/";
        private const string ResourceName = "payment/data";

        /// <summary>
        /// The constructor
        /// </summary>
        /// <param name="callId"></param>
        /// <param name="apiKey"></param>
        public GetPaymentData(string callId, string apiKey)
            : base(string.Format("{0}/{1}", ResourceName, callId))
        {
            ApiKey = apiKey;
            CallID = callId;
        }

        /// <summary>
        /// (Required) Public API key, which is different than the shared secret.
        /// </summary>
        [Option("apikey")]
        public string ApiKey { get; set; }

        /// <summary>
        /// The callId from response.success
        /// </summary>
        public string CallID { get; set; }

        /// <summary>
        /// (Optional) Whether the response should include summary information or full information. Permission to receive full information must be configured in Visa Checkout; otherwise, you will always receive only summary information, regardless of the data level you specify. This value overrides the value in your external profile, if it is set.
        /// </summary>
        [Option("dataLevel")]
        public DataLevels? DataLevel { get; set; }

        /// <summary>
        /// Sends the web request
        /// </summary>
        /// <returns>A JSON string result</returns>
        public bool SendRequest(string sharedKey, out string responseString)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(WriteOptionalQueryStringValue((GetPaymentData o) => o.ApiKey));
            sb.Append(WriteOptionalQueryStringValue((GetPaymentData o) => o.DataLevel));

            sb.Length = sb.Length - 1;

            return SendWebRequest(string.Format("{0}{1}", Environment.IsSandbox ? SandboxUrl : ProductionUrl, CallID), sb.ToString(), "GET", null, sharedKey, out responseString);
        }
    }
}