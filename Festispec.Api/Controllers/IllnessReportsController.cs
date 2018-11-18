using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Festispec.Api.Database;
using Festispec.Domain;

namespace Festispec.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IllnessReportsController : ControllerBase
    {
        private readonly FestispecContext _context;

        public IllnessReportsController(FestispecContext context)
        {
            _context = context;
        }

        // GET: api/IllnessReports
        [HttpGet]
        public IEnumerable<IllnessReport> GetIllnessReports()
        {
            return _context.IllnessReports;
        }

        // GET: api/IllnessReports/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetIllnessReport([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var illnessReport = await _context.IllnessReports.FindAsync(id);

            if (illnessReport == null)
            {
                return NotFound();
            }

            return Ok(illnessReport);
        }

        // PUT: api/IllnessReports/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIllnessReport([FromRoute] int id, [FromBody] IllnessReport illnessReport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != illnessReport.Id)
            {
                return BadRequest();
            }

            _context.Entry(illnessReport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IllnessReportExists(id))
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

        // POST: api/IllnessReports
        [HttpPost]
        public async Task<IActionResult> PostIllnessReport([FromBody] IllnessReport illnessReport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.IllnessReports.Add(illnessReport);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIllnessReport", new { id = illnessReport.Id }, illnessReport);
        }

        // DELETE: api/IllnessReports/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIllnessReport([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var illnessReport = await _context.IllnessReports.FindAsync(id);
            if (illnessReport == null)
            {
                return NotFound();
            }

            _context.IllnessReports.Remove(illnessReport);
            await _context.SaveChangesAsync();

            return Ok(illnessReport);
        }

        private bool IllnessReportExists(int id)
        {
            return _context.IllnessReports.Any(e => e.Id == id);
        }
    }
}