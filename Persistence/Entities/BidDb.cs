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
        public double Amount { get; set; }

        [Required]
        public DateTime TimeCreated { get; set; }

        [ForeignKey("BidderId")]
        public UserDb Bidder { get; set; }
        public string BidderId { get; set; }

        [ForeignKey("AuctionId")]
        public AuctionDb Auction { get; set; }
        public int AuctionId { get; set; }

        public override string? ToString()
        {
            return $"Bid ID: {Id}, Amount: {Amount}, Auction ID: {AuctionId}, " +
                $"Bidder ID: {BidderId}";
        }

    }
}
