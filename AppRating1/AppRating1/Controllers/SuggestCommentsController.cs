using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppRating1.Models;
using AppRating1.Data;

namespace AppRating1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuggestCommentsController : ControllerBase
    {
        private readonly AppRating1Context _context;

        public SuggestCommentsController(AppRating1Context context)
        {
            _context = context;
        }

        // GET: api/SuggestComments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SuggestCommentTable>>> GetSuggestComment()
        {
            return await _context.SuggestComment.ToListAsync();
        }

        // GET: api/SuggestComments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SuggestCommentTable>> GetSuggestComment(int id)
        {
            var suggestComment = await _context.SuggestComment.FindAsync(id);

            if (suggestComment == null)
            {
                return NotFound();
            }

            return suggestComment;
        }

        // PUT: api/SuggestComments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSuggestComment(int id, SuggestCommentTable suggestComment)
        {
            var suggestComment1 = _context.SuggestComment.SingleOrDefault(lo => lo.Id == id);
            if (suggestComment1 == null)
            {
                return BadRequest();
            }
            else
            {
                suggestComment1.Comment = suggestComment.Comment;
            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SuggestCommentExists(id))
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

        // POST: api/SuggestComments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SuggestCommentTable>> PostSuggestComment(SuggestComment suggestComment)
        {
            var suggestComment1 = new SuggestComment()
            {
                Comment = suggestComment.Comment,
                RatedEntityId = suggestComment.RatedEntityId,
            };
            _context.Add(suggestComment1);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSuggestComment", new { id = suggestComment.Id }, suggestComment);
        }

        // DELETE: api/SuggestComments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSuggestComment(int id)
        {
            var suggestComment = await _context.SuggestComment.FindAsync(id);
            if (suggestComment == null)
            {
                return NotFound();
            }

            _context.SuggestComment.Remove(suggestComment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SuggestCommentExists(int id)
        {
            return _context.SuggestComment.Any(e => e.Id == id);
        }
    }
}
