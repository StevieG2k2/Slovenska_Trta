using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web.Data;
using web.Models;

namespace web.Controllers_Api
{
    [Route("api/v1/Odkup")]
    [ApiController]
    public class OdkupApiController : ControllerBase
    {
        private readonly TrtaContext _context;

        public OdkupApiController(TrtaContext context)
        {
            _context = context;
        }

        // GET: api/OdkupApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Odkup>>> GetOdkup()
        {
            return await _context.Odkup.ToListAsync();
        }

        // GET: api/OdkupApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Odkup>> GetOdkup(int id)
        {
            var odkup = await _context.Odkup.FindAsync(id);

            if (odkup == null)
            {
                return NotFound();
            }

            return odkup;
        }

        // PUT: api/OdkupApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOdkup(int id, Odkup odkup)
        {
            if (id != odkup.OdkupId)
            {
                return BadRequest();
            }

            _context.Entry(odkup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OdkupExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/OdkupApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Odkup>> PostOdkup(Odkup odkup)
        {
            _context.Odkup.Add(odkup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOdkup", new { id = odkup.OdkupId }, odkup);
        }

        // DELETE: api/OdkupApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOdkup(int id)
        {
            var odkup = await _context.Odkup.FindAsync(id);
            if (odkup == null)
            {
                return NotFound();
            }

            _context.Odkup.Remove(odkup);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OdkupExists(int id)
        {
            return _context.Odkup.Any(e => e.OdkupId == id);
        }
    }
}
