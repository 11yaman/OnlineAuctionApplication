using Microsoft.EntityFrameworkCore;
using OnlineAuctionApplication.Core.Models;
using OnlineAuctionApplication.Persistence.Entities;

namespace OnlineAuctionApplication.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork 
    {
        private readonly ApplicationDbContext context;
        public IAuctionRepository Auctions { get; }
        public IBidRepository Bids { get; }

        public UnitOfWork(ApplicationDbContext context,
            IAuctionRepository auctionRepository,
            IBidRepository bidRepository)
        {
            this.context = context;
            Auctions = auctionRepository;
            Bids = bidRepository;
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
