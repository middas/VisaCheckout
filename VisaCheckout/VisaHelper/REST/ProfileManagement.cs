using System;
using System.Collections.Generic;
using System.Text;
using VisaCheckout.VisaHelper.Attributes;
using VisaCheckout.VisaHelper.Options;

namespace VisaCheckout.VisaHelper.REST
{
    /// <summary>
    /// The REST helper for managing profiles
    /// </summary>
    public class ProfileManagement : VisaRequestBase, IAdminRestRequest
    {
        public const string ProductionUrl = "https://secure.checkout.visa.com/merchant-api/client/profiles/";
        public const string ResourceName = "client/profiles";
        public const string SandboxUrl = "https://sandbox.secure.checkout.visa.com/merchant-api-ic/client/profiles/";

        private string ContentString = null;
        private string QueryParameters = null;

        /// <summary>
        /// The constructor
        /// </summary>
        public ProfileManagement(string apikey)
            : base(ResourceName)
        {
            if (string.IsNullOrEmpty(apikey))
            {
                throw new ArgumentNullException("ApiKey cannot be null");
            }

            ApiKey = apikey;
        }

        /// <summary>
        /// Whether a Canadian merchant accepts Visa Canada debit cards; required for Canadian merchants, otherwise, ignored.
        /// </summary>
        [Option("acceptCanadianVisaDebit")]
        public bool AcceptCanadianVisaDebit { get; set; }

        /// <summary>
        /// (Optional) Initial value for shipping region country codes in the merchant's external profile, which limits selection of eligible addresses in the consumer's account.
        /// </summary>
        [Option("acceptedRegions")]
        public List<string> AcceptedRegions { get; set; }

        /// <summary>
        /// (Required) Public API key, which is different than the shared secret.
        /// </summary>
        [Option("apikey")]
        public string ApiKey { get; set; }

        /// <summary>
        /// (Optional) Billing country codes, which limits selection of eligible cards in the consumer's account. If not set in the profile or overridden for a transaction, payments from all billing countries are accepted.
        /// </summary>
        [Option("billingCountries")]
        public BillingCountries? BillingCountries { get; set; }

        /// <summary>
        /// (Optional) Initial value for brands associated with card art to be displayed or available in the lightbox. If a brand matching the consumer's preferred card is specified, the card art is displayed on the button; otherwise, a generic button is displayed.
        /// </summary>
        [Option("cardBrands")]
        public SupportedCards? CardBrands { get; set; }

        /// <summary>
        /// (Optional) Whether to obtain a shipping address from the consumer.
        /// </summary>
        [Option("collectShipping")]
        public bool? CollectShipping { get; set; }

        /// <summary>
        /// (Optional) Complete URL to merchant's customer support page.
        /// </summary>
        [Option("customerSupportURL")]
        public Uri CustomerSupportUrl { get; set; }

        /// <summary>
        /// Whether to create a default profile.
        /// </summary>
        [Option("defaultProfile")]
        public bool DefaultProfile { get; set; }

        /// <summary>
        /// (Optional) Profile name.
        /// </summary>
        [Option("externalProfileId")]
        public string ExternalProfileID { get; set; }

        /// <summary>
        /// (Optional) The name to display with the logo for cobranding; typically, it is the company name.
        /// </summary>
        [Option("logoDisplayName")]
        public string LogoDisplayName { get; set; }

        /// <summary>
        /// (Optional) Logo to display in the Visa Checkout lightbox; otherwise, the default Visa Checkout logo appears. Your image must not exceed 250 pixels in width and should be 36 pixels high. If the height is not 36 pixels, the height will be expanded or shrunk to fit in exactly 36 pixels.
        /// </summary>
        [Option("logoURL")]
        public Uri LogoUrl { get; set; }

        /// <summary>
        /// The request method
        /// </summary>
        public string Method { get; private set; }

        /// <summary>
        /// (Optional) Whether Verified by Visa is active.
        /// </summary>
        [Option("threeDSActive")]
        public bool? ThreeDSActive { get; set; }

        /// <summary>
        /// (Optional) Brands that are eligible for Verified by Visa.
        /// </summary>
        [Option("threeDSEligibleBrands")]
        public ThreeDSEligibleBrandsOptions ThreeDSEligibleBrands { get; set; }

        /// <summary>
        /// (Optional) Whether to suppress Verified by Visa challenge questions.
        /// </summary>
        [Option("threeDSSuppressChallenge")]
        public bool? ThreeDSSuppressChallenge { get; set; }

        /// <summary>
        /// (Optional) Complete URL to merchant's website.
        /// </summary>
        [Option("websiteURL")]
        public Uri WebsiteUrl { get; set; }

