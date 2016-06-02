using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinevans.Domain.Entities {
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class Rate {

        [Key]
        public int RateId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string EnglishName { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
