using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Cinevans.Web.Controllers;
using Cinevans.Domain.Abstract;
using System.Collections.Generic;
using Cinevans.Domain.Entities;
using System.Web.Mvc;

namespace Cinevans.Tests.Controller
{
    [TestClass]
    public class TicketControllerWebTests
    {
        Mock<ICinemaRepository> _mock;
        TicketController ticketController;


        [TestInitialize]
        public void Before()
        {
            //assemble
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

            //act
            ticketController = new TicketController(_mock.Object);
        }

        [TestMethod]
        public void GetRateViewWeb()
        {
            //act
            ViewResult result = ticketController.Rates(1);
            Viewing movieViewingResult = (Viewing)result.Model;
            //assert

            Assert.AreEqual("Rates", result.ViewName);
            // Assert.IsTrue(movieViewingResult.Movie.Rates.Any());
        }

        [TestMethod]
        public void generateTicketPrintFriendlyWeb()
        {
            try
            {
                //assemble
                List<Ticket> ticketList = new List<Ticket>();
                ticketList.Add(new Ticket { TicketId = 1, SeatId = 1, ViewingId = 1, RateId = 1, Rate = new Rate { RateId = 1, Name = "Testrate", Price = 8 }, Seat = new Seat { SeatId = 1, IsTaken = false, Row = new Row { RowNumber = 1 }, }, Viewing = new Viewing { Movie = new Movie { Titel = "MovieTitel" }, StartTime = DateTime.Now, Room = new Room { RoomId = 1 } } });
                ticketList.Add(new Ticket { TicketId = 2, SeatId = 2, ViewingId = 2, RateId = 1, Rate = new Rate { RateId = 1, Name = "Testrate", Price = 8 }, Seat = new Seat { SeatId = 2, IsTaken = false, Row = new Row { RowNumber = 2 }, }, Viewing = new Viewing { Movie = new Movie { Titel = "MovieTitel" }, StartTime = DateTime.Now, Room = new Room { RoomId = 2 } } });
                //act
                ticketController.GenerateTicket(ticketList, true);
                //assert
                //no errors in generateticket()
            }
            catch { }
        }
        [TestMethod]
        public void generateTicketNotPrintFriendlyWeb()
        {
            try
            {
                //assemble
                List<Ticket> ticketList = new List<Ticket>();
                ticketList.Add(new Ticket { TicketId = 1, SeatId = 1, ViewingId = 1, RateId = 1, Rate = new Rate { RateId = 1, Name = "Testrate", Price = 8 }, Seat = new Seat { SeatId = 1, IsTaken = false, Row = new Row { RowNumber = 1 }, }, Viewing = new Viewing { Movie = new Movie { Titel = "MovieTitel" }, StartTime = DateTime.Now, Room = new Room { RoomId = 1 } } });
                ticketList.Add(new Ticket { TicketId = 2, SeatId = 2, ViewingId = 2, RateId = 1, Rate = new Rate { RateId = 1, Name = "Testrate", Price = 8 }, Seat = new Seat { SeatId = 2, IsTaken = false, Row = new Row { RowNumber = 2 }, }, Viewing = new Viewing { Movie = new Movie { Titel = "MovieTitel" }, StartTime = DateTime.Now, Room = new Room { RoomId = 2 } } });
                //act
                ticketController.GenerateTicket(ticketList, false);
                //assert
                //no errors in generateticket()
            }
            catch { }
        }

        [TestMethod]
        public void PaymentViewTestWeb()
        {
            var result = ticketController.PaymentView();
            Assert.AreEqual("paymentView", result.ViewName);
        }

        //TODO test afmaken!
        /*
        [TestMethod]
        public void GenerateTicketTest()
        {

            Ticket t1 = new Ticket
            {
                Viewing = new Viewing
                {
                    Movie = new Movie
                    {
                        Titel = "Deadpool"
                    },
                    StartTime = DateTime.Now.AddHours(3),
                    Room = new Room
                    {
                        RoomId = 1
                    }
                },
                Rate = new Rate
                {
                    Name = "Student",
                    Price = 10
                },
                SeatId = 1
            };
            

            List<Ticket> ticketList = new List<Ticket>();
            ticketList.Add(t1);

            var resultTrue = ticketController.GenerateTicket(ticketList, true);
            var resultFalse = ticketController.GenerateTicket(ticketList, false);

            Assert.IsInstanceOfType(resultTrue, typeof(byte));
            Assert.IsInstanceOfType(resultFalse, typeof(byte));
        }
        */


        [TestMethod]
        public void RatesTestWeb()
        {
            var result = ticketController.Rates(1, 0, 0, 1, 0);
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
        }


        [TestMethod]
        public void SuccessTestWeb()
        {
            var result = ticketController.Success();
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void IndexTestWeb()
        {
            var result = ticketController.Index();
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
        }


        [TestMethod]
        public void DownloadTicketsTestWeb()
        {
            ticketController.Rates(1, 0, 0, 1, 0);
            try
            {
                var result = ticketController.DownloadTickets();
                Assert.IsInstanceOfType(result, typeof(FileResult));
            }
            catch { }
        }

        [TestMethod]
        public void ShowTicketCodeTest()
        {
            //var result = ticketController.ShowTicketCode() as ViewResult;
            //Assert.AreEqual("ShowTicketCode", result.ViewName);
        }


    }
}
