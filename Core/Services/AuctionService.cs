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

        public Auction GetAuctionById(int auctionId)
        {
            return auctionRepository.GetAuctionById(auctionId);
        }

        public List<Auction> GetUserOwnAuctions(string userId)
        {
            return auctionRepository.GetUserOwnAuctions(userId);
        }

        public IEnumerable<Auction> GetUserWonAuctions(string userId)
        {
            return auctionRepository.GetUserWonAuctions(userId);
        }

        public IEnumerable<Auction> GetAuctionsWithUserBids(string userId)
        {
            return auctionRepository.GetAuctionsWithUserBids(userId);
        }

        public void UpdateDescription(int auctionId, string newDescription, string userId)
        {
            var auction = auctionRepository.GetAuctionById(auctionId);
            if (auction == null || !auction.SellerId.Equals(userId) || auction.EndTime < DateTime.Now)
                throw new InvalidOperationException();

            auctionRepository.UpdateDescription(auctionId, newDescription);
        }
    }
}
