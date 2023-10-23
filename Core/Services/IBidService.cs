using OnlineAuctionApplication.Core.Models;

namespace OnlineAuctionApplication.Core.Services
{
    public interface IBidService
    {
        void MakeBid(Bid bid);
        IEnumerable<Bid> GetBidsForOngoingAuction(int auctionId);
        IEnumerable<Bid> GetBidsForAuctionBySeller(string sellerId, int auctionId);
        IEnumerable<Bid> GetBidsForAuction(int auctionId);
        void DeleteUserBids(string userId);
    }
}
