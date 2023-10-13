using OnlineAuctionSystem.Core.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineAuctionSystem.Persistence.Entities
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

        public List<Bid> BidDbs = new List<Bid>();

        [ForeignKey("SellerId")]
        public UserDb SellerDb { get; set; }
        public int SellerId { get; set; }


    }
}
