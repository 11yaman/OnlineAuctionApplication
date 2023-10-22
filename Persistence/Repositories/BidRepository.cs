using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineAuctionApplication.Core.Models;
using OnlineAuctionApplication.Persistence.Entities;

namespace OnlineAuctionApplication.Persistence.Repositories
{
    public class BidRepository : GenericRepository<BidDb, Bid>, IBidRepository
    {
        public BidRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public IEnumerable<Bid> GetBidsWithBidders(int auctionId)
        {
            return Find(filter: b => b.AuctionId == auctionId,
                includeProperties: "Bidder",
                orderBy: b => b.OrderByDescending(b => b.TimeCreated));
        }

        public override void Add(Bid bid)
        {
            var bidDb = mapper.Map<BidDb>(bid);
            dbSet.Add(bidDb);

            var auctionDb = bidDb.Auction;
            auctionDb.HighestBid = bidDb;
        }
    }
}
