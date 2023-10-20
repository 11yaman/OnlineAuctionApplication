using OnlineAuctionApplication.Core.Models;

namespace OnlineAuctionApplication.Persistence.Repositories
{
    public interface IBidRepository
    {
        void AddBid(Bid bid);
        List<Bid> GetBidList(int auctionId);
    }
}
