using Cinevans.Web.Controllers;
using Cinevans.Domain.Abstract;
using Cinevans.Domain.Concrete;
using Cinevans.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Cinevans.Tests.Controller
{
    [TestClass]
    public class HomeControllerWebTests
    {
        Mock<ICinemaRepository> _mock;
        ICinemaRepository rep;
        HomeController homeController = new HomeController();

        [TestInitialize]
        public void Before()
        {
            _mock = new Mock<ICinemaRepository>();
            List<Seat> seats = new List<Seat>();
            seats.Add(new Seat { RowId = 0, IsTaken = true, SeatNumber = 1 });
            seats.Add(new Seat { RowId = 1, IsTaken = false, SeatNumber = 2 });
            seats.Add(new Seat { RowId = 2, IsTaken = false, SeatNumber = 3 });
            seats.Add(new Seat { RowId = 3, IsTaken = false, SeatNumber = 4 });
            seats.Add(new Seat { RowId = 4, IsTaken = true, SeatNumber = 5 });
            seats.Add(new Seat { RowId = 5, IsTaken = true, SeatNumber = 6 });
            seats.Add(new Seat { RowId = 6, IsTaken = true, SeatNumber = 7 });
            seats.Add(new Seat { RowId = 7, IsTaken = true, SeatNumber = 8 });
            List<Seat> seats2 = new List<Seat>();
            seats.Add(new Seat { RowId = 8, IsTaken = true, SeatNumber = 1 });
            seats.Add(new Seat { RowId = 9, IsTaken = false, SeatNumber = 2 });
            seats.Add(new Seat { RowId = 10, IsTaken = false, SeatNumber = 3 });
            seats.Add(new Seat { RowId = 11, IsTaken = false, SeatNumber = 4 });
            seats.Add(new Seat { RowId = 12, IsTaken = true, SeatNumber = 5 });
            seats.Add(new Seat { RowId = 13, IsTaken = true, SeatNumber = 6 });
            seats.Add(new Seat { RowId = 14, IsTaken = true, SeatNumber = 7 });
            seats.Add(new Seat { RowId = 15, IsTaken = true, SeatNumber = 8 });
            List<Row> rows = new List<Row>();
            rows.Add(new Row { RowId = 1, Seats = seats });
            rows.Add(new Row { RowId = 2, Seats = seats2 });

            List<NewsLetter> subscriptions = new List<NewsLetter>();
            subscriptions.Add(new NewsLetter { NewsLetterId = 1, Email = "nick_audenaerde@hotmail.com" });
            NewsLetter news = new NewsLetter{ NewsLetterId = 2 , Email = "hallo@hotmail.com"};
        
            List<Rate> rates = new List<Rate>
            {
                new Rate{ Name = "Normaal", Price = 4.00 , RateId = 1},
                new Rate{ Name = "Studentenkaartje", Price = 4.00 , RateId = 1},
                new Rate{ Name = "Kinderkaartje", Price = 4.00 , RateId = 1},
                new Rate{ Name = "Seniorenkaartje", Price = 4.00 , RateId = 1}
            };
            _mock.Setup(m => m.GetViewingById(It.IsAny<int>())).Returns(new Viewing
            {
                ViewingId = 1,
                MovieId = 1,
                StartTime = DateTime.Now,
                Movie = new Movie
                {
                    MovieId = 1,
                    Titel = "The Revenant",
                    MovieImage = "",
                    is3D = true,
                    Duration = 120,
                    Description = "Helemaal testing",
                    ReleaseDate = DateTime.Now,
                    Age = 16,
                    HasSubtitles = true,
                    Language = "Dutch",
                    Rates = rates
                },
                RoomId = 1,
                Room = new Room()
                {
                    RoomId = 1,
                    RoomName = "Zaal Test",
                    is3D = false,
                    Accessbility = true,
                    Rows = rows
                }


            });


            homeController = new HomeController(_mock.Object);
        }

        /*
        [TestMethod]
        public void IndexViewTest()
        {
            var result = homeController.Index();
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
        */

        [TestMethod]
        public void HomeControllerTest()
        {
            var result = new HomeController(rep);
        }

        /*
        [TestMethod]
        public void ViewingDetailTest()
        {
            var result = homeController.ViewingDetail(1);
            Assert.AreEqual("ViewingDetail", result);
        }
        */

        [TestMethod]
        public void ContactTest()
        {
            var result = homeController.Contact();
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void ThanksTest()
        {
            var result = homeController.Thanks();
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void NewsLetterTest()
        {
            ViewResult result = homeController.NewsLetter("hallo@hotmail.com");
            ViewResult result1 = homeController.NewsLetter("niethallo@hotmail.com");
            Assert.AreEqual("Thanks", result1.ViewName);
            Assert.IsNotNull(result);
            Assert.AreEqual("Thanks", result.ViewName);
        }

        [TestMethod]
        public void MovieDetailTest()
        {
            //var result = homeController.MovieDetail(1) as ViewResult;
            //Assert.AreEqual("MovieDetail", result.ViewName);
        }

        [TestMethod]
        public void IndexTest()
        {
            ViewResult result = homeController.Index();
            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void ViewingDetailTest()
        {
            var result = homeController.ViewingDetail(1) as ViewResult;
            Assert.AreEqual("ViewingDetail", result.ViewName);
        }

        [TestMethod]
        public void MoviesTest()
        {
            var result = homeController.Movies(true) as ViewResult;
            Assert.AreEqual("Movies", result.ViewName);
        }

        [TestMethod]
        public void SortMoviesTest()
        {
            var result = homeController.SortMovies("a-z");
            Assert.AreEqual("_Movies", result.ViewName);
        }

        [TestMethod]
        public void SetCultureTest()
        {
//            var result = homeController.SetCulture("en-US");

  //          Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
        }
    }
}
