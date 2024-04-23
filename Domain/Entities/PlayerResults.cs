using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class PlayerResults
    {
        public int Id { get; set; }
        public Player? Player { get; set; }
        public int? PlayerId { get; set; }
        public Game? Game { get; set; }
        public int? GameId { get; set; }
        public int Kills { get; set; } = 0;
        public int Deaths { get; set; } = 0;        
        public bool WonGame { get; set; }
        public int KillStreak{ get; set; }
        public int GameDuration { get; set; }
        public int Headshots { get; set; }
        public DateTime StartTime { get; set; }
    }
}
