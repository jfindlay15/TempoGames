using Application.Dtos;

namespace Application.Interfaces;
public interface IPlayerService
{
    Task<PlayerDashboardDto?> GetPlayerDashboardDataAsync(string playerName);
}
