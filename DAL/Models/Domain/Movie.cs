using DAL.Models.Domain;

public class Movie
{
    public int MovieId { get; set; }
    public string Title { get; set; }
    public int Duration { get; set; }
    public decimal Rating { get; set; }
    public DateOnly ReleaseDate { get; set; }

    public ICollection<Screening> Screenings { get; set; } = new List<Screening>();
    public int CinemaHallId { get; set; }
    public CinemaHall CinemaHall { get; set; } = null!;

    public ICollection<Genre> Genres { get; set; } = new List<Genre>();

    // Tilføj dette felt
    public string? PosterPath { get; set; }
}
