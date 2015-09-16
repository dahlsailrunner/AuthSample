using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthSample.Views;
using Xamarin.Forms;

namespace AuthSample
{
    public class HomePage: MasterDetailPage
    {
        public HomePage()
        {
            Master = new MainPage();
            
            Detail = new NavigationPage(new LoginPage());
        }
    }
}
