using Microsoft.VisualStudio.TestTools.UnitTesting;
using VisaCheckout.VisaHelper.Options;

namespace VisaCheckout.Tests
{
    [TestClass]
    public class OnOptionsTest
    {
        [TestMethod]
        public void GetHtmlTest()
        {
            IOptions options = new OnOptions();

            string result = options.GetOptionString();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetHtmlWithOptionsTest()
        {
            IOptions options = new OnOptions
            {
                PaymentCancel = "cancel",
                PaymentError = "error",
                PaymentSuccess = "success"
            };

            string result = options.GetOptionString();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Contains("V.on(\"payment.success\", function(payment){success});"));
            Assert.IsTrue(result.Contains("V.on(\"payment.error\", function(payment){error});"));
            Assert.IsTrue(result.Contains("V.on(\"payment.cancel\", function(payment){cancel});"));
        }

        [TestInitialize]
        public void TestInitialize()
        {
            VisaCheckout.VisaHelper.Environment.IsSandbox = false;
        }
    }
}