using DAL.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IGenreRepository
    {
        Task<List<Genre>> GetAllAsync();
        Task<Genre?> GetByIdAsync(int id);
    }
}
