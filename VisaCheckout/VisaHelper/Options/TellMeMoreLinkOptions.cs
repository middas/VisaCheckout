namespace VisaCheckout.VisaHelper.Options
{
    /// <summary>
    /// Options for displaying the "Tell Me More" link
    /// </summary>
    public class TellMeMoreLinkOptions : IOptions
    {
        /// <summary>
        /// Whether or not the Tell Me More link is displayed.
        /// </summary>
        public bool Display { get; set; }

        /// <summary>
        /// (Optional) The locale, which controls how the pop up text displays in a Tell Me More link.
        /// </summary>
        public string Locale { get; set; }

        /// <summary>
        /// Gets the options HTML.
        /// </summary>
        /// <returns></returns>
        public string GetHtml()
        {
            throw new System.NotImplementedException();
        }
    }
}