using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinevans.Domain.Entities {
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class Seat {
        [Key]
        public int SeatId { get; set; }
        public int SeatNumber { get; set; }
        public int RowId { get; set; }

        public bool IsTaken { get; set; }
        public virtual Row Row { get; set; }
    }
}
