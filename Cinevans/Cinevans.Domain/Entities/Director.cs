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
    public class Director
    {
        [Key]
        public int DirectorId { get; set; }
        public string Name { get; set; }

        public int Age { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
