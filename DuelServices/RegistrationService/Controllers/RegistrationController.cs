using Microsoft.AspNetCore.Mvc;
using RegistrationService.Entities;
using RegistrationService.Repositories.Implementations;
using RegistrationService.Repositories.Interfaces;

namespace RegistrationService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RegistrationController : ControllerBase
{
    private readonly ManagePlayerRepository _playerRepository;

    public RegistrationController(ManagePlayerRepository playerRepository)
    {
        _playerRepository = playerRepository;
    }

    [HttpPost("Registration/{name}")]
    public ActionResult<Player> RegisterPlayer(string name)
    {
        var player = _playerRepository.RegisterPlayer(name);
        return CreatedAtAction(nameof(GetPlayer), new { id = player.Id }, player);
    }

    [HttpPut("Registration/{id}")]
    public ActionResult<Player> UpdatePlayer(int id, [FromBody] Player updatedPlayer)
    {
        var player = _playerRepository.UpdatePlayer(id, updatedPlayer.Name, updatedPlayer.EloRating);

        if (player == null)
        {
            return NotFound(); // Spieler nicht gefunden
        }

        return player;
    }

    [HttpGet("Players")]
    public ActionResult<List<Player>> GetAllPlayers()
    {
        var players = _playerRepository.GetAllPlayers();
        return players;
    }

    [HttpGet("Players/{id}")]
    public ActionResult<Player> GetPlayer(int id)
    {
        var player = _playerRepository.GetPlayer(id);

        if (player != null)
        {
            return player;
        }
        else
        {
            return NotFound();
        }
    }
}