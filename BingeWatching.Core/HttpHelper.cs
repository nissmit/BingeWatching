using BingeWatching.API;
using BingeWatching.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BingeWatching.Core
{
    public class HttpHelper : IHttpHelper
    {
        private readonly string _url;
        HttpClient httpClient;
        public HttpHelper(string url)
        {
            httpClient = HttpClientFactory.Create();
            if (string.IsNullOrEmpty(url)) throw new ArgumentNullException(nameof(url));
            _url = url;
        }
        public async Task<IContent> StreamWithSystemTextJson(IQueryParams queryParams)
        {
            var url = $"{_url}?{queryParams.ToUri()}";


            var httpResponse = httpClient.GetAsync(url, HttpCompletionOption.ResponseHeadersRead).Result;

            httpResponse.EnsureSuccessStatusCode(); // throws if not 200-299

            if (httpResponse.Content is object && httpResponse.Content.Headers.ContentType.MediaType == "application/json")
            {
                var contentStream = await httpResponse.Content.ReadAsStreamAsync();
                return await System.Text.Json.JsonSerializer.DeserializeAsync<Content>(contentStream, new System.Text.Json.JsonSerializerOptions { IgnoreNullValues = true, PropertyNameCaseInsensitive = true });

            }
            return default(Content);

        }

     
    }
}
