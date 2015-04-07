using System.Text;
using VisaCheckout.VisaHelper.Attributes;

namespace VisaCheckout.VisaHelper.Options
{
    /// <summary>
    /// Payment options.
    /// </summary>
    public class PaymentOptions : OptionsBase, IOptions
    {
        /// <summary>
        /// (Optional) Override of whether a Canadian merchant accepts Visa Canada debit cards; ignored for non-Canadian merchants.
        /// </summary>
        [Option("acceptCanadianVisaDebit")]
        public bool AcceptCanadianVisaDebit { get; set; }

        /// <summary>
        /// (Optional) Override value for billing country codes in the merchant's external profile, which limits selection of eligible cards in the consumer's account. If not set in the profile or overridden here, payments from all billing countries are accepted.
        /// </summary>
        [Option("billingCountries")]
        public BillingCountries? BillingCountries { get; set; }

        /// <summary>
        /// (Optional) Card brands that are accepted.
        /// </summary>
        [Option("cardBrands")]
        public SupportedCards CardBrands { get; set; }

        /// <summary>
        /// Gets the options HTML.
        /// </summary>
        /// <returns></returns>
        public string GetOptionString()
        {
            StringBuilder sb = new StringBuilder("payment:{");

            sb.Append(WriteOptionalJavascriptValue((PaymentOptions o) => o.CardBrands));
            sb.Append(WriteOptionalJavascriptValue((PaymentOptions o) => o.AcceptCanadianVisaDebit));
            sb.Append(WriteOptionalJavascriptValue((PaymentOptions o) => o.BillingCountries));

            if (sb[sb.Length - 1] == ',')
            {
                sb.Length = sb.Length - 1;
            }
            sb.Append("}");

            return sb.ToString();
        }
    }
}