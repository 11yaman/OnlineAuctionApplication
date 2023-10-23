using OnlineAuctionApplication.Core.Models;

namespace OnlineAuctionApplication.ViewModels
{
    public class UserVM
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string UserRole { get; set; }

        public List<AuctionVM> AuctionVMs = new List<AuctionVM>();

        public override string? ToString()
        {
            return $"User ID: {Id}, Username: {Username}, UserRole: {UserRole}";
        }
    }
}
