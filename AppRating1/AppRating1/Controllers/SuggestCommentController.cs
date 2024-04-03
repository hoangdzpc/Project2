using AppRating1.Controllers.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class SuggestCommentController : ControllerBase
{
    public static List<SuggestComment> _suggestComments = new List<SuggestComment>();

    // GET: api/suggestcomment
    [HttpGet]
    public ActionResult<IEnumerable<SuggestComment>> GetSuggestComments()
    {
        return _suggestComments;
    }

    // GET: api/suggestcomment/{id}
    [HttpGet("{id}")]
    public ActionResult<SuggestComment> GetSuggestComment(Guid id)
    {
        var suggestComment = _suggestComments.FirstOrDefault(ac => ac.Id == id);
        if (suggestComment == null)
        {
            return NotFound();
        }
        return suggestComment;
    }

    // POST: api/suggestcomment
    [HttpPost]
    public ActionResult<SuggestComment> AddSuggestComment(SuggestComment suggestComment)
    {
        _suggestComments.Add(suggestComment);
        return CreatedAtAction(nameof(GetSuggestComment), new { id = suggestComment.Id }, suggestComment);
    }

    // PUT: api/suggestcomment/{id}
    [HttpPut("{id}")]
    public IActionResult UpdateSuggestComment(Guid id, SuggestComment suggestComment)
    {
        try
        {
            var existingSuggestComment = _suggestComments.FirstOrDefault(ac => ac.Id == id);
            if (existingSuggestComment == null)
            {
                return NotFound();
            }
            existingSuggestComment.Comment = suggestComment.Comment;
            // Cập nhật các thông tin khác nếu cần
            return Ok(existingSuggestComment);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // DELETE: api/suggestcomment/{id}
    [HttpDelete("{id}")]
    public IActionResult DeleteSuggestComment(Guid id)
    {
        var existingSuggestComment = _suggestComments.FirstOrDefault(ac => ac.Id == id);
        if (existingSuggestComment == null)
        {
            return NotFound();
        }
        _suggestComments.Remove(existingSuggestComment);
        return NoContent();
    }
}
