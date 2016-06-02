using Cinevans.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;

namespace Cinevans.Controllers {
    public class HomeController:Controller {
        ICinemaRepository cinemaRepository;

        public HomeController(ICinemaRepository cinemaRepository) {
            this.cinemaRepository = cinemaRepository;
        }

        public HomeController() {
        }

        public ViewResult Index() {
            var movies = cinemaRepository.GetUpcomingViewings();
            ViewBag.Title = "Index";
            return View("Index", movies);
        }

        public ViewResult Index3d() {
            var movies = cinemaRepository.GetUpcomingViewings3d();
            ViewBag.Title = "3D";
            return View("Index", movies);
        }

        public ViewResult IndexWheelchair() {
            var movies = cinemaRepository.GetUpcomingViewingsWheelchair();
            ViewBag.Title = "Rolstoel vriendelijk";
            return View("Index", movies);
        }

        public ViewResult IndexDutchMovies() {
            var movies = cinemaRepository.GetUpcomingViewingsDutch();
            ViewBag.Title = "Nederlandse films";
            return View("Index", movies);
        }

        public ViewResult PaymentView() {
            return View();
        }

        public ActionResult ViewingDetail(int viewingId) {


            return View(cinemaRepository.GetViewingById(viewingId));
        }


    }
}