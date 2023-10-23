using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineAuctionApplication.Areas.Identity.Data;
using OnlineAuctionApplication.Core.Services;
using OnlineAuctionApplication.Persistence.Repositories;
using OnlineAuctionApplication.ViewModels;
using System.Transactions;

namespace OnlineAuctionApplication.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationIdentityUser> userManager;
        private readonly IAuctionService auctionService;
        private readonly IBidService bidService;
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public AdminController(UserManager<ApplicationIdentityUser> userManager, IAuctionService auctionService,
            IUserService userService, IBidService bidService, IMapper mapper)
        {
            this.userManager = userManager;
            this.auctionService = auctionService;
            this.userService = userService;
            this.bidService = bidService;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListUsers()
        {
            var users = userService.GetAllUsers();

            var userVMs = new List<UserVM>();
            foreach (var u in users)
            {
                userVMs.Add(mapper.Map<UserVM>(u));
            }
            return View(userVMs);
        }

        public IActionResult ListAuctions(string userId)
        {
            var auctions = auctionService.GetAuctionsBySeller(userId);
            List<AuctionVM> auctionVMs = new();
            foreach (var a in auctions)
            {
                auctionVMs.Add(mapper.Map<AuctionVM>(a));
            }
            return View(auctionVMs);
        }

        public ActionResult ListBids(int auctionId)
        {
            try
            {
                var bids = bidService.GetBidsForAuction(auctionId);
                var vms = new List<BidVM>();
                foreach (var b in bids)
                {
                    var bvm = mapper.Map<BidVM>(b);
                    vms.Add(bvm);
                }
                return View(vms);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }
        public IActionResult DeleteUser(string userId)
        {
            var identityUser = userManager.Users.FirstOrDefault(u => u.Id == userId);

            if (identityUser != null)
            {
                var result = userManager.DeleteAsync(identityUser).Result;

                if (!result.Succeeded)
                {
                    return NotFound();

                }
            }
            userService.DeleteUser(userId);
            return RedirectToAction("ListUsers");
            
        }


        public IActionResult DeleteAuction(int auctionId)
        {
            var auction = auctionService.GetAuctionById(auctionId);
            if (auction != null)
            {
                auctionService.DeleteAuction(auctionId);
                return RedirectToAction("ListAuctions", new { userId = auction.SellerId });
            }
            return NotFound();
        }
    }
}