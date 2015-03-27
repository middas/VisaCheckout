namespace VisaCheckout.VisaHelper.Options
{
    /// <summary>
    /// Shipping options.
    /// </summary>
    public class ShippingOptions
    {
        /// <summary>
        /// (Optional) Override value for shipping region country codes in the merchant's external profile, which limits selection of eligible addresses in the consumer's account.
        /// </summary>
        public string AcceptedRegions { get; set; }

        /// <summary>
        /// (Optional) Whether to obtain a shipping address from the consumer.
        /// </summary>
        public bool CollectShipping { get; set; }
    }
}