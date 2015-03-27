using System.Collections.Generic;

namespace VisaCheckout.VisaHelper.Options
{
    /// <summary>
    /// The init Javascript options.
    /// </summary>
    public class InitOptions
    {
        public InitOptions()
        {
            PaymentRequest = new Dictionary<string, string>();
        }

        /// <summary>
        /// (Required) The API key that Visa Checkout created when you created the Visa Checkout account. You will use both a live key and a sandbox key, which are different from each other.
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// Unique ID associated with the client, such as a merchant, which could be assigned by you or Visa Checkout.
        /// </summary>
        public string ExternalClientID { get; set; }

        /// <summary>
        /// (Optional) Profile ID, and also the profile's name, created externally by a merchant or partner, which Visa Checkout uses to populate settings, such as accepted card brands and shipping regions. The properties set in this profile override properties in the merchant's current profile.
        /// </summary>
        public string ExternalProfileID { get; set; }

        /// <summary>
        /// (Optional) One or more name-value pairs, each of which specifies a payment request attribute.
        /// </summary>
        public Dictionary<string, string> PaymentRequest { get; set; }

        /// <summary>
        /// (Optional) One or more name-value pairs, each of which specifies a configuration attribute.
        /// </summary>
        public InitSettings Settings { get; set; }

        /// <summary>
        /// (Optional) Your merchant reference ID.
        /// </summary>
        public string SourceID { get; set; }
    }
}