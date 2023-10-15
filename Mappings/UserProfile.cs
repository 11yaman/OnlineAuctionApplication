using AutoMapper;
using OnlineAuctionApplication.Core.Models;
using OnlineAuctionApplication.Persistence.Entities;
using OnlineAuctionApplication.ViewModels;

namespace OnlineAuctionApplication.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDb, User>().ReverseMap();
            CreateMap<UserVM, User>().ReverseMap();
        }
    }
}
