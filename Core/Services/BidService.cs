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

        public List<Bid> GetBidList(int auctionId)
        {
            return bidRepository.GetBidList(auctionId);
        }

        public void MakeBid(Bid bid)
        {
            Console.WriteLine("Make Bid " + bid.ToString());
            //it must be higher than previous bids
            //user cant bid own auctions
            //add to db

            Auction auction = auctionRepository.GetAuctionById(bid.AuctionId);

            if (auction.SellerId == bid.BidderId)
                throw new InvalidOperationException("The user can't bid on own auctions.");

            if (bid.Amount <= auction.HighestAmount)
                throw new InvalidOperationException("The bid must be higher than the current highest bid.");

            bidRepository.AddBid(bid);
        }
    }
}
