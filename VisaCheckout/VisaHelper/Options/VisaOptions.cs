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
        public VisaOptions(string apiKey, decimal subTotal, CurrencyCodes currencyCode)
        {
            InitOptions = new InitOptions
            {
                ApiKey = apiKey,
                PaymentRequest = new PaymentRequestOptions
                {
                    CurrencyCode = currencyCode,
                    Subtotal = subTotal
                }
            };

            ButtonOptions = new ButtonOptions();
        }

        /// <summary>
        /// The production URL for the SDK
        /// </summary>
        public const string ProductionSdkUrl = "https://assets.secure.checkout.visa.com/checkout-widget/resources/js/integration/v1/sdk.js";

        /// <summary>
        /// The sandbox URL for the SDK
        /// </summary>
        public const string SandboxSdkUrl = "https://sandbox-assets.secure.checkout.visa.com/checkout-widget/resources/js/integration/v1/sdk.js";

        /// <summary>
        /// (Required) Defines how the button will be displayed.
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
        /// Whether the environment is the sandbox or production
        /// </summary>
        public bool IsSandbox { get; set; }

        /// <summary>
        /// Gets the options HTML.
        /// </summary>
        /// <returns></returns>
        public string GetHtml()
        {
            if (InitOptions == null)
            {
                throw new ArgumentNullException("InitOptions cannot be null");
            }

            if (ButtonOptions == null)
            {
                throw new ArgumentNullException("ButtonOptions cannot be null");
            }

            StringBuilder sb = new StringBuilder();
            TagBuilder tag = new TagBuilder("script");
            tag.Attributes.Add("type", "text/javascript");
            tag.InnerHtml = string.Format("function onVisaCheckoutReady(){{{0}}}", InitOptions.GetHtml());

            sb.Append(tag.ToString()).Append("\r\n");

            tag = new TagBuilder("div");
            tag.Attributes.Add("class", "v-checkout-wrapper");
            tag.InnerHtml = string.Format("{0}\r\n{1}", ButtonOptions.GetHtml(), TellMeMoreLinkOptions == null ? "" : TellMeMoreLinkOptions.GetHtml());

            sb.Append(tag.ToString());

            tag = new TagBuilder("script");
            tag.Attributes.Add("type", "text/javascript");
            tag.Attributes.Add("src", IsSandbox ? SandboxSdkUrl : ProductionSdkUrl);

            sb.Append(tag.ToString());

            return sb.ToString();
        }
    }
}