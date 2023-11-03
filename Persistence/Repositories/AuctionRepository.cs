using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineAuctionApplication.Core.Models;
using OnlineAuctionApplication.Persistence.Entities;
using OnlineAuctionApplication.ViewModels;

namespace OnlineAuctionApplication.Persistence.Repositories
{
    public class AuctionRepository : GenericRepository<AuctionDb, Auction>, IAuctionRepository
    {
        public AuctionRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public IEnumerable<Auction> GetAllOngoingAuctions()
        {
            List<AuctionDb> auctionDbs = dbSet
                .Where(adb => adb.EndTime > DateTime.Now)
                .OrderBy(adb => adb.EndTime)
                .ToList();
            List<Auction> auctions = new();
            foreach (var adb in auctionDbs) { 
                auctions.Add(mapper.Map<Auction>(adb));
            }
            return auctions;
        }

        public IEnumerable<Auction> GetAuctionsBySeller(string sellerId)
        {
            List<AuctionDb> auctionDbs = dbSet
                .Where(adb => adb.SellerId == sellerId)
                .OrderByDescending(adb => adb.EndTime)
                .ToList();
            List<Auction> auctions = new();
            foreach (var adb in auctionDbs)
            {
                auctions.Add(mapper.Map<Auction>(adb));
            }
            return auctions;
        }

        public IEnumerable<Auction> GetWonAuctionsByBidder(string bidderId)
        {
            var wonAuctions = dbSet
                .Where(adb => adb.EndTime < DateTime.Now)
                .Where(adb => adb.HighestBid != null && adb.HighestBid.BidderId== bidderId)
                .Include(adb => adb.HighestBid)
                .OrderByDescending(adb => adb.EndTime)
                .ToList();

            List<Auction> auctions = new();
            foreach (var adb in wonAuctions)
            {
                auctions.Add(mapper.Map<Auction>(adb));
            }
            return auctions;
        }

        public IEnumerable<Auction> GetOngoingAuctionsByBidder(string userId)
        {
            var ongoingAuctions = dbSet
                        .Where(adb => adb.EndTime > DateTime.Now)
                        .Where(adb => adb.BidDbs.Any(bid => bid.BidderId == userId))
                        .Include(adb => adb.HighestBid)
                        .OrderByDescending(adb => adb.EndTime)
                        .ToList();

            List<Auction> auctions = new();
            foreach (var adb in ongoingAuctions)
            {
                auctions.Add(mapper.Map<Auction>(adb));
            }
            return auctions;
        }

        public void UpdateDescription(int auctionId, string newDescription)
        {
            var auctionDb = dbSet.SingleOrDefault(a => a.Id == auctionId);

            if (auctionDb != null)
                auctionDb.Description = newDescription;
            else
                throw new InvalidOperationException("Auction not found.");
        }
    }
}
