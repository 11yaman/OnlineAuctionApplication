using AutoMapper;
using OnlineAuctionApplication.Core.Models;
using OnlineAuctionApplication.Persistence.Repositories;

namespace OnlineAuctionApplication.Core.Services
{
    public class BidService : IBidService
    {
        private readonly IUnitOfWork unitOfWork;

        public BidService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Bid> GetBidsForOngoingAuction(int auctionId)
        {
            Auction auction = unitOfWork.Auctions.GetByID(auctionId);
            if (auction == null || auction.EndTime < DateTime.Now)
                throw new InvalidOperationException();

            return unitOfWork.Bids.GetBidsWithBidders(auctionId);
        }

        public IEnumerable<Bid> GetBidsForAuctionBySeller(string sellerId, int auctionId)
        {
            Auction auction = unitOfWork.Auctions.GetByID(auctionId);
            if (auction == null || auction.SellerId != sellerId)
                throw new InvalidOperationException();

            return unitOfWork.Bids.GetBidsWithBidders(auctionId);
        }

        public void MakeBid(Bid bid)
        {
            Auction auction = unitOfWork.Auctions.GetByID(bid.AuctionId);
            Console.WriteLine("Auction Id: "+ auction.ToString());
            if (auction == null || auction.EndTime < DateTime.Now)
                throw new InvalidOperationException("The auction not found");
            if (auction.SellerId == bid.BidderId)
                throw new InvalidOperationException("The user can't bid on own auctions.");
            if (auction.HighestBid?.Amount >= bid.Amount || auction.StartingPrice > bid.Amount)
                throw new InvalidOperationException("The bid must be higher than the current highest bid.");

            unitOfWork.Bids.Add(bid);
            unitOfWork.Save();
        }
    }
}
