using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium_Web_Automation
{
    public class PageObject
    {
        private readonly IWebDriver _driver;

        public PageObject(IWebDriver driver)
        {
            _driver = driver;
        }

        public void GoToHomePage()
        {
            _driver.Navigate().GoToUrl("https://www.google.ca");
        }
    }
}