using OnlineAuctionApplication.Core.Models;

namespace OnlineAuctionApplication.Core.Services
{
    public interface IAuctionService
    {
        void CreateAuction(Auction auction);
        Auction GetAuctionById(int auctionId);
        IEnumerable<Auction> GetAllOngoingAuctions();
        IEnumerable<Auction> GetAuctionsBySeller(string sellerId);
        IEnumerable<Auction> GetWonAuctionsByBidder(string bidderId);
        IEnumerable<Auction> GetOngoingAuctionsByBidder(string bidderId);
        void UpdateDescription(int auctionId, string newDescription, string sellerId);
        void DeleteAuction(int auctionId);
    }
}
