using RegistrationService.Configurations;
using RegistrationService.Entities;

namespace RegistrationService.Repositories.Implementations;

public class ManagePlayerRepository : ARepository<Player>
{
    public ManagePlayerRepository(RegistrationServiceDbContext context) : base(context)
    {
    }

    public Player RegisterPlayer(string name)
    {
        var player = new Player()
        {
            Name = name,
            EloRating = 1500.0m // Initialer Elo-Wert
        };

        CreateAsync(player).Wait(); // Warten, um synchronen Aufruf zu ermöglichen

        return player;
    }

    public Player UpdatePlayer(int playerId, string name, decimal eloRating)
    {
        var player = ReadAsync(playerId).Result;

        if (player != null)
        {
            player.Name = name;
            player.EloRating = eloRating;

            UpdateAsync(player).Wait(); // Warten, um synchronen Aufruf zu ermöglichen

            return player;
        }

        return null; // Spieler nicht gefunden
    }

    public List<Player> GetAllPlayers()
    {
        return ReadAllAsync().Result;
    }

    public Player GetPlayer(int playerId)
    {
        return ReadAsync(playerId).Result;
    }
}