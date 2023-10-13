namespace OnlineAuctionSystem.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }

        //Password

        private List<Auction> auctions = new List<Auction>();
        public IEnumerable<Auction> Auctions => auctions;

    }
}
