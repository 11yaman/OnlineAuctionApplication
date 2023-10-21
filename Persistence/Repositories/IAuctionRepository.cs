using OnlineAuctionApplication.Core.Models;

namespace OnlineAuctionApplication.Persistence.Repositories
{
    public interface IAuctionRepository
    {
        public void CreateAuction(Auction auction);
        Auction GetAuctionById(int auctionId);
        IEnumerable<Auction> GetAuctionsWithUserBids(string userId);
        public List<Auction> GetOngoingAuctions();
        List<Auction> GetUserOwnAuctions(string userId);
        IEnumerable<Auction> GetUserWonAuctions(string userId);
        void UpdateDescription(int auctionId, string newDescription);

    }
}
