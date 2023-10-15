using OnlineAuctionApplication.Core.Models;

namespace OnlineAuctionApplication.Persistence.Repositories
{
    public interface IUserRepository
    {
        public void Add(User user);
        Task AddOrUpdateAsync(User user);
        User GetUserById(string id);
        public void Update(User user);
    }
}
