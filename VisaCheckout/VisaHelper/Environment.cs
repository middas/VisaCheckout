using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VisaCheckout.VisaHelper
{
    /// <summary>
    /// Environment setup
    /// </summary>
    public static class Environment
    {
        /// <summary>
        /// Whether the environment is sandbox or production
        /// </summary>
        public static bool IsSandbox { get; set; }
    }
}
