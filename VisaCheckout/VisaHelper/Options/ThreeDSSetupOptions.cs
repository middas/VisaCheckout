using System.Text;
using VisaCheckout.VisaHelper.Attributes;

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
        [Option("threeDSActive")]
        public bool? ThreeDSActive { get; set; }

        /// <summary>
        /// Gets the options HTML.
        /// </summary>
        /// <returns></returns>
        public string GetOptionString()
        {
            StringBuilder sb = new StringBuilder("threeDSSetup:{");

            sb.Append(WriteOptionalJavascriptValue((ThreeDSSetupOptions o) => o.ThreeDSActive));

            if (sb[sb.Length - 1] == ',')
            {
                sb.Length = sb.Length - 1;
            }
            sb.Append("}");

            return sb.ToString();
        }
    }
}