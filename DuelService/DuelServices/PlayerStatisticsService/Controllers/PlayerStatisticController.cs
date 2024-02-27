using Microsoft.AspNetCore.Mvc;
using PlayerStatisticsService.Dtos;
using PlayerStatisticsService.Entities;
using PlayerStatisticsService.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayerStatisticsService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerStatisticController : ControllerBase
    {
        private readonly IPlayerStatisticRepository _playerStatisticRepository;

        public PlayerStatisticController(IPlayerStatisticRepository playerStatisticRepository)
        {
            _playerStatisticRepository = playerStatisticRepository ?? throw new ArgumentNullException(nameof(playerStatisticRepository));
        }

        // Endpoint to retrieve statistics for all players
        [HttpGet("Statistics")]
        public async Task<ActionResult<List<PlayerStatistic>>> GetStatistics()
        {
            // Retrieve all player statistics from the repository
            var playerStatistics = await _playerStatisticRepository.ReadAllAsync();

            // Return the list of player statistics
            return Ok(playerStatistics);
        }

        // Endpoint to update statistics based on the outcome of a duel
        [HttpPost("Statistics")]
        public async Task<ActionResult> UpdateStatistics([FromBody] UpdateStatsDto updateStatsDto)
        {
            // Retrieve the player statistics for the specified player
            var playerStatistic = await _playerStatisticRepository.ReadAsync(updateStatsDto.PlayerId);

            if (playerStatistic == null)
            {
                return NotFound();
            }

            // Update player statistics based on the outcome of the duel
            playerStatistic.NumberOfDuelsWon = updateStatsDto.NumberOfDuelsWon;
            playerStatistic.NumberOfDuelsLost = updateStatsDto.NumberOfDuelsLost;
            playerStatistic.NumberOfDuelsDraw = updateStatsDto.NumberOfDuelsDraw;
            playerStatistic.NumberOfDuelsPlayed = updateStatsDto.NumberOfDuelsPlayed;
            playerStatistic.AverageDuelDuration = updateStatsDto.AverageDuelDuration;
            playerStatistic.LastDuelPlayedAt = updateStatsDto.LastDuelPlayedAt;

            // Save the updated player statistics
            await _playerStatisticRepository.UpdateAsync(playerStatistic);

            // Return a success response
            return Ok();
        }
    }
}
