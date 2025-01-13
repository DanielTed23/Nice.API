using DAL.Models.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IGenreRepository
{
    Task<List<Genre>> GetAllAsync();
    Task<Genre?> GetByIdAsync(int id);
    Task<List<Genre>> GetGenresByIdsAsync(List<int> genreIds); // Ny metode til at hente genrer via IDs
}
