using System;
using System.Collections.Generic;
using DuelService;

namespace DuelService.Services
{
    public class DuelSimulationService {
        private readonly Random _random;
        private readonly RegistrationServiceClient _registrationServiceClient;
        private readonly StatisticsServiceClient _statisticsServiceClient;

        public DuelSimulationService(
            RegistrationServiceClient registrationServiceClient,
            StatisticsServiceClient statisticsServiceClient) {
            _random = new Random();
            _registrationServiceClient = registrationServiceClient ??
                                         throw new ArgumentNullException(nameof(registrationServiceClient));
            _statisticsServiceClient = statisticsServiceClient ??
                                       throw new ArgumentNullException(nameof(statisticsServiceClient));
        }

        public List<DuelResult> SimulateDuels() {
            // Simulate duels and generate results
            // Simple example:
            var duelResults = new List<DuelResult>();

            // Simulate 2 players
            int player1Rating = _random.Next(1000, 2000);
            int player2Rating = _random.Next(1000, 2000);

            // Assume player 1 wins
            duelResults.Add(new DuelResult { PlayerId = 1, WinnerId = 1, IsDraw = false, EloDelta = 20 });

            return duelResults;
        }
    }
}