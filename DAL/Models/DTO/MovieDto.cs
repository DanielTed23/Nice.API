using DAL.Models.Domain;

public class MovieDto
{
    public int MovieId { get; set; }
    public string Title { get; set; }
    public int DurationMinutes { get; set; }
    public decimal Rating { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public List<Genre> Genres { get; set; } = new List<Genre>();

    // Inkluder PosterPath
    public string? PosterPath { get; set; }
}
