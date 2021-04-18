using Automation.Test.Core;
using Automation.Test.Core.Extensions;

namespace Automation.Test.Sample
{
    public class TestPage : PageBase, IPageObject
    {
        public TestPage(Browser browser) : base(browser)
        {
        }

        public void GoToVnExpress()
        {
            WebDriver.GoToUrl($"https://vnexpress.net/");
        }
    }
}
