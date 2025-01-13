using DAL.Data;
using DAL.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class SQLCinemaHallRepository : ICinemaHallRepository
    {
        private readonly MyDbContext _dbContext;

        public SQLCinemaHallRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CinemaHall>> GetAllAsync()
        {
            return await _dbContext.CinemaHalls
                .Include(ch => ch.CinemaAddress) // Include navigation property if needed
                .ToListAsync();
        }

        public async Task<CinemaHall?> GetByIdAsync(int id)
        {
            return await _dbContext.CinemaHalls
                .Include(ch => ch.CinemaAddress) // Include navigation property if needed
                .FirstOrDefaultAsync(ch => ch.CinemaHallId == id);
        }

        public async Task<CinemaHall> CreateAsync(CinemaHall cinemaHall)
        {
            await _dbContext.CinemaHalls.AddAsync(cinemaHall);
            await _dbContext.SaveChangesAsync();
            return cinemaHall;
        }

        public async Task<CinemaHall?> UpdateAsync(int id, CinemaHall cinemaHall)
        {
            var existingCinemaHall = await _dbContext.CinemaHalls.FirstOrDefaultAsync(ch => ch.CinemaHallId == id);
            if (existingCinemaHall == null)
            {
                return null;
            }

            existingCinemaHall.Name = cinemaHall.Name;
            existingCinemaHall.SeatCapacity = cinemaHall.SeatCapacity;
            existingCinemaHall.CinemaAddress = cinemaHall.CinemaAddress;

            await _dbContext.SaveChangesAsync();
            return existingCinemaHall;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var cinemaHall = await _dbContext.CinemaHalls.FirstOrDefaultAsync(ch => ch.CinemaHallId == id);
            if (cinemaHall == null)
            {
                return false;
            }

            _dbContext.CinemaHalls.Remove(cinemaHall);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
