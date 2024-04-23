using Application.Dtos;
using Application.Interfaces;
using Application.Utilities;
using Mapster;

namespace Application.Logic
{
    /// <summary>
    /// Service that does calculations for the PlayerStatsDashboardDto
    /// </summary>
    /// <param name="players"></param>
    /// <param name="results"></param>
    public class PlayerStatsService(IPlayerRepository players, IPlayerResultsRepository results) : IPlayerStatsService
    {        
        public async Task<PlayerDashboardDto> GetPlayerStats(string playerName)
        {
            PlayerDashboardDto playerDashboardDto = new();

            var player = await players.GetByPlayerName(playerName);
            if (player == null)
            {
                return null!;
            }
            var playerResults = await results.GetAsync(player.id);

            if (playerResults.Any())
            {
                playerDashboardDto = CalculateStats(playerResults);
                playerDashboardDto.KillsPerGameAverage = ((playerDashboardDto.TotalKills / playerResults.Count) * 1.0m);
                playerDashboardDto.GamesPlayed = playerResults.Count;
                playerDashboardDto.LastGamesPlayed = GetLastGamesPlayed(playerResults, 5);
            }

            playerDashboardDto.PlayerName = player.name;
            playerDashboardDto.Level = player.level;

            return playerDashboardDto;
        }

        /// <summary>
        /// Iterates through games and calculates stats such as timePlayed, highestKills, highestKillStreaks, etc...
        /// </summary>
        /// <param name="games"></param>
        /// <returns></returns>
        private PlayerDashboardDto CalculateStats(List<PlayerResultDto> games)
        {
            int kills = 0;
            int deaths = 0;
            int wins = 0;
            int losses = 0;
            int highestKills = 0;
            int highestKillStreak = 0;
            int seconds = 0;

            foreach (var game in games)
            {
                kills += game.Kills;
                deaths += game.Deaths;
                seconds += game.GameDuration;

                if (game.WonGame)
                    wins++;
                else
                    losses++;

                highestKills = Math.Max(highestKills, game.Kills);
                highestKillStreak = Math.Max(highestKillStreak, game.KillStreak);                
            }

            var totalTimePlayed = seconds.GetTimeDurationFromSeconds();
            
            //Avoid dividing by zero incase there are 0 losses return wins / 1 
            decimal killsDeathsRatio = deaths == 0 ? kills : ((decimal)kills / deaths);            
            decimal winsLossRatio = losses == 0 ? wins : ((decimal)wins / losses);

            var result = new PlayerDashboardDto
            {
                KillsDeathsRatio = killsDeathsRatio,
                WinLossesRatio = winsLossRatio,
                TotalKills = kills,
                TotalDeaths = deaths,
                TotalWins = wins,
                TotalLosses = losses,
                HighestKillsPerGame = highestKills,
                HighestKillstreak = highestKillStreak,
                TimePlayed = totalTimePlayed
            };

            return result;
        }

        /// <summary>
        /// Gets the latest games played by a player
        /// </summary>
        /// <param name="games"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        private List<PlayedGamesDto> GetLastGamesPlayed(List<PlayerResultDto> games, int amount)
        {
            var lastGames = games.OrderBy(a => a.StartTime).Take(amount);
            var result = lastGames.Adapt<List<PlayedGamesDto>>();
            return result;
        }
    }
}
