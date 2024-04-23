using Application.Dtos;

namespace Application.Interfaces
{
    /// <summary>
    /// Player Stats Service
    /// </summary>
    public interface IPlayerStatsService
    {
        /// <summary>
        /// Calculates Player Stats
        /// </summary>
        /// <param name="playerName"></param>
        /// <returns></returns>
        Task<PlayerDashboardDto> GetPlayerStats(string playerName);
    }
}
