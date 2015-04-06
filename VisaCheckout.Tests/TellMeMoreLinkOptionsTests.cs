using Microsoft.VisualStudio.TestTools.UnitTesting;
using VisaCheckout.VisaHelper.Options;

namespace VisaCheckout.Tests
{
    [TestClass]
    public class TellMeMoreLinkOptionsTests
    {
        [TestMethod]
        public void GetHtmlTest()
        {
            IOptions options = new TellMeMoreLinkOptions();

            string result = options.GetOptionString();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Contains("<a "));
            Assert.IsTrue(result.Contains("v-learn"));
            Assert.IsTrue(result.Contains(string.Format(">{0}</a>", ((TellMeMoreLinkOptions)options).LinkText)));
        }

        [TestMethod]
        public void GetHtmlWithOptionsTest()
        {
            IOptions options = new TellMeMoreLinkOptions
            {
                DataLocale = "en-US",
                LinkText = "test"
            };

            string result = options.GetOptionString();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Contains("<a "));
            Assert.IsTrue(result.Contains("v-learn"));
            Assert.IsTrue(result.Contains(string.Format(">{0}</a>", ((TellMeMoreLinkOptions)options).LinkText)));
            Assert.IsTrue(result.Contains("data-locale=\"en-US\""));
        }

        [TestInitialize]
        public void TestInitialize()
        {
            VisaCheckout.VisaHelper.Environment.IsSandbox = false;
        }
    }
}