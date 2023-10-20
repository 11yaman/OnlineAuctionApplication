using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineAuctionApplication.Core.Models;
using OnlineAuctionApplication.Persistence.Entities;

namespace OnlineAuctionApplication.Persistence.Repositories
{
    public class BidRepository : IBidRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public BidRepository(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void AddBid(Bid bid)
        {
            var bidDb = mapper.Map<BidDb>(bid);
            context.BidDbs.Add(bidDb);
            var auctionDb = bidDb.Auction;

            if (auctionDb == null || auctionDb.HighestAmount > bidDb.Amount)
                throw new InvalidOperationException();

            auctionDb.HighestAmount = bidDb.Amount;
            context.SaveChanges();
        }


        public List<Bid> GetBidList(int auctionId)
        {
            var bidDbs = context.BidDbs
            .Where(bdb => bdb.AuctionId == auctionId)
            .Include(bdb => bdb.Bidder)
            .OrderByDescending(bdb => bdb.TimeCreated)
            .ToList();

            var bids = new List<Bid>();
            foreach (var bdb in bidDbs)
            {
                bids.Add(mapper.Map<Bid>(bdb));
            }
            return bids;
        }
    }
}
