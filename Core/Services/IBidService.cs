using OnlineAuctionApplication.Core.Models;

namespace OnlineAuctionApplication.Core.Services
{
    public interface IBidService
    {
        void MakeBid(Bid bid);
        List<Bid> GetBidList(int auctionId);
    }
}
