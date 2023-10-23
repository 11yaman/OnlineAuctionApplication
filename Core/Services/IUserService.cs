using OnlineAuctionApplication.Core.Models;

namespace OnlineAuctionApplication.Core.Services
{
    public interface IUserService
    {
        Task AddOrUpdateAsync(User user);
        void DeleteUser(string userId);
        IEnumerable<User> GetAllUsers();
        string GetRoleByUsername(string? name);
        User GetUserById(string id);
    }
}
