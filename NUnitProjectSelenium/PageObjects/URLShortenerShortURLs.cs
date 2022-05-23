using OpenQA.Selenium;

namespace StudentsRegistrySeleniumPOMTests.PageObjects
{
    public class URLShortenerShortURLs : BasePage
    {
        public URLShortenerShortURLs(IWebDriver driver) : base(driver)
        {
        }

        public override string PageUrl =>
            "https://shorturl.nakov.repl.co/urls";

        public IReadOnlyCollection<IWebElement> ListElements =>
            driver.FindElements(By.CssSelector("body > main > table > tbody > tr"));

        public IWebElement LastElementShortURL =>
            driver.FindElement(By.CssSelector("body > main > table > tbody > tr:last-child > td:nth-child(2) > a"));

        public IWebElement VisitsElement =>
            driver.FindElement(By.CssSelector("body > main > table > tbody > tr:last-child > td:nth-child(4)"));

        public string[] GetListElements()
        {
            string[] elements = ListElements
                .Select(e => e.Text).ToArray();
            return elements;
        }

        public int GetVisitsCount()
        {
            var visitsCount = VisitsElement.Text;
            return int.Parse(visitsCount);
        }
    }
}
