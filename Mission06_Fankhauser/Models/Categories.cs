using System.ComponentModel.DataAnnotations;

namespace Mission06_Fankhauser.Models
{
    // Create a class for the Categories Model
    public class Categories
    {
        // Make the CategoryId the key
        [Key]
        public int CategoryId { get; set; }

        // Add a string value for the Category Name
        public string Category {  get; set; }
    }
}
