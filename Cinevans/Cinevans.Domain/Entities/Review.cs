using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinevans.Domain.Entities
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        public string ReviewMessage { get; set; }
        public string UserName { get; set; }
        public int MovieId { get; set; }
    }
}
