using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using MatchmakingService.Dtos;
using MatchmakingService.Repositories.Implementations;
using Microsoft.AspNetCore.Mvc;
using RegistrationService.Entities;

namespace MatchmakingService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MatchmakingController : ControllerBase
    {
        private readonly MatchmakingRepository _matchmakingRepository;
        private readonly HttpClientService.HttpClientService _httpClientService;

        public MatchmakingController(MatchmakingRepository matchmakingRepository, HttpClientService.HttpClientService httpClientService)
        {
            _matchmakingRepository = matchmakingRepository ?? throw new ArgumentNullException(nameof(matchmakingRepository));
            _httpClientService = httpClientService ?? throw new ArgumentNullException(nameof(httpClientService));
        }

        [HttpGet("Matchmaking")]
        public async Task<ActionResult<List<MatchmakingPlayerDto>>> GetMatchmaking()
        {
            try
            {
                // Retrieve all players from the matchmaking repository
                var allPlayers = await _matchmakingRepository.ReadAllAsync();

                // Initialize a list to store matchmaking player information
                var matchmakingPlayers = new List<MatchmakingPlayerDto>();

                foreach (var player in allPlayers)
                {
                    // Example: Access RegistrationService to get additional player information
                    var registrationServicePlayerResponse = await _httpClientService.Client.GetAsync($"/api/players/{player.Id}");

                    if (!registrationServicePlayerResponse.IsSuccessStatusCode)
                    {
                        return StatusCode((int)registrationServicePlayerResponse.StatusCode, "Error accessing RegistrationService");
                    }

                    var registrationServicePlayerJson = await registrationServicePlayerResponse.Content.ReadAsStringAsync();
                    var registrationServicePlayer = JsonSerializer.Deserialize<Player>(registrationServicePlayerJson);

                    // Example: Access StatisticsService to get last duel information
                    var statisticsServiceLastGameTimeResponse = await _httpClientService.Client.GetAsync($"/api/statistics/{player.Id}/lastgametime");

                    if (!statisticsServiceLastGameTimeResponse.IsSuccessStatusCode)
                    {
                        return StatusCode((int)statisticsServiceLastGameTimeResponse.StatusCode, "Error accessing StatisticsService");
                    }

                    var lastGameTimeJson = await statisticsServiceLastGameTimeResponse.Content.ReadAsStringAsync();
                    var lastGameTime = JsonSerializer.Deserialize<DateTime>(lastGameTimeJson);

                    // Create a MatchmakingPlayerDto with the retrieved information
                    var matchmakingPlayerDto = new MatchmakingPlayerDto
                    {
                        PlayerId = player.Id,
                        PlayerName = registrationServicePlayer.Name,
                        EloRating = player.EloRating,
                        LastDuelPlayedAt = lastGameTime
                    };
                    matchmakingPlayers.Add(matchmakingPlayerDto);
                }

                // Order the players
                matchmakingPlayers.Sort((p1, p2) =>
                {
                    // First, order by EloRating in descending order
                    var eloRatingComparison = p2.EloRating.CompareTo(p1.EloRating);

                    if (eloRatingComparison != 0)
                    {
                        return eloRatingComparison;
                    }

                    // If EloRatings are the same, order by LastDuelPlayedAt in ascending order
                    return p1.LastDuelPlayedAt.CompareTo(p2.LastDuelPlayedAt);
                });

                return Ok(matchmakingPlayers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
