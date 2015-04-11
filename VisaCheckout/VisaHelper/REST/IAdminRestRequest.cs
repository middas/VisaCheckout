using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VisaCheckout.VisaHelper.REST
{
    public interface IAdminRestRequest : IVisaRestRequest
    {
        string Create();
        string Update();
        string Delete();
    }
}
