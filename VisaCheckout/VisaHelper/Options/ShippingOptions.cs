using System.Text;

namespace VisaCheckout.VisaHelper.Options
{
    /// <summary>
    /// Shipping options.
    /// </summary>
    public class ShippingOptions : OptionsBase, IOptions
    {
        /// <summary>
        /// (Optional) Override value for shipping region country codes in the merchant's external profile, which limits selection of eligible addresses in the consumer's account.
        /// </summary>
        public string AcceptedRegions { get; set; }

        /// <summary>
        /// (Optional) Whether to obtain a shipping address from the consumer. (default true)
        /// </summary>
        public bool CollectShipping { get; set; }

        /// <summary>
        /// Gets the options HTML.
        /// </summary>
        /// <returns></returns>
        public string GetHtml()
        {
            StringBuilder sb = new StringBuilder("shipping:{");

            sb.Append(WriteOptionalJavascriptValue("acceptedRegions", AcceptedRegions));
            sb.Append(WriteOptionalJavascriptValue("collectShipping", CollectShipping));

            if (sb[sb.Length - 1] == ',')
            {
                sb.Length = sb.Length - 1;
            }
            sb.Append("}");

            return sb.ToString();
        }
    }
}