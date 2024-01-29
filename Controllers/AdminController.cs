using Jop_Portal.Data;
using Jop_Portal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Composition;

namespace Jop_Portal.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;
        public AdminController(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var Offers = _dbContext.Offers.Where(o => !o.Active).OrderByDescending(p => p.CreatedAt).ToList();

            return View(Offers);
        }

     

        public IActionResult ReportsHome()
        {
            var account = _dbContext.Account.Where(a=>a.Reports!=0).OrderByDescending(a=> a.Reports);

            return View(account);
        }
        [HttpGet]
        public IActionResult ConfirmPage(int id)
        {
            var offer = _dbContext.Offers.SingleOrDefault(o => o.Id == id);
            ViewData["offer"] = offer;
            ViewData["account"] = _dbContext.Account.SingleOrDefault(a => a.Id == offer.UserId);
            return View("OfferConfirm");
        }

        [HttpPost]
        public IActionResult Confirm(int id)
        {
            var offer = _dbContext.Offers.SingleOrDefault(o => o.Id==id);
            offer.Active = true;
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }

        [HttpPost]
        public async Task<IActionResult> Block(string id)
        {
            var offers = await _dbContext.Offers
         .Where(o => o.UserId == id)
            .ToListAsync();

            OffersController obj =new OffersController(_dbContext,_userManager);
            foreach (var offer in offers)
                await obj.DeleteConfirmed(offer.Id);

            var reports = await _dbContext.Reports
    .Where(o => o.ReportedUserId == id)
    .ToListAsync();

            ReportsController obj2 = new ReportsController(_dbContext, _userManager);
            foreach (var report in reports)
                await obj2.DeleteConfirmed(report.Id);
            BlockedEmails email = new BlockedEmails();
            email.id = id;
            email.Email = _dbContext.Users.SingleOrDefault(u=>u.Id==id).Email;
            _dbContext.Add(email);
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var product = _dbContext.Offers.SingleOrDefault(p => p.Id == id);
            _dbContext.Offers.Remove(product);
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }
    }
}
