﻿using OnlineAuctionApplication.Core.Models;

namespace OnlineAuctionApplication.ViewModels
{
    public class UserVM
    {
        public string Id { get; set; }
        public string Username { get; set; }

        public List<AuctionVM> AuctionVMs = new List<AuctionVM>();
    }
}
