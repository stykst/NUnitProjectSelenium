using OpenQA.Selenium;
using StudentsRegistrySeleniumPOMTests.PageObjects;

namespace NUnitProjectSelenium.Tests
{
    public class SummatorTests : BaseTest
    {
        [Test]
        public void Test_AddTwoNumbers_Valid()
        {
            var page = new SummatorPage(driver);
            page.Open();

            var number1 = "15";
            var number2 = "7";
            page.Calculate(number1, number2);

            Assert.AreEqual("Sum: 22", page.Result.Text);
        }

        [Test]
        public void Test_AddTwoNumbers_InvalidInput()
        {
            var page = new SummatorPage(driver);
            page.Open();

            var number1 = "Pesho";
            var number2 = "7";
            page.Calculate(number1, number2);

            Assert.AreEqual("Sum: invalid input", page.Result.Text);
        }

        [Test]
        public void Test_AddTwoNumbers_Reset()
        {
            var page = new SummatorPage(driver);
            page.Open();

            var number1 = "Pesho";
            var number2 = "7";
            page.Reset();

            Assert.AreEqual("", page.TextBoxNumberOne.Text);
            Assert.AreEqual("", page.TextBoxNumberTwo.Text);
        }
    }
}