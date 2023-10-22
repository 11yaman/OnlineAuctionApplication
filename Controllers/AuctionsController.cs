using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineAuctionApplication.Areas.Identity.Data;
using OnlineAuctionApplication.Core.Models;
using OnlineAuctionApplication.Core.Services;
using OnlineAuctionApplication.ViewModels;

namespace OnlineAuctionApplication.Controllers
{
    [Authorize]
    public class AuctionsController : Controller
    {
        private readonly IAuctionService auctionService;
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationIdentityUser> userManager;

        public AuctionsController(IAuctionService auctionService, IMapper mapper, UserManager<ApplicationIdentityUser> userManager)
        {
            this.auctionService = auctionService;
            this.mapper = mapper;
            this.userManager = userManager;
        }
        

        // GET: AuctionsController
        [Route("[controller]")]
        public ActionResult AllAuctions()
        {
            var auctions = auctionService.GetAllOngoingAuctions();
            List<AuctionVM> auctionVMs = new List<AuctionVM>();
            foreach (var a in auctions)
            {
                auctionVMs.Add(mapper.Map<AuctionVM>(a));
            }
            return View(auctionVMs);
        }
    }
}