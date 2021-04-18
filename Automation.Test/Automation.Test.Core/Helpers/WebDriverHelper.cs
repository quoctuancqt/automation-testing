using OpenQA.Selenium;

namespace Automation.Test.Core
{
    public static class WebDriverHelper
    {
        public static By SelectorByAttributeValue(string attributeValue, string attrubuteName = "attr-test")
        {
            return (By.XPath($"//*[@{attrubuteName} = '{attributeValue}']"));
        }
    }
}