using OnlineAuctionApplication.Core.Models;

namespace OnlineAuctionApplication.Core.Services
{
    public interface IUserService
    {
        void Add(User user);
        Task AddOrUpdateAsync(User user);
        User GetUserById(string id);
        void Update(User user);
    }
}
