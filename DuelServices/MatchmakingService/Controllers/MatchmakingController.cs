using System.Text.Json;
using MatchmakingService.Repositories.Implementations;
using Microsoft.AspNetCore.Mvc;
using RegistrationService.Entities;

namespace MatchmakingService.Controellers;

[Route("api/[controller]")]
[ApiController]
public class MatchmakingController : ControllerBase
{
    
        private readonly MatchmakingRepository _matchmakingRepository;
        private readonly HttpClient _registrationServiceClient;
        private readonly HttpClient _statisticsServiceClient;

        public MatchmakingController(MatchmakingRepository matchmakingRepository, IHttpClientFactory httpClientFactory)
        {
            _matchmakingRepository = matchmakingRepository;

            // URL zu RegistrationService
            var registrationServiceUrl = "https://url-zu-registrations-service";
            _registrationServiceClient = httpClientFactory.CreateClient();
            _registrationServiceClient.BaseAddress = new Uri(registrationServiceUrl);

            // URL zu StatisticsService
            var statisticsServiceUrl = "https://url-zu-statistics-service";
            _statisticsServiceClient = httpClientFactory.CreateClient();
            _statisticsServiceClient.BaseAddress = new Uri(statisticsServiceUrl);
        }

        [HttpGet]
        public async Task<ActionResult<List<Player>>> GetMatchmaking()
        {
            try
            {
                var allPlayers = await _matchmakingRepository.ReadAllAsync();

                // Beispiel für den Zugriff auf RegistrationService
                var registrationServicePlayersResponse = await _registrationServiceClient.GetAsync("/api/players");

                if (!registrationServicePlayersResponse.IsSuccessStatusCode)
                {
                    // Logge den Fehler oder behandle ihn entsprechend
                    return StatusCode((int)registrationServicePlayersResponse.StatusCode, "Fehler beim Zugriff auf RegistrationService");
                }

                var registrationServicePlayersJson = await registrationServicePlayersResponse.Content.ReadAsStringAsync();
                var registrationServicePlayers = JsonSerializer.Deserialize<List<Player>>(registrationServicePlayersJson);

                // Beispiel für den Zugriff auf StatisticsService
                var playerId = 1; // Setze die tatsächliche Spieler-ID
                var lastGameTimeResponse = await _statisticsServiceClient.GetAsync($"/api/statistics/{playerId}/lastgametime");

                if (!lastGameTimeResponse.IsSuccessStatusCode)
                {
                    // Logge den Fehler oder behandle ihn entsprechend
                    return StatusCode((int)lastGameTimeResponse.StatusCode, "Fehler beim Zugriff auf StatisticsService");
                }

                var lastGameTimeJson = await lastGameTimeResponse.Content.ReadAsStringAsync();
                var lastGameTime = JsonSerializer.Deserialize<DateTime>(lastGameTimeJson);

                // Logik für die Ermittlung der bevorstehenden Duelle basierend auf den erhaltenen Daten
                var upcomingDuels = allPlayers
                    .OrderBy(player => player.EloRating)
                    .ThenByDescending(player => lastGameTime); // Beispiellogik, bitte entsprechend anpassen

                return upcomingDuels.ToList();
            }
            catch (Exception ex)
            {
                // Logge den Fehler oder behandle ihn entsprechend
                return StatusCode(500, "Interner Serverfehler");
            }
        }
}
