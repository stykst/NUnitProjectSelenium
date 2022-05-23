using OpenQA.Selenium;

namespace StudentsRegistrySeleniumPOMTests.PageObjects
{
    public class BasePage
    {
        protected readonly IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        public virtual string PageUrl { get; }

        public IWebElement LinkHome =>
            driver.FindElement(By.XPath("//a[contains(.,'Home')]"));
        public IWebElement LinkShortURLs =>
            driver.FindElement(By.XPath("//a[contains(.,'Short URLs')]"));
        public IWebElement LinkAddURL =>
            driver.FindElement(By.XPath("//a[contains(.,'Add URL')]"));
        public IWebElement PageHeading =>
            driver.FindElement(By.CssSelector("body > main > h1"));
        public IWebElement PageFooter =>
            driver.FindElement(By.CssSelector("body > footer > div"));

        public void Open()
        {
            driver.Navigate().GoToUrl(PageUrl);
        }

        public bool IsOpen()
        {
            return driver.Url == PageUrl;
        }

        public string GetPageTitle()
        {
            return driver.Title;
        }
    }
}
