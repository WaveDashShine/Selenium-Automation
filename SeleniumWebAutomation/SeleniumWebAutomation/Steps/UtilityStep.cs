using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace SeleniumWebAutomation.Steps
{
    [Binding]
    public class UtilityStep
    {
        public static IWebDriver Driver;

        [BeforeFeature]
        public static void BeforeFeature()
        {
            Driver = new ChromeDriver();
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            Driver.Quit();
        }
    }
}
