using AppRating1.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YourNamespace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingViewModelController : ControllerBase
    {
        private readonly AppRating1Context _context;

        public RatingViewModelController(AppRating1Context context)
        {
            _context = context;
        }

        // GET: api/RatingViewModel
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RatingViewModel>>> GetRatingViewModels()
        {
            var ratings = await _context.RatingTable
                .Include(r => r.User)
                .Include(r => r.RatedEntity)
                .Select(r => new RatingViewModel
                {
                    RatingId = r.Id,
                    UserName = r.User.Username,
                    RatedEntityName = r.RatedEntity.Name,
                    RatingValue = r.RatingValue,
                    Comment = r.Comment
                })
                .ToListAsync();

            return ratings;
        }

        // GET: api/RatingViewModel/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RatingViewModel>> GetRatingViewModel(int id)
        {
            var rating = await _context.RatingTable
                .Include(r => r.User)
                .Include(r => r.RatedEntity)
                .Select(r => new RatingViewModel
                {
                    RatingId = r.Id,
                    UserName = r.User.Username,
                    RatedEntityName = r.RatedEntity.Name,
                    RatingValue = r.RatingValue,
                    Comment = r.Comment
                })
                .FirstOrDefaultAsync(r => r.RatingId == id);

            if (rating == null)
            {
                return NotFound();
            }

            return rating;
        }

        // PUT: api/RatingViewModel/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRatingViewModel(int id, RatingViewModel ratingViewModel)
        {
            if (id != ratingViewModel.RatingId)
            {
                return BadRequest();
            }

            var rating = await _context.RatingTable.FindAsync(id);
            if (rating == null)
            {
                return NotFound();
            }

            rating.RatingValue = ratingViewModel.RatingValue;
            rating.Comment = ratingViewModel.Comment;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RatingViewModelExists(id))
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

        // POST: api/RatingViewModel
        [HttpPost]
        public async Task<ActionResult<RatingViewModel>> PostRatingViewModel(RatingViewModel ratingViewModel)
        {
            var rating = new RatingTable
            {
                RatingValue = ratingViewModel.RatingValue,
                Comment = ratingViewModel.Comment
                // Lưu ý: Bạn cần cập nhật khóa ngoại UserId và RatedEntityId ở đây
            };

            _context.RatingTable.Add(rating);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRatingViewModel), new { id = rating.Id }, ratingViewModel);
        }

        // DELETE: api/RatingViewModel/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRatingViewModel(int id)
        {
            var rating = await _context.RatingTable.FindAsync(id);
            if (rating == null)
            {
                return NotFound();
            }

            _context.RatingTable.Remove(rating);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RatingViewModelExists(int id)
        {
            return _context.RatingTable.Any(e => e.Id == id);
        }
    }
}
