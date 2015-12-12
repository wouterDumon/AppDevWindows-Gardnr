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
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Authentication.Web;
using Windows.Security.Credentials;
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
       private string provider = "Facebook";
        private async System.Threading.Tasks.Task<bool> AuthenticateAsync()
        {
            // Use the PasswordVault to securely store and access credentials.
            PasswordVault vault = new PasswordVault();
            PasswordCredential credential = null;

            try
            {
                // Try to get an existing credential from the vault.
                credential = vault.FindAllByResource(provider).FirstOrDefault();
            }
            catch (Exception)
            {
                // When there is no matching resource an error occurs, which we ignore.
            }


            string message;
            bool success = false;
            if (credential != null)
            {
                // Create a user from the stored credentials.
                user = new MobileServiceUser(credential.UserName);
                credential.RetrievePassword();
                user.MobileServiceAuthenticationToken = credential.Password;

                // Set the user from the stored credentials.
                App.MobileService.CurrentUser = user;

                // Consider adding a check to determine if the token is 
                // expired, as shown in this post: http://aka.ms/jww5vp.

                success = true;
                message = string.Format("Cached credentials for user - {0}", user.UserId);
            }
            else
            {
                try
                {
                    // Login with the identity provider.
                    user = await App.MobileService
                        .LoginAsync(provider);

                    // Create and store the user credentials.
                    credential = new PasswordCredential(provider,
                        user.UserId, user.MobileServiceAuthenticationToken);
                    vault.Add(credential);

                    success = true;
                }
                catch (MobileServiceInvalidOperationException)
                {
                    message = "You must log in. Login Required";
                }
            }
            
            message = string.Format("You are now logged in - {0}", user.UserId);
            var dialog = new MessageDialog(message);
            dialog.Commands.Add(new UICommand("OK"));
            await dialog.ShowAsync();

            return success;
        
    }

        public async Task watchlogin() {
            try
            {

                sampleFile =
                         sampleFile =
await storageFolder.CreateFileAsync("islogin.txt",
Windows.Storage.CreationCollisionOption.OpenIfExists);
                //indien file bestaat
                string text = await Windows.Storage.FileIO.ReadTextAsync(sampleFile);

                if (text == "")
                {
                    //EERSTE KEER 
                    App.isAuthenticated = false;
                }
                else
                {
                    string[] mijnarray = text.Split(';');
                    App.isAuthenticated = bool.Parse(mijnarray[0]);
                    App.FacebookId = mijnarray[1];
                    Gebruiker gebruiker = await repoGebruiker.GetGebruiker(App.FacebookId);
                    App.Gebruiker = gebruiker;
                    App.Fotourl = mijnarray[2];

                    GoToPageMessage message = new GoToPageMessage() { PageNumber = 11 };
                    Messenger.Default.Send<GoToPageMessage>(message);

                }
            }
            catch (Exception e)
            {
                //VINDT FILE NIET AKA maak 1 aan

            }

        }


        public RelayCommand Testing { get; set; }
        public async static Task<string> GetPictureUrl(string faceBookId)
        {
            WebResponse response = null;
            string pictureUrl = string.Empty;
            try
            {
                WebRequest request = WebRequest.Create(string.Format("https://graph.facebook.com/{0}/picture", faceBookId));
                
                response = await request.GetResponseAsync();
               
                pictureUrl = response.ResponseUri.ToString();
            }
            catch (Exception ex)
            {
                //? handle
            }
            finally
            {
               // if (response != null) //response.Close();
            }
            return pictureUrl;
        }
        private Windows.Storage.StorageFolder storageFolder =
Windows.Storage.ApplicationData.Current.LocalFolder;
        private Windows.Storage.StorageFile sampleFile = null;
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
                    App.Fotourl = await GetPictureUrl(App.FacebookId);
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
                    // temp.VulCatalog


                    await Windows.Storage.FileIO.WriteTextAsync(sampleFile, App.isAuthenticated +";"+App.FacebookId+";"+App.Fotourl);

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
