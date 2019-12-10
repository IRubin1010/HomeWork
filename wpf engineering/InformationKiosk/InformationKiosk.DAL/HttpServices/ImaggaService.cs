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
    public class ImaggaService
    {
        public async Task<bool> IsImageContainsItem(string imageUrl, string item)
        {
            string apiKey = "acc_800d837796a799b";
            string apiSecret = "c0951db577672beb1d8493df67c282d2";
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
                                 where (double)t["confidence"] > 40
                                 select (string)t["tag"]["en"]).ToList();
                }
            }
            return labelList.Contains(item);
        }
    }
}
