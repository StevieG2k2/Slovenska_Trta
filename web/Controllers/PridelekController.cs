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
    public class PridelekController : Controller
    {
        private readonly TrtaContext _context;
        private readonly UserManager<ApplicationUser> _usermanager;

        public PridelekController(TrtaContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _usermanager = userManager;
        }

        // GET: Pridelek
        public async Task<IActionResult> Index(string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {   
            ViewData["CurrentSort"] = sortOrder;
            ViewData["VinogradId"] = sortOrder == "vinogradId"  ? "vinogradId_desc" : "vinogradId";
            ViewData["Kolicina"] = sortOrder == "kolicina"  ? "kolicina_desc" : "kolicina";
            ViewData["KolNaHa"] = sortOrder == "hektar" ? "hektar_desc" : "hektar";
            ViewData["KgNaTrto"] = sortOrder == "teza" ? "teza_desc" : "teza";
            ViewData["Leto"] = sortOrder == "leto" ? "leto_desc" : "leto";
            ViewData["TrteId"] = String.IsNullOrEmpty(sortOrder) ? "trteId_desc" : "";
            
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var pridelek = from v in _context.Pridelek
                select v;

            pridelek = _context.Pridelek
                .Include(p => p.Trte)
                .Include(p => p.Vinogradi);
            if (!String.IsNullOrEmpty(searchString))

            {
                pridelek = pridelek.Where(s => s.VinogradId.ToString().Contains(searchString)
                               || s.letoMeritve.ToString().Contains(searchString)
                               || s.Kolicina.ToString().Contains(searchString)
                               || s.KolNaHa.ToString().Contains(searchString)
                               || s.TrteId.ToString().Contains(searchString)
                               || s.KgNaTrto.ToString().Contains(searchString));
            }

            switch (sortOrder)
            {
                case "vinogradId_desc":
                    pridelek = pridelek.OrderByDescending(v => v.VinogradId);
                    break;
                case "vinogradId":
                    pridelek = pridelek.OrderBy(v => v.VinogradId);
                    break;
                case "kolicina_desc":
                    pridelek = pridelek.OrderByDescending(v => v.Kolicina);
                    break;
                case "kolicina":
                    pridelek = pridelek.OrderBy(v => v.Kolicina);
                    break;
                case "hektar_desc":
                    pridelek = pridelek.OrderByDescending(v => v.KolNaHa);
                    break;
                case "hektar":
                    pridelek = pridelek.OrderBy(v => v.KolNaHa);
                    break;
                case "teza_desc":
                    pridelek = pridelek.OrderByDescending(v => v.KgNaTrto);
                    break;
                case "teza":
                    pridelek = pridelek.OrderBy(v => v.KgNaTrto);
                    break;
                case "leto_desc":
                    pridelek = pridelek.OrderByDescending(v => v.letoMeritve);
                    break;
                case "leto":
                    pridelek = pridelek.OrderBy(v => v.letoMeritve);
                    break;
                case "trteId_desc":
                    pridelek = pridelek.OrderByDescending(v => v.TrteId);
                    break;
                default:
                    pridelek = pridelek.OrderBy(v => v.TrteId);
                    break;
            }
            
            int pageSize = 5;
            return View(await PaginatedList<Pridelek>.CreateAsync(pridelek.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Pridelek/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pridelek == null)
            {
                return NotFound();
            }

            var pridelek = await _context.Pridelek
                //.Include(p => p.Trte)
                .FirstOrDefaultAsync(m => m.PridelekId == id);
            if (pridelek == null)
            {
                return NotFound();
            }
            return View(pridelek);
        }

        // GET: Pridelek/Create
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            ViewData["TrteId"] = new SelectList(_context.Trte, "TrteId", "TrteId");
            return View();
        }

        // POST: Pridelek/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PridelekId,TrteId,VinogradId,Kolicina,KolNaHa,KgNaTrto,letoMeritve")] Pridelek pridelek)
        {
            var currentUser = await _usermanager.GetUserAsync(User);
            if (ModelState.IsValid)
            {
                pridelek.DateCreated = DateTime.Now;
                pridelek.DateEdited = DateTime.Now;
                pridelek.Owner= currentUser;
                _context.Add(pridelek);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TrteId"] = new SelectList(_context.Trte, "TrteId", "TrteId", pridelek.TrteId);
            return View(pridelek);
        }

        // GET: Pridelek/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pridelek == null)
            {
                return NotFound();
            }

            var pridelek = await _context.Pridelek.FindAsync(id);
            if (pridelek == null)
            {
                return NotFound();
            }
            ViewData["TrteId"] = new SelectList(_context.Trte, "TrteId", "TrteId", pridelek.TrteId);
            return View(pridelek);
        }

        // POST: Pridelek/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PridelekId,TrteId,VinogradId,Kolicina,KolNaHa,KgNaTrto,letoMeritve")] Pridelek pridelek)
        {
            if (id != pridelek.PridelekId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pridelek);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PridelekExists(pridelek.PridelekId))
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
            ViewData["TrteId"] = new SelectList(_context.Trte, "TrteId", "TrteId", pridelek.TrteId);
            return View(pridelek);
        }

        // GET: Pridelek/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pridelek == null)
            {
                return NotFound();
            }

            var pridelek = await _context.Pridelek
                .Include(p => p.Trte)
                .FirstOrDefaultAsync(m => m.PridelekId == id);
            if (pridelek == null)
            {
                return NotFound();
            }

            return View(pridelek);
        }

        // POST: Pridelek/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pridelek == null)
            {
                return Problem("Entity set 'TrtaContext.Pridelek'  is null.");
            }
            var pridelek = await _context.Pridelek.FindAsync(id);
            if (pridelek != null)
            {
                _context.Pridelek.Remove(pridelek);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PridelekExists(int id)
        {
          return _context.Pridelek.Any(e => e.PridelekId == id);
        }
    }
}
