using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VisaCheckout.VisaHelper.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class OptionAttribute : Attribute
    {
        public string ApiName { get; set; }

        public OptionAttribute(string apiName)
        {
            ApiName = apiName;
        }
    }
}
