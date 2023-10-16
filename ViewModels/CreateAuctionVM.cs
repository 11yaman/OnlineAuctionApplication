namespace OnlineAuctionApplication.ViewModels
{
    public class CreateAuctionVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double StartingPrice { get; set; }
        public DateTime EndTime { get; set; }
    }
}