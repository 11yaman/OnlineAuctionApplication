using OnlineAuctionApplication.Core.Models;

namespace OnlineAuctionApplication.Persistence.Repositories
{
    public interface IUserRepository
    {
        void Add(User user);
        Task AddOrUpdateAsync(User user);
        User GetUserById(string id);
        void Update(User user);
    }
}
