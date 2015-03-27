﻿using System.Collections.Generic;

namespace VisaCheckout.VisaHelper.Options
{
    /// <summary>
    /// Possible currency code values
    /// </summary>
    public enum CurrencyCodes
    {
        /// <summary>
        /// US dollars
        /// </summary>
        USD,

        /// <summary>
        /// Canadian dollars
        /// </summary>
        CAD,

        /// <summary>
        /// Australian dollars
        /// </summary>
        AUD
    }

    /// <summary>
    /// Payment request options.
    /// </summary>
    public class PaymentRequestOptions
    {
        /// <summary>
        /// (Required) The currency with which to process the transaction.
        /// </summary>
        public CurrencyCodes CurrencyCode { get; set; }

        /// <summary>
        /// (Optional) Merchant-supplied data, as name-value pairs in JSON format.
        ///
        /// Format: Alphanumeric; maximum 1024 characters
        /// </summary>
        public string CustomData { get; set; }

        /// <summary>
        /// (Optional) Total of discounts related to the payment. If provided, it is a positive value representing the amount to be deducted from the total.
        /// </summary>
        public decimal Discount { get; set; }

        /// <summary>
        /// (Optional) Total gift-wrapping charges in the payment.
        /// </summary>
        public decimal GiftWrap { get; set; }

        /// <summary>
        /// (Optional) Merchant's ID associated with the request. Visa Checkout stores this value for your use as a convenience.
        ///
        /// Format: Alphanumeric; maximum 100 characters
        /// </summary>
        public string MerchantRequestID { get; set; }

        /// <summary>
        /// (Optional) Total uncategorized charges in the payment.
        /// </summary>
        public decimal Misc { get; set; }

        /// <summary>
        /// (Optional) Merchant's order ID associated with the payment.
        ///
        /// Format: Alphanumeric; maximum 100 characters
        /// </summary>
        public string OrderID { get; set; }

        /// <summary>
        /// (Optional) Promotion codes associated with the payment.
        ///
        /// Each promotional code is surrounded by quotes (") and separated by a period (.)
        /// The total length cannot be more than 100 characters
        /// </summary>
        public List<string> PromoCodes { get; set; }

        /// <summary>
        /// (Optional) Total of shipping and handling charges in the payment.
        /// </summary>
        public decimal ShippingHandling { get; set; }

        /// <summary>
        /// (Required) Subtotal of the payment.
        /// </summary>
        public decimal Subtotal { get; set; }

        /// <summary>
        /// (Optional) Total tax-related charges in the payment.
        /// </summary>
        public decimal Tax { get; set; }

        /// <summary>
        /// (Optional) Total of the payment including all amounts.
        /// </summary>
        public decimal Total { get; set; }
    }
}