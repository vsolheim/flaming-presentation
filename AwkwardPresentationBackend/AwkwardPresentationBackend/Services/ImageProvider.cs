using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace AwkwardPresentationBackend.Services
{
    public class ImageProvider
    {
        static HttpClient client = new HttpClient();

        public static async Task<string> RunAsync(string searchText)
        {
            var response = await client.PostAsJsonAsync("http://placeholder.no/test/test", "Yay!");
            string result = "";
            if (response.IsSuccessStatusCode)
            {
                var a = await response.Content.ReadAsStringAsync();
                dynamic b = JsonConvert.DeserializeObject(a);
                if (b != null && b.Result != null)
                    result = b.Result;
            }
            return result;
        } 
    }
}