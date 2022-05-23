using OpenQA.Selenium;

namespace StudentsRegistrySeleniumPOMTests.PageObjects
{
    public class NumberCalculatorPage : BasePage
    {
        public NumberCalculatorPage(IWebDriver driver) : base(driver)
        {
        }

        public override string PageUrl =>
            "https://number-calculator.nakov.repl.co/";

        public IWebElement PageHeading =>
            driver.FindElement(By.CssSelector("body > h1"));

        public IWebElement TextBoxNumberOne =>
            driver.FindElement(By.Id("number1"));

        public IWebElement DropDownOperation =>
            driver.FindElement(By.Id("operation"));

        public IWebElement TextBoxNumberTwo =>
            driver.FindElement(By.Id("number2"));

        public IWebElement ButtonCalculate =>
            driver.FindElement(By.Id("calcButton"));

        public IWebElement ButtonReset =>
            driver.FindElement(By.Id("resetButton"));

        public IWebElement Result =>
            driver.FindElement(By.Id("result"));

        public void Calculate(string num1, string operation, string num2)
        {
            ButtonReset.Click();
            if (num1 != "") TextBoxNumberOne.SendKeys(num1);
            if (operation != "") DropDownOperation.SendKeys(operation);
            if (num2 != "") TextBoxNumberTwo.SendKeys(num2);
            ButtonCalculate.Click();
        }

        public void Reset()
        {
            ButtonReset.Click();
        }
    }
}
