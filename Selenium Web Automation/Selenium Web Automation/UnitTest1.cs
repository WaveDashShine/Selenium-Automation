using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace Selenium_Web_Automation
{
    [TestClass]
    public class UnitTest1
    {
        static IWebDriver driver;

        [AssemblyInitialize]
        public static void Initialize(TestContext testContext)
        {
            driver = new ChromeDriver();
        }

        [TestMethod]
        public void TestMethod1()
        {
            driver.Navigate().GoToUrl("https://www.google.ca");
        }
    }
}
