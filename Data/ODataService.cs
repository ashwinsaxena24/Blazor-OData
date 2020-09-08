using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FlexGridOData.Data
{
    public class ODataService<T>
    {
        public string URL { get; set; }
        public string Modal { get; set; }

        public HttpClient Http { get; }

        public ODataService(string url, string model)
        {
            this.Http = new HttpClient();
            this.URL = url;
            this.Modal = model;
        }

        public async Task<List<T>> GetAsync()
        {
            var url = this.GetUrl();
            var response = await this.Http.GetStringAsync(url);
            var parsedResponse = this.ParseResponse(response);
            return parsedResponse.Value;
        }

        private string GetUrl()
        {
            UriBuilder builder = new UriBuilder(this.URL);
            builder.Path += this.Modal;
            builder.Query = "$format=json";
            return builder.Uri.ToString();
        }

        private ODataResponse<T> ParseResponse(string response)
        {
            var parsedResponse = JsonConvert.DeserializeObject<ODataResponse<T>>(response);
            return parsedResponse;
        }

        private class ODataResponse<S>
        {
            [JsonProperty("odata.metadata")]
            public string Metadata { get; set; }
            [JsonProperty("value")]
            public List<S> Value { get; set; }
        }
    }
}
