using OnlineAuctionSystem.Core.Models;

namespace OnlineAuctionSystem.Core.Services
{
    public interface IAuctionService
    {
        void CreateAuction(Auction auction);

        List<Auction> GetOngoingAuctions();

    }
}
