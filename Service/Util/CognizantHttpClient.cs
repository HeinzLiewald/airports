using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Service.Util {
    public class CognizantHttpClient {
        private static HttpClient HttpClient = new HttpClient {
            MaxResponseContentBufferSize = 5000000 //5 megabytes
        };

        public static async Task<T> GetAsync<T>(string url, Dictionary<string, string> parameters = null) {
            url.CheckIfIsNull("URL");

            var uriBuilder = new UriBuilder(url);
            var parametersCollection = HttpUtility.ParseQueryString(uriBuilder.Query);
            if (parameters != null) {
                foreach (var parameter in parameters) {
                    parametersCollection[parameter.Key] = parameter.Value;
                }
                uriBuilder.Query = parametersCollection.ToString();
            }

            var response = await HttpClient.GetAsync(uriBuilder.ToString());
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseString);
        }
    }
}
