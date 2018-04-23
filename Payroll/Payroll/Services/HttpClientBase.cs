using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Payroll.Helpers;
using Payroll.Model;

namespace Payroll.Services
{
    public class HttpClientBase
    {
        public async Task<T> Get<T>(string endpoint)
        {
            using (var httpClient = new HttpClient())
            {

                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.BaseAddress = new Uri(ApiBaseService.BaseUrl);
                var response = await httpClient.GetAsync(endpoint);
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(jsonString);
            }
        }

        public async Task<bool> Put<T>(string endpoint, T obj)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiBaseService.BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                StringContent content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
                // HTTP POST
                HttpResponseMessage response = await client.PutAsync(endpoint, content);
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    //    return JsonConvert.DeserializeObject<T>(data);
                    return true;
                }

                return false;
            }
        }
    }
}
