using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VisaCheckout.Example.Models;
using VisaCheckout.VisaHelper.Options;
using VisaCheckout.VisaHelper.REST;

namespace VisaCheckout.Example.Controllers
{
    public class ProfileController : Controller
    {
        private const string ApiKey = "6L54BENENGTFB0JBDE9E139PCi16xnxbxsVKqSetpw_u_kJmc";
        private const string SharedKey = "TA0@pG+k9S1OK0{5+1ENOTZ3Mj4ydjWf3FF/oC$c";

        //
        // GET: /Profile/
        public ActionResult Index()
        {
            ViewBag.Message = "Profile Management";
            return View();
        }

        public ActionResult Select()
        {
            ViewBag.Message = "Profile Query";

            ProfileManagement request = new ProfileManagement(ApiKey);
            request.PrepareSelectRequest();

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

        public ActionResult Create()
        {
            ViewBag.Message = "Profile Create";

            ProfileManagement request = new ProfileManagement(ApiKey)
            {
                AcceptCanadianVisaDebit = true,
                AcceptedRegions = new List<string>() { "US" },
                BillingCountries = BillingCountries.US | BillingCountries.AU,
                CardBrands = SupportedCards.VISA | SupportedCards.AMEX | SupportedCards.DISCOVER | SupportedCards.MASTERCARD,
                CollectShipping = true,
                CustomerSupportUrl = new Uri("http://www.test.com"),
                DefaultProfile = false,
                ExternalProfileID = "testprofile",
                LogoDisplayName = "display name",
                LogoUrl = new Uri("http://www.test.com"),
                ThreeDSActive = false,
                ThreeDSSuppressChallenge = false,
                WebsiteUrl = new Uri("http://www.test.com")
            };
            request.PrepareCreateRequest();

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

        public ActionResult Delete()
        {
            ViewBag.Message = "Profile Delete";

            ProfileManagement request = new ProfileManagement(ApiKey)
            {
                ExternalProfileID = "testprofile"
            };
            request.PrepareDeleteRequest();

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
            ViewBag.Message = "Profile Update";

            ProfileManagement request = new ProfileManagement(ApiKey)
            {
                AcceptCanadianVisaDebit = true,
                AcceptedRegions = new List<string>() { "US" },
                BillingCountries = BillingCountries.US | BillingCountries.AU,
                CardBrands = SupportedCards.VISA | SupportedCards.AMEX | SupportedCards.DISCOVER | SupportedCards.MASTERCARD,
                CollectShipping = true,
                CustomerSupportUrl = new Uri("http://www.test.com"),
                DefaultProfile = false,
                ExternalProfileID = "testprofile",
                LogoDisplayName = "updated display name",
                LogoUrl = new Uri("http://www.test.com"),
                ThreeDSActive = false,
                ThreeDSSuppressChallenge = false,
                WebsiteUrl = new Uri("http://www.test.com")
            };
            request.PrepareUpdateRequest();

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