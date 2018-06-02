using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace IMDBSearchApp.Data.Net
{
    public class IMDBApiConnection
    {
        public const string HostUrl = "http://www.omdbapi.com/?apikey=37a4ac58";

        static HttpClient BuildClient()
        {
            var client = new HttpClient();
            client.MaxResponseContentBufferSize = 25600;
            return client;
        }

        public static async Task<string> DoGet(string endpoint)
        {
            var uri = new Uri(endpoint);
            var client = BuildClient();
            var response = await client.GetAsync(uri);
            if(response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return content;
            }
            return "";
        }
    }
}
