using System;
using System.Collections.Generic;
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
        public const string ResourceName = "client/profiles/";
        public const string SandboxUrl = "https://sandbox.secure.checkout.visa.com/merchant-api-ic/client/profiles/";

        /// <summary>
        /// The constructor
        /// </summary>
        public ProfileManagement()
            : base(ResourceName)
        {
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
        public BillingCountries BillingCountries { get; set; }

        /// <summary>
        /// (Optional) Initial value for brands associated with card art to be displayed or available in the lightbox. If a brand matching the consumer's preferred card is specified, the card art is displayed on the button; otherwise, a generic button is displayed.
        /// </summary>
        [Option("cardBrands")]
        public SupportedCards CardBrands { get; set; }

        /// <summary>
        /// (Optional) Whether to obtain a shipping address from the consumer.
        /// </summary>
        [Option("collectShipping")]
        public bool CollectShipping { get; set; }

        /// <summary>
        /// (Optional) Complete URL to merchant's customer support page.
        /// </summary>
        [Option("customerSupportUrl")]
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
        [Option("logoUrl")]
        public Uri LogoUrl { get; set; }

        /// <summary>
        /// The request method
        /// </summary>
        public string Method { get; private set; }

        /// <summary>
        /// (Optional) Whether Verified by Visa is active.
        /// </summary>
        [Option("threeDSActive")]
        public bool ThreeDSActive { get; set; }

        /// <summary>
        /// (Optional) Brands that are eligible for Verified by Visa.
        /// </summary>
        [Option("threeDSEligibleBrands")]
        public ThreeDSEligibleBrandsOptions ThreeDSEligibleBrands { get; set; }

        /// <summary>
        /// (Optional) Whether to suppress Verified by Visa challenge questions.
        /// </summary>
        [Option("threeDSSuppressChallenge")]
        public bool ThreeDSSuppressChallenge { get; set; }

        /// <summary>
        /// (Optional) Complete URL to merchant's website.
        /// </summary>
        [Option("websiteUrl")]
        public Uri WebsiteUrl { get; set; }

        /// <summary>
        /// Prepares a request to create a profile
        /// </summary>
        /// <returns></returns>
        public string PrepareCreateRequest()
        {
            throw new NotImplementedException();
        }

        public string PrepareDeleteRequest()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Prepares a request to query existing profiles
        /// </summary>
        /// <param name="limit">(Optional) The number of results per page; default is 100 clients.</param>
        /// <param name="page">(Optional) The page number; default is the next page, starting from 1.</param>
        /// <returns></returns>
        public string PrepareSelectRequest(byte limit = 100, int page = 1)
        {
            throw new NotImplementedException();
        }

        public string PrepareUpdateRequest()
        {
            throw new NotImplementedException();
        }

        public bool SendRequest(string sharedKey, out string responseString)
        {
            throw new NotImplementedException();
        }
    }
}