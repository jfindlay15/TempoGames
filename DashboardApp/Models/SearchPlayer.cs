using System.ComponentModel.DataAnnotations;

namespace DashboardApp.Models
{
    /// <summary>
    /// Model to work with the Form Validation
    /// </summary>
    public class SearchPlayer
    {
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
