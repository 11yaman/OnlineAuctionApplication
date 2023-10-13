
using AutoMapper;
using OnlineAuctionSystem.Core.Models;
using OnlineAuctionSystem.Persistence.Entities;
using OnlineAuctionSystem.ViewModels;

namespace OnlineAuctionSystem.Mappings
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
