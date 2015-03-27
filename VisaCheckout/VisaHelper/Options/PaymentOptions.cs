namespace VisaCheckout.VisaHelper.Options
{
    /// <summary>
    /// Payment options.
    /// </summary>
    public class PaymentOptions : IOptions
    {
        /// <summary>
        /// (Optional) Override of whether a Canadian merchant accepts Visa Canada debit cards; ignored for non-Canadian merchants.
        /// </summary>
        public bool AcceptCanadianVisaDebit { get; set; }

        /// <summary>
        /// (Optional) Card brands that are accepted.
        /// </summary>
        public SupportedCards SupportedCards { get; set; }

        /// <summary>
        /// Gets the options HTML
        /// </summary>
        /// <returns></returns>
        public string GetHtml()
        {
            throw new System.NotImplementedException();
        }
    }
}