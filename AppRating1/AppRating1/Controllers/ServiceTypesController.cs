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
    public class ServiceTypesController : ControllerBase
    {
        private readonly AppRating1Context _context;

        public ServiceTypesController(AppRating1Context context)
        {
            _context = context;
        }

        // GET: api/ServiceTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceType>>> GetServiceType()
        {
            return await _context.ServiceType.ToListAsync();
        }

        // GET: api/ServiceTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceType>> GetServiceType(Guid id)
        {
            var serviceType = await _context.ServiceType.FindAsync(id);

            if (serviceType == null)
            {
                return NotFound();
            }

            return serviceType;
        }

        // PUT: api/ServiceTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceType(Guid id, ServiceType serviceType)
        {
            if (id != serviceType.Id)
            {
                return BadRequest();
            }

            _context.Entry(serviceType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceTypeExists(id))
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

        // POST: api/ServiceTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ServiceType>> PostServiceType(ServiceType serviceType)
        {
            _context.ServiceType.Add(serviceType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServiceType", new { id = serviceType.Id }, serviceType);
        }

        // DELETE: api/ServiceTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceType(Guid id)
        {
            var serviceType = await _context.ServiceType.FindAsync(id);
            if (serviceType == null)
            {
                return NotFound();
            }

            _context.ServiceType.Remove(serviceType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServiceTypeExists(Guid id)
        {
            return _context.ServiceType.Any(e => e.Id == id);
        }
    }
}
