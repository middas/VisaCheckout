using Microsoft.VisualStudio.TestTools.UnitTesting;
using VisaCheckout.VisaHelper.Options;

namespace VisaCheckout.Tests
{
    [TestClass]
    public class ButtonOptionsTests
    {
        [TestMethod]
        public void BuildUrlIsSandboxTest()
        {
            IOptions options = new ButtonOptions();

            string result = options.GetHtml();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Contains("<image"));
            Assert.IsTrue(result.Contains("class=\"v-button\""));
            Assert.IsTrue(result.Contains(ButtonOptions.SandboxButtonUrl));
        }

        [TestMethod]
        public void BuildUrlTest()
        {
            VisaHelper.Environment.IsSandbox = false;
            IOptions options = new ButtonOptions();

            string result = options.GetHtml();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Contains("<image"));
            Assert.IsTrue(result.Contains("class=\"v-button\""));
            Assert.IsTrue(result.Contains(ButtonOptions.ProductionButtonUrl));
        }

        [TestMethod]
        public void BuildUrlWithOptionsTest()
        {
            VisaHelper.Environment.IsSandbox = false;
            IOptions options = new ButtonOptions
            {
                CardBrands = SupportedCards.AMEX | SupportedCards.VISA,
                Color = ButtonColors.Neutral,
                Size = ButtonSizes.Large
            };

            string result = options.GetHtml();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Contains("<image"));
            Assert.IsTrue(result.Contains("class=\"v-button\""));
            Assert.IsTrue(result.Contains(ButtonOptions.ProductionButtonUrl));
            Assert.IsTrue(result.Contains("cardBrands=VISA,AMEX"));
            Assert.IsTrue(result.Contains("color=neutral"));
            Assert.IsTrue(result.Contains("size=425"));
        }

        [TestMethod]
        public void BuildUrlWithTabIndexTest()
        {
            VisaHelper.Environment.IsSandbox = false;
            IOptions options = new ButtonOptions
            {
                TabIndex = 1
            };

            string result = options.GetHtml();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Contains("<image"));
            Assert.IsTrue(result.Contains("class=\"v-button\""));
            Assert.IsTrue(result.Contains(ButtonOptions.ProductionButtonUrl));
            Assert.IsTrue(result.Contains("tabindex=\"1\""));
        }

        [TestInitialize]
        public void TestInitialize()
        {
            VisaHelper.Environment.IsSandbox = true;
        }
    }
}