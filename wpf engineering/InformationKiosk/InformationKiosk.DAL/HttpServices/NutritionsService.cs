using InformationKiosk.BE;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace InformationKiosk.DAL.HttpServices
{
    public class NutritionsService
    {
        private static readonly String API_KEY = "Zde2nKnxVYuaFO6UnEbX601aSRoZCaZdcAPtW3SN";
        private List<string> nutrientIds = new List<string>(){"208", "203", "204"};

        public async Task<Nutrients> GetNutritionsInformationAsync(int productID)
        {
            string url = "https://api.nal.usda.gov/ndb/V2/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(@"application/json"));

                HttpResponseMessage response = await client.GetAsync(string.Format("reports?ndbno={0}&type=f&format=json&api_key={1}", productID, API_KEY));
                HttpContent content = response.Content;
                string result = await content.ReadAsStringAsync();

                JObject jobject = JObject.Parse(result);
                var NutritionsList = jobject["foods"][0]["food"]["nutrients"].
                    Where(n => nutrientIds.Contains((string)n["nutrient_id"])).ToList();

                var Nutritions = new Nutrients()
                {
                    Energy = (float)NutritionsList.First(n => (int)n["nutrient_id"] == 208)["value"],
                    Fats = (float)NutritionsList.First(n => (int)n["nutrient_id"] == 204)["value"],
                    Protein = (float)NutritionsList.First(n => (int)n["nutrient_id"] == 203)["value"]

                };
                return Nutritions;
            }
            
        }
    }
}
