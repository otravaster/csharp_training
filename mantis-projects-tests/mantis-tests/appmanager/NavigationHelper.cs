using OpenQA.Selenium;

namespace mantis_projects_tests
{
    public class NavigationHelper : HelperBase
    {
        private string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }

        public void OpenManagementPage()
        {
            if (driver.Url == baseURL + "/manage_overview_page.php")
            {
                return;
            }
            driver.FindElement(By.CssSelector("a[href='/mantisbt-2.25.2/manage_overview_page.php']")).Click();
        }

        public void OpenProjectsManagementPage()
        {
            if (driver.Url == baseURL + "/manage_proj_page.php")
            {
                return;
            }
            driver.FindElement(By.CssSelector("a[href='/mantisbt-2.25.2/manage_proj_page.php']")).Click();
        }
    }
}
