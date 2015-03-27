namespace VisaCheckout.VisaHelper.Options
{
    /// <summary>
    /// Payment options.
    /// </summary>
    public class PaymentOptions
    {
        /// <summary>
        /// (Optional) Override of whether a Canadian merchant accepts Visa Canada debit cards; ignored for non-Canadian merchants.
        /// </summary>
        public bool AcceptCanadianVisaDebit { get; set; }

        /// <summary>
        /// (Optional) Card brands that are accepted.
        /// </summary>
        public SupportedCards SupportedCards { get; set; }
    }
}