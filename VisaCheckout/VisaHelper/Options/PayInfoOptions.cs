using System.Text;
using VisaCheckout.VisaHelper.Attributes;

namespace VisaCheckout.VisaHelper.Options
{
    /// <summary>
    /// The payment information options
    /// </summary>
    public class PayInfoOptions : OptionsBase, IOptions
    {
        /// <summary>
        /// The constructor
        /// </summary>
        /// <param name="eventType"></param>
        /// <param name="eventStatus"></param>
        /// <param name="currencyCode"></param>
        /// <param name="total"></param>
        public PayInfoOptions(PayEventTypes eventType, EventStatuses eventStatus, CurrencyCodes currencyCode, decimal total)
        {
            EventType = eventType;
            EventStatus = eventStatus;
            CurrencyCode = currencyCode;
            Total = total;
        }

        /// <summary>
        /// (Optional) Authorization code associated with the transaction.
        /// </summary>
        [Option("authCode")]
        public string AuthCode { get; set; }

        /// <summary>
        /// (Optional) Address verification system response code.
        /// </summary>
        [Option("avsResponseCode")]
        public string AvsResponseCode { get; set; }

        /// <summary>
        /// (Required) The currency with which to process the transaction. Required because total must be provided.
        /// </summary>
        [Option("currencyCode")]
        public CurrencyCodes CurrencyCode { get; set; }

        /// <summary>
        /// (Required) Status of the event.
        /// </summary>
        [Option("eventStatus")]
        public EventStatuses EventStatus { get; set; }

        /// <summary>
        /// (Required) Kind of event associated with the update.
        /// </summary>
        [Option("eventType")]
        public PayEventTypes EventType { get; set; }

        /// <summary>
        /// (Optional) Payment transaction ID associated with the merchant authorization of the payment instrument.
        /// </summary>
        [Option("payTransId")]
        public string PayTransID { get; set; }

        /// <summary>
        /// (Optional) Reason for the update.
        /// </summary>
        [Option("reason")]
        public string Reason { get; set; }

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
            StringBuilder sb = new StringBuilder("\"payInfo\":{");
            sb.Append(WriteOptionalJavascriptValue((PayInfoOptions o) => o.AuthCode, true, true));
            sb.Append(WriteOptionalJavascriptValue((PayInfoOptions o) => o.AvsResponseCode, true, true));
            sb.Append(WriteOptionalJavascriptValue((PayInfoOptions o) => o.CurrencyCode, true, true));
            sb.Append(WriteOptionalJavascriptValue((PayInfoOptions o) => o.EventStatus, true, true));
            sb.Append(WriteOptionalJavascriptValue((PayInfoOptions o) => o.EventType, true, true));
            sb.Append(WriteOptionalJavascriptValue((PayInfoOptions o) => o.PayTransID, true, true));
            sb.Append(WriteOptionalJavascriptValue((PayInfoOptions o) => o.Reason, true, true));
            sb.Append(WriteOptionalJavascriptValue((PayInfoOptions o) => o.Total, true, true));

            sb.Length = sb.Length - 1;
            sb.Append("}");

            return sb.ToString();
        }
    }
}