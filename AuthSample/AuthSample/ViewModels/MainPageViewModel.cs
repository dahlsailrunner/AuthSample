using System;
using AuthSample.Events;
using Prism.Commands;
using Prism.Events;
using Prism.Navigation;

namespace AuthSample.ViewModels
{
    public class MainPageViewModel : MyBindableBase, INavigationAware
    {
        public DelegateCommand NavigateCommand { get; set; }        

        string _title = "Main Page";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value);  }
        }        

        public MainPageViewModel(INavigationService navigationService, IEventAggregator eventAggregator) : base(navigationService, eventAggregator)
        {            
            Title = "Main Page from Constructor";
            EventAgg.GetEvent<LoggedInEvent>().Subscribe(HandleLoginEvent);
            NavigateCommand = new DelegateCommand(Navigate);
        }

        private void Navigate()
        {
            NavService.Navigate("LoginPage");
        }

        private void HandleLoginEvent(string notReallyUsedButNeeded)
        {
            Title = "Main Page after Login Event";
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            //throw new NotImplementedException();
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            Title = "Main Page from Navigation";
        }
    }
}
