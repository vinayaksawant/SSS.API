using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SSS.API.Data;
using SSS.API.Models.Domain;

namespace SSS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobSkillsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public JobSkillsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/JobSkills
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobSkill>>> GetJobSkills()
        {
          if (_context.JobSkills == null)
          {
              return NotFound();
          }
            return await _context.JobSkills.ToListAsync();
        }

        // GET: api/JobSkills/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobSkill>> GetJobSkill(Guid id)
        {
          if (_context.JobSkills == null)
          {
              return NotFound();
          }
            var jobSkill = await _context.JobSkills.FindAsync(id);

            if (jobSkill == null)
            {
                return NotFound();
            }

            return jobSkill;
        }

        // PUT: api/JobSkills/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobSkill(Guid id, JobSkill jobSkill)
        {
            if (id != jobSkill.Id)
            {
                return BadRequest();
            }

            _context.Entry(jobSkill).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobSkillExists(id))
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

        // POST: api/JobSkills
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<JobSkill>> PostJobSkill(JobSkill jobSkill)
        {
          if (_context.JobSkills == null)
          {
              return Problem("Entity set 'ApplicationDbContext.JobSkills'  is null.");
          }
            _context.JobSkills.Add(jobSkill);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJobSkill", new { id = jobSkill.Id }, jobSkill);
        }

        // DELETE: api/JobSkills/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobSkill(Guid id)
        {
            if (_context.JobSkills == null)
            {
                return NotFound();
            }
            var jobSkill = await _context.JobSkills.FindAsync(id);
            if (jobSkill == null)
            {
                return NotFound();
            }

            _context.JobSkills.Remove(jobSkill);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JobSkillExists(Guid id)
        {
            return (_context.JobSkills?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
