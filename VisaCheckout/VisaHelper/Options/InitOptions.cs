using System;
using System.Text;
using VisaCheckout.VisaHelper.Attributes;

namespace VisaCheckout.VisaHelper.Options
{
    /// <summary>
    /// The init Javascript options.
    /// </summary>
    public class InitOptions : OptionsBase, IOptions
    {
        /// <summary>
        /// (Required) The API key that Visa Checkout created when you created the Visa Checkout account. You will use both a live key and a sandbox key, which are different from each other.
        /// </summary>
        [Option("apikey")]
        public string ApiKey { get; set; }

        /// <summary>
        /// Unique ID associated with the client, such as a merchant, which could be assigned by you or Visa Checkout.
        /// </summary>
        [Option("externalClientId")]
        public string ExternalClientID { get; set; }

        /// <summary>
        /// (Optional) Profile ID, and also the profile's name, created externally by a merchant or partner, which Visa Checkout uses to populate settings, such as accepted card brands and shipping regions. The properties set in this profile override properties in the merchant's current profile.
        /// </summary>
        [Option("externalProfileId")]
        public string ExternalProfileID { get; set; }

        /// <summary>
        /// (Required) One or more name-value pairs, each of which specifies a payment request attribute.
        /// </summary>
        public PaymentRequestOptions PaymentRequest { get; set; }

        /// <summary>
        /// (Optional) Visa Checkout transaction ID. The referenceCallID can be used with the Preselected Checkout Feature.
        ///
        /// Format: Alphanumeric; maximum 48 characters
        /// </summary>
        [Option("referenceCallId")]
        public string ReferenceCallID { get; set; }

        /// <summary>
        /// (Optional) One or more name-value pairs, each of which specifies a configuration attribute.
        /// </summary>
        public SettingOptions Settings { get; set; }

        /// <summary>
        /// (Optional) Your merchant reference ID.
        /// </summary>
        [Option("sourceId")]
        public string SourceID { get; set; }

        /// <summary>
        /// Gets the options HTML.
        /// </summary>
        /// <returns></returns>
        public string GetOptionString()
        {
            if (PaymentRequest == null)
            {
                throw new ArgumentNullException("PaymentRequest cannot be null");
            }

            if (string.IsNullOrEmpty(ApiKey))
            {
                throw new ArgumentNullException("ApiKey cannot be null");
            }

            StringBuilder sb = new StringBuilder("V.init({");
            sb.Append(WriteOptionalJavascriptValue((InitOptions o) => o.ApiKey));
            sb.Append(WriteOptionalJavascriptValue((InitOptions o) => o.ReferenceCallID));
            sb.Append(WriteOptionalJavascriptValue((InitOptions o) => o.ExternalProfileID));
            sb.Append(WriteOptionalJavascriptValue((InitOptions o) => o.ExternalClientID));
            sb.Append(WriteOptionalJavascriptValue((InitOptions o) => o.SourceID));
            sb.Append(WriteOptionalJavascriptValue(null, Settings));
            sb.Append(WriteOptionalJavascriptValue(null, PaymentRequest));

            if (sb[sb.Length - 1] == ',')
            {
                sb.Length = sb.Length - 1;
            }
            sb.Append("});");

            return sb.ToString();
        }
    }
}