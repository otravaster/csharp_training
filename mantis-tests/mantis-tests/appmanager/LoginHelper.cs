using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace mantis_tests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager)
        { 
        }

        public void Login(AccountData account)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account))
                {
                    return;
                }

                Logout();
            }
            Type(By.Name("username"), account.Name);
            driver.FindElement(By.CssSelector("input[value='Вход']")).Click();

            Type(By.Name("password"), account.Password);
            driver.FindElement(By.CssSelector("input[value='Вход']")).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement result = wait.Until(x => x.FindElement(By.CssSelector("span.user-info")));
        }

        public void Logout()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.CssSelector("span.user-info")).Click();
                driver.FindElement(By.CssSelector("a[href = '/mantisbt-2.25.2/logout_page.php']")).Click();

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement result = wait.Until(x => x.FindElement(By.Id("login-box")));
            }
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.CssSelector("span.user-info"));
        }

        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn()
                && GetLoggedUserName() == account.Name;
        }

        public string GetLoggedUserName()
        {
            return driver.FindElement(By.CssSelector("span.user-info")).Text;
        }
    }
}
