using Gardenr.Models;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace Gardenr.Repositories
{
    class GebruikerRepository : IGebruikerRepository
    {
        private IMobileServiceSyncTable<Gebruiker> GebruikerTable =
                App.MobileService.GetSyncTable<Gebruiker>(); // offline sync
        private async Task InitLocalStoreAsync()
        {
            if (!App.MobileService.SyncContext.IsInitialized)
            {

                await App.MobileService.SyncContext.InitializeAsync(App.store);
            }



            await SyncAsync();
        }

        private async Task SyncAsync()
        {
            String errorString = null;

            try
            {
                await App.MobileService.SyncContext.PushAsync();
                // first param is query ID, used for incremental sync
                await GebruikerTable.PullAsync("Gebruikers", GebruikerTable.CreateQuery());
            }

            catch (MobileServicePushFailedException ex)
            {
                errorString = "Push failed because of sync errors. " +
                              "You may be offine.\nMessage: " +
                              ex.Message + "\nPushResult.Status: " +
                              ex.PushResult.Status.ToString();
            }
            catch (Exception ex)
            {
                errorString = "Pull failed: " + ex.Message +
                  "\n\nIf you are still in an offline scenario, " +
                  "you can try your Pull again when connected with " +
                  "your Mobile Service.";
            }

            if (errorString != null)
            {
                MessageDialog d = new MessageDialog(errorString);
                await d.ShowAsync();
            }
        }
        private MobileServiceCollection<Gebruiker, Gebruiker> items;
        private async Task RefreshItems()
        {
            MobileServiceInvalidOperationException exception = null;
            try
            {
                // This code refreshes the entries in the list view by querying the TodoItems table.
                // The query excludes completed TodoItems
                items = await GebruikerTable.ToCollectionAsync();
            }
            catch (MobileServiceInvalidOperationException e)
            {
                exception = e;
            }

            if (exception != null)
            {
                await new MessageDialog(exception.Message, "Error loading items").ShowAsync();
            }
            else
            {
                //    ListItems.ItemsSource = items;
                //  this.ButtonSave.IsEnabled = true;
            }
        }
        public async Task<ObservableCollection<Gebruiker>> GetGebruiker()
        {
            await InitLocalStoreAsync();
            await RefreshItems();
            ObservableCollection<Gebruiker> geb = new ObservableCollection<Gebruiker>();

            foreach(Gebruiker g in items)
            {
                geb.Add(g);
            }
            return geb;
        }
        public async Task<Gebruiker> GetGebruiker(string login)
        {
            await InitLocalStoreAsync();
            await RefreshItems();
           
            foreach(Gebruiker g in items)
            {
                if(g.Facebook == login)
                {
                    
                    return g;
                }
            }
            return null;
        }
        public async void AdjustGebruiker(Gebruiker data)
        {
            await InitLocalStoreAsync();
            await GebruikerTable.UpdateAsync(data);
            await SyncAsync();
            await RefreshItems();

        }
        public async void AddGebruiker(Gebruiker data)
        {
            await InitLocalStoreAsync();
            await GebruikerTable.InsertAsync(data);           
            await SyncAsync();
            await RefreshItems();
        }
    }
}
