namespace DuelService.Services
{
    public class RegistrationServiceClient
    {
        private readonly HttpClient _httpClient;

        public RegistrationServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task UpdateEloValuesAsync(List<DuelResult> duelResults)
        {
            // Update Elo values in the Registration Service
            // Simple example:

            foreach (var duelResult in duelResults)
            {
                var updateData = new { PlayerId = duelResult.PlayerId, EloDelta = duelResult.EloDelta };
                await _httpClient.PostAsJsonAsync("Registration/UpdateElo", updateData);
            }
        }
    }
}