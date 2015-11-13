using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gardenr.Models;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Windows.UI.Popups;
using Microsoft.WindowsAzure.MobileServices;
using System.Collections.ObjectModel;

namespace Gardenr.Repositories
{
    class TuinRepository : ITuinRepository
    {
        private IMobileServiceSyncTable<TuinObject> Table =
               App.MobileService.GetSyncTable<TuinObject>(); // offline sync
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
                await Table.PullAsync("TuinObjects", Table.CreateQuery());
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
        private MobileServiceCollection<TuinObject, TuinObject> items;
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

       /* public async Task<ObservableCollection<TuinObject>> GetTOs()
        {
            await InitLocalStoreAsync();
            await RefreshItems();
            ObservableCollection<TuinObject> ni = new ObservableCollection<TuinObject>();

            foreach (TuinObject nieuws in items)
            {
                ni.Add(nieuws);
            }
            return ni;
        }*/
        public async Task<TuinObject> GetTO(string nitem)
        {
            await InitLocalStoreAsync();
            await RefreshItems();
            foreach (TuinObject ni in items)
            {
                if (ni.ID == nitem)
                {
                    return ni;
                }
            }
            return null;
        }

        public async void AdjustTO(TuinObject nitem)
        {
            await InitLocalStoreAsync();
            await Table.UpdateAsync(nitem);
            await SyncAsync();
            await RefreshItems();
        }
        public async void AddTO(TuinObject nitem)
        {
            await InitLocalStoreAsync();
            await Table.InsertAsync(nitem);
            await SyncAsync();
            await RefreshItems();
        }
        public async void DeleteTO(TuinObject nitem)
        {
            await InitLocalStoreAsync();
            await Table.DeleteAsync(nitem);
            await SyncAsync();
            await RefreshItems();
        }

        public async Task<ObservableCollection<TuinObject>> GetTOs(string gebruikerid)
        {
            await InitLocalStoreAsync();
            await RefreshItems();
            ObservableCollection<TuinObject> ni = new ObservableCollection<TuinObject>();

            foreach (TuinObject nieuws in items)
            {
                if (nieuws.gebruikerID == gebruikerid)
                {
                    ni.Add(nieuws);
                }
            }
            return ni;
        }
    }
}
