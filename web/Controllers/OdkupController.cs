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
    public class OdkupController : Controller
    {
        
        private readonly TrtaContext _context;
        private readonly UserManager<ApplicationUser> _usermanager;

        public OdkupController(TrtaContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _usermanager = userManager;
        }

        // GET: Odkup
        public async Task<IActionResult> Index()
        {
              return View(await _context.Odkup.ToListAsync());
        }

        // GET: Odkup/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Odkup == null)
            {
                return NotFound();
            }

            var odkup = await _context.Odkup
                .FirstOrDefaultAsync(m => m.OdkupId == id);
            if (odkup == null)
            {
                return NotFound();
            }

            return View(odkup);
        }

        // GET: Odkup/Create
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Odkup/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OdkupId,PridelekId,Kolicina,CenaNaKg,letoMeritve")] Odkup odkup)
        {
            var currentUser = await _usermanager.GetUserAsync(User);
            if (ModelState.IsValid)
            {
                odkup.DateCreated = DateTime.Now;
                odkup.DateEdited = DateTime.Now;
                odkup.Owner= currentUser;
                _context.Add(odkup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(odkup);
        }

        // GET: Odkup/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Odkup == null)
            {
                return NotFound();
            }

            var odkup = await _context.Odkup.FindAsync(id);
            if (odkup == null)
            {
                return NotFound();
            }
            return View(odkup);
        }

        // POST: Odkup/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OdkupId,PridelekId,Kolicina,CenaNaKg,letoMeritve")] Odkup odkup)
        {
            if (id != odkup.OdkupId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(odkup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OdkupExists(odkup.OdkupId))
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
            return View(odkup);
        }

        // GET: Odkup/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Odkup == null)
            {
                return NotFound();
            }

            var odkup = await _context.Odkup
                .FirstOrDefaultAsync(m => m.OdkupId == id);
            if (odkup == null)
            {
                return NotFound();
            }

            return View(odkup);
        }

        // POST: Odkup/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Odkup == null)
            {
                return Problem("Entity set 'TrtaContext.Odkup'  is null.");
            }
            var odkup = await _context.Odkup.FindAsync(id);
            if (odkup != null)
            {
                _context.Odkup.Remove(odkup);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OdkupExists(int id)
        {
          return _context.Odkup.Any(e => e.OdkupId == id);
        }
    }
}
