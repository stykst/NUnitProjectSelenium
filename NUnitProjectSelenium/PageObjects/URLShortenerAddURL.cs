using OpenQA.Selenium;

namespace StudentsRegistrySeleniumPOMTests.PageObjects
{
    public class URLShortenerAddURL : BasePage
    {
        public URLShortenerAddURL(IWebDriver driver) : base(driver)
        {
        }

        public override string PageUrl =>
            "https://shorturl.nakov.repl.co/add-url";

        public IWebElement TextBoxURL =>
            driver.FindElement(By.Id("url"));

        public IWebElement TextBoxShortCode =>
            driver.FindElement(By.Id("code"));

        public IWebElement ButtonCreate =>
            driver.FindElement(By.XPath("//button[@type='submit']"));

        public IWebElement ErrorMessageElement =>
            driver.FindElement(By.XPath("/html/body/div"));

        public void AddURL(string url)
        {
            TextBoxURL.SendKeys(url);
            ButtonCreate.Click();
        }

        public string ErrorMsg()
        {
            return ErrorMessageElement.Text;
        }
    }
}
