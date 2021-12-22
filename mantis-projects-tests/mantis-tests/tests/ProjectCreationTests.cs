using NUnit.Framework;
using System.Collections.Generic;

namespace mantis_projects_tests
{
    [TestFixture]
    public class ProjectCreationTests : AuthTestBase
    {
        [Test]
        public void ProjectCreationTest()
        {
            ProjectData project = new ProjectData(GetRandomString(10))
            {
                Description = GetRandomString(15),
            };
            List<ProjectData> oldProjects = app.ProjectManagement.GetProjectsList();
            app.ProjectManagement.Create(project);
            List<ProjectData> newProjects = app.ProjectManagement.GetProjectsList();
            oldProjects.Add(project);
            oldProjects.Sort();
            newProjects.Sort();

            Assert.AreEqual(oldProjects, newProjects);
        }

        [Test]
        public void ProjectCreationTestWithAPI()
        {
            AccountData account = new AccountData("administrator", "root");
            ProjectData project = new ProjectData(GetRandomString(10))
            {
                Description = GetRandomString(15),
            };
            List<ProjectData> oldProjects = app.API.GetProjectsListAPI(account);

            app.ProjectManagement.Create(project);

            List<ProjectData> newProjects = app.API.GetProjectsListAPI(account);
            oldProjects.Add(project);
            oldProjects.Sort();
            newProjects.Sort();

            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}
