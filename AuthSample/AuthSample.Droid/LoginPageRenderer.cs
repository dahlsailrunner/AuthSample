using System;
using Android.App;
using Xamarin.Forms;
using AuthSample;
using AuthSample.Droid;
using Xamarin.Forms.Platform.Android;
using Xamarin.Auth;

[assembly: ExportRenderer(typeof(LoginPage), typeof(LoginPageRenderer))]
namespace AuthSample.Droid
{
    public class LoginPageRenderer : PageRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            var activity = Context as Activity;

            var auth = new OAuth2Authenticator(
                clientId: "actioncenterapp", // OAuth2 client id
                scope: "actioncenter", // the scopes for the particular API you're accessing, delimited by "+" symbols
                authorizeUrl: new Uri("https://idsat.nwpsmart.com/identity/connect/authorize"), // the auth URL for the service
                redirectUrl: new Uri("https://actioncenterapp/callback/")); // the redirect URL for the service

            auth.Completed += (sender, eventArgs) =>
            {
                if (eventArgs.IsAuthenticated)
                {                    
                    App.SaveToken(eventArgs.Account.Properties["access_token"]);
                    var page = Element as LoginPage;
                    page?.NavigateToHome();                 
                }
                else
                {
                    // The user cancelled
                }
            };

            activity.StartActivity(auth.GetUI(activity));
        }
    }
}
