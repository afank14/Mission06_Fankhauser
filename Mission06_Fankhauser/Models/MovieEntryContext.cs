using Microsoft.EntityFrameworkCore;

namespace Mission06_Fankhauser.Models
{
    // Let the class inherit from DbContext
    public class MovieEntryContext : DbContext
    {
        // Build a constructor to set up the options and include base options
        public MovieEntryContext(DbContextOptions<MovieEntryContext> options) : base (options) 
        { 
        }

        // Make a Db Set of a Movie Entry and name the table Movies
        public DbSet<MovieEntry> Movies { get; set; }
    }
}
