using NUnit.Framework;

namespace Autotests_1
{
    public class TestBase
    {
        protected ApplicationManager app;

        [SetUp]
        public void SetupTest()
        {
            app = ApplicationManager.GetInstance();
            app.Navigation.GoToHomePage();
        }

    }
}
