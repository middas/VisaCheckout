using Newtonsoft.Json;
using System.Web.Mvc;
using VisaCheckout.Example.Models;
using VisaCheckout.VisaHelper.REST;

namespace VisaCheckout.Example.Controllers
{
    public class ApiKeyController : Controller
    {
        private const string ApiKey = "6L54BENENGTFB0JBDE9E139PCi16xnxbxsVKqSetpw_u_kJmc";
        private const string ExternalClientID = "4d110199-7703-4744-b4af-5889fd1da422";
        private const string SharedKey = "TA0@pG+k9S1OK0{5+1ENOTZ3Mj4ydjWf3FF/oC$c";

        public ActionResult Create()
        {
            ViewBag.Message = "API Key Create";

            ApiKeyManagement request = new ApiKeyManagement(ApiKey);
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

            ApiKeyManagement request = new ApiKeyManagement(ApiKey)
            {
                ExternalClientID = ExternalClientID
            };
            request.PrepareSelectRequest();

            return SendRequest(request);
        }

        public ActionResult Update()
        {
            ViewBag.Message = "API Key Update (set last key to INACTIVE)";

            ApiKeyManagement request = new ApiKeyManagement(ApiKey)
            {
                ExternalClientID = ExternalClientID
            };
            request.PrepareSelectRequest();

            string response;
            if (request.SendRequest(SharedKey, out response))
            {
                dynamic data = JsonConvert.DeserializeObject(response);

                if (data != null && data.apiKeys != null && data.apiKeys.Count > 1)
                {
                    int index = data.apiKeys.Count - 1;
                    string apiKey = data.apiKeys[index].key;

                    request.ApiKeyToUpdate = apiKey;
                    request.Status = VisaHelper.Options.ApiKeyStatus.INACTIVE;
                    request.PrepareUpdateRequest();

                    return SendRequest(request);
                }
                else
                {
                    TempData.Add("error", "Not enough keys to update, you must have at least 2 keys.");
                }
            }
            else
            {
                TempData.Add("error", string.Format("Could not query keys:\r\n{0}", response));
            }

            return View();
        }

        private ActionResult SendRequest(ApiKeyManagement request)
        {
            return SendRequest(request, SharedKey);
        }

        private ActionResult SendRequest(ApiKeyManagement request, string sharedKey)
        {
            string response;
            bool success = request.SendRequest(sharedKey, out response);
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