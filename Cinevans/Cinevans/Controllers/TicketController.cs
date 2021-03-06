﻿using Cinevans.Domain.Abstract;
using Cinevans.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using iTextSharp.text.pdf;
using System.Drawing;
using iTextSharp.text;

namespace Cinevans.Controllers {
    public class TicketController:Controller {
        ICinemaRepository cinemaRepository;
         
        public TicketController(ICinemaRepository cinemaRepository) {
            this.cinemaRepository = cinemaRepository;
        }
        // Post: Ticket
        [HttpPost]
        public ActionResult Rates(int Normaal, int Studentenkaartje, int Seniorenkaartje, int viewingId, int Popcornarrangement, int Kinderkaartje = 0, int Ladiesnight = 0)
        {
            int normalTicketCount = Normaal;
            int childTicketCount = Kinderkaartje;
            int studentTicketCount = Studentenkaartje;
            int seniorTicketCount = Seniorenkaartje;
            int popcornTicketCount = Popcornarrangement;
            int ladiesTicketCount = Ladiesnight;


            // Get movieViewing so we can retrieve rates again
            Viewing viewing = cinemaRepository.GetViewingById(viewingId);
            //viewing.Movie.AddFeeToRatesPrice();
            Rate normalRate = viewing.Movie.Rates.FirstOrDefault(r => r.Name == "Normaal");
            Rate studentRate = viewing.Movie.Rates.FirstOrDefault(r => r.Name == "Studentenkaartje");
            Rate childRate = viewing.Movie.Rates.FirstOrDefault(r => r.Name == "Kinderkaartje");
            Rate seniorRate = viewing.Movie.Rates.FirstOrDefault(r => r.Name == "Seniorenkaartje");
            Rate popcornRate = viewing.Movie.Rates.FirstOrDefault(r => r.Name == "Popcornarrangement");
            Rate ladiesRate = viewing.Movie.Rates.FirstOrDefault(r => r.Name == "Ladiesnight");

            double normalTicketTotal = normalTicketCount * normalRate.Price;
            double studentTicketTotal = studentTicketCount * studentRate.Price;
            if (childRate != null)
            {
                double childTicketTotal = childTicketCount * childRate.Price;
            }

            double seniorTicketTotal = seniorTicketCount * seniorRate.Price;

            double completeTotal = normalTicketTotal;

            // Time to build some tickets
            List<Ticket> purchasedTickets = new List<Ticket>();

            for (var i = 0; i < normalTicketCount; i++)
            {
                purchasedTickets.Add(
                    new Ticket
                    {
                        Viewing = viewing,
                        ViewingId = viewingId,
                        Rate = normalRate,
                        RateId = normalRate.RateId
                    });
            }

            for (var i = 0; i < studentTicketCount; i++)
            {
                purchasedTickets.Add(
                    new Ticket
                    {
                        Viewing = viewing,
                        ViewingId = viewingId,
                        Rate = studentRate,
                        RateId = studentRate.RateId
                    });
            }

            for (var i = 0; i < seniorTicketCount; i++)
            {
                purchasedTickets.Add(
                    new Ticket
                    {
                        Viewing = viewing,
                        ViewingId = viewingId,
                        Rate = seniorRate,
                        RateId = seniorRate.RateId
                    });
            }
            for (var i = 0; i < childTicketCount; i++)
            {
                purchasedTickets.Add(
                    new Ticket
                    {
                        Viewing = viewing,
                        ViewingId = viewingId,
                        Rate = childRate,
                        RateId = childRate.RateId
                    });
            }

            for (var i = 0; i < popcornTicketCount; i++)
            {
                purchasedTickets.Add(
                    new Ticket
                    {
                        Viewing = viewing,
                        ViewingId = viewingId,
                        Rate = popcornRate,
                        RateId = popcornRate.RateId
                    });
            }
            for (var i = 0; i < ladiesTicketCount; i++)
            {
                purchasedTickets.Add(
                    new Ticket
                    {
                        Viewing = viewing,
                        ViewingId = viewingId,
                        Rate = ladiesRate,
                        RateId = ladiesRate.RateId
                    });
            }


            var allTickets = cinemaRepository.GetAvailableSeats(purchasedTickets, viewing);
            TempData["Tickets"] = allTickets;
            TempData["Viewing"] = viewing;
            return RedirectToAction("PaymentView");
            //var document = GenerateTicket(allTickets, true);
            //return File(document, "application/force-download", "ticket_" + viewing.Movie.Titel + "_" + DateTime.Now);

        }

