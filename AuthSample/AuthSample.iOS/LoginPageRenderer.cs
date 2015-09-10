using AuthSample;
using AuthSample.iOS;
using System;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(LoginPage), typeof(LoginPageRenderer))]
namespace AuthSample.iOS
{
    public class LoginPageRenderer : PageRenderer
    {
        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            var auth = new OAuth2Authenticator(
                clientId: "actioncenterapp", // your OAuth2 client id
                scope: "actioncenter", // the scopes for the particular API you're accessing, delimited by "+" symbols
                authorizeUrl: new Uri("https://idsat.nwpsmart.com/identity/connect/authorize"), // the auth URL for the service
                redirectUrl: new Uri("https://actioncenterapp/callback/")); // the redirect URL for the service
            auth.Completed += (sender, eventArgs) =>
            {
                DismissViewController(true, null);

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

            PresentViewController(auth.GetUI(), true, null);
        }
    }
}
