using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Festispec.Database;
using Festispec.Database.Models;

namespace Festispec.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionItemsController : ControllerBase
    {
        private readonly FestispecContext _context;

        public QuestionItemsController(FestispecContext context)
        {
            _context = context;
        }

        // GET: api/QuestionItems
        [HttpGet]
        public IEnumerable<QuestionItem> GetQuestionItems()
        {
            return _context.QuestionItems;
        }

        // GET: api/QuestionItems/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestionItem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var questionItem = await _context.QuestionItems.FindAsync(id);

            if (questionItem == null)
            {
                return NotFound();
            }

            return Ok(questionItem);
        }

        // PUT: api/QuestionItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestionItem([FromRoute] int id, [FromBody] QuestionItem questionItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != questionItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(questionItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionItemExists(id))
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

        // POST: api/QuestionItems
        [HttpPost]
        public async Task<IActionResult> PostQuestionItem([FromBody] QuestionItem questionItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.QuestionItems.Add(questionItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuestionItem", new { id = questionItem.Id }, questionItem);
        }

        // DELETE: api/QuestionItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestionItem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var questionItem = await _context.QuestionItems.FindAsync(id);
            if (questionItem == null)
            {
                return NotFound();
            }

            _context.QuestionItems.Remove(questionItem);
            await _context.SaveChangesAsync();

            return Ok(questionItem);
        }

        private bool QuestionItemExists(int id)
        {
            return _context.QuestionItems.Any(e => e.Id == id);
        }
    }
}