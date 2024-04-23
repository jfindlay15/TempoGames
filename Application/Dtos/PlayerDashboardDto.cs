namespace Application.Dtos
{
    /// <summary>
    /// Object containing the stats data to send to the API
    /// </summary>
    public class PlayerDashboardDto
    {
        public string? PlayerName { get; set; }
        public int Level { get; set; }
        public decimal KillsDeathsRatio { get; set; }
        public int TotalKills { get; set; }
        public int TotalDeaths { get; set; }
        public decimal WinLossesRatio { get; set; }
        public int TotalWins { get; set; }
        public int TotalLosses { get; set; }
        public int HighestKillstreak { get; set; }
        public decimal HighestKillsPerGame { get; set; }
        public decimal KillsPerGameAverage { get; set; }
        public int GamesPlayed { get; set; }
        public string TimePlayed { get; set; } = "0d 0h 0m";
        public List<PlayedGamesDto> LastGamesPlayed { get; set; } = [];
    }   
}
