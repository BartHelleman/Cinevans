using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cinevans.Web.Controllers;
using System.Web.Mvc;
using Cinevans.Domain.Concrete;

namespace Cinevans.Tests.Controller
{
    [TestClass]
    public class MovieControllerTest
    {
        CinemaRepository cinemaRepository = new CinemaRepository();
        [TestMethod]
        public void TestIndex()
        {
            MovieController con = new MovieController(cinemaRepository);
            ViewResult result = (ViewResult)con.Index();
            Assert.AreEqual("Index", result.ViewName);
        }

    }
}
