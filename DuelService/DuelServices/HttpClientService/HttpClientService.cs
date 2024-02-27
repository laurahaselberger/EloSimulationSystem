namespace HttpClientService; 

// Singleton: because only 1 HttpClient instance is used
public class HttpClientService : IHttpClientService
{
    public HttpClient Client { get; }

    public HttpClientService(IHttpClientFactory httpClientFactory)
    {
        Client = httpClientFactory.CreateClient();
        // Set the BaseAddress here
        Client.BaseAddress = new Uri("http://localhost:14984/");
        // HttpClient configuration possible
    }
}