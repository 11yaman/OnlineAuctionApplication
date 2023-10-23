using OnlineAuctionApplication.Core.Models;
using OnlineAuctionApplication.Persistence.Repositories;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineAuctionApplication.Persistence.Entities
{
    public class AuctionDb
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(256)]
        public string Description { get; set; }
        [Required]
        public double StartingPrice { get; set; }
        [Required]
        public DateTime EndTime { get; set; }

        [InverseProperty("Auction")]
        public List<BidDb> BidDbs { get; set; } = new List<BidDb>();

        [ForeignKey("SellerId")]
        public UserDb Seller { get; set; }
        public String SellerId { get; set; }

        [ForeignKey("HighestBidId")]
        public BidDb? HighestBid { get; set; }
        public int? HighestBidId { get; set; }

        public override string? ToString()
        {
            return $"ID: {Id}, Name: {Name}, Description: {Description}, " +
                $"StartingPrice: {StartingPrice}, EndTime: {EndTime}";
        }

    }
}