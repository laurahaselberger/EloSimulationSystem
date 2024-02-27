using HttpClientService;
using PlayerStatisticsService.Entities;

namespace PlayerStatisticsService.Pages; 

using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

public abstract class PlayerStatisticsBase : ComponentBase
{
    [Inject]
    protected IHttpClientService HttpClientService { get; set; }

    protected List<PlayerStatistic> PlayerStatistics { get; set; }

    protected override async Task OnInitializedAsync()
    {
        // Fetch player statistics from the service
        PlayerStatistics = await HttpClientService.Client.GetFromJsonAsync<List<PlayerStatistic>>("/Statistics");
    }
}