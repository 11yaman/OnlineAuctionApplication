using AutoMapper;
using OnlineAuctionApplication.Core.Models;
using OnlineAuctionApplication.Persistence.Repositories;

namespace OnlineAuctionApplication.Core.Services
{
    public class BidService : IBidService
    {
        private readonly IBidRepository bidRepository;
        private readonly IMapper mapper;
        private readonly IAuctionRepository auctionRepository;

        public BidService(IBidRepository bidRepository, IMapper mapper, IAuctionRepository auctionRepository)
        {
            this.bidRepository = bidRepository;
            this.mapper = mapper;
            this.auctionRepository = auctionRepository; 
        }

        public List<Bid> GetOngoingAuctionBids(int auctionId)
        {
            Auction auction = auctionRepository.GetAuctionById(auctionId);
            if (auction == null || auction.EndTime < DateTime.Now)
                throw new InvalidOperationException();
            return bidRepository.GetBidList(auctionId);
        }

        public List<Bid> GetUserAuctionBids(string userId, int auctionId)
        {
            Auction auction = auctionRepository.GetAuctionById(auctionId);
            if (auction == null || auction.SellerId != userId)
                throw new InvalidOperationException();

            return bidRepository.GetBidList(auctionId);
        }

        public void MakeBid(Bid bid)
        {
            Auction auction = auctionRepository.GetAuctionById(bid.AuctionId);

            if (auction.SellerId == bid.BidderId)
                throw new InvalidOperationException("The user can't bid on own auctions.");

            if (bid.Amount <= auction.HighestAmount)
                throw new InvalidOperationException("The bid must be higher than the current highest bid.");

            bidRepository.AddBid(bid);
        }
    }
}
