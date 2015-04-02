using System.Text;
using VisaCheckout.VisaHelper.Attributes;

namespace VisaCheckout.VisaHelper.Options
{
    /// <summary>
    /// Possible button actions on the Review page
    /// </summary>
    public enum ButtonActions
    {
        /// <summary>
        /// Display Continue on the lightbox button (default)
        /// </summary>
        Continue,

        /// <summary>
        /// Pay - Display Pay on the lightbox button
        ///
        /// Note: A value for total must be specified; otherwise Continue will be displayed.
        /// </summary>
        Pay
    }

    /// <summary>
    /// Review options.
    /// </summary>
    public class ReviewOptions : OptionsBase, IOptions
    {
        /// <summary>
        /// (Optional) The button label in the Visa Checkout lightbox.
        /// </summary>
        [Option("buttonAction")]
        public ButtonActions? ButtonAction { get; set; }

        /// <summary>
        /// (Optional) Your message to display on the Review page. You are responsible for translating the message.
        /// </summary>
        [Option("message")]
        public string Message { get; set; }

        /// <summary>
        /// Gets the options HTML.
        /// </summary>
        /// <returns></returns>
        public string GetHtml()
        {
            StringBuilder sb = new StringBuilder("review:{");

            sb.Append(WriteOptionalJavascriptValue((ReviewOptions o) => o.Message));
            sb.Append(WriteOptionalJavascriptValue((ReviewOptions o) => o.ButtonAction));

            if (sb[sb.Length - 1] == ',')
            {
                sb.Length = sb.Length - 1;
            }
            sb.Append("}");

            return sb.ToString();
        }
    }
}