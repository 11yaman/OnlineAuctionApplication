using OnlineAuctionApplication.Core.Models;
using OnlineAuctionApplication.Persistence.Repositories;

namespace OnlineAuctionApplication.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public void Add(User user)
        {
            throw new NotImplementedException();
        }

        public async Task AddOrUpdateAsync(User user)
        {
            await userRepository.AddOrUpdateAsync(user);
        }

        public User GetUserById(string id)
        {
            throw new NotImplementedException();
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
