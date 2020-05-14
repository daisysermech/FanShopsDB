using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FanShopsDB.Models;

namespace FanShopsDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssortmentsController : ControllerBase
    {
        private readonly FanShopsDBContext _context;

        public AssortmentsController(FanShopsDBContext context)
        {
            _context = context;
        }

        // GET: api/Assortments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Assortment>>> GetAssortments()
        {
            return await _context.Assortments.ToListAsync();
        }

        // GET: api/Assortments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Assortment>> GetAssortment(int id)
        {
            var assortment = await _context.Assortments.FindAsync(id);

            if (assortment == null)
            {
                return NotFound();
            }

            return assortment;
        }

        // PUT: api/Assortments/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssortment(int id, Assortment assortment)
        {
            if (id != assortment.ID)
            {
                return BadRequest();
            }

            _context.Entry(assortment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssortmentExists(id))
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

        // POST: api/Assortments
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Assortment>> PostAssortment(Assortment assortment)
        {
            _context.Assortments.Add(assortment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAssortment", new { id = assortment.ID }, assortment);
        }

        // DELETE: api/Assortments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Assortment>> DeleteAssortment(int id)
        {
            var assortment = await _context.Assortments.FindAsync(id);
            if (assortment == null)
            {
                return NotFound();
            }

            _context.Assortments.Remove(assortment);
            await _context.SaveChangesAsync();

            return assortment;
        }

        private bool AssortmentExists(int id)
        {
            return _context.Assortments.Any(e => e.ID == id);
        }
    }
}
