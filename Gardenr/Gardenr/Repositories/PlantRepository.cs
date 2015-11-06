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


namespace Gardenr.Repositories
{
    class PlantRepository : IPlantRepository
    {
        public async Task<List<Plant>> GetPlanten()
        {
            List<Plant> planten = new List<Plant>();
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
          
           
            



            return planten;
        }
        public async Task<Plant> GetPlantById(int id)
        {
            Plant temp = new Plant();
            using (HttpClient client = new HttpClient())
            {

                string link = "http://wingardnr.azurewebsites.net//Plant?id="+id;
                var result = client.GetAsync(link);
                
                string json = await result.Result.Content.ReadAsStringAsync();
                json = json.Replace("&quot;", "'");
                temp = JsonConvert.DeserializeObject<Plant>(json);
               
            }
            return temp;
        }

        public async void AddPlant()
        {
            Plant probeer = new Plant();
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

            }

           
        }
       
    }
}
