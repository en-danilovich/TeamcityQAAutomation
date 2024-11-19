﻿using TeamcityTestingFramework.src.UI.Pages.Setup;

namespace TeamcityTestingFramework.Tests.UI
{
    public class SetupServerTests : BaseUITest
    {
        [Test, Category("Setup")]
        public async Task SetupTeamCityServer()
        {
            var firstStartPage = new FirstStartPage(Page);
            await firstStartPage.NavigateAsync();
            await firstStartPage.SetupFirstStartAsync();
        }
    }
}