using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web.Data;
using web.Models;
using web.Filters;

namespace web.Controllers_Api
{
    [Route("api/v1/Pridelek")]
    [ApiController]
    [ApiKeyAuth]
    public class PridelekApiController : ControllerBase
    {
        private readonly TrtaContext _context;

        public PridelekApiController(TrtaContext context)
        {
            _context = context;
        }

        // GET: api/PridelekApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pridelek>>> GetPridelek()
        {
            return await _context.Pridelek.ToListAsync();
        }

        // GET: api/PridelekApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pridelek>> GetPridelek(int id)
        {
            var pridelek = await _context.Pridelek.FindAsync(id);

            if (pridelek == null)
            {
                return NotFound();
            }

            return pridelek;
        }

        // PUT: api/PridelekApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPridelek(int id, Pridelek pridelek)
        {
            if (id != pridelek.PridelekId)
            {
                return BadRequest();
            }

            _context.Entry(pridelek).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PridelekExists(id))
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

        // POST: api/PridelekApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pridelek>> PostPridelek(Pridelek pridelek)
        {
            _context.Pridelek.Add(pridelek);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPridelek", new { id = pridelek.PridelekId }, pridelek);
        }

        // DELETE: api/PridelekApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePridelek(int id)
        {
            var pridelek = await _context.Pridelek.FindAsync(id);
            if (pridelek == null)
            {
                return NotFound();
            }

            _context.Pridelek.Remove(pridelek);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PridelekExists(int id)
        {
            return _context.Pridelek.Any(e => e.PridelekId == id);
        }
    }
}
