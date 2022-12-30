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
    [Route("api/v1/Trte")]
    [ApiController]
    [ApiKeyAuth]
    public class TrteApiController : ControllerBase
    {
        private readonly TrtaContext _context;

        public TrteApiController(TrtaContext context)
        {
            _context = context;
        }

        // GET: api/TrteApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trte>>> GetTrte()
        {
            return await _context.Trte.ToListAsync();
        }

        // GET: api/TrteApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Trte>> GetTrte(int id)
        {
            var trte = await _context.Trte.FindAsync(id);

            if (trte == null)
            {
                return NotFound();
            }

            return trte;
        }

        // PUT: api/TrteApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrte(int id, Trte trte)
        {
            if (id != trte.TrteId)
            {
                return BadRequest();
            }

            _context.Entry(trte).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrteExists(id))
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

        // POST: api/TrteApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Trte>> PostTrte(Trte trte)
        {
            _context.Trte.Add(trte);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrte", new { id = trte.TrteId }, trte);
        }

        // DELETE: api/TrteApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrte(int id)
        {
            var trte = await _context.Trte.FindAsync(id);
            if (trte == null)
            {
                return NotFound();
            }

            _context.Trte.Remove(trte);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrteExists(int id)
        {
            return _context.Trte.Any(e => e.TrteId == id);
        }
    }
}
