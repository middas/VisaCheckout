﻿using System.Collections.Generic;
using System.Text;
using VisaCheckout.VisaHelper.Attributes;

namespace VisaCheckout.VisaHelper.Options
{
    /// <summary>
    /// Shipping options.
    /// </summary>
    public class ShippingOptions : RequestBase, IOptions
    {
        /// <summary>
        /// The constructor
        /// </summary>
        public ShippingOptions()
        {
            AcceptedRegions = new List<string>();
        }

        /// <summary>
        /// (Optional) Override value for shipping region country codes in the merchant's external profile, which limits selection of eligible addresses in the consumer's account.
        /// </summary>
        [Option("acceptedRegions")]
        public List<string> AcceptedRegions { get; set; }

        /// <summary>
        /// (Optional) Whether to obtain a shipping address from the consumer. (default true)
        /// </summary>
        [Option("collectShipping")]
        public bool CollectShipping { get; set; }

        /// <summary>
        /// Gets the options HTML.
        /// </summary>
        /// <returns></returns>
        public string GetOptionString()
        {
            StringBuilder sb = new StringBuilder("\"shipping\":{");

            sb.Append(WriteOptionalJavascriptValue((ShippingOptions o) => o.AcceptedRegions));
            sb.Append(WriteOptionalJavascriptValue((ShippingOptions o) => o.CollectShipping));

            if (sb[sb.Length - 1] == ',')
            {
                sb.Length = sb.Length - 1;
            }
            sb.Append("}");

            return sb.ToString();
        }
    }
}