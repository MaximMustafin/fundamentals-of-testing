using NUnit.Framework;
using System.Threading;

namespace Autotests_1.Tests
{
    [TestFixture]
    public class DeleteTaskTest: AuthBase
    {
        [Test]
        public void DoDeleteTaskTest()
        {
            TaskData task = new TaskData("Test", "New Task Description");
            app.Task.CreateTask(task);
            Thread.Sleep(5 * 1000);

            app.Task.DeleteTask();
            Thread.Sleep(5 * 1000);

            TaskData deletedTask = app.Task.GetCreatedTaskData();
            Assert.AreNotEqual(task, deletedTask);

            app.Auth.Logout();
            Thread.Sleep(5 * 1000);
        }
    }
}
