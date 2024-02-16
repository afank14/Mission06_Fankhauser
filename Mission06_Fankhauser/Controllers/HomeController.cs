using Microsoft.AspNetCore.Mvc;
using Mission06_Fankhauser.Models;
using System.Diagnostics;

namespace Mission06_Fankhauser.Controllers
{
    public class HomeController : Controller
    {
        // make an instance of the database for use in the program
        private MovieEntryContext _context;

        // Controller
        public HomeController(MovieEntryContext temp)
        {
            // Set the private variable available to all the class equal to this temp instance of the db
            _context = temp;
        }

        // Action for the index view
        public IActionResult Index()
        {
            return View();
        }

        // Action for the about view
        public IActionResult About()
        {
            return View();
        }

        // Get action for the EnterMovie view
        [HttpGet]
        public IActionResult EnterMovie()
        {
            return View();
        }

        // Post action that renders the confirmation view when a movie is submitted
        [HttpPost]
        public IActionResult EnterMovie(MovieEntry response) 
        {
            // Add the record to the database
            _context.Movies.Add(response);
            _context.SaveChanges();
           
            // return the confirmation view with the response object to be used in the display
            return View("Confirmation", response);
        }
    }
}
