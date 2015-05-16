using System.Text;
using VisaCheckout.VisaHelper.Attributes;

namespace VisaCheckout.VisaHelper.Options
{
    /// <summary>
    /// The order information options
    /// </summary>
    public class OrderInfoOptions : RequestBase, IOptions
    {
        /// <summary>
        /// The constructor
        /// </summary>
        /// <param name="total"></param>
        /// <param name="currencyCode"></param>
        /// <param name="subtotal"></param>
        /// <param name="eventTypes"></param>
        public OrderInfoOptions(decimal total, CurrencyCodes currencyCode, decimal subtotal, EventTypes eventTypes)
        {
            Total = total;
            CurrencyCode = currencyCode;
            Subtotal = subtotal;
            EventType = eventTypes;
        }

        /// <summary>
        /// (Required) The currency with which to process the transaction. Required because total must be provided.
        /// </summary>
        [Option("currencyCode")]
        public CurrencyCodes CurrencyCode { get; set; }

        /// <summary>
        /// (Optional) Total of discounts related to the payment. If provided, it is a positive value representing the amount to be deducted from the total.
        /// </summary>
        [Option("discount")]
        public decimal? Discount { get; set; }

        /// <summary>
        /// (Required) Kind of event associated with the update.
        /// </summary>
        [Option("eventType")]
        public EventTypes EventType { get; set; }

        /// <summary>
        /// (Optional) Total gift-wrapping charges in the payment.
        /// </summary>
        [Option("giftWrap")]
        public decimal? GiftWrap { get; set; }

        /// <summary>
        /// (Optional) Total uncategorized charges in the payment.
        /// </summary>
        [Option("misc")]
        public decimal? Misc { get; set; }

        /// <summary>
        /// (Optional) Merchant's order ID associated with the payment.
        /// </summary>
        [Option("orderId")]
        public string OrderID { get; set; }

        /// <summary>
        /// (Optional) Promotion codes associated with the payment. Multiple promotion codes are separated by a period (.).
        /// </summary>
        [Option("promoCode")]
        public string PromoCode { get; set; }

        /// <summary>
        /// (Optional) Reason for the update.
        /// </summary>
        [Option("reason")]
        public string Reason { get; set; }

        /// <summary>
        /// (Optional) Total of shipping and handling charges for the payment.
        /// </summary>
        [Option("shippingHandling")]
        public decimal? ShippingHandling { get; set; }

        /// <summary>
        /// (Required) Subtotal of the payment.
        /// </summary>
        [Option("subtotal")]
        public decimal Subtotal { get; set; }

        /// <summary>
        /// (Optional) Total tax-related charges in the payment
        /// </summary>
        [Option("tax")]
        public decimal? Tax { get; set; }

        /// <summary>
        /// (Required) Total of the payment including all amounts.
        /// </summary>
        [Option("total")]
        public decimal Total { get; set; }

        /// <summary>
        /// Gets the options HTML.
        /// </summary>
        /// <returns></returns>
        public string GetOptionString()
        {
            StringBuilder sb = new StringBuilder("\"orderInfo\":{");
            sb.Append(WriteOptionalJavascriptValue((OrderInfoOptions o) => o.CurrencyCode));
            sb.Append(WriteOptionalJavascriptValue((OrderInfoOptions o) => o.Discount));
            sb.Append(WriteOptionalJavascriptValue((OrderInfoOptions o) => o.EventType));
            sb.Append(WriteOptionalJavascriptValue((OrderInfoOptions o) => o.GiftWrap));
            sb.Append(WriteOptionalJavascriptValue((OrderInfoOptions o) => o.Misc));
            sb.Append(WriteOptionalJavascriptValue((OrderInfoOptions o) => o.OrderID));
            sb.Append(WriteOptionalJavascriptValue((OrderInfoOptions o) => o.PromoCode));
            sb.Append(WriteOptionalJavascriptValue((OrderInfoOptions o) => o.Reason));
            sb.Append(WriteOptionalJavascriptValue((OrderInfoOptions o) => o.ShippingHandling));
            sb.Append(WriteOptionalJavascriptValue((OrderInfoOptions o) => o.Subtotal));
            sb.Append(WriteOptionalJavascriptValue((OrderInfoOptions o) => o.Tax));
            sb.Append(WriteOptionalJavascriptValue((OrderInfoOptions o) => o.Total));

            sb.Length = sb.Length - 1;
            sb.Append("}");

            return sb.ToString();
        }
    }
}