using DAL.Models.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface ICinemaHallRepository
    {
        Task<List<CinemaHall>> GetAllAsync();
        Task<CinemaHall?> GetByIdAsync(int id);
        Task<CinemaHall> CreateAsync(CinemaHall cinemaHall);
        Task<CinemaHall?> UpdateAsync(int id, CinemaHall cinemaHall);
        Task<bool> DeleteAsync(int id);
    }
}
