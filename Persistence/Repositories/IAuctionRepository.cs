using OnlineAuctionApplication.Core.Models;

namespace OnlineAuctionApplication.Persistence.Repositories
{
    public interface IAuctionRepository
    {
        public void CreateAuction(Auction auction);
        public List<Auction> GetOngoingAuctions();

    }
}
