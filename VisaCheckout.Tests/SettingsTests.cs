using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using VisaCheckout.VisaHelper.Options;

namespace VisaCheckout.Tests
{
    [TestClass]
    public class SettingsTests
    {
        [TestMethod]
        public void GetHtmlTest()
        {
            IOptions options = new SettingOptions();

            string result = options.GetOptionString();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Contains("\"settings\":{"));
        }

        [TestMethod]
        public void GetHtmlWithOptionsTest()
        {
            IOptions options = new SettingOptions
            {
                DataLevel = DataLevels.FULL,
                DisplayName = "name",
                Locale = "en-US"
            };

            string result = options.GetOptionString();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Contains("\"settings\":{"));
            Assert.IsTrue(result.Contains("\"dataLevel\":\"FULL\""));
            Assert.IsTrue(result.Contains("\"displayName\":\"name\""));
            Assert.IsTrue(result.Contains("\"locale\":\"en-US\""));
        }

        [TestMethod]
        public void GetHtmlWithPaymentTest()
        {
            IOptions options = new SettingOptions
            {
                Payment = new PaymentOptions()
            };

            string result = options.GetOptionString();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Contains("\"settings\":{"));
            Assert.IsTrue(result.Contains("\"payment\":{"));
        }

        [TestMethod]
        public void GetHtmlWithReviewTest()
        {
            IOptions options = new SettingOptions
            {
                Review = new ReviewOptions()
            };

            string result = options.GetOptionString();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Contains("\"settings\":{"));
            Assert.IsTrue(result.Contains("\"review\":{"));
        }

        [TestMethod]
        public void GetHtmlWithShippingTest()
        {
            IOptions options = new SettingOptions
            {
                Shipping = new ShippingOptions()
            };

            string result = options.GetOptionString();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Contains("\"settings\":{"));
            Assert.IsTrue(result.Contains("\"shipping\":{"));
        }

        [TestMethod]
        public void GetHtmlWithThreeDSSetupTest()
        {
            IOptions options = new SettingOptions
            {
                ThreeDSSetup = new ThreeDSSetupOptions()
            };

            string result = options.GetOptionString();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Contains("\"settings\":{"));
            Assert.IsTrue(result.Contains("\"threeDSSetup\":{"));
        }

        [TestMethod]
        public void GetHtmlWithUrlTest()
        {
            IOptions options = new SettingOptions
            {
                WebsiteUrl = new Uri("http://www.test.com")
            };

            string result = options.GetOptionString();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Contains("\"websiteUrl\":\"http://www.test.com/\""));
        }

        [TestInitialize]
        public void TestInitialize()
        {
            VisaCheckout.VisaHelper.Environment.IsSandbox = false;
        }
    }
}