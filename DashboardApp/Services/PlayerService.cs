using Application.Dtos;

namespace DashboardApp.Services
{
    public interface IPlayerService
    {
        Task<PlayerDashboardDto> GetPlayerDashboardDataAsync(string playerName);
    }

    public class PlayerService(HttpClient httpClient) : IPlayerService
    {
        public async Task<PlayerDashboardDto> GetPlayerDashboardDataAsync(string playerName)
        {
            try
            {
                var data = await httpClient.GetFromJsonAsync<PlayerDashboardDto>($"api/PlayerResults/{playerName}");
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            
        }
    }
}
