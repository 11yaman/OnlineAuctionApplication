using Microsoft.EntityFrameworkCore;
using OnlineAuctionApplication.Core.Models;
using OnlineAuctionApplication.Persistence.Repositories;
using System.Reflection.Metadata.Ecma335;

namespace OnlineAuctionApplication.Core.Services
{
    public class AuctionService : IAuctionService
    {
        private readonly IUnitOfWork unitOfWork;

        public AuctionService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void CreateAuction(Auction auction)
        {
            unitOfWork.Auctions.Add(auction);
            unitOfWork.Save();
        }

        public IEnumerable<Auction> GetAllOngoingAuctions()
        {
            return unitOfWork.Auctions.GetAllOngoingAuctions();
        }

        public Auction GetAuctionById(int auctionId)
        {
            return unitOfWork.Auctions.GetByID(auctionId);
        }

        public IEnumerable<Auction> GetAuctionsBySeller(string sellerId)
        {
            return unitOfWork.Auctions.GetAuctionsBySeller(sellerId);
        }

        public IEnumerable<Auction> GetWonAuctionsByBidder(string bidderId)
        {
            return unitOfWork.Auctions.GetWonAuctionsByBidder(bidderId);
        }

        public IEnumerable<Auction> GetOngoingAuctionsByBidder(string bidderId)
        {
            return unitOfWork.Auctions.GetOngoingAuctionsByBidder(bidderId);
        }

        public void UpdateDescription(int auctionId, string newDescription, string sellerId)
        {
            var auction = unitOfWork.Auctions.GetByID(auctionId);
            if (auction == null || !auction.SellerId.Equals(sellerId) || auction.EndTime < DateTime.Now)
                throw new InvalidOperationException();

            unitOfWork.Auctions.UpdateDescription(auctionId, newDescription);
            unitOfWork.Save();
        }

        public void DeleteAuction(int auctionId)
        {
            unitOfWork.Bids.DeleteBidsForAuction(auctionId);
            unitOfWork.Save();

            unitOfWork.Auctions.Delete(auctionId);
            unitOfWork.Save();
        }
    }
}
