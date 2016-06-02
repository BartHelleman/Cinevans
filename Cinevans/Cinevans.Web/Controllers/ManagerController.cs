using Cinevans.Domain.Abstract;
using Cinevans.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cinevans.Web.Controllers
{
    public class ManagerController : Controller
    {
        // GET: Manager
        ICinemaRepository repository;

        public ManagerController(ICinemaRepository repository)
        {
            this.repository = repository;
        }

        [Authorize(Roles = "Manager")]
        public ActionResult Financial()
        {
            return View("Financial");
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return repository.GetAllMovies();
        }

        public Double GetIncomeByMovieId(int movieId)
        {
            return repository.GetIncomeByMovieId(movieId);
        }

        public int GetAmountOfViewingsByMovieId(int movieId)
        {
            return repository.GetAmountOfViewingsByMovieId(movieId);
        }
    }
}