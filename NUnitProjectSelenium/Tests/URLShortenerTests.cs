using OpenQA.Selenium;
using StudentsRegistrySeleniumPOMTests.PageObjects;

namespace NUnitProjectSelenium.Tests
{
    public class URLShortenerTests : BaseTest
    {
        [Test]
        public void Test_URLShortener_Home()
        {
            var page = new URLShortenerHome(driver);
            page.Open();

            Assert.IsTrue(page.IsOpen());
            Assert.AreEqual("URL Shortener", page.PageHeading.Text);
        }

        [Test]
        public void Test_URLShortener_ShortURLs()
        {
            var page = new URLShortenerShortURLs(driver);
            page.Open();

            Assert.IsTrue(page.IsOpen());
            Assert.AreEqual("Short URLs", page.PageHeading.Text);

            var elements = page.GetListElements();
            var sum = 0;
            foreach (var element in elements)
            {
                sum++;
            }
            
            Assert.IsTrue(sum == page.ListElements.Count);
            Assert.AreEqual("https://nakov.com", driver
                .FindElement(By
                .CssSelector("body > main > table > tbody > tr:nth-child(1) > td:nth-child(1)")).Text);
            Assert.AreEqual("http://shorturl.nakov.repl.co/go/nak", driver
                .FindElement(By
                .XPath("/html/body/main/table/tbody/tr[1]/td[2]")).Text);
        }

        [Test]
        public void Test_URLShortener_AddURL_Invalid()
        {
            var page = new URLShortenerAddURL(driver);
            page.Open();

            Assert.IsTrue(page.IsOpen());

            var url = "alabala";
            page.AddURL(url);
            Assert.AreEqual("Invalid URL!", page.ErrorMsg());
        }

        [Test]
        public void Test_URLShortener_AddURL_Valid()
        {
            var page = new URLShortenerAddURL(driver);
            page.Open();
            Assert.IsTrue(page.IsOpen());

            var url = "https://google.com";
            page.AddURL(url);

            var newPage = new URLShortenerShortURLs(driver);
            newPage.Open();
            Assert.IsTrue(newPage.IsOpen());

            var elements = newPage.GetListElements();
            Assert.That(elements.Last().Contains(url));
        }

        [Test]
        public void Test_URLShortener_VisitURL()
        {
            var page = new URLShortenerAddURL(driver);
            page.Open();
            Assert.IsTrue(page.IsOpen());
            var url = "https://google.com";
            page.AddURL(url);

            var newPage = new URLShortenerShortURLs(driver);
            Assert.IsTrue(newPage.IsOpen());
            var visitsCount = newPage.GetVisitsCount();

            newPage.LastElementShortURL.Click();
            var newURL = driver.SwitchTo().Window(driver.WindowHandles[1]).Url;
            Assert.AreEqual("https://www.google.com/", newURL);

            driver.SwitchTo().Window(driver.WindowHandles[0]);
            var newVisitsCount = newPage.GetVisitsCount();
            Assert.IsTrue(newVisitsCount > visitsCount);
        }

        [Test]
        public void Test_URLShortener_VisitNonExistingURL()
        {
            var page = new URLShortenerAddURL(driver);
            page.Open();
            Assert.IsTrue(page.IsOpen());
            var url = "https://alabala.com";
            page.AddURL(url);

            var newPage = new URLShortenerShortURLs(driver);
            Assert.IsTrue(newPage.IsOpen());
            var visitsCount = newPage.GetVisitsCount();

            newPage.LastElementShortURL.Click();
            var errPage = driver.SwitchTo().Window(driver.WindowHandles[1]);
            Assert.AreEqual("https://alabala.com/", errPage.Url);
            Assert.AreEqual("This site can’t be reached", errPage
                .FindElement(By.CssSelector("#main-message > h1 > span")).Text);

            driver.SwitchTo().Window(driver.WindowHandles[0]);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            var newVisitsCount = newPage.GetVisitsCount();
            Assert.IsTrue(newVisitsCount > visitsCount);
        }
    }
}