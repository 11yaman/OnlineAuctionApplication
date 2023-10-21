using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineAuctionApplication.Areas.Identity.Data;
using OnlineAuctionApplication.Core.Models;
using OnlineAuctionApplication.Core.Services;
using OnlineAuctionApplication.Persistence.Entities;
using OnlineAuctionApplication.ViewModels;

namespace OnlineAuctionApplication.Controllers
{
    [Route("Auction/{auctionId}/[action]")]
    public class BidsController : Controller
    {
        private readonly IBidService bidService;
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationIdentityUser> userManager;

        public BidsController(IBidService bidService,
            IMapper mapper, UserManager<ApplicationIdentityUser> userManager)
        {
            this.bidService = bidService;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        // GET: Auctions/{auctionId}/Bids
        public ActionResult ListBids(int auctionId)
        {
            try
            {
                var bids = bidService.GetOngoingAuctionBids(auctionId);
                var vms = new List<BidVM>();
                foreach (var b in bids)
                {
                    var bvm = mapper.Map<BidVM>(b);
                    vms.Add(bvm);
                }
                return View(vms);
            } 
            catch (Exception)
            {
                return Forbid();
            }
        }


        // GET: Auctions/{auctionId}/Bids/MakeBid
        public ActionResult MakeBid(int auctionId)
        {
            return View();
        }

        // POST: Auctions/{auctionId}/MakeBid
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MakeBid(int auctionId, MakeBidVM vm)
        {
            var inloggedUser = userManager.FindByNameAsync(User.Identity.Name).Result;

            if (ModelState.IsValid)
            {
                Bid bid = new(vm.Amount, DateTime.Now ,vm.AuctionId, inloggedUser.Id);
                try
                {
                    bidService.MakeBid(bid);
                    return RedirectToAction("ListBids", new { auctionId = vm.AuctionId });
                }
                catch (InvalidOperationException e)
                {
                    return Forbid();
                }
            }
            return View(vm);
        }
    }
}
