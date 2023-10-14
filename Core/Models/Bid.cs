﻿namespace OnlineAuctionApplication.Core.Models
{
    public class Bid
    {
        public int Id { get; set; }

        //auction/auctionId

        public User Bidder { get; set; }
        public double BidAmount { get; set; }

        public Bid(int id, User bidder, double bidAmount)
        {
            Id = id;
            Bidder = bidder;
            BidAmount = bidAmount;
        }

        //Mappings constructor
        public Bid(int id, double bidAmount)
        {
            Id = id;
            BidAmount = bidAmount;
        }
    }
}