using System.Threading;
using NUnit.Framework;

namespace Autotests_1.Tests
{
    //[TestFixture]
    public class LoginTest : TestBase
    {
        //[Test]
        public void DoLoginTest()
        {
            app.Auth.Logout();
            Thread.Sleep(5 * 1000);

            app.Navigation.GoToLoginPage();
            AccountData user = new AccountData("Mus-Maxim", "8vXP56ghhab");
            app.Auth.Login(user);
            Thread.Sleep(10 * 1000);

            string requiredElement = "Выйти";
            string element = app.Auth.GetOnlyLoggedInElem();

            Assert.AreEqual(requiredElement, element);
        }
    }
}
