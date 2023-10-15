using OnlineAuctionApplication.Core.Models;

namespace OnlineAuctionApplication.ViewModels
{
    public class BidVM
    {
        public int Id { get; set; }
        public UserVM BidderVM { get; set; }
        public double BidAmount { get; set; }
    }
}
