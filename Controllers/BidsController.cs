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
    [Route("Auctions/{auctionId}/[controller]/[action]")]
    public class BidsController : Controller
    {
        private readonly IBidService bidService;
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationIdentityUser> userManager;

        public BidsController(IBidService bidService, IMapper mapper, UserManager<ApplicationIdentityUser> userManager)
        {
            this.bidService = bidService;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        // GET: Auctions/5/Bids/ListBids
        public ActionResult ListBids(int auctionId)
        {
            var bids = bidService.GetBidList(auctionId);
            var vms = new List<BidVM>();
            foreach (var b in bids)
            {
                var bvm = mapper.Map<BidVM>(b);
                vms.Add(bvm);
            }
            return View(vms);
        }


        // GET: Auctions/5/Bids/MakeBid
        public ActionResult MakeBid()
        {
            return View();
        }

        // POST: Auctions/5/Bids/MakeBid
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MakeBid(MakeBidVM vm)
        {
            var inloggedUser = userManager.FindByNameAsync(User.Identity.Name).Result;

            if (ModelState.IsValid)
            {
                Bid bid = new(vm.Amount, DateTime.Now ,vm.AuctionId, inloggedUser.Id);
                try
                {
                    bidService.MakeBid(bid);
                } catch (Exception)
                {
                    return View(vm);
                }
                return RedirectToAction("ListBids", new { auctionId = vm.AuctionId });
            }
            return View(vm);
        }
    }
}
