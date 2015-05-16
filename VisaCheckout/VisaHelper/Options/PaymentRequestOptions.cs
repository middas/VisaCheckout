using System.Collections.Generic;
using System.Linq;
using System.Text;
using VisaCheckout.VisaHelper.Attributes;

namespace VisaCheckout.VisaHelper.Options
{
    /// <summary>
    /// Payment request options.
    /// </summary>
    public class PaymentRequestOptions : RequestBase, IOptions
    {
        public PaymentRequestOptions()
        {
            CustomData = new Dictionary<string, string>();
        }

        /// <summary>
        /// (Required) The currency with which to process the transaction.
        /// </summary>
        [Option("currencyCode")]
        public CurrencyCodes CurrencyCode { get; set; }

        /// <summary>
        /// (Optional) Merchant-supplied data, as name-value pairs
        ///
        /// Format: Alphanumeric; maximum 1024 characters
        /// </summary>
        [Option("customData")]
        public Dictionary<string, string> CustomData { get; set; }

        /// <summary>
        /// (Optional) Description associated with the payment.
        ///
        /// Format: Alphanumeric; maximum 100 characters
        /// </summary>
        [Option("description")]
        public string Description { get; set; }

        /// <summary>
        /// (Optional) Total of discounts related to the payment. If provided, it is a positive value representing the amount to be deducted from the total.
        /// </summary>
        [Option("discount")]
        public decimal? Discount { get; set; }

        /// <summary>
        /// (Optional) Total gift-wrapping charges in the payment.
        /// </summary>
        [Option("giftWrap")]
        public decimal? GiftWrap { get; set; }

        /// <summary>
        /// (Optional) Merchant's ID associated with the request. Visa Checkout stores this value for your use as a convenience.
        ///
        /// Format: Alphanumeric; maximum 100 characters
        /// </summary>
        [Option("merchantRequestId")]
        public string MerchantRequestID { get; set; }

        /// <summary>
        /// (Optional) Total uncategorized charges in the payment.
        /// </summary>
        [Option("misc")]
        public decimal? Misc { get; set; }

        /// <summary>
        /// (Optional) Merchant's order ID associated with the payment.
        ///
        /// Format: Alphanumeric; maximum 100 characters
        /// </summary>
        [Option("orderId")]
        public string OrderID { get; set; }

        /// <summary>
        /// (Optional) Promotion codes associated with the payment.
        ///
        /// The total length cannot be more than 100 characters
        /// </summary>
        [Option("promoCode")]
        public string PromoCodes { get; set; }

        /// <summary>
        /// (Optional) Total of shipping and handling charges in the payment.
        /// </summary>
        [Option("shippingHandling")]
        public decimal? ShippingHandling { get; set; }

        /// <summary>
        /// (Required) Subtotal of the payment.
        /// </summary>
        [Option("subtotal")]
        public decimal Subtotal { get; set; }

        /// <summary>
        /// (Optional) Total tax-related charges in the payment.
        /// </summary>
        [Option("tax")]
        public decimal? Tax { get; set; }

        /// <summary>
        /// (Optional) Total of the payment including all amounts.
        /// </summary>
        [Option("total")]
        public decimal? Total { get; set; }

        /// <summary>
        /// Gets the options HTML.
        /// </summary>
        /// <returns></returns>
        public string GetOptionString()
        {
            StringBuilder sb = new StringBuilder("\"paymentRequest\":{");

            sb.Append(WriteOptionalJavascriptValue((PaymentRequestOptions o) => o.MerchantRequestID));
            sb.Append(WriteOptionalJavascriptValue((PaymentRequestOptions o) => o.CurrencyCode));
            sb.Append(WriteOptionalJavascriptValue((PaymentRequestOptions o) => o.Subtotal));
            sb.Append(WriteOptionalJavascriptValue((PaymentRequestOptions o) => o.ShippingHandling));
            sb.Append(WriteOptionalJavascriptValue((PaymentRequestOptions o) => o.Tax));
            sb.Append(WriteOptionalJavascriptValue((PaymentRequestOptions o) => o.Discount));
            sb.Append(WriteOptionalJavascriptValue((PaymentRequestOptions o) => o.GiftWrap));
            sb.Append(WriteOptionalJavascriptValue((PaymentRequestOptions o) => o.Misc));
            sb.Append(WriteOptionalJavascriptValue((PaymentRequestOptions o) => o.Total));
            sb.Append(WriteOptionalJavascriptValue((PaymentRequestOptions o) => o.OrderID));
            sb.Append(WriteOptionalJavascriptValue((PaymentRequestOptions o) => o.Description));
            sb.Append(WriteOptionalJavascriptValue((PaymentRequestOptions o) => o.PromoCodes));

            if (CustomData.Count > 0)
            {
                sb.Append(string.Format("\"{0}\":{{\"nvPair\":[{1}]}}", GetApiName(this.GetType().GetProperty("CustomData")), string.Join(",", CustomData.Select(c => string.Format("{{\"name\":\"{0}\",\"value\":\"{1}\"}}", c.Key.ToString(), c.Value.ToString())))));
            }

            if (sb[sb.Length - 1] == ',')
            {
                sb.Length = sb.Length - 1;
            }
            sb.Append("}");

            if (sb[sb.Length - 1] == '&')
            {
                sb.Length = sb.Length - 1;
            }

            return sb.ToString();
        }
    }
}