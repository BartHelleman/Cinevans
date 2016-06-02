using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinevans.Domain.Entities
{
    [ExcludeFromCodeCoverage]
    public class NewsLetter
    {
        [Key]
        public int NewsLetterId { get; set; }
        public string Email { get; set; }
    }
}
