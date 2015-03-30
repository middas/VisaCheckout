using System.Text;

namespace VisaCheckout.VisaHelper.Options
{
    /// <summary>
    /// Options for the "V.on" events
    /// </summary>
    public class OnOptions : IOptions
    {
        /// <summary>
        /// On payment cancel Javascript
        ///
        /// function(payment) { ... }
        /// </summary>
        public string PaymentCancel { get; set; }

        /// <summary>
        /// On payment error Javascript
        ///
        /// function(payment) { ... }
        /// </summary>
        public string PaymentError { get; set; }

        /// <summary>
        /// On payment success Javascript
        ///
        /// function(payment) { ... }
        /// </summary>
        public string PaymentSuccess { get; set; }

        public string GetHtml()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(string.Format("V.on(\"payment.success\", function(payment){{{0}}});", PaymentSuccess));
            sb.Append(string.Format("V.on(\"payment.cancel\", function(payment){{{0}}});", PaymentCancel));
            sb.Append(string.Format("V.on(\"payment.error\", function(payment){{{0}}});", PaymentError));

            return sb.ToString();
        }
    }
}