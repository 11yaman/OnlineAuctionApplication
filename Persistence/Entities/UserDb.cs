using Microsoft.EntityFrameworkCore;
using OnlineAuctionApplication.Core.Models;
using OnlineAuctionApplication.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace OnlineAuctionApplication.Persistence.Entities
{
    [Index(nameof(UserDb.Username), IsUnique = true)]
    public class UserDb
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string Username { get; set; }

        public List<AuctionDb> AuctionDbs { get; set; } = new List<AuctionDb>();
        public List<BidDb> BidDbs { get; set; } = new List<BidDb>();


        public override string? ToString()
        {
            return $"User ID: {Id}, Username: {Username}";
        }

    }
}
