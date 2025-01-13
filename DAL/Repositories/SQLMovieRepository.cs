using DAL.Data;
using DAL.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class SQLMovieRepository : IMovieRepository
    {
        private readonly MyDbContext dbContext;

        public SQLMovieRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Movie> CreateAsync(Movie movie)
        {
            await dbContext.Movies.AddAsync(movie);
            await dbContext.SaveChangesAsync();
            return movie;
        }

        public async Task<Movie?> DeleteAsync(int id)
        {
            var existingMovie = await dbContext.Movies.FirstOrDefaultAsync(x => x.MovieId == id);

            if (existingMovie == null)
            {
                return null;
            }

            dbContext.Movies.Remove(existingMovie);
            await dbContext.SaveChangesAsync();
            return existingMovie;
        }

        public async Task<List<Movie>> GetAllAsync()
        {
            return await dbContext.Movies.Include(m => m.Genres).ToListAsync();
        }

        public async Task<Movie?> GetByIdAsync(int id)
        {
            return await dbContext.Movies
                .Include(m => m.Genres)
                .FirstOrDefaultAsync(x => x.MovieId == id);
        }

        public async Task<Movie?> UpdateAsync(int id, Movie movie)
        {
            var existingMovie = await dbContext.Movies.Include(m => m.Genres).FirstOrDefaultAsync(x => x.MovieId == id);
            if (existingMovie == null)
            {
                return null;
            }

            existingMovie.Title = movie.Title;
            existingMovie.Duration = movie.Duration;
            existingMovie.ReleaseDate = movie.ReleaseDate;
            existingMovie.Rating = movie.Rating;
            existingMovie.Genres = movie.Genres;

            await dbContext.SaveChangesAsync();
            return existingMovie;
        }

        public async Task<List<Genre>> GetGenresByIdsAsync(List<int> genreIds)
        {
            return await dbContext.Genres
                .Where(g => genreIds.Contains(g.GenreId))
                .ToListAsync();
        }
    }
}
