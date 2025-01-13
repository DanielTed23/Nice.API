using DAL.Data;
using DAL.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class SQLGenreRepository : IGenreRepository
{
    private readonly MyDbContext dbContext;

    public SQLGenreRepository(MyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<List<Genre>> GetAllAsync()
    {
        return await dbContext.Genres.ToListAsync();
    }

    public async Task<Genre?> GetByIdAsync(int id)
    {
        return await dbContext.Genres.FirstOrDefaultAsync(x => x.GenreId == id);
    }

    public async Task<List<Genre>> GetGenresByIdsAsync(List<int> genreIds)
    {
        return await dbContext.Genres
            .Where(genre => genreIds.Contains(genre.GenreId))
            .ToListAsync();
    }
}
