using Cinevans.Domain.Abstract;
using Cinevans.Domain.Entities;
using Cinevans.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cinevans.Web.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        ICinemaRepository cinemaRepository;

        public HomeController()
        {

        }

        public HomeController(ICinemaRepository cinemaRepository)
        {
            this.cinemaRepository = cinemaRepository;
        }

        public ViewResult Index()
        {
            var movies = cinemaRepository.GetViewingsByDate(true);
            ViewBag.Title = "Index";
            return View("Index", movies);
        }

        public ActionResult ViewingDetail(int viewingId)
        {
            return View("ViewingDetail", cinemaRepository.GetViewingById(viewingId));
        }

        public ActionResult Movies(Boolean asc = true)
        {
            return View("Movies", cinemaRepository.GetMoviesByTitle(asc));
        }
        
        public PartialViewResult SortMovies(String sort)
        {
            Boolean asc = true;
            if(sort == "z-a") {
                asc = false;
            }
            return PartialView("_Movies", cinemaRepository.GetMoviesByTitle(asc));
        }

        public ViewResult MovieDetail(int movieId)
        {
            
            var movie = cinemaRepository.GetMovieById(movieId);
            movie.Viewings = cinemaRepository.GetViewingsByMovieId(movieId).ToList();
            return View("MovieDetail",movie);
        }

        public ViewResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ViewResult NewsLetter(string email)
        {
            NewsLetter n = new NewsLetter();
            n.Email = email;

            if(cinemaRepository.CheckSubscriptions(email) == true)
            {
                cinemaRepository.AddEmailToNewsLetter(n);
                ViewBag.check = "Subscribed";
                return View("Thanks");
            } else
            {
                ViewBag.check = "AlreadySubscribed"; 
                return View("Thanks");
            }
        }

        public ViewResult Thanks()
        {
            return View();
        }


        public ActionResult SetCulture(string culture)
        {
            // Validate input
            culture = CultureHelper.GetImplementedCulture(culture);
            // Save culture in a cookie
            HttpCookie cookie = Request.Cookies["_culture"];
            if (cookie != null)
                cookie.Value = culture;   // update cookie value
            else
            {
                cookie = new HttpCookie("_culture");
                cookie.Value = culture;
                cookie.Expires = DateTime.Now.AddYears(1);
            }
            Response.Cookies.Add(cookie);
            return Redirect(Request.UrlReferrer.ToString());
        }

        public IEnumerable<Review> GetReviews(int movieId)
        {
            return cinemaRepository.GetReviews(movieId);
        }

        public void AddReviewMovie(string reviewMessage, string userName, int movieId)
        {
            Review review = new Review { ReviewMessage = reviewMessage, UserName = userName, MovieId = movieId };
            cinemaRepository.AddReview(review);
            string redirectUrl = "/Home/MovieDetail?movieId=" + movieId;
            Response.Redirect(redirectUrl);
        }

        public void AddReviewViewing(string reviewMessage, string userName, int movieId)
        {
            Review review = new Review { ReviewMessage = reviewMessage, UserName = userName, MovieId = movieId };
            cinemaRepository.AddReview(review);
            string redirectUrl = "/Home/ViewingDetail?viewingId=" + movieId;
            Response.Redirect(redirectUrl);
        }
    }
}