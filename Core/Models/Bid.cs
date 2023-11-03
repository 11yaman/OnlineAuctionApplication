namespace OnlineAuctionApplication.Core.Models
{
    public class Bid
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public DateTime TimeCreated { get; set; }
        public int AuctionId { get; set; } 
        public string BidderId { get; set; }
        public User Bidder { get; set; }

        public Bid(int id, double amount, DateTime timeCreated, int auctionId, string bidderId)
        {
            Id = id;
            Amount = amount;
            TimeCreated = timeCreated;
            AuctionId = auctionId;
            BidderId = bidderId;
        }

        public Bid(double amount, DateTime timeCreated, int auctionId, string bidderId)
        {
            Amount = amount;
            TimeCreated = timeCreated;
            AuctionId = auctionId;
            BidderId = bidderId;
        }

        public override string? ToString()
        {
            return $"Bid ID: {Id}, Amount: {Amount}, Auction ID: {AuctionId}, Bidder ID: {BidderId}";
        }
    }
}
