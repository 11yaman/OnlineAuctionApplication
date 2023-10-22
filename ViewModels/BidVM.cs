namespace OnlineAuctionApplication.ViewModels
{
    public class BidVM
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public DateTime TimeCreated { get; set; } 
        public int AuctionId { get; set; }
        public string BidderId { get; set; }
        public UserVM Bidder { get; set; }

        public override string? ToString()
        {
            return $"Bid ID: {Id}, Amount: {Amount}, Auction ID: {AuctionId}, " +
                $"Bidder ID: {BidderId}";
        }
    }
}
