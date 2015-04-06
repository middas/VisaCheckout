using Newtonsoft.Json;
using System.Web.Mvc;
using VisaCheckout.Example.Models;
using VisaCheckout.VisaHelper;

namespace VisaCheckout.Example.Controllers
{
    public class HomeController : Controller
    {
        private const string SharedKey = "TA0@pG+k9S1OK0{5+1ENOTZ3Mj4ydjWf3FF/oC$c";

        [HttpPost]
        public ActionResult Cancel(string response)
        {
            ViewBag.Message = "Visa Checkout - Cancel result.";

            dynamic result = JsonConvert.DeserializeObject(response);
            ViewBag.Result = JsonConvert.SerializeObject(result, Formatting.Indented);

            return View();
        }

        [HttpPost]
        public ActionResult Error(string response)
        {
            ViewBag.Message = "Visa Checkout - Error result.";

            dynamic result = JsonConvert.DeserializeObject(response);
            ViewBag.Result = JsonConvert.SerializeObject(result, Formatting.Indented);

            return View();
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Visa Checkout example.";

            return View();
        }

        [HttpPost]
        public ActionResult Success(string response)
        {
            SuccessModel model = new SuccessModel();
            ViewBag.Message = "Visa Checkout - Success result.";

            dynamic result = JsonConvert.DeserializeObject(response);
            model.EncryptedData = JsonConvert.SerializeObject(result, Formatting.Indented);

            ResponseHandler handler = new ResponseHandler();
            string unencrypted = handler.DecryptPaymentData(SharedKey, result.encKey.ToString(), result.encPaymentData.ToString());
            dynamic eData = JsonConvert.DeserializeObject(unencrypted);
            model.UnencryptedData = JsonConvert.SerializeObject(eData, Formatting.Indented);

            return View(model);
        }

        public ActionResult RestTests()
        {
            ViewBag.Message = "Visa Checkout REST tests.";

            return View();
        }

        [HttpPost]
        public ActionResult SuccessREST(string response)
        {
            SuccessModel model = new SuccessModel();
            ViewBag.Message = "Visa Checkout - Success result.";

            dynamic result = JsonConvert.DeserializeObject(response);
            model.EncryptedData = JsonConvert.SerializeObject(result, Formatting.Indented);

            ResponseHandler handler = new ResponseHandler();
            string unencrypted = handler.DecryptPaymentData(SharedKey, result.encKey.ToString(), result.encPaymentData.ToString());
            dynamic eData = JsonConvert.DeserializeObject(unencrypted);
            model.UnencryptedData = JsonConvert.SerializeObject(eData, Formatting.Indented);

            ViewBag.CallID = result.callid;

            return View(model);
        }

        public ActionResult GetPaymentData(string callId)
        {
            ViewBag.Message = "Visa Checkout - GetPaymentData result.";
            ViewBag.CallId = callId;

            VisaCheckout.VisaHelper.REST.GetPaymentData request = new VisaHelper.REST.GetPaymentData(callId, "6L54BENENGTFB0JBDE9E139PCi16xnxbxsVKqSetpw_u_kJmc")
            {
                DataLevel = VisaHelper.Options.DataLevels.FULL
            };

            string response;
            bool success = request.SendRequest(SharedKey, out response);
            SuccessModel model = new SuccessModel();

            if (success)
            {
                dynamic result = JsonConvert.DeserializeObject(response);
                model.EncryptedData = JsonConvert.SerializeObject(result, Formatting.Indented);
            }
            else
            {
                TempData.Add("error", response);
            }

            return View(model);
        }
    }
}