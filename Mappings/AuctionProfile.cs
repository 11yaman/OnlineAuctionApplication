using AutoMapper;
using OnlineAuctionApplication.Core.Models;
using OnlineAuctionApplication.Persistence.Entities;
using OnlineAuctionApplication.ViewModels;

namespace OnlineAuctionApplication.Mappings
{
    public class AuctionProfile : Profile
    {
        public AuctionProfile()
        {
            CreateMap<Auction, AuctionDb>().ForMember(dest => dest.HighestBid, src => src.MapFrom(src => src.HighestBid));
            CreateMap<AuctionDb, Auction>().ForMember(dest => dest.HighestBid, src => src.MapFrom(src => src.HighestBid));
            CreateMap<Auction, AuctionVM>().ForMember(dest => dest.HighestBid, src => src.MapFrom(src => src.HighestBid));
            CreateMap<AuctionVM, Auction>();
        }
    }
}
