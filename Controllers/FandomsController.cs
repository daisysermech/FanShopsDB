﻿using System;
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
    public class FandomsController : ControllerBase
    {
        private readonly FanShopsDBContext _context;

        public FandomsController(FanShopsDBContext context)
        {
            _context = context;
        }

        // GET: api/Fandoms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fandom>>> GetFandoms()
        {
            return await _context.Fandoms.ToListAsync();
        }

        // GET: api/Fandoms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fandom>> GetFandom(int id)
        {
            var fandom = await _context.Fandoms.FindAsync(id);

            if (fandom == null)
            {
                return NotFound();
            }

            return fandom;
        }

        // PUT: api/Fandoms/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFandom(int id, Fandom fandom)
        {
            if (id != fandom.ID)
            {
                return BadRequest();
            }

            _context.Entry(fandom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FandomExists(id))
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

        // POST: api/Fandoms
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Fandom>> PostFandom(Fandom fandom)
        {
            _context.Fandoms.Add(fandom);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFandom", new { id = fandom.ID }, fandom);
        }

        // DELETE: api/Fandoms/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Fandom>> DeleteFandom(int id)
        {
            var fandom = await _context.Fandoms.FindAsync(id);
            if (fandom == null)
            {
                return NotFound();
            }

            _context.Fandoms.Remove(fandom);
            await _context.SaveChangesAsync();

            return fandom;
        }

        private bool FandomExists(int id)
        {
            return _context.Fandoms.Any(e => e.ID == id);
        }
    }
}