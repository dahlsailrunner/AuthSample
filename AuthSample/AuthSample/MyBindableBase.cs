using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;

namespace AuthSample
{
    public abstract class MyBindableBase: BindableBase
    {
        public readonly INavigationService NavService;
        public readonly IEventAggregator EventAgg;
        public MyBindableBase(INavigationService navigationService, IEventAggregator eventAggregator)
        {
            NavService = navigationService;
            EventAgg = eventAggregator;

            // FIRST ATTEMPT:  This doesn't seem to get the MainPage on the ModalStack in iOS.
            //if (!App.IsLoggedIn)
            //{
            //    NavService.Navigate("LoginPage");
            //}
        }
    }
}
