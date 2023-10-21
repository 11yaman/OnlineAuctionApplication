namespace OnlineAuctionApplication.ViewModels
{
    public class AuctionVM
    {
        public int Id { get;}
        public string Name { get; }
        public string Description { get; }
        public double StartingPrice { get; }
        public double HighestAmount { get; }
        public DateTime EndTime { get; }

        public AuctionVM(int id, string name, string description, double startingPrice, DateTime endTime)
        {
            Id = id;
            Name = name;
            Description = description;
            StartingPrice = startingPrice;
            HighestAmount = startingPrice;
            EndTime = endTime;
        }
        public AuctionVM(int id, string name, string description, double startingPrice, double highestAmount, DateTime endTime)
        {
            Id = id;
            Name = name;
            Description = description;
            StartingPrice = startingPrice;
            HighestAmount = highestAmount;
            EndTime = endTime;
        }
    }
}
