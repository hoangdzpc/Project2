using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppRating1.Controllers.Models;
using AppRating1.Data;

namespace AppRating1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatedEntitiesController : ControllerBase
    {
        private readonly AppRating1Context _context;

        public RatedEntitiesController(AppRating1Context context)
        {
            _context = context;
        }

        // GET: api/RatedEntities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RatedEntity>>> GetRatedEntity()
        {
            return await _context.RatedEntity.ToListAsync();
        }

        // GET: api/RatedEntities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RatedEntity>> GetRatedEntity(Guid id)
        {
            var ratedEntity = await _context.RatedEntity.FindAsync(id);

            if (ratedEntity == null)
            {
                return NotFound();
            }

            return ratedEntity;
        }

        // PUT: api/RatedEntities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRatedEntity(Guid id, RatedEntity ratedEntity)
        {
            if (id != ratedEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(ratedEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RatedEntityExists(id))
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

        // POST: api/RatedEntities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RatedEntity>> PostRatedEntity(RatedEntity ratedEntity)
        {
            _context.RatedEntity.Add(ratedEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRatedEntity", new { id = ratedEntity.Id }, ratedEntity);
        }

        // DELETE: api/RatedEntities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRatedEntity(Guid id)
        {
            var ratedEntity = await _context.RatedEntity.FindAsync(id);
            if (ratedEntity == null)
            {
                return NotFound();
            }

            _context.RatedEntity.Remove(ratedEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RatedEntityExists(Guid id)
        {
            return _context.RatedEntity.Any(e => e.Id == id);
        }
    }
}
