using OpenQA.Selenium;
using StudentsRegistrySeleniumPOMTests.PageObjects;

namespace NUnitProjectSelenium.Tests
{
    public class WikipediaTests : BaseTest
    {
        [Test]
        public void Test_SearchQAInWikipedia()
        {
            var page = new WikipediaPage(driver);
            page.Open();

            var input = "QA";
            page.SearchFor(input);

            Assert.AreEqual("https://en.wikipedia.org/wiki/QA", driver.Url);
        }
    }
}