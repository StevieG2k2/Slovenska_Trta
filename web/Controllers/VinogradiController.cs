using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using web.Data;
using web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace web.Controllers
{
    [Authorize]
    public class VinogradiController : Controller
    {
        private readonly TrtaContext _context;
        private readonly UserManager<ApplicationUser> _usermanager;

        public VinogradiController(TrtaContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _usermanager = userManager;
        }

        // GET: Vinogradi
        public async Task<IActionResult> Index(string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["TrteId"] = String.IsNullOrEmpty(sortOrder) ? "trteId_desc" : "";
            ViewData["StSort"] = sortOrder == "stSort"  ? "stSort_desc" : "stSort";
            ViewData["Povrsina"] = sortOrder == "povrsina" ? "povrsina_desc" : "povrsina";
            ViewData["Leto"] = sortOrder == "leto" ? "leto_desc" : "leto";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var vinogradi = from v in _context.Vinogradi
                select v;
            vinogradi = _context.Vinogradi.Include(v => v.Trte);
            if (!String.IsNullOrEmpty(searchString))
            {
                vinogradi = vinogradi.Where(s => s.VinogradiId.ToString().Contains(searchString)
                               || s.letoMeritve.ToString().Contains(searchString)
                               || s.StTrt.ToString().Contains(searchString)
                               || s.Povrsina.ToString().Contains(searchString));
            }
            switch (sortOrder)
            {
                case "trteId_desc":
                    vinogradi = vinogradi.OrderByDescending(v => v.TrteId);
                    break;
                case "stSort_desc":
                    vinogradi = vinogradi.OrderByDescending(v => v.StTrt);
                    break;
                case "stSort":
                    vinogradi = vinogradi.OrderBy(v => v.StTrt);
                    break;
                case "povrsina_desc":
                    vinogradi = vinogradi.OrderByDescending(v => v.Povrsina);
                    break;
                case "povrsina":
                    vinogradi = vinogradi.OrderBy(v => v.Povrsina);
                    break;
                case "leto_desc":
                    vinogradi = vinogradi.OrderByDescending(v => v.letoMeritve);
                    break;
                case "leto":
                    vinogradi = vinogradi.OrderBy(v => v.letoMeritve);
                    break;
                default:
                    vinogradi = vinogradi.OrderBy(v => v.TrteId);
                    break;
            }
            //var trtaContext = _context.Vinogradi.Include(v => v.Trte);
            int pageSize = 5;
            return View(await PaginatedList<Vinogradi>.CreateAsync(vinogradi.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Vinogradi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Vinogradi == null)
            {
                return NotFound();
            }

            var vinogradi = await _context.Vinogradi
                .Include(v => v.Trte)
                .FirstOrDefaultAsync(m => m.VinogradiId == id);
            if (vinogradi == null)
            {
                return NotFound();
            }

            return View(vinogradi);
        }

        // GET: Vinogradi/Create
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            ViewData["TrteId"] = new SelectList(_context.Trte, "TrteId", "TrteId");
            return View();
        }

        // POST: Vinogradi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VinogradiId,TrteId,Povrsina,StTrt,letoMeritve")] Vinogradi vinogradi)
        {
            var currentUser = await _usermanager.GetUserAsync(User);
            if (ModelState.IsValid)
            {
                vinogradi.DateCreated = DateTime.Now;
                vinogradi.DateEdited = DateTime.Now;
                vinogradi.Owner= currentUser;
                _context.Add(vinogradi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TrteId"] = new SelectList(_context.Trte, "TrteId", "TrteId", vinogradi.TrteId);
            return View(vinogradi);
        }

        // GET: Vinogradi/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Vinogradi == null)
            {
                return NotFound();
            }

            var vinogradi = await _context.Vinogradi.FindAsync(id);
            if (vinogradi == null)
            {
                return NotFound();
            }
            ViewData["TrteId"] = new SelectList(_context.Trte, "TrteId", "TrteId", vinogradi.TrteId);
            return View(vinogradi);
        }

        // POST: Vinogradi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VinogradiId,TrteId,Povrsina,StTrt,letoMeritve")] Vinogradi vinogradi)
        {
            if (id != vinogradi.VinogradiId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vinogradi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VinogradiExists(vinogradi.VinogradiId))
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
            ViewData["TrteId"] = new SelectList(_context.Trte, "TrteId", "TrteId", vinogradi.TrteId);
            return View(vinogradi);
        }

        // GET: Vinogradi/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Vinogradi == null)
            {
                return NotFound();
            }

            var vinogradi = await _context.Vinogradi
                .Include(v => v.Trte)
                .FirstOrDefaultAsync(m => m.VinogradiId == id);
            if (vinogradi == null)
            {
                return NotFound();
            }

            return View(vinogradi);
        }

        // POST: Vinogradi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Vinogradi == null)
            {
                return Problem("Entity set 'TrtaContext.Vinogradi'  is null.");
            }
            var vinogradi = await _context.Vinogradi.FindAsync(id);
            if (vinogradi != null)
            {
                _context.Vinogradi.Remove(vinogradi);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VinogradiExists(int id)
        {
          return _context.Vinogradi.Any(e => e.VinogradiId == id);
        }
    }
}
