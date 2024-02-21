using System.ComponentModel.DataAnnotations;

namespace Mission06_Fankhauser.Models
{
    // Create a class for the Categories Model
    public class Category
    {
        // Make the CategoryId the key
        [Key]
        public int CategoryId { get; set; }

        // Add a string value for the Category Name
        public string CategoryName {  get; set; }
    }
}
