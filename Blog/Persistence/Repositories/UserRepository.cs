using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Blog.Domain.Models;
using Blog.Domain.Repositories;
using Blog.Persistence.Contexts;

namespace Blog.Persistence.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<User> FindByNameAsync(string name)
        {
            return await context.Users.SingleOrDefaultAsync(p => p.Name == name);       
        }
    }
}
