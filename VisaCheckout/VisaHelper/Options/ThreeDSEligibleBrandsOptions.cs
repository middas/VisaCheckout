using System;
using System.Text;
using VisaCheckout.VisaHelper.Attributes;

namespace VisaCheckout.VisaHelper.Options
{
    /// <summary>
    /// Options for three DS eligible brands
    /// </summary>
    public class ThreeDSEligibleBrandsOptions : OptionsBase, IOptions
    {
        /// <summary>
        /// The constructor
        /// </summary>
        /// <param name="acquirerID"></param>
        /// <param name="cardBrands"></param>
        public ThreeDSEligibleBrandsOptions(string acquirerID, SupportedCards cardBrands)
        {
            AcquirerID = acquirerID;
            CardBrands = cardBrands;
        }

        /// <summary>
        /// (Required) Acquirer ID associated with the processor.
        /// </summary>
        [Option("acquirerId")]
        public string AcquirerID { get; set; }

        /// <summary>
        /// (Required) Card brands.
        /// </summary>
        [Option("cardBrands")]
        public SupportedCards CardBrands { get; set; }

        /// <summary>
        /// Gets the options HTML
        /// </summary>
        /// <returns></returns>
        public string GetOptionString()
        {
            if (string.IsNullOrEmpty(AcquirerID))
            {
                throw new ArgumentException("AcquirerID cannot be null");
            }

            StringBuilder sb = new StringBuilder("\"threeDSEligibleBrands\":{");
            sb.Append(WriteOptionalJavascriptValue((ThreeDSEligibleBrandsOptions o) => o.AcquirerID));
            sb.Append(WriteOptionalJavascriptValue((ThreeDSEligibleBrandsOptions o) => o.CardBrands));

            sb.Length = sb.Length - 1;
            sb.Append("}");

            return sb.ToString();
        }
    }
}