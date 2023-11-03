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
        private readonly IAuctionService auctionService;    

        public UserService(IUserRepository userRepository, IBidService bidService, IAuctionService auctionService)
        {
            this.userRepository = userRepository;
            this.bidService = bidService;
            this.auctionService = auctionService;
            
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
            bidService.DeleteUserBids(userId);
            auctionService.DeleteUserAuctions(userId);
            userRepository.Delete(userId);
        }
    }
}
