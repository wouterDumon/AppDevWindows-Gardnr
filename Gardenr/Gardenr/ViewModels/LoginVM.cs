using Facebook;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using Gardenr.Mesages;
using Gardenr.Models;
using Gardenr.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Authentication.Web;

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
                    Gebruiker gebruiker = await repoGebruiker.GetGebruiker(App.FacebookId);

                    
                    if(gebruiker == null)
                    {
                        Gebruiker newgebruiker = new Gebruiker();
                        newgebruiker.Active = true;
                        newgebruiker.Facebook = App.FacebookId;
                      
                        newgebruiker.Naam = me.name.Split(" ".ToCharArray())[1];
                        newgebruiker.Voornaam = me.name.Split(" ".ToCharArray())[0];


                        //standaard isntelling
                        Instellingen tempinst = new Instellingen();
                        tempinst = await repoInstellingen.GetInst("1");
                        // standaardtaal ophale uit database id = 1
                        Taal a = new Taal();
                        a = await ta.GetTaalById("1");
                        newgebruiker.Instellingen.Taal = a;
                        newgebruiker.Instellingen = tempinst;

                        repoGebruiker.AddGebruiker(newgebruiker);
                    }
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
