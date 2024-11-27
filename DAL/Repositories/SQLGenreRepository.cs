using DAL.Data;
using DAL.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
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
            return await dbContext.Genres
                         .FirstOrDefaultAsync(x => x.GenreID == id);


        }
    }
}
