using System;
using System.Text;
namespace VisaCheckout.VisaHelper.Options
{
    [Flags]
    public enum BillingCountries
    {
        /// <summary>
        /// Argentina
        /// </summary>
        AR = 1,
        /// <summary>
        /// Australia
        /// </summary>
        AU = 2,
        /// <summary>
        /// Brazil
        /// </summary>
        BR = 4,
        /// <summary>
        /// Canada
        /// </summary>
        CA = 8,
        /// <summary>
        /// China
        /// </summary>
        CN = 16,
        /// <summary>
        /// Chile
        /// </summary>
        CL = 32,
        /// <summary>
        /// Colombia
        /// </summary>
        CO = 64,
        /// <summary>
        /// Hong Kong
        /// </summary>
        HK = 128,
        /// <summary>
        /// Malaysia
        /// </summary>
        MY = 256,
        /// <summary>
        /// Mexico
        /// </summary>
        MX = 512,
        /// <summary>
        /// New Zealand
        /// </summary>
        NZ = 1024,
        /// <summary>
        /// Peru
        /// </summary>
        PE = 2048,
        /// <summary>
        /// Singapore
        /// </summary>
        SG = 4096,
        /// <summary>
        /// South Africa
        /// </summary>
        ZA = 8192,
        /// <summary>
        /// United Arab Emirates
        /// </summary>
        AE = 16384,
        /// <summary>
        /// United States
        /// </summary>
        US = 32768
    }

    /// <summary>
    /// Payment options.
    /// </summary>
    public class PaymentOptions : OptionsBase, IOptions
    {
        /// <summary>
        /// (Optional) Override of whether a Canadian merchant accepts Visa Canada debit cards; ignored for non-Canadian merchants.
        /// </summary>
        public bool AcceptCanadianVisaDebit { get; set; }

        /// <summary>
        /// (Optional) Card brands that are accepted.
        /// </summary>
        public SupportedCards CardBrands { get; set; }

        /// <summary>
        /// (Optional) Override value for billing country codes in the merchant's external profile, which limits selection of eligible cards in the consumer's account. If not set in the profile or overridden here, payments from all billing countries are accepted.
        /// </summary>
        public BillingCountries? BillingCountries { get; set; }

        /// <summary>
        /// Gets the options HTML.
        /// </summary>
        /// <returns></returns>
        public string GetHtml()
        {
            StringBuilder sb = new StringBuilder("payment: {");

            sb.Append(WriteOptionalJavascriptValue("cardBrands", CardBrands));
            sb.Append(WriteOptionalJavascriptValue("acceptCanadianVisaDebit", AcceptCanadianVisaDebit.ToString().ToLower()));
            sb.Append(WriteOptionalJavascriptValue("billingCountries", BillingCountries));

            if (sb[sb.Length - 1] == ',')
            {
                sb.Length = sb.Length - 1;
            }
            sb.Append("}");

            return sb.ToString();
        }
    }
}