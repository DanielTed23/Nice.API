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
    public class SQLUserRepository : IUserRepository
    {
        private readonly MyDbContext dbContext;

        public SQLUserRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<User> CreateAsync(User user)
        {
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User?> DeleteAsync(int id)
        {
            var existingUser = await dbContext.Users.FirstOrDefaultAsync(x => x.UserId == id);

            if (existingUser == null)
            {
                return null;
            }

            dbContext.Users.Remove(existingUser); // There is no Async remove in EF at this time.
            await dbContext.SaveChangesAsync();
            return existingUser;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await dbContext.Users.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await dbContext.Users
                         .FirstOrDefaultAsync(x => x.UserId == id);


        }

        public async Task<User?> UpdateAsync(int id, User user)
        {
            var existingUser = await dbContext.Users.FirstOrDefaultAsync(x => x.UserId == id);
            if (existingUser == null)
            {
                return null;
            }

            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Email = user.Email;

            await dbContext.SaveChangesAsync();
            return existingUser;
        }
    }
}
