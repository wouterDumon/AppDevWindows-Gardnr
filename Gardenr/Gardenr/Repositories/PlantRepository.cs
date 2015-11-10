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
            await InitLocalStoreAsync(); // offline sync
            await RefreshPlantItems();
            ObservableCollection<Plant> a = new ObservableCollection<Plant>();
            foreach (Plant p in items) {
                a.Add(p);
            }

            return  a;

        }
        public async Task<Plant> GetPlantById(int id)
        {


            return null;
        }

        public async void AddPlant()
        {
            await InitLocalStoreAsync(); // offline sync

            Plant probeer = new Plant();
            // probeer.ID = 10;
            probeer.Naam = "andere";
            probeer.Omschrijving = "een knol die onder de grond groeid";
            probeer.FotoUrl = "http://www.aardappel.be/wp-content/themes/manyfacesofpotatoes/images/Avatar_VLAM_v.01_c.jpg";
            probeer.ZaaiBegin = "01/01/2010";
            probeer.ZaaiEinde = "01/01/2010";
            probeer.OogstBegin = "01/01/2010";
            probeer.OogstEinde = "01/01/2010";
            probeer.PlantBegin = "01/01/2010";
            probeer.PlantEinde = "01/01/2010";
            probeer.ZaaiDiepte = "10";
            probeer.AfstandTussen = "30";
            probeer.AfstandRij = "30";
            probeer.WaterGeven = "3";
            probeer.DagenOogst = "20";
            probeer.DagenVerplanten = "0";
            probeer.Binnen = 0;
            probeer.Buiten = 1;
            await PlantTable.InsertAsync(probeer);

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
