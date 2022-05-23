using OpenQA.Selenium;
using StudentsRegistrySeleniumPOMTests.PageObjects;

namespace NUnitProjectSelenium.Tests
{
    public class NumberCalculatorTests : BaseTest
    {
        // Valid integers
        [TestCase("3", "+", "5", "Result: 8")]
        [TestCase("5", "-", "2", "Result: 3")]
        [TestCase("8", "*", "4", "Result: 32")]
        [TestCase("18", "/", "3", "Result: 6")]
        [TestCase("3", "-", "5", "Result: -2")]
        [TestCase("-1", "+", "2", "Result: 1")]
        [TestCase("-1", "+", "-2", "Result: -3")]
        [TestCase("-3", "*", "2", "Result: -6")]
        [TestCase("-3", "*", "-2", "Result: 6")]
        [TestCase("15", "/", "-3", "Result: -5")]
        [TestCase("-15", "/", "3", "Result: -5")]
        [TestCase("-15", "/", "-3", "Result: 5")]

        // Valid decimals
        [TestCase("5.23", "+", "3.88", "Result: 9.11")]
        [TestCase("3.14", "-", "12.763", "Result: -9.623")]
        [TestCase("3.14", "*", "-7.534", "Result: -23.65676")]
        [TestCase("12.5", "/", "4", "Result: 3.125")]

        // Valid xponentials
        [TestCase("1.5e53", "*", "150", "Result: 2.25e+55")]
        [TestCase("1.5e53", "/", "150", "Result: 1e+51")]

        // Invalid inputs
        [TestCase("", "+", "1", "Result: invalid input")]
        [TestCase("", "-", "2", "Result: invalid input")]
        [TestCase("", "*", "3", "Result: invalid input")]
        [TestCase("", "/", "4", "Result: invalid input")]
        [TestCase("5", "+", "", "Result: invalid input")]
        [TestCase("6", "-", "", "Result: invalid input")]
        [TestCase("7", "*", "", "Result: invalid input")]
        [TestCase("8", "/", "", "Result: invalid input")]
        [TestCase("asd", "+", "9", "Result: invalid input")]
        [TestCase("10", "-", "sadf", "Result: invalid input")]
        [TestCase("zxcv", "*", "sd", "Result: invalid input")]
        [TestCase("", "/", "", "Result: invalid input")]

        // Infinity input
        [TestCase("Infinity", "+", "1", "Result: Infinity")]
        [TestCase("Infinity", "-", "2", "Result: Infinity")]
        [TestCase("Infinity", "*", "3", "Result: Infinity")]
        [TestCase("Infinity", "/", "4", "Result: Infinity")]
        [TestCase("5", "+", "Infinity", "Result: Infinity")]
        [TestCase("6", "-", "Infinity", "Result: -Infinity")]
        [TestCase("7", "*", "Infinity", "Result: Infinity")]
        [TestCase("8", "/", "Infinity", "Result: 0")]
        [TestCase("Infinity", "+", "Infinity", "Result: Infinity")]
        [TestCase("Infinity", "-", "Infinity", "Result: invalid calculation")]
        [TestCase("Infinity", "*", "Infinity", "Result: Infinity")]
        [TestCase("Infinity", "/", "Infinity", "Result: invalid calculation")]
        public void Test_NumberCalculator(string num1, string operation, string num2, string result)
        {
            var page = new NumberCalculatorPage(driver);
            page.Open();
            page.Calculate(num1,operation, num2);

            Assert.AreEqual(result, page.Result.Text);
        }
    }
}