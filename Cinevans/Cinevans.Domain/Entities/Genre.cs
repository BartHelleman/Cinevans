using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinevans.Domain.Entities {
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class Genre {
        [Key]
        public int GenreId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }


    }
}
