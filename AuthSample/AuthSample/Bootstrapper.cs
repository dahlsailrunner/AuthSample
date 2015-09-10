using Prism.Unity;
using Microsoft.Practices.Unity;
using Xamarin.Forms;
using AuthSample.Views;

namespace AuthSample
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override Page CreateMainPage()
        {
            return Container.Resolve<MainPage>();
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<LoginPage>();
        }
    }
}
