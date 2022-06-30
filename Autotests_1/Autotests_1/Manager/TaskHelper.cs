using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Text.RegularExpressions;

namespace Autotests_1
{
    public class TaskHelper: HelperBase
    {
        public TaskHelper(ApplicationManager manager)
            : base(manager)
        {
        }

        public void CreateTask(TaskData taskData)
        {
            driver.FindElement(By.Id("create-task-btn")).Click();
            driver.FindElement(By.XPath("//div[@id='app']/div[4]/div[3]/div/div/div/div[2]/div/div[3]")).Click();
            driver.FindElement(By.XPath("//header[@id='task-modal___BV_modal_header_']/div/div[2]/input")).Click();
            driver.FindElement(By.XPath("//header[@id='task-modal___BV_modal_header_']/div/div[2]/input")).Clear();
            driver.FindElement(By.XPath("//header[@id='task-modal___BV_modal_header_']/div/div[2]/input")).SendKeys(taskData.Header);
            driver.FindElement(By.XPath("//header[@id='task-modal___BV_modal_header_']/div/div[3]/textarea")).Click();
            driver.FindElement(By.XPath("//header[@id='task-modal___BV_modal_header_']/div/div[3]/textarea")).Clear();
            driver.FindElement(By.XPath("//header[@id='task-modal___BV_modal_header_']/div/div[3]/textarea")).SendKeys(taskData.Description);
            driver.FindElement(By.XPath("//header[@id='task-modal___BV_modal_header_']/div/div/div/button[2]/div")).Click();
        }

        public void ChangeTask(TaskData taskData)
        {
            driver.FindElement(By.CssSelector("div.svg-icon.dropdown-icon > svg > path")).Click();
            driver.FindElement(By.XPath("//div[@id='app']/div[4]/div[3]/div/div/div[2]/div[3]/div[2]/div[3]/div/div/div/div[2]/div/div/div/div[2]/div/div")).Click();
            driver.FindElement(By.XPath("//header[@id='task-modal___BV_modal_header_']/div/div[2]/input")).Clear();
            driver.FindElement(By.XPath("//header[@id='task-modal___BV_modal_header_']/div/div[2]/input")).SendKeys(taskData.Header);
            driver.FindElement(By.XPath("//header[@id='task-modal___BV_modal_header_']/div/div[3]/textarea")).Click();
            driver.FindElement(By.XPath("//header[@id='task-modal___BV_modal_header_']/div/div[3]/textarea")).Clear();
            driver.FindElement(By.XPath("//header[@id='task-modal___BV_modal_header_']/div/div[3]/textarea")).SendKeys(taskData.Description);
            driver.FindElement(By.XPath("//header[@id='task-modal___BV_modal_header_']/div/div/div/button[2]/div")).Click();
        }

        public void DeleteTask()
        {
            acceptNextAlert = true;
            driver.FindElement(By.CssSelector("div.svg-icon.dropdown-icon > svg > path")).Click();
            driver.FindElement(By.XPath("//div[@id='app']/div[4]/div[3]/div/div/div[2]/div[3]/div[2]/div[3]/div/div/div/div[2]/div/div/div/div[2]/div/div[4]/span/span[2]")).Click();
            Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Вы уверены, что хотите удалить задачу[\\s\\S]$"));
        }

        public TaskData GetCreatedTaskData()
        {
            string foundHeader = string.Empty;
            string foundDescription = string.Empty;

            try
            {
                foundHeader = driver.FindElement(By.XPath("//div[@id='app']/div[4]/div[3]/div/div/div[2]/div[3]/div[2]/div[3]/div/div/div/div[2]/div/div/h3/p")).Text;
                foundDescription = driver.FindElement(By.XPath("//div[@id='app']/div[4]/div[3]/div/div/div[2]/div[3]/div[2]/div[3]/div/div/div/div[2]/div/div[2]/p")).Text;
            }
            catch (NoSuchElementException)
            {
                return new TaskData(foundHeader, foundDescription);
            }

            return new TaskData(foundHeader, foundDescription);
        }

        public TaskData GetChangedTaskData()
        {
            driver.FindElement(By.XPath("//div[@id='app']/div[4]/div[3]/div/div/div[2]/div[3]/div[2]/div[3]/div/div/div/div[2]/div/div")).Click();
            string header = driver.FindElement(By.XPath("//header[@id='task-modal___BV_modal_header_']/div/div[2]/input")).GetAttribute("value");
            string description = driver.FindElement(By.XPath("//header[@id='task-modal___BV_modal_header_']/div/div[3]/textarea")).GetAttribute("value");
            driver.FindElement(By.XPath("//header[@id='task-modal___BV_modal_header_']/div/div/div/button[2]/div")).Click();
            return new TaskData(header, description);
        }



    }
}
