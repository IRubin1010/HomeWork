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
    class ImaggaService
    {
        public async Task<bool> IsImageContainsItem(string imageUrl, string item)
        {
            string apiKey = "acc_c4ce731bb14dcf7";
            string apiSecret = "8d833fd35787d0450fc558d13451d0f2";
            List<string> labelList = new List<string>();
            string basicAuthValue = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(String.Format("{0}:{1}", apiKey, apiSecret)));

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.imagga.com/v2/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(@"application/json"));
                client.DefaultRequestHeaders.Add("Authorization", String.Format("Basic {0}", basicAuthValue));

                using (HttpResponseMessage response = await client.GetAsync(String.Format("tags?image_url={0}", imageUrl)))
                {
                    HttpContent content = response.Content;
                    string result = await content.ReadAsStringAsync();
                    JObject jobject = JObject.Parse(result);

                    labelList = (from t in jobject["result"]["tags"]
                                 where (double)t["confidence"] > 70
                                 select (string)t["tag"]["en"]).ToList();
                }
            }
            return labelList.Contains(item);
        }
    }
}
