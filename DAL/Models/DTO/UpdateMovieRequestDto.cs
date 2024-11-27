using DAL.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.DTO
{
    public class UpdateMovieRequestDto
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public int DurationMinutes { get; set; }
        public decimal Rating { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public List<Genre> Genres { get; set; } = new List<Genre>();

    }
}
