namespace OnlineAuctionApplication.Core.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Username { get; set; }

        private List<Auction> auctions = new List<Auction>();
        public IEnumerable<Auction> Auctions => auctions;

        public User(string id, string username)
        {
            Id = id;
            Username = username;
        }
    }
}
