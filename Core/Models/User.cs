namespace OnlineAuctionApplication.Core.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string? UserRole { get; set; }

        public User(string id, string username, string userRole)
        {
            Id = id;
            Username = username;
            UserRole = userRole ?? "User";
        }

        public override string? ToString()
        {
            return $"User ID: {Id}, Username: {Username}, UserRole: {UserRole}";
        }
    }
}
