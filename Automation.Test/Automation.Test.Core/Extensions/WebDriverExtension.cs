using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Automation.Test.Core.Extensions
{
    public static class WebDriverExtension
    {
        public static bool WaitForAjax(this IWebDriver driver)
        {
            try
            {
                while (true)
                {
                    var ajaxIsComplete = (bool)(driver as IJavaScriptExecutor).ExecuteScript("return jQuery.active == 0");
                    if (ajaxIsComplete)
                        break;
                    Thread.Sleep(100);
                }
            }
            catch (TimeoutException e)
            {
                Console.Error.WriteLine(e.Message + "Error waiting for ajax");
            }

            return true;
        }

        public static IWebElement FindElement(this IWebDriver driver, string elm)
        {
            return driver.FindElement(WebDriverHelper.SelectorByAttributeValue(elm));
        }

        public static IWebElement FindElementByJQuery(this IWebDriver driver, string selector)
        {
            var js = (IJavaScriptExecutor)driver;

            if ((bool)js.ExecuteScript("return typeof jQuery == 'undefined'"))
            {
                js.ExecuteScript("var jq = document.createElement('script');jq.src = '//code.jquery.com/jquery-latest.min.js';document.getElementsByTagName('head')[0].appendChild(jq);");

                Thread.Sleep(300);
            }
            var formattedSelector = selector.IndexOf("$(", StringComparison.InvariantCultureIgnoreCase) == -1 ? string.Format("$(\"{0}\")", selector.Replace('\"', '\'')) : selector;

            var elements = FindElements(driver, formattedSelector);

            if (!elements.Any())
            {
                Thread.Sleep(4000);

                elements = FindElements(driver, formattedSelector);

                if (!elements.Any())
                    throw new InvalidOperationException("No element found with selector " + formattedSelector);
            }
            if (elements.Count() > 1)
                throw new InvalidOperationException(
                    string.Format(
                        "Multiple elements found with selector {0}. Make sure that the selector uniquely identifies a single element.",
                        formattedSelector));

            return elements.FirstOrDefault() as IWebElement;
        }

        private static IEnumerable<object> FindElements(IWebDriver driver, string selector)
        {
            const string ret = "return ";
            var result = ((IJavaScriptExecutor)driver).ExecuteScript(
                (selector.StartsWith(ret, StringComparison.InvariantCultureIgnoreCase) ? string.Empty : ret) + selector);
            return result as IEnumerable<object>;
        }

        public static void GoToUrl(this IWebDriver driver, string url)
        {
            driver.Navigate().GoToUrl(url);
        }
    }
}