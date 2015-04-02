using Newtonsoft.Json;
using System.Web.Mvc;
using VisaCheckout.Example.Models;
using VisaCheckout.VisaHelper;

namespace VisaCheckout.Example.Controllers
{
    public class HomeController : Controller
    {
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
            string unencrypted = handler.DecryptPaymentData("TA0@pG+k9S1OK0{5+1ENOTZ3Mj4ydjWf3FF/oC$c", result.encKey.ToString(), result.encPaymentData.ToString());
            dynamic eData = JsonConvert.DeserializeObject(unencrypted);
            model.UnencryptedData = JsonConvert.SerializeObject(eData, Formatting.Indented);

            return View(model);
        }
    }
}