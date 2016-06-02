using Cinevans.Domain.Abstract;
using Cinevans.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cinevans.Web.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        ICinemaRepository cinemaRepository;
        public MovieController(ICinemaRepository cinemaRepository)
        {
            this.cinemaRepository = cinemaRepository;
        }

        public ActionResult Index()
        {
            return View("Index");
        }

        public void UpdateUserReview(int movieId, int rating)
        {
            Movie currentMovie = cinemaRepository.GetMovieById(movieId);
            cinemaRepository.UpdateUserReview(currentMovie, rating);
            string redirectUrl = "/Home/MovieDetail?movieId=" + movieId;
            Response.Redirect(redirectUrl);
        }
    }
}