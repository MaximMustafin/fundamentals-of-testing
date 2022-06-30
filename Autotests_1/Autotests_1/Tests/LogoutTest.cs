using System.Threading;
using NUnit.Framework;

namespace Autotests_1.Tests
{
    [TestFixture]
    public class LogoutTest : AuthBase
    {
        [Test]
        public void DoLogoutTest()
        {
            app.Auth.Logout();
            Thread.Sleep(5 * 1000);

            string requiredElementText = "Вход";
            string element = app.Auth.GetOnlyLoggedOutElem(requiredElementText);

            Assert.AreEqual(requiredElementText, element);
        }
    }
}
