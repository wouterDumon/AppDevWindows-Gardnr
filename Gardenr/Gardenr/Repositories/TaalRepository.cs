﻿using Gardenr.Models;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
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
    class TaalRepository : ITaalRepository
    {
        private IMobileServiceSyncTable<Taal> TaalTable =
               App.MobileService.GetSyncTable<Taal>();

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
                await TaalTable.PullAsync("Taals", TaalTable.CreateQuery());
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
        public async Task<ObservableCollection<Taal>> GetTalen()
        {
            ObservableCollection<Taal> tal = new ObservableCollection<Taal>();
            await InitLocalStoreAsync();
            await RefreshTaalItems();
            foreach(Taal t in items)
            {
                tal.Add(t);
            }
            return tal;
        }
        private MobileServiceCollection<Taal, Taal> items;
        private async Task RefreshTaalItems()
        {
            MobileServiceInvalidOperationException exception = null;
            try
            {
                // This code refreshes the entries in the list view by querying the TodoItems table.
                // The query excludes completed TodoItems
                items = await TaalTable.ToCollectionAsync();
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
    
        public async Task<Taal> GetTaalById(string id)
        {
            await InitLocalStoreAsync();
            await RefreshTaalItems();
            foreach (Taal ni in items)
            {
                if (ni.ID == id)
                {
                    return ni;
                }
            }
            return null;
        }

        //only available for admins
        public async void AddTaal()
        {
            await InitLocalStoreAsync();

            Taal test = new Taal();
            test.Naam = "Engels";

            await TaalTable.InsertAsync(test);

            Taal test2 = new Taal();
            test2.Naam = "Nederlands";
            await TaalTable.InsertAsync(test2);

            Taal test3 = new Taal();
            test3.Naam = "Frans";
            await TaalTable.InsertAsync(test3);
            await SyncAsync();
            await RefreshTaalItems();
        }

    }
}
