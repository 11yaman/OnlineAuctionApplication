using OnlineAuctionApplication.Core.Models;

namespace OnlineAuctionApplication.Core.Services
{
    public interface IAuctionService
    {
        void CreateAuction(Auction auction);

        List<Auction> GetOngoingAuctions();

    }
}
