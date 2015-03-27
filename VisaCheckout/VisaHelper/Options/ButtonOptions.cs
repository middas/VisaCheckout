namespace VisaCheckout.VisaHelper.Options
{
    /// <summary>
    /// Preset colors of the button.
    /// </summary>
    public enum ButtonColor { Standard, Neutral }

    /// <summary>
    /// Preset widths of the button.
    /// </summary>
    public enum ButtonSize
    {
        /// <summary>
        /// 154 pixels
        /// </summary>
        Small,

        /// <summary>
        /// 213 pixels (default)
        /// </summary>
        Medium,

        /// <summary>
        /// 425 pixels
        /// </summary>
        Large,

        /// <summary>
        /// Custom size defined by Width and Height properties.
        /// </summary>
        Custom
    }

    /// <summary>
    /// Options specific to how the button is displayed.
    /// </summary>
    public class ButtonOptions : IOptions
    {
        /// <summary>
        /// The production URL for the button image
        /// </summary>
        protected const string ProductionButtonUrl = "https://secure.checkout.visa.com/wallet-services-web/xo/button.png";

        /// <summary>
        /// The sandbox URL for the button image
        /// </summary>
        protected const string SandboxButtonUrl = "https://sandbox.secure.checkout.visa.com/ wallet-services-web/xo/button.png";

        /// <summary>
        /// Whether a Canadian merchant accepts Visa Canada debit cards; required for Canadian merchants, otherwise, ignored.
        /// </summary>
        public bool AcceptCanadianVisaDebit { get; set; }

        /// <summary>
        /// (Optional) The color of the Visa Checkout button.
        /// </summary>
        public ButtonColor? Color { get; set; }

        /// <summary>
        /// (Optional) Height of the button, in pixels, for custom button sizes.
        ///
        /// You must specify the height if you specify a value for width. The value you choose determines the range of allowable values for width.
        /// </summary>
        public int? Height { get; set; }

        /// <summary>
        /// (Optional) The locale, which controls how text displays in a Visa Checkout button and the Visa Checkout lightbox. If not specified, the Accepted-Language value in HTTPS header is used, or if not present, en_US is used.
        /// </summary>
        public string Locale { get; set; }

        /// <summary>
        /// (Optional) Width of the button, in pixels.
        ///
        /// You can either specify size to display a standard size button, or you can specify height and width to specify a custom size. If you do not specify size or both height and width, the button size is 213 pixels. If you specify height or width, the value of size is ignored.
        /// </summary>
        public ButtonSize? Size { get; set; }

        /// <summary>
        /// (Optional) Override value for brands associated with card art to be displayed. If a brand matching the consumer's preferred card is specified, the card art is displayed on the button; otherwise, a generic button is displayed.
        /// </summary>
        /// <remarks>
        /// This property supports flags
        /// </remarks>
        public SupportedCards? SupportedCards { get; set; }

        /// <summary>
        /// (Optional) The tab index of the button.
        /// </summary>
        public int? TabIndex { get; set; }

        /// <summary>
        /// (Optional) Width of the button, in pixels, for custom button sizes. You must specify the width if you specify a value for height.
        /// </summary>
        /// <remarks>
        /// Format: It is one of the following values:
        ///
        /// less than 477 if height is 34; default value is 154
        /// greater than 476 and less than 659 if height is 47; default value is 213
        /// greater than 658 and less than 1317 if height is 94; default value is 425
        /// The default value is used if the value for width is invalid for the specified height.
        /// </remarks>
        public int? Width { get; set; }

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