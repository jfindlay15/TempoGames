using Application.Dtos;
using Application.Interfaces;

namespace DashboardApp.Services
{
    public class PlayerService(ILogger<PlayerService> logger, HttpClient httpClient) : IPlayerService
    {
        public async Task<PlayerDashboardDto?> GetPlayerDashboardDataAsync(string playerName)
        {
            PlayerDashboardDto? data = null;
            try
            {
                data = await httpClient.GetFromJsonAsync<PlayerDashboardDto>($"api/PlayerResults/{playerName}");
                return data;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
            }

            return null;
        }
    }
}
