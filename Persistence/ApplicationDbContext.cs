using Microsoft.EntityFrameworkCore;
using OnlineAuctionApplication.Persistence.Entities;
using System.Threading.Tasks;

namespace OnlineAuctionApplication.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<AuctionDb> AuctionDbs { get; set; }
        public DbSet<BidDb> BidDbs { get; set; }
        public DbSet<UserDb> UserDbs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            UserDb user1 = new UserDb { Id = "-1", Username = "user1"  };
            UserDb user2 = new UserDb { Id = "-2", Username = "user2" };

            modelBuilder.Entity<UserDb>()
                .HasData(user1, user2);

            AuctionDb auction1 = new AuctionDb
            {
                Id = -1,
                Name = "Auction 1",
                Description = "Description for Auction 1",
                StartingPrice = 100.0,
                EndTime = DateTime.Now.AddHours(24),
                SellerId = "-1"
            };

            AuctionDb auction2 = new AuctionDb 
            {
                Id = -2,
                Name = "Auction 2",
                Description = "Description for Auction 2",
                StartingPrice = 50.0,
                EndTime = DateTime.Now.AddHours(48),
                SellerId = "-2"
            };

            modelBuilder.Entity<AuctionDb>()
                .HasData(auction1, auction2);

            BidDb bid1 = new BidDb
            {
                Id = -1,
                BidAmount = 120.0,
                BidderId = "-2",
                AuctionId = -1 
            };

            BidDb bid2 = new BidDb
            {
                Id = -2,
                BidAmount = 60.0,
                BidderId = "-1",
                AuctionId = -2 
            };

            modelBuilder.Entity<BidDb>()
                .HasOne(bid => bid.Bidder)
                .WithMany(bidder => bidder.BidDbs)
                .HasForeignKey(bid => bid.BidderId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<BidDb>().HasData(bid1, bid2);
        }
    }
}
