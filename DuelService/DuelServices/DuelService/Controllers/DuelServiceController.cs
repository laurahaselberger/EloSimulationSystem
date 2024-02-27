using DuelService.Services;
using Microsoft.AspNetCore.Mvc;

namespace DuelService.Controllers
{
    public class DuelServiceController : ControllerBase
    {
        private readonly DuelBgService _duelBgService;

        public DuelServiceController(DuelBgService duelBgService)
        {
            _duelBgService = duelBgService ?? throw new ArgumentNullException(nameof(duelBgService));
        }

        public async Task SimulateDuels()
        {
            try
            {
                // Simulate duels using the background service
                await _duelBgService.SimulateDuelAsync();
                Console.WriteLine("Duels simulated and player statistics updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
            }
        }
    }
}