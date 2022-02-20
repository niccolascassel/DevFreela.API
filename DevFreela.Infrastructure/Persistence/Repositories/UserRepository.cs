using DevFreela.Core.Entities;
using DevFreela.Core.Interfaces;
using DevFreela.Infrastructure.Persistence.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DevFreelaDbContext dbContext;

        public UserRepository(DevFreelaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddAsync(User user)
        {
            await dbContext.AddAsync(user);
            await dbContext.SaveChangesAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var user = await dbContext.Users.SingleOrDefaultAsync(u => u.Id == id);

            return user;
        }

        public async Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash)
        {
            var user = await dbContext.Users.SingleOrDefaultAsync(u => u.Email == email && u.Password == passwordHash);

            return user;
        }
    }
}
