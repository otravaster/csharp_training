using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Threading;

namespace mantis_projects_tests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;

        public LoginHelper Auth { get; set; }
        public NavigationHelper Navigator { get; set; }
        public ProjectManagementHelper ProjectManagement { get; set; }
        public ManagementMenuHelper ManagementMenu { get; set; }
        public APIHelper API { get; set; }
        
        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/mantisbt-2.25.2";
            Auth = new LoginHelper(this);
            Navigator = new NavigationHelper(this, baseURL);
            ProjectManagement = new ProjectManagementHelper(this);
            ManagementMenu = new ManagementMenuHelper(this, baseURL);
            API = new APIHelper(this);
        }

        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public static ApplicationManager GetInstance()
        {
            if (! app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.driver.Url = "http://localhost/mantisbt-2.25.2/login_page.php";
                app.Value = newInstance;
            }
            return app.Value;
        }

        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }
    }
}
