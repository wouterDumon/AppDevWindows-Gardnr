using Gardenr.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;  // offline sync
using Microsoft.WindowsAzure.MobileServices.Sync;         // offline sync
using Microsoft.WindowsAzure.MobileServices;
using Windows.UI.Popups;
using System.Collections.ObjectModel;

namespace Gardenr.Repositories
{
    class PlantRepository : IPlantRepository
    {
        private IMobileServiceSyncTable<Plant> PlantTable =
                App.MobileService.GetSyncTable<Plant>(); // offline sync
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
                await PlantTable.PullAsync("Plants", PlantTable.CreateQuery());
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


        public async Task<ObservableCollection<Plant>> GetPlanten()
        {
            if (App.DATUM == null)
            {
                App.DATUM = new DateTime();
                App.DATUM = DateTime.Now;
            }
            else {
                string vandaag = App.DATUM.Day + "/" + App.DATUM.Month + "/" + App.DATUM.Year;
                DateTime DATUM = DateTime.Now;
                string vandaag2 = DATUM.Day + "/" + DATUM.Month + "/" + DATUM.Year;

   if(vandaag.Equals(vandaag2))
                {
                    //zelfde goed
                }
                else {
                    //plant db veranderd?
                    App.PLANTEN = null;
                    App.DATUM = DateTime.Now;
                }


            }
            if (App.PLANTEN == null)
            {
                App.PLANTEN = new ObservableCollection<Plant>();
                await InitLocalStoreAsync(); // offline sync
                await RefreshPlantItems();
                ObservableCollection<Plant> a = new ObservableCollection<Plant>();
                foreach (Plant p in items)
                {
                    a.Add(p);
                    App.PLANTEN.Add(p);
                }
                return a;
            }
            else {

                return App.PLANTEN;

            }

        }
        public async Task<Plant> GetPlantById(string id)
        {
            await InitLocalStoreAsync(); // offline sync
            await RefreshPlantItems();
            Plant a = new Plant();
            foreach (Plant p in items)
            {
                if(p.ID == id)
                {
                    return p;
                }
              
            }

        

            return null;
        }

        public async void AddPlant(Plant nieuweplant)
        {
            await InitLocalStoreAsync(); // offline sync

            await PlantTable.InsertAsync(nieuweplant);

           

            await SyncAsync(); // offline sync


            await RefreshPlantItems();


        }
        private MobileServiceCollection<Plant, Plant> items;
        private async Task RefreshPlantItems()
        {
            MobileServiceInvalidOperationException exception = null;
            try
            {
                // This code refreshes the entries in the list view by querying the TodoItems table.
                // The query excludes completed TodoItems
                items = await PlantTable
                    .ToCollectionAsync();
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

      
     

     
    }
}
