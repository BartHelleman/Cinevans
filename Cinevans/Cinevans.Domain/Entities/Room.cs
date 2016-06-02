using Cinevans.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinevans.Domain.Entities {
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class Room {
        [Key]
        public int RoomId { get; set; }

        public string RoomName { get; set; }
        public bool Accessbility { get; set; }
        public bool is3D { get; set; }

        public int AllSeats {
            get {
                return Rows.Sum(r => r.Seats.Count());
            }
        }
        public virtual ICollection<Viewing> Viewings { get; set; }

        public virtual ICollection<Row> Rows { get; set; }

        public CinemaRepository repository = new CinemaRepository();

        public IEnumerable<Seat> GetAllRoomSeats(int i) {
            List<Seat> seats = repository.GetAllSeats()
                .Where(k => k.RowId == i)
                .ToList();

            return seats;
        }

        public List<Ticket> GetAvailableSeats(int RoomId, List<Ticket> ticketList, Viewing viewing) {
            int Amount = ticketList.Count();
            List<Row> rows = viewing.Room.Rows.ToList();
            List<Seat> newSeats = new List<Seat>(Amount);

            for(int i = (rows.Count / 2);i < rows.Count();++i) {
                List<Seat> seats = viewing.Room.GetAllRoomSeats(i).ToList();

                for(int j = (seats.Count() / 2);j < seats.Count();++j) {
                    if(newSeats.Count == Amount) {
                        repository.UpdateSeats(newSeats);

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
                    } else {
                        if(seats[j].IsTaken == false) {
                            newSeats.Add(seats[j]);
                        } else {
                            newSeats.Clear();
                        }
                    }
                }

                newSeats.Clear();

                for (int j = 0;j < (seats.Count() / 2 + Amount);++j) {
                    if(newSeats.Count == Amount) {
                        repository.UpdateSeats(newSeats);

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
                    } else {
                        if(seats[j].IsTaken == false) {
                            newSeats.Add(seats[j]);
                        } else {
                            newSeats.Clear();
                        }
                    }
                }
            }

            for(int i = (rows.Count() / 2 - 1);i >= 0;--i) {
                List<Seat> seats = viewing.Room.GetAllRoomSeats(i).ToList();
                newSeats.Clear();

                for (int j = (seats.Count() / 2);j < seats.Count();++j) {
                    if(newSeats.Count == Amount) {
                        repository.UpdateSeats(newSeats);

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
                    } else {
                        if(seats[j].IsTaken == false) {
                            newSeats.Add(seats[j]);
                        } else {
                            newSeats.Clear();
                        }
                    }
                }

                newSeats.Clear();

                for (int j = 0;j < (seats.Count() / 2 + Amount);++j) {
                    if(newSeats.Count == Amount) {
                        repository.UpdateSeats(newSeats);

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
                    } else {
                        if(seats[j].IsTaken == false) {
                            newSeats.Add(seats[j]);
                        } else {
                            newSeats.Clear();
                        }
                    }
                }
            }
            return ticketList;
        }
    }
}
