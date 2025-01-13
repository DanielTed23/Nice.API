using System.Collections.Generic;

namespace DAL.Models.DTO
{
    public class UpdateMovieRequestDto
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public int DurationMinutes { get; set; }
        public decimal Rating { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public List<int> Genres { get; set; } = new List<int>();
    }
}
