using System;

namespace VisaCheckout.VisaHelper.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class OptionAttribute : Attribute
    {
        public OptionAttribute(string apiName)
        {
            ApiName = apiName;
        }

        public string ApiName { get; set; }
    }
}