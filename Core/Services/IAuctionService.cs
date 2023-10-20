using OnlineAuctionApplication.Core.Models;

namespace OnlineAuctionApplication.Core.Services
{
    public interface IAuctionService
    {
        void CreateAuction(Auction auction);
        Auction GetAuctionById(int auctionId);
        List<Auction> GetOngoingAuctions();
        List<Auction> GetUserAuctions(string userId);
        void UpdateDescription(int auctionId, string newDescription);

    }
}
