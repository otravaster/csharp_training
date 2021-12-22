using NUnit.Framework;

namespace mantis_projects_tests
{
    [TestFixture]
    public class ProjectCreationTestsAPI : TestBase
    {
        [Test]
        public void ProjectCreationTestAPI()
        {
            AccountData account = new AccountData("administrator", "root");
            ProjectData projectData = new ProjectData()
            {
                ProjectName = GetRandomString(11),
                Description = GetRandomString(16),
            };

            app.API.CreateProject(account, projectData);
        }
    }
}
