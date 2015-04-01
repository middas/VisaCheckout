using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VisaCheckout.VisaHelper.Options;

namespace VisaCheckout.Tests
{
    [TestClass]
    public class SettingsTests
    {
        [TestInitialize]
        public void TestInitialize()
        {
            VisaCheckout.VisaHelper.Environment.IsSandbox = false;
        }

        [TestMethod]
        public void GetHtmlTest()
        {
            IOptions options = new Settings();

            string result = options.GetHtml();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Contains("settings:{"));
        }

        [TestMethod]
        public void GetHtmlWithOptionsTest()
        {
            IOptions options = new Settings
            {
                DataLevel = DataLevel.FULL,
                DisplayName = "name",
                Locale = "en-US"
            };

            string result = options.GetHtml();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Contains("settings:{"));
            Assert.IsTrue(result.Contains("dataLevel:\"FULL\""));
            Assert.IsTrue(result.Contains("displayName:\"name\""));
            Assert.IsTrue(result.Contains("locale:\"en-US\""));
        }

        [TestMethod]
        public void GetHtmlWithPaymentTest()
        {
            IOptions options = new Settings
            {
               Payment = new PaymentOptions()
            };

            string result = options.GetHtml();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Contains("settings:{"));
            Assert.IsTrue(result.Contains("payment:{"));
        }

        [TestMethod]
        public void GetHtmlWithReviewTest()
        {
            IOptions options = new Settings
            {
                Review = new ReviewOptions()
            };

            string result = options.GetHtml();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Contains("settings:{"));
            Assert.IsTrue(result.Contains("review:{"));
        }

        [TestMethod]
        public void GetHtmlWithShippingTest()
        {
            IOptions options = new Settings
            {
                Shipping = new ShippingOptions()
            };

            string result = options.GetHtml();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Contains("settings:{"));
            Assert.IsTrue(result.Contains("shipping:{"));
        }

        [TestMethod]
        public void GetHtmlWithThreeDSSetupTest()
        {
            IOptions options = new Settings
            {
                ThreeDSSetup = new ThreeDSSetupOptions()
            };

            string result = options.GetHtml();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Contains("settings:{"));
            Assert.IsTrue(result.Contains("threeDSSetup:{"));
        }

        [TestMethod]
        public void GetHtmlWithUrlTest()
        {
            IOptions options = new Settings
            {
                WebsiteUrl = new Uri("http://www.test.com")
            };

            string result = options.GetHtml();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Contains("websiteUrl:\"http://www.test.com/\""));
        }
    }
}
