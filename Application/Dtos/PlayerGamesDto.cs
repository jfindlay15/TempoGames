namespace Application.Dtos
{
    /// <summary>
    /// Object containing the player's game data to send to the API
    /// </summary>
    public class PlayedGamesDto
    {
        public string? MapName { get; set; }
        public int Kills { get; set; }
        public int Headshots { get; set; }
        public decimal KDRatio { get; set; }
    }
}
