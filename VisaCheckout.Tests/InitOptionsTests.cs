using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using VisaCheckout.VisaHelper.Options;

namespace VisaCheckout.Tests
{
    [TestClass]
    public class InitOptionsTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetHtmlNoApiKeyTest()
        {
            IOptions options = new InitOptions
            {
                PaymentRequest = new PaymentRequestOptions()
            };

            string result = options.GetOptionString();

            Assert.IsNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetHtmlNoPaymentOptionsTest()
        {
            IOptions options = new InitOptions();

            string result = options.GetOptionString();

            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetHtmlWithOptionsTest()
        {
            IOptions options = new InitOptions
            {
                PaymentRequest = new PaymentRequestOptions(),
                ApiKey = "apiKey",
                Settings = new SettingOptions()
            };

            string result = options.GetOptionString();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Contains("V.init({"));
            Assert.IsTrue(result.Contains("\"paymentRequest\":{"));
            Assert.IsTrue(result.Contains("\"apikey\":\"apiKey\""));
            Assert.IsTrue(result.Contains("\"settings\":{"));
        }

        [TestInitialize]
        public void TestInitialize()
        {
            VisaCheckout.VisaHelper.Environment.IsSandbox = false;
        }
    }
}