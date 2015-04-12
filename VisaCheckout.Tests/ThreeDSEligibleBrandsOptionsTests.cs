using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VisaCheckout.VisaHelper.Options;

namespace VisaCheckout.Tests
{
    [TestClass]
    public class ThreeDSEligibleBrandsOptionsTests
    {
        [TestMethod]
        public void GetHtmlTest()
        {
            IOptions options = new ThreeDSEligibleBrandsOptions("abc123", SupportedCards.VISA | SupportedCards.AMEX);
            string result = options.GetOptionString();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Contains("\"threeDSEligibleBrands\":{"));
            Assert.IsTrue(result.Contains("\"acquirerId\":\"abc123\""));
            Assert.IsTrue(result.Contains("\"cardBrands\":[\"VISA\",\"AMEX\"]"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void GetHtmlNoAcquirerIDTest()
        {
            IOptions options = new ThreeDSEligibleBrandsOptions(null, SupportedCards.VISA | SupportedCards.AMEX);
            string result = options.GetOptionString();

            Assert.IsNull(result);
        }
    }
}
