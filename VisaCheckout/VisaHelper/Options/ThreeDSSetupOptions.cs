using System.Text;

namespace VisaCheckout.VisaHelper.Options
{
    /// <summary>
    /// Three DS Setup options.
    /// </summary>
    public class ThreeDSSetupOptions : OptionsBase, IOptions
    {
        /// <summary>
        /// (Optional) Whether Verified by Visa (VbV) is active for this transaction. If Verified by Visa is configured, you can use threeDSActive to deactivate it for the transaction; otherwise, VbV will be active if it has been configured.
        /// </summary>
        public bool? ThreeDSActive { get; set; }

        /// <summary>
        /// Gets the options HTML.
        /// </summary>
        /// <returns></returns>
        public string GetHtml()
        {
            StringBuilder sb = new StringBuilder("threeDSSetup:{");

            sb.Append(WriteOptionalJavascriptValue("threeDSActive", ThreeDSActive.ToString().ToLower()));

            if (sb[sb.Length - 1] == ',')
            {
                sb.Length = sb.Length - 1;
            }
            sb.Append("}");

            return sb.ToString();
        }
    }
}