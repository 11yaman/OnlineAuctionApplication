
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
            CreateMap<BidDb, Bid>().ReverseMap();
            CreateMap<BidVM, Bid>().ReverseMap();
        }
    }
}
