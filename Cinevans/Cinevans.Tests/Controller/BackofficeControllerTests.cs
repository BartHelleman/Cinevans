using Cinevans.Domain.Abstract;
using Cinevans.Domain.Entities;
using Cinevans.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinevans.Tests.Controller
{
    [TestClass]
    public class BackofficeControllerTests
    {
        [TestMethod]
        public void AddMovie()
        {
            Mock<ICinemaRepository> mock = new Mock<ICinemaRepository>();
            mock.Setup(m => m.GetMovieById(It.IsAny<int>())).Returns(new Movie
            {
                MovieId = 15,
                Titel = "Testmovie",
                Duration = 100,
                Age = 12,
                MovieImage = "",
                Description = "Testmovie description",
                EnglishDescription = "English description",
                is3D = false,
                ReleaseDate = DateTime.Today,
                Language = "English",
                HasSubtitles = true,
                MovieTrailerUrl = "",
                MovieWebsite = "",
                ImdbLink = "",
                UserReview = 3
            });

            //Arrange
            BackofficeController target = new BackofficeController(mock.Object);

            //Action
            Movie result = target.GetAllMovies().Where(m => m.MovieId == 15).FirstOrDefault();

            //Assert
            Assert.AreEqual(result.MovieId, 15);
            Assert.AreEqual(result.is3D, false);
            Assert.AreEqual(result.Language, "English");
        }

        [TestMethod]
        public void AddViewing()
        {
            Mock<ICinemaRepository> mock = new Mock<ICinemaRepository>();
            mock.Setup(m => m.GetViewingById(It.IsAny<int>())).Returns(new Viewing
            {
                ViewingId = 100,
                StartTime = DateTime.Now,
                MovieId = 1,
                RoomId = 3
            });

            //Arrange
            BackofficeController target = new BackofficeController(mock.Object);

            //Action
            Movie result = target.GetAllMovies().Where(m => m.MovieId == 1).FirstOrDefault();

            //Assert
            Assert.AreEqual(result.MovieId, 1);
            Assert.AreEqual(result.is3D, false);
            Assert.AreEqual(result.Language, "English");
        }
    }
}
