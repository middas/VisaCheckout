using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VisaCheckout.VisaHelper.Options;

namespace VisaCheckout.Tests
{
    [TestClass]
    public class VisaUpdateImageOptionTests
    {
        [TestInitialize]
        public void TestInitialize()
        {

        }

        [TestMethod]
        public void GetHtmlTest()
        {
            IOptions options = new VisaUpdateImageOptions("shared_Key", "abc123", EventTypes.Confirm, 12345678, "apiKey", 21M, 22M, CurrencyCodes.USD);

            string results = options.GetHtml();

            Assert.IsNotNull(results);
            Assert.IsTrue(results.Contains("x:12345678:"));
        }
    }
}
