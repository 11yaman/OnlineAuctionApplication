using OnlineAuctionApplication.Core.Models;

namespace OnlineAuctionApplication.Core.Services
{
    public interface IAuctionService
    {
        void CreateAuction(Auction auction);
        Auction GetAuctionById(int auctionId);
        List<Auction> GetOngoingAuctions();
        List<Auction> GetUserOwnAuctions(string userId);
        IEnumerable<Auction> GetUserWonAuctions(string userId);
        IEnumerable<Auction> GetAuctionsWithUserBids(string userId);
        void UpdateDescription(int auctionId, string newDescription, string userId);

    }
}
