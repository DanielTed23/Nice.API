using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Domain
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public decimal Rating { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public ICollection<Screening> Screenings { get; set; } = new List<Screening>(); // Filmens screenings
        public int CinemaHallId { get; set; }
        public CinemaHall CinemaHall { get; set; } = null!;

        public ICollection<Genre> Genres { get; set; } = new List<Genre>();
    }
}
