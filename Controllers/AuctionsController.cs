using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineAuctionApplication.Core.Models;
using OnlineAuctionApplication.Core.Services;
using OnlineAuctionApplication.ViewModels;

namespace OnlineAuctionApplication.Controllers
{
    public class AuctionsController : Controller
    {
        private readonly IAuctionService auctionService;
        private readonly IMapper mapper;

        public AuctionsController(IAuctionService auctionService, IMapper mapper)
        {
            this.auctionService = auctionService;
            this.mapper = mapper;
        }


        // GET: AuctionsController
        public ActionResult Index()
        {
            List<Auction> auctions = auctionService.GetOngoingAuctions();
            List<AuctionVM> auctionVMs = new List<AuctionVM>();
            foreach (var a in auctions)
            {
                auctionVMs.Add(mapper.Map<AuctionVM>(a));
            }
            return View(auctionVMs);
        }

        // GET: AuctionsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AuctionsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuctionsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuctionsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AuctionsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuctionsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AuctionsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
