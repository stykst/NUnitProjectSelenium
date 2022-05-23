using OpenQA.Selenium;

namespace StudentsRegistrySeleniumPOMTests.PageObjects
{
    public class URLShortenerHome : BasePage
    {
        public URLShortenerHome(IWebDriver driver) : base(driver)
        {
        }

        public override string PageUrl =>
            "https://shorturl.nakov.repl.co/";

        public IWebElement ViewShortURLsCount =>
            driver.FindElement(By.CssSelector("body > main > ul > li:nth-child(1) > b"));

        public IWebElement ViewURLVisitorsCount =>
            driver.FindElement(By.CssSelector("body > main > ul > li:nth-child(2) > b"));
    }
}
