namespace OnlineAuctionApplication.ViewModels
{
    public class AuctionVM
    {
        public int Id { get;}
        public string Name { get; }
        public string Description { get; }
        public double StartingPrice { get; }
        public BidVM HighestBid { get; }
        public DateTime EndTime { get; }

        public AuctionVM(int id, string name, string description, double startingPrice, BidVM highestBid, DateTime endTime)
        {
            Id = id;
            Name = name;
            Description = description;
            StartingPrice = startingPrice;
            HighestBid = highestBid;
            EndTime = endTime;
        }

        public override string? ToString()
        {
            return $"ID: {Id}, Name: {Name}, Description: {Description}, " +
                $"StartingPrice: {StartingPrice}, EndTime: {EndTime}";
        }

    }
}
