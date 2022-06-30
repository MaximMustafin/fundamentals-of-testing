using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Xml.Serialization;
using NUnit.Framework;

namespace Autotests_1.Tests
{
    [TestFixture]
    public class CreateTaskTest : AuthBase
    {
        [Test, TestCaseSource("TaskDataFromXmlFile")]
        public void DoCreateTaskTest(TaskData task)
        {           
            app.Task.CreateTask(task);
            Thread.Sleep(5 * 1000);

            TaskData createdTask = app.Task.GetCreatedTaskData();
            Assert.AreEqual(task.Header, createdTask.Header);
            Assert.AreEqual(task.Description, createdTask.Description);

            app.Task.DeleteTask();
            Thread.Sleep(5 * 1000);

            app.Auth.Logout();
            Thread.Sleep(5 * 1000);
        }

        public static IEnumerable<TaskData> TaskDataFromXmlFile()
        {
            return (List<TaskData>)new XmlSerializer(typeof(List<TaskData>))
                .Deserialize(new StreamReader(@"D:\Study\Course 3\Testing\Practise\15 Oct 2021\Autotests_1\Generator Release\netcoreapp3.1\tasks.xml"));
        }
    }
}
