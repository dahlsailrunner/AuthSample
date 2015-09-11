using AuthSample.Events;
using Microsoft.Practices.ServiceLocation;
using Prism.Events;
using Xamarin.Forms;

namespace AuthSample
{
    public class LoginPage : ContentPage
    {
        private readonly IEventAggregator _ea;
        public LoginPage()
        {
            _ea = ServiceLocator.Current.GetInstance<IEventAggregator>();
        }

        public void NavigateToHome()
        {
            _ea.GetEvent<LoggedInEvent>().Publish(""); // empty string is needed but we really are just publishing the fact that login was done

            // PROBLEM:  This does not remove the view in iOS - presumably because their is nothing 
            //     under it on Navigation.ModalStack like there is in Android.
            Navigation.PopModalAsync();
        }
    }
}
