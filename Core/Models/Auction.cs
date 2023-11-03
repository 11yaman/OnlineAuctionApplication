using OnlineAuctionApplication.Persistence.Repositories;

namespace OnlineAuctionApplication.Core.Models
{
    public class Auction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public double StartingPrice { get; set; }
        public DateTime EndTime { get; set; }
        public User Seller { get; set; }
        public string SellerId { get; set; }
        private readonly List<Bid> bids = new();
        public IEnumerable<Bid> Bids => bids;
        public Bid? HighestBid { get; set; } = null;

        public Auction(int id, string name, string description, double startingPrice, DateTime endTime, string sellerId)
        {
            Id = id;
            Name = name;
            Description = description;
            StartingPrice = startingPrice;
            EndTime = endTime;
            SellerId = sellerId;
        }

        public Auction(string name, string description, double startingPrice, DateTime endTime, string sellerId)
        {
            Name = name;
            Description = description;
            StartingPrice = startingPrice;
            EndTime = endTime;
            SellerId = sellerId;
        }

        public override string? ToString()
        {
            return $"Auction ID: {Id}, Name: {Name}, Description: {Description}, SellerId : {SellerId}";
        }
    }
}
