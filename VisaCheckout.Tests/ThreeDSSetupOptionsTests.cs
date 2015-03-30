using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VisaCheckout.VisaHelper.Options;

namespace VisaCheckout.Tests
{
    [TestClass]
    public class ThreeDSSetupOptionsTests
    {
        [TestMethod]
        public void GetHtmlTest()
        {
            IOptions options = new ThreeDSSetupOptions();

            string result = options.GetHtml();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Contains("threeDSSetup:{"));
        }

        [TestMethod]
        public void GetHtmlWithOptionsTest()
        {
            IOptions options = new ThreeDSSetupOptions
            {
                ThreeDSActive = true
            };

            string result = options.GetHtml();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Contains("threeDSSetup:{"));
            Assert.IsTrue(result.Contains("threeDSActive:\"true\""));
        }
    }
}
