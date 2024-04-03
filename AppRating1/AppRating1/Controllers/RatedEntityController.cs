using AppRating1.Controllers.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class RatedEntityController : ControllerBase
{
    public static List<RatedEntity> _ratedEntities = new List<RatedEntity>();

    // GET: api/ratedentity
    [HttpGet]
    public ActionResult<IEnumerable<RatedEntity>> GetRatedEntities()
    {
        return _ratedEntities;
    }

    // GET: api/ratedentity/{id}
    [HttpGet("{id}")]
    public ActionResult<RatedEntity> GetRatedEntity(Guid id)
    {
        var ratedEntity = _ratedEntities.FirstOrDefault(re => re.Id == id);
        if (ratedEntity == null)
        {
            return NotFound();
        }
        return ratedEntity;
    }

    // POST: api/ratedentity
    [HttpPost]
    public ActionResult<RatedEntity> AddRatedEntity(RatedEntity ratedEntity)
    {
        _ratedEntities.Add(ratedEntity);
        return CreatedAtAction(nameof(GetRatedEntity), new { id = ratedEntity.Id }, ratedEntity);
    }

    // PUT: api/ratedentity/{id}
    [HttpPut("{id}")]
    public IActionResult UpdateRatedEntity(Guid id, RatedEntity ratedEntity)
    {
        try
        {
            var existingRatedEntity = _ratedEntities.FirstOrDefault(re => re.Id == id);
            if (existingRatedEntity == null)
            {
                return NotFound();
            }
            existingRatedEntity.Name = ratedEntity.Name;
            existingRatedEntity.ServiceTypeId = ratedEntity.ServiceTypeId;
            return Ok(existingRatedEntity);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // DELETE: api/ratedentity/{id}
    [HttpDelete("{id}")]
    public IActionResult DeleteRatedEntity(Guid id)
    {
        var existingRatedEntity = _ratedEntities.FirstOrDefault(re => re.Id == id);
        if (existingRatedEntity == null)
        {
            return NotFound();
        }
        _ratedEntities.Remove(existingRatedEntity);
        return NoContent();
    }
}
