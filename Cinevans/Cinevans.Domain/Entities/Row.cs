using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinevans.Domain.Entities {
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class Row {
        [Key]
        public int RowId { get; set; }

        public int RowNumber { get; set; }

        public virtual ICollection<Seat> Seats { get; set; }
    }
}
