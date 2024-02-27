using System;
using System.Threading;
using System.Threading.Tasks;
using HttpClientService;
using PlayerStatisticsService.Dtos;

namespace DuelService.Services
{
    public class DuelBgService : BackgroundService
    {
        private readonly IHttpClientService _httpClientService;
        private readonly Random _random;

        public DuelBgService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService ?? throw new ArgumentNullException(nameof(httpClientService));
            _random = new Random();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                // Simulate a duel and update the Elo-values
                await SimulateDuelAsync();

                // Wait 10 seconds
                await Task.Delay(10_000, stoppingToken);
            }
        }

        public async Task SimulateDuelAsync()
        {
            // Assumtion: 2 random players
            int player1Rating = _random.Next(1000, 2000);
            int player2Rating = _random.Next(1000, 2000);

            // Calculate the winner randomly
            int winnerId = _random.Next(1, 3);

            // Update the Elo ratings
            await _httpClientService.Client.PostAsJsonAsync("Registration/UpdateElo", new { PlayerId = 1, EloRating = player1Rating });
            await _httpClientService.Client.PostAsJsonAsync("Registration/UpdateElo", new { PlayerId = 2, EloRating = player2Rating });

            // Update player statistics in PlayerStatisticsService
            await UpdatePlayerStatisticsAsync(1, winnerId);
            await UpdatePlayerStatisticsAsync(2, winnerId == 1 ? 2 : 1);
        }

        private async Task UpdatePlayerStatisticsAsync(int playerId, int winnerId)
        {
            var updateStatsDto = new UpdateStatsDto
            {
                PlayerId = playerId,
                NumberOfDuelsPlayed = 1,
                NumberOfDuelsWon = 0, 
                NumberOfDuelsLost = 0, 
                NumberOfDuelsDraw = 0, 
                AverageDuelDuration = null, 
                LastDuelPlayedAt = null
            };
            if (winnerId == playerId)
            {
                updateStatsDto = updateStatsDto with { NumberOfDuelsWon = 1 };
            }
            else
            {
                updateStatsDto = updateStatsDto with { NumberOfDuelsLost = 1 };
            }

            await _httpClientService.Client.PostAsJsonAsync("Statistics/UpdateStatistics", updateStatsDto);
        }
    }
}
