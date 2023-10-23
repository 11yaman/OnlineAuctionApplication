using OnlineAuctionApplication.Core.Models;

namespace OnlineAuctionApplication.Persistence.Repositories
{
    public interface IUserRepository
    {
        Task AddOrUpdateAsync(User user);
        void Delete(string userId);
        IEnumerable<User> GetAll();
        string GetRoleByUsername(string username);
        User GetUserById(string id);
    }
}
