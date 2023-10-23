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
            UserDb user1 = new() { Id = "-1", Username = "user1", UserRole = "User" };
            UserDb user2 = new() { Id = "-2", Username = "user2", UserRole = "User" };

            modelBuilder.Entity<UserDb>()
                .HasMany(u => u.BidDbs)
                .WithOne(b => b.Bidder)
                .HasForeignKey(b => b.BidderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserDb>()
                .HasData(user1, user2);

            AuctionDb auction1 = new()
            {
                Id = -1,
                Name = "Auction 1",
                Description = "Description for Auction 1",
                StartingPrice = 100.0,
                EndTime = DateTime.Now.AddHours(24),
                SellerId = "-1",
                HighestBidId = null
            };

            AuctionDb auction2 = new()
            {
                Id = -2,
                Name = "Auction 2",
                Description = "Description for Auction 2",
                StartingPrice = 50.0,
                EndTime = DateTime.Now.AddHours(48),
                SellerId = "-2",
                HighestBidId = null
            };

            modelBuilder.Entity<AuctionDb>()
                .HasOne(a => a.Seller)
                .WithMany(seller => seller.AuctionDbs)
                .HasForeignKey(a => a.SellerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AuctionDb>()
                .HasData(auction1, auction2);


            BidDb bid1 = new()
            {
                Id = -1,
                Amount = 120.0,
                BidderId = "-2",
                AuctionId = -1 
            };

            BidDb bid2 = new()
            {
                Id = -2,
                Amount = 60.0,
                BidderId = "-1",
                AuctionId = -2
            };

            modelBuilder.Entity<BidDb>()
                .HasOne(bid => bid.Bidder)
                .WithMany(bidder => bidder.BidDbs)
                .HasForeignKey(bid => bid.BidderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BidDb>()
                .HasOne(bid => bid.Auction)
                .WithMany(a => a.BidDbs)
                .HasForeignKey(bid => bid.AuctionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BidDb>()
                .HasData(bid1, bid2);
        }
    }
}
