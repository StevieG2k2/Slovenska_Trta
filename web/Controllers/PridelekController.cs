using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using web.Data;
using web.Models;

namespace web.Controllers
{
    public class PridelekController : Controller
    {
        private readonly TrtaContext _context;

        public PridelekController(TrtaContext context)
        {
            _context = context;
        }

        // GET: Pridelek
        public async Task<IActionResult> Index()
        {
            var trtaContext = _context.Pridelek.Include(p => p.Trte);
            return View(await trtaContext.ToListAsync());
        }

        // GET: Pridelek/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: Pridelek/Create
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
            if (ModelState.IsValid)
            {
                _context.Add(pridelek);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TrteId"] = new SelectList(_context.Trte, "TrteId", "TrteId", pridelek.TrteId);
            return View(pridelek);
        }

        // GET: Pridelek/Edit/5
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
