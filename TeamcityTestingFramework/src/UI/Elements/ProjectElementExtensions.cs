namespace TeamcityTestingFramework.src.UI.Elements
{
    public static class ProjectElementExtensions
    {
        public static ProjectElement FindProjectWithName(this List<ProjectElement> projects, string name)
        {
            var tasks = projects.Select(async project =>
            {
                var nameText = await project.Name.TextContentAsync();
                return (project, nameText);
            });
            var results = Task.WhenAll(tasks).GetAwaiter().GetResult();
            return results.Where(result => result.nameText == name).FirstOrDefault().project;
        }
    }
}
