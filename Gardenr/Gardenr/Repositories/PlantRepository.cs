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

namespace Gardenr.Repositories
{
    class PlantRepository : IPlantRepository
    {
        private IMobileServiceSyncTable<TodoItem> todoTable =
                App.MobileService.GetSyncTable<TodoItem>(); // offline sync
        private async Task InitLocalStoreAsync()
        {
            if (!App.MobileService.SyncContext.IsInitialized)
            {
                var store = new MobileServiceSQLiteStore("localstore.db");
                store.DefineTable<TodoItem>();
                await App.MobileService.SyncContext.InitializeAsync(store);
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
                await todoTable.PullAsync("todoItems", todoTable.CreateQuery());
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


        public async Task<List<Plant>> GetPlanten()
        {
            /* List<Plant> planten = new List<Plant>();
             using (HttpClient client = new HttpClient())
             {
                 var result =  client.GetAsync("http://wingardnr.azurewebsites.net//Plant");
                // var result = client.GetAsync("http://datatank4.gent.be//mobiliteit/bezettingparkingsrealtime.json");
                 string json = await result.Result.Content.ReadAsStringAsync();
                json = json.Replace("&quot;", "'");
                 Plant[] data = JsonConvert.DeserializeObject<Plant[]>(json);    
                 foreach(var plantje in data)
                 {
                     planten.Add(plantje);
                 }        
             }






             return planten*/
            return null;
        }
        public async Task<Plant> GetPlantById(int id)
        {

            /* Plant temp = new Plant();
             using (HttpClient client = new HttpClient())
             {

                 string link = "http://wingardnr.azurewebsites.net//Plant?id="+id;
                 var result = client.GetAsync(link);

                 string json = await result.Result.Content.ReadAsStringAsync();
                 json = json.Replace("&quot;", "'");
                 temp = JsonConvert.DeserializeObject<Plant>(json);

             }
             return temp;*/
            return null;
        }

        public async void AddPlant()
        {
            /*  Plant probeer = new Plant();
             // probeer.ID = 10;
              probeer.Naam = "Patat";
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

             string url = "http://wingardnr.azurewebsites.net/Plant/Edit";
             // string url = "http://localhost:64597/Plant/Edit";



              string serializer = JsonConvert.SerializeObject(probeer);

              using (HttpClient client = new HttpClient())
              {
                  HttpResponseMessage response = await client.PutAsync(url, new StringContent(serializer, Encoding.UTF8, "application/json"));
                  if(response.IsSuccessStatusCode)
                  {
                      string jsonresponse = await response.Content.ReadAsStringAsync();
                      int result = JsonConvert.DeserializeObject<int>(jsonresponse);
                  }

              }*/

          //  TodoItem item = new TodoItem { Text = "Awesome item", Complete = false };
            //await App.MobileService.GetTable<TodoItem>().InsertAsync(item);

            Plant probeer = new Plant();
            // probeer.ID = 10;
            probeer.Naam = "StringID";
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
         //  await App.MobileService.GetTable<Plant>().InsertAsync(probeer);
           // List<Plant> A = await App.MobileService.GetTable<Plant>().ToListAsync();

            await InitLocalStoreAsync(); // offline sync
            await SyncAsync(); // offline sync
            await RefreshTodoItems();


        }
        private MobileServiceCollection<TodoItem, TodoItem> items;
        private async Task RefreshTodoItems()
        {
            MobileServiceInvalidOperationException exception = null;
            try
            {
                // This code refreshes the entries in the list view by querying the TodoItems table.
                // The query excludes completed TodoItems
                items = await todoTable
                    .Where(todoItem => todoItem.Complete == false)
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

        private async Task InsertTodoItem(TodoItem todoItem)
        {
            await todoTable.InsertAsync(todoItem);
            items.Add(todoItem);

            await SyncAsync(); // offline sync
        }
        private async Task UpdateCheckedTodoItem(TodoItem item)
        {
            await todoTable.UpdateAsync(item);
            items.Remove(item);
          //  ListItems.Focus(Windows.UI.Xaml.FocusState.Unfocused);

            await SyncAsync(); // offline sync
        }

        private async void add() {
          

        }
    }
}
