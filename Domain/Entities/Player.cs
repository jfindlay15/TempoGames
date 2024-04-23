using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Player
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required int Level { get; set; } = 1;
        //public required Rank Rank { get; set; }
        //public IList<Game>? Games { get; set; }
    }
}