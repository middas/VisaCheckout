using Newtonsoft.Json;
using System.Web.Mvc;
using VisaCheckout.Example.Models;
using VisaCheckout.VisaHelper.REST;

namespace VisaCheckout.Example.Controllers
{
    public class UserController : Controller
    {
        private const string ApiKey = "6L54BENENGTFB0JBDE9E139PCi16xnxbxsVKqSetpw_u_kJmc";
        private const string SharedKey = "TA0@pG+k9S1OK0{5+1ENOTZ3Mj4ydjWf3FF/oC$c";

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Delete()
        {
            return View();
        }

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Select()
        {
            ViewBag.Message = "User Query";

            UserManagement request = new UserManagement(ApiKey);
            request.PrepareSelectRequest();

            return SendRequest(request);
        }

        public ActionResult Update()
        {
            return View();
        }

        private ActionResult SendRequest(UserManagement request)
        {
            return SendRequest(request, SharedKey);
        }

        private ActionResult SendRequest(UserManagement request, string sharedKey)
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