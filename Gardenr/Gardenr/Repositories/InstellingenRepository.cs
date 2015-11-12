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
    class InstellingenRepository : IInstellingenRepository
    {
        private IMobileServiceSyncTable<Instellingen> Table =
               App.MobileService.GetSyncTable<Instellingen>(); // offline sync
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
                await Table.PullAsync("Instellingens", Table.CreateQuery());
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
        private MobileServiceCollection<Instellingen, Instellingen> items;
        private async Task RefreshItems()
        {
            MobileServiceInvalidOperationException exception = null;
            try
            {
                // This code refreshes the entries in the list view by querying the TodoItems table.
                // The query excludes completed TodoItems
                items = await Table.ToCollectionAsync();
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

        public async Task<ObservableCollection<Instellingen>> GetInsts()
        {
            await InitLocalStoreAsync();
            await RefreshItems();
            ObservableCollection<Instellingen> ni = new ObservableCollection<Instellingen>();

            foreach (Instellingen nieuws in items)
            {
                ni.Add(nieuws);
            }
            return ni;
        }
        public async Task<Instellingen> GetInst(string nitem)
        {
            await InitLocalStoreAsync();
            await SyncAsync();
            await RefreshItems();
            foreach (Instellingen ni in items)
            {
                if (ni.ID == nitem)
                {
                    return ni;
                }
            }
            return null;
        }

        public async void AdjustInst(Instellingen nitem)
        {
            await InitLocalStoreAsync();
            await Table.UpdateAsync(nitem);
            await SyncAsync();
            await RefreshItems();
        }
        public async void AddInst(Instellingen nitem)
        {
            await InitLocalStoreAsync();
            await Table.InsertAsync(nitem);
            await SyncAsync();
            await RefreshItems();
        }
        public async void DeleteInst(Instellingen nitem)
        {
            await InitLocalStoreAsync();
            await Table.DeleteAsync(nitem);
            await SyncAsync();
            await RefreshItems();
        }
    }
}
