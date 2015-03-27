using System;
using System.Text;
namespace VisaCheckout.VisaHelper.Options
{
    [Flags]
    public enum BillingCountries
    {
        AR,
        AU,
        BR,
        CA,
        CN,
        CL,
        CO,
        HK,
        MY,
        MX,
        NZ,
        PE,
        SG,
        ZA,
        AE,
        US
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
            sb.Append(WriteOptionalJavascriptValue("acceptCanadianVisaDebit", AcceptCanadianVisaDebit));
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