        [HttpGet]
        public ViewResult Rates(int viewingId)
        {
            var viewing = cinemaRepository.GetViewingById(viewingId);
            var time = DateTime.Today.AddHours(18);
            if (viewing.StartTime.Hour < time.Hour)
            {
                var rate = viewing.Movie.Rates.FirstOrDefault(r => r.Name == "Ladiesnight");
                viewing.Movie.Rates.Remove(rate);
            }
            viewing.Movie.AddFeeToRatesPrice();
            return View("Rates", viewing);
        }

        public ActionResult DownloadTickets() {
            List<Ticket> allTickets = TempData["Tickets"] as List<Ticket>;
            Viewing viewing = TempData["Viewing"] as Viewing;
            viewing.Movie.AddFeeToRatesPrice();
            var document = GenerateTicket(allTickets, true);
            return File(document, "application/force-download", "ticket_" + viewing.Movie.Titel + "_" + DateTime.Now + ".pdf");
        }

        public ActionResult Success() {

            return View("Success");
        }

        public byte[] GenerateTicket(List<Ticket> tickets, bool printFriendly) {


            string logoName = @"C:\PDF\Logo\logo.png";
            byte[] fileContents = null;
            using(MemoryStream stream = new MemoryStream()) {

                var pgSize = new iTextSharp.text.Rectangle(400, 600);

                Document document = new Document(pgSize, 20, 20, 15, 20);
                PdfWriter writer = PdfWriter.GetInstance(document, stream);

                // Add meta information to the document
                document.AddAuthor("Cinevans");
                document.AddSubject("Ticket");
                document.AddTitle("Ticket for print");

                // Open the document to enable you to write to the document
                document.Open();

                // Create paragraph 
                Paragraph p = new Paragraph();

                if(printFriendly == false) {

                    // Adding the logo
                    iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(logoName);
                    p.Add(logo);

                } else {
                    // Adding text instead of logo
                    iTextSharp.text.Font font = FontFactory.GetFont(FontFactory.HELVETICA, 30);
                    p.Font = font;
                    p.Add("Cinevans");
                }
                foreach(Ticket t in tickets) {
                    document.NewPage();
                    // Create paragraph 
                    p = new Paragraph();

                    p.SpacingBefore = 35;

                    PdfPTable table = new PdfPTable(2);
                    table.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    PdfPCell cell = new PdfPCell(new Phrase("Cinevans Breda"));
                    cell.Colspan = 2;
                    cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                    table.AddCell(cell);
                    table.AddCell("Film:");
                    table.AddCell(t.Viewing.Movie.Titel.ToString());
                    table.AddCell("Aanvang:");
                    table.AddCell(t.Viewing.StartTime.ToString());
                    table.AddCell("Zaal:");
                    table.AddCell(t.Viewing.Room.RoomId.ToString());
                    table.AddCell("Rij:");
                    table.AddCell(cinemaRepository.GetSeatById(t.SeatId).Row.RowNumber.ToString());
                    table.AddCell("Stoel:");
                    table.AddCell(cinemaRepository.GetSeatById(t.SeatId).SeatNumber.ToString());

                    table.AddCell(" ");
                    table.AddCell(" ");
                    table.AddCell("Tarief:");
                    table.AddCell(t.Rate.Name.ToString());
                    table.AddCell(" ");
                    table.AddCell(" ");
                    table.AddCell("Prijs:");
                    table.AddCell(t.Rate.Price.ToString());

                    table.SpacingAfter = 65;

                    p.Add(table);
                    document.Add(p);
                }


                // Close the document

                //Needs a dynamic name


                document.Close();

                fileContents = stream.ToArray();
            }
            // Close the writer instance
            return fileContents;
        }
        
        public ViewResult PaymentView() {
            return View("paymentView");
        }

        public List<int> GetIntList(int num) {
            List<int> listOfInts = new List<int>();
            while(num > 0) {
                listOfInts.Add(num % 10);
                num = num / 10;
            }
            listOfInts.Reverse();
            return listOfInts;
        }

        public ActionResult Index() {
            return RedirectToAction("Index", "Home");
        }

        public ViewResult TypeCodePrintTickets() {
            return View("TypeCodePrintTickets");
        }
    }
}