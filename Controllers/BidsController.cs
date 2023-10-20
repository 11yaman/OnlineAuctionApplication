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
    [Route("Auctions/[controller]/[action]/{auctionId}")]
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

        // GET: Auctions/ListBids/{auctionId}
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
            } catch (Exception)
            {
                return NotFound();
            }
        }


        // GET: Auctions/MakeBid/{auctionId}
        public ActionResult MakeBid(int auctionId)
        {
            return View();
        }

        // POST: Auctions/MakeBid/{auctionId}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MakeBid(int auctionId, MakeBidVM vm)
        {
            var inloggedUser = userManager.FindByNameAsync(User.Identity.Name).Result;

            if (ModelState.IsValid)
            {
                Bid bid = new(vm.Amount, DateTime.Now ,vm.AuctionId, inloggedUser.Id);
                Console.WriteLine(bid.AuctionId +" " + bid.Amount);
                try
                {
                    bidService.MakeBid(bid);
                    return RedirectToAction("ListBids", new { auctionId = vm.AuctionId });
                }
                catch (InvalidOperationException)
                {
                }
            }
            return View(vm);
        }
    }
}
