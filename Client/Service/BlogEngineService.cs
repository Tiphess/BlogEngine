using Client.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client.Api
{
    public class BlogEngineService
    {
        private readonly HttpClient _client;

        public BlogEngineService(HttpClient client)
        {
            _client = client;
        }

        public T Request<T>(HttpMethod method, string uri)
        {
            var request = new HttpRequestMessage
            {
                Method = method,
                RequestUri = new Uri(_client.BaseAddress + uri)
            };

            var response = _client.SendAsync(request).Result;

            return EvaluateContent<T>(response);
        }

        private T EvaluateContent<T>(HttpResponseMessage response)
        {
            var content = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode  == false)
            {
                throw new ApiException
                {
                    StatusCode = response.StatusCode,
                    Content = content
                };
            }

            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}
