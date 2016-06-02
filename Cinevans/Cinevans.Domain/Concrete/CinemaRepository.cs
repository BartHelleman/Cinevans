using Cinevans.Domain.Abstract;
using Cinevans.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Cinevans.Domain.Concrete {
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics;
    [ExcludeFromCodeCoverage]
    public class CinemaRepository:ICinemaRepository {
        private readonly EFDbContext _efdbContext = new EFDbContext();

        public bool CheckSubscriptions(string email)
        {
            var subscriptionList = _efdbContext.NewsLetter.ToList();
            if (subscriptionList.Where(v => v.Email == email).FirstOrDefault() == null)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public List<Viewing> GetAllViewings()
        {
            return _efdbContext.Viewing.ToList();
        }

        public IEnumerable<Viewing> GetUpcomingViewings() {
            DateTime currentDate = DateTime.Now.Date;
            var viewingList = _efdbContext.Viewing.ToList();
            return viewingList.Where(v => (
                v.StartTime.Date==currentDate.Date)&&
                (v.StartTime.TimeOfDay>currentDate.TimeOfDay)
            ).OrderBy(v => v.StartTime);
        }

        public IEnumerable<Viewing> GetUpcomingViewings3d() {
            DateTime currentDate = DateTime.Now.Date;
            var viewingList = _efdbContext.Viewing.ToList();
            return viewingList.Where(v => (
                v.StartTime.Date==currentDate.Date)&&
                (v.StartTime.TimeOfDay>currentDate.TimeOfDay)&&
                (v.Movie.is3D==true)
            ).OrderBy(v => v.StartTime);
        }

        public IEnumerable<Viewing> GetUpcomingViewingsWheelchair()
        {
            DateTime currentDate = DateTime.Now.Date;
            var viewingList = _efdbContext.Viewing.ToList();
            return viewingList.Where(v => (v.StartTime.Date == currentDate.Date) &&
            (v.StartTime.TimeOfDay > currentDate.TimeOfDay) &&
            (v.Room.Accessbility == true)).OrderBy(v => v.StartTime);
        }

        public IEnumerable<Viewing> GetUpcomingViewingsDutch()
        {
            DateTime currentDate = DateTime.Now.Date;
            var viewingList = _efdbContext.Viewing.ToList();
            return viewingList.Where(v => (v.StartTime.Date == currentDate.Date) &&
            (v.StartTime.TimeOfDay > currentDate.TimeOfDay) &&
            (v.Movie.Language == "Dutch")).OrderBy(v => v.StartTime);
        }


        public IEnumerable<Rate> GetAllRates() {
            return _efdbContext.Rate;
        }


        public Viewing GetViewingById(int viewingId) {
            return _efdbContext.Viewing.FirstOrDefault(v => v.ViewingId==viewingId);
        }

        public IEnumerable<Viewing> GetViewingsByMovieId(int movieId)
        {
            DateTime currentDate = DateTime.Now.Date;
            var viewingList = _efdbContext.Viewing.ToList();
            return viewingList.Where(v => (v.StartTime.Date >= currentDate.Date) &&
                (v.StartTime.TimeOfDay > currentDate.TimeOfDay)  &&
                (v.MovieId == movieId)
            ).OrderBy(v => v.StartTime);
        }

     

        public IEnumerable<Viewing> GetViewingsByDate(bool asc)
        {
            DateTime currentDate = DateTime.Now.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
            DayOfWeek currentDay = (DateTime.Now.DayOfWeek);
            
                switch (currentDay)
                {
                    case DayOfWeek.Thursday:
                        currentDate = currentDate.AddDays(6);
                        break;
                    case DayOfWeek.Friday:
                        currentDate = currentDate.AddDays(5);
                        break;
                    case DayOfWeek.Saturday:
                        currentDate = currentDate.AddDays(4);
                        break;
                    case DayOfWeek.Sunday:
                        currentDate = currentDate.AddDays(3);
                        break;
                    case DayOfWeek.Monday:
                        currentDate = currentDate.AddDays(2);
                        break;
                    case DayOfWeek.Tuesday:
                        currentDate = currentDate.AddDays(1);
                        break;
                }

            DateTime now = DateTime.Now.Date;
            IEnumerable<Viewing> movieWeek = _efdbContext.Viewing.Where(v => v.StartTime >= now && v.StartTime <= currentDate);

            if (asc)
                movieWeek = movieWeek.OrderBy(v => v.StartTime);
            else
                movieWeek = movieWeek.OrderByDescending(v => v.StartTime);
          
            return movieWeek;
        }

        public IEnumerable<Movie> GetMoviesByTitle(bool asc)
        {
            if (asc)
            {
                return _efdbContext.Movie.OrderBy(v => v.Titel);
            }
            else
            {
                return _efdbContext.Movie.OrderByDescending(v => v.Titel);
            }
        }

        public IEnumerable<Movie> GetAllMovies() {
            return _efdbContext.Movie;
        }

        public Movie GetMovieById(int id) {
            Debug.WriteLine("Movie id in CinemaRepository: "+id);
            return _efdbContext.Movie.FirstOrDefault(x => x.MovieId==id);
        }

        public IEnumerable<Seat> GetAllSeats() {
            return _efdbContext.Seat;
        }

        public IEnumerable<Review> GetReviews(int movieId)
        {
            return _efdbContext.Reiew.Where(m => m.MovieId == movieId);
        }

        public void UpdateSeats(List<Seat> seats)
        {
            foreach(Seat s in seats)
            {
                _efdbContext.Seat.Where(z => z.SeatId == s.SeatId).FirstOrDefault().IsTaken = true;
            }
            _efdbContext.SaveChanges();
        }

        public void UpdateUserReview(Movie movie, int newUserRate)
        {
            movie.UserReview = (movie.UserReview + newUserRate) / 2;
            _efdbContext.Movie.Where(m => m.MovieId == movie.MovieId).FirstOrDefault();
            _efdbContext.SaveChanges();
        }

        public List<Ticket> GetAvailableSeats(List<Ticket> ticketList, Viewing viewing)
        {
            int Amount = ticketList.Count();
            List<Row> rows = viewing.Room.Rows.ToList();
            List<Seat> newSeats = new List<Seat>(Amount);

            for (int i = (rows.Count / 2); i < rows.Count(); ++i)
            {
                List<Seat> seats = viewing.Room.GetAllRoomSeats(i).ToList();

                for (int j = (seats.Count() / 2); j < seats.Count(); ++j)
                {
                    if (newSeats.Count == Amount)
                    {
                        UpdateSeats(newSeats);

                        int k = 0;

                        foreach (var ticket in ticketList)
                        {
                            do
                            {
                                ticket.SeatId = newSeats[k].SeatId;
                                k++;
                            }
                            while (k > newSeats.Count());
                        }

                        return ticketList;
                    }
                    else {
                        if (seats[j].IsTaken == false)
                        {
                            newSeats.Add(seats[j]);
                        }
                        else {
                            newSeats.Clear();
                        }
                    }
                }

                newSeats.Clear();

                for (int j = 0; j < (seats.Count() / 2 + Amount); ++j)
                {
                    if (newSeats.Count == Amount)
                    {
                        UpdateSeats(newSeats);

                        int k = 0;

                        foreach (var ticket in ticketList)
                        {
                            do
                            {
                                ticket.SeatId = newSeats[k].SeatId;
                                k++;
                            }
                            while (k > newSeats.Count());
                        }

                        return ticketList;
                    }
                    else {
                        if (seats[j].IsTaken == false)
                        {
                            newSeats.Add(seats[j]);
                        }
                        else {
                            newSeats.Clear();
                        }
                    }
                }
            }

            for (int i = (rows.Count() / 2 - 1); i >= 0; --i)
            {
                List<Seat> seats = viewing.Room.GetAllRoomSeats(i).ToList();
                newSeats.Clear();

                for (int j = (seats.Count() / 2); j < seats.Count(); ++j)
                {
                    if (newSeats.Count == Amount)
                    {
                        UpdateSeats(newSeats);

                        int k = 0;

                        foreach (var ticket in ticketList)
                        {
                            do
                            {
                                ticket.SeatId = newSeats[k].SeatId;
                                k++;
                            }
                            while (k > newSeats.Count());
                        }

                        return ticketList;
                    }
                    else {
                        if (seats[j].IsTaken == false)
                        {
                            newSeats.Add(seats[j]);
                        }
                        else {
                            newSeats.Clear();
                        }
                    }
                }

                newSeats.Clear();

                for (int j = 0; j < (seats.Count() / 2 + Amount); ++j)
                {
                    if (newSeats.Count == Amount)
                    {
                        UpdateSeats(newSeats);

                        int k = 0;

                        foreach (var ticket in ticketList)
                        {
                            do
                            {
                                ticket.SeatId = newSeats[k].SeatId;
                                k++;
                            }
                            while (k > newSeats.Count());
                        }

                        return ticketList;
                    }
                    else {
                        if (seats[j].IsTaken == false)
                        {
                            newSeats.Add(seats[j]);
                        }
                        else {
                            newSeats.Clear();
                        }
                    }
                }
            }
            return ticketList;
        }

        public Seat GetSeatById(int seatId)
        {
            return _efdbContext.Seat.FirstOrDefault(s => s.SeatId == seatId);
        }

        public IEnumerable<Viewing> GetUpcomingWeekViews()
        {
            throw new NotImplementedException();
        }

        public void AddEmailToNewsLetter(NewsLetter newsLetter)
        {
            _efdbContext.NewsLetter.Add(newsLetter);
            _efdbContext.SaveChanges();
        }

        public void AddSubscription(Subscription subscription)
        {
            _efdbContext.Subscription.Add(subscription);
            _efdbContext.SaveChanges();
        }

        public void AddViewing(Viewing viewing)
        {
            _efdbContext.Viewing.Add(viewing);
            _efdbContext.SaveChanges();
        }

        public void AddMovie(Movie movie)
        {
            _efdbContext.Movie.Add(movie);
            _efdbContext.SaveChanges();
        }

        public void AddReview(Review review)
        {
            _efdbContext.Reiew.Add(review);
            _efdbContext.SaveChanges();
        }

        public List<Order> GetAllOrders() {
            return _efdbContext.Order.ToList();
        }

        private int GetNewOrderId() {
            List<Order> allOrders = GetAllOrders();
            int newOrderId = 0;
            foreach(Order order in allOrders) {
                if(order.OrderId > newOrderId) {
                    newOrderId = order.OrderId + 1;
                }
            }
            return newOrderId;
        }

        private void SaveOrder(Order order) {
            _efdbContext.Order.Add(order);
            _efdbContext.SaveChanges();
        }

        public List<Ticket> GetAllTickets() {
            return _efdbContext.Ticket.ToList();
        }

        public Double GetIncomeByMovieId(int movieId)
        {
            IEnumerable<Ticket> tickets = _efdbContext.Ticket;

            var a = tickets.Where(t => t.Viewing.MovieId == movieId);
            double income = 0;
                
            foreach(Ticket t in a)
            {
                income += t.Rate.Price;
            }
            
            return income;
        }

        public int GetAmountOfViewingsByMovieId(int movieId)
        {
            DateTime currentDate = DateTime.Now;
            return _efdbContext.Viewing.Where(v => v.MovieId == movieId && v.StartTime < currentDate).Count();
        }

        public IEnumerable<Room> GetAllRooms()
        {
            return _efdbContext.Room;
        }

        public void SaveTicketList(List<Ticket> ticketList) {
            int newOrderId = GetNewOrderId();
            Order newOrder = new Order { OrderId = newOrderId };
            SaveOrder(newOrder);
            foreach(Ticket ticket in ticketList) {
                ticket.OrderNumber = newOrderId;
                SaveTicket(ticket);
            }
            _efdbContext.SaveChanges();
        }

        private void SaveTicket(Ticket newTicket) {
            Debug.WriteLine("#################");
            Debug.WriteLine("Ticket opslaan...");
            Debug.WriteLine("OrderId: " + newTicket.OrderNumber);
            Debug.WriteLine("RateId: " + newTicket.RateId);
            Debug.WriteLine("SeatId: " + newTicket.SeatId);
            Debug.WriteLine("ViewingId: " + newTicket.ViewingId);
            newTicket.Rate = null;
            newTicket.Seat = null;
            newTicket.Viewing = null;
            _efdbContext.Ticket.Add(newTicket);
        }

        public List<int> GetAmountOfAvailableSeats()
        {
            List<Seat> allAvailableSeats = _efdbContext.Seat.Where(s => s.IsTaken == false).ToList();
            int room1 = allAvailableSeats.Where(s => s.SeatId <= 120).Count();
            int room2 = allAvailableSeats.Where(s => s.SeatId > 120 && s.SeatId <= 240).Count();
            int room3 = allAvailableSeats.Where(s => s.SeatId > 240 && s.SeatId <= 360).Count();
            int room4 = allAvailableSeats.Where(s => s.SeatId > 360 && s.SeatId <= 420).Count();
            int room5 = allAvailableSeats.Where(s => s.SeatId > 420 && s.SeatId <= 470).Count();
            int room6 = allAvailableSeats.Where(s => s.SeatId > 470 && s.SeatId <= 520).Count();

            return new List<int> { room1, room2, room3, room4, room5, room6 };
        }
    }
}