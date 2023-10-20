using AutoMapper;
using OnlineAuctionApplication.Core.Models;
using OnlineAuctionApplication.Persistence.Entities;
using OnlineAuctionApplication.ViewModels;

namespace OnlineAuctionApplication.Persistence.Repositories
{
    public class AuctionRepository : IAuctionRepository
    {

        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public AuctionRepository(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void CreateAuction(Auction auction)
        {
            AuctionDb auctionDb = mapper.Map<AuctionDb>(auction);
            auctionDb.SellerId = auction.SellerId;

            context.AuctionDbs.Add(auctionDb);
            context.SaveChanges(); 
        }

        public Auction GetAuctionById(int auctionId)
        {
            var auctionDb = context.AuctionDbs.FirstOrDefault(a => a.Id == auctionId);
            return mapper.Map<Auction>(auctionDb);        
        }

        public List<Auction> GetOngoingAuctions()
        {
            List<AuctionDb> auctionDbs = context.AuctionDbs
                .Where(adb => adb.EndTime > DateTime.Now)
                .OrderBy(adb => adb.EndTime)
                .ToList();
            List<Auction> auctions = new();
            foreach (var adb in  auctionDbs) { 
                auctions.Add(mapper.Map<Auction>(adb));
            }
            return auctions;
        }

        public void UpdateDescription(int auctionId, string newDescription)
        {
            var auctionDb = context.AuctionDbs.SingleOrDefault(a => a.Id == auctionId);

            if (auctionDb != null)
            {
                auctionDb.Description = newDescription;
                context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Auction not found.");
            }
        }
    }
}
