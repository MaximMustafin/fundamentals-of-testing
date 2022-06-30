using NUnit.Framework;
using System.Threading;
using Autotests_1.Model;

namespace Autotests_1.Tests
{
    public class AuthBase: TestBase
    {
        [SetUp]
        public void SetupTestLoggedIn()
        {
            app.Navigation.GoToLoginPage();
            app.Auth.Login(new AccountData(Settings.Login, Settings.Password));
            Thread.Sleep(10 * 1000);
        }
    }
}
