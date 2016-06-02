using Cinevans.Domain.Abstract;
using Cinevans.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cinevans.Web.Controllers
{
    public class BackofficeController : Controller
    {
        // GET: Backoffice
        ICinemaRepository repository;

        public BackofficeController(ICinemaRepository repository)
        {
            this.repository = repository;
        }
        
        [Authorize(Roles = "Backoffice")]
        public ActionResult AddMovie()
        {
            return View("AddMovie");
        }

        [HttpPost]
        [Authorize(Roles = "Backoffice")]
        public ActionResult AddMovie(Movie movie)
        {
            if(ModelState.IsValid)
            {
                repository.AddMovie(movie);
                return View();
            }
            return View();
        }

        [Authorize(Roles = "Backoffice")]
        public ActionResult AddViewing()
        {
            return View("AddViewing");
        }

        [HttpPost]
        [Authorize(Roles = "Backoffice")]
        public ActionResult AddViewing(Viewing viewing)
        {
            if(ModelState.IsValid)
            {
                List<Viewing> allViewings = repository.GetAllViewings();
                Movie movie = repository.GetMovieById(viewing.MovieId);
                foreach(Viewing v in allViewings)
                {
                    if(viewing.RoomId == v.RoomId &&
                        viewing.StartTime <= v.StartTime.AddMinutes(v.Movie.Duration) &&
                        viewing.StartTime.AddMinutes(movie.Duration) >= v.StartTime)
                    {
                        return View();
                    }
                }
                repository.AddViewing(viewing);
                return View();
            }
            return View();
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return repository.GetAllMovies();
        }

        public IEnumerable<Room> GetAllRooms()
        {
            return repository.GetAllRooms();
        }
    }
}