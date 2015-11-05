using Gardenr.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

       
    }
}
