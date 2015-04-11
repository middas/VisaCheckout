using Microsoft.VisualStudio.TestTools.UnitTesting;
using VisaCheckout.VisaHelper.Options;

namespace VisaCheckout.Tests
{
    [TestClass]
    public class PaymentRequestOptionsTests
    {
        [TestMethod]
        public void GetHtmlTest()
        {
            IOptions options = new PaymentRequestOptions();

            string result = options.GetOptionString();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Contains("\"paymentRequest\":{"));
        }

        [TestMethod]
        public void GetHtmlWithCustomDataTest()
        {
            IOptions options = new PaymentRequestOptions();
            ((PaymentRequestOptions)options).CustomData.Add("test1", "value1");
            ((PaymentRequestOptions)options).CustomData.Add("test2", "value2");

            string result = options.GetOptionString();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Contains("\"paymentRequest\":{"));
            Assert.IsTrue(result.Contains("\"customData\":{\"nvPair\":[{\"name\":\"test1\",\"value\":\"value1\"},{\"name\":\"test2\",\"value\":\"value2\"}]"));
        }

        [TestMethod]
        public void GetHtmlWithOptionsTest()
        {
            IOptions options = new PaymentRequestOptions
            {
                CurrencyCode = CurrencyCodes.USD,
                Subtotal = 21.21M
            };

            string result = options.GetOptionString();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Contains("\"paymentRequest\":{"));
            Assert.IsTrue(result.Contains("\"currencyCode\":\"USD\""));
            Assert.IsTrue(result.Contains("\"subtotal\":\"21.21\""));
        }

        [TestInitialize]
        public void TestInitialize()
        {
            VisaCheckout.VisaHelper.Environment.IsSandbox = false;
        }
    }
}