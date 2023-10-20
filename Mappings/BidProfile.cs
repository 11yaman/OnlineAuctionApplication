
using AutoMapper;
using OnlineAuctionApplication.Core.Models;
using OnlineAuctionApplication.Persistence.Entities;
using OnlineAuctionApplication.ViewModels;

namespace OnlineAuctionApplication.Mappings
{
    public class BidProfile : Profile
    {
        public BidProfile()
        {
            CreateMap<BidDb, Bid>().ForMember(dest => dest.Bidder, src => src.MapFrom(src => src.Bidder));
            CreateMap<BidVM, Bid>().ForMember(dest => dest.Bidder, src => src.MapFrom(src => src.BidderVM));
            CreateMap<Bid, BidDb>().ForMember(dest => dest.Bidder, src => src.MapFrom(src => src.Bidder));
            CreateMap<Bid, BidVM>().ForMember(dest => dest.BidderVM, src => src.MapFrom(src => src.Bidder));
        }
    }
}
