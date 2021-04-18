using Automation.Test.Core;

namespace Automation.Test.Sample
{
    public class Pages
    {
        public Browser Browser;

        public Pages(Browser browser)
        {
            Browser = browser;
        }

        public TestPage TestPage
        {
            get
            {
                return new TestPage(Browser);
            }
        }
    }
}
