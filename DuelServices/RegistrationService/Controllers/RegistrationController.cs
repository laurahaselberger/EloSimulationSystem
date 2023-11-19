using Microsoft.AspNetCore.Mvc;
using RegistrationService.Dtos;
using RegistrationService.Entities;
using RegistrationService.Repositories.Implementations;

namespace RegistrationService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly ManagePlayerRepository _playerRepository;

        public RegistrationController(ManagePlayerRepository playerRepository)
        {
            _playerRepository = playerRepository?? throw new ArgumentNullException(nameof(playerRepository));
        }

        // Endpoint to create a new player
        [HttpPost("Registration")]
        public ActionResult<Player> RegisterPlayer([FromBody] PlayerDto playerDto)
        {
            // Register a new player with the provided name
            var player = _playerRepository.RegisterPlayer(playerDto.Name);

            // Return a 201 Created response with the newly created player
            return CreatedAtAction(nameof(RegisterPlayer), new { id = player.Id }, player);
        }

        // Endpoint to update an existing player
        [HttpPut("Registration/{id}")]
        public ActionResult<Player> UpdatePlayer(int id, [FromBody] UpdatePlayerDto updatePlayerDto)
        {
            // Update an existing player with the provided ID, name, and Elo rating
            var player = _playerRepository.UpdatePlayer(id, updatePlayerDto.Name, updatePlayerDto.EloRating);
            
            if (player == null)
            {
                return NotFound(); // Player not found
            }

            return player;
        }

        // Endpoint to retrieve a list of all registered players
        [HttpGet("Players")]
        public ActionResult<List<PlayerListDto>> GetAllPlayers()
        {
            // Get all registered players from the repository
            var players = _playerRepository.GetAllPlayers();

            // Map players to PlayerListDto for response
            var playersDto = players.Select(p => new PlayerListDto { Id = p.Id, Name = p.Name, EloRating = p.EloRating }).ToList();

            return playersDto;
        }
    }
}
