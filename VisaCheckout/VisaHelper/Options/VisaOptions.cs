using System;

namespace VisaCheckout.VisaHelper.Options
{
    /// <summary>
    /// The cards that you support charging.
    /// </summary>
    [Flags]
    public enum SupportedCards
    {
        VISA = 1,
        AMEX = 2,
        MASTERCARD = 4,
        DISCOVER = 8
    }

    /// <summary>
    /// Options to define how the Visa controls are displayed.
    /// </summary>
    public class VisaOptions
    {
        private const string ProductionSdkUrl = "";
        private const string SandboxSdkUrl = "";

        /// <summary>
        /// (Required) The API key that Visa Checkout created when you created the Visa Checkout account. You will use both a live key and a sandbox key, which are different from each other.
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// (Optional) Defines how the button will be displayed.
        /// </summary>
        public ButtonOptions ButtonOptions { get; set; }

        /// <summary>
        /// (Optional) Defines how the "Tell Me More" link will be displayed.
        /// </summary>
        public TellMeMoreLinkOptions TellMeMoreLinkOptions { get; set; }
    }
}