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

        public Auction GetAuctionById(int auctionId)
        {
            return auctionRepository.GetAuctionById(auctionId);   
        }

        public List<Auction> GetOngoingAuctions()
        {
            return auctionRepository.GetOngoingAuctions();
        }

        public List<Auction> GetUserAuctions(string userId)
        {
            return auctionRepository.GetUserAuctions(userId);
        }

        public void UpdateDescription(int auctionId, string newDescription)
        {
            auctionRepository.UpdateDescription(auctionId, newDescription);
        }
    }
}
