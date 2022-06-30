using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using NUnit.Framework;
using Autotests_1.Model;

namespace Autotests_1.Tests
{
    [TestFixture]
    public class LoginTests: TestBase
    {
        [Test]
        public void DoLoginWithValidData()
        {
            app.Auth.Logout();
            Thread.Sleep(5 * 1000);

            app.Navigation.GoToLoginPage();

            AccountData user = new AccountData(Settings.Login, Settings.Password);
            app.Auth.Login(user);
            Thread.Sleep(10 * 1000);

            string requiredElement = "Выйти";
            string element = app.Auth.GetOnlyLoggedInElem();

            Assert.AreEqual(requiredElement, element);

            app.Auth.Logout();
            Thread.Sleep(5 * 1000);
        }

        [Test]
        public void LoginWithInvalidData()
        {
            app.Auth.Logout();
            Thread.Sleep(5 * 1000);

            app.Navigation.GoToLoginPage();

            AccountData user = new AccountData(Settings.Login + "1", Settings.Password + "1");
            app.Auth.Login(user);
            Thread.Sleep(10 * 1000);

            string requiredElement = "Выйти";
            string element = app.Auth.GetOnlyLoggedOutElem(requiredElement);

            Assert.AreNotEqual(requiredElement, element);
        }
    }
}
