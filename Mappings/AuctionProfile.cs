using AutoMapper;
using OnlineAuctionApplication.Core.Models;
using OnlineAuctionApplication.Persistence.Entities;
using OnlineAuctionApplication.ViewModels;

namespace OnlineAuctionApplication.Mappings
{
    public class AuctionProfile : Profile
    {
        //TODO: Make mapping for User and bind Auction, Bid and user together
        public AuctionProfile()
        {
            CreateMap<AuctionDb, Auction>().ReverseMap();
            CreateMap<AuctionVM, Auction>().ReverseMap();
        }
    }
}
