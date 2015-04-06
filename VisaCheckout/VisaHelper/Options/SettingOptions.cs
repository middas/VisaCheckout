using System;
using System.Text;
using VisaCheckout.VisaHelper.Attributes;

namespace VisaCheckout.VisaHelper.Options
{
    /// <summary>
    /// The response data level values.
    /// </summary>
    public enum DataLevels
    {
        /// <summary>
        /// Summary information (default)
        /// </summary>
        SUMMARY,

        /// <summary>
        /// Full information, which is only available if you are configured to receive it.
        /// </summary>
        FULL,

        /// <summary>
        /// Consumer and payment information is not returned in the payment.success event response, in which case the Get Payment Data API must be used to obtain the information.
        /// </summary>
        NONE
    }

    /// <summary>
    /// Settings specific to the Javascript init.
    /// </summary>
    public class SettingOptions : OptionsBase, IOptions
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
        [Option("countryCode")]
        public string CountryCode { get; set; }

        /// <summary>
        /// (Optional) Your complete customer service or support URL.
        /// </summary>
        [Option("customerSupportUrl")]
        public Uri CustomerSupportUrl { get; set; }

        /// <summary>
        /// (Optional) Whether the payment.success event response should include summary information or full information. Permission to receive full information must be configured in Visa Checkout; otherwise, you will always receive only summary information, regardless of the data value you specify.
        /// </summary>
        [Option("dataLevel")]
        public DataLevels? DataLevel { get; set; }

        /// <summary>
        /// (Optional) The merchant's name as it appears on the Review panel of the lightbox; typically, it is the name of your company.
        /// </summary>
        [Option("displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// (Optional) Override value for the locale, which controls how text displays in the Visa Checkout checkout button and lightbox. By default, Visa Checkout determines the locale from the consumer's browser settings. Do not use the locale attribute unless explicit control over the button or lightbox locale is required.
        /// </summary>
        [Option("locale")]
        public string Locale { get; set; }

        /// <summary>
        /// (Optional) Absolute secure (HTTPS) URL path to the logo to display in the Visa Checkout lightbox; otherwise, the default Visa Checkout logo appears.
        ///
        /// Your image must not exceed 174 pixels in width and should be 34 pixels high; oversize logos will be scaled to fit.
        /// </summary>
        [Option("logoUrl")]
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
        /// (Optional) Verified by Visa setup properties.
        /// </summary>
        public ThreeDSSetupOptions ThreeDSSetup { get; set; }

        /// <summary>
        /// (Optional) Complete URL to your website.
        /// </summary>
        [Option("websiteUrl")]
        public Uri WebsiteUrl { get; set; }

        /// <summary>
        /// Gets the options HTML.
        /// </summary>
        /// <returns></returns>
        public string GetOptionString()
        {
            StringBuilder sb = new StringBuilder("settings:{");

            sb.Append(WriteOptionalJavascriptValue((SettingOptions o) => o.Locale));
            sb.Append(WriteOptionalJavascriptValue((SettingOptions o) => o.CountryCode));
            sb.Append(WriteOptionalJavascriptValue((SettingOptions o) => o.LogoUrl));
            sb.Append(WriteOptionalJavascriptValue((SettingOptions o) => o.DisplayName));
            sb.Append(WriteOptionalJavascriptValue((SettingOptions o) => o.WebsiteUrl));
            sb.Append(WriteOptionalJavascriptValue((SettingOptions o) => o.CustomerSupportUrl));
            sb.Append(WriteOptionalJavascriptValue(null, Shipping));
            sb.Append(WriteOptionalJavascriptValue(null, Review));
            sb.Append(WriteOptionalJavascriptValue(null, Payment));
            sb.Append(WriteOptionalJavascriptValue(null, ThreeDSSetup));
            sb.Append(WriteOptionalJavascriptValue((SettingOptions o) => o.DataLevel));

            if (sb[sb.Length - 1] == ',')
            {
                sb.Length = sb.Length - 1;
            }
            sb.Append("}");

            return sb.ToString();
        }
    }
}