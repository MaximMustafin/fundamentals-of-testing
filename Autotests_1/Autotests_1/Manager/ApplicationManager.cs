using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Autotests_1.Model;

namespace Autotests_1
{
    public class ApplicationManager
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;

        private NavigationHelper navigation;
        private LoginHelper auth;
        private TaskHelper task;
        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new ChromeDriver(@"D:\");
            driver.Manage().Window.Maximize();
            baseURL = Settings.BaseURL;
            verificationErrors = new StringBuilder();
            task = new TaskHelper(this);
            auth = new LoginHelper(this);
            navigation = new NavigationHelper(this, baseURL);

        }

        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch(Exception)
            {
                //Ignore
            }
        }

        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                //newInstance.Navigation.GoToHomePage();
                //newInstance.Navigation.GoToLoginPage();

                //AccountData user = new AccountData("Mus-Maxim", "8vXP56ghhab");
                //newInstance.Auth.Login(user);
                //Thread.Sleep(10 * 1000);

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
        public NavigationHelper Navigation
        {
            get
            {
                return navigation;
            }
        }

        public LoginHelper Auth
        {
            get
            {
                return auth;
            }
        }
        public TaskHelper Task
        {
            get
            {
                return task;
            }
        }

    }
}
