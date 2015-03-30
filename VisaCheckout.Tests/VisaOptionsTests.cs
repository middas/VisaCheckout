﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VisaCheckout.VisaHelper.Options;

namespace VisaCheckout.Tests
{
    [TestClass]
    public class VisaOptionsTests
    {
        private static OnOptions OnOptions;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            OnOptions = new OnOptions
            {
                PaymentCancel = "cancel",
                PaymentError = "error",
                PaymentSuccess = "success"
            };
        }

        [TestMethod]
        public void GetHtmlTest()
        {
            IOptions options = new VisaOptions("apiKey", 21.21M, CurrencyCodes.USD, OnOptions);

            string result = options.GetHtml();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Contains("onVisaCheckoutReady(){"));
            Assert.IsTrue(result.Contains("<div class=\"v-checkout-wrapper\""));
            Assert.IsTrue(result.Contains("V.init({"));
            Assert.IsTrue(result.Contains("apikey:\"apiKey\""));
            Assert.IsTrue(result.Contains("subtotal:\"21.21\""));
            Assert.IsTrue(result.Contains("currencyCode:\"USD\""));
            Assert.IsTrue(result.Contains("V.on"));
            Assert.IsTrue(result.Contains(VisaOptions.ProductionSdkUrl));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetHtmlNoApiKeyTest()
        {
            IOptions options = new VisaOptions(null, 21.21M, CurrencyCodes.USD, OnOptions);

            string result = options.GetHtml();

            Assert.IsNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetHtmlNoOnOptionsTest()
        {
            IOptions options = new VisaOptions("apiKey", 21.21M, CurrencyCodes.USD, null);

            string result = options.GetHtml();

            Assert.IsNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetHtmlNoPaymentRequestTest()
        {
            IOptions options = new VisaOptions("apiKey", 21.21M, CurrencyCodes.USD, OnOptions)
            {
                InitOptions = new InitOptions
                {
                    ApiKey = "apiKey",
                    PaymentRequest = null
                }
            };

            string result = options.GetHtml();

            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetHtmlIsSandboxTest()
        {
            IOptions options = new VisaOptions("apiKey", 21.21M, CurrencyCodes.USD, OnOptions)
            {
                IsSandbox = true
            };

            string result = options.GetHtml();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Contains("onVisaCheckoutReady(){"));
            Assert.IsTrue(result.Contains("<div class=\"v-checkout-wrapper\""));
            Assert.IsTrue(result.Contains("V.init({"));
            Assert.IsTrue(result.Contains("apikey:\"apiKey\""));
            Assert.IsTrue(result.Contains("subtotal:\"21.21\""));
            Assert.IsTrue(result.Contains("currencyCode:\"USD\""));
            Assert.IsTrue(result.Contains("V.on"));
            Assert.IsTrue(result.Contains(VisaOptions.SandboxSdkUrl));
        }
    }
}
