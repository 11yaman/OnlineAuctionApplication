using AutoMapper;
using OnlineAuctionSystem.Core.Models;
using OnlineAuctionSystem.Persistence.Entities;
using OnlineAuctionSystem.ViewModels;

namespace OnlineAuctionSystem.Mappings
{
    public class AuctionProfile : Profile
    {
        public AuctionProfile()
        {
            CreateMap<AuctionDb, Auction>().ReverseMap();
            CreateMap<AuctionVM, Auction>().ReverseMap();
        }
    }
}
