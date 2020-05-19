using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using FanShopsDB.Models;
using System.Threading.Tasks;

namespace FanShopsDB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FandomsController : ControllerBase
    {
        FanShopsDBContext db;
        public FandomsController(FanShopsDBContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fandom>>> Get()
        {
            return await db.Fandoms.ToListAsync();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fandom>> Get(int id)
        {
            Fandom fandom = await db.Fandoms.FirstOrDefaultAsync(x => x.ID == id);
            if (fandom == null)
                return NotFound();
            return new ObjectResult(fandom);
        }

        // POST api/users
        [HttpPost]
        public async Task<ActionResult<Fandom>> Post(Fandom fandom)
        {
            if (fandom == null)
            {
                return BadRequest();
            }

            db.Fandoms.Add(fandom);
            await db.SaveChangesAsync();
            return Ok(fandom);
        }

        // PUT api/users/
        [HttpPut]
        public async Task<ActionResult<Fandom>> Put(Fandom fandom)
        {
            if (fandom == null)
            {
                return BadRequest();
            }
            if (!db.Fandoms.Any(x => x.ID == fandom.ID))
            {
                return NotFound();
            }

            db.Update(fandom);
            await db.SaveChangesAsync();
            return Ok(fandom);
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Fandom>> Delete(int id)
        {
            Fandom fandom = db.Fandoms.FirstOrDefault(x => x.ID == id);
            if (fandom == null)
            {
                return NotFound();
            }
            db.Fandoms.Remove(fandom);
            await db.SaveChangesAsync();
            return Ok(fandom);
        }
    }
}