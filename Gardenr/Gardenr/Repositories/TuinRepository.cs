﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gardenr.Models;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Windows.UI.Popups;
using Microsoft.WindowsAzure.MobileServices;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Ioc;
using Newtonsoft.Json.Linq;

namespace Gardenr.Repositories
{
    class TuinRepository : ITuinRepository
    {
        private IMobileServiceSyncTable<TuinObject> Table =
               App.MobileService.GetSyncTable<TuinObject>(); // offline sync

        public IPlantRepository repoPlant = SimpleIoc.Default.GetInstance<IPlantRepository>();
        public INotificatiesRepository repoInst = SimpleIoc.Default.GetInstance<INotificatiesRepository>();


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
        public async Task<Tuin> GetTO(string nitem)
        {
            await InitLocalStoreAsync();
            await RefreshItems();
            ObservableCollection<Plant> lijstplant = await repoPlant.GetPlanten();
            ObservableCollection<Notificaties> lijstnotificaites = await repoInst.GetNotificaties();


            foreach (TuinObject ni in items)
            {
                if (ni.ID == nitem)
                {
                    Tuin newT = new Tuin();
                    newT.ID = ni.ID;
                    newT.gebruikerID = ni.gebruikerID;
                    newT.favoriet = ni.favoriet;
                    newT.Aantal = ni.Aantal;
                    newT.LaatstWater = ni.LaatstWater;
                    newT.extra = ni.extra;
                    foreach (Plant p in lijstplant) {
                        if (p.ID.Equals(ni.PlantenID)) {
                            newT.Plant = p;
                        }

                    }             
                    newT.plantDatum = ni.plantDatum;

                    if (ni.NotificationID != null && ni.NotificationID=="")//geen notificaties voorlopig nog testen met notificaties
                    {
                        var tempinstid = ni.NotificationID.Split(",".ToCharArray());
                        for (int i = 0; i < tempinstid.Length; i++)
                        {
                            //TODO: HIER ERROR 
                            //KOMT ERIN ALS STRING LEEG IS 
                            // voorlopige fix
                            foreach (Notificaties not in lijstnotificaites) {
                                if (not.ID.Equals(tempinstid[i])) {
                                    newT.Notificaties.Add(not);
                                }
                            }
                        }
                    }

                    return newT;
                }
            }
            return null;
        }

        public  TuinObject convertNaarObject (Tuin tuin)
        {
            TuinObject temp = new TuinObject();
            temp.ID = tuin.ID;
            temp.PlantenID = tuin.Plant.ID;
            temp.gebruikerID = tuin.gebruikerID;
            temp.favoriet = tuin.favoriet;
            temp.Aantal = tuin.Aantal;
            temp.LaatstWater = tuin.LaatstWater;
            temp.extra = tuin.extra;
            
            //notificaties list naar id string
            string idstring = "";
            


            if(tuin.Notificaties!= null)
            {
                foreach (Notificaties not in tuin.Notificaties)
                {
                    idstring += not.ID + ";";
                }
                temp.NotificationID = idstring;

            }
            else
            {
                temp.NotificationID = "";

            }
            

            
            temp.historiek = tuin.historiek;
            if (tuin.plantDatum == null) {
                temp.plantDatum = "";
            }
            else
            {
                temp.plantDatum = tuin.plantDatum;
            }

            return temp;
        }

        public void AdjustTO(Tuin nitem)
        {

            TuinObject temp =  convertNaarObject(nitem);

          //  await InitLocalStoreAsync();
            //await Table.UpdateAsync(JObject.Parse(temp.ToString()));
            DeleteTO(nitem);
            AddTO(temp);

           // await Table.DeleteAsync(temp);
         //   await Table.InsertAsync(temp);
            //await Table.UpdateAsync(temp);
          //  await SyncAsync();
         //   await RefreshItems();
        }
        public async void AddTO(TuinObject nitem)
        {
            await InitLocalStoreAsync();
            await Table.InsertAsync(nitem);
            await SyncAsync();
            await RefreshItems();
        }
        public async void DeleteTO(Tuin nitem)
        {
            TuinObject temp =  convertNaarObject(nitem);

            await InitLocalStoreAsync();
            await Table.DeleteAsync(temp);
            await SyncAsync();
            await RefreshItems();
        }

        public async Task<ObservableCollection<Tuin>> GetTOs(string gebruikerid)
        {
            await InitLocalStoreAsync();
            await RefreshItems();
            ObservableCollection<Tuin> ni = new ObservableCollection<Tuin>();
            ObservableCollection<Notificaties> mijnlijst = await repoInst.GetNotificaties();
            ObservableCollection<Plant> lijstplant = await repoPlant.GetPlanten();
            foreach (TuinObject nieuws in items)
            {
                if (nieuws.gebruikerID == gebruikerid)
                {
                    Tuin newT = new Tuin();
                    newT.ID = nieuws.ID;
                    newT.gebruikerID = nieuws.gebruikerID;
                    newT.favoriet = nieuws.favoriet;
                    newT.Aantal = nieuws.Aantal;
                    newT.LaatstWater = nieuws.LaatstWater;
                    newT.extra = nieuws.extra;
                   
                    foreach (Plant p in lijstplant)
                    {
                        if (p.ID.Equals(nieuws.PlantenID))
                        {
                            newT.Plant = p;
                        }

                    }


                    newT.plantDatum = nieuws.plantDatum;
                    newT.Notificaties = new ObservableCollection<Notificaties>();


                    String mijngebruiker = nieuws.gebruikerID;
                    String plant = nieuws.PlantenID;

                 

                    foreach (Notificaties mijnnot in mijnlijst) {
                        if (mijnnot.GebruikerID.Equals(mijngebruiker)) {
                            if (mijnnot.PlantID == null) { }else
                            if (mijnnot.PlantID.Equals(plant)) {
                                //zelfde gebruiker en plant
                                newT.Notificaties.Add(mijnnot);
                            }
                              }

                    }                   

                    ni.Add(newT);
                }
            }
            return ni;
        }

        public async Task AddFAV(TuinObject nitem)
        {
            await InitLocalStoreAsync();
            await Table.InsertAsync(nitem);
            await SyncAsync();
            await RefreshItems();
            return;
        }
        public async Task DeleteFAV(TuinObject nitem)
        {
            await InitLocalStoreAsync();
            await Table.DeleteAsync(nitem);
            await SyncAsync();
            await RefreshItems();
            return;
        }


        public async Task AdjustFAV(TuinObject nitem)
        {
            await DeleteFAV(nitem);
            await AddFAV(nitem);   
           
            return;
        }
    }
}
