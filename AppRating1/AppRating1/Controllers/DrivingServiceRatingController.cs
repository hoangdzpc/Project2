using AppRating1.Controllers.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AppRating1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvaluationController : ControllerBase
    {
        public static List<DriverEvaluation> evaluations = new List<DriverEvaluation>();

        // GET: api/evaluation
        [HttpGet]
        public ActionResult<IEnumerable<DriverEvaluation>> GetEvaluations()
        {
            return Ok(evaluations);
        }

        // GET: api/evaluation/{rating}
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<DriverEvaluation>> GetEvaluationsByRating(string id)
        {
            try
            {
                var evaluations1 = evaluations.SingleOrDefault(e => e.id == Guid.Parse(id));
                if (evaluations1 == null)
                {
                    return NotFound();
                }
                return Ok(evaluations1);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/evaluation
        [HttpPost]
        public ActionResult<DriverEvaluation> AddEvaluation(DriverEvaluation evaluation1)
        {
            var evaluation = new DriverEvaluation()
            {
                id = Guid.NewGuid(),
                Name = evaluation1.Name,
                Rating = evaluation1.Rating,
                Comment = evaluation1.Comment,
            };
                evaluations.Add(evaluation1);
            return Ok(new
            {
                Success = true,
                Data = evaluation
            });    
        }

        // PUT: api/evaluation/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateEvaluation(string id, DriverEvaluation evaluationEdit)
        {
            try
            {
                var evaluations1 = evaluations.SingleOrDefault(e => e.id == Guid.Parse(id));
                if (evaluations1 == null)
                {
                    return NotFound();
                }
                if(id != evaluations1.id.ToString() || evaluationEdit.Name != evaluations1.Name)
                {
                    return BadRequest();
                }
                //Update
                evaluations1.Rating = evaluationEdit.Rating;
                evaluations1.Comment = evaluationEdit.Comment;

                return Ok(evaluations1);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/evaluation/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteEvaluation(string id)
        {
            try
            {
                var evaluations1 = evaluations.SingleOrDefault(e => e.id == Guid.Parse(id));
                if (evaluations1 == null)
                {
                    return NotFound();
                }
                //Remove
                evaluations.Remove(evaluations1);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }         
        }
    }
}