using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VisaCheckout.VisaHelper.REST
{
    public interface IVisaRestRequest
    {
        bool SendRequest(string sharedKey, out string responseString);
    }
}
