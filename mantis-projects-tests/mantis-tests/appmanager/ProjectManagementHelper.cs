using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace mantis_projects_tests
{
    public class ProjectManagementHelper : HelperBase
    {
        public ProjectManagementHelper(ApplicationManager manager) : base(manager) { }

        public void Create(ProjectData project)
        {
            manager.Navigator.OpenManagementPage();
            manager.Navigator.OpenProjectsManagementPage();

            InitProjectCreation();
            FillProjectForm(project);
            SubmitProjectCreation();
        }

        internal void Delete(int projectNumber)
        {
            manager.Navigator.OpenManagementPage();
            manager.Navigator.OpenProjectsManagementPage();

            Select(projectNumber);
            Delete();
            ConfirmDeletion();
        }

        public List<ProjectData> GetProjectsList()
        {
            List<ProjectData> projects = new List<ProjectData>();

            manager.Navigator.OpenManagementPage();
            manager.Navigator.OpenProjectsManagementPage();
            ICollection<IWebElement> elements = driver.FindElements(By.XPath("//div[2]/div[2]/div[1]/div/table/tbody/tr"));
            foreach (IWebElement element in elements)
            {
                projects.Add(new ProjectData(element.FindElement(By.TagName("a")).Text));
            }
            return projects;
        }

        private void InitProjectCreation()
        {
            driver.FindElements(By.CssSelector("button[type='submit']"))[0].Click();
        }

        private void FillProjectForm(ProjectData project)
        {
            Type(By.Id("project-name"), project.ProjectName);
            Type(By.Id("project-description"), project.Description);
        }

        private void SubmitProjectCreation()
        {
            driver.FindElement(By.CssSelector("input[type='submit']"))
                .Click();

            //wait for redirection to ProjectsList
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IWebElement result = wait.Until(x => x.FindElement(By.CssSelector("div.table-responsive")));
        }

        internal void CreateProjectIfNeeded(ProjectData project)
        {
            manager.Navigator.OpenManagementPage();
            manager.Navigator.OpenProjectsManagementPage();
            if (!IsElementPresent(By.XPath("//tr[1]/td/a")))
            {
                Create(project);
            }
        }

        private void Select(int projectNumber)
        {
            driver.FindElement(By.XPath("//tr[" + (projectNumber + 1) + "]/td/a")).Click();
        }

        private void Delete()
        {
            driver.FindElement(By.CssSelector("input[value='Удалить проект']")).Click();
        }

        private void ConfirmDeletion()
        {
            driver.FindElement(By.CssSelector("input[value='Удалить проект']")).Click();
        }
    }
}