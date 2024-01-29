using Jop_Portal.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Jop_Portal.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public AdminController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var Offers = _dbContext.Offers.Where(o => !o.Active).OrderByDescending(p => p.CreatedAt).ToList();

            return View(Offers);
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
        public IActionResult Delete(int id)
        {
            var product = _dbContext.Offers.SingleOrDefault(p => p.Id == id);
            _dbContext.Offers.Remove(product);
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }
    }
}
