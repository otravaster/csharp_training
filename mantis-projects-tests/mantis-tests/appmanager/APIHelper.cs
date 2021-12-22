using OpenQA.Selenium;
using System.Collections.Generic;
using mantis_tests.Mantis;

namespace mantis_projects_tests
{
    public class APIHelper : HelperBase
    {
        public APIHelper(ApplicationManager manager) : base(manager) { }

        public void CreateProject(AccountData account, ProjectData projectData)
        {
            mantis_tests.Mantis.MantisConnectPortTypeClient client = new mantis_tests.Mantis.MantisConnectPortTypeClient();
            mantis_tests.Mantis.ProjectData project = new mantis_tests.Mantis.ProjectData();
            project.name = projectData.ProjectName;
            project.description = projectData.Description;
            client.mc_project_add(account.Name, account.Password, project);
        }

        public List<ProjectData> GetProjectsListAPI(AccountData account)
        {
            List<ProjectData> projects = new List<ProjectData>();
            mantis_tests.Mantis.MantisConnectPortTypeClient client = new mantis_tests.Mantis.MantisConnectPortTypeClient();
            mantis_tests.Mantis.ProjectData[] list = client.mc_projects_get_user_accessible(account.Name, account.Password);
            foreach (mantis_tests.Mantis.ProjectData l in list)
            {
                projects.Add(new ProjectData(l.name));
            }
            return projects;
        }

        public void CreateProjectIfNeededAPI(AccountData account, ProjectData projectData)
        {
            manager.Navigator.OpenManagementPage();
            manager.ManagementMenu.OpenProjectsManagementPage();
            if (!IsElementPresent(By.XPath("//tr[1]/td/a")))
            {
                CreateProject(account, projectData);
            }
        }
    }
}
