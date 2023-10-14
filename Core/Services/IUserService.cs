using OnlineAuctionApplication.Core.Models;

namespace OnlineAuctionApplication.Core.Services
{
    public interface IUserService
    {
        public void Add(User user);
        public void Update(User user);
    }
}
