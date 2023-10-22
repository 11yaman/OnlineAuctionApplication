using OnlineAuctionApplication.Core.Models;
using OnlineAuctionApplication.Persistence.Entities;

namespace OnlineAuctionApplication.Persistence.Repositories
{
    public interface IAuctionRepository : IGenericRepository<AuctionDb, Auction>
    {
        //public void CreateAuction(Auction auction);
        //Auction GetAuctionById(int auctionId);
        IEnumerable<Auction> GetAllOngoingAuctions();
        IEnumerable<Auction> GetAuctionsBySeller(string sellerId);
        IEnumerable<Auction> GetWonAuctionsByBidder(string bidderId);
        IEnumerable<Auction> GetOngoingAuctionsByBidder(string bidderId);
        void UpdateDescription(int auctionId, string newDescription);

    }
}
