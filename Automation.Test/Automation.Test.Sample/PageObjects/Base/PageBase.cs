using OpenQA.Selenium;
using Automation.Test.Core;
using Automation.Test.Core.Data;

namespace Automation.Test.Sample
{
    public abstract class PageBase
    {
        protected readonly Browser _browser;

        protected IWebDriver WebDriver => Browser.WebDriver;

        protected IRemoteBrowserMobProxyClient ProxyClient => Browser.ProxyClient;

        protected IRemoteBrowserMobProxyInstance ProxyInstance => Browser.ProxyInstance;

        public string Host => Browser.Host;

        public Browser Browser => _browser;

        public PageBase(Browser browser)
        {
            _browser = browser;
        }

        public string CreateHar(string pageRef)
        {
            return ProxyInstance.CreateHar(new HarOptions { captureContent = true, captureBinaryContent = true, captureCookies = true, captureHeaders = true, initialPageRef = pageRef });
        }

        public HarSharp.Har GetHarContent()
        {
            return ProxyInstance.GetHarContent();
        }

        public string GetHarContentString()
        {
            return ProxyInstance.GetHarContentString();
        }
    }
}
