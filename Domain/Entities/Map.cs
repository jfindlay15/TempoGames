using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Map
    {        
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}
