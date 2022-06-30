using System.Threading;
using NUnit.Framework;

namespace Autotests_1.Tests
{
    [TestFixture]
    public class EditTaskTest : AuthBase
    {
        [Test]
        public void DoEditTaskTest()
        {
            TaskData task = new TaskData("Test1", "New Task Description1");
            app.Task.CreateTask(task);
            Thread.Sleep(5 * 1000);

            task.Header += " Change header";
            task.Description += " Change description";
            app.Task.ChangeTask(task);
            Thread.Sleep(5 * 1000);


            TaskData changedTask = app.Task.GetChangedTaskData();
            Assert.AreEqual(task.Header, changedTask.Header);
            Assert.AreEqual(task.Description, changedTask.Description);

            app.Task.DeleteTask();
            Thread.Sleep(5 * 1000);

            app.Auth.Logout();
            Thread.Sleep(5 * 1000);
        }
    }
}
