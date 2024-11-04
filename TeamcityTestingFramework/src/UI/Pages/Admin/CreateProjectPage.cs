﻿using Microsoft.Playwright;
using TeamcityTestingFramework.src.Api.Generators;
using TeamcityTestingFramework.src.Api.Enums;
using TeamcityTestingFramework.src.Api.Models;
using System.Text.RegularExpressions;

namespace TeamcityTestingFramework.src.UI.Pages.Admin
{
    public class CreateProjectPage : CreateBasePage
    {
        private static readonly string PROJECT_SHOW_MODE = "createProjectMenu";

        private ILocator _projectNameInput;

        public CreateProjectPage(IPage page) : base(page)
        {
            _projectNameInput = Page.Locator("#projectName");
        }

        public async Task NavigateAsync(string projectId = "_Root")
        {
            await Page.GotoAsync(string.Format(CREATE_URL, projectId, PROJECT_SHOW_MODE));
        }

        public async Task CreateForm(string repoUrl)
        {
            await BaseCreateFormAsync(repoUrl);
        }

        public async Task SetupProjectAsync(string projectName, string buildType)
        {
            await _projectNameInput.FillAsync(projectName);
            await BuildTypeInput.FillAsync(buildType);
            await SubmitButton.ClickAsync();
            await Page.WaitForURLAsync($"**{BuildTypeDetailsPage.PAGE_URL}**");
            TestDataStorage.GetInstance().AddCreatedEntity(Endpoint.PROJECTS, new Project() { id = getProjectId(Page.Url) });
        }

        private string getProjectId(string url)
        {
            string pattern = @"buildType:([a-zA-Z0-9]+)_";
            var regex = new Regex(pattern);
            var match = regex.Match(url);
            if (match.Success)
            {
                // Extract the project ID from the matched group
                return match.Groups[1].Value;
            }
            else
            {
                throw new KeyNotFoundException("No match found.");
            }
        }
    }
}
