using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using VisaCheckout.VisaHelper.Options;

namespace VisaCheckout
{
    public static class Extensions
    {
        public static HtmlString WriteVisaCheckoutLink(this HtmlHelper helper)
        {
            return WriteVisaCheckoutLink(helper, null);
        }

        public static HtmlString WriteVisaCheckoutLink(this HtmlHelper helper, VisaOptions options)
        {
            return new HtmlString("");
        }
    }
}
