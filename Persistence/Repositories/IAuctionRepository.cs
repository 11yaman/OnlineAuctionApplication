using OnlineAuctionApplication.Core.Models;

namespace OnlineAuctionApplication.Persistence.Repositories
{
    public interface IAuctionRepository
    {
        public void CreateAuction(Auction auction);
        Auction GetAuctionById(int auctionId);
        public List<Auction> GetOngoingAuctions();
        List<Auction> GetUserAuctions(string userId);
        void UpdateDescription(int auctionId, string newDescription);

    }
}
