using System.ComponentModel.DataAnnotations;

namespace Mission06_Fankhauser.Models
{
    // Make the model
    public class MovieEntry
    {
        // Set the MovieID as the key and as required
        [Key]
        [Required]
        public int MovieID { get; set; }

        // Set the required features as required
        [Required]
        public string Category { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string Rating { get; set; } // G, PG, PG-13, R

        // Set the following three features as nullable with the ? after the data type
        public bool? Edited { get; set; }
        public string? LentTo { get; set; }

        // Restrict string length to 25 characters for the Notes
        [StringLength(25, ErrorMessage = "Notes must be under 25 characters")]
        public string? Notes { get; set; }
    }
}
