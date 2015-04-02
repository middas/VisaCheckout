using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Web.Mvc;
using System.Linq;
using System.Web;
using System.Security.Cryptography;

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
    public class VisaUpdateImageOptions : OptionsBase, IOptions
    {
        public const string ProductionUrl = "https://secure.checkout.visa.com/wallet-services-web/payment/updatepaymentinfo.gif";
        public const string SandboxUrl = "https://sandbox.secure.checkout.visa.com/wallet-services-web/payment/updatepaymentinfo.gif";

        private string SharedKey;
        private int TimeStamp;

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
        public VisaUpdateImageOptions(string sharedKey, string callId, EventTypes eventType, int timestamp, string apiKey, decimal subtotal, decimal total, CurrencyCodes currencyCode)
        {
            SharedKey = sharedKey;
            CallID = callId;
            EventType = eventType;
            TimeStamp = timestamp;
            ApiKey = apiKey;
            Subtotal = subtotal;
            Total = total;
            CurrencyCode = currencyCode;
        }

        /// <summary>
        /// The constructor
        /// </summary>
        /// <param name="sharedKey">The private shared key from Visa</param>
        /// <param name="callId">The CallID value from VisaResponse.success</param>
        /// <param name="eventType">The event type of this transaction</param>
        /// <param name="paymentRequestOptions">The <see cref="PaymentRequestOptions"/> to populate the properties from</param>
        public VisaUpdateImageOptions(string sharedKey, string callId, EventTypes eventType, int timestamp, PaymentRequestOptions paymentRequestOptions)
        {
            if (paymentRequestOptions == null)
            {
                throw new ArgumentNullException("paymentRequestOptions", "value cannot be null");
            }

            if (!paymentRequestOptions.Total.HasValue)
            {
                throw new ArgumentNullException("Total cannot be null");
            }

            SharedKey = sharedKey;
            CallID = callId;
            EventType = eventType;
            TimeStamp = timestamp;

            CurrencyCode = paymentRequestOptions.CurrencyCode;
            Discount = paymentRequestOptions.Discount;
            GiftWrap = paymentRequestOptions.GiftWrap;
            Misc = paymentRequestOptions.Misc;
            OrderID = paymentRequestOptions.OrderID;
            PromoCode = paymentRequestOptions.PromoCodes;
            ShippingHandling = paymentRequestOptions.ShippingHandling;
            Subtotal = paymentRequestOptions.Subtotal;
            Tax = paymentRequestOptions.Tax;
            Total = paymentRequestOptions.Total.Value;
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
            TagBuilder tag = new TagBuilder("img");
            StringBuilder sb = new StringBuilder(ProductionUrl).Append("?");
            sb.Append(WriteOptionalQueryStringValue("token", GenerateToken()));
            sb.Append(WriteOptionalQueryStringValue("apikey", ApiKey));
            sb.Append(WriteOptionalQueryStringValue("callId", CallID));
            sb.Append(WriteOptionalQueryStringValue("total", Total));
            sb.Append(WriteOptionalQueryStringValue("currencyCode", CurrencyCode));
            sb.Append(WriteOptionalQueryStringValue("orderId", OrderID));
            sb.Append(WriteOptionalQueryStringValue("promoCode", PromoCode));
            sb.Append(WriteOptionalQueryStringValue("reason", Reason));
            sb.Append(WriteOptionalQueryStringValue("subtotal", Subtotal));
            sb.Append(WriteOptionalQueryStringValue("shippingHandling", ShippingHandling));
            sb.Append(WriteOptionalQueryStringValue("tax", Tax));
            sb.Append(WriteOptionalQueryStringValue("discount", Discount));
            sb.Append(WriteOptionalQueryStringValue("giftWrap", GiftWrap));
            sb.Append(WriteOptionalQueryStringValue("misc", Misc));


            tag.Attributes.Add("src", sb.ToString());

            return tag.ToString(TagRenderMode.SelfClosing);
        }

        /// <summary>
        /// Format: Alphanumeric; maximum 100 characters in the form of token: x:UNIX_UTC_Timestamp:SHA256_hash, where 
        ///     • UNIX_UTC_Timestamp is a UNIX Epoch timestamp 
        ///     • SHA256_hash is an SHA256 hash of the following unseparated items: 
        ///         1. Your shared secret 
        ///         2. Timestamp from the transaction; exactly the same as UNIX_UTC_Timestamp 
        ///         3. Resource path (API name) 
        ///         4. This HTTPS request's query string Note: –The query string includes one or more parameters 
        ///         in name-value pair format, whose names are separated from values by equal signs (=); 
        ///         an empty value may be omitted but the name and equal sign must be present. The initial 
        ///         question mark (?) is not included. All parameters must be present. 
        ///         The parameters must be in lexicographic sort order (UTF-8, uppercase hex characters) with 
        ///         parameters separated from each other by an ampersand (&). The query string must be URL 
        ///         encoded (excepting the following characters, per RFC 3986: hyphen, period, underscore. and tilde). 
        /// </summary>
        /// <returns></returns>
        private string GenerateToken()
        {
            StringBuilder sb = new StringBuilder(SharedKey).Append("payment/info");

            List<PropertyInfo> properties = new List<PropertyInfo>();
            properties.AddRange(typeof(VisaUpdateImageOptions).GetProperties());

            foreach (var property in properties.OrderBy(p => p.Name))
            {
                string name = property.Name;
                name = Char.ToLower(name[0]) + name.Substring(1);
                name = name.Replace("Key", "key");

                string value = WriteOptionalQueryStringValue(name, property.GetValue(this, null));
                if (string.IsNullOrEmpty(value))
                {
                    value = string.Format("{0}=&", name);
                }

                value = HttpUtility.UrlEncode(value);
                sb.Append(value);
            }

            return string.Format("x:{0}:{1}", TimeStamp, Sha256Hash(sb.ToString()));
        }

        private string Sha256Hash(string s)
        {
            SHA256Managed sha = new SHA256Managed();
            byte[] hash = sha.ComputeHash(Encoding.UTF8.GetBytes(s));
            string hashString = "";

            foreach (byte b in hash)
            {
                hashString += string.Format("{0:x2}", b);
            }

            return hashString;
        }
    }
}