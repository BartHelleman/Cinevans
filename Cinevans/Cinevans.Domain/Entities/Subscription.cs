using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinevans.Domain.Entities
{
    public class Subscription
    {
        [Key]
        public int SubscriptionId { get; set; }
        [Required(ErrorMessage = "Voer de voornaam in")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Voer de achternaam in")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Voer het adres in")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Voer de woonplaats in")]
        public string City { get; set; }
        public string Image { get; set; }
        [Required(ErrorMessage = "Voer de datum in")]
        public DateTime Date { get; set; }
    }
}
