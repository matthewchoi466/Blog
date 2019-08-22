using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Domain.Models;
using Blog.Domain.Repositories;
using Blog.Domain.Services;
using Blog.Domain.Services.Communication;

namespace Blog.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserResponse> GetAsync(string name)
        {
            var existingUser = await _userRepository.FindByNameAsync(name);

            if (existingUser == null)
                return new UserResponse("User not found.");
            else
                return new UserResponse(existingUser);
        }
    }
}
