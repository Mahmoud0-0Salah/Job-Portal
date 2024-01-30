using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Jop_Portal.Data;
using Jop_Portal.Models;
using Microsoft.AspNetCore.Identity;

namespace Jop_Portal.Controllers
{
    public class OffersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public OffersController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Offers
        public async Task<IActionResult> Index(string id)
        {
            var applicationDbContext = _context.Offers.Where(o => o.UserId==id);
            return View(applicationDbContext.ToList());
        }

    
        // GET: Offers/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Offers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,JobTittle,Photo,Description,Available,Active,CreatedAt,UserId")] Offers offers)
        {
                
                var file = HttpContext.Request.Form.Files;
                    string imageName = Guid.NewGuid().ToString() + Path.GetExtension(file[0].FileName);
                    var filePath = Path.Combine("wwwroot", "imj", imageName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file[0].CopyTo(fileStream); // Save in the Images folder
                    }

                offers.Photo = $"/imj/{imageName}"; // Save in the database
                offers.Active = false;
                offers.CreatedAt = DateTime.Now;
                offers.UserId = _userManager.GetUserId(User);
                var user = _context.Account.SingleOrDefault(a => a.Id == offers.UserId);
                offers.UserName = user.Name;
                offers.UserPhoto = user.Photo;
                 _context.Add(offers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { id = _userManager.GetUserId(User) });
        }
        // GET: Offers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Offers == null)
            {
                return NotFound();
            }

            var offers = await _context.Offers
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (offers == null)
            {
                return NotFound();
            }

            return View(offers);
        }

        // POST: Offers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Offers == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Offers'  is null.");
            }
            var offers = await _context.Offers.FindAsync(id);
            if (offers != null)
            {
                _context.Offers.Remove(offers);
            }
            
            await _context.SaveChangesAsync();
            if (User==null || User.IsInRole("Admin"))
                return RedirectToAction("Index", "Admin");
            return RedirectToAction(nameof(Index), new { id = _userManager.GetUserId(User) });
        }

        private bool OffersExists(int id)
        {
          return (_context.Offers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
