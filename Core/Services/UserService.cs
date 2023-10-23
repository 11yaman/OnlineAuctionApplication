using OnlineAuctionApplication.Core.Models;
using OnlineAuctionApplication.Persistence.Entities;
using OnlineAuctionApplication.Persistence.Repositories;
using System.Security.Cryptography;

namespace OnlineAuctionApplication.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IBidService bidService;    

        public UserService(IUserRepository userRepository, IBidService bidService)
        {
            this.userRepository = userRepository;
            this.bidService = bidService;
            
        }

        public async Task AddOrUpdateAsync(User user)
        {
            await userRepository.AddOrUpdateAsync(user);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return userRepository.GetAll();
        }

        public string GetRoleByUsername(string username)
        {
            return userRepository.GetRoleByUsername(username);
        }

        public User GetUserById(string id)
        {
            return userRepository.GetUserById(id);
        }

        public void DeleteUser(string userId)
        {
            //Auctions is handled by Auto Cascading in db
            bidService.DeleteUserBids(userId);
            userRepository.Delete(userId);
        }
    }
}
