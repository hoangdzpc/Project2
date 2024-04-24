using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppRating1.Data;
using AppRating1.Models;

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
        public async Task<ActionResult<IEnumerable<ServiceTypeTable>>> GetServiceType()
        {
            return await _context.ServiceType.ToListAsync();
        }

        // GET: api/ServiceTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceTypeTable>> GetServiceType(int id)
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
        public async Task<IActionResult> PutServiceType(int id, Models.ServiceType serviceType)
        {
            var serviceType1 = _context.ServiceType.SingleOrDefault(x => x.Id == id);
            if (serviceType1 == null)
            {
                return BadRequest();
            }
            else
            {
                serviceType1.Name = serviceType.Name;
            }

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
        public async Task<ActionResult<ServiceTypeTable>> PostServiceType(Models.ServiceType serviceType)
        {
            var serviceType1 = new ServiceType()
            {
                Name = serviceType.Name,
            };
            _context.Add(serviceType1);
            await _context.SaveChangesAsync();

            return Ok(serviceType1);
        }

        // DELETE: api/ServiceTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceType(int id)
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

        private bool ServiceTypeExists(int id)
        {
            return _context.ServiceType.Any(e => e.Id == id);
        }
    }
}
