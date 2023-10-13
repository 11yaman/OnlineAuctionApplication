using OnlineAuctionSystem.Core.Models;

namespace OnlineAuctionSystem.Persistence.Repositories
{
    public interface IAuctionRepository
    {
        public void CreateAuction(Auction auction);
        public List<Auction> GetOngoingAuctions();

    }
}
