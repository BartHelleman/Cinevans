using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;
using Cinevans.Domain.Concrete;

namespace Cinevans.Domain.Entities
{
    [ExcludeFromCodeCoverage]
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        public string Titel { get; set; }
        public int Duration { get; set; }
        public int Age { get; set; }
        public string MovieImage { get; set; }
        public string Description { get; set; }
        public string EnglishDescription { get; set; }
        public bool is3D { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Language { get; set; }
        public bool HasSubtitles { get; set; }

        public string MovieTrailerUrl { get; set; }

        public string MovieWebsite { get; set; }

        public string ImdbLink { get; set; }

        public int UserReview { get; set; }

        public void AddFeeToRatesPrice()
        {
            List<Rate> movieRates = Rates.ToList();
            foreach (Rate rate in Rates)
            {
                if (is3D)
                {
                    rate.Price += 2.50;
                }

                if (Duration > 120)
                {
                    rate.Price += 0.50;
                }

            }

            Rates = movieRates;
        }

        public virtual ICollection<Rate> Rates { get; set; }

        public virtual ICollection<Genre> Genres { get; set; }
        public virtual ICollection<Cast> Casts { get; set; }
        public virtual ICollection<Director> Directors { get; set; }

        public virtual ICollection<Viewing> Viewings { get; set; }
    }
}
