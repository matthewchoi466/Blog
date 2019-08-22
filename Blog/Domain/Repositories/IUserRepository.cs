using System.Threading.Tasks;
using Blog.Domain.Models;

namespace Blog.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> FindByNameAsync(string Name);
    }
}
