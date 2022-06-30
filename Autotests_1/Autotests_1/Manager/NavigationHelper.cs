using OpenQA.Selenium;

namespace Autotests_1
{
    public class NavigationHelper: HelperBase
    {
        private string baseURL;
        public NavigationHelper(ApplicationManager manager, string baseURL)
                    : base(manager)
        {
            this.baseURL = baseURL;
        }

        public void GoToHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }

        public void GoToLoginPage()
        {
            driver.FindElement(By.LinkText("Вход")).Click();
        }
    }
}
