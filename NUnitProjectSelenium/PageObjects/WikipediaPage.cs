using OpenQA.Selenium;

namespace StudentsRegistrySeleniumPOMTests.PageObjects
{
    public class WikipediaPage : BasePage
    {
        public WikipediaPage(IWebDriver driver) : base(driver)
        {
        }

        public override string PageUrl =>
            "https://wikipedia.org";

        public IWebElement TextBoxSearch =>
            driver.FindElement(By.Id("searchInput"));

        public IWebElement ButtonSubmit =>
            driver.FindElement(By.CssSelector("#search-form > fieldset > button"));

        public IWebElement PageHeading =>
            driver.FindElement(By.XPath("//span[contains(@class,'wordmark')]"));

        public void SearchFor(string input)
        {
            TextBoxSearch.SendKeys(input);
            ButtonSubmit.Click();
        }
    }
}
