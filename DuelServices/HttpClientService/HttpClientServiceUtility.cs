
namespace HttpClientService
{
    public static class HttpClientServiceUtility
    {
        public static HttpClient GetHttpClient(IHttpClientFactory httpClientFactory)
        {
            return httpClientFactory.CreateClient();
        }
    }
}