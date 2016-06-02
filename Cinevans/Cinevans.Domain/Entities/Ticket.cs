using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinevans.Domain.Entities {
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class Ticket {
        [Key]
        public int TicketId { get; set; }
        public int SeatId { get; set; }
        public int ViewingId { get; set; }
        public int RateId { get; set; }
        public int OrderNumber { get; set; }
        public virtual Viewing Viewing { get; set; }
        public virtual Seat Seat { get; set; }
        public virtual Rate Rate { get; set; }
        //public virtual Order Order { get; set; }
    }
}