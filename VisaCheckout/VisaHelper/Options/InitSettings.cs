using System;

namespace VisaCheckout.VisaHelper.Options
{
    /// <summary>
    /// The response data level.
    /// </summary>
    public enum DataLevel
    {
        /// <summary>
        /// Summary information (default)
        /// </summary>
        Summary,

        /// <summary>
        /// Full information, which is only available if you are configured to receive it.
        /// </summary>
        Full
    }

    /// <summary>
    /// Settings specific to the Javascript init.
    /// </summary>
    public class InitSettings : IOptions
    {
        /// <summary>
        /// (Optional) Override value for the country code, which controls how text displays in the Visa Checkout checkout button and lightbox. By default, Visa Checkout determines the country from the consumer's IP address. Do not use the countryCode attribute unless explicit control over the display is required.
        /// </summary>
        /// <remarks>
        /// Format: It is one of the following values:
        ///
        /// US - United States
        /// CA - Canada
        /// AU - Australia
        /// </remarks>
        public string CountryCode { get; set; }

        /// <summary>
        /// (Optional) Your complete customer service or support URL.
        /// </summary>
        public Uri CustomerSupportUrl { get; set; }

        /// <summary>
        /// (Optional) Whether the payment.success event response should include summary information or full information. Permission to receive full information must be configured in Visa Checkout; otherwise, you will always receive only summary information, regardless of the data value you specify.
        /// </summary>
        public DataLevel? DataLevel { get; set; }

        /// <summary>
        /// (Optional) The merchant's name as it appears on the Review panel of the lightbox; typically, it is the name of your company.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// (Optional) Override value for the locale, which controls how text displays in the Visa Checkout checkout button and lightbox. By default, Visa Checkout determines the locale from the consumer's browser settings. Do not use the locale attribute unless explicit control over the button or lightbox locale is required.
        /// </summary>
        public string Locale { get; set; }

        /// <summary>
        /// (Optional) Absolute secure (HTTPS) URL path to the logo to display in the Visa Checkout lightbox; otherwise, the default Visa Checkout logo appears.
        ///
        /// Your image must not exceed 174 pixels in width and should be 34 pixels high; oversize logos will be scaled to fit.
        /// </summary>
        public Uri LogoUrl { get; set; }

        /// <summary>
        /// (Optional) Payment method properties associated with the lightbox.
        /// </summary>
        public PaymentOptions Payment { get; set; }

        /// <summary>
        /// (Optional) Review properties associated with the lightbox.
        /// </summary>
        public ReviewOptions Review { get; set; }

        /// <summary>
        /// (Optional) Shipping properties associated with the lightbox.
        /// </summary>
        public ShippingOptions Shipping { get; set; }

        /// <summary>
        /// (Optional) Complete URL to your website.
        /// </summary>
        public Uri WebsiteUrl { get; set; }

        /// <summary>
        /// Gets the options HTML
        /// </summary>
        /// <returns></returns>
        public string GetHtml()
        {
            throw new NotImplementedException();
        }
    }
}