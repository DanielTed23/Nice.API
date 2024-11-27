using DAL.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IUserRepository
    {
        Task<User> CreateAsync(User user);
        Task<List<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<User?> UpdateAsync(int id, User user);
        Task<User?> DeleteAsync(int id);
    }
}
