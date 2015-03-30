using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VisaCheckout.VisaHelper.Options;

namespace VisaCheckout.Tests
{
    [TestClass]
    public class ReviewOptionsTests
    {
        [TestMethod]
        public void GetHtmlTest()
        {
            IOptions options = new ReviewOptions();

            string result = options.GetHtml();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Contains("review:{"));
        }

        [TestMethod]
        public void GetHtmlWithOptionsTest()
        {
            IOptions options = new ReviewOptions
            {
                ButtonAction = ButtonActions.Pay,
                Message = "message"
            };

            string result = options.GetHtml();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Contains("review:{"));
            Assert.IsTrue(result.Contains("buttonAction:\"Pay\""));
            Assert.IsTrue(result.Contains("message:\"message\""));
        }
    }
}
