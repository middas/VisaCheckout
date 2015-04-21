using Newtonsoft.Json;
using System.Web.Mvc;
using VisaCheckout.Example.Models;
using VisaCheckout.VisaHelper.Options;
using VisaCheckout.VisaHelper.REST;

namespace VisaCheckout.Example.Controllers
{
    public class ApiKeyController : Controller
    {
        private const string ApiKey = "6L54BENENGTFB0JBDE9E139PCi16xnxbxsVKqSetpw_u_kJmc";
        private const string SharedKey = "TA0@pG+k9S1OK0{5+1ENOTZ3Mj4ydjWf3FF/oC$c";
        private const string ExternalClientID = "4d110199-7703-4744-b4af-5889fd1da422";

        public ActionResult Create()
        {
            ViewBag.Message = "API Key Create";

            ApiKeyManagement request = new ApiKeyManagement(ExternalClientID);
            request.PrepareCreateRequest();

            return SendRequest(request);
        }

        public ActionResult Delete()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Select()
        {
            ViewBag.Message = "API Key Query";

            ApiKeyManagement request = new ApiKeyManagement(ExternalClientID)
            {
                ApiKey = ApiKey
            };
            request.PrepareSelectRequest();

            return SendRequest(request);
        }

        private ActionResult SendRequest(ApiKeyManagement request)
        {
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

        public ActionResult Update()
        {
            return View();
        }
    }
}