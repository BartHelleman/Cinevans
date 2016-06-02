using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinevans.Domain.Entities {
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class Order {
        [Key]
        public int OrderId { get; set; }

        public double TotalPrice {
            get { return Tickets.Sum(t => t.Rate.Price); }
        }

        public virtual ICollection<Ticket> Tickets { get; set; }

    }
}
