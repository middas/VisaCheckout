using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VisaCheckout.VisaHelper.Options;

namespace VisaCheckout.Tests
{
    [TestClass]
    public class PaymentOptionsTests
    {
        [TestInitialize]
        public void TestInitialize()
        {
            VisaCheckout.VisaHelper.Environment.IsSandbox = false;
        }

        [TestMethod]
        public void GetHtmlTest()
        {
            IOptions options = new PaymentOptions();

            string result = options.GetHtml();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Contains("payment:{"));
        }

        [TestMethod]
        public void GetHtmlWithOptionsTest()
        {
            IOptions options = new PaymentOptions
            {
                AcceptCanadianVisaDebit = true,
                BillingCountries = BillingCountries.US | BillingCountries.CA,
                CardBrands = SupportedCards.VISA | SupportedCards.AMEX
            };

            string result = options.GetHtml();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Contains("payment:{"));
            Assert.IsTrue(result.Contains("acceptCanadianVisaDebit:\"true\""));
            Assert.IsTrue(result.Contains("billingCountries:[\"CA\",\"US\"]"));
            Assert.IsTrue(result.Contains("cardBrands:[\"VISA\",\"AMEX\"]"));
        }
    }
}
