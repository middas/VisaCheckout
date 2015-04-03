using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VisaCheckout.VisaHelper.Options;

namespace VisaCheckout.VisaHelper.REST
{
    public abstract class VisaRequestBase : OptionsBase
    {
        protected string GenerateToken()
        {
            return "";
        }
    }
}
