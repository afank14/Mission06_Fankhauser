using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Fankhauser.Models
{
    // Make the model
    public class MovieEntry
    {
        // Set the MovieID as the key and as required
        [Key]
        [Required]
        public int MovieId { get; set; }

        // Set the Foreign Key as CategoryId from the Category Model
        // IDK why I need the required and the ?s here, it seems contradictory
        // However, this is the only way I tried that made it work, so I kept it. 
        [ForeignKey("CategoryId")]
        [Required(ErrorMessage = "Please input a valid Category")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        // Set the Title as required and add an error message
        [Required(ErrorMessage = "Please input a title")]
        public string Title { get; set; }

        // The director can be null
        public string? Director { get; set; }

        // set the range for the year from 1888 to now. Initialize it at 0
        [Range(1888, 2024, ErrorMessage = "Please input a valid year")]
        public int Year { get; set; } = 0;

        public string? Rating { get; set; } // G, PG, PG-13, R, NR

        // The Edited field is required
        [Required]
        public bool Edited { get; set; }

        // The CopiedToPlex field is required
        [Required] 
        public bool CopiedToPlex { get; set; }

        // Set the following features as nullable with the ? after the data type
        public string? LentTo { get; set; }

        // Restrict string length to 25 characters for the Notes
        [MaxLength(25, ErrorMessage = "Notes must be under 25 characters")]
        public string? Notes { get; set; }
    }
}
