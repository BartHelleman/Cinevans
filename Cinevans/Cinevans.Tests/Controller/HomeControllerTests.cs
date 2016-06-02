using Cinevans.Controllers;
using Cinevans.Domain.Abstract;
using Cinevans.Domain.Concrete;
using Cinevans.Domain.Entities;
using Cinevans.Domain.Migrations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Cinevans.Tests {
    [TestClass]
    public class HomeControllerTests {
        Mock<ICinemaRepository> _mock;
        HomeController homeController;

        [TestInitialize]
        public void Before() {
            _mock = new Mock<ICinemaRepository>();
            this.homeController = new HomeController();
        }

        [TestMethod]
        public void GetUpcomingMoviesTest() {

            _mock.Setup(m => m.GetUpcomingViewings()).Returns(new List<Viewing>()
            {
                new Viewing
                {
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
                    },
                    RoomId = 1,
                    Room = new Room(){
                        RoomId = 1,
                        RoomName = "Zaal Test",
                        is3D = false,
                        Accessbility = true,
                    }
            }});
            //assemble

            //act
            HomeController homeController = new HomeController(_mock.Object);

            ViewResult result = homeController.Index();
            IEnumerable<Viewing> movieViewingResult = (IEnumerable<Viewing>)result.Model;
            //assert

            Assert.AreEqual("Index",result.ViewName);

        }

        [TestMethod]
        public void GetUpcoming3DMoviesTest() {

            _mock.Setup(m => m.GetUpcomingViewings()).Returns(new List<Viewing>()
            {
                new Viewing
                {
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
                    },
                    RoomId = 1,
                    Room = new Room(){
                        RoomId = 1,
                        RoomName = "Zaal Test",
                        is3D = false,
                        Accessbility = true,
                    }
            }});
            //assemble

            //act
            HomeController homeController = new HomeController(_mock.Object);

            ViewResult result = homeController.Index3d();
            IEnumerable<Viewing> movieViewingResult = (IEnumerable<Viewing>)result.Model;
            //assert

            Assert.AreEqual("Index",result.ViewName);

        }

        [TestMethod]
        public void GetUpcomingWheelchairMoviesTest() {

            _mock.Setup(m => m.GetUpcomingViewings()).Returns(new List<Viewing>()
            {
                new Viewing
                {
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
                    },
                    RoomId = 1,
                    Room = new Room(){
                        RoomId = 1,
                        RoomName = "Zaal Test",
                        is3D = false,
                        Accessbility = true,
                    }
            }});
            //assemble

            //act
            HomeController homeController = new HomeController(_mock.Object);

            ViewResult result = homeController.IndexWheelchair();
            IEnumerable<Viewing> movieViewingResult = (IEnumerable<Viewing>)result.Model;
            //assert

            Assert.AreEqual("Index",result.ViewName);

        }

        [TestMethod]
        public void GetUpcomingDutchMoviesTest() {

            _mock.Setup(m => m.GetUpcomingViewings()).Returns(new List<Viewing>()
            {
                new Viewing
                {
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
                    },
                    RoomId = 1,
                    Room = new Room(){
                        RoomId = 1,
                        RoomName = "Zaal Test",
                        is3D = false,
                        Accessbility = true,
                    }
            }});
            //assemble

            //act
            HomeController homeController = new HomeController(_mock.Object);

            ViewResult result = homeController.IndexDutchMovies();
            IEnumerable<Viewing> movieViewingResult = (IEnumerable<Viewing>)result.Model;
            //assert

            Assert.AreEqual("Index",result.ViewName);

        }
    }
}
