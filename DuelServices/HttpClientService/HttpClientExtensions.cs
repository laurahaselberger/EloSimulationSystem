using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;

namespace HttpClientService 
{
    public static class HttpClientExtensions {
        public static HttpClient GetHttpClient(this IHttpClientFactory httpClientFactory) {
            return httpClientFactory.CreateClient();
        }
    }
}