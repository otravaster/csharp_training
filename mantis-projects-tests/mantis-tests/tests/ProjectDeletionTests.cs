using NUnit.Framework;
using System.Collections.Generic;

namespace mantis_projects_tests
{
    [TestFixture]
    public class ProjectDeletionTests : AuthTestBase
    {
        [Test]
        public void ProjectDeletionTest()
        {
            app.ProjectManagement.CreateProjectIfNeeded(new ProjectData(GetRandomString(10))
            {
                Description = GetRandomString(15),
            });
            List<ProjectData> oldProjects = app.ProjectManagement.GetProjectsList();
            app.ProjectManagement.Delete(0);
            List<ProjectData> newProjects = app.ProjectManagement.GetProjectsList();
            oldProjects.RemoveAt(0);

            Assert.AreEqual(oldProjects, newProjects);
        }

        [Test]
        public void ProjectDeletionTestWithAPI()
        {
            AccountData account = new AccountData("administrator", "root");
            ProjectData project = new ProjectData()
            {
                ProjectName = GetRandomString(10),
                Description = GetRandomString(15),
            };

            app.API.CreateProjectIfNeededAPI(account, project);
            List<ProjectData> oldProjects = app.API.GetProjectsListAPI(account);

            app.ProjectManagement.Delete(0);

            List<ProjectData> newProjects = app.API.GetProjectsListAPI(account);
            oldProjects.RemoveAt(0);

            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}
