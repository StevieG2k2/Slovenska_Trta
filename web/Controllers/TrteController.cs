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
    public class TrteController : Controller
    {
        private readonly TrtaContext _context;

        public TrteController(TrtaContext context)
        {
            _context = context;
        }

        // GET: Trte
        public async Task<IActionResult> Index()
        {
              return View(await _context.Trte.ToListAsync());
        }

        // GET: Trte/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Trte == null)
            {
                return NotFound();
            }

            var trte = await _context.Trte
                .FirstOrDefaultAsync(m => m.TrteId == id);
            if (trte == null)
            {
                return NotFound();
            }

            return View(trte);
        }

        // GET: Trte/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trte/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TrteId,Sorta")] Trte trte)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trte);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trte);
        }

        // GET: Trte/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Trte == null)
            {
                return NotFound();
            }

            var trte = await _context.Trte.FindAsync(id);
            if (trte == null)
            {
                return NotFound();
            }
            return View(trte);
        }

        // POST: Trte/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TrteId,Sorta")] Trte trte)
        {
            if (id != trte.TrteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trte);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrteExists(trte.TrteId))
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
            return View(trte);
        }

        // GET: Trte/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Trte == null)
            {
                return NotFound();
            }

            var trte = await _context.Trte
                .FirstOrDefaultAsync(m => m.TrteId == id);
            if (trte == null)
            {
                return NotFound();
            }

            return View(trte);
        }

        // POST: Trte/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Trte == null)
            {
                return Problem("Entity set 'TrtaContext.Trte'  is null.");
            }
            var trte = await _context.Trte.FindAsync(id);
            if (trte != null)
            {
                _context.Trte.Remove(trte);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrteExists(int id)
        {
          return _context.Trte.Any(e => e.TrteId == id);
        }
    }
}
