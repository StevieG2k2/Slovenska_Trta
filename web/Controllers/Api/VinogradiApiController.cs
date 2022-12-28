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
    [Route("api/v1/Vinogradi")]
    [ApiController]
    public class VinogradiApiController : ControllerBase
    {
        private readonly TrtaContext _context;

        public VinogradiApiController(TrtaContext context)
        {
            _context = context;
        }

        // GET: api/VinogradiApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vinogradi>>> GetVinogradi()
        {
            return await _context.Vinogradi.ToListAsync();
        }

        // GET: api/VinogradiApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vinogradi>> GetVinogradi(int id)
        {
            var vinogradi = await _context.Vinogradi.FindAsync(id);

            if (vinogradi == null)
            {
                return NotFound();
            }

            return vinogradi;
        }

        // PUT: api/VinogradiApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVinogradi(int id, Vinogradi vinogradi)
        {
            if (id != vinogradi.VinogradiId)
            {
                return BadRequest();
            }

            _context.Entry(vinogradi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VinogradiExists(id))
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

        // POST: api/VinogradiApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vinogradi>> PostVinogradi(Vinogradi vinogradi)
        {
            _context.Vinogradi.Add(vinogradi);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVinogradi", new { id = vinogradi.VinogradiId }, vinogradi);
        }

        // DELETE: api/VinogradiApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVinogradi(int id)
        {
            var vinogradi = await _context.Vinogradi.FindAsync(id);
            if (vinogradi == null)
            {
                return NotFound();
            }

            _context.Vinogradi.Remove(vinogradi);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VinogradiExists(int id)
        {
            return _context.Vinogradi.Any(e => e.VinogradiId == id);
        }
    }
}
