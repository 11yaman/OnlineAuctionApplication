using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineAuctionApplication.Core.Models;
using OnlineAuctionApplication.Persistence.Entities;
using OnlineAuctionApplication.ViewModels;
using System.Security.Cryptography;

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

        public Bid GetHighestBidForAuction(int auctionId)
        {
            return Find(filter: b => b.AuctionId == auctionId)?.OrderByDescending(b => b.Amount).FirstOrDefault(); ;
        }

        public void AddAndUpdateHighestBid(Bid bid)
        {
            var bidDb = mapper.Map<BidDb>(bid);
            var auctionDb = bidDb.Auction ?? context.Set<AuctionDb>().Find(bidDb.AuctionId);

            dbSet.Add(bidDb);
            auctionDb.HighestBid = bidDb;
            context.Set<AuctionDb>().Attach(auctionDb);
        }

        public void DeleteAndUpdateIfHighestBid(Bid bid)
        {
            var bidDb = mapper.Map<BidDb>(bid);

            var auctionDb = bidDb.Auction ?? context.Set<AuctionDb>().Find(bidDb.AuctionId);
            if (auctionDb?.HighestBid == null || auctionDb.HighestBid.Equals(bidDb))
            {
                auctionDb.HighestBid = mapper.Map<BidDb>(GetHighestBidForAuction(auctionDb.Id));
            }
            Delete(bid);
        }

        public void DeleteBidsForAuction(int auctionId)
        {
            List<Bid> bidsToDelete = (List<Bid>)Find(filter: b => b.AuctionId == auctionId);
            var auctionDb = context.Set<AuctionDb>().Find(auctionId);
            foreach (var bid in bidsToDelete)
            {
                var bdb = mapper.Map<BidDb>(bid);
                if ( bdb == auctionDb?.HighestBid)
                {
                    auctionDb.HighestBid = null;
                    context.Set<AuctionDb>().Update(auctionDb);
                }
                Delete(bid);
            }
        }
    }
}
