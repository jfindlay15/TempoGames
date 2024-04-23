namespace Domain.Entities
{
    public class Game
    {
        public int Id { get; set; }        
        public Map? Map { get; set; }
        public int? MapId { get; set; }
        public IList<PlayerResults> PlayerResults { get; set; } = [];
    }        
}
