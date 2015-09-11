using Prism.Unity;
using Microsoft.Practices.Unity;
using Xamarin.Forms;
using AuthSample.Views;
using AuthSample.ViewModels;

namespace AuthSample
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override Page CreateMainPage()
        {            
            return Container.Resolve<MainPage>();
        }

        // THIRD ATTEMPT on iOS -- see if this flow makes a difference.   It didn't.
        //
        //protected override void InitializeMainPage()
        //{
        //    if (!AuthSample.App.IsLoggedIn)
        //    {
        //        var viewModel = App.MainPage.BindingContext;
        //        (viewModel as MainPageViewModel).NavService.Navigate("LoginPage");
        //    }
        //}

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<LoginPage>();
        }
    }
}
