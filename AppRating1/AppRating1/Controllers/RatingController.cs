using AppRating1.Controllers.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class RatingController : ControllerBase
{
    public static List<Rating> _ratings = new List<Rating>();

    // GET: api/rating
    [HttpGet]
    public ActionResult<IEnumerable<Rating>> GetRatings()
    {
        return _ratings;
    }

    // GET: api/rating/{id}
    [HttpGet("{id}")]
    public ActionResult<Rating> GetRating(Guid id)
    {
        var rating = _ratings.FirstOrDefault(r => r.Id == id);
        if (rating == null)
        {
            return NotFound();
        }
        return rating;
    }

    // POST: api/rating
    [HttpPost]
    public ActionResult<Rating> AddRating(Rating rating)
    {
        _ratings.Add(rating);
        return CreatedAtAction(nameof(GetRating), new { id = rating.Id }, rating);
    }

    // PUT: api/rating/{id}
    [HttpPut("{id}")]
    public IActionResult UpdateRating(Guid id, Rating updatedRating)
    {
        try
        {
            var ratingToUpdate = _ratings.FirstOrDefault(r => r.Id == id);
            if (ratingToUpdate == null)
            {
                return NotFound();
            }

            ratingToUpdate.RatingValue = updatedRating.RatingValue;
            ratingToUpdate.Comment = updatedRating.Comment;

            return Ok(ratingToUpdate);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // DELETE: api/rating/{id}
    [HttpDelete("{id}")]
    public IActionResult DeleteRating(Guid id)
    {
        var ratingToDelete = _ratings.FirstOrDefault(r => r.Id == id);
        if (ratingToDelete == null)
        {
            return NotFound();
        }

        _ratings.Remove(ratingToDelete);
        return NoContent();
    }
}
