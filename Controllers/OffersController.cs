using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Jop_Portal.Data;
using Jop_Portal.Models;

namespace Jop_Portal.Controllers
{
    public class OffersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OffersController(ApplicationDbContext context)
        {
            _context = context;
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
            if (ModelState.IsValid)
            {
                _context.Add(offers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", offers.UserId);
            return View(offers);
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
            return RedirectToAction(nameof(Index));
        }

        private bool OffersExists(int id)
        {
          return (_context.Offers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
