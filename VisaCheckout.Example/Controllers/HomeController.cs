using Newtonsoft.Json;
using System.Web.Mvc;
using VisaCheckout.Example.Models;
using VisaCheckout.VisaHelper;
using VisaCheckout.VisaHelper.Options;
using VisaCheckout.VisaHelper.REST;

namespace VisaCheckout.Example.Controllers
{
    public class HomeController : Controller
    {
        private const string SharedKey = "TA0@pG+k9S1OK0{5+1ENOTZ3Mj4ydjWf3FF/oC$c";
        private const string ApiKey = "6L54BENENGTFB0JBDE9E139PCi16xnxbxsVKqSetpw_u_kJmc";

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

        public ActionResult GetPaymentData(string callId)
        {
            ViewBag.Message = "Visa Checkout - GetPaymentData result.";
            ViewBag.CallId = callId;

            GetPaymentData request = new GetPaymentData(callId, ApiKey)
            {
                DataLevel = VisaHelper.Options.DataLevels.FULL
            };

            string response;
            bool success = request.SendRequest(SharedKey, out response);
            SuccessModel model = new SuccessModel();

            if (success)
            {
                dynamic result = JsonConvert.DeserializeObject(response);
                model.UnencryptedData = JsonConvert.SerializeObject(result, Formatting.Indented);
            }
            else
            {
                TempData.Add("error", response);
            }

            return View(model);
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

            ViewBag.CallID = result.callid;

            return View(model);
        }

        public ActionResult UpdatePayment(string callId)
        {
            ViewBag.Message = "Visa Checkout - UpdatePayment result.";
            ViewBag.CallId = callId;

            UpdatePaymentInfo request = new UpdatePaymentInfo(callId, ApiKey)
            {
                //OrderInfo = new OrderInfoOptions(101M, CurrencyCodes.USD, 80.1M, EventTypes.Create)
                //{
                //    ShippingHandling = 5.1M,
                //    Tax = 7.1M,
                //    Discount = 5.25M,
                //    GiftWrap = 10.1M,
                //    Misc = 3.2M,
                //    OrderID = "testorderID",
                //    PromoCode = "testPromoCode",
                //    Reason = "Order Successfully Created"
                //},
                PayInfo = new PayInfoOptions(PayEventTypes.Authorize, EventStatuses.Success, CurrencyCodes.USD, 101M)
                {
                    AvsResponseCode = "V"
                }
            };

            string response;
            bool success = request.SendRequest(SharedKey, out response);
            SuccessModel model = new SuccessModel();
            dynamic result = JsonConvert.DeserializeObject(response);

            if (success)
            {
                model.UnencryptedData = JsonConvert.SerializeObject(result, Formatting.Indented);
            }
            else
            {
                TempData.Add("error", JsonConvert.SerializeObject(result, Formatting.Indented));
            }

            return View(model);
        }
    }
}