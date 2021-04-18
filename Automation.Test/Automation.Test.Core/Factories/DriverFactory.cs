using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;

namespace Automation.Test.Core.Factories
{
    public class DriverFactory
    {
        public static IWebDriver Create(string host, ChromeOptions options)
        {
            var driver = new RemoteWebDriver(new Uri($"{host}:4444/wd/hub/"), options.ToCapabilities(), TimeSpan.FromMinutes(3));

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);

            // Suppress the onbeforeunload event first. This prevents the application hanging on a dialog box that does not close.
            ((IJavaScriptExecutor)driver).ExecuteScript("window.onbeforeunload = function(e){};");

            return driver;
        }
    }
}
