using System;

namespace VisaCheckout.VisaHelper.Options
{
    /// <summary>
    /// Transaction event types
    /// </summary>
    public enum EventTypes
    {
        Create,
        Confirm,
        Cancel,
        Fraud,
        Other
    }

    /// <summary>
    /// Visa Update Image options.
    /// </summary>
    public class VisaUpdateImageOptions : IOptions
    {
        public const string ProductionUrl = "https://secure.checkout.visa.com/wallet-services-web/payment/updatepaymentinfo.gif";
        public const string SandboxUrl = "https://sandbox.secure.checkout.visa.com/wallet-services-web/payment/updatepaymentinfo.gif";

        private string SharedKey;

        /// <summary>
        /// The constructor
        /// </summary>
        /// <param name="sharedKey">The private shared key from Visa</param>
        /// <param name="callId">The CallID value from VisaResponse.success</param>
        /// <param name="eventType">The event type of this transaction</param>
        /// <param name="apiKey">The public API Key from Visa</param>
        /// <param name="subtotal">The subtotal of the transaction</param>
        /// <param name="total">The total of the transaction</param>
        /// <param name="currencyCode">The currency code value</param>
        public VisaUpdateImageOptions(string sharedKey, string callId, EventTypes eventType, string apiKey, decimal subtotal, decimal total, CurrencyCodes currencyCode)
        {
        }

        /// <summary>
        /// The constructor
        /// </summary>
        /// <param name="sharedKey">The private shared key from Visa</param>
        /// <param name="callId">The CallID value from VisaResponse.success</param>
        /// <param name="eventType">The event type of this transaction</param>
        /// <param name="paymentRequestOptions">The <see cref="PaymentRequestOptions"/> to populate the properties from</param>
        public VisaUpdateImageOptions(string sharedKey, string callId, EventTypes eventType, PaymentRequestOptions paymentRequestOptions)
        {
        }

        /// <summary>
        /// (Required) Your public API key, which is different than your shared secret.
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// (Required) Visa Checkout transaction ID returned by the Visa Checkoutpayment.successevent.
        /// </summary>
        public string CallID { get; set; }

        /// <summary>
        /// (Required) The currency with which to process the transaction. Required because total must be provided.
        /// </summary>
        public CurrencyCodes CurrencyCode { get; set; }

        /// <summary>
        /// (Optional) Total of discounts related to the payment. If provided, it is a positive value representing the amount to be deducted from the total.
        /// </summary>
        public decimal? Discount { get; set; }

        /// <summary>
        /// (Required) Kind of event associated with the update.
        /// </summary>
        public EventTypes EventType { get; set; }

        /// <summary>
        /// (Optional) Total gift-wrapping charges in the payment.
        /// </summary>
        public decimal? GiftWrap { get; set; }

        /// <summary>
        /// (Optional) Total uncategorized charges in the payment.
        /// </summary>
        public decimal? Misc { get; set; }

        /// <summary>
        /// (Optional) Merchant's order ID associated with the payment.
        /// </summary>
        public string OrderID { get; set; }

        /// <summary>
        ///  (Optional) Promotion codes associated with the payment. Multiple promotion codes are separated by a period (.).
        /// </summary>
        public string PromoCode { get; set; }

        /// <summary>
        /// (Optional) Reason for the update
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// (Optional)Total of shipping and handling charges for the payment.
        /// </summary>
        public decimal? ShippingHandling { get; set; }

        /// <summary>
        /// (Required) Subtotal of the payment.
        /// </summary>
        public decimal Subtotal { get; set; }

        /// <summary>
        /// (Optional) Total tax-related charges in the payment.
        /// </summary>
        public decimal? Tax { get; set; }

        /// <summary>
        /// (Required) Total of the payment including all amounts.
        /// </summary>
        public decimal Total { get; set; }

        /// <summary>
        /// Gets the options HTML.
        /// </summary>
        /// <returns></returns>
        public string GetHtml()
        {
            throw new NotImplementedException();
        }

        private string GenerateToken()
        {
            throw new NotImplementedException();
        }
    }
}