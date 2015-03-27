using System;
using System.Text;
using System.Web.Mvc;

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
    public class VisaOptions : IOptions
    {
        /// <summary>
        /// The production URL for the SDK
        /// </summary>
        public const string ProductionSdkUrl = "https://assets.secure.checkout.visa.com/ checkout-widget/resources/js/integration/v1/sdk.js";

        /// <summary>
        /// The sandbox URL for the SDK
        /// </summary>
        public const string SandboxSdkUrl = "https://sandbox-assets.secure.checkout.visa.com/ checkout-widget/resources/js/integration/v1/sdk.js";

        /// <summary>
        /// (Optional) Defines how the button will be displayed.
        /// </summary>
        public ButtonOptions ButtonOptions { get; set; }

        /// <summary>
        /// (Required) Defines the Javascript init data.
        /// </summary>
        public InitOptions InitOptions { get; set; }

        /// <summary>
        /// (Optional) Defines how the "Tell Me More" link will be displayed.
        /// </summary>
        public TellMeMoreLinkOptions TellMeMoreLinkOptions { get; set; }

        /// <summary>
        /// Gets the options HTML
        /// </summary>
        /// <returns></returns>
        public string GetHtml()
        {
            if (InitOptions == null)
            {
                throw new ArgumentNullException("InitOptions cannot be null");
            }
            TagBuilder scriptTag = new TagBuilder("script");
            scriptTag.Attributes.Add("type", "text\\javascript");

            StringBuilder sb = new StringBuilder(@"function onVisaCheckoutReady(){");
            sb.Append(InitOptions.GetHtml());
            sb.Append("}");

            scriptTag.InnerHtml = sb.ToString();

            return sb.ToString();
        }
    }
}