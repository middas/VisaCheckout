using System.Web.Mvc;

namespace VisaCheckout.VisaHelper.Options
{
    /// <summary>
    /// Options for displaying the "Tell Me More" link
    /// </summary>
    public class TellMeMoreLinkOptions : IOptions
    {
        public TellMeMoreLinkOptions()
        {
            LinkText = "Tell Me More";
        }

        /// <summary>
        /// (Optional) The locale, which controls how the pop up text displays in a Tell Me More link.
        /// </summary>
        public string DataLocale { get; set; }

        /// <summary>
        /// The link text (Default: Tell Me More)
        /// </summary>
        public string LinkText { get; set; }

        /// <summary>
        /// Gets the options HTML.
        /// </summary>
        /// <returns></returns>
        public string GetHtml()
        {
            TagBuilder tag = new TagBuilder("a");
            tag.Attributes.Add("class", "v-learn v-learn-default");
            tag.Attributes.Add("href", "#");
            tag.SetInnerText(LinkText);

            if (!string.IsNullOrEmpty(DataLocale))
            {
                tag.Attributes.Add("data-locale", DataLocale);
            }

            return tag.ToString();
        }
    }
}