using Facebook;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using Gardenr.Mesages;
using Gardenr.Models;
using Gardenr.Repositories;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Authentication.Web;
using Windows.UI.Popups;

namespace Gardenr.ViewModels
{
    class LoginVM : ViewModelBase
    {
        public LoginVM()
        {
            Testing = new RelayCommand(TestingM);

        }
        private IGebruikerRepository repoGebruiker = SimpleIoc.Default.GetInstance<IGebruikerRepository>();
        private ITaalRepository ta = SimpleIoc.Default.GetInstance<ITaalRepository>();
        private IInstellingenRepository repoInstellingen = SimpleIoc.Default.GetInstance<IInstellingenRepository>();
        private string AppId = Constants.FacebookAppId;
        private const string ExtendedPermissions = "public_profile";
        private async Task<string> Facebook()
        {
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
        // Define a member variable for storing the signed-in user. 
        private MobileServiceUser user;

        // Define a method that performs the authentication process
        // using a Facebook sign-in. 
        private async System.Threading.Tasks.Task<bool> AuthenticateAsync()
        {
            string message;
            bool success = false;
            try
            {
                // Change 'MobileService' to the name of your MobileServiceClient instance.
                // Sign-in using Facebook authentication.
                user = await App.MobileService
                    .LoginAsync(MobileServiceAuthenticationProvider.Facebook);
                message =
                    string.Format("You are now signed in - {0}", user.UserId);
                App.AccessToken = user.UserId;

                success = true;
            }
            catch (InvalidOperationException)
            {
                message = "You must log in. Login Required";
            }

            var dialog = new MessageDialog(message);
            dialog.Commands.Add(new UICommand("OK"));
            await dialog.ShowAsync();
            return success;
        }

        public RelayCommand Testing { get; set; }
        public async void TestingM()
        {
            //if(await AuthenticateAsync())
            if (!App.isAuthenticated)
            {
                try
                {
                  //  bool b = await AuthenticateAsync();
                    App.AccessToken = await Facebook();
                    var client = new FacebookClient(App.AccessToken);
                    dynamic me = await client.GetTaskAsync("me");
                    App.FacebookId = "" + me.id;
                    App.isAuthenticated = true;
                    Gebruiker gebruiker = await repoGebruiker.GetGebruiker(App.FacebookId);
                    
                    //await App.store.DeleteAsync();

                    if (gebruiker == null)
                    {
                        gebruiker = new Gebruiker();
                       gebruiker.Active = true;
                       gebruiker.Facebook = App.FacebookId;
                      
                       gebruiker.Naam = me.name.Split(" ".ToCharArray())[1];
                       gebruiker.Voornaam = me.name.Split(" ".ToCharArray())[0];

                                         
              
                      gebruiker.InstellingenID = "1";

                        repoGebruiker.AddGebruiker(gebruiker);
                    }
                    App.Gebruiker = gebruiker;
                    //1 malig om de catalogus te vullen met planten
                   // Opvuller temp = new Opvuller();
                   // temp.VulCatalogus();

                    GoToPageMessage message = new GoToPageMessage() { PageNumber = 11 };
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
