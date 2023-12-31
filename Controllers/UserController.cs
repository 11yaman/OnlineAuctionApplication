﻿using AutoMapper;
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
    public class UserController : Controller
    {
        private readonly IAuctionService auctionService;
        private readonly IBidService bidService;
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationIdentityUser> userManager;

        public UserController(IAuctionService auctionService, IBidService bidService,
        IMapper mapper, UserManager<ApplicationIdentityUser> userManager)
        {
            this.auctionService = auctionService;
            this.bidService = bidService;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        // GET: UserController
        public ActionResult Index()
        {
            return View();
        }


        // GET: UserController/OwnAuctions
        public ActionResult OwnAuctions()
        {
            var inloggedUser = userManager.FindByNameAsync(User.Identity.Name).Result;

            var auctions = auctionService.GetAuctionsBySeller(inloggedUser.Id);
            List<AuctionVM> auctionVMs = new();
            foreach (var a in auctions)
            {
                auctionVMs.Add(mapper.Map<AuctionVM>(a));
            }
            return View(auctionVMs);
        }

        // GET: UserController/Bids/{auctionId}
        [Route("[controller]/Auction/{auctionId}/Bids")]
        public ActionResult ListBids(int auctionId)
        {
            var inloggedUser = userManager.FindByNameAsync(User.Identity.Name).Result;
            try
            {
                var bids = bidService.GetBidsForAuctionBySeller(inloggedUser.Id, auctionId);
                List<BidVM> vms = new();
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

        // GET: UserController/CreateAuction
        public ActionResult CreateAuction()
        {
            return View();
        }

        // POST: UserController/CreateAuction
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAuction(CreateAuctionVM vm)
        {
            var inloggedUser = userManager.FindByNameAsync(User.Identity.Name).Result;
            if (ModelState.IsValid)
            {
                Auction auction = new(vm.Name, vm.Description, vm.StartingPrice,
                    vm.EndTime, inloggedUser.Id);
                auctionService.CreateAuction(auction);
                return RedirectToAction("OwnAuctions");
            }
            return View(vm);
        }

        // GET: UserController/EditAuction/{auctionId}
        [Route("[controller]/[action]/{auctionId}")]
        public ActionResult EditAuction(int auctionId)
        {
            var inloggedUser = userManager.FindByNameAsync(User.Identity.Name).Result;
            var auction = auctionService.GetAuctionById(auctionId);

            if (auction.SellerId != inloggedUser.Id || auction.EndTime < DateTime.Now)
                return Forbid();

            return View(new EditAuctionVM
            {
                Description = auction.Description,
                AuctionId = auction.Id
            });
        }

        // POST: UserController/EditAuction/{auctionId}
        [Route("[controller]/[action]/{auctionId}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAuction(EditAuctionVM vm)
        {
            var inloggedUser = userManager.FindByNameAsync(User.Identity.Name).Result;
            try
            {
                auctionService.UpdateDescription(vm.AuctionId, vm.Description, inloggedUser.Id);
                return RedirectToAction("OwnAuctions");
            } catch (InvalidOperationException)
            {
                return Forbid();
            }

        }

        // GET: UserController/WonAuctions
        [Route("[controller]/WonAuctions")]
        public ActionResult WonAuctions(int auctionId)
        {
            var inloggedUser = userManager.FindByNameAsync(User.Identity.Name).Result;

            var auctions = auctionService.GetWonAuctionsByBidder(inloggedUser.Id);
            var vms = new List<AuctionVM>();
            foreach (var a in auctions)
            {
                var vm = mapper.Map<AuctionVM>(a);
                vms.Add(vm);
            }
            return View(vms);
        }


        // GET: UserController/WonAuctions
        [Route("[controller]/AuctionsWithUserBids")]
        public ActionResult AuctionsWithUserBids(int auctionId)
        {
            var inloggedUser = userManager.FindByNameAsync(User.Identity.Name).Result;

            var auctions = auctionService.GetOngoingAuctionsByBidder(inloggedUser.Id);
            var vms = new List<AuctionVM>();
            foreach (var a in auctions)
            {
                var vm = mapper.Map<AuctionVM>(a);
                vms.Add(vm);
            }
            return View(vms);
        }
    }
}
