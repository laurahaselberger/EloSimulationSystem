using System.Net.Http;
using System.Threading.Tasks;
using DuelService;

namespace DuelService.Services
{
    public class StatisticsServiceClient
    {
        private readonly HttpClient _httpClient;

        public StatisticsServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task UpdatePlayerStatisticsAsync(List<DuelResult> duelResults)
        {
            // Update player statistics in the Statistics Service
            // Simple example:

            foreach (var duelResult in duelResults)
            {
                var updateData = new { PlayerId = duelResult.PlayerId, WinnerId = duelResult.WinnerId, IsDraw = duelResult.IsDraw };
                await _httpClient.PostAsJsonAsync("Statistics/UpdatePlayerStatistics", updateData);
            }
        }
    }
}