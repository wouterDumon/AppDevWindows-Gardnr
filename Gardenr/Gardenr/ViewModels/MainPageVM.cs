using Facebook;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Gardenr.Mesages;
using Gardenr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Store;
using Windows.Security.Authentication.Web;

namespace Gardenr.ViewModels
{
    //erven niet vergeten is verplicht!
    public class MainPageVM : ViewModelBase
    {
      
        public MainPageVM()
        {
            
            Testing = new RelayCommand(TestingM);
        }
        private string AppId = Constants.FacebookAppId;
        private const string ExtendedPermissions = "public_profile";
        private async Task<string> Facebook() {
            try
            {
                var fb = new FacebookClient();
                var redirectUri = WebAuthenticationBroker.GetCurrentApplicationCallbackUri().ToString();
                var loginUri = fb.GetLoginUrl(new
                {
                    client_id = AppId,
                    redirect_uri = redirectUri,
                    scope = ExtendedPermissions,
                    display = "popup",
                    response_type = "token"
                });

                var callbackUri = new Uri(redirectUri, UriKind.Absolute);

                var authenticationResult =
                  await
                    WebAuthenticationBroker.AuthenticateAsync(
                    WebAuthenticationOptions.None,
                    loginUri, callbackUri);

                return ParseAuthenticationResult(fb, authenticationResult);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string ParseAuthenticationResult(FacebookClient fb,
                                            WebAuthenticationResult result)
        {
            switch (result.ResponseStatus)
            {
                case WebAuthenticationStatus.ErrorHttp:
                    return "Error";
                case WebAuthenticationStatus.Success:

                    var oAuthResult = fb.ParseOAuthCallbackUrl(new Uri(result.ResponseData));
                    return oAuthResult.AccessToken;
                case WebAuthenticationStatus.UserCancel:
                    return "Operation aborted";
            }
            return null;
        }

 
        public RelayCommand Testing { get; set; }
        public async void TestingM()
        {
            if (!App.isAuthenticated)
            {
                try
                {
                    App.AccessToken = await Facebook();
                    var client = new FacebookClient(App.AccessToken);
                    dynamic me = await client.GetTaskAsync("me");
                    App.FacebookId = "" + me.id;
                    App.isAuthenticated = true;
                     GoToPageMessage message = new GoToPageMessage() { PageNumber = 1 };
            Messenger.Default.Send<GoToPageMessage>(message);
                }
                catch (Exception)
                {

                    App.isAuthenticated = false;
                }
              
            }
       /*
            GoToPageMessage message = new GoToPageMessage() { PageNumber = 1 };
            Messenger.Default.Send<GoToPageMessage>(message);*/
        }

    }
}
