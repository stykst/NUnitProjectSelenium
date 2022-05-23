using OpenQA.Selenium;

namespace StudentsRegistrySeleniumPOMTests.PageObjects
{
    public class SummatorPage : BasePage
    {
        public SummatorPage(IWebDriver driver) : base(driver)
        {
        }

        public override string PageUrl =>
            "https://sum-numbers.nakov.repl.co";

        public IWebElement PageHeading =>
            driver.FindElement(By.XPath("//h1[contains(.,'Sum Two Numbers')]"));

        public IWebElement TextBoxNumberOne =>
            driver.FindElement(By.Id("number1"));

        public IWebElement TextBoxNumberTwo =>
            driver.FindElement(By.Id("number2"));

        public IWebElement ButtonCalculate =>
            driver.FindElement(By.Id("calcButton"));

        public IWebElement ButtonReset =>
            driver.FindElement(By.Id("resetButton"));

        public IWebElement Result =>
            driver.FindElement(By.Id("result"));

        public void Calculate(string num1, string num2)
        {
            TextBoxNumberOne.SendKeys(num1);
            TextBoxNumberTwo.SendKeys(num2);
            ButtonCalculate.Click();
        }

        public void Reset()
        {
            ButtonReset.Click();
        }
    }
}
