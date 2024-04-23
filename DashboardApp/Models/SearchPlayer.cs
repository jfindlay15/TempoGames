using System.ComponentModel.DataAnnotations;

namespace DashboardApp.Models
{
    public class SearchPlayer
    {
        [Required]
        public string? Name { get; set; }
    }
}