        /// <summary>
        /// Prepares a request to create a profile
        /// </summary>
        /// <returns></returns>
        public void PrepareCreateRequest()
        {
            Method = "POST";

            ContentString = CreateContentString();

            StringBuilder sb = new StringBuilder(WriteOptionalQueryStringValue((ProfileManagement o) => o.ApiKey));
            sb.Append(WriteOptionalQueryStringValue((ProfileManagement o) => o.ExternalProfileID));
            sb.Length = sb.Length - 1;
            QueryParameters = sb.ToString();
        }

        /// <summary>
        /// Prepares a request to delete a profile
        /// </summary>
        public void PrepareDeleteRequest()
        {
            if (string.IsNullOrEmpty(ExternalProfileID))
            {
                throw new ArgumentNullException("ExternalProfileID cannot be null");
            }

            Method = "DELETE";

            StringBuilder sb = new StringBuilder(WriteOptionalQueryStringValue((ProfileManagement o) => o.ApiKey));
            sb.Length = sb.Length - 1;
            QueryParameters = sb.ToString();
        }

        /// <summary>
        /// Prepares a request to query existing profiles
        /// </summary>
        /// <param name="limit">(Optional) The number of results per page; default is 100 clients.</param>
        /// <param name="page">(Optional) The page number; default is the next page, starting from 1.</param>
        /// <returns></returns>
        public void PrepareSelectRequest(byte limit = 100, int page = 1)
        {
            Method = "GET";

            StringBuilder sb = new StringBuilder(WriteOptionalQueryStringValue((ProfileManagement o) => o.ApiKey));

            if (limit != 100)
            {
                sb.Append("limit=").Append(limit).Append("&");
            }

            if (page != 1)
            {
                sb.Append("page=").Append(page).Append("&");
            }

            sb.Length = sb.Length - 1;
            QueryParameters = sb.ToString();
        }

        /// <summary>
        /// Prepares a request to update a given profile
        /// </summary>
        public void PrepareUpdateRequest()
        {
            Method = "PUT";

            ContentString = CreateContentString();

            StringBuilder sb = new StringBuilder(WriteOptionalQueryStringValue((ProfileManagement o) => o.ApiKey));
            sb.Length = sb.Length - 1;
            QueryParameters = sb.ToString();
        }

        /// <summary>
        /// Sends the request to Visa
        /// </summary>
        /// <param name="sharedKey">The private key given by Visa</param>
        /// <param name="responseString">The response from the request</param>
        /// <returns>Whether the request succeeded or failed</returns>
        public bool SendRequest(string sharedKey, out string responseString)
        {
            if (string.IsNullOrEmpty(Method))
            {
                throw new Exception("Web request was not prepared");
            }

            string url = Environment.IsSandbox ? SandboxUrl : ProductionUrl;

            if (!string.IsNullOrEmpty(ExternalProfileID) && Method != "POST")
            {
                url += ExternalProfileID;
                ResourcePath = string.Format("{0}/{1}", ResourcePath, ExternalProfileID);
            }
            else
            {
                ResourcePath = ResourceName;
            }

            return SendWebRequest(url, QueryParameters, Method, ContentString, sharedKey, out responseString);
        }

        private string CreateContentString()
        {
            StringBuilder sb = new StringBuilder("{");
            sb.Append(WriteOptionalJavascriptValue((ProfileManagement o) => o.AcceptCanadianVisaDebit));
            sb.Append(WriteOptionalJavascriptValue((ProfileManagement o) => o.AcceptedRegions));
            sb.Append(WriteOptionalJavascriptValue((ProfileManagement o) => o.BillingCountries));
            sb.Append(WriteOptionalJavascriptValue((ProfileManagement o) => o.CardBrands));
            sb.Append(WriteOptionalJavascriptValue((ProfileManagement o) => o.CollectShipping));
            sb.Append(WriteOptionalJavascriptValue((ProfileManagement o) => o.CustomerSupportUrl));
            sb.Append(WriteOptionalJavascriptValue((ProfileManagement o) => o.DefaultProfile));
            sb.Append(WriteOptionalJavascriptValue((ProfileManagement o) => o.ExternalProfileID));
            sb.Append(WriteOptionalJavascriptValue((ProfileManagement o) => o.LogoDisplayName));
            sb.Append(WriteOptionalJavascriptValue((ProfileManagement o) => o.LogoUrl));
            sb.Append(WriteOptionalJavascriptValue((ProfileManagement o) => o.ThreeDSActive));
            sb.Append(WriteOptionalJavascriptValue((ProfileManagement o) => o.ThreeDSEligibleBrands));
            sb.Append(WriteOptionalJavascriptValue((ProfileManagement o) => o.ThreeDSSuppressChallenge));
            sb.Append(WriteOptionalJavascriptValue((ProfileManagement o) => o.WebsiteUrl));
            sb.Length = sb.Length - 1;
            sb.Append("}");

            return sb.ToString();
        }
    }
}