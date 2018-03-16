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

        public static async Task<object> RunAsync(object payload = null, string url = "http://placeholder.no/test/test")
        {
            if (payload == null)
                payload = "Yay!";
            
            var response = await client.PostAsJsonAsync(url, payload);
            string result = "";
            if (response.IsSuccessStatusCode)
            {
                var a = await response.Content.ReadAsStringAsync();
                dynamic b = JsonConvert.DeserializeObject(a);
                if (b is bool)
                    return b;
                if (b != null && b.Result != null)
                    result = b.Result;
            }
            return result;
        } 
    }
}