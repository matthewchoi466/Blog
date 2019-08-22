using System.Threading.Tasks;
using Blog.Domain.Services.Communication;

namespace Blog.Domain.Services
{
    public interface IUserService
    {
        Task<UserResponse> GetAsync(string name);
    }
}
