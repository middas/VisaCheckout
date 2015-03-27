using System;

namespace VisaCheckout.VisaHelper.Options
{
    /// <summary>
    /// The cards that you support charging
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
    /// Options to define how the Visa controls are displayed
    /// </summary>
    public class VisaOptions
    {
        private const string ProductionSdkUrl = "";
        private const string SandboxSdkUrl = "";

        /// <summary>
        /// (optional) Defines how the button will be displayed
        /// </summary>
        public ButtonOptions ButtonOptions { get; set; }
    }
}