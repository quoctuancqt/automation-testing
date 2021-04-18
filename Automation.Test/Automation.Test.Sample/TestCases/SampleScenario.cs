using Xunit;

namespace Automation.Test.Sample.TestCases
{
    public class SampleScenario : IClassFixture<SampleFixture>
    {
        private SampleFixture _fixture;

        private TestPage TestPage => _fixture.Pages.TestPage;

        public SampleScenario(SampleFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void Go_To_VnExpress_Successfully()
        {
            TestPage.GoToVnExpress();

            Assert.Equal("VnExpress - Báo tiếng Việt nhiều người xem nhất", TestPage.Browser.WebDriver.Title);
        }
    }
}
