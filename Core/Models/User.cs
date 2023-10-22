namespace OnlineAuctionApplication.Core.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Username { get; set; }

        public User(string id, string username)
        {
            Id = id;
            Username = username;
        }

        public override string? ToString()
        {
            return $"User ID: {Id}, Username: {Username}";
        }
    }
}
