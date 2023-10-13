using AutoMapper;
using OnlineAuctionSystem.Core.Models;
using OnlineAuctionSystem.Persistence.Entities;

namespace OnlineAuctionSystem.Persistence.Repositories
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
            throw new NotImplementedException();
        }

        public List<Auction> GetOngoingAuctions()
        {
            List<AuctionDb> auctionDbs = context.AuctionDbs.Where(adb => adb.EndTime > DateTime.Now).ToList();
            List<Auction> auctions = new List<Auction>();
            foreach (var adb in  auctionDbs) { 
                auctions.Add(mapper.Map<Auction>(adb));
            }
            return auctions;
        }
    }
}
