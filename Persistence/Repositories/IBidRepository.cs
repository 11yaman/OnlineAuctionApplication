using OnlineAuctionApplication.Core.Models;
using OnlineAuctionApplication.Persistence.Entities;

namespace OnlineAuctionApplication.Persistence.Repositories
{
    public interface IBidRepository : IGenericRepository<BidDb, Bid>
    {
        IEnumerable<Bid> GetBidsWithBidders(int auctionId);
        Bid GetHighestBidForAuction(int auctionId);
        void AddAndUpdateHighestBid(Bid bid);
        void DeleteAndUpdateIfHighestBid(Bid bid);
        void DeleteBidsForAuction(int auctionId);
    }
}
