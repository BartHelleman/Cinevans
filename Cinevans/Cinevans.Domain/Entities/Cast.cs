using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;

namespace Cinevans.Domain.Entities
{
    [ExcludeFromCodeCoverage]
    public class Cast
    {
        [Key]
        public int CastId { get; set; }
        public string Name { get; set; }

        public int Age { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}
