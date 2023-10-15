using OnlineAuctionApplication.Core.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineAuctionApplication.Persistence.Entities
{
    public class BidDb
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public double BidAmount { get; set; }

        [ForeignKey("BidderId")]
        public UserDb Bidder { get; set; }
        public String BidderId { get; set; }

        [ForeignKey("AuctionId")]
        public AuctionDb Auction { get; set; }
        public int AuctionId { get; set; } 

    }
}
