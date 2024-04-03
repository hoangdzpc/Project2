using AppRating1.Controllers.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class ServiceTypeController : ControllerBase
{
    public static List<ServiceType> _serviceTypes = new List<ServiceType>();

    // GET: api/servicetype
    [HttpGet]
    public ActionResult<IEnumerable<ServiceType>> GetServiceTypes()
    {
        return _serviceTypes;
    }

    // GET: api/servicetype/{id}
    [HttpGet("{id}")]
    public ActionResult<ServiceType> GetServiceType(Guid id)
    {
        var serviceType = _serviceTypes.FirstOrDefault(st => st.Id == id);
        if (serviceType == null)
        {
            return NotFound();
        }
        return serviceType;
    }

    // POST: api/servicetype
    [HttpPost]
    public ActionResult<ServiceType> AddServiceType(ServiceType serviceType)
    {
        _serviceTypes.Add(serviceType);
        return CreatedAtAction(nameof(GetServiceType), new { id = serviceType.Id }, serviceType);
    }

    // PUT: api/servicetype/{id}
    [HttpPut("{id}")]
    public IActionResult UpdateServiceType(Guid id, ServiceType serviceType)
    {
        try
        {
            var existingServiceType = _serviceTypes.FirstOrDefault(st => st.Id == id);
            if (existingServiceType == null)
            {
                return NotFound();
            }
            //Update
            existingServiceType.Name = serviceType.Name;

            return Ok(existingServiceType);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
}

// DELETE: api/servicetype/{id}
[HttpDelete("{id}")]
    public IActionResult DeleteServiceType(Guid id)
    {
        var existingServiceType = _serviceTypes.FirstOrDefault(st => st.Id == id);
        if (existingServiceType == null)
        {
            return NotFound();
        }
        _serviceTypes.Remove(existingServiceType);
        return NoContent();
    }
}
