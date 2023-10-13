using Microsoft.EntityFrameworkCore;
using OnlineAuctionSystem.Core.Models;
using OnlineAuctionSystem.Persistence.Repositories;
using System.Reflection.Metadata.Ecma335;

namespace OnlineAuctionSystem.Core.Services
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
