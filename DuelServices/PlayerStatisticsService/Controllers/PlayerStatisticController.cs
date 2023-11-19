using Microsoft.AspNetCore.Mvc;
using PlayerStatisticsService.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlayerStatisticsService;
using PlayerStatisticsService.Dtos;

namespace PlayerStatisticService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerStatisticController : ControllerBase
    {
        private readonly IPlayerStatisticRepository _playerStatisticRepository;

        public PlayerStatisticController(IPlayerStatisticRepository playerStatisticRepository)
        {
            _playerStatisticRepository = playerStatisticRepository;
        }

        [HttpGet("Statistics")]
        public async Task<ActionResult<IEnumerable<PlayerStatisticsDto>>> GetPlayerStatistics()
        {
            try
            {
                var playerStatistics = await _playerStatisticRepository.ReadAllAsync();
                var playerStatisticsDtos = playerStatistics
                    .Select(stat => new PlayerStatisticsDto
                    {
                        PlayerId = stat.PlayerId,
                        PlayerName = stat.PlayerName,
                        CurrentEloRating = stat.CurrentEloRating,
                        NumberOfDuelsWon = stat.NumberOfDuelsWon,
                        NumberOfDuelsLost = stat.NumberOfDuelsLost,
                        NumberOfDuelsDraw = stat.NumberOfDuelsDraw,
                        NumberOfDuelsPlayed = stat.NumberOfDuelsPlayed,
                        AverageDuelDuration = stat.AverageDuelDuration,
                        LastDuelPlayedAt = stat.LastDuelPlayedAt
                    })
                    .ToList();

                return Ok(playerStatisticsDtos);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return BadRequest(new { Message = "Failed to retrieve player statistics", Error = ex.Message });
            }
        }

        [HttpPost("Statistics")]
        public async Task<ActionResult> UpdatePlayerStatistics([FromBody] UpdateStatsDto updateStatsDto)
        {
            try
            {
                await _playerStatisticRepository.UpdatePlayerStatisticsAsync(updateStatsDto);
                return Ok(new { Message = "Player statistics updated successfully" });
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return BadRequest(new { Message = "Failed to update player statistics", Error = ex.Message });
            }
        }
    }
}
