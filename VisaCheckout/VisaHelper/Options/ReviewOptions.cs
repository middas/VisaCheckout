using System.Text;
using VisaCheckout.VisaHelper.Attributes;

namespace VisaCheckout.VisaHelper.Options
{
    /// <summary>
    /// Review options.
    /// </summary>
    public class ReviewOptions : RequestBase, IOptions
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
        public string GetOptionString()
        {
            StringBuilder sb = new StringBuilder("\"review\":{");

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