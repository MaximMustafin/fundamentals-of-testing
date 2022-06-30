using System;
using System.Threading;
using OpenQA.Selenium;

namespace Autotests_1
{
    public class LoginHelper: HelperBase
    {
        public LoginHelper(ApplicationManager manager)
            : base(manager)
        {
        }

        public bool IsLoggedIn()
        {
            try
            {
                if (GetOnlyLoggedInElem() == "Выйти") return true;               
            }
            catch (Exception)
            {
                return false;
            }

            return false;
        }

        public bool IsLoggedIn(string username) 
        {
            try
            {
                if (driver.FindElement(By.XPath("//div[@id='app-header']/div[2]/div[2]/div/div[2]/h3/span")).Text == username) return true;
            }
            catch 
            {
                return false;
            }
           
            return false;
        }

        public void Login(AccountData user)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(user.Username))
                {
                    return;
                }
                Logout();
            }

            driver.FindElement(By.Id("usernameInput")).Click();
            driver.FindElement(By.Id("usernameInput")).Clear();
            driver.FindElement(By.Id("usernameInput")).SendKeys(user.Username);
            driver.FindElement(By.Id("passwordInput")).Click();
            driver.FindElement(By.Id("passwordInput")).Clear();
            driver.FindElement(By.Id("passwordInput")).SendKeys(user.Password);
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
        }

        public bool IsLoggedOut()
        {
            try 
            {
                if (GetOnlyLoggedOutElem("Вход") == "Вход") return true;
            }
            catch (Exception) 
            {
                return false;
            }

            return false;
            
        }

        public void Logout()
        {
            if (IsLoggedOut()) 
            {
                return;
            }
            else
            {
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Вики'])[1]/following::*[name()='svg'][5]")).Click();
                driver.FindElement(By.XPath("//div[@id='menu_collapse']/div[2]/div[2]/div[2]/div/a[9]")).Click();
            }
            
        }

        public string GetOnlyLoggedInElem()
        {
            try 
            {
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Вики'])[1]/following::*[name()='svg'][5]")).Click();
            }
            catch (Exception)        
            {
                return null;
            }
            
            string element= driver.FindElement(By.XPath("//div[@id='menu_collapse']/div[2]/div[2]/div[2]/div/a[9]")).Text;
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Вики'])[1]/following::*[name()='svg'][5]")).Click();
            return element;
        }

        public string GetOnlyLoggedOutElem(string requiredElementText) 
        {
            try 
            {
                driver.FindElement(By.LinkText(requiredElementText));
            }
            catch (Exception)
            {
                return null;
            }

            string element = driver.FindElement(By.LinkText(requiredElementText)).Text;
       
            return element;
        }
    }
}
