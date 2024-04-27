namespace Application.Dtos
{
    /// <summary>
    /// Dto contains stats of player information
    /// </summary>    
    public class PlayerResultDto()
    {
        public int PlayerId { get; set; }
        public int Headshots { get; set; }
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public bool WonGame { get; set; }
        public int KillStreak { get; set; }
        public int GameDuration { get; set; }
        public DateTime StartTime { get; set; }
        public string? MapName { get; set; }
    }

}