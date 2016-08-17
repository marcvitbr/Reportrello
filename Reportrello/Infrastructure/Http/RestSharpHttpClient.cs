namespace Reportrello.Infrastructure.Http
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using RestSharp;

    public class RestSharpHttpClient : IHttpClient
    {
        private static readonly JsonSerializerSettings
                                    DefaultSerializationSettings =
                                        new JsonSerializerSettings {
                                            ContractResolver = new CamelCasePropertyNamesContractResolver(),
                                            NullValueHandling = NullValueHandling.Ignore
                                        };

        private readonly RestClient client;

        public RestSharpHttpClient(string baseUrl)
        {
            this.client = new RestClient(baseUrl);
        }

        public async Task<TResponseData> GetAsync<TResponseData>(string resource, IEnumerable<KeyValuePair<string, string>> segments)
        {
            var request = new RestRequest(resource, Method.GET);

            foreach(var segment in segments)
            {
                request.AddUrlSegment(segment.Key, segment.Value);
            }

            var response = await this.client.ExecuteTaskAsync<TResponseData>(request);

            var data = JsonConvert.DeserializeObject<TResponseData>(response.Content);

            return data;
        }
    }
}