using Automation.Test.Core;
using System;
using System.Linq;

namespace Automation.Test.Sample
{
    public class SampleFixture : IDisposable
    {
        public Pages Pages { get; private set; }

        public SampleFixture()
        {
            Pages = new Pages(new Browser());
        }

        public void Dispose()
        {
            Pages.Browser.ProxyInstance.Dispose();
            Pages.Browser.ProxyClient.RemoteBrowserMobProxyInstances().ToList().ForEach(p => p.Dispose());
            Pages.Browser.WebDriver.Dispose();
        }
    }
}
