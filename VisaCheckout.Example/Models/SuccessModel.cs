using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VisaCheckout.Example.Models
{
    public class SuccessModel
    {
        public string EncryptedData { get; set; }
        public string UnencryptedData { get; set; }
    }
}