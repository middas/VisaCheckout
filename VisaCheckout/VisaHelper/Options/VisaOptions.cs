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
        public const string ProductionSdkUrl = "https://assets.secure.checkout.visa.com/checkout-widget/resources/js/integration/v1/sdk.js";

        /// <summary>
        /// The sandbox URL for the SDK
        /// </summary>
        public const string SandboxSdkUrl = "https://sandbox-assets.secure.checkout.visa.com/checkout-widget/resources/js/integration/v1/sdk.js";

        public VisaOptions(string apiKey, decimal subTotal, CurrencyCodes currencyCode, OnOptions on)
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

            On = on;

            ButtonOptions = new ButtonOptions();
        }

        /// <summary>
        /// (Required) Defines how the button will be displayed.
        /// </summary>
        public ButtonOptions ButtonOptions { get; set; }

        /// <summary>
        /// (Required) Defines the Javascript init data.
        /// </summary>
        public InitOptions InitOptions { get; set; }

        /// <summary>
        /// V.on event handler options
        /// </summary>
        public OnOptions On { get; set; }

        /// <summary>
        /// (Optional) Defines how the "Tell Me More" link will be displayed.
        /// </summary>
        public TellMeMoreLinkOptions TellMeMoreLinkOptions { get; set; }

        /// <summary>
        /// Gets the options HTML.
        /// </summary>
        /// <returns></returns>
        public string GetOptionString()
        {
            if (InitOptions == null)
            {
                throw new ArgumentNullException("InitOptions cannot be null");
            }

            if (ButtonOptions == null)
            {
                throw new ArgumentNullException("ButtonOptions cannot be null");
            }

            if (On == null)
            {
                throw new ArgumentNullException("On event handlers cannot be null");
            }

            StringBuilder sb = new StringBuilder();
            TagBuilder tag = new TagBuilder("script");
            tag.Attributes.Add("type", "text/javascript");
            tag.InnerHtml = string.Format("function onVisaCheckoutReady(){{{0}{1}}}", InitOptions.GetOptionString(), On.GetOptionString());

            sb.Append(tag.ToString()).Append("\r\n");

            tag = new TagBuilder("div");
            tag.Attributes.Add("class", "v-checkout-wrapper");
            tag.InnerHtml = string.Format("{0}\r\n{1}", ButtonOptions.GetOptionString(), TellMeMoreLinkOptions == null ? "" : TellMeMoreLinkOptions.GetOptionString());

            sb.Append(tag.ToString());

            tag = new TagBuilder("script");
            tag.Attributes.Add("type", "text/javascript");
            tag.Attributes.Add("src", Environment.IsSandbox ? SandboxSdkUrl : ProductionSdkUrl);

            sb.Append(tag.ToString());

            return sb.ToString();
        }
    }
}