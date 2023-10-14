using Microsoft.EntityFrameworkCore;
using OnlineAuctionApplication.Core.Models;
using OnlineAuctionApplication.Persistence.Repositories;
using System.Reflection.Metadata.Ecma335;

namespace OnlineAuctionApplication.Core.Services
{
    public class AuctionService : IAuctionService
    {
        private IAuctionRepository auctionRepository;

        public AuctionService(IAuctionRepository auctionRepository)
        {
            this.auctionRepository = auctionRepository;
        }

        public void CreateAuction(Auction auction)
        {
            auctionRepository.CreateAuction(auction);
        }

        public List<Auction> GetOngoingAuctions()
        {
            return auctionRepository.GetOngoingAuctions();
        }
    }
}
