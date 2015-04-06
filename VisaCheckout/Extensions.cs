using System;
using System.Web;
using System.Web.Mvc;
using VisaCheckout.VisaHelper.Options;

namespace VisaCheckout
{
    public static class Extensions
    {
        /// <summary>
        /// Write the Visa Checkout button and Javascript
        /// </summary>
        /// <param name="helper">The <see cref="HtmlHelper"/></param>
        /// <param name="options">The options for the Visa Checkout button and Javascript <see cref="VisaOptions"/></param>
        /// <returns>The <see cref="HtmlString"/> to render the button</returns>
        /// <exception cref="ArgumentNullException">Thrown when a required parameter is missing</exception>
        public static MvcHtmlString WriteVisaCheckoutLink(this HtmlHelper helper, VisaOptions options)
        {
            return new MvcHtmlString(options.GetOptionString());
        }

        /// <summary>
        /// Write the Visa Checkout update image
        /// </summary>
        /// <param name="helper">The <see cref="HtmlHelper"/></param>
        /// <param name="options">The options for the Visa Checkout update image <see cref="VisaUpdateImageOptions"/></param>
        /// <returns></returns>
        public static MvcHtmlString WriteVisaUpdateImage(this HtmlHelper helper, VisaUpdateImageOptions options)
        {
            return new MvcHtmlString(options.GetOptionString());
        }
    }
}