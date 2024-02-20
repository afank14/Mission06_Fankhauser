using Microsoft.AspNetCore.Mvc;
using Mission06_Fankhauser.Models;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

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
            // Create a viewbag to display all the categories from the category table
            ViewBag.Categories = _context.Categories.ToList();

            // return with a new instance of the movieEntry model so that the MovieId defaults to 0 and isn't null
            return View(new MovieEntry());
        }

        // Post action that renders the confirmation view when a movie is submitted
        [HttpPost]
        public IActionResult EnterMovie(MovieEntry response) 
        {
            // Check for validation
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response); // Add record to the database
                _context.SaveChanges();

                return View("Confirmation", response);
            }
            // If the entered info doesn't match requirements for the model
            else
            {
                // remake the viewbag and go to the EnterMovie view with the response already inputted so they can
                // just edit what they had already entered
                ViewBag.Categories = _context.Categories.ToList();

                return View(response);
            }
        }

        // Create the Get action for the collection view
        [HttpGet]
        public IActionResult Collection()
        {
            // Use linq to show the records from the database
            var movies = _context.Movies.ToList();

            return View(movies);
        }

        // Create a get action for the edit button which receives the MovieId from the route
        [HttpGet]
        public IActionResult Edit(int id)
        {
            // Grab the single record to edit based on the MovieId based in the URL route
            var recordToEdit = _context.Movies
                .Single(x => x.MovieId == id);

            // Remake the viewbag again
            ViewBag.Categories = _context.Categories.ToList();

            // go to the EnterMovie view with the record to edit info already in the input fields
            return View("EnterMovie", recordToEdit);
        }

        // Create a Post action for the edit
        [HttpPost]
        public IActionResult Edit(MovieEntry updatedInfo)
        {
            // We're gonna make sure when they update info, they don't take out required info by validating again
            if(ModelState.IsValid)
            {
                // if it is valid, go ahead and update that record and save the changes
                _context.Update(updatedInfo);
                _context.SaveChanges();

                // Redirect back to the collection action
                return RedirectToAction("Collection");
            }
            else
            {
                // If it is invalid, stay on the enter movie page with their updated info already inputted
                ViewBag.Categories = _context.Categories.ToList();

                return View("EnterMovie", updatedInfo);
            }
            
        }

        // Create a get action for delete button. Receives the MovieId from the route
        [HttpGet]
        public IActionResult Delete(int id)
        {
            // Grab the single record based on the MovieId passed in the route
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == id);

            // Go to the delete view and pass the record to be deleted
            return View(recordToDelete);
        }

        // Create a post action for the delete button
        [HttpPost]
        public IActionResult Delete(MovieEntry deletedInfo)
        {
            // Delete the record and save the change to the db
            _context.Movies.Remove(deletedInfo);
            _context.SaveChanges();

            // redirect to the Collection action to show the records
            return RedirectToAction("Collection");
        }
    }
}
