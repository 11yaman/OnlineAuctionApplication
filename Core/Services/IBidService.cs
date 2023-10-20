using OnlineAuctionApplication.Core.Models;

namespace OnlineAuctionApplication.Core.Services
{
    public interface IBidService
    {
        void MakeBid(Bid bid);
        List<Bid> GetOngoingAuctionBids(int auctionId);
        List<Bid> GetUserAuctionBids(string userId, int auctionId);
    }
}
