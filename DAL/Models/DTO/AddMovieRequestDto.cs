using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models.DTO
{
    public class AddMovieRequestDto
    {
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Duration must be greater than 0.")]
        public int DurationMinutes { get; set; }

        [Range(0, 5, ErrorMessage = "Rating must be between 0 and 5.")]
        public decimal Rating { get; set; }

        [Required(ErrorMessage = "Release date is required.")]
        public DateOnly ReleaseDate { get; set; }

        [Required(ErrorMessage = "CinemaHallId is required.")]
        public int CinemaHallId { get; set; }
        public string? PosterPath { get; set; }

        
    }
}
