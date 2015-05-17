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
            ViewBag.Message = "User Create";

            UserManagement request = new UserManagement(ApiKey)
            {
                Email = "donotreply@ldsborrowedandblue.com",
                FirstName = "first",
                LastName = "last",
                Username = "donotreply@ldsborrowedandblue.com"
            };
            request.PrepareCreateRequest();

            return SendRequest(request);
        }

        public ActionResult Delete()
        {
            ViewBag.Message = "User Delete (the last user)";

            UserManagement request = new UserManagement(ApiKey);
            request.PrepareSelectRequest();

            string response;
            if (request.SendRequest(SharedKey, out response))
            {
                dynamic data = JsonConvert.DeserializeObject(response);

                if (data != null && data.users != null && data.users.Count > 0)
                {
                    int index = data.users.Count - 1;
                    string username = data.users[index].username;

                    request.Username = username;
                    request.PrepareDeleteRequest();

                    return SendRequest(request);
                }
                else
                {
                    TempData.Add("error", "No users to delete");
                }
            }
            else
            {
                TempData.Add("error", string.Format("Could not query users:\r\n{0}", response));
            }

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
            ViewBag.Message = "User Update (the last user)";

            UserManagement request = new UserManagement(ApiKey);
            request.PrepareSelectRequest();

            string response;
            if (request.SendRequest(SharedKey, out response))
            {
                dynamic data = JsonConvert.DeserializeObject(response);

                if (data != null && data.users != null && data.users.Count > 0)
                {
                    int index = data.users.Count - 1;
                    string username = data.users[index].username;

                    request.Username = username;
                    request.LastName = "updated";
                    request.FirstName = data.users[index].firstName;
                    request.Email = username;
                    request.PrepareUpdateRequest();

                    return SendRequest(request);
                }
                else
                {
                    TempData.Add("error", "No users to update");
                }
            }
            else
            {
                TempData.Add("error", string.Format("Could not query users:\r\n{0}", response));
            }

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