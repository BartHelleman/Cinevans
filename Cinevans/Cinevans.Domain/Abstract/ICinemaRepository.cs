using Cinevans.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinevans.Domain.Abstract {
    public interface ICinemaRepository {
        List<Viewing> GetAllViewings();

        IEnumerable<Viewing> GetUpcomingViewings();

        IEnumerable<Viewing> GetUpcomingViewings3d();

        IEnumerable<Viewing> GetUpcomingViewingsWheelchair();

        IEnumerable<Viewing> GetUpcomingViewingsDutch();
        IEnumerable<Viewing> GetUpcomingWeekViews();

        Viewing GetViewingById(int viewingId);

        IEnumerable<Viewing> GetViewingsByDate(bool asc);


        IEnumerable<Movie> GetMoviesByTitle(bool asc);

        IEnumerable<Rate> GetAllRates();

        IEnumerable<Movie> GetAllMovies();
        Movie GetMovieById(int id);

        IEnumerable<Seat> GetAllSeats();

        List<Ticket> GetAvailableSeats(List<Ticket> ticketList, Viewing viewing);

        List<int> GetAmountOfAvailableSeats();

        IEnumerable<Review> GetReviews(int movieId);

        IEnumerable<Viewing> GetViewingsByMovieId(int movieId);

        void UpdateSeats(List<Seat> seats);

        void UpdateUserReview(Movie movie, int newUserRate);

        bool CheckSubscriptions(string email);

        void AddEmailToNewsLetter(NewsLetter newsLetter);

        Seat GetSeatById(int seatId);

        List<Order> GetAllOrders();

        void SaveTicketList(List<Ticket> ticketList);

        List<Ticket> GetAllTickets();

        Double GetIncomeByMovieId(int movieId);

        int GetAmountOfViewingsByMovieId(int movieId);

        IEnumerable<Room> GetAllRooms();

        void AddSubscription(Subscription subscription);

        void AddViewing(Viewing viewing);

        void AddMovie(Movie movie);

        void AddReview(Review review);
    }
}
