using System.Web.Mvc;
using VisaCheckout.VisaHelper.Attributes;

namespace VisaCheckout.VisaHelper.Options
{
    /// <summary>
    /// Options for displaying the "Tell Me More" link
    /// </summary>
    public class TellMeMoreLinkOptions : OptionsBase, IOptions
    {
        public TellMeMoreLinkOptions()
        {
            LinkText = "Tell Me More";
        }

        /// <summary>
        /// (Optional) The locale, which controls how the pop up text displays in a Tell Me More link.
        /// </summary>
        [Option("data-locale")]
        public string DataLocale { get; set; }

        /// <summary>
        /// The link text (Default: Tell Me More)
        /// </summary>
        public string LinkText { get; set; }

        /// <summary>
        /// Gets the options HTML.
        /// </summary>
        /// <returns></returns>
        public string GetOptionString()
        {
            TagBuilder tag = new TagBuilder("a");
            tag.Attributes.Add("class", "v-learn v-learn-default");
            tag.Attributes.Add("href", "#");
            tag.SetInnerText(LinkText);

            if (!string.IsNullOrEmpty(DataLocale))
            {
                tag.Attributes.Add(GetApiName(this.GetType().GetProperty("DataLocale")), DataLocale);
            }

            return tag.ToString();
        }
    }
}