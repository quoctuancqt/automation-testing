using Automation.Test.Core.Data;
using Automation.Test.Core.Factories;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace Automation.Test.Core
{
    public class Browser
    {
        public const string Host = "http://testserver.local";
        public IWebDriver WebDriver { get; private set; }
        public IRemoteBrowserMobProxyClient ProxyClient { get; private set; }
        public IRemoteBrowserMobProxyInstance ProxyInstance { get; private set; }

        public Browser()
        {
            ProxyClient = new RemoteBrowserMobProxyClient(new Uri($"{Host}:58080"));

            ProxyInstance = ProxyClient.NewRemoteBrowserMobProxyInstance(8081);

            ProxyInstance.SetWaitTimeouts(new WaitTimeouts { quietPeriodInMs = 1000 });

            var proxy = new Proxy { Kind = ProxyKind.Manual, IsAutoDetect = false, HttpProxy = $"{Host}:58081" };

            var options = new ChromeOptions
            {
                Proxy = proxy
            };

            options.AddArgument("start-maximized");
            options.AddArgument("ignore-certificate-errors");
            options.AddArgument("no-sandbox");

            WebDriver = DriverFactory.Create(Host, options);
        }
    }
}
