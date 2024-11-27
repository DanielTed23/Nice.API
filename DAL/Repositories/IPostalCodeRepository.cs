using DAL.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IPostalCodeRepository
    {
        Task<List<PostalCode>> GetAllAsync();
        Task<PostalCode?> GetByIdAsync(int id);
    }
}
