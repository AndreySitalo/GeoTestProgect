using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GeoProgect
{
   public class ApiContext
    {
        private string _uri;

        public ApiContext(string uri) 
        {
            _uri = uri;
        }

        public async Task<string> GetAsyncData(string uriParams)
        {
            using HttpClient httpClient = new HttpClient { BaseAddress = new Uri(_uri) };
            httpClient.DefaultRequestHeaders.Add("User-Agent", "C# App");
            HttpResponseMessage httpResult = await httpClient.GetAsync(uriParams);
            return await httpResult.Content.ReadAsStringAsync();
        }
    }
}
