using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;

namespace Cinevans.Domain.Entities {
    [ExcludeFromCodeCoverage]
    public class Viewing {
        [Key]
        public int ViewingId { get; set; }
        public DateTime StartTime { get; set; }

        public int MovieId { get; set; }
        public int RoomId { get; set; }


        public virtual Movie Movie { get; set; }
        public virtual Room Room { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}

