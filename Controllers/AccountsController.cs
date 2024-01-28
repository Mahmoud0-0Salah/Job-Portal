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
    public class AccountsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly UserManager<IdentityUser> _userManager;

        public AccountsController(ApplicationDbContext context, IWebHostEnvironment hostingEnvironment, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
            _userManager = userManager;
        }


        // GET: Accounts
        public async Task<IActionResult> Index()
        {
              return _context.Account != null ? 
                          View(await _context.Account.ToListAsync()) :
                          Problem("Entity set 'Jop_PortalContext.Account'  is null.");
        }

        // GET: Accounts/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Account == null)
            {
                return NotFound();
            }
            var offers= _context.Offers.Where(o => (o.Active &&o.UserId==id));
            var account =  _context.Account
                .SingleOrDefault(m => m.Id == id);
            ViewData["Name"] = account.Name;
            ViewData["Photo"] = account.Photo;
            ViewData["About"] = account.About;
            ViewData["UserId"] =account.Id;
            ViewData["Id"] = _userManager.GetUserId(User);
            return View(offers);
        }

        // GET: Accounts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IdentityUser user, string name, IFormFile photo,string?About)
        {
            Account account = new Account();
            if (photo != null && photo.Length > 0)
            {
                // Get the wwwroot path
                string uploadPath = Path.Combine(_hostingEnvironment.WebRootPath, "imj");
                Directory.CreateDirectory(uploadPath);

                // Generate a unique filename for the uploaded file
                string newfilename = $"{Guid.NewGuid().ToString()}{Path.GetExtension(photo.FileName)}";
                string fileName = Path.Combine(uploadPath, newfilename);

                // Save the file to the server
                using (var fileStream = new FileStream(fileName, FileMode.Create))
                {
                    photo.CopyTo(fileStream);
                }
                account.Photo = $"/imj/{newfilename}";
            }
            else
                account.Photo = "/imj/default.jpg";
            // Optionally, save the file path to a database or return it to the user
            account.Id = user.Id;
            account.Name = name;
            account.Reports =0;
            account.About =About;
            if (ModelState.IsValid)
            {
                _context.Add(account);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }

        // GET: Accounts/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Account == null)
            {
                return NotFound();
            }

            var account = await _context.Account.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,Photo,Reports")] Account account)
        {
            if (id != account.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(account);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountExists(account.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }

        // GET: Accounts/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Account == null)
            {
                return NotFound();
            }

            var account = await _context.Account
                .FirstOrDefaultAsync(m => m.Id == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Account == null)
            {
                return Problem("Entity set 'Jop_PortalContext.Account'  is null.");
            }
            var account = await _context.Account.FindAsync(id);
            if (account != null)
            {
                _context.Account.Remove(account);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountExists(string id)
        {
          return (_context.Account?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
