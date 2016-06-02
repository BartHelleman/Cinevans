using Cinevans.Domain.Abstract;
using Cinevans.Domain.Entities;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cinevans.Web.Controllers
{
    public class PaydeskController : Controller
    {
        // GET: Paydesk
        ICinemaRepository repository;

        public PaydeskController(ICinemaRepository repository)
        {
            this.repository = repository;
        }

        [Authorize(Roles = "Kassamedewerker")]
        public ActionResult Subscription()
        {
            return View("Subscription");
        }

        [HttpPost]
        public ActionResult Subscription(Subscription subscription)
        {
            if(ModelState.IsValid)
            {
                repository.AddSubscription(subscription);
                return View("SubscriptionSuccess", subscription);
            }
            return View();
        }

        [Authorize(Roles = "Kassamedewerker")]
        public ActionResult Availibility()
        {
            return View("Availibility");
        }

        [Authorize(Roles = "Kassamedewerker")]
        public ActionResult SubscriptionSuccess(Subscription subscription)
        {
            return View("SubscriptionSuccess", subscription);
        }

        public List<int> GetAmountOfAvailableSeats()
        {
            return repository.GetAmountOfAvailableSeats();
        }

        public ActionResult DownloadSubscription(Subscription subscription)
        {
            var document = GenerateTicket(subscription);
            return File(document, "application/force-download", "subscription_" + subscription.FirstName + "_" + subscription.LastName + ".pdf");
        }

        [HttpPost]
        public ActionResult PrintSubscription(Subscription subscription)
        {
            return DownloadSubscription(subscription);
        }

        public byte[] GenerateTicket(Subscription subscription)
        {
            //string logoName = @"C:\PDF\Logo\logo.png";
            //string imageName = "~/Images/51aac8e5328790194fc4220dfd88c1f7.jpg";
            byte[] fileContents = null;
            using (MemoryStream stream = new MemoryStream())
            {
                var pgSize = new iTextSharp.text.Rectangle(400, 600);

                Document document = new Document(pgSize, 20, 20, 15, 20);
                PdfWriter writer = PdfWriter.GetInstance(document, stream);

                // Add meta information to the document
                document.AddAuthor("Cinevans");
                document.AddSubject("Abonnement");
                document.AddTitle("Abonnement");

                // Open the document to enable you to write to the document
                document.Open();

                // Create paragraph 
                Paragraph p = new Paragraph();

                //iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(logoName);
                //iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(imageName);
                //p.Add(logo);

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
                table.AddCell("Voornaam:");
                table.AddCell(subscription.FirstName);
                table.AddCell("Achternaam:");
                table.AddCell(subscription.LastName);
                table.AddCell("Adres:");
                table.AddCell(subscription.Address);
                table.AddCell("Plaats:");
                table.AddCell(subscription.City);
                table.AddCell("Datum:");
                table.AddCell(subscription.Date.ToString());
                
                table.SpacingAfter = 65;

                p.Add(table);
                //p.Add(image);
                document.Add(p);

                // Close the document
                
                document.Close();

                fileContents = stream.ToArray();
            }
            // Close the writer instance
            return fileContents;
        }
    }
}