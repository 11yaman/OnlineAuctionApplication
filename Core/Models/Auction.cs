namespace OnlineAuctionApplication.Core.Models
{
    public class Auction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public double StartingPrice { get; set; }
        public DateTime EndTime { get; set; }
        public string SellerId { get; set; }

        private List<Bid> bids = new List<Bid>();
        public IEnumerable<Bid> Bids => bids;

        public Auction(int id, string name, string description, double startingPrice, DateTime endTime)
        {
            Id = id;
            Name = name;
            Description = description;
            StartingPrice = startingPrice;
            EndTime = endTime;
        }

        public Auction(string name, string description, double startingPrice, DateTime endTime, string sellerId)
        {
            Name = name;
            Description = description;
            StartingPrice = startingPrice;
            EndTime = endTime;
            SellerId = sellerId;
        }
    }
}
