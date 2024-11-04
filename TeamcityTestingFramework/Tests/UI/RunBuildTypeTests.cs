using TeamcityTestingFramework.src.Api.Models;
using TeamcityTestingFramework.src.UI.Pages;

namespace TeamcityTestingFramework.Tests.UI
{
    [Category("Regression"), Category("UI")]
    public class RunBuildTypeTests : BaseUITest
    {
        [Test(Description = "User should be able to start build and get success build result")]
        [Category("Positive")]
        public async Task UserStartsBuildAndGetsSuccessResult()
        {
            // prepare data
            CreateProjectWithBuildType();
            await LoginAsAsync(TestData.User);

            // ui steps
            var buildConfigurtationPage = new BuildConfigurationPage(Page);
            await buildConfigurtationPage.NavigateAsync(TestData.BuildType.id);
            await buildConfigurtationPage.RunButton.ClickAsync();

            // TODO
        }
    }
}